//----------------------------------------------------------------------------
// MIT License
// 
// Copyright (c) 2017 SSASQueryAnalyzer
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//----------------------------------------------------------------------------

namespace SSASQueryAnalyzer.Server.Profiler
{
    using Microsoft.AnalysisServices;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    internal static class Extension
    {
        public static string ToNamespace(this ProfilerResult profilerResult)
        {
            #region Argument exception

            if (profilerResult == null)
                throw new ArgumentNullException("profilerResult");

            #endregion

            return "{0}".FormatWith(ProfilerResult.Namespace);
        }

        public static string ToNamespace(this TraceEvent traceEvent)
        {
            #region Argument exception

            if (traceEvent == null)
                throw new ArgumentNullException("traceEvent");

            #endregion

            return "{0}".FormatWith(ProfilerResult.Namespace);
        }

        public static IEnumerable<DataTable> ToDataTables(this IList<TraceEventArgs> traces, IList<TraceEvent> currentTraceEvents, bool executeForPrepare, ref int id)
        {            
            int __id = id;
            var profilerTables = currentTraceEvents
#if !DEBUG
                .AsParallel().WithDegreeOfParallelism(currentTraceEvents.Count)
#endif
                .Select((e) =>
                {
                    var eventTable = e.ToDataTable();
                    var eventClass = eventTable.TableName.ToEventClass();

                    if (executeForPrepare)
                        return eventTable;

                    var mapping = eventTable.Columns.Cast<DataColumn>()
                        .Select((c) => new
                        {
                            DataColumn = c,
                            Property = ProfilerResult.ItemsType.GetProperty(c.ColumnName)
                        })
                        .Select((c) =>  new
                        {
                            Property = c.Property,
                            DataColumn = c.DataColumn,
                            TraceColumn = (TraceColumn)Enum.Parse(typeof(TraceColumn), c.Property.Name)
                        })
                        .ToArray();

                    var columnID = eventTable.Columns.Add("ID", typeof(int));

                    foreach (var ev in traces.Select((a, i) => new { Event = a, Index = ++i + __id }).Where((a) => a.Event.EventClass.Equals(eventClass)))
                    {
                        var row = eventTable.NewRow();
                        row[columnID] = ev.Index;

                        foreach (var map in mapping)
                        {
                            object value = null;

                            if (ev.Event[map.TraceColumn] != null)
                                value = map.Property.GetValue(ev.Event, index: null);
                            
                            if (map.Property.PropertyType == typeof(TraceEventClass) || map.Property.PropertyType == typeof(TraceEventSubclass))
                                value = Convert.ToString(value);
                            else if (map.Property.Name == "ObjectType" && map.Property.PropertyType == typeof(Type))
                            {
                                // HACK
                                if (value == null && ev.Event[TraceColumn.ObjectType] == ProfilerCollector.TraceEventObjectTypeAggregationUnmapped)
                                    value = typeof(Aggregation);

                                if (value != null)
                                    value = (value as Type).AssemblyQualifiedName;
                            }

                            row[map.DataColumn] = value ?? DBNull.Value;
                        }

                        eventTable.Rows.Add(row);
                    }

                    return eventTable;
                });

            id += traces.Count;
            return profilerTables;
        }

        public static DataTable ToDataTable(this TraceEvent traceEvent)
        {
            #region Argument exceptions

            if (traceEvent == null)
                throw new ArgumentNullException("traceEvent");

            #endregion

            var columns = traceEvent.Columns.Cast<TraceColumn>()
                .Where((c) => c != ProfilerCollector.TraceColumnFilter)
                .Select((c) => new { Name = c.ToName() });

            var properties = ProfilerResult.ItemsType
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Where((p) => !p.CanWrite);

            var query = properties.Join(columns, 
                o => o.Name, 
                i => i.Name,
                (o, i) => 
                    {
                        var columnType = o.PropertyType;

                        if (o.PropertyType == typeof(TraceEventClass) || o.PropertyType == typeof(TraceEventSubclass) || o.PropertyType == typeof(Type)) 
                            columnType = typeof(string);

                        return new
                        {
                            ColumnName = o.Name,
                            ColumnType = columnType
                        };
                    },
                StringComparer.OrdinalIgnoreCase
                );

            var table = new DataTable(traceEvent.EventID.ToName(), traceEvent.ToNamespace()); 
            foreach (var property in query)
                table.Columns.Add(property.ColumnName, property.ColumnType);

            return table;
        }

        public static TraceEventClass ToEventClass(this string name)
        {
#region Argument exception

            if (name == null)
                throw new ArgumentNullException("name");

#endregion

            return (TraceEventClass)Enum.Parse(typeof(TraceEventClass), name);
        }

        public static string ToName(this TraceEventClass @class)
        {
            return Enum.GetName(typeof(TraceEventClass), @class);
        }

        public static string ToName(this TraceColumn column)
        {
            return Enum.GetName(typeof(TraceColumn), column);
        }

        private static IEnumerable<TraceEventArgs> FilterProgressReportEndQueryAggregationEvents(this List<TraceEventArgs> profilerResultEvents)
        {
            // TraceEventClass.ProgressReportEnd
            var progressReportEndQueryEvents = profilerResultEvents.Where((e) => e.EventClass == TraceEventClass.ProgressReportEnd && e.EventSubclass == TraceEventSubclass.Query);

            // TraceEventClass.GetDataFromAggregation
            var getDataFromAggregationEvents = profilerResultEvents.Where((e) => e.EventClass == TraceEventClass.GetDataFromAggregation);
            var getDataFromAggregationEventsInfo = getDataFromAggregationEvents.Select((e) =>
            {
                Debug.Assert(e.TextData != null);

                var values = e.TextData.Split('\n');

                Debug.Assert(values.Length == 2);

                return new
                {
                    ObjectPath = e.ObjectPath,
                    AggregationObjectPath = "{0}.{1}".FormatWith(e.ObjectPath, values.First()),
                    AggregationID = values.First()
                };
            });

            return getDataFromAggregationEventsInfo.Join(progressReportEndQueryEvents,
                aggregationInfo => new { ObjectPath = aggregationInfo.AggregationObjectPath, ObjectID = aggregationInfo.AggregationID },
                progressReportEnd => new { ObjectPath = progressReportEnd.ObjectPath, ObjectID = progressReportEnd.ObjectID },
                (aggregationInfo, progressReportEnd) => progressReportEnd
                );
        }

        private static IEnumerable<TraceEventArgs> FilterProgressReportEndQueryPartitionEvents(this List<TraceEventArgs> profilerResultEvents)
        {
            return profilerResultEvents.Where((e) =>
                e.EventClass == TraceEventClass.ProgressReportEnd &&
                e.EventSubclass == TraceEventSubclass.Query &&
                e.ObjectType != null && 
                e.ObjectType.Name == "Partition"
                );
        }

        public static DataTable ToEnginePerformanceTable(this ProfilerResult profilerResult)
        {
            var enginePerformance = new DataTable("EnginePerformance",  "Common");

#region Columns
            enginePerformance.Columns.Add("QueryDuration", typeof(TimeSpan));
            enginePerformance.Columns.Add("FormulaEngineDuration", typeof(TimeSpan));
            enginePerformance.Columns.Add("StorageEngineDuration", typeof(TimeSpan));
            enginePerformance.Columns.Add("QuerySubcubeExecutionsCacheData", typeof(int));
            enginePerformance.Columns.Add("QuerySubcubeExecutionsNonCacheData", typeof(int));
            enginePerformance.Columns.Add("CachesRead", typeof(int));
            enginePerformance.Columns.Add("PartitionsRead", typeof(int));
            enginePerformance.Columns.Add("PartitionsHit", typeof(int));
            enginePerformance.Columns.Add("PartitionsDuration", typeof(TimeSpan));
            enginePerformance.Columns.Add("AggregationsRead", typeof(int));
            enginePerformance.Columns.Add("AggregationsHit", typeof(int));
            enginePerformance.Columns.Add("AggregationsDuration", typeof(TimeSpan));
            enginePerformance.Columns.Add("ResourceUsageReads", typeof(int));
            enginePerformance.Columns.Add("ResourceUsageReadKB", typeof(long));
            enginePerformance.Columns.Add("ResourceUsageWrites", typeof(int));
            enginePerformance.Columns.Add("ResourceUsageWriteKB", typeof(long));
            enginePerformance.Columns.Add("ResourceUsageCpuTimeMS", typeof(long));
            enginePerformance.Columns.Add("ResourceUsageRowsScanned", typeof(int));
            enginePerformance.Columns.Add("ResourceUsageRowsReturned", typeof(int));
#endregion

            if (profilerResult.ExecuteForPrepare)
                return enginePerformance;

#region Calculation

#region QueryEnd events
            var queryEndEvents = profilerResult.Values.Where((e) => e.EventClass == TraceEventClass.QueryEnd);
            if (queryEndEvents.Count() != 1)
                throw new ApplicationException("Invalid QueryEnd events count [{0}]".FormatWith(queryEndEvents.Count()));
#endregion

            var queryDuration = queryEndEvents.Single().Duration;

#region QuerySubCube events
            var querySubCubeEvents = profilerResult.Values.Where((e) => e.EventClass == TraceEventClass.QuerySubcube);
#endregion

            var storageEngineDuration = querySubCubeEvents.Sum((e) => e.Duration);
            if (storageEngineDuration > queryDuration)
                storageEngineDuration = queryDuration;
            var formulaEngineDuration = queryDuration - storageEngineDuration;

            var querySubcubeExecutionsCacheData = querySubCubeEvents.Count((e) => e.EventSubclass == TraceEventSubclass.CacheData);
            var querySubcubeExecutionsNonCacheData = querySubCubeEvents.Count((e) => e.EventSubclass == TraceEventSubclass.NonCacheData);
            
#region ProgressReportEnd events
            var progressReportEndQueryPartitionEvents = profilerResult.Values.FilterProgressReportEndQueryPartitionEvents();
            var progressReportEndQueryAggregationEvents = profilerResult.Values.FilterProgressReportEndQueryAggregationEvents();
#endregion

            var partitionsRead = progressReportEndQueryPartitionEvents.GroupBy((e) => e.ObjectID).Count();
            var partitionsDuration = progressReportEndQueryPartitionEvents.Sum((e) => e.Duration);
            var partitionsHit = progressReportEndQueryPartitionEvents.Count();

            var aggregationsRead = progressReportEndQueryAggregationEvents.GroupBy((e) => e.ObjectID).Count();
            var aggregationsDuration = progressReportEndQueryAggregationEvents.Sum((e) => e.Duration);
            var aggregationsHit = progressReportEndQueryAggregationEvents.Count();

#region GetDataFromCache events
            var getDataFromCacheEvents = profilerResult.Values.Where((e) => e.EventClass == TraceEventClass.GetDataFromCache);
#endregion

            var cachesRead = getDataFromCacheEvents.Count();

#region ResourceUsage events
            var resourceUsageEvents = profilerResult.Values.Where((e) => e.EventClass == TraceEventClass.ResourceUsage);
            if (resourceUsageEvents.Count() != 1)
                throw new ApplicationException("Invalid ResourceUsage events count");
#endregion

            var resourceUsage = resourceUsageEvents.Select((e) =>
            {
                if (e.TextData == null)
                    throw new ApplicationException("Invalid ResourceUsage.TextData [null]");

                var values = e.TextData.Split('\n')
                    .Select((v) => v.Split(',').Last().Trim())
                    .ToArray();

                if (values.Length != 8)
                    throw new ApplicationException("Invalid ResourceUsage.TextData [{0}]".FormatWith(values.Length));

                return new
                {
                    ResourceUsageReads = int.Parse(values[0]),
                    ResourceUsageReadKB = long.Parse(values[1]),
                    ResourceUsageWrites = int.Parse(values[2]),
                    ResourceUsageWriteKB = long.Parse(values[3]),
                    ResourceUsageCpuTimeMS = long.Parse(values[4]),
                    ResourceUsageRowsScanned = int.Parse(values[5]),
                    ResourceUsageRowsReturned = int.Parse(values[6]),
                };
            })
            .Single();

#endregion

#region Insert row
            enginePerformance.Rows.Add(
                TimeSpan.FromMilliseconds(queryDuration),
                TimeSpan.FromMilliseconds(formulaEngineDuration),
                TimeSpan.FromMilliseconds(storageEngineDuration),
                querySubcubeExecutionsCacheData,
                querySubcubeExecutionsNonCacheData,
                cachesRead,
                partitionsRead,
                partitionsHit,
                TimeSpan.FromMilliseconds(partitionsDuration),
                aggregationsRead,
                aggregationsHit,
                TimeSpan.FromMilliseconds(aggregationsDuration),
                resourceUsage.ResourceUsageReads,
                resourceUsage.ResourceUsageReadKB,
                resourceUsage.ResourceUsageWrites,
                resourceUsage.ResourceUsageWriteKB,
                resourceUsage.ResourceUsageCpuTimeMS,
                resourceUsage.ResourceUsageRowsScanned,
                resourceUsage.ResourceUsageRowsReturned
                );
#endregion

            return enginePerformance;
        }

        public static DataTable ToPartitionsReadTable(this ProfilerResult profilerResult)
        {
            var partitionsRead = new DataTable("PartitionsRead", "Common");

#region Columns
            partitionsRead.Columns.Add("CubeID", typeof(string));
            partitionsRead.Columns.Add("MeasureGroupID", typeof(string));
            partitionsRead.Columns.Add("PartitionID", typeof(string));
            partitionsRead.Columns.Add("PartitionName", typeof(string));
            partitionsRead.Columns.Add("PartitionHit", typeof(int));
            partitionsRead.Columns.Add("PartitionDuration", typeof(TimeSpan));
            partitionsRead.Columns.Add("PartitionDurationRatio", typeof(double));
#endregion

            if (profilerResult.ExecuteForPrepare)
                return partitionsRead;

#region Calculation

            var progressReportEndQueryPartitionEvents = profilerResult.Values.FilterProgressReportEndQueryPartitionEvents().ToList();
            var durationTotal = progressReportEndQueryPartitionEvents.Sum((e) => e.Duration);

            var progressReportEndQueryPartition = progressReportEndQueryPartitionEvents.GroupBy((e) => e.ObjectID)
                .Select((g) => 
                {
                    var fe = g.First();
                    var xdoc = XDocument.Parse(fe.ObjectReference);
                    
                    return new 
                    {
                        CubeID = xdoc.Root.Element("CubeID").Value,
                        MeasureGroupID = xdoc.Root.Element("MeasureGroupID").Value,
                        PartitionID = xdoc.Root.Element("PartitionID").Value,
                        PartitionName = fe.ObjectName,
                        PartitionHit = g.Count(),
                        PartitionDuration = g.Sum((e) => e.Duration),
                        PartitionDurationRatio = durationTotal == 0L ? 0D : ((double)(g.Sum((e) => e.Duration) * 100D) / (double)durationTotal)
                    };
                });

#endregion

#region Insert rows

            foreach (var item in progressReportEndQueryPartition)
	        {
                partitionsRead.Rows.Add(
                    item.CubeID,
                    item.MeasureGroupID,
                    item.PartitionID,
                    item.PartitionName,
                    item.PartitionHit,
                    TimeSpan.FromMilliseconds(item.PartitionDuration),
                    Math.Round(item.PartitionDurationRatio, 2)
                    );
	        }

#endregion

            return partitionsRead;
        }

        public static DataTable ToAggregationsReadTable(this ProfilerResult profilerResult)
        {
            var aggregationsRead = new DataTable("AggregationsRead", "Common");

#region Columns
            aggregationsRead.Columns.Add("CubeID", typeof(string));
            aggregationsRead.Columns.Add("MeasureGroupID", typeof(string));
            aggregationsRead.Columns.Add("PartitionID", typeof(string));
            aggregationsRead.Columns.Add("AggregationID", typeof(string));
            aggregationsRead.Columns.Add("AggregationName", typeof(string));
            aggregationsRead.Columns.Add("AggregationHit", typeof(int));
            aggregationsRead.Columns.Add("AggregationDuration", typeof(TimeSpan));
            aggregationsRead.Columns.Add("AggregationDurationRatio", typeof(double));
#endregion

            if (profilerResult.ExecuteForPrepare)
                return aggregationsRead;

#region Calculation

            var progressReportEndQueryAggregationEvents = profilerResult.Values.FilterProgressReportEndQueryAggregationEvents().ToList();
            var durationTotal = progressReportEndQueryAggregationEvents.Sum((e) => e.Duration);
            
            var progressReportEndQueryAggregation = progressReportEndQueryAggregationEvents.GroupBy((e) => e.ObjectID)
                .Select((g) =>
                {
                    var fe = g.First();
                    var values = fe.ObjectPath.Split('.');

                    return new
                    {
                        CubeID = values[2],
                        MeasureGroupID = values[3],
                        PartitionID = values[4],
                        AggregationID = values[5],
                        AggregationName = fe.ObjectName,
                        AggregationHit = g.Count(),
                        AggregationDuration = g.Sum((e) => e.Duration),
                        AggregationDurationRatio = durationTotal == 0L ? 0D : ((double)(g.Sum((e) => e.Duration) * 100D) / (double)durationTotal)
                    };
                });

#endregion

#region Insert rows

            foreach (var item in progressReportEndQueryAggregation)
            {
                aggregationsRead.Rows.Add(
                    item.CubeID,
                    item.MeasureGroupID,
                    item.PartitionID,
                    item.AggregationID,
                    item.AggregationName,
                    item.AggregationHit,
                    TimeSpan.FromMilliseconds(item.AggregationDuration),
                    Math.Round(item.AggregationDurationRatio, 2)
                    );
            }

#endregion

            return aggregationsRead;
        }

        public static DataTable ToCachesReadTable(this ProfilerResult profilerResult)
        {
            var cachesRead = new DataTable("CachesRead", "Common");
            
#region Columns
            cachesRead.Columns.Add("CacheType", typeof(string));
            cachesRead.Columns.Add("CacheSubType", typeof(string));
#endregion

            if (profilerResult.ExecuteForPrepare)
                return cachesRead;

#region Calculation

            var getDataFromCache = profilerResult.Values
                .Where((e) => e.EventClass == TraceEventClass.GetDataFromCache);

            var measureGroupCache = getDataFromCache
                .Where((e) => e.EventSubclass == TraceEventSubclass.GetDataFromMeasureGroupCache)
                .Select((e) => new
                {
                    CacheType = "Measure Group Cache",
                    CacheSubType = e.TextData
                });

            var persistedCache = getDataFromCache
                .Where((e) => e.EventSubclass == TraceEventSubclass.GetDataFromPersistedCache)
                .Select((e) => new
                {
                    CacheType = "Persisted Cache",
                    CacheSubType = e.TextData
                });

            var flatCache = getDataFromCache
                .Where((e) => e.EventSubclass == TraceEventSubclass.GetDataFromFlatCache)
                .Select((e) => new
                {
                    CacheType = "Flat Cache",
                    CacheSubType = e.TextData
                });

            var calculationCacheGlobalScope = getDataFromCache
                .Where((e) => 
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache && 
                        e.TextData.Equals("Global Scope", StringComparison.InvariantCultureIgnoreCase))
                .Select((e) => new
                {
                    CacheType = "Calculation Cache - Global Scope",
                    CacheSubType = e.TextData
                });

            var calculationCacheSessionScope = getDataFromCache
                .Where((e) =>
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache &&
                        e.TextData.Equals("Session Scope", StringComparison.InvariantCultureIgnoreCase))
                .Select((e) => new
                {
                    CacheType = "Calculation Cache - Session Scope",
                    CacheSubType = e.TextData
                });

            var calculationCacheQueryScope = getDataFromCache
                .Where((e) =>
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache &&
                        e.TextData.Equals("Query Scope", StringComparison.InvariantCultureIgnoreCase))
                .Select((e) => new
                {
                    CacheType = "Calculation Cache - Query Scope",
                    CacheSubType = e.TextData
                });

#endregion

#region Insert rows

            var caches = measureGroupCache
                .Concat(persistedCache)
                .Concat(flatCache)
                .Concat(calculationCacheGlobalScope)
                .Concat(calculationCacheSessionScope)
                .Concat(calculationCacheQueryScope);

            foreach (var item in caches)
                cachesRead.Rows.Add(item.CacheType, item.CacheSubType);

#endregion

            return cachesRead;
        }

        public static DataTable ToQueryResultTable(this DataTable queryResult)
        {
            queryResult.TableName = "QueryResult";
            queryResult.Namespace = "Common";

            return queryResult;
        }

        public static DataTable ToProcedureEventTable(this IDictionary<ProcedureEvents, DateTime> events)
        {
            var table = new DataTable("ProcedureEvent", "Common");

#region Columns
            table.Columns.Add("Event", typeof(string));
            table.Columns.Add("Time", typeof(DateTime));
#endregion

            foreach (var @event in events)
                table.Rows.Add(@event.Key, @event.Value);

            return table;
        }
    }
}
