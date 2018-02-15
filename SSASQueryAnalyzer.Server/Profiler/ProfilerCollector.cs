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
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://technet.microsoft.com/en-us/library/ms345148(v=sql.90).aspx"/>
    internal static class ProfilerCollector
    {
        private const string TraceId = "SSASQueryAnalyzerTrace";
        private const string TraceName = "SSASQueryAnalyzerTrace";
        public const string TraceEventObjectTypeAggregationUnmapped = "100031";

#if ASQASSAS11 || ASQASSAS12
        public static TraceColumn TraceColumnFilter = TraceColumn.ConnectionID;
#else
        public static TraceColumn TraceColumnFilter = TraceColumn.ActivityID;
#endif

        private static readonly TraceColumn[] MandatoryTraceEventColumn = 
        {
            TraceColumn.EventClass, 
            TraceColumn.CurrentTime,
            TraceColumnFilter
        };

        private static readonly TraceColumn[] ExcludedTraceEventColumn = 
        {
            TraceColumn.ClientHostName,
            TraceColumn.ClientProcessID,
            TraceColumn.NTUserName,
            TraceColumn.NTDomainName,
            TraceColumn.NTCanonicalUserName,
            TraceColumn.Spid,
            TraceColumn.ServerName,
            TraceColumn.SessionType,
            TraceColumn.SessionID,
            TraceColumn.RequestProperties,
            TraceColumn.RequestParameters,
            TraceColumn.ApplicationName,
            TraceColumn.DatabaseName,
            TraceColumn.Severity,
            TraceColumn.Success,
            TraceColumn.Error,
            TraceColumn.JobID 
        };

        //private const string TraceFilterTemplate =
        //    "<Like xmlns=\"http://schemas.microsoft.com/analysisservices/2003/engine\">" +
        //        "<ColumnID>{0}</ColumnID>" +
        //        "<Value>{1}</Value>" +
        //    "</Like>";

        //private static XmlNode CreateTraceFilter()
        //{
        //    var doc = new XmlDocument();

        //    var xml = TraceFilterTemplate.FormatWith(
        //        (int)TraceColumn.ApplicationName,
        //        AnalyzerTasks.ApplicationName
        //    );

        //    doc.LoadXml(xml);

        //    return doc.FirstChild;
        //}

        #region Trace Events

        /// <summary>
        /// Collects all query begin events since the trace started.
        /// </summary>
        private static TraceEvent CreateEventQueryBegin()
        {
            var ev = new TraceEvent(TraceEventClass.QueryBegin);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.EventSubclass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        /// <summary>
        /// Collects all query end events since the trace started.
        /// </summary>
        private static TraceEvent CreateEventQueryEnd()
        {
            var ev = new TraceEvent(TraceEventClass.QueryEnd);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.EventSubclass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.Duration);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        /// <summary>
        /// Query subcube, for Usage Based Optimization.
        /// </summary>
        private static TraceEvent CreateEventQuerySubcube()
        {
            var ev = new TraceEvent(TraceEventClass.QuerySubcube);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.EventSubclass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.Duration);
                ev.Columns.Add(TraceColumn.CpuTime);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        /// <summary>
        /// Collects all progress report end events since the trace was started.
        /// </summary>
        private static TraceEvent CreateEventProgressReportBegin()
        {
            var ev = new TraceEvent(TraceEventClass.ProgressReportBegin);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.EventSubclass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.ObjectID);
                ev.Columns.Add(TraceColumn.ObjectType);
                ev.Columns.Add(TraceColumn.ObjectName);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumn.ObjectReference);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        /// <summary>
        /// Collects all progress report end events since the trace was started.
        /// </summary>
        private static TraceEvent CreateEventProgressReportEnd()
        {
            var ev = new TraceEvent(TraceEventClass.ProgressReportEnd);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.EventSubclass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.Duration);
                ev.Columns.Add(TraceColumn.ObjectID);
                ev.Columns.Add(TraceColumn.ObjectType);
                ev.Columns.Add(TraceColumn.ObjectName);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumn.ObjectReference);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        /// <summary>
        /// Answer query by getting data from one of the caches. 
        /// This event may have a negative impact on performance when turned on.
        /// </summary>
        private static TraceEvent CreateEventGetDataFromCache()
        {
            var ev = new TraceEvent(TraceEventClass.GetDataFromCache);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.EventSubclass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumnFilter);
                ev.Columns.Add(TraceColumn.TextData);

                #endregion
            }

            return ev;
        }

        /// <summary>
        /// Answer query by getting data from aggregation.
        /// This event may have a negative impact on performance when turned on.
        /// </summary>
        private static TraceEvent CreateEventGetDataFromAggregation()
        {
            var ev = new TraceEvent(TraceEventClass.GetDataFromAggregation);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumnFilter);
                ev.Columns.Add(TraceColumn.TextData);

                #endregion
            }

            return ev;
        }

        /// <summary>
        /// Reports reads, writes, cpu usage after end of commands and queries.
        /// </summary>
        private static TraceEvent CreateEventResourceUsage()
        {
            var ev = new TraceEvent(TraceEventClass.ResourceUsage);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumnFilter);
                ev.Columns.Add(TraceColumn.TextData);

                #endregion
            }

            return ev;
        }

        private static TraceEvent CreateEventCalculateNonEmptyBegin()
        {
            var ev = new TraceEvent(TraceEventClass.CalculateNonEmptyBegin);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.IntegerData);
                ev.Columns.Add(TraceColumn.ObjectType);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        private static TraceEvent CreateEventCalculateNonEmptyCurrent()
        {
            var ev = new TraceEvent(TraceEventClass.CalculateNonEmptyCurrent);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.EventSubclass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.ProgressTotal);
                ev.Columns.Add(TraceColumn.IntegerData);
                ev.Columns.Add(TraceColumn.ObjectType);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        private static TraceEvent CreateEventCalculateNonEmptyEnd()
        {
            var ev = new TraceEvent(TraceEventClass.CalculateNonEmptyEnd);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.IntegerData);
                ev.Columns.Add(TraceColumn.ObjectType);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        private static TraceEvent CreateEventSerializeResultsBegin()
        {
            var ev = new TraceEvent(TraceEventClass.SerializeResultsBegin);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        private static TraceEvent CreateEventSerializeResultsCurrent()
        {
            var ev = new TraceEvent(TraceEventClass.SerializeResultsCurrent);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.EventSubclass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.ProgressTotal);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumnFilter);
                ev.Columns.Add(TraceColumn.TextData);

                #endregion
            }

            return ev;
        }

        private static TraceEvent CreateEventSerializeResultsEnd()
        {
            var ev = new TraceEvent(TraceEventClass.SerializeResultsEnd);
            {
                #region columns definition

                ev.Columns.Add(TraceColumn.EventClass);
                ev.Columns.Add(TraceColumn.CurrentTime);
                ev.Columns.Add(TraceColumn.Duration);
                ev.Columns.Add(TraceColumn.ObjectPath);
                ev.Columns.Add(TraceColumnFilter);

                #endregion
            }

            return ev;
        }

        #endregion

        private static void ValidateTraceEvents(IList<TraceEvent> events)
        {
            if (events == null)
                throw new ApplicationException("validate$null__events");

            if (events.Count == 0)
                throw new ApplicationException("validate$empty__events");

            if (events.SingleOrDefault((e) => e.EventID == TraceEventClass.ResourceUsage) == null)
                throw new ApplicationException("validate$missing__[{0}]".FormatWith(TraceEventClass.ResourceUsage));

            foreach (var mandatoryColumn in MandatoryTraceEventColumn)
                if (!events.All((e) => e.Columns.Contains(mandatoryColumn)))
                    throw new ApplicationException("validate$missing__[{0}]".FormatWith(mandatoryColumn));

            foreach (var excludedColumn in ExcludedTraceEventColumn)
                if (events.Any((e) => e.Columns.Contains(excludedColumn)))
                    throw new ApplicationException("validate$excluded__[{0}]".FormatWith(excludedColumn));
        }
        
        private static IList<TraceEvent> DefaultTraceEvents()
        {
            var events = new List<TraceEvent>()
            {
                CreateEventQueryBegin(),
                CreateEventQueryEnd(),
                CreateEventQuerySubcube(),
                CreateEventProgressReportBegin(),
                CreateEventProgressReportEnd(),
                CreateEventGetDataFromCache(),
                CreateEventGetDataFromAggregation(),
                CreateEventResourceUsage(),
                //CreateEventSerializeResultsBegin(),
                //CreateEventSerializeResultsCurrent(),
                //CreateEventSerializeResultsEnd(),
                //CreateEventCalculateNonEmptyBegin(),
                //CreateEventCalculateNonEmptyCurrent(),
                CreateEventCalculateNonEmptyEnd()
            };

            ValidateTraceEvents(events);

            return events;
        }

        public static IList<TraceEvent> CurrentTraceEvents()
        {
            var events = new List<TraceEvent>();

            using (var server = new Server())
            {
                server.Connect("*");

                var trace = server.Traces.Find(ProfilerCollector.TraceId);
                if (trace == null)
                    throw new ApplicationException("Trace not found [{0}].".FormatWith(ProfilerCollector.TraceId));

                events.AddRange(trace.Events.Cast<TraceEvent>());
            }

            ValidateTraceEvents(events);

            return events;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Assicurarsi che per ogni evento vengano tracciate solamente le informazioni minime necessarie.
        ///</remarks>
        ///<see cref="http://msdn.microsoft.com/en-us/library/ms174867.aspx"/>
        public static void Install()
        {
            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureInstallStepInstallTrace);

            using (var server = new Server())
            {
                server.Connect("*");

                var trace = server.Traces.Find(ProfilerCollector.TraceId);
                if (trace != null)
                    trace.Drop();

                trace = server.Traces.Add(ProfilerCollector.TraceName, ProfilerCollector.TraceId);
                foreach (var ev in DefaultTraceEvents())
                    trace.Events.Add(ev);
                //trace.Filter = CreateTraceFilter();
                //trace.StopTime = DateTime.UtcNow.AddDays(1);
                trace.AutoRestart = true;
                trace.Audit = false;
                trace.Update();
            }
        }

        public static void Uninstall()
        {
            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureUninstallStepUninstallTrace);

            using (var server = new Server())
            {
                server.Connect("*");

                var trace = server.Traces.Find(ProfilerCollector.TraceId);
                if (trace == null)
                    return;

                trace.Drop();
            }
        }

        public static string Reconfigure(string xconfig)
        {
            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureReconfigureStepReconfigureTrace);

            var traceDefinitionColumns = XDocument.Parse(text: GetTraceDefinitionText()).Root
                .Elements("EVENTCATEGORYLIST")
                .Descendants("EVENTCATEGORY")
                .Descendants("EVENT")
                .Select((e) => new
                {
                    ID = int.Parse(e.Element("ID").Value),
                    Name = e.Element("NAME").Value,
                    Category = e.Parent.Parent.Element("NAME").Value,
                    Columns = e.Elements("EVENTCOLUMNLIST")
                        .Descendants("EVENTCOLUMN")
                        .Select((c) => (TraceColumn)Enum.ToObject(typeof(TraceColumn), int.Parse(c.Element("ID").Value)))
                        .Where((c) => !ExcludedTraceEventColumn.Contains(c))
                })
                .ToList();

            var xdoc = XDocument.Parse(xconfig);
            var defaultTraceEvents = DefaultTraceEvents();
            var configuredTraceEvents = xdoc.Root
                .Elements(ProcedureConfiguration.XConfigTraceCollection)
                .Descendants(ProcedureConfiguration.XConfigTraceItem)
                .Select((e) => new
                {
                    Element = e,
                    ID = int.Parse(e.Attribute(ProcedureConfiguration.XConfigTraceAttributeId).Value),
                    EventID = (TraceEventClass)Enum.ToObject(typeof(TraceEventClass), int.Parse(e.Attribute(ProcedureConfiguration.XConfigTraceAttributeId).Value)),
                    ColumnsID = traceDefinitionColumns
                        .Where((d) => d.ID == int.Parse(e.Attribute(ProcedureConfiguration.XConfigTraceAttributeId).Value))
                        .SelectMany((d) => d.Columns)
                });

            using (var server = new Server())
            {
                server.Connect("*");

                var trace = server.Traces.Find(ProfilerCollector.TraceId);
                if (trace == null)
                    throw new ApplicationException("Trace not found [{0}].".FormatWith(ProfilerCollector.TraceId));

                trace.Events.Clear();

                foreach (var @event in defaultTraceEvents)
                    trace.Events.Add(@event);

                foreach (var configuredEvent in configuredTraceEvents)
                {
                    var definitionItem = traceDefinitionColumns.Single((t) => t.ID == configuredEvent.ID);
                    configuredEvent.Element.Add(new XAttribute("Name", definitionItem.Name));
                    configuredEvent.Element.Add(new XAttribute("Category", definitionItem.Category));

                    if (defaultTraceEvents.Any((v) => v.EventID == configuredEvent.EventID))
                        continue;

                    foreach (var mandatoryColumn in MandatoryTraceEventColumn)
                        if (!configuredEvent.ColumnsID.Contains(mandatoryColumn))
                            throw new ApplicationException("reconfigure$missing__[{0}]".FormatWith(mandatoryColumn));

                    foreach (var excludedColumn in ExcludedTraceEventColumn)
                        if (configuredEvent.ColumnsID.Contains(excludedColumn))
                            throw new ApplicationException("reconfigure$excluded__[{0}]".FormatWith(excludedColumn));

                    var traceEvent = new TraceEvent(configuredEvent.EventID);
                    foreach (var column in configuredEvent.ColumnsID)
                        traceEvent.Columns.Add(column);

                    trace.Events.Add(traceEvent);
                }

                trace.Update();
            }

            return xdoc.ToString(SaveOptions.None);
        }

        public static string GetTraceDefinitionText()
        {
            var info = ProcedureContext.GetServerInfo();
            var version = info.Item1;
            
            Func<string> read = () =>
            {
                string path;
                using (var process = Process.GetCurrentProcess())
                    path = Path.GetDirectoryName(process.MainModule.FileName);

                path = Path.Combine(path, "Resources", "1033", "tracedefinition{0}{1}.xml".FormatWith(version.Major, version.Minor));

                return File.ReadAllText(path);
            };

            using (var task = Task.Factory.StartNew(read))
                return task.Result;
        }

        public static DataTable GetConfiguration()
        {
            var table = new DataTable(ConfigurationType.TraceEvents.ToString(), "Configuration");

            table.Columns.Add("CategoryName", typeof(string));
            table.Columns.Add("CategoryDescription", typeof(string));
            table.Columns.Add("EventID", typeof(int));
            table.Columns.Add("EventName", typeof(string));
            table.Columns.Add("EventDescription", typeof(string));
            table.Columns.Add("IsActive", typeof(string));
            table.Columns.Add("IsDefault", typeof(string));
            
            var categories = XDocument.Parse(text: GetTraceDefinitionText()).Root
                .Elements("EVENTCATEGORYLIST")
                .Descendants("EVENTCATEGORY")
                .Select((c) => new
                {
                    Name = c.Element("NAME").Value,
                    Description = c.Element("DESCRIPTION").Value,
                    Events = c.Elements("EVENTLIST")
                        .Descendants("EVENT")
                        .Select((e) => new
                        {
                            ID = int.Parse(e.Element("ID").Value),
                            Name = e.Element("NAME").Value,
                            Description = e.Element("DESCRIPTION").Value,
                            Columns = e.Elements("EVENTCOLUMNLIST")
                                .Descendants("EVENTCOLUMN")
                                .Select((l) => (TraceColumn)Enum.ToObject(typeof(TraceColumn), int.Parse(l.Element("ID").Value)))
                        })
                });           

            var defaultTraceEvents = DefaultTraceEvents()
                .Select((e) => (int)e.EventID)
                .ToList();

            var currentTraceEvents = CurrentTraceEvents()
                .Select((e) => (int)e.EventID)
                .ToList();

            foreach (var category in categories)
            {
                foreach (var @event in category.Events)
                {
                    bool skip = false;
                    foreach (var mandatoryColumn in MandatoryTraceEventColumn)
                        if (skip = !@event.Columns.Contains(mandatoryColumn))
                            break;

                    if (!skip)
                        table.Rows.Add(
                            category.Name,
                            category.Description,
                            @event.ID,
                            @event.Name,
                            @event.Description,
                            currentTraceEvents.Contains(@event.ID),
                            defaultTraceEvents.Contains(@event.ID)
                            );
                }
            }

            return table;
        }

        public static Task<ProfilerResult> StartAsync(ProcedureContext procedureContext, CollectorsSynchronizer collectorsSynchronizer, CancellationToken cancellationToken)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");
            if (collectorsSynchronizer == null)
                throw new ArgumentNullException("collectorsSynchronizer");
            if (cancellationToken == null)
                throw new ArgumentNullException("cancellationToken");

            #endregion
            
            var started = new ManualResetEvent(false);
            var faulted = new ManualResetEvent(false);

            var traceTask = new Task<ProfilerResult>(() =>
            {
                #region task

                var profilerResult = ProfilerResult.Create(procedureContext, collectorsSynchronizer);

                using(var server = new Server())
                {
                    server.Connect(procedureContext.ConnectionString);

                    var trace = server.Traces.Find(ProfilerCollector.TraceId);
                    if (trace == null)
                        throw new ApplicationException("Trace not found [{0}]".FormatWith(ProfilerCollector.TraceName));

                    var onTraceEventException = default(Exception);
#if ASQASSAS13 || ASQASSAS14
                    var clientActivityID = procedureContext.ClientActivityID.ToString("D");
#endif
                    trace.OnEvent += (s, e) =>
                    {
                        #region OnEvent

                        try
                        {
#if ASQASSAS11 || ASQASSAS12
                            var found = e.ConnectionID == procedureContext.CurrentConnectionID;
#else
                            var found = clientActivityID.Equals(e[TraceColumn.ActivityID], StringComparison.OrdinalIgnoreCase);
#endif
                            if (found)
                                profilerResult.Add(e);
                        }
                        catch(Exception ex)
                        {
                            if (onTraceEventException == null)
                                onTraceEventException = ex;

                            profilerResult.CollectCompleted.Set();
                        }

                        #endregion
                    };

                    trace.Start();

                    while (!trace.IsStarted)
                        Thread.Sleep(50);
                    started.Set();

                    cancellationToken.WaitHandle.WaitOne(Timeout.Infinite);

                    WaitHandle.WaitAny(new []
                    {
                        profilerResult.CollectCompleted,
                        procedureContext.CancellationToken.WaitHandle
                    });

                    if (onTraceEventException != null)
                        throw onTraceEventException;

                    if (procedureContext.ExecutionMode == ProcedureExecutionMode.Batch && !procedureContext.IsCancellationRequested)
                        profilerResult.FlushBatch(completion: true);

                    trace.Stop();
                }
                
                return profilerResult;

#endregion
            },
            cancellationToken, TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);

            traceTask.ContinueWith((previousTask) => faulted.Set(), TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);
            traceTask.ContinueWith((previousTask) => collectorsSynchronizer.CompleteAdding(), TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.ExecuteSynchronously);

            traceTask.Start();

            WaitHandle.WaitAny(new []
            {
                started,
                faulted
            });

            return traceTask;
        }
    }
}