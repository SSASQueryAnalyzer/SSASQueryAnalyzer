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

namespace SSASQueryAnalyzer.Server.Infrastructure
{
    using Microsoft.AnalysisServices;
    using Profiler;
    using SSASQueryAnalyzer.Server.Performance;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Security.Principal;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using AdomdClient = Microsoft.AnalysisServices.AdomdClient;
    using AdomdServer = Microsoft.AnalysisServices.AdomdServer;

    internal class ProcedureContext : IDisposable
    {
        private static readonly string ApplicationName = "SSASQueryAnalyzer.Server";
        public static readonly string ConfigurationFileRelativePath = Path.Combine(ApplicationName, "config.xml");
        public static readonly string SQLiteFolderPath = Path.Combine(ApplicationName, "sqlite");

#if ASQASSAS11 || ASQASSAS12
        private static readonly string CommandDiscoverSessionConnectionId = @"select session_connection_id from $system.discover_sessions where session_id = '{0}'";
        private string _currentConnectionID;
        public readonly Guid ClientActivityID = Guid.Empty;
#else
        public readonly Guid ClientActivityID = Guid.NewGuid();
#endif

        private CancellationTokenSource _cancellationSource;
        private string _batchConnectionString;
        private bool _disposed = false;

        public static ProcedureContext CreateForBatchExecution(string statement, ClearCacheMode clearCacheMode, string batchID, string batchConnectionString, string clientVersion, string clientType, string batchName)
        {
            int queryResultRowLimit = 0;
            return new ProcedureContext(ProcedureExecutionMode.Batch, statement, clearCacheMode, queryResultRowLimit, clientVersion, clientType, batchID, batchConnectionString, batchName);
        }

        public static ProcedureContext CreateForLiveExecution(string statement, ClearCacheMode clearCacheMode, int queryResultRowLimit, string clientVersion, string clientType)
        {
            return new ProcedureContext(ProcedureExecutionMode.Live, statement, clearCacheMode, queryResultRowLimit, clientVersion, clientType);
        }

        public static void CheckVersionCompatibility(Version ssasVersion)
        {
#if ASQASSAS11
            const int CompatibilitySsasMajorVersion = 11;
#elif ASQASSAS12
            const int CompatibilitySsasMajorVersion = 12;
#elif ASQASSAS13
            const int CompatibilitySsasMajorVersion = 13;  
#elif ASQASSAS14
            const int CompatibilitySsasMajorVersion = 14;            
#endif
            if (ssasVersion.Major != CompatibilitySsasMajorVersion)
                throw new ApplicationException("SSAS incompatible with current ASQA version [{0}/{1}]".FormatWith(ssasVersion.Major, CompatibilitySsasMajorVersion));
        }

        public static void CheckBatchVersionCompatibility(string version)
        {
            if (!Version.TryParse(version, out Version databaseVersion))
                throw new ApplicationException("ASQA database version is invalid [{0}]".FormatWith(version));

            if (databaseVersion != GetAsqaServerVersion())
                throw new ApplicationException("ASQA batch and server versions are incompatible");
        }
        
