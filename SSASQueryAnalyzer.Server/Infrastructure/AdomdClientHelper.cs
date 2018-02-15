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
    using System.Threading;
    using System.Threading.Tasks;
    using AdomdClient = Microsoft.AnalysisServices.AdomdClient;

    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://thinknook.com/kill-a-session-spid-or-connection-to-analysis-service-cube-2012-09-21/"/>
    internal static class AdomdClientHelper
    {
        private static int DefaultTimeout = 24 * 60 * 60; //TODO: definire e parametrizzare

        public static void ExecuteNonQuery(string connectionString, string commandText)
        {
            #region Argument exceptions

            if (commandText == null)
                throw new ArgumentNullException("commandText");
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            #endregion

            using (var connection = new AdomdClient.AdomdConnection(connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandTimeout = DefaultTimeout;
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ExecutePrepare(string connectionString, string commandText)
        {
            #region Argument exceptions

            if (commandText == null)
                throw new ArgumentNullException("commandText");
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            #endregion

            using (var connection = new AdomdClient.AdomdConnection(connectionString))
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

        public static object ExecuteScalar(AdomdClient.AdomdConnection connection, string commandText)
        {
            #region Argument exceptions

            if (commandText == null)
                throw new ArgumentNullException("commandText");
            if (connection == null)
                throw new ArgumentNullException("connection");

            #endregion

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

        public static object ExecuteScalar(string connectionString, string commandText)
        {
            #region Argument exceptions

            if (commandText == null)
                throw new ArgumentNullException("commandText");
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            #endregion

            using (var connection = new AdomdClient.AdomdConnection(connectionString))
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

        private static void CellsetToDataTable(AdomdClient.CellSet cellset, DataTable table, int rowsLimit)
        {
            #region Argument exception
            
            if (table == null)
                throw new ArgumentNullException("table");

            if (cellset == null)
                throw new ArgumentNullException("cellset");

            if (rowsLimit < 0)
                throw new ArgumentOutOfRangeException("rowsLimit");

            #endregion

            if (rowsLimit == 0)
                return;

            int columnsHeaders = 0;
            int rowsHeaders = 0;
            int columnsOn0 = 0;
            int rowsOn1 = 0;

            if (cellset.Axes.Count == 0)
            {
                #region Axes.Count == 0

                columnsHeaders = 0;
                rowsHeaders = 0;
                columnsOn0 = cellset.FilterAxis.Positions.Count;
                rowsOn1 = 1;

                for (int i = 0; i < columnsOn0; i++)
                    table.Columns.Add();

                var values = new object[columnsOn0];

                for (int i = 0; i < columnsOn0; i++)
                    values[i] = cellset[i].Value;

                table.Rows.Add(values);

                #endregion
            }
            else if (cellset.Axes.Count == 1)
            {
                #region Axes.Count == 1

                if (cellset.Axes[0].Positions.Count == 0 )
                    return;

                columnsHeaders = cellset.Axes[0].Positions[0].Members.Count;
                rowsHeaders = 0;
                columnsOn0 = cellset.Axes[0].Positions.Count;
                rowsOn1 = 1;

                int rowCount = rowsOn1 + columnsHeaders;
                int columnCount = columnsOn0 + rowsHeaders;

                for (int i = 0; i < columnCount; i++)
                    table.Columns.Add();

                for (int rowIdx = 0; rowIdx < rowCount; rowIdx++)
                {
                    var values = new object[columnCount];

                    for (int columnIdx = 0; columnIdx < columnCount; columnIdx++)
                    {
                        if (rowIdx < columnsHeaders)
                        {
                            values[columnIdx] = cellset.Axes[0].Positions[columnIdx - rowsHeaders].Members[rowIdx].Caption;
                        }
                        else
                        {
                            var value = cellset[columnIdx - rowsHeaders].Value;
                            if (value != null)
                                values[columnIdx] = value;
                        }
                    }

                    table.Rows.Add(values);
                }

                #endregion
            }
            else if (cellset.Axes.Count == 2)
            {
                #region Axes.Count == 2

                if (cellset.Axes[0].Positions.Count == 0 || cellset.Axes[1].Positions.Count == 0)
                    return; // No data returned for the selection

                // number of dimensions on the column
                columnsHeaders = cellset.Axes[0].Positions[0].Members.Count;
                // number of dimensions on the row
                rowsHeaders = cellset.Axes[1].Positions[0].Members.Count;

                // number of columns on Axes[0] --> excluding columns for row headers
                columnsOn0 = cellset.Axes[0].Positions.Count;
                // number of rows on Axes[1] --> excluding rows for column headers
                rowsOn1 = cellset.Axes[1].Positions.Count;

                if (rowsOn1 > rowsLimit)
                {
                    rowsOn1 = rowsLimit;
                    table.ExtendedProperties.Add("RowsFiltered", rowsLimit);
                }

                // total rows and columns
                int rowCount = rowsOn1 + columnsHeaders;  // number of rows + rows for column headers
                int columnCount = columnsOn0 + rowsHeaders;  // number of columns + columns for row headers

                for (int i = 0; i < columnCount; i++)
                    table.Columns.Add();

                for (int rowIdx = 0; rowIdx < rowCount; rowIdx++)
                {
                    var values = new object[columnCount];

                    for (int columnIdx = 0; columnIdx < columnCount; columnIdx++)
                    {
                        // check if we are writing to a ROW having column header 
                        if (rowIdx < columnsHeaders)
                        {
                            // check if we are writing to a cell having row header
                            if (columnIdx < rowsHeaders)
                                // this should be empty cell -- it's on top left of the grid
                                values[columnIdx] = string.Empty;
                            else
                                // this is a column header cell -- use member caption for header
                                values[columnIdx] = cellset.Axes[0].Positions[columnIdx - rowsHeaders].Members[rowIdx].Caption;
                        }
                        // we are here.. so we are writing a row having data (not column headers), check if we are writing to a cell having row header
                        else if (columnIdx < rowsHeaders)
                        {
                            // this is a row header cell -- use member caption for header
                            values[columnIdx] = cellset.Axes[1].Positions[rowIdx - columnsHeaders].Members[columnIdx].Caption;
                        }
                        else
                        {
                            // this is data cell.. so we write the Formatted value of the cell.
                            var value = cellset[columnIdx - rowsHeaders, rowIdx - columnsHeaders].Value;
                            if (value != null)
                                values[columnIdx] = value;
                        }
                    }

                    table.Rows.Add(values);
                };

                #endregion
            }
            else
            {
                throw new ApplicationException("Queries with more than two axes are not supported [" + cellset.Axes.Count + "]");
            }

            table.ExtendedProperties.Add("ColumnsHeadersCount", columnsHeaders);
            table.ExtendedProperties.Add("RowsHeadersCount", rowsHeaders);
            table.ExtendedProperties.Add("ColumnsOn0Count", columnsOn0);
            table.ExtendedProperties.Add("RowsOn1Count", rowsOn1);
            table.ExtendedProperties.Add("AxesCount", cellset.Axes.Count);
        }

        public static DataTable ExecuteDataTable(string connectionString, string commandText)
        {
            #region Argument exceptions

            if (commandText == null)
                throw new ArgumentNullException("commandText");
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            #endregion

            using (var connection = new AdomdClient.AdomdConnection(connectionString))
            {
                connection.Open();

                return ExecuteDataTable(connection, CancellationToken.None, commandText);
            }
        }

        public static DataTable ExecuteDataTable(AdomdClient.AdomdConnection connection, CancellationToken cancellationToken, string commandText, Guid activityID = default(Guid), int rowsLimit = Int32.MaxValue, Action beforeStart = null, Action beforeWait = null)
        {
#region Argument exceptions

            if (connection == null)
                throw new ArgumentNullException("connection");
            if (commandText == null)
                throw new ArgumentNullException("commandText");
            if (cancellationToken == null)
                throw new ArgumentNullException("cancellationToken");

#endregion
            
            var table = new DataTable();
            
            using (var command = connection.CreateCommand())
            {
                command.CommandTimeout = DefaultTimeout;
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;

                if (activityID != Guid.Empty)
                    command.ActivityID = activityID;

                beforeStart?.Invoke();

                using (var task = Task.Factory.StartNew(() =>
                {
                    if (rowsLimit == 0)
                        command.ExecuteNonQuery();
                    else
                        CellsetToDataTable(command.ExecuteCellSet(), table, rowsLimit);

                    return table;

                    //using (var adapter = new AdomdClient.AdomdDataAdapter(command))
                    //    adapter.Fill(table);
                    //return table;
                }, 
                cancellationToken, TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent, TaskScheduler.Default))
                {
                    try
                    {
                        beforeWait?.Invoke();

                        task.Wait(cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        command.Cancel();

                        while (!task.IsCompleted)
                            Thread.Sleep(50);

                        throw;
                    }
                    finally
                    {
                        table = task.Result;
                    }
                }
            }

            return table;
        }
    }
}
