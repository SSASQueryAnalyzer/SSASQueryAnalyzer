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

namespace SSASQueryAnalyzer.Server
{
    using SSASQueryAnalyzer.Server.Infrastructure;
    using SSASQueryAnalyzer.Server.Performance;
    using SSASQueryAnalyzer.Server.Profiler;
    using System;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    using AdomdClient = Microsoft.AnalysisServices.AdomdClient;

    internal class AnalyzerTask
    {
        private static AnalyzerTaskResult InternalAnalyzeAsync(ProcedureContext procedureContext, AdomdClient.AdomdConnection connection)
        {
            var queryResult = default(DataTable);
            var profilerResult = default(ProfilerResult);
            var performanceResult = default(PerformanceResult);

            using (var collectorsSynchronizer = CollectorsSynchronizer.Create(procedureContext.CancellationToken))
            using (var performanceTask = PerformanceCollector.StartAsync(procedureContext, collectorsSynchronizer))
            {
                try
                {
                    if (!performanceTask.IsFaulted && !procedureContext.IsCancellationRequested)
                    {
                        #region profiler collector

                        using (var profilerCancellation = CancellationTokenSource.CreateLinkedTokenSource(procedureContext.CancellationToken))
                        using (var profilerTask = ProfilerCollector.StartAsync(procedureContext, collectorsSynchronizer, profilerCancellation.Token))
                        {
                            try
                            {
                                if (!profilerTask.IsFaulted && !profilerCancellation.IsCancellationRequested)
                                {
                                    try
                                    {
                                        queryResult = AdomdClientHelper.ExecuteDataTable(
                                            connection,
                                            procedureContext.CancellationToken,
                                            procedureContext.Statement,
                                            activityID: procedureContext.ClientActivityID,
                                            rowsLimit: procedureContext.QueryResultRowLimit,
                                            beforeStart: () => EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepExecuteStatement),
                                            beforeWait: () => EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepPendingOutcome)
                                        );
                                    }
                                    finally
                                    {
                                        profilerCancellation.Cancel();
                                    }
                                }
                            }
                            finally
                            {
                                profilerResult = profilerTask.Result;
                            }
                        }

                        #endregion
                    }
                }
                finally
                {
                    performanceResult = performanceTask.Result;
                }
            }

            return AnalyzerTaskResult.Create(queryResult, profilerResult, performanceResult);
        }

        public static Task<AnalyzerTaskResult> StartAsync(ProcedureContext procedureContext)
        {
            #region Argument exception

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion
            
            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepStartAnalyzerTask);

            return Task.Factory.StartNew(() =>
            {
                using (var connection = procedureContext.GetAnalyzeConnection())
                    return InternalAnalyzeAsync(procedureContext, connection);
            },
            procedureContext.CancellationToken,
            TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning,
            TaskScheduler.Default);
        }
    }
}