        public static void Reconfigure(string xconfig)
        {
            xconfig = ProfilerCollector.Reconfigure(xconfig);

            System.Action action = () =>
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProcedureContext.ConfigurationFileRelativePath);
                var content = XDocument.Parse(xconfig).ToString(SaveOptions.None);

                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, content);
            };

            using (var task = Task.Factory.StartNew(action))
                task.Wait();
        }

        private static void GetConfigurationDetails(out int traceEventsThreshold, out ClearCacheMode clearCacheMode)
        {
            int configuredTraceEventsThreshold = ProcedureConfiguration.XConfigEngineAttributeTraceEventsThresholdUnlimited;
            var configuredClearCacheMode = ProcedureConfiguration.XConfigEngineAttributeClearCacheModeDefault;

            System.Action action = () =>
            {
                var configurationFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProcedureContext.ConfigurationFileRelativePath);

                if (File.Exists(configurationFile))
                {
                    var engineConfiguration = XDocument.Load(configurationFile).Root.Elements(ProcedureConfiguration.XConfigEngineItem).SingleOrDefault();
                    if (engineConfiguration != null)
                    {
                        if (engineConfiguration.Attribute(ProcedureConfiguration.XConfigEngineAttributeTraceEventsThreshold) != null)
                            configuredTraceEventsThreshold = int.Parse(engineConfiguration.Attribute(ProcedureConfiguration.XConfigEngineAttributeTraceEventsThreshold).Value);

                        if (engineConfiguration.Attribute(ProcedureConfiguration.XConfigEngineAttributeClearCacheMode) != null)
                            configuredClearCacheMode = (ClearCacheMode)Enum.Parse(typeof(ClearCacheMode), engineConfiguration.Attribute(ProcedureConfiguration.XConfigEngineAttributeClearCacheMode).Value);
                    }
                }
            };

            using (var task = Task.Factory.StartNew(action))
                task.Wait();

            traceEventsThreshold = configuredTraceEventsThreshold;
            clearCacheMode = configuredClearCacheMode;
        }

        private static string GetRawConfiguration()
        {
            Func<string> read = () =>
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProcedureContext.ConfigurationFileRelativePath);
                if (File.Exists(path))
                    return File.ReadAllText(path);

                return new XDocument(new XElement(ProcedureConfiguration.XConfigRoot)).ToString(SaveOptions.DisableFormatting);
            };

            using (var task = Task.Factory.StartNew(read))
                return task.Result;
        }

        private static DataTable GetConfiguration()
        {
            GetConfigurationDetails(out int configuredTraceEventsThreshold, out ClearCacheMode configuredClearCacheMode);

            var table = new DataTable(ConfigurationType.Engine.ToString(), "Configuration");

            table.Columns.Add("PropertyName", typeof(string));
            table.Columns.Add("PopertyValue", typeof(string));

            table.Rows.Add(ProcedureConfiguration.XConfigEngineAttributeTraceEventsThreshold, configuredTraceEventsThreshold);
            table.Rows.Add(ProcedureConfiguration.XConfigEngineAttributeClearCacheMode, configuredClearCacheMode);

            return table;
        }

        public static DataTable GetConfigurationFor(ConfigurationType configurationType)
        {
            switch (configurationType)
            {
                case ConfigurationType.Engine:
                    return ProcedureContext.GetConfiguration();
                case ConfigurationType.TraceEvents:
                    return ProfilerCollector.GetConfiguration();
                case ConfigurationType.PerformanceCounters:
                    return PerformanceCollector.GetConfiguration();
                default:
                    throw new ApplicationException("Unknown ConfigurationType [{0}]".FormatWith(configurationType));
            }
        }

        private ProcedureContext(ProcedureExecutionMode executionMode, string statement, ClearCacheMode clearCacheMode, int queryResultRowLimit = 0, string clientVersion = null, string clientType = null, string batchID = null, string batchConnectionString = null, string batchName = null)
        {
#region Argument exception

            if (statement == null)
                throw new ArgumentNullException("statement");

            if (executionMode == ProcedureExecutionMode.Batch ^ batchID != null)
                throw new ArgumentException("ExecutionMode XOR batchID");

            if (executionMode == ProcedureExecutionMode.Batch ^ batchConnectionString != null)
                throw new ArgumentException("ExecutionMode XOR BatchConnectionString");

#endregion

            _batchConnectionString = batchConnectionString;
            _cancellationSource = new CancellationTokenSource();

            Statement = statement;
            ExecutionMode = executionMode;
            BatchID = Guid.Parse(batchID ?? Guid.Empty.ToString());
            ExecutionID = Guid.NewGuid();
            BatchName = batchName;
            CubeName = statement.GetCubeName();
            QueryResultRowLimit = queryResultRowLimit;
            DatabaseName = AdomdServer.Context.CurrentDatabaseName;
            ConnectionUserName = AdomdServer.Context.CurrentConnection.User.Name;
            ImpersonationIdentity = WindowsIdentity.GetCurrent();
            ExecuteForPrepare = AdomdServer.Context.ExecuteForPrepare;
            CurrentTraceEvents = ProfilerCollector.CurrentTraceEvents();
            ASQAServerVersion = GetAsqaServerVersion().ToString();
            ASQAServerConfig = GetRawConfiguration();
            ClientVersion = clientVersion;
            ClientType = clientType;
            SystemPhysicalMemory = PInvokeHelper.GetPhysicalSystemMemory();
            SystemOperativeSystemName = PInvokeHelper.GetOperatingSystemName();
            SystemLogicalCpuCore = Environment.ProcessorCount;

            GetConfigurationDetails(out int configuredTraceEventsThreshold, out ClearCacheMode configuredClearCacheMode);
            TraceEventsThreshold = configuredTraceEventsThreshold;
            ClearCacheMode = clearCacheMode == ClearCacheMode.Default ? configuredClearCacheMode : clearCacheMode;

            var ssasInfo = GetServerInfo();
            SSASInstanceName = AdomdServer.Context.CurrentServerID;
            SSASInstanceVersion = ssasInfo.Item1;
            SSASInstanceEdition = ssasInfo.Item2;
            SSASInstanceConfig = ssasInfo.Item3;

            if (executionMode == ProcedureExecutionMode.Batch)
            {
                var sqlInfo = BatchHelper.GetServerInfo(this);
                SQLInstanceName = sqlInfo.Item1;
                SQLInstanceVersion = sqlInfo.Item2;
                SQLInstanceEdition = sqlInfo.Item3;

                CheckBatchVersionCompatibility(version: sqlInfo.Item4);
            }

            CubeMetadata = XmlaHelper.RetrieveCubeMetadata(this);
            ProcedureContext.CheckVersionCompatibility(SSASInstanceVersion);
        }

        public static Tuple<Version, string, string> GetServerInfo()
        {
            Version version;
            string edition;
            string config;

            using (var server = new Microsoft.AnalysisServices.Server())
            {
                server.Connect("*");
                version = Version.Parse(server.Version);
                edition = server.Edition.ToString();
            }

            Func<string> read = () =>
            {
                var path = Environment.GetCommandLineArgs()
                    .SkipWhile((a) => !"-s".Equals(a, StringComparison.OrdinalIgnoreCase))
                    .Skip(1)
                    .Take(1)
                    .FirstOrDefault();

                if (path == null)
                    throw new FileNotFoundException("Unable to retrieve path from CommandLine", "msmdsrv.ini");

                return File.ReadAllText(Path.Combine(path, "msmdsrv.ini"));
            };

            using (var task = Task.Factory.StartNew(read))
                config = task.Result;

            return Tuple.Create(version, edition, config);
        }

        public static Version GetAsqaServerVersion()
        {
            return AssemblyInfo.AssemblyFileVersion;
        }

        public string SystemOperativeSystemName { get; private set; }

        public long SystemPhysicalMemory { get; private set; }

        public int SystemLogicalCpuCore { get; private set; }

        public string Statement { get; private set; }

        public int QueryResultRowLimit { get; private set; }

        public string ConnectionUserName { get; private set; }

        public WindowsIdentity ImpersonationIdentity { get; private set; }

        public string CubeName { get; private set; }

        public string CubeMetadata { get; private set; }

        public string SSASInstanceName { get; private set; }

        public Version SSASInstanceVersion { get; private set; }

        public string SSASInstanceEdition { get; private set; }

        public string SSASInstanceConfig { get; private set; }

        public string SQLInstanceName { get; private set; }

        public string SQLInstanceVersion { get; private set; }

        public string SQLInstanceEdition { get; private set; }

        public string ASQAServerVersion { get; private set; }

        public string ASQAServerConfig { get; private set; }

        public string ClientVersion { get; private set; }

        public string ClientType { get; private set; }

        public string DatabaseName { get; private set; }

        public bool ExecuteForPrepare { get; private set; }

        public ProcedureExecutionMode ExecutionMode { get; private set; }

        public ClearCacheMode ClearCacheMode { get; private set; }

        public int TraceEventsThreshold { get; private set; }

        public string BatchName { get; private set; }

        public Guid BatchID { get; private set; }

        public Guid ExecutionID { get; private set; }

        public IList<TraceEvent> CurrentTraceEvents { get; private set; }

