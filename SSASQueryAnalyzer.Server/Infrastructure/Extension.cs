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
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal static class Extension
    {
        public static string GetCubeName(this string statement)
        {
            #region Argument exceptions

            if (statement == null)
                throw new ArgumentNullException(nameof(statement));

            #endregion
            
            var patternFrom = @"(?:\s|\n)(?:FROM)(?:\s|\n)+(?:(?<name>[\w]+)|(?:(?:\[?)(?<name>[\w\s]+)(?:\]?)))";
            //var patternCreateMember = @"(?:\s|\n)*(?:CREATE)(?:\s|\n)+(?:[a-zA-Z]+(?:\s|\n)+)*(?:MEMBER)(?:\s|\n)+(?:(?<name>[\w]+)|(?:(?:\[?)(?<name>[\w\s]+)(?:\]?)))\.";
            //var patternCreateSet = @"(?:\s|\n)*(?:CREATE)(?:\s|\n)+(?:[a-zA-Z]+(?:\s|\n)+)*(?:SET)(?:\s|\n)+(?:(?<name>[\w]+)|(?:(?:\[?)(?<name>[\w\s]+)(?:\]?)))\.";

            var matches = Regex.Matches(statement, patternFrom, RegexOptions.IgnoreCase);

            var match = matches.Cast<Match>().LastOrDefault((m) => m.Success);
            if (match != null)
            {
                var group = match.Groups["name"];
                if (group != null)
                {
                    if (group.Success)
                        return group.Value;
                }
            }

            throw new ApplicationException("Unable to find cube name from input statement");
        }

        public static string FormatWith(this string format, params object[] args)
        {
            #region Argument exceptions

            if (args == null)
                throw new ArgumentNullException("args");
            if (format == null)
                throw new ArgumentNullException("format");

            #endregion

            return string.Format(format, args);
        }

        public static void ValidateStatement(this ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            if (procedureContext.IsCancellationRequested)
                return;

            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepValidateStatement);
            AdomdClientHelper.ExecutePrepare(procedureContext.ConnectionString, procedureContext.Statement);
        }

        public static void ClearCache(this ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException(nameof(procedureContext));

            if (procedureContext.ClearCacheMode == ClearCacheMode.Default)
                throw new ArgumentException("Invalid ClearCacheMode[ClearCacheMode.Default]");

            #endregion

            if (procedureContext.IsCancellationRequested)
                return;
            
            if (procedureContext.ClearCacheMode != ClearCacheMode.Nothing)
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepClearCache);

            if (procedureContext.ClearCacheMode == ClearCacheMode.CurrentCube ||
                procedureContext.ClearCacheMode == ClearCacheMode.CurrentCubeAndFileSystem ||
                procedureContext.ClearCacheMode == ClearCacheMode.CurrentDatabase ||
                procedureContext.ClearCacheMode == ClearCacheMode.CurrentDatabaseAndFileSystem ||
                procedureContext.ClearCacheMode == ClearCacheMode.AllDatabases ||
                procedureContext.ClearCacheMode == ClearCacheMode.AllDatabasesAndFileSystem)
                XmlaHelper.ClearCache(procedureContext);

            if (procedureContext.ClearCacheMode == ClearCacheMode.FileSystemOnly || 
                procedureContext.ClearCacheMode == ClearCacheMode.CurrentCubeAndFileSystem ||
                procedureContext.ClearCacheMode == ClearCacheMode.CurrentDatabaseAndFileSystem ||
                procedureContext.ClearCacheMode == ClearCacheMode.AllDatabasesAndFileSystem)
                FileSystemHelper.ClearFileSystemCache(clearStandbyCache: true);
        }

        /// <summary>
        /// Force reload MDX script code in the cube executing a query that return an empty cellset.
        /// </summary>
        public static void LoadCubeScript(this ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            if (procedureContext.IsCancellationRequested)
                return;

            if (procedureContext.ClearCacheMode != ClearCacheMode.Nothing)
            {
                EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepLoadCubeScript);
                AdomdClientHelper.ExecuteNonQuery(procedureContext.ConnectionString, "SELECT {{}} ON 0 FROM [{0}]".FormatWith(procedureContext.CubeName));
            }
        }

        public static DataTable ToExecutionInfoTable(this ProcedureContext procedureContext)
        {
            #region Argument exception

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            var table = new DataTable("ExecutionInfo", "Common");
            {
                table.Columns.Add("key", typeof(string));
                table.Columns.Add("value", typeof(string));
            }

            if (procedureContext.ExecutionMode == ProcedureExecutionMode.Batch)
            {
                table.Rows.Add("batch_id", procedureContext.BatchID.ToString());
                table.Rows.Add("batch_name", procedureContext.BatchName);
                table.Rows.Add("sql_instance_name", procedureContext.SQLInstanceName);
                table.Rows.Add("sql_instance_version", procedureContext.SQLInstanceVersion);
                table.Rows.Add("sql_instance_edition", procedureContext.SQLInstanceEdition);
            }

            table.Rows.Add("client_version", procedureContext.ClientVersion);
            table.Rows.Add("client_type", procedureContext.ClientType);
            table.Rows.Add("connection_user_name", procedureContext.ConnectionUserName);
            table.Rows.Add("asqa_server_version", procedureContext.ASQAServerVersion);
            table.Rows.Add("asqa_server_config", procedureContext.ASQAServerConfig);
            table.Rows.Add("ssas_instance_name", procedureContext.SSASInstanceName);
            table.Rows.Add("ssas_instance_version", procedureContext.SSASInstanceVersion.ToString());
            table.Rows.Add("ssas_instance_edition", procedureContext.SSASInstanceEdition);
            table.Rows.Add("ssas_instance_config", procedureContext.SSASInstanceConfig);
            table.Rows.Add("statement", procedureContext.Statement);
            table.Rows.Add("database_name", procedureContext.DatabaseName);
            table.Rows.Add("cube_name", procedureContext.CubeName);
            table.Rows.Add("cube_metadata", procedureContext.CubeMetadata);
            table.Rows.Add("system_operative_system_name", procedureContext.SystemOperativeSystemName);
            table.Rows.Add("system_physical_memory", procedureContext.SystemPhysicalMemory);
            table.Rows.Add("system_logical_cpu_core", procedureContext.SystemLogicalCpuCore);

            return table;
        }

        public static DataTable ToVersionTable(this Version version)
        {
            #region Argument exception

            if (version == null)
                throw new ArgumentNullException("version");

            #endregion

            var table = new DataTable("Version");
            {
                table.Columns.Add("AssemblyVersion", typeof(string));
            }

            table.Rows.Add(version.ToString());

            return table;
        }

        public static string ToXmlString(this DataTable table)
        {
            #region Argument exception

            if (table == null)
                throw new ArgumentNullException("table");

            #endregion

            using (var writer = new StringWriter())
            {
                table.WriteXml(writer, XmlWriteMode.WriteSchema);
                return writer.ToString();
            }
        }
    }
}
