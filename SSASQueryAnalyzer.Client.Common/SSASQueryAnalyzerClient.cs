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

namespace SSASQueryAnalyzer.Client.Common
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices;
    using SSASQueryAnalyzer.Client.Common.Windows.Forms;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    public class SSASQueryAnalyzerClient : IDisposable
    {
        private const string ClrAssemblyID = "ASQA";
        private const string ClrAssemblyName = ClrAssemblyID;
        private const string ClrAssemblyDescription = "SSASQueryAnalyzer";
        private const string ClrAssemblyFileNameFormat = "SSASQueryAnalyzer.Server{0}.dll";
        private const string ConnectionStringFormat = "Data Source={0};Application Name={1};Initial Catalog={2}";

        private ResultPresenterExecutionProgressControl _executionProgressControl;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly string _connectionString;
        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public static Version ClientVersion
        {
            get
            {
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var version = FileVersionInfo.GetVersionInfo(location).FileVersion;

                return Version.Parse(version);
            }
        }

        public bool DebugToXml { get; set; }
        public bool ExecutionProgressControlEnabled { get; set; }

        public ResultPresenterExecutionProgressControl ExecutionProgressControl
        {
            get
            {
                if (_executionProgressControl == null && ExecutionProgressControlEnabled)
                    _executionProgressControl = new ResultPresenterExecutionProgressControl(this);

                return _executionProgressControl;
            }
        }
        
        public SSASQueryAnalyzerClient(string server, string database) 
            : this(ConnectionStringFormat.FormatWith(server, ClrAssemblyID, database))
        {
        }

        public SSASQueryAnalyzerClient(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// Retrieve server-side assembly version
        /// </summary>
        public async Task<Version> GetVersionAsync()
        {
            var command = "call {0}.GetVersion();".FormatWith(ClrAssemblyID);

            Func<Version> function = () =>
            {
                if (AnalysisServicesHelper.ClrAssemblyInstalled(_connectionString, ClrAssemblyID))
                    return AnalysisServicesHelper.ExecuteForDataTable(_connectionString, command).ToVersion();

                return null;
            };

            using (var task = Task.Factory.StartNew(function))
                return await task.ConfigureAwait(continueOnCapturedContext: false);
        }
        
        /// <summary>
        /// Install and configure the server-side objects using custom assembly file path
        /// </summary>
        public async Task InstallAsync(string assemblyFilePath = null)
        {
            if (assemblyFilePath == null)
            {
                string clrAssemblyFileName;

                switch (AnalysisServicesHelper.InstanceVersion(_connectionString).Major)
	            {
                    case 11:
                        clrAssemblyFileName = ClrAssemblyFileNameFormat.FormatWith(2012);
                        break;
                    case 12:
                        clrAssemblyFileName = ClrAssemblyFileNameFormat.FormatWith(2014);
                        break;
                    case 13:
                        clrAssemblyFileName = ClrAssemblyFileNameFormat.FormatWith(2016);
                        break;
                    case 14:
                        clrAssemblyFileName = ClrAssemblyFileNameFormat.FormatWith(2017);
                        break;
                    default:
                        throw new ApplicationException("Unsupported SSAS version");
	            }

                assemblyFilePath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), clrAssemblyFileName);
            }

            var command = "call {0}.Install();".FormatWith(ClrAssemblyID);

            Action action = () =>
            {
                AnalysisServicesHelper.RegisterClrAssembly(_connectionString, ClrAssemblyID, ClrAssemblyName, ClrAssemblyDescription, assemblyFilePath);
                AnalysisServicesHelper.ExecuteNonQuery(_connectionString, command);
            };

            using (var task = Task.Factory.StartNew(action))
                await task.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Uninstall the server-side objects previously configured
        /// </summary>
        public async Task UninstallAsync()
        {
            var command = "call {0}.Uninstall();".FormatWith(ClrAssemblyID);

            Action action = () =>
            {
                AnalysisServicesHelper.ExecuteNonQuery(_connectionString, command);
                AnalysisServicesHelper.UnregisterClrAssembly(_connectionString, ClrAssemblyID);
            };

            using (var task = Task.Factory.StartNew(action))
                await task.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Reconfigure the server-side objects previously configured
        /// </summary>
        public async Task ReconfigureAsync(string xconfig)
        {
            var command = "call {0}.Reconfigure(\"{1}\");".FormatWith(ClrAssemblyID, xconfig.EscapeMdxString());

            Action action = () =>
            {
                AnalysisServicesHelper.ExecuteNonQuery(_connectionString, command);
            };

            using (var task = Task.Factory.StartNew(action))
                await task.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// 
        /// </summary>
        public ProcedureEvents GetLastEvent()
        {
            var command = "call {0}.GetLastEvent();".FormatWith(ClrAssemblyID);

            return (ProcedureEvents)AnalysisServicesHelper.ExecuteScalar(_connectionString, command);
        }

        /// <summary>
        /// Retrieve server-side assembly configured trace events
        /// </summary>
        public async Task<DataTable> GetConfigurationForTraceEventsAsync()
        {
            var command = "call {0}.GetConfiguration({1});".FormatWith(ClrAssemblyID, (int)ConfigurationType.TraceEvents);

            Func<DataTable> function = () =>
            {
                return AnalysisServicesHelper.ExecuteForDataTable(_connectionString, command);
            };

            using (_cancellationTokenSource = new CancellationTokenSource())
            {
                using (var task = Task.Factory.StartNew(function))
                    return await task.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Retrieve server-side assembly configured performance counters
        /// </summary>
        public async Task<DataTable> GetConfigurationForPerformanceCountersAsync()
        {
            var command = "call {0}.GetConfiguration({1});".FormatWith(ClrAssemblyID, (int)ConfigurationType.PerformanceCounters);

            Func<DataTable> function = () =>
            {
                return AnalysisServicesHelper.ExecuteForDataTable(_connectionString, command);
            };            

            using (_cancellationTokenSource = new CancellationTokenSource())
            {
                using (var task = Task.Factory.StartNew(function))
                    return await task.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Retrieve server-side assembly configuration
        /// </summary>
        public async Task<DataTable> GetConfigurationForEngineAsync()
        {
            var command = "call {0}.GetConfiguration({1});".FormatWith(ClrAssemblyID, (int)ConfigurationType.Engine);

            Func<DataTable> function = () =>
            {
                return AnalysisServicesHelper.ExecuteForDataTable(_connectionString, command);
            };

            using (_cancellationTokenSource = new CancellationTokenSource())
            {
                using (var task = Task.Factory.StartNew(function))
                    return await task.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Cancel a currently running operation
        /// </summary>
        public void Cancel()
        {
            if (_cancellationTokenSource != null)
                _cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Execute server-side Analyze procedure
        /// </summary>
        public async Task<AnalyzerStatistics> AnalyzeAsync(string statement, ClearCacheMode clearCacheMode = ClearCacheMode.Default, int queryResultRowLimit = 0)
        {
            #region Argument exception

            if (statement == null)
                throw new ArgumentNullException("statement");

            #endregion

            var currentProcess = Process.GetCurrentProcess();
            var processName = currentProcess.ProcessName;
            var clientVersion = "{0} ({1})".FormatWith(currentProcess.MainModule.FileVersionInfo.FileVersion, ClientVersion);

#if DEBUG
            Func<ClearCacheMode, string> commandAnalyze = (cacheMode) => "call {0}.AnalyzeWithDebug(\"{1}\", {2}, {3}, \"{4}\", \"{5}\");".FormatWith(ClrAssemblyID, statement.EscapeMdxString(), (int)cacheMode, queryResultRowLimit, clientVersion, processName);
#else
            Func<ClearCacheMode, string> commandAnalyze = (cacheMode) => "call {0}.Analyze(\"{1}\", {2}, {3}, \"{4}\", \"{5}\");".FormatWith(ClrAssemblyID, statement.EscapeMdxString(), (int)cacheMode, queryResultRowLimit, clientVersion, processName);
#endif
            Action<DataSet, string> saveDebug = (data, dbgType) =>
            {
                if (!DebugToXml)
                    return;

                var debugPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"SSASQueryAnalyzer\debug");
                Directory.CreateDirectory(debugPath);
                data.WriteXml(Path.Combine(debugPath, "AnalyzerExecutionResult-{0:yyyyMMdd-hhmmss-fff}.{1}").FormatWith(DateTime.Now, dbgType), XmlWriteMode.WriteSchema);
            };

            Func<AnalyzerStatistics> analyzeProcedure = () =>
            {
                ExecutionProgressControl?.StartMonitor();
                try
                {
                    AnalyzerExecutionResult coldCacheExecutionResult;
                    AnalyzerExecutionResult warmCacheExecutionResult;

                    using(var data = AnalysisServicesHelper.ExecuteForDataSet(_connectionString, commandAnalyze(clearCacheMode), _cancellationTokenSource.Token))
                    {
                        saveDebug(data, "xqac");
                        coldCacheExecutionResult = data.ToAnalyzerExecutionResult(dispose: true);
                    }

                    ExecutionProgressControl?.ColdCacheExecutionCompleted();

                    using (var data = AnalysisServicesHelper.ExecuteForDataSet(_connectionString, commandAnalyze(ClearCacheMode.Nothing), _cancellationTokenSource.Token))
                    {
                        saveDebug(data, "xqaw");
                        warmCacheExecutionResult = data.ToAnalyzerExecutionResult(dispose: true);
                    }

                    ExecutionProgressControl?.WarmCacheExecutionCompleted();

                    return AnalyzerStatistics.CreateFromAnalyzerExecutionResults(coldCacheExecutionResult, warmCacheExecutionResult);
                }
                finally
                {
                    ExecutionProgressControl?.StopMonitor();
                }
            };

            using (_cancellationTokenSource = new CancellationTokenSource())
            {
                using (var task = Task.Factory.StartNew(analyzeProcedure))
                    return await task.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Execute server-side AnalyzeBatch procedure
        /// </summary>
        public async Task<AnalyzerStatistics> AnalyzeBatchAsync(string connectionStringBatch, string statement, ClearCacheMode clearCacheMode = ClearCacheMode.Default, string xconfig = null, string batchName = null, bool throwOnError = true)
        {
            #region Argument exception

            if (connectionStringBatch == null)
                throw new ArgumentNullException("connectionStringBatch");

            if (statement == null)
                throw new ArgumentNullException("statement");

            #endregion

            var currentProcess = Process.GetCurrentProcess();
            var processName = currentProcess.ProcessName;
            var clientVersion = "{0} ({1})".FormatWith(currentProcess.MainModule.FileVersionInfo.FileVersion, ClientVersion);
            
#if DEBUG
            Func<Guid, ClearCacheMode, string> commandAnalyze = (batchID, cacheMode) => "call {0}.AnalyzeBatchWithDebug(\"{1}\", {2}, \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\");".FormatWith(ClrAssemblyID, statement.EscapeMdxString(), (int)cacheMode, batchID, connectionStringBatch.EscapeMdxString(), clientVersion, processName, batchName, throwOnError);
#else
            Func<Guid, ClearCacheMode, string> commandAnalyze = (batchID, cacheMode) => "call {0}.AnalyzeBatch(\"{1}\", {2}, \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\");".FormatWith(ClrAssemblyID, statement.EscapeMdxString(), (int)cacheMode, batchID, connectionStringBatch.EscapeMdxString(), clientVersion, processName, batchName, throwOnError);
#endif
            Func<AnalyzerStatistics> analyzeProcedure = () =>
            {
                ExecutionProgressControl?.StartMonitor_Batch();
                try
                {
                    var batchID = Guid.NewGuid();
                
                    var coldCacheExecutionResult = AnalysisServicesHelper.ExecuteForDataSet(_connectionString, commandAnalyze(batchID, clearCacheMode), _cancellationTokenSource.Token).ToAnalyzerExecutionResult(dispose: true);
                    var warmCacheExecutionResult = AnalysisServicesHelper.ExecuteForDataSet(_connectionString, commandAnalyze(batchID, ClearCacheMode.Nothing), _cancellationTokenSource.Token).ToAnalyzerExecutionResult(dispose: true);

                    return AnalyzerStatistics.CreateFromAnalyzerExecutionResults(coldCacheExecutionResult, warmCacheExecutionResult);
                }
                finally
                {
                    ExecutionProgressControl?.StopMonitor_Batch();
                }
            };

            using (_cancellationTokenSource = new CancellationTokenSource())
            {
                using (var task = Task.Factory.StartNew(analyzeProcedure))
                    return await task.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Load Xml debug file
        /// </summary>
        public async Task<AnalyzerStatistics> AnalyzeFromDebugAsync(string coldCacheDebugFile, string warmCacheDebugFile)
        {
            #region Argument exception

            if (coldCacheDebugFile == null)
                throw new ArgumentNullException("coldCacheDebugFile");

            if (warmCacheDebugFile == null)
                throw new ArgumentNullException("warmCacheDebugFile");

            #endregion

            Func<AnalyzerStatistics> analyzeProcedure = () =>
            {
                AnalyzerExecutionResult coldCacheExecutionResult;
                AnalyzerExecutionResult warmCacheExecutionResult;

                using (var data = new DataSet())
                {
                    data.ReadXml(coldCacheDebugFile, XmlReadMode.ReadSchema);
                    coldCacheExecutionResult = data.ToAnalyzerExecutionResult(dispose: true);
                }

                using (var data = new DataSet())
                {
                    data.ReadXml(warmCacheDebugFile, XmlReadMode.ReadSchema);
                    warmCacheExecutionResult = data.ToAnalyzerExecutionResult(dispose: true);
                }

                return AnalyzerStatistics.CreateFromAnalyzerExecutionResults(coldCacheExecutionResult, warmCacheExecutionResult);
            };

            using (var task = Task.Factory.StartNew(analyzeProcedure))
                return await task.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<AnalyzerStatistics> AnalyzeFromBatchAsync(string connectionStringBatch, string batchID)
        {
            #region Argument exception

            if (connectionStringBatch == null)
                throw new ArgumentNullException("connectionStringBatch");

            if (batchID == null)
                throw new ArgumentNullException("batchID");

            #endregion
            
            Func<AnalyzerStatistics> analyzeProcedure = () =>
            {
                ExecutionProgressControl?.StartMonitor_Batch();
                try
                {
                    return AnalyzerStatistics.CreateFromAnalyzerBatchResults(connectionStringBatch, batchID);
                }
                finally
                {
                    ExecutionProgressControl?.StopMonitor_Batch();
                }
            };

            using (var task = Task.Factory.StartNew(analyzeProcedure))
                return await task.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// 
        /// </summary>
        public Control BuildRawResultControl(AnalyzerStatistics analyzerStatistics)
        {
            return AnalyzerExecutionResultHelper.BuildRawResultControl(analyzerStatistics);
        }

        /// <summary>
        /// 
        /// </summary>
        public Control BuildResultControl(AnalyzerStatistics analyzerStatistics)
        {
            return ResultPresenterControl.Create(analyzerStatistics);
        }

        /// <summary>
        /// 
        /// </summary>
        public Control BuildBatchResultControl(AnalyzerStatistics analyzerStatistics)
        {
            return ResultPresenterControl.CreateForBatch(analyzerStatistics);
        }

        /// <summary>
        /// 
        /// </summary>
        public Control BuildLoadBatchResultControl(AnalyzerStatistics analyzerStatistics)
        {
            return ResultPresenterControl.CreateForLoadBatch(analyzerStatistics);
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_cancellationTokenSource != null)
                    {
                        _cancellationTokenSource.Dispose();
                        _cancellationTokenSource = null;
                    }

                    if (_executionProgressControl != null)
                    {
                        _executionProgressControl.Dispose();
                        _executionProgressControl = null;
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