#if ASQASSAS11 || ASQASSAS12        
        public string CurrentConnectionID
        {
            get
            {
                if (_currentConnectionID == null)
                    throw new ApplicationException("CurrentConnectionID is null");

                return _currentConnectionID;
            }
        }
#endif

        public string BatchConnectionString
        {
            get
            {
                if (ExecutionMode != ProcedureExecutionMode.Batch)
                    throw new ApplicationException("ExecutionMode is Batch");

                return _batchConnectionString;
            }
        }

        public string ConnectionString
        {
            get
            {
                // TODO: Protocol Format = EnableCompression
                return "Data Source={0};Initial Catalog={1};Application Name={2}".FormatWith(
                   SSASInstanceName,
                   DatabaseName,
                   ApplicationName
                   );
            }
        }

        public bool IsCancellationRequested
        {
            get
            {
                return _cancellationSource.IsCancellationRequested;
            }
        }

        public CancellationToken CancellationToken
        {
            get
            {
                return _cancellationSource.Token;
            }
        }

        public AdomdClient.AdomdConnection GetAnalyzeConnection()
        {
#if ASQASSAS11 || ASQASSAS12
            if (_currentConnectionID != null)
                throw new ApplicationException("Connection already created");

            var connection = new AdomdClient.AdomdConnection(ConnectionString);
            {
                connection.Open();
                connection.Disposed += (s, e) => _currentConnectionID = null;

                var connectionId = AdomdClientHelper.ExecuteScalar(ConnectionString, CommandDiscoverSessionConnectionId.FormatWith(connection.SessionID));
                if (connectionId == null)
                    throw new ApplicationException("session_connection_id is null");

                _currentConnectionID = Convert.ToString(connectionId);
            }
#else
            var connection = new AdomdClient.AdomdConnection(ConnectionString);
            {
                connection.Open();
            }
#endif
            return connection;
        }

        public void Cancel()
        {
            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepCancelTask);

            _cancellationSource.Cancel();
        }

        public void InitializeBatch()
        {
#region Argument exceptions
            
            if (ExecutionMode != ProcedureExecutionMode.Batch)
                throw new ApplicationException("Invalid executuion mode [{0}]".FormatWith(ExecutionMode));

#endregion

            BatchHelper.Initialize(this);
        }

        public void TraceBatchException(Exception exception)
        {
#region Argument exceptions

            if (ExecutionMode != ProcedureExecutionMode.Batch)
                throw new ApplicationException("Invalid executuion mode [{0}]".FormatWith(ExecutionMode));

#endregion

            BatchHelper.TraceException(this, exception);
        }

#region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _cancellationSource.Dispose();
                _cancellationSource = null;
            }
           
            _disposed = true;
        }

#endregion
    }
}
