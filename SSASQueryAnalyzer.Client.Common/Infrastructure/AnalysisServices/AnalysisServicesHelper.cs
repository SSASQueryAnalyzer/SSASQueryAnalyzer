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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices
{
    using Microsoft.AnalysisServices;
    using Microsoft.AnalysisServices.AdomdClient;
    using System;
    using System.Data;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class AnalysisServicesHelper
    {
        private static int DefaultTimeout = 24 * 60 * 60; //TODO: definire e parametrizzare

        public static Version InstanceVersion(string connectionString)
        {
            using (var server = new Server())
            {
                server.Connect(connectionString);

                return Version.Parse(server.Version);
            }
        }

        public static bool ClrAssemblyInstalled(string connectionString, string assemblyID)
        {
            using (var server = new Server())
            {
                server.Connect(connectionString);

                if (server.Assemblies.Contains(assemblyID))
                    return true;
            }

            return false;
        }

        public static void RegisterClrAssembly(string connectionString, string assemblyID, string assemblyName, string assemblyDescription, string assemblyFilePath)
        {
            #region XMLA Create Assembly

            string commandText = 
                @"<Create AllowOverwrite=""false"" xmlns=""http://schemas.microsoft.com/analysisservices/2003/engine"">
                    <ObjectDefinition>
                        <Assembly xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:ddl2=""http://schemas.microsoft.com/analysisservices/2003/engine/2"" xmlns:ddl2_2=""http://schemas.microsoft.com/analysisservices/2003/engine/2/2"" xmlns:ddl100_100=""http://schemas.microsoft.com/analysisservices/2008/engine/100/100"" xmlns:ddl200=""http://schemas.microsoft.com/analysisservices/2010/engine/200"" xmlns:ddl200_200=""http://schemas.microsoft.com/analysisservices/2010/engine/200/200"" xmlns:ddl300=""http://schemas.microsoft.com/analysisservices/2011/engine/300"" xmlns:ddl300_300=""http://schemas.microsoft.com/analysisservices/2011/engine/300/300"" xmlns:ddl400=""http://schemas.microsoft.com/analysisservices/2012/engine/400"" xmlns:ddl400_400=""http://schemas.microsoft.com/analysisservices/2012/engine/400/400"" xsi:type=""ClrAssembly"">
                            <ID>{0}</ID>
                            <Name>{1}</Name>
                            <Description>{2}</Description>
                            <ImpersonationInfo>
                                <ImpersonationMode>Default</ImpersonationMode>
                            </ImpersonationInfo>
                            <Files>
                                <File>
                                    <Name>{3}</Name>
                                    <Type>Main</Type>
                                    <Data>
                                        <Block>{4}</Block>
                                    </Data>
                                </File>
                            </Files>
                            <PermissionSet>Unrestricted</PermissionSet>
                        </Assembly>
                    </ObjectDefinition>
                </Create>";

            #endregion

            commandText = commandText.FormatWith(
                assemblyID,
                assemblyName,
                assemblyDescription,
                Path.GetFileName(assemblyFilePath),
                Convert.ToBase64String(File.ReadAllBytes(assemblyFilePath))
                );

            ExecuteNonQuery(connectionString, commandText); 
        }

        public static void UnregisterClrAssembly(string connectionString, string assemblyID)
        {
            #region XMLA Delete Assembly

            string commandText =
                @"<Delete xmlns=""http://schemas.microsoft.com/analysisservices/2003/engine"">
                    <Object>
                        <AssemblyID>{0}</AssemblyID>
                    </Object>
                </Delete>";

            #endregion

            commandText = commandText.FormatWith(assemblyID);

            ExecuteNonQuery(connectionString, commandText); 
        }

        public static object ExecuteScalar(string connectionString, string commandText)
        {
            using (var connection = new AdomdConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandTimeout = DefaultTimeout;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return reader.GetValue(0);
                    }

                    return null;
                }
            }
        }

        public static void ExecuteNonQuery(string connectionString, string commandText, CancellationToken cancellationToken = default(CancellationToken))
        {
            Func<IDbCommand, int> function = (command) =>
            {
                return command.ExecuteNonQuery();
            };

            Execute<int>(connectionString, commandText, cancellationToken, function);
        }

        public static void ExecuteForPrepare(string connectionString, string commandText)
        {
            using (var connection = new AdomdConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandTimeout = DefaultTimeout;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Prepare();
                }
            }
        }

        public static DataSet ExecuteForDataSet(string connectionString, string commandText, CancellationToken cancellationToken = default(CancellationToken))
        {
            Func<IDbCommand, DataSet> function = (command) =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return new DataSet();

                    var o = reader.GetValue(0);
                    if (o == null)
                        throw new ApplicationException("Null result");
                    if (!(o is DataSet))
                        throw new ApplicationException("Invalid result type [{0}]".FormatWith(o.GetType()));

                    return o as DataSet;
                }
            };

            return Execute<DataSet>(connectionString, commandText, cancellationToken, function);
        }

        public static DataTable ExecuteForDataTable(string connectionString, string commandText, CancellationToken cancellationToken = default(CancellationToken))
        {
            Func<IDbCommand, DataTable> function = (command) =>
            {
                var table = new DataTable();
                using (var adapter = new AdomdDataAdapter(command as AdomdCommand))
                    adapter.Fill(table);
                return table;
            };

            return Execute<DataTable>(connectionString, commandText, cancellationToken, function);
        }

        private static T Execute<T>(string connectionString, string commandText, CancellationToken cancellationToken, Func<IDbCommand, T> function)
        {
            if (cancellationToken.IsCancellationRequested)
                return default(T);

            using (var connection = new AdomdConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandTimeout = DefaultTimeout;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;

                    using (var task = Task.Factory.StartNew(() => function(command), cancellationToken))
                    {
                        try
                        {
                            task.Wait(cancellationToken);
                        }
                        catch (OperationCanceledException)
                        {
                            command.Cancel();

                            while (!task.IsCompleted)
                                Thread.Sleep(30);
                        }

                        return (T)task.Result;
                    }
                }
            }
        }
    }
}
