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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Server;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Server.Performance;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Server.Profiler;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class AnalyzerExecutionResult : IDisposable
    {
        private bool _disposed;

        public EnginePerformanceCollection EnginePerformances { get; private set; }
        public AggregationsReadCollection AggregationsReads { get; private set; }
        public PartitionsReadCollection PartitionsReads { get; private set; }
        public CachesReadCollection CachesReads { get; private set; }
        public PerformanceItemCollectionList Performances { get; private set; }
        public ProfilerItemCollectionList Profilers { get; private set; }
        public ProcedureEventCollection ProcedureEvents { get; private set; }
        public DataTable QueryResults { get; private set; }
        public DataTable ExecutionInfo { get; private set; }

        #region Properties

        public DateTime ExecutionStartTime
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'execution_start_time'");
                if (row.Length == 1)
                    return DateTime.Parse((string)row[0]["value"]);

                return DateTime.MinValue;
            }
        }
        
        public DateTime ExecutionEndTime
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'execution_end_time'");
                if (row.Length == 1)
                    return DateTime.Parse((string)row[0]["value"]);

                return DateTime.MinValue;
            }
        }
        
        public string ASQAServerVersion
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'asqa_server_version'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string ASQAServerConfig
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'asqa_server_config'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string ClientVersion
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'client_version'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string ClientType
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'client_type'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public Guid BatchID
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'batch_id'");
                if (row.Length == 1)
                    return Guid.Parse(Convert.ToString(row[0]["value"]));

                return Guid.Empty;
            }
        }

        public string BatchName
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'batch_name'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string ConnectionUserName
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'connection_user_name'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string SSASInstanceName
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'ssas_instance_name'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string SSASInstanceVersion
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'ssas_instance_version'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string SSASInstanceEdition
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'ssas_instance_edition'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string SSASInstanceConfig
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'ssas_instance_config'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string SQLInstanceName
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'sql_instance_name'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);
                 
                return null;
            }
        }

        public string SQLInstanceVersion
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'sql_instance_version'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string SQLInstanceEdition
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'sql_instance_edition'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string Statement
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'statement'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string DatabaseName
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'database_name'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string CubeName
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'cube_name'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string CubeMetadata
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'cube_metadata'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public string SystemOperativeSystemName
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'system_operative_system_name'");
                if (row.Length == 1)
                    return Convert.ToString(row[0]["value"]);

                return null;
            }
        }

        public long SystemPhysicalMemory
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'system_physical_memory'");
                if (row.Length == 1)
                    return Convert.ToInt64(row[0]["value"]);

                return 0L;
            }
        }

        public int SystemLogicalCpuCore
        {
            get
            {
                var row = ExecutionInfo.Select("key = 'system_logical_cpu_core'");
                if (row.Length == 1)
                    return Convert.ToInt32(row[0]["value"]);

                return 0;
            }
        }

        #endregion

        private AnalyzerExecutionResult()
        {
        }

        public static AnalyzerExecutionResult CreateFromDataSet(DataSet dataset)
        {
            #region Argument exception

            if (dataset == null)
                throw new ArgumentNullException("dataset");

            #endregion

            // TODO: implementare gestione cancellationToken.CancellationRequested

            var result = new AnalyzerExecutionResult()
            {
                EnginePerformances = EnginePerformanceCollection.CreateFromDataSet(dataset),
                AggregationsReads = AggregationsReadCollection.CreateFromDataSet(dataset),
                PartitionsReads = PartitionsReadCollection.CreateFromDataSet(dataset),
                CachesReads = CachesReadCollection.CreateFromDataSet(dataset),
                Performances = PerformanceItemCollectionList.CreateFromDataSet(dataset),
                Profilers = ProfilerItemCollectionList.CreateFromDataSet(dataset),
                ProcedureEvents = ProcedureEventCollection.CreateFromDataSet(dataset),
                QueryResults = QueryResult.CreateFromDataSet(dataset),
            };

            var table = dataset.Tables["ExecutionInfo", "Common"];
            if (table != null)
                result.ExecutionInfo = table.Copy();

            return result;
        }

        public static AnalyzerExecutionResult CreateFromBatch(string connectionStringBatch, string batchID, ClearCacheMode clearCacheMode)
        {
            // TODO: parallelizzare e sistemare codice
            Action<string, Action<DataTable>, Action<SqlParameterCollection>> load = (commandText, action, param) =>
            {
                using (var connection = new SqlConnection(connectionStringBatch))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = commandText;
                        command.Parameters.Add(new SqlParameter("@batchID", SqlDbType.UniqueIdentifier)).Value = Guid.Parse(batchID);
                        command.Parameters.Add(new SqlParameter("@clearCacheMode", SqlDbType.NVarChar)).Value = clearCacheMode;
                        param(command.Parameters);

                        using (var reader = command.ExecuteReader())
                        using (var table = new DataTable())
                        {
                            table.Load(reader);
                            action(table);
                        }
                    }
                }
            };

            var result = new AnalyzerExecutionResult();

            load("[asqa].[sp_read_CommonEnginePerformance]", (table) => result.EnginePerformances = EnginePerformanceCollection.CreateFromDataTable(table), (param) => { });
            load("[asqa].[sp_read_CommonAggregationsRead]", (table) => result.AggregationsReads = AggregationsReadCollection.CreateFromDataTable(table), (param) => { });
            load("[asqa].[sp_read_CommonPartitionsRead]", (table) => result.PartitionsReads = PartitionsReadCollection.CreateFromDataTable(table), (param) => { });
            load("[asqa].[sp_read_CommonCachesRead]", (table) => result.CachesReads = CachesReadCollection.CreateFromDataTable(table), (param) => { });
            load("[asqa].[sp_read_ExecutionInfo]", (table) => result.ExecutionInfo = table.Copy(), (param) => { });

            #region Load performance

            DataTable performanceTypes = null;
            load("[asqa].[sp_read_PerformanceTypes]", (table) => performanceTypes = table.Copy(), (param) => { });

            result.Performances = new PerformanceItemCollectionList();

            foreach (DataRow type in performanceTypes.Rows)
            {
                string category = Convert.ToString(type["CategoryName"]);
                string name = Convert.ToString(type["CounterName"]);           

                load("[asqa].[sp_read_Performance]", 
                    (table) => result.Performances.Add(PerformanceItemCollection.CreateFromDataTable(table, category, name)), 
                    (param) => 
                    {
                        param.Add(new SqlParameter("@categoryName", SqlDbType.NVarChar)).Value = category;
                        param.Add(new SqlParameter("@counterName", SqlDbType.NVarChar)).Value = name;
                    });
            }

            #endregion

            #region Load trace

            DataTable profilerTypes = null;
            load("[asqa].[sp_read_TraceTypes]", (table) => profilerTypes = table.Copy(), (param) => { });

            result.Profilers = new ProfilerItemCollectionList();

            foreach (DataRow type in profilerTypes.Rows)
            {
                string eventClass = type["EventClass"].ToString();

                load("[asqa].[sp_read_Trace]", 
                    (table) => result.Profilers.Add(ProfilerItemCollection.CreateFromDataTable(table, eventClass)),
                    (param) => param.Add(new SqlParameter("@eventClass", SqlDbType.NVarChar)).Value = eventClass);
            }

            #endregion

            return result;
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (QueryResults != null)
                    {
                        QueryResults.Dispose();
                        QueryResults = null;
                    }

                    ProcedureEvents = null;
                    EnginePerformances = null;
                    AggregationsReads = null;
                    PartitionsReads = null;
                    CachesReads = null;
                    Performances = null;
                    Profilers = null;

                    GC.Collect(); // TODO: verificare se serve
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
