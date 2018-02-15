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

namespace SSASQueryAnalyzer.Server.Performance
{
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    internal static class PerformanceCollector
    {
        private static string DecodeOlapCategory(string serverName, Version serverVersion)
        {
            #region Argument exception

            if (serverName == null)
                throw new ArgumentNullException("serverName");
            if (serverVersion == null)
                throw new ArgumentNullException("serverVersion");

            #endregion

            var serverNameParts = serverName.Split('\\');

            switch (serverNameParts.Length)
            {
                case 1: // default instance
                    if (serverVersion.Major == 9)
                        return "MSAS {0}:".FormatWith("2005");

                    if (serverVersion.Major == 10)
                        return "MSAS {0}:".FormatWith("2008");

                    return "MSAS{0}:".FormatWith(serverVersion.Major);

                case 2: // named instance
                    return "MSOLAP${0}:".FormatWith(serverNameParts.Last());

                default:
                    throw new ApplicationException("Invalid server name [{0}]".FormatWith(serverName));
            }
        }

        public static IList<PerformanceCounter> ActivePerformanceCounters(ProcedureContext procedureContext)
        {
            #region Argument exception

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            var activePerformanceCounters = DefaultPerformanceCounters(procedureContext.SSASInstanceName, procedureContext.SSASInstanceVersion);

            Action action = () =>
            {
                var configurationFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProcedureContext.ConfigurationFileRelativePath);

                if (File.Exists(configurationFile))
                {
                    var configuredPerformanceCounters = XDocument.Load(configurationFile).Root
                        .Elements(ProcedureConfiguration.XConfigPerformanceCollection)
                        .Descendants(ProcedureConfiguration.XConfigPerformanceItem)
                        .Select((e) => new
                        {
                            CategoryName = e.Attribute(ProcedureConfiguration.XConfigPerformanceAttributeCategory).Value,
                            CounterName = e.Attribute(ProcedureConfiguration.XConfigPerformanceAttributeName).Value,

                        });

                    foreach (var counter in configuredPerformanceCounters)
                        if (!activePerformanceCounters.Any((c) => c.CategoryName == counter.CategoryName && c.CounterName == counter.CounterName))
                            activePerformanceCounters.Add(new PerformanceCounter(counter.CategoryName, counter.CounterName));
                }
            };

            using (var task = Task.Factory.StartNew(action))
                task.Wait();

            foreach (var counter in activePerformanceCounters)
                counter.NextValue();

            return activePerformanceCounters;
        }

        private static IList<PerformanceCounter> DefaultPerformanceCounters(string serverName, Version serverVersion)
        {
            // TOFIX: dispose PerformanceCounters and invoke PerformanceCounter.CloseSharedResources();

            var counters = new List<PerformanceCounter>();

            var olapCategory = DecodeOlapCategory(serverName, serverVersion);

            var olapMdxCategory = olapCategory + "MDX";
            counters.Add(new PerformanceCounter(olapMdxCategory, "Total cells calculated"));
            counters.Add(new PerformanceCounter(olapMdxCategory, "Total sonar subcubes"));
            counters.Add(new PerformanceCounter(olapMdxCategory, "Total autoexist"));
            counters.Add(new PerformanceCounter(olapMdxCategory, "Total NON EMPTY"));
            counters.Add(new PerformanceCounter(olapMdxCategory, "Total EXISTING"));
            counters.Add(new PerformanceCounter(olapMdxCategory, "Total flat cache inserts"));
            counters.Add(new PerformanceCounter(olapMdxCategory, "Number of calculation covers"));
            counters.Add(new PerformanceCounter(olapMdxCategory, "Number of bulk-mode evaluation nodes"));
            counters.Add(new PerformanceCounter(olapMdxCategory, "Number of cell-by-cell evaluation nodes"));

            var olapStorageEngineQueryCategory = olapCategory + "Storage Engine Query";
            counters.Add(new PerformanceCounter(olapStorageEngineQueryCategory, "Total measure group queries"));

            var olapMemoryCategory = olapCategory + "Memory";
            counters.Add(new PerformanceCounter(olapMemoryCategory, "Memory usage KB"));

            var olapCacheCategory = olapCategory + "Cache";
            counters.Add(new PerformanceCounter(olapCacheCategory, "Total direct hits"));
            counters.Add(new PerformanceCounter(olapCacheCategory, "Total inserts"));
            counters.Add(new PerformanceCounter(olapCacheCategory, "Total lookups"));
            counters.Add(new PerformanceCounter(olapCacheCategory, "Total misses"));         

            return counters;
        }

