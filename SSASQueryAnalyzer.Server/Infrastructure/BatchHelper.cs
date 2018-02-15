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
    using SSASQueryAnalyzer.Server.Performance;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    internal static class BatchHelper
    {
        public static int CalculateTimeout = 60 * 5;
        public static int BulkCopyTimeout = 60;
        public static int BulkCopyBatchSize = 1000;
        public static string PerformanceTableName = "[asqa].[Performance]";

        private static void WriteToServer(ProcedureContext procedureContext, DataTable table, string destinationTableName)
        {
            using (procedureContext.ImpersonationIdentity.Impersonate())
            {
                // http://www.sqlbi.com/wp-content/uploads/SqlBulkCopy-Performance-1.0.pdf
                using (var bulkCopy = new SqlBulkCopy(procedureContext.BatchConnectionString, SqlBulkCopyOptions.TableLock))
                {
                    foreach (DataColumn column in table.Columns)
                        bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);

                    bulkCopy.BatchSize = BatchHelper.BulkCopyBatchSize;
                    bulkCopy.BulkCopyTimeout = BatchHelper.BulkCopyTimeout;
                    bulkCopy.DestinationTableName = destinationTableName;
                    bulkCopy.WriteToServer(table);
                }
            }
        }

        public static void WriteToServer(ProcedureContext procedureContext, IDataReader reader, string destinationTableName, string beforeActionCommandText = null, string afterActionCommandText = null)
        {
            using (procedureContext.ImpersonationIdentity.Impersonate())
            {
                using (var connection = new SqlConnection(procedureContext.BatchConnectionString))
                {
                    connection.Open();

                    if (beforeActionCommandText != null)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = beforeActionCommandText;
                            command.ExecuteNonQuery();
                        }
                    }

                    // http://www.sqlbi.com/wp-content/uploads/SqlBulkCopy-Performance-1.0.pdf
                    using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, externalTransaction: null))
                    {
                        var fields = Enumerable.Range(0, reader.FieldCount);
                        foreach (var columnName in fields.Select((i) => reader.GetName(i)))
                            bulkCopy.ColumnMappings.Add(columnName, columnName);

                        bulkCopy.BatchSize = BatchHelper.BulkCopyBatchSize;
                        bulkCopy.BulkCopyTimeout = BatchHelper.BulkCopyTimeout;
                        bulkCopy.DestinationTableName = destinationTableName;

                        do
                        {
                            bulkCopy.WriteToServer(reader);
                        }
                        while (reader.NextResult());
                    }

                    if (afterActionCommandText != null)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = afterActionCommandText;
                            command.CommandTimeout = 0;
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void WriteToSqlite(ProcedureContext procedureContext, IDataReader reader, Action<IDataReader> afterCompleted)
        {            
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            if (reader == null)
                throw new ArgumentNullException("reader");

            if (afterCompleted == null)
                throw new ArgumentNullException("afterCompleted");

            #endregion

            var createTableCommandText = @"     
CREATE TABLE Trace
(
	ID NUMERIC,
	EventClass TEXT,
	EventSubclass TEXT,
	IntegerData INTEGER,
	StartTime DATETIME,
	CurrentTime DATETIME,
	Duration INTEGER,
	ObjectName TEXT,
	CpuTime INTEGER,
	EndTime DATETIME,
	ObjectID TEXT,
	ObjectPath TEXT,
	ObjectType TEXT,
	ObjectReference TEXT,
	ProgressTotal INTEGER,
	TextData TEXT
)";

            var insertCommandText = @" 
INSERT INTO Trace
(
	ID,
	EventClass,
	EventSubclass,
	IntegerData,
	StartTime,
	CurrentTime,
	Duration,
	ObjectName,
	CpuTime,
	EndTime,
	ObjectID,
	ObjectPath,
	ObjectType,
	ObjectReference,
	ProgressTotal,
	TextData
)
VALUES
(
	@ID,
	@EventClass,
	@EventSubclass,
	@IntegerData,
	@StartTime,
	@CurrentTime,
	@Duration,
	@ObjectName,
	@CpuTime,
	@EndTime,
	@ObjectID,
	@ObjectPath,
	@ObjectType,
	@ObjectReference,
	@ProgressTotal,
	@TextData
)";
            
            var selectCommandText = @"
SELECT
	ID,
	EventClass,
	EventSubclass,
	IntegerData,
	StartTime,
	CurrentTime,
	Duration,
	ObjectName,
	CpuTime,
	EndTime,
	ObjectID,
	ObjectPath,
	ObjectType,
	ObjectReference,
	ProgressTotal,
	TextData
FROM
    Trace";

            System.Action action = () =>
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProcedureContext.SQLiteFolderPath);

                Environment.SetEnvironmentVariable("PreLoadSQLite_BaseDirectory", Path.Combine(path, "bin"));

                var interopPath = Path.Combine(path, "bin", "x64");
                var interopFile = Path.Combine(interopPath, "SQLite.Interop.dll");

                if (!File.Exists(interopFile))
                {
                    Directory.CreateDirectory(interopPath);

                    using (var stream = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SSASQueryAnalyzer.Server.Resources.SQLite.Interop.dll")))
                    using (var file = File.Create(interopFile))
                    {
                        stream.BaseStream.Seek(0, SeekOrigin.Begin);
                        stream.BaseStream.CopyTo(file);
                    }
                }

                var databasePath = Path.Combine(path, "db");
                var databaseFileName = Path.Combine(databasePath, "asqa-{0:N}-{1:N}.db".FormatWith(procedureContext.BatchID, procedureContext.ExecutionID));

                Directory.CreateDirectory(databasePath);

                foreach (var file in Directory.EnumerateFiles(databasePath, "asqa-*.db"))
                    File.Delete(file);

                var connectionStringBuilder = new SQLiteConnectionStringBuilder();
                connectionStringBuilder.JournalMode = SQLiteJournalModeEnum.Off;
                connectionStringBuilder.SyncMode = SynchronizationModes.Off;
                connectionStringBuilder.DataSource = databaseFileName;
                connectionStringBuilder.FailIfMissing = false;
                connectionStringBuilder.LegacyFormat = false;
                connectionStringBuilder.Version = 3;
                connectionStringBuilder.DateTimeKind = DateTimeKind.Utc;
                connectionStringBuilder.DateTimeFormat = SQLiteDateFormats.ISO8601;

                using (var connection = new SQLiteConnection(connectionStringBuilder.ToString()))
                {
                    connection.Open();
                    
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = createTableCommandText;
                        command.ExecuteNonQuery();
                    }

                    using (var transaction = connection.BeginTransaction())
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = insertCommandText;
                        command.Prepare();

                        #region Params binding

                        var paramID = command.Parameters.Add("@ID", DbType.Int32);
                        var paramEventClass = command.Parameters.Add("@EventClass", DbType.String);
                        var paramEventSubclass = command.Parameters.Add("@EventSubclass", DbType.String);
                        var paramIntegerData = command.Parameters.Add("@IntegerData", DbType.Int64);
                        var paramStartTime = command.Parameters.Add("@StartTime", DbType.DateTime);
                        var paramCurrentTime = command.Parameters.Add("@CurrentTime", DbType.DateTime);
                        var paramDuration = command.Parameters.Add("@Duration", DbType.Int32);
                        var paramObjectName = command.Parameters.Add("@ObjectName", DbType.String);
                        var paramCpuTime = command.Parameters.Add("@CpuTime", DbType.Int32);
                        var paramEndTime = command.Parameters.Add("@EndTime", DbType.DateTime);
                        var paramObjectID = command.Parameters.Add("@ObjectID", DbType.String);
                        var paramObjectPath = command.Parameters.Add("@ObjectPath", DbType.String);
                        var paramObjectType = command.Parameters.Add("@ObjectType", DbType.String);
                        var paramObjectReference = command.Parameters.Add("@ObjectReference", DbType.String);
                        var paramProgressTotal = command.Parameters.Add("@ProgressTotal", DbType.Int64);
                        var paramTextData = command.Parameters.Add("@TextData", DbType.String);
 
                        var columnOrdinalID = reader.GetOrdinal("ID");
                        var columnOrdinalEventClass = reader.GetOrdinal("EventClass");
                        var columnOrdinalEventSubclass = reader.GetOrdinal("EventSubclass");
                        var columnOrdinalIntegerData = reader.GetOrdinal("IntegerData");
                        var columnOrdinalStartTime = reader.GetOrdinal("StartTime");
                        var columnOrdinalCurrentTime = reader.GetOrdinal("CurrentTime");
                        var columnOrdinalDuration = reader.GetOrdinal("Duration");
                        var columnOrdinalObjectName = reader.GetOrdinal("ObjectName");
                        var columnOrdinalCpuTime = reader.GetOrdinal("CpuTime");
                        var columnOrdinalEndTime = reader.GetOrdinal("EndTime");
                        var columnOrdinalObjectID = reader.GetOrdinal("ObjectID");
                        var columnOrdinalObjectPath = reader.GetOrdinal("ObjectPath");
                        var columnOrdinalObjectType = reader.GetOrdinal("ObjectType");
                        var columnOrdinalObjectReference = reader.GetOrdinal("ObjectReference");
                        var columnOrdinalProgressTotal = reader.GetOrdinal("ProgressTotal");
                        var columnOrdinalTextData = reader.GetOrdinal("TextData");

                        #endregion

                        do
                        {
                            while (reader.Read())
                            {
                                #region Params values

                                paramID.Value = reader[columnOrdinalID];
                                paramEventClass.Value = reader[columnOrdinalEventClass];
                                paramEventSubclass.Value = reader[columnOrdinalEventSubclass];
                                paramIntegerData.Value = reader[columnOrdinalIntegerData];
                                paramStartTime.Value = reader[columnOrdinalStartTime];
                                paramCurrentTime.Value = reader[columnOrdinalCurrentTime];
                                paramDuration.Value = reader[columnOrdinalDuration];
                                paramObjectName.Value = reader[columnOrdinalObjectName];
                                paramCpuTime.Value = reader[columnOrdinalCpuTime];
                                paramEndTime.Value = reader[columnOrdinalEndTime];
                                paramObjectID.Value = reader[columnOrdinalObjectID];
                                paramObjectPath.Value = reader[columnOrdinalObjectPath];
                                paramObjectType.Value = reader[columnOrdinalObjectType];
                                paramObjectReference.Value = reader[columnOrdinalObjectReference];
                                paramProgressTotal.Value = reader[columnOrdinalProgressTotal];
                                paramTextData.Value = reader[columnOrdinalTextData];

                                #endregion

                                command.ExecuteNonQuery();
                            }
                        }
                        while (reader.NextResult());
 
                        transaction.Commit();
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = selectCommandText;

                        using (var select = command.ExecuteReader())
                            afterCompleted(select);
                    }
                }
            };

            using (var task = Task.Factory.StartNew(action))
                task.Wait();
        }

        public static Tuple<string, string, string, string> GetServerInfo(ProcedureContext procedureContext)
        {
            var selectCommand = @"
SELECT
    [ServerName] = CAST(SERVERPROPERTY('ServerName') AS NVARCHAR(256)), 
    [ProductVersion] = CAST(SERVERPROPERTY('ProductVersion') AS NVARCHAR(256)), 
    [Edition] = CAST(SERVERPROPERTY('Edition') AS NVARCHAR(256)),
	[ASQADatabaseVersion] = 
	(
		SELECT [ASQADatabaseVersion] = ep.value 
		FROM sys.extended_properties AS ep 
		WHERE ep.class = 0 AND ep.name = N'ASQA_DatabaseVersion'
	)
";

            using (procedureContext.ImpersonationIdentity.Impersonate())
            {
                using (var connection = new SqlConnection(procedureContext.BatchConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(selectCommand, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        using (var table = new DataTable())
                        {
                            table.Load(reader);

                            var serverName = Convert.ToString(table.Rows[0][0]);
                            var productVersion = Convert.ToString(table.Rows[0][1]);
                            var edition = Convert.ToString(table.Rows[0][2]);
                            var asqaDatabaseVersion = Convert.ToString(table.Rows[0][3]);

                            return Tuple.Create(serverName, productVersion, edition, asqaDatabaseVersion);
                        }
                    }
                }
            }
        }

        public static void Initialize(ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion
                     
            var insertCommand = @"
INSERT INTO [asqa].[Execution] 
(
    [BatchID], 
    [ExecutionID], 
    [BatchName], 
    [ExecutionStartTime], 
    [ConnectionUserName], 
    [ImpersonationUserName], 
    [SSASInstanceName], 
    [SSASInstanceVersion], 
    [SSASInstanceEdition], 
    [SSASInstanceConfig], 
    [SQLInstanceName], 
    [SQLInstanceVersion], 
    [SQLInstanceEdition], 
    [DatabaseName], 
    [CubeName],  
    [CubeMetadata], 
    [ClearCacheMode], 
    [Statement], 
    [ASQAServerVersion], 
    [ASQAServerConfig], 
    [ClientVersion], 
    [ClientType],
    [SystemOperativeSystemName],
    [SystemPhysicalMemory],
    [SystemLogicalCpuCore]
)
VALUES 
(
    @batchID, 
    @executionID, 
    @batchName, 
    @executionStartTime, 
    @connectionUserName, 
    @impersonationUserName, 
    @ssasInstanceName, 
    @ssasInstanceVersion, 
    @ssasInstanceEdition, 
    @ssasInstanceConfig,
    CAST(SERVERPROPERTY('ServerName') AS NVARCHAR(256)), 
    CAST(SERVERPROPERTY('ProductVersion') AS NVARCHAR(256)), 
    CAST(SERVERPROPERTY('Edition') AS NVARCHAR(256)), 
    @databaseName,
    @cubeName,
    @cubeMetadata,
    @clearCacheMode, 
    @statement, 
    @asqaServerVersion,
    @asqaServerConfig,
    @clientVersion,
    @clientType,
    @systemOperativeSystemName,
    @systemPhysicalMemory,
    @systemLogicalCpuCore
)";
            
            using (procedureContext.ImpersonationIdentity.Impersonate())
            {
                using (var connection = new SqlConnection(procedureContext.BatchConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(insertCommand, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@batchID", SqlDbType.UniqueIdentifier)).Value = procedureContext.BatchID;
                        command.Parameters.Add(new SqlParameter("@executionID", SqlDbType.UniqueIdentifier)).Value = procedureContext.ExecutionID;
                        command.Parameters.Add(new SqlParameter("@batchName", SqlDbType.NVarChar)).Value = procedureContext.BatchName;
                        command.Parameters.Add(new SqlParameter("@executionStartTime", SqlDbType.DateTime)).Value = DateTime.UtcNow;
                        command.Parameters.Add(new SqlParameter("@connectionUserName", SqlDbType.NVarChar)).Value = procedureContext.ConnectionUserName;
                        command.Parameters.Add(new SqlParameter("@impersonationUserName", SqlDbType.NVarChar)).Value = procedureContext.ImpersonationIdentity.Name;
                        command.Parameters.Add(new SqlParameter("@ssasInstanceName", SqlDbType.NVarChar)).Value = procedureContext.SSASInstanceName;
                        command.Parameters.Add(new SqlParameter("@ssasInstanceVersion", SqlDbType.NVarChar)).Value = procedureContext.SSASInstanceVersion.ToString();
                        command.Parameters.Add(new SqlParameter("@ssasInstanceEdition", SqlDbType.NVarChar)).Value = procedureContext.SSASInstanceEdition;
                        command.Parameters.Add(new SqlParameter("@ssasInstanceConfig", SqlDbType.NVarChar)).Value = procedureContext.SSASInstanceConfig;
                        command.Parameters.Add(new SqlParameter("@databaseName", SqlDbType.NVarChar)).Value = procedureContext.DatabaseName;
                        command.Parameters.Add(new SqlParameter("@cubeName", SqlDbType.NVarChar)).Value = procedureContext.CubeName;
                        command.Parameters.Add(new SqlParameter("@cubeMetadata", SqlDbType.NVarChar)).Value = procedureContext.CubeMetadata; 
                        command.Parameters.Add(new SqlParameter("@clearCacheMode", SqlDbType.NVarChar)).Value = procedureContext.ClearCacheMode;
                        command.Parameters.Add(new SqlParameter("@statement", SqlDbType.NVarChar)).Value = procedureContext.Statement;
                        command.Parameters.Add(new SqlParameter("@asqaServerVersion", SqlDbType.NVarChar)).Value = procedureContext.ASQAServerVersion;
                        command.Parameters.Add(new SqlParameter("@asqaServerConfig", SqlDbType.NVarChar)).Value = procedureContext.ASQAServerConfig;
                        command.Parameters.Add(new SqlParameter("@clientVersion", SqlDbType.NVarChar)).Value = procedureContext.ClientVersion;
                        command.Parameters.Add(new SqlParameter("@clientType", SqlDbType.NVarChar)).Value = procedureContext.ClientType;
                        command.Parameters.Add(new SqlParameter("@systemOperativeSystemName", SqlDbType.NVarChar)).Value = procedureContext.SystemOperativeSystemName;
                        command.Parameters.Add(new SqlParameter("@systemPhysicalMemory", SqlDbType.BigInt)).Value = procedureContext.SystemPhysicalMemory;
                        command.Parameters.Add(new SqlParameter("@systemLogicalCpuCore", SqlDbType.Int)).Value = procedureContext.SystemLogicalCpuCore;                        
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void Finalize(ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            var updateCommand = @"UPDATE [asqa].[Execution] SET [ExecutionEndTime] = @executionEndTime WHERE [BatchID] = CAST(@batchID AS UNIQUEIDENTIFIER) AND [ExecutionID] = CAST(@executionID AS UNIQUEIDENTIFIER)";

            using (procedureContext.ImpersonationIdentity.Impersonate())
            {
                using (var connection = new SqlConnection(procedureContext.BatchConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(updateCommand, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@batchID", SqlDbType.UniqueIdentifier)).Value = procedureContext.BatchID;
                        command.Parameters.Add(new SqlParameter("@executionID", SqlDbType.UniqueIdentifier)).Value = procedureContext.ExecutionID;
                        command.Parameters.Add(new SqlParameter("@executionEndTime", SqlDbType.DateTime)).Value = DateTime.UtcNow;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void TraceException(ProcedureContext procedureContext, Exception exception)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            if (exception == null)
                throw new ArgumentNullException("exception");

            #endregion

            var updateCommand = @"UPDATE [asqa].[Execution] SET [ExecutionError] = @executionError WHERE [BatchID] = CAST(@batchID AS UNIQUEIDENTIFIER) AND [ExecutionID] = CAST(@executionID AS UNIQUEIDENTIFIER)";

            using (procedureContext.ImpersonationIdentity.Impersonate())
            {
                using (var connection = new SqlConnection(procedureContext.BatchConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(updateCommand, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@batchID", SqlDbType.UniqueIdentifier)).Value = procedureContext.BatchID;
                        command.Parameters.Add(new SqlParameter("@executionID", SqlDbType.UniqueIdentifier)).Value = procedureContext.ExecutionID;
                        command.Parameters.Add(new SqlParameter("@executionError", SqlDbType.NVarChar)).Value = exception.ToString();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void WriteToServer(this List<PerformanceAggregate> aggreagates, ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (aggreagates == null)
                throw new ArgumentNullException("aggreagates");

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            // TODO: LINQ to IDataReader, avoid DataTables
            foreach (var table in aggreagates.ToDataTables(executeForPrepare: false))
            {
                using (table)
                {
                    if (procedureContext.IsCancellationRequested)
                        break;

                    if (table.Rows.Count == 0)
                        continue;

                    table.Columns.Add(new DataColumn("ExecutionID", typeof(Guid)) { DefaultValue = procedureContext.ExecutionID });
                    table.Columns.Add(new DataColumn("CategoryName", typeof(string)) { DefaultValue = table.Namespace.Split(':').Last() });
                    table.Columns.Add(new DataColumn("CounterName", typeof(string)) { DefaultValue = table.TableName });

                    WriteToServer(procedureContext, table, PerformanceTableName);
                }
            }
        }

        public static void Calculate(ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            Func<string, string> loadResource = (name) =>
            {
                using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                using (var reader = new StreamReader(stream))
                    return reader.ReadToEnd();
            };

            const string BatchCalculateCommonEnginePerformance = "SSASQueryAnalyzer.Server.Resources.SSASQueryAnalyzerDatabaseBatchCalculateCommonEnginePerformance.sql";
            const string BatchCalculateCommonAggregationsRead = "SSASQueryAnalyzer.Server.Resources.SSASQueryAnalyzerDatabaseBatchCalculateCommonAggregationsRead.sql";
            const string BatchCalculateCommonPartitionsRead = "SSASQueryAnalyzer.Server.Resources.SSASQueryAnalyzerDatabaseBatchCalculateCommonPartitionsRead.sql";
            const string BatchCalculateCommonCachesRead = "SSASQueryAnalyzer.Server.Resources.SSASQueryAnalyzerDatabaseBatchCalculateCommonCachesRead.sql";

            using (procedureContext.ImpersonationIdentity.Impersonate())
            {
                using (var connection = new SqlConnection(procedureContext.BatchConnectionString))
                {
                    connection.Open();

                    if (procedureContext.IsCancellationRequested)
                        return;

                    using (var command = new SqlCommand(loadResource(BatchCalculateCommonEnginePerformance), connection))
                    {
                        command.CommandTimeout = CalculateTimeout;
                        command.Parameters.Add(new SqlParameter("@executionID", SqlDbType.UniqueIdentifier)).Value = procedureContext.ExecutionID;
                        command.ExecuteNonQuery();
                    }

                    if (procedureContext.IsCancellationRequested)
                        return;

                    using (var command = new SqlCommand(loadResource(BatchCalculateCommonAggregationsRead), connection))
                    {
                        command.CommandTimeout = CalculateTimeout;
                        command.Parameters.Add(new SqlParameter("@executionID", SqlDbType.UniqueIdentifier)).Value = procedureContext.ExecutionID;
                        command.ExecuteNonQuery();
                    }

                    if (procedureContext.IsCancellationRequested)
                        return;

                    using (var command = new SqlCommand(loadResource(BatchCalculateCommonPartitionsRead), connection))
                    {
                        command.CommandTimeout = CalculateTimeout;
                        command.Parameters.Add(new SqlParameter("@executionID", SqlDbType.UniqueIdentifier)).Value = procedureContext.ExecutionID;
                        command.ExecuteNonQuery();
                    }

                    if (procedureContext.IsCancellationRequested)
                        return;

                    using (var command = new SqlCommand(loadResource(BatchCalculateCommonCachesRead), connection))
                    {
                        command.CommandTimeout = CalculateTimeout;
                        command.Parameters.Add(new SqlParameter("@executionID", SqlDbType.UniqueIdentifier)).Value = procedureContext.ExecutionID;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

/*
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));

            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            return table;
        }
*/
    }
}
