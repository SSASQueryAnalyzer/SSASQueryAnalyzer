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

namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Properties;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public partial class ResultPresenterQueryResultControl : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        public ResultPresenterQueryResultControl()
        {
            InitializeComponent();

            InitializeGridSettings();
        }

        public void InitializeGridSettings()
        {
            #region ColdCache Datagrid
            System.Windows.Forms.DataGridViewCellStyle ColumnHeadersCellStyleColdCache = new System.Windows.Forms.DataGridViewCellStyle();
            ColumnHeadersCellStyleColdCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersCellStyleColdCache.SelectionForeColor = System.Drawing.Color.White; 
            
            System.Windows.Forms.DataGridViewCellStyle RowHeadersCellStyleColdCache = new System.Windows.Forms.DataGridViewCellStyle();
            RowHeadersCellStyleColdCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersCellStyleColdCache.SelectionForeColor = System.Drawing.Color.White;

            dataGridViewColdCache.ColumnHeadersDefaultCellStyle = ColumnHeadersCellStyleColdCache;
            dataGridViewColdCache.RowHeadersDefaultCellStyle = RowHeadersCellStyleColdCache;

            dataGridViewColdCache.DefaultCellStyle.SelectionBackColor = Properties.Settings.Default.HighlightColor;
            dataGridViewColdCache.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            dataGridViewColdCache.Dock = DockStyle.Fill;
            dataGridViewColdCache.GridColor = Color.Black;
            dataGridViewColdCache.Location = new Point(4, 4);
            dataGridViewColdCache.Margin = new Padding(4);
            dataGridViewColdCache.Name = "dataGridViewColdCache";
            dataGridViewColdCache.RowHeadersVisible = false;
            dataGridViewColdCache.ColumnHeadersVisible = false;
            dataGridViewColdCache.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridViewColdCache.SelectionMode = DataGridViewSelectionMode.CellSelect;

            #endregion

            #region WarmCache Datagrid

            dataGridViewWarmCache.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            dataGridViewWarmCache.DefaultCellStyle.SelectionBackColor = Properties.Settings.Default.HighlightColor;
            dataGridViewWarmCache.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            dataGridViewWarmCache.Dock = DockStyle.Fill;
            dataGridViewWarmCache.GridColor = Color.Black;
            dataGridViewWarmCache.Location = new Point(4, 4);
            dataGridViewWarmCache.Margin = new Padding(4);
            dataGridViewWarmCache.Name = "dataGridViewWarmCache";
            dataGridViewWarmCache.RowHeadersVisible = false;
            dataGridViewWarmCache.ColumnHeadersVisible = false;
            dataGridViewWarmCache.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridViewWarmCache.SelectionMode = DataGridViewSelectionMode.CellSelect;

            #endregion
        }

        private bool BuildGridView(DataGridView grid, DataTable table)
        {
            bool found = table.ExtendedProperties.ContainsKey("ColumnsHeadersCount") &&
                table.ExtendedProperties.ContainsKey("RowsHeadersCount") &&
                table.ExtendedProperties.ContainsKey("ColumnsOn0Count") &&
                table.ExtendedProperties.ContainsKey("RowsOn1Count") &&
                table.ExtendedProperties.ContainsKey("AxesCount");

            if (!found)
                return false;

            bool rowsFiltered = table.ExtendedProperties.ContainsKey("RowsFiltered");
            pictureBoxMessage.Image = (rowsFiltered) ? SystemIcons.Information.ToBitmap() : SystemIcons.Warning.ToBitmap();
            customLabelMessage.ForeColor = (rowsFiltered) ? Color.Black : Color.Red;
            customLabelMessage.BackColor = (rowsFiltered) ? Color.White : Color.Yellow;

            if (rowsFiltered)
            {
                customLabelMessage.Text = "Number of rows limited to {0} by 'Max rows returned' parameter setting".FormatWith(table.ExtendedProperties["RowsFiltered"]);
                panelMessages.Visible = true;
            }

            int columnsHeaders = Convert.ToInt32(table.ExtendedProperties["ColumnsHeadersCount"]);
            int rowsHeaders = Convert.ToInt32(table.ExtendedProperties["RowsHeadersCount"]);
            int columnsOn0 = Convert.ToInt32(table.ExtendedProperties["ColumnsOn0Count"]); //--> Real number of columns
            int rowsOn1 = Convert.ToInt32(table.ExtendedProperties["RowsOn1Count"]); //--> Real number of rows
            int axesCount = Convert.ToInt32(table.ExtendedProperties["AxesCount"]);

            SendMessage(grid.Handle, /* WM_SETREDRAW */ 11, false, 0);

            Color foreColor = (grid == dataGridViewWarmCache) ? Color.Black : Color.White;

            // Load Columns and format RowHeaders columns
            for (var i = 0; i < rowsHeaders + columnsOn0; i++)
            {
                var column = new DataGridViewTextBoxColumn()
                {
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                if(i < rowsHeaders)
                {
                    column.DefaultCellStyle.SelectionForeColor = column.DefaultCellStyle.ForeColor = foreColor;
                    column.DefaultCellStyle.SelectionBackColor = column.DefaultCellStyle.BackColor = grid == dataGridViewColdCache ? Settings.Default.ColdCacheColor : Settings.Default.WarmCacheColor;
                }
                grid.Columns.Add(column);
            }

            // Load Rows and format ColumnHeaders rows
            int rowIndex;
            foreach (DataRow row in table.Rows)
            {
                rowIndex = grid.Rows.Add(row.ItemArray);
                if (rowIndex < columnsHeaders)
                {
                    grid.Rows[rowIndex].DefaultCellStyle.SelectionForeColor = grid.Rows[rowIndex].DefaultCellStyle.ForeColor = foreColor;
                    grid.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = grid.Rows[rowIndex].DefaultCellStyle.BackColor = grid == dataGridViewColdCache ? Settings.Default.ColdCacheColor : Settings.Default.WarmCacheColor;
                }
            }

            // Clear the top left cells
            if (axesCount == 2)
            {
                for (var rowIdx = 0; rowIdx < columnsHeaders; rowIdx++)
                {
                    for (var colIdx = 0; colIdx < rowsHeaders; colIdx++)
                    {
                        grid.Rows[rowIdx].Cells[colIdx].Style.BackColor = grid.Rows[rowIdx].Cells[colIdx].Style.SelectionBackColor = Color.White;
                        grid.Rows[rowIdx].Cells[colIdx].Style.ForeColor = grid.Rows[rowIdx].Cells[colIdx].Style.SelectionForeColor = Color.White;
                    }
                }
            }



            SendMessage(grid.Handle, /* WM_SETREDRAW */ 11, true, 0);

            return true;
        }

        public void UpdateStatistics(AnalyzerStatistics analyzerStatistics)
        {
            if (!BuildGridView(dataGridViewColdCache, analyzerStatistics.ColdCacheExecutionResult.QueryResults))
                dataGridViewColdCache.DataSource = analyzerStatistics.ColdCacheExecutionResult.QueryResults;

            if (!BuildGridView(dataGridViewWarmCache, analyzerStatistics.WarmCacheExecutionResult.QueryResults))
                dataGridViewWarmCache.DataSource = analyzerStatistics.WarmCacheExecutionResult.QueryResults;
        }

    }
}