        public static Task<PerformanceResult> StartAsync(ProcedureContext procedureContext, CollectorsSynchronizer collectorsSynchronizer)
        {
            #region Argument exceptions

            if (collectorsSynchronizer == null)
                throw new ArgumentNullException("collectorsSynchronizer");
            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            var started = new ManualResetEvent(false);
            var faulted = new ManualResetEvent(false);

            var performanceTask = new Task<PerformanceResult>(() =>
            {
                var performanceResult = PerformanceResult.Create(procedureContext);

                started.Set();

                while (!collectorsSynchronizer.IsCompleted)
                {
                    try
                    {
                        DateTime eventTime;
                        if (collectorsSynchronizer.TryTake(out eventTime, Timeout.Infinite, procedureContext.CancellationToken))
                            performanceResult.Collect(eventTime);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }

                if (procedureContext.ExecutionMode == ProcedureExecutionMode.Batch)
                    performanceResult.FlushBatch(ThreadingTimeout.Infinite).Wait();

                return performanceResult;
            },
            procedureContext.CancellationToken, TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);

            performanceTask.ContinueWith((previousTask) => faulted.Set(), TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);
            performanceTask.Start();

            WaitHandle.WaitAny(new[] { started, faulted });

            return performanceTask;
        }

        public static DataTable GetConfiguration()
        {
            var table = new DataTable(ConfigurationType.PerformanceCounters.ToString(), "Configuration");
            table.Columns.Add("CategoryName", typeof(string));
            table.Columns.Add("CounterName", typeof(string));
            table.Columns.Add("CounterType", typeof(string));
            table.Columns.Add("IsActive", typeof(string));
            table.Columns.Add("IsDefault", typeof(string));
             
            Version version;
            using (var server = new Microsoft.AnalysisServices.Server())
            {
                server.Connect("*");
                version = Version.Parse(server.Version);
            }

            string olapCategory = DecodeOlapCategory(Microsoft.AnalysisServices.AdomdServer.Context.CurrentServerID, version);

            try
            {
                var systemPerformanceCounters = PerformanceCounterCategory.GetCategories()
                    .Where((c) => c.CategoryName.StartsWith(olapCategory))
                    .Select((c) => c.GetCounters())
                    .SelectMany((c) => c);

                try
                {
                    var configuredPerformanceCounters = new[] 
                    {
                        new
                        {
                            CategoryName = default(string),
                            CounterName = default(string),
                        }
                    }
                    .Take(0);

                    Action action = () =>
                    {
                        var configurationFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProcedureContext.ConfigurationFileRelativePath);

                        if (File.Exists(configurationFile))
                        {
                            configuredPerformanceCounters = XDocument.Load(configurationFile).Root
                                .Elements(ProcedureConfiguration.XConfigPerformanceCollection)
                                .Descendants(ProcedureConfiguration.XConfigPerformanceItem)
                                .Select((e) => new
                                {
                                    CategoryName = e.Attribute(ProcedureConfiguration.XConfigPerformanceAttributeCategory).Value,
                                    CounterName = e.Attribute(ProcedureConfiguration.XConfigPerformanceAttributeName).Value,

                                })
                                .ToArray();
                        }
                    };

                    using (var task = Task.Factory.StartNew(action))
                        task.Wait();                    

                    var defaultPerformanceCounters = DefaultPerformanceCounters(Microsoft.AnalysisServices.AdomdServer.Context.CurrentServerID, version)
                        .ToList();
                    try
                    {
                        foreach (var counter in systemPerformanceCounters)
                        {
                            bool isDefault = defaultPerformanceCounters.Any((c) => c.CategoryName.ToLower() == counter.CategoryName.ToLower() && c.CounterName.ToLower() == counter.CounterName.ToLower());
                            bool isActive = configuredPerformanceCounters.Any((c) => c.CategoryName.ToLower() == counter.CategoryName.ToLower() && c.CounterName.ToLower() == counter.CounterName.ToLower());

                            table.Rows.Add(
                                counter.CategoryName,
                                counter.CounterName,
                                counter.CounterType,
                                isDefault || isActive,
                                isDefault
                                );
                        }
                    }
                    finally
                    {
                        foreach (var counter in defaultPerformanceCounters)
                            counter.Dispose();
                    }
                }
                finally
                {
                    foreach (var counter in systemPerformanceCounters)
                        counter.Dispose();
                }
            }
            finally
            {
                PerformanceCounter.CloseSharedResources();
            }

            return table;
        }
    }
}
