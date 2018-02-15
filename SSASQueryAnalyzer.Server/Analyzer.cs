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
    using SSASQueryAnalyzer.Server.Profiler;
    using System;
    using System.Data;
    using System.Security.Permissions;
    using System.Threading;
    using AdomdServer = Microsoft.AnalysisServices.AdomdServer;

    public static class Analyzer
    {
        static Analyzer()
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolverHelper.Resolve;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>call ASQA.GetVersion();</example>
        public static DataTable GetVersion()
        {
            return ProcedureContext.GetAsqaServerVersion().ToVersionTable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>call ASQA.GetConfiguration(configurationType);</example>
        public static DataTable GetConfiguration(int configurationType)
        {
            using (ProcedureMutex.TryAcquire())
            {
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureGetConfigurationBegin);
                var configuration = ProcedureContext.GetConfigurationFor((ConfigurationType)configurationType);
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureGetConfigurationEnd);
                return configuration;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>call ASQA.GetLastEvent();</example>
        public static DataTable GetLastEvent()
        {
            var table = new DataTable();

            table.Columns.Add("LastEvent", typeof(int));
            table.Rows.Add((int)EventsNotifier.Instance.LastNotifiedEvent);              

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>
        /// call ASQA.Reconfigure("<config />");
        /// </example>
        public static void Reconfigure(string xconfig)
        {
            using (ProcedureMutex.TryAcquire())
            {
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureReconfigureBegin);
                ProcedureContext.Reconfigure(xconfig);
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureReconfigureEnd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>
        /// call ASQA.Install();
        /// </example>
        public static void Install()
        {
            using (ProcedureMutex.TryAcquire())
            {
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureInstallBegin);
                ProfilerCollector.Install();
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureInstallEnd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>
        /// call ASQA.Uninstall();
        /// </example>
        public static void Uninstall()
        {
            using (ProcedureMutex.TryAcquire())
            {
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureUninstallBegin);
                ProfilerCollector.Uninstall();
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureUninstallEnd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>
        /// call ASQA.Analyze("select [Measures].[Amount] on 0 from [Adventure Works]", 3);
        /// </example>
        [AdomdServer.SafeToPrepare(true)]
        public static DataSet Analyze(string statement, int clearCacheMode, int queryResultRowLimit, string clientVersion, string clientType)
        {
            using (ProcedureMutex.TryAcquire())
            {
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeBegin);

                DataSet procedureResult;
                using (var procedureContext = ProcedureContext.CreateForLiveExecution(statement, (ClearCacheMode)clearCacheMode, queryResultRowLimit, clientVersion, clientType))
                using (var analyzeResult = new AnalyzerResult(procedureContext))
                {
                    if (AdomdServer.Context.ExecuteForPrepare)
                    {
                        procedureResult = analyzeResult.CalculateForPrepare();
                    }
                    else
                    {
                        procedureContext.ValidateStatement();
                        procedureContext.ClearCache();
                        procedureContext.LoadCubeScript();

                        AdomdServer.Context.CheckCancelled();

                        using (var analyzeTask = AnalyzerTask.StartAsync(procedureContext))
                        {
                            #region Pending outcome

                            while (!analyzeTask.Wait(100))
                            {
                                try
                                {
                                    AdomdServer.Context.CheckCancelled();
                                }
                                catch (AdomdServer.AdomdException)
                                {
                                    procedureContext.Cancel();

                                    while (!analyzeTask.IsCompleted)
                                        Thread.Sleep(50);

                                    throw;
                                }
                            }

                            #endregion

                            procedureResult = analyzeResult.Calculate(analyzeTask.Result);
                        }
                    }
                }

                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeEnd);
                return procedureResult;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>
        /// call ASQA.AnalyzeBatch("select [Measures].[Amount] on 0 from [Adventure Works]", 3, "ed1b80e0-639d-4bb5-a418-4508c2d2c1a1", "Data Source=localhost;Initial Catalog=ASQA", "0.1.0.16245", "ssms.exe", "my batch name", true);
        /// </example>
        [AdomdServer.SafeToPrepare(false)]
        public static DataSet AnalyzeBatch(string statement, int clearCacheMode, string batchID, string batchConnectionString, string clientVersion, string clientType, string batchName, bool throwOnError)
        {
            using (ProcedureMutex.TryAcquire())
            {
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeBegin);

                var procedureResult = new DataSet();
                using (var procedureContext = ProcedureContext.CreateForBatchExecution(statement, (ClearCacheMode)clearCacheMode, batchID, batchConnectionString, clientVersion, clientType, batchName))
                using (var analyzeResult = new AnalyzerResult(procedureContext))
                {
                    AdomdServer.Context.CheckCancelled();

                    BatchHelper.Initialize(procedureContext);
                    try
                    {
                        procedureContext.ValidateStatement();
                        procedureContext.ClearCache();
                        procedureContext.LoadCubeScript();

                        AdomdServer.Context.CheckCancelled();

                        using (var analyzeTask = AnalyzerTask.StartAsync(procedureContext))
                        {
                            #region Pending outcome

                            while (!analyzeTask.Wait(100))
                            {
                                try
                                {
                                    AdomdServer.Context.CheckCancelled();
                                }
                                catch (AdomdServer.AdomdException)
                                {
                                    procedureContext.Cancel();

                                    while (!analyzeTask.IsCompleted)
                                        Thread.Sleep(50);

                                    throw;
                                }
                            }

                            #endregion

                            procedureResult = analyzeResult.Calculate(analyzeTask.Result);
                        }

                        BatchHelper.Finalize(procedureContext);
                    }
                    catch(Exception ex)
                    {
                        BatchHelper.TraceException(procedureContext, ex);

                        if (throwOnError)
                            throw ex;
                    }
                }

                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeEnd);
                return procedureResult;
            }
        }

#if DEBUG
        [AdomdServer.SafeToPrepare(true)]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static DataSet AnalyzeWithDebug(string statement, int clearCacheMode, int queryResultRowLimit, string clientVersion, string clientType)
        {
            UnhandledExceptionEventHandler unhandledException = (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                AdomdServer.Context.TraceEvent((int)ProcedureEvents.UnhandledException, 0, ex.ToString());
                throw ex;
            };
            
            AppDomain.CurrentDomain.UnhandledException += unhandledException;
            try
            {
                try
                {
                    return Analyze(statement, clearCacheMode, queryResultRowLimit, clientVersion, clientType);
                }
                catch (Exception ex)
                {
                    AdomdServer.Context.TraceEvent((int)ProcedureEvents.ApplicationException, 0, ex.ToString());
                    throw new ApplicationException(ProcedureEvents.ApplicationException.ToString(), ex);
                }
            }
            finally
            {
                AppDomain.CurrentDomain.UnhandledException -= unhandledException;
            }
        }

        [AdomdServer.SafeToPrepare(false)]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static DataSet AnalyzeBatchWithDebug(string statement, int clearCacheMode, string batchID, string batchConnectionString, string clientVersion, string clientType, string batchName, bool throwOnError)
        {
            UnhandledExceptionEventHandler unhandledException = (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                AdomdServer.Context.TraceEvent((int)ProcedureEvents.UnhandledException, 0, ex.ToString());
                throw ex;
            };

            AppDomain.CurrentDomain.UnhandledException += unhandledException;
            try
            {
                try
                {
                    return AnalyzeBatch(statement, clearCacheMode, batchID, batchConnectionString, clientVersion, clientType, batchName, throwOnError);
                }
                catch (Exception ex)
                {
                    AdomdServer.Context.TraceEvent((int)ProcedureEvents.ApplicationException, 0, ex.ToString());
                    throw new ApplicationException(ProcedureEvents.ApplicationException.ToString(), ex);
                }
            }
            finally
            {
                AppDomain.CurrentDomain.UnhandledException -= unhandledException;
            }
        }
#endif
    }
}
