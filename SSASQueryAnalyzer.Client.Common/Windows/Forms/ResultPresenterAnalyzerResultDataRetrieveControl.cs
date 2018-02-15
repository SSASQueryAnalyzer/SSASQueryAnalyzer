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
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using SSASQueryAnalyzer.Client.Common.Properties;
    using System.Runtime.InteropServices;

    public partial class ResultPresenterAnalyzerResultDataRetrieveControl : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        private Chart _selectedChart;
        private ContextMenuStrip _chartMenu;
        private ContextMenuStrip _datagridMenu;
        private ToolStripMenuItem _showBoth;
        private ToolStripMenuItem _showOnlyThis;
        private ToolStripMenuItem _resizeBoth;
        private ToolStripMenuItem _showOnTimeline;
        private ToolStripMenuItem _showDetails;
        private ToolStripSeparator _tss;

        private bool _coldZeroAggregationsRead;
        private bool _warmZeroAggregationsRead;
        private bool _coldZeroPartitionsRead;
        private bool _warmZeroPartitionsRead;
        private bool _coldZeroCachesRead;
        private bool _warmZeroCachesRead;
        private int _coldTotalAggregationsCounter;
        private int _warmTotalAggregationsCounter;
        private int _coldTotalPartitionsCounter;
        private int _warmTotalPartitionsCounter;
        private int _coldTotalCachesCounter;
        private int _warmTotalCachesCounter;

        private ResultPresenterAnalyzerResultTimelineControl _selectedTimelineControl;
        private ResultPresenterAnalyzerResultTimelineControl.TimelineHelper _selectedCacheHelper;
        private ResultPresenterControl _selectedPresenterControl;
        private Chart _selectedTimelineChart;
        private ToolStripMenuItem _selectedMenuItem;
        private ToolStripMenuItem _uncheckMenuItem;
        private CustomTabControlControl _selectedTabControl;
        private CustomDataGridViewControl _selectedGrid;
        private string _keyColumnName;
        private DataPoint _selectedDataPoint;
        private List<string> _entityNames = new List<string>();

        private int CurrentTotalCounter
        {
            get
            {
                int currentTotalCounter = 0;

                switch (tabControlDetails.SelectedTab.Text)
                {
                    case "Partitions":
                        _selectedTabControl = tabControlDetailsPartitions;
                        switch (_selectedTabControl.SelectedTab.Text)
                        {
                            case "Cold Cache":
                                currentTotalCounter = _coldTotalPartitionsCounter;
                                break;
                            case "Warm Cache":
                                currentTotalCounter = _warmTotalPartitionsCounter;
                                break;
                        }
                        break;
                    case "Aggregations":
                        _selectedTabControl = tabControlDetailsAggregations;
                        switch (_selectedTabControl.SelectedTab.Text)
                        {
                            case "Cold Cache":
                                currentTotalCounter = _coldTotalAggregationsCounter;
                                break;
                            case "Warm Cache":
                                currentTotalCounter = _warmTotalAggregationsCounter;
                                break;
                        }
                        break;
                    case "Caches":
                        _selectedTabControl = tabControlDetailsCaches;
                        switch (_selectedTabControl.SelectedTab.Text)
                        {
                            case "Cold Cache":
                                currentTotalCounter = _coldTotalCachesCounter;
                                break;
                            case "Warm Cache":
                                currentTotalCounter = _warmTotalCachesCounter;
                                break;
                        }
                        break;
                }

                return currentTotalCounter;

                throw new ApplicationException("Invalid type for CurrentTotalCounter");
            }
        }

        private CustomDataGridViewControl CurrentDataGridView
        {
            get
            {
                CustomDataGridViewControl currentDataGridView = null;

                switch (tabControlDetails.SelectedTab.Text)
                {
                    case "Partitions":
                        _selectedTabControl = tabControlDetailsPartitions;
                        switch (_selectedTabControl.SelectedTab.Text)
                        {
                            case "Cold Cache":
                                currentDataGridView = dataGridViewDetailsPartitionsColdCache;
                                break;
                            case "Warm Cache":
                                currentDataGridView = dataGridViewDetailsPartitionsWarmCache;
                                break;
                        }
                        break;
                    case "Aggregations":
                        _selectedTabControl = tabControlDetailsAggregations;
                        switch (_selectedTabControl.SelectedTab.Text)
                        {
                            case "Cold Cache":
                                currentDataGridView = dataGridViewDetailsAggregationsColdCache;
                                break;
                            case "Warm Cache":
                                currentDataGridView = dataGridViewDetailsAggregationsWarmCache;
                                break;
                        }
                        break;
                    case "Caches":
                        _selectedTabControl = tabControlDetailsCaches;
                        switch (_selectedTabControl.SelectedTab.Text)
                        {
                            case "Cold Cache":
                                currentDataGridView = dataGridViewDetailsCachesColdCache;
                                break;
                            case "Warm Cache":
                                currentDataGridView = dataGridViewDetailsCachesWarmCache;
                                break;
                        }
                        break;
                }

                return currentDataGridView;

                throw new ApplicationException("Invalid type for CurrentDataGridView");
            }
        }       

        public ResultPresenterAnalyzerResultDataRetrieveControl()
        {
            InitializeComponent();

            InitializeGlobalComponents();
            InitializePartitionsComponents();

            InitializeGridSettings(dataGridViewDetailsCachesColdCache, dataGridViewDetailsCachesWarmCache);
            InitializeGridSettings(dataGridViewDetailsAggregationsColdCache, dataGridViewDetailsAggregationsWarmCache);
            InitializeGridSettings(dataGridViewDetailsPartitionsColdCache, dataGridViewDetailsPartitionsWarmCache);

            InitializeChartSettings();
        }

        public void InitializeChartSettings()
        {
            #region ColdCache Chart

            chartColdCache.Series.Clear();

            var seriesColdCache = new Series();
            var dataPointColdCache01 = new DataPoint(0D, 3D);
            var dataPointColdCache02 = new DataPoint(0D, 4D);
            var dataPointColdCache03 = new DataPoint(0D, 1D);
            var dataPointColdCache04 = new DataPoint(0D, 3D);
            var dataPointColdCache05 = new DataPoint(0D, 2D);
            var dataPointColdCache06 = new DataPoint(0D, 1D);
            var dataPointColdCache07 = new DataPoint(0D, 2D);
            var dataPointColdCache08 = new DataPoint(0D, 3D);

            #region Data Points settings

            dataPointColdCache01.AxisLabel = "Calculation Cache - Global Scope";
            dataPointColdCache01.BorderColor = Settings.Default.ColdCacheColor;
            dataPointColdCache01.Color = Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache01.IsValueShownAsLabel = true;
            dataPointColdCache01.Label = "#VAL";
            dataPointColdCache01.LegendText = "Calculation Cache - Global Scope";
            dataPointColdCache02.AxisLabel = "Calculation Cache - Session Scope";
            dataPointColdCache02.BorderColor = Settings.Default.ColdCacheColor;
            dataPointColdCache02.Color = SystemColors.Window;
            dataPointColdCache02.IsValueShownAsLabel = true;
            dataPointColdCache02.Label = "#VAL";
            dataPointColdCache02.LegendText = "Calculation Cache - Session Scope";
            dataPointColdCache03.AxisLabel = "Calculation Cache - Query Scope";
            dataPointColdCache03.BorderColor = Settings.Default.ColdCacheColor;
            dataPointColdCache03.Color = Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache03.IsValueShownAsLabel = true;
            dataPointColdCache03.Label = "#VAL";
            dataPointColdCache03.LegendText = "Calculation Cache - Query Scope";
            dataPointColdCache04.AxisLabel = "Measure Group Cache";
            dataPointColdCache04.BorderColor = Settings.Default.ColdCacheColor;
            dataPointColdCache04.Color = SystemColors.Window;
            dataPointColdCache04.IsValueShownAsLabel = true;
            dataPointColdCache04.Label = "#VAL";
            dataPointColdCache04.LegendText = "Measure Group Cache";
            dataPointColdCache05.AxisLabel = "Persisted Cache";
            dataPointColdCache05.BorderColor = Settings.Default.ColdCacheColor;
            dataPointColdCache05.Color = Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache05.IsValueShownAsLabel = true;
            dataPointColdCache05.Label = "#VAL";
            dataPointColdCache05.LegendText = "Persisted Cache";
            dataPointColdCache06.AxisLabel = "Flat Cache";
            dataPointColdCache06.BorderColor = Settings.Default.ColdCacheColor;
            dataPointColdCache06.Color = SystemColors.Window;
            dataPointColdCache06.IsValueShownAsLabel = true;
            dataPointColdCache06.Label = "#VAL";
            dataPointColdCache06.LegendText = "Flat Cache";
            dataPointColdCache07.AxisLabel = "Aggregations";
            dataPointColdCache07.BorderColor = Settings.Default.ColdCacheColor;
            dataPointColdCache07.Color = Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache07.IsValueShownAsLabel = true;
            dataPointColdCache07.Label = "#VAL";
            dataPointColdCache07.LegendText = "Aggregations";
            dataPointColdCache08.AxisLabel = "Partitions";
            dataPointColdCache08.BorderColor = Settings.Default.ColdCacheColor;
            dataPointColdCache08.Color = SystemColors.Window;
            dataPointColdCache08.IsValueShownAsLabel = true;
            dataPointColdCache08.Label = "#VAL";
            dataPointColdCache08.LegendText = "Partitions";

            #endregion

            #region Serie settings

            seriesColdCache.ChartArea = "chartAreaColdCache";
            seriesColdCache.IsValueShownAsLabel = true;
            seriesColdCache.Label = "#VAL";
            seriesColdCache.LegendText = "#LEGENDTEXT";
            seriesColdCache.Name = "chartSerieColdCache";
            seriesColdCache.Points.Add(dataPointColdCache01);
            seriesColdCache.Points.Add(dataPointColdCache02);
            seriesColdCache.Points.Add(dataPointColdCache03);
            seriesColdCache.Points.Add(dataPointColdCache04);
            seriesColdCache.Points.Add(dataPointColdCache05);
            seriesColdCache.Points.Add(dataPointColdCache06);
            seriesColdCache.Points.Add(dataPointColdCache07);
            seriesColdCache.Points.Add(dataPointColdCache08);

            chartColdCache.Series.Add(seriesColdCache);

            #endregion

            #endregion

            #region WarmCache Chart

            chartWarmCache.Series.Clear();

            var seriesWarmCache = new Series();
            var dataPointWarmCache01 = new DataPoint(0D, 3D);
            var dataPointWarmCache02 = new DataPoint(0D, 4D);
            var dataPointWarmCache03 = new DataPoint(0D, 1D);
            var dataPointWarmCache04 = new DataPoint(0D, 3D);
            var dataPointWarmCache05 = new DataPoint(0D, 2D);
            var dataPointWarmCache06 = new DataPoint(0D, 1D);
            var dataPointWarmCache07 = new DataPoint(0D, 2D);
            var dataPointWarmCache08 = new DataPoint(0D, 3D);

            #region Data Points settings

            dataPointWarmCache01.AxisLabel = "Calculation Cache - Global Scope";
            dataPointWarmCache01.BorderColor = Settings.Default.WarmCacheColor;
            dataPointWarmCache01.Color = Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache01.IsValueShownAsLabel = true;
            dataPointWarmCache01.Label = "#VAL";
            dataPointWarmCache01.LegendText = "Calculation Cache - Global Scope";
            dataPointWarmCache02.AxisLabel = "Calculation Cache - Session Scope";
            dataPointWarmCache02.BorderColor = Settings.Default.WarmCacheColor;
            dataPointWarmCache02.Color = SystemColors.Window;
            dataPointWarmCache02.IsValueShownAsLabel = true;
            dataPointWarmCache02.Label = "#VAL";
            dataPointWarmCache02.LegendText = "Calculation Cache - Session Scope";
            dataPointWarmCache03.AxisLabel = "Calculation Cache - Query Scope";
            dataPointWarmCache03.BorderColor = Settings.Default.WarmCacheColor;
            dataPointWarmCache03.Color = Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache03.IsValueShownAsLabel = true;
            dataPointWarmCache03.Label = "#VAL";
            dataPointWarmCache03.LegendText = "Calculation Cache - Query Scope";
            dataPointWarmCache04.AxisLabel = "Measure Group Cache";
            dataPointWarmCache04.BorderColor = Settings.Default.WarmCacheColor;
            dataPointWarmCache04.Color = SystemColors.Window;
            dataPointWarmCache04.IsValueShownAsLabel = true;
            dataPointWarmCache04.Label = "#VAL";
            dataPointWarmCache04.LegendText = "Measure Group Cache";
            dataPointWarmCache05.AxisLabel = "Persisted Cache";
            dataPointWarmCache05.BorderColor = Settings.Default.WarmCacheColor;
            dataPointWarmCache05.Color = Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache05.IsValueShownAsLabel = true;
            dataPointWarmCache05.Label = "#VAL";
            dataPointWarmCache05.LegendText = "Persisted Cache";
            dataPointWarmCache06.AxisLabel = "Flat Cache";
            dataPointWarmCache06.BorderColor = Settings.Default.WarmCacheColor;
            dataPointWarmCache06.Color = SystemColors.Window;
            dataPointWarmCache06.IsValueShownAsLabel = true;
            dataPointWarmCache06.Label = "#VAL";
            dataPointWarmCache06.LegendText = "Flat Cache";
            dataPointWarmCache07.AxisLabel = "Aggregations";
            dataPointWarmCache07.BorderColor = Settings.Default.WarmCacheColor;
            dataPointWarmCache07.Color = Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache07.IsValueShownAsLabel = true;
            dataPointWarmCache07.Label = "#VAL";
            dataPointWarmCache07.LegendText = "Aggregations";
            dataPointWarmCache08.AxisLabel = "Partitions";
            dataPointWarmCache08.BorderColor = Settings.Default.WarmCacheColor;
            dataPointWarmCache08.Color = SystemColors.Window;
            dataPointWarmCache08.IsValueShownAsLabel = true;
            dataPointWarmCache08.Label = "#VAL";
            dataPointWarmCache08.LegendText = "Partitions";

            #endregion

            #region Serie settings

            seriesWarmCache.ChartArea = "chartAreaWarmCache";
            seriesWarmCache.IsValueShownAsLabel = true;
            seriesWarmCache.Label = "#VAL";
            seriesWarmCache.LegendText = "#LEGENDTEXT";
            seriesWarmCache.Name = "chartSerieWarmCache";
            seriesWarmCache.Points.Add(dataPointWarmCache01);
            seriesWarmCache.Points.Add(dataPointWarmCache02);
            seriesWarmCache.Points.Add(dataPointWarmCache03);
            seriesWarmCache.Points.Add(dataPointWarmCache04);
            seriesWarmCache.Points.Add(dataPointWarmCache05);
            seriesWarmCache.Points.Add(dataPointWarmCache06);
            seriesWarmCache.Points.Add(dataPointWarmCache07);
            seriesWarmCache.Points.Add(dataPointWarmCache08);

            chartWarmCache.Series.Add(seriesWarmCache);

            #endregion

            #endregion
        }

        public void InitializeGridSettings(DataGridView dataGridViewColdCache, DataGridView dataGridViewWarmCache)
        {
            #region ColdCache Datagrid

            System.Windows.Forms.DataGridViewCellStyle ColumnHeadersCellStyleColdCache = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle CellStyleColdCache = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle RowHeadersCellStyleColdCache = new System.Windows.Forms.DataGridViewCellStyle();

            #region Column Headers template

            ColumnHeadersCellStyleColdCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersCellStyleColdCache.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ColumnHeadersCellStyleColdCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ColumnHeadersCellStyleColdCache.BackColor = Properties.Settings.Default.ColdCacheColor;
            ColumnHeadersCellStyleColdCache.ForeColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersCellStyleColdCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersCellStyleColdCache.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region Row Headers template

            RowHeadersCellStyleColdCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            RowHeadersCellStyleColdCache.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            RowHeadersCellStyleColdCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RowHeadersCellStyleColdCache.BackColor = Properties.Settings.Default.ColdCacheColor;
            RowHeadersCellStyleColdCache.ForeColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersCellStyleColdCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersCellStyleColdCache.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region Cells template

            CellStyleColdCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            CellStyleColdCache.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            CellStyleColdCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CellStyleColdCache.BackColor = System.Drawing.SystemColors.Window;
            CellStyleColdCache.ForeColor = System.Drawing.Color.Black;
            CellStyleColdCache.SelectionBackColor = Properties.Settings.Default.HighlightColor;
            CellStyleColdCache.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region Data Grid View settings

            dataGridViewColdCache.ColumnHeadersDefaultCellStyle = ColumnHeadersCellStyleColdCache;
            dataGridViewColdCache.DefaultCellStyle = CellStyleColdCache;
            dataGridViewColdCache.RowHeadersDefaultCellStyle = RowHeadersCellStyleColdCache;

            dataGridViewColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewColdCache.GridColor = System.Drawing.Color.Black;
            dataGridViewColdCache.Location = new System.Drawing.Point(4, 4);
            dataGridViewColdCache.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewColdCache.Name = "dataGridViewColdCache";
            dataGridViewColdCache.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewColdCache.RowHeadersVisible = false;
            dataGridViewColdCache.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewColdCache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            #endregion

            #endregion

            #region WarmCache Datagrid

            System.Windows.Forms.DataGridViewCellStyle ColumnHeadersCellStyleWarmCache = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle CellStyleWarmCache = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle RowHeadersCellStyleWarmCache = new System.Windows.Forms.DataGridViewCellStyle();

            #region Column Headers template

            ColumnHeadersCellStyleWarmCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersCellStyleWarmCache.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ColumnHeadersCellStyleWarmCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ColumnHeadersCellStyleWarmCache.BackColor = Properties.Settings.Default.WarmCacheColor;
            ColumnHeadersCellStyleWarmCache.ForeColor = System.Drawing.Color.Black;
            ColumnHeadersCellStyleWarmCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersCellStyleWarmCache.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region Row Headers template

            RowHeadersCellStyleWarmCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            RowHeadersCellStyleWarmCache.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            RowHeadersCellStyleWarmCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RowHeadersCellStyleWarmCache.BackColor = Properties.Settings.Default.WarmCacheColor;
            RowHeadersCellStyleWarmCache.ForeColor = System.Drawing.Color.Black;
            RowHeadersCellStyleWarmCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersCellStyleWarmCache.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region Cells template

            CellStyleWarmCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            CellStyleWarmCache.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            CellStyleWarmCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CellStyleWarmCache.BackColor = System.Drawing.SystemColors.Window;
            CellStyleWarmCache.ForeColor = System.Drawing.Color.Black;
            CellStyleWarmCache.SelectionBackColor = Properties.Settings.Default.HighlightColor;
            CellStyleWarmCache.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region Data Grid View settings

            dataGridViewWarmCache.ColumnHeadersDefaultCellStyle = ColumnHeadersCellStyleWarmCache;
            dataGridViewWarmCache.DefaultCellStyle = CellStyleWarmCache;
            dataGridViewWarmCache.RowHeadersDefaultCellStyle = RowHeadersCellStyleWarmCache;

            dataGridViewWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewWarmCache.GridColor = System.Drawing.Color.Black;
            dataGridViewWarmCache.Location = new System.Drawing.Point(4, 4);
            dataGridViewWarmCache.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewWarmCache.Name = "dataGridViewWarmCache";
            dataGridViewWarmCache.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewWarmCache.RowHeadersVisible = false;
            dataGridViewWarmCache.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewWarmCache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            #endregion

            #endregion
        }

        private void InitializeGlobalComponents()
        {
           // TODO: sistemare le proprietà impostandole a design time
            gaugeLabelWarmCacheUncertain.cacheFillColor = Settings.Default.WarmCacheColor;
            gaugeLabelWarmCacheUncertain.cacheBorderColor = CustomColor.ObjectsBorderColor;
            gaugeLabelWarmCacheMixed.cacheFillColor = Settings.Default.WarmCacheColor;
            gaugeLabelWarmCacheMixed.cacheBorderColor = CustomColor.ObjectsBorderColor;
            gaugeLabelWarmCacheCellByCell.cacheFillColor = Settings.Default.WarmCacheColor;
            gaugeLabelWarmCacheCellByCell.cacheBorderColor = CustomColor.ObjectsBorderColor;
            gaugeLabelWarmCacheBlock.cacheFillColor = Settings.Default.WarmCacheColor;
            gaugeLabelWarmCacheBlock.cacheBorderColor = CustomColor.ObjectsBorderColor;

            gaugeLabelColdCacheUncertain.cacheFillColor = Settings.Default.ColdCacheColor;
            gaugeLabelColdCacheUncertain.cacheBorderColor = CustomColor.ObjectsBorderColor;
            gaugeLabelColdCacheMixed.cacheFillColor = Settings.Default.ColdCacheColor;
            gaugeLabelColdCacheMixed.cacheBorderColor = CustomColor.ObjectsBorderColor;
            gaugeLabelColdCacheCellByCell.cacheFillColor = Settings.Default.ColdCacheColor;
            gaugeLabelColdCacheCellByCell.cacheBorderColor = CustomColor.ObjectsBorderColor;
            gaugeLabelColdCacheBlock.cacheFillColor = Settings.Default.ColdCacheColor;
            gaugeLabelColdCacheBlock.cacheBorderColor = CustomColor.ObjectsBorderColor;
        }

        private void InitializePartitionsComponents()
        {
            splitContainerPartitionsColdCache.SplitterDistance = splitContainerPartitionsColdCache.Width / 2;
            splitContainerPartitionsWarmCache.SplitterDistance = splitContainerPartitionsWarmCache.Width / 2;
        }

        private void InitializeContextMenuStrips()
        {
            #region Debug
            Debug.Assert(chartColdCache.ContextMenuStrip == null);
            Debug.Assert(chartWarmCache.ContextMenuStrip == null);
            Debug.Assert(dataGridViewDetailsAggregationsColdCache.ContextMenuStrip == null);
            Debug.Assert(dataGridViewDetailsAggregationsWarmCache.ContextMenuStrip == null);
            Debug.Assert(dataGridViewDetailsCachesColdCache.ContextMenuStrip == null);
            Debug.Assert(dataGridViewDetailsCachesWarmCache.ContextMenuStrip == null);
            Debug.Assert(dataGridViewDetailsPartitionsColdCache.ContextMenuStrip == null);
            Debug.Assert(dataGridViewDetailsPartitionsWarmCache.ContextMenuStrip == null);
            #endregion

            #region Charts menu

            _chartMenu = new ContextMenuStrip();

            _showDetails = new ToolStripMenuItem("Show Details");
            _showDetails.Click += (s, e) => ShowDetails();
            _showDetails.Checked = false;
            _showDetails.Visible = true;
            _chartMenu.Items.Add(_showDetails);

            _tss = new ToolStripSeparator();
            _tss.Visible = true;
            _chartMenu.Items.Add(_tss);

            _showBoth = new ToolStripMenuItem("Show both charts");
            _showBoth.Click += (object sender, EventArgs e) =>
            {
                splitContainerGlobal.SplitterDistance = splitContainerGlobal.Width / 2;
                splitContainerGlobal.Panel1Collapsed = false;
                splitContainerGlobal.Panel2Collapsed = false;
                _showBoth.Checked = false;
                _showBoth.Visible = false;
                _showOnlyThis.Visible = true;
                _resizeBoth.Visible = true;
            };
            _showBoth.Checked = false;
            _showBoth.Visible = false;
            _chartMenu.Items.Add(_showBoth);

            _showOnlyThis = new ToolStripMenuItem("Show only this chart");
            _showOnlyThis.Click += (object sender, EventArgs e) =>
            {
                if (_selectedChart == chartColdCache)
                {
                    splitContainerGlobal.Panel1Collapsed = false;
                    splitContainerGlobal.Panel2Collapsed = true;
                }
                else if (_selectedChart == chartWarmCache)
                {
                    splitContainerGlobal.Panel1Collapsed = true;
                    splitContainerGlobal.Panel2Collapsed = false;
                }
                _showOnlyThis.Checked = false;
                _showOnlyThis.Visible = false;
                _showBoth.Visible = true;
                _resizeBoth.Visible = false;
            };
            _showOnlyThis.Checked = false;
            _showOnlyThis.Visible = true;
            _chartMenu.Items.Add(_showOnlyThis);

            _resizeBoth = new ToolStripMenuItem("Resize both charts");
            _resizeBoth.Click += (object sender, EventArgs e) =>
            {
                splitContainerGlobal.SplitterDistance = splitContainerGlobal.Width / 2;
                splitContainerGlobal.Panel1Collapsed = false;
                splitContainerGlobal.Panel2Collapsed = false;
                _resizeBoth.Checked = false;
            };
            _resizeBoth.Checked = false;
            _resizeBoth.Visible = true;
            _chartMenu.Items.Add(_resizeBoth);

            chartColdCache.ContextMenuStrip = _chartMenu;
            chartWarmCache.ContextMenuStrip = _chartMenu;

            #endregion

            #region Datagrid menu

            _showOnTimeline = new ToolStripMenuItem("Show on Timeline");
            _showOnTimeline.Click += (s, e) => ShowEventsInTimeline();
            _showOnTimeline.Checked = false;
            _showOnTimeline.Visible = true;

            _datagridMenu = new ContextMenuStrip();
            _datagridMenu.Items.Add(_showOnTimeline);
            _datagridMenu.Opening += (s, e) => { _showOnTimeline.Enabled = _selectedMenuItem != null; };

            dataGridViewDetailsAggregationsColdCache.ContextMenuStrip = _datagridMenu;
            dataGridViewDetailsAggregationsWarmCache.ContextMenuStrip = _datagridMenu;
            dataGridViewDetailsCachesColdCache.ContextMenuStrip = _datagridMenu;
            dataGridViewDetailsCachesWarmCache.ContextMenuStrip = _datagridMenu;
            dataGridViewDetailsPartitionsColdCache.ContextMenuStrip = _datagridMenu;
            dataGridViewDetailsPartitionsWarmCache.ContextMenuStrip = _datagridMenu;

            #endregion
        }

        private void ShowDetails()
        {
            if (_selectedDataPoint != null)
            {
                string pageLabel = _selectedDataPoint.AxisLabel;
                if (_selectedDataPoint.AxisLabel.Contains("Cache"))
                    pageLabel = "Caches";

                var page = tabControlDetails.TabPages.Cast<TabPage>()
                    .Where((p) => p.Text.Equals(pageLabel))
                    .SingleOrDefault();

                if (page != null)
                {
                    if (_selectedChart == chartWarmCache)
                    {
                        tabControlDetailsAggregations.SelectTab(tabPageDetailsAggregationsWarmCache);
                        tabControlDetailsPartitions.SelectTab(tabPageDetailsPartitionsWarmCache);
                        tabControlDetailsCaches.SelectTab(tabPageDetailsCachesWarmCache);
                    }
                    else if (_selectedChart == chartColdCache)
                    {
                        tabControlDetailsAggregations.SelectTab(tabPageDetailsAggregationsColdCache);
                        tabControlDetailsPartitions.SelectTab(tabPageDetailsPartitionsColdCache);
                        tabControlDetailsCaches.SelectTab(tabPageDetailsCachesColdCache);
                    }

                    tabControlDetails.SelectTab(page);

                    if (pageLabel == "Caches")
                    {
                        #region Debug
                        Debug.Assert(_selectedGrid == dataGridViewDetailsCachesColdCache || _selectedGrid == dataGridViewDetailsCachesWarmCache);
                        #endregion

                        SelectGridCells(_selectedDataPoint.AxisLabel);
                   }
                }
            }
        }

        private void SelectGridCells(string textToCompare)
        {
            _selectedGrid.SuspendLayout();
            _selectedGrid.SelectionChanged -= dataGridView_SelectionChanged;
            _selectedGrid.ClearSelection();
            _selectedGrid.CurrentCell = null;
            _selectedGrid.FirstDisplayedScrollingRowIndex = 0;
            SendMessage(_selectedGrid.Handle, WM_SETREDRAW, false, 0);

            foreach (DataGridViewRow row in _selectedGrid.Rows)
            {
                if (row.Cells[_keyColumnName].Value.ToString() == textToCompare)
                {
                    if (_selectedGrid.FirstDisplayedScrollingRowIndex == 0)
                        _selectedGrid.FirstDisplayedScrollingRowIndex = row.Index;

                    row.Selected = true;
                }
            }

            SendMessage(_selectedGrid.Handle, WM_SETREDRAW, true, 0);
            _selectedGrid.Refresh();
            _selectedGrid.SelectionChanged += dataGridView_SelectionChanged;
            dataGridView_SelectionChanged(_selectedGrid, null);
            _selectedGrid.ResumeLayout();
        }

        public void UpdateStatistics(AnalyzerStatistics analyzerStatistics)
        {
           
            panelMessageExternal.Visible = false;
            pictureBoxMessage.Image = SystemIcons.Information.ToBitmap();

            labelColdCacheTotalRead.Text = "Total read: {0}".FormatWith(analyzerStatistics.DataRetrieveColdCacheTotalRead);
            labelWarmCacheTotalRead.Text = "Total read: {0}".FormatWith(analyzerStatistics.DataRetrieveWarmCacheTotalRead);

            #region Cold cache computation type

            gaugeLabelColdCacheBlock.State = CustomGaugeLabelState.Off;
            gaugeLabelColdCacheMixed.State = CustomGaugeLabelState.Off;
            gaugeLabelColdCacheUncertain.State = CustomGaugeLabelState.Off;
            gaugeLabelColdCacheCellByCell.State = CustomGaugeLabelState.Off;

            switch (analyzerStatistics.DataRetrieveColdCacheCalculationComputationType)
            {
                case AnalyzerStatistics.CalculationComputationType.Block:
                    gaugeLabelColdCacheBlock.State = CustomGaugeLabelState.Signaled;
                    break;
                case AnalyzerStatistics.CalculationComputationType.CellByCell:
                    gaugeLabelColdCacheCellByCell.State = CustomGaugeLabelState.Unsignaled;
                    break;
                case AnalyzerStatistics.CalculationComputationType.Mixed:
                    gaugeLabelColdCacheMixed.State = CustomGaugeLabelState.Mixed;
                    break;
                case AnalyzerStatistics.CalculationComputationType.Uncertain:
                default:
                    gaugeLabelColdCacheUncertain.State = CustomGaugeLabelState.Unsignaled;
                    break;
            }

            #endregion

            #region Warm cache computation type

            gaugeLabelWarmCacheMixed.State = CustomGaugeLabelState.Off;
            gaugeLabelWarmCacheBlock.State = CustomGaugeLabelState.Off;
            gaugeLabelWarmCacheCellByCell.State = CustomGaugeLabelState.Off;

            switch (analyzerStatistics.DataRetrieveWarmCacheCalculationComputationType)
            {
                case AnalyzerStatistics.CalculationComputationType.Block:
                    gaugeLabelWarmCacheBlock.State = CustomGaugeLabelState.Signaled;
                    break;
                case AnalyzerStatistics.CalculationComputationType.CellByCell:
                    gaugeLabelWarmCacheCellByCell.State = CustomGaugeLabelState.Unsignaled;
                    break;
                case AnalyzerStatistics.CalculationComputationType.Mixed:
                    gaugeLabelWarmCacheMixed.State = CustomGaugeLabelState.Mixed;
                    break;
                case AnalyzerStatistics.CalculationComputationType.Uncertain:
                default:
                    gaugeLabelWarmCacheUncertain.State = CustomGaugeLabelState.Unsignaled;
                    break;
            }

            #endregion

            #region assert
            Debug.Assert(chartColdCache.Series.Count == 1);
            Debug.Assert(chartColdCache.Series[0].Points.Count == 8);
            Debug.Assert(chartColdCache.Series[0].Points[0].LegendText == "Calculation Cache - Global Scope");
            Debug.Assert(chartColdCache.Series[0].Points[1].LegendText == "Calculation Cache - Session Scope");
            Debug.Assert(chartColdCache.Series[0].Points[2].LegendText == "Calculation Cache - Query Scope");
            Debug.Assert(chartColdCache.Series[0].Points[3].LegendText == "Measure Group Cache");
            Debug.Assert(chartColdCache.Series[0].Points[4].LegendText == "Persisted Cache");
            Debug.Assert(chartColdCache.Series[0].Points[5].LegendText == "Flat Cache");
            Debug.Assert(chartColdCache.Series[0].Points[6].LegendText == "Aggregations");
            Debug.Assert(chartColdCache.Series[0].Points[7].LegendText == "Partitions");
            #endregion
            var coldCacheSerie = chartColdCache.Series[0];
            {
                coldCacheSerie.Points[0].SetValueY(analyzerStatistics.DataRetrieveColdCacheCalculationCacheGlobalScopeRead);
                coldCacheSerie.Points[1].SetValueY(analyzerStatistics.DataRetrieveColdCacheCalculationCacheSessionScopeRead);
                coldCacheSerie.Points[2].SetValueY(analyzerStatistics.DataRetrieveColdCacheCalculationCacheQueryScopeRead);
                coldCacheSerie.Points[3].SetValueY(analyzerStatistics.DataRetrieveColdCacheMeasureGroupCacheRead);
                coldCacheSerie.Points[4].SetValueY(analyzerStatistics.DataRetrieveColdCachePersistedCacheRead);
                coldCacheSerie.Points[5].SetValueY(analyzerStatistics.DataRetrieveColdCacheFlatCacheRead);

                var read = analyzerStatistics.DataRetrieveColdCacheAggregationsRead;
                var hit = analyzerStatistics.DataRetrieveColdCacheAggregationsHit;
                coldCacheSerie.Points[6].SetValueY(read);
                if (read != hit)
                    coldCacheSerie.Points[6].Label = "{0} - [Hits {1}]".FormatWith(read, hit);

                read = analyzerStatistics.DataRetrieveColdCachePartitionsRead;
                hit = analyzerStatistics.DataRetrieveColdCachePartitionsHit;
                coldCacheSerie.Points[7].SetValueY(read);
                if (read != hit)
                    coldCacheSerie.Points[7].Label = "{0} - [Hits {1}]".FormatWith(read, hit);
            }

            #region assert
            Debug.Assert(chartWarmCache.Series.Count == 1);
            Debug.Assert(chartWarmCache.Series[0].Points.Count == 8);
            Debug.Assert(chartWarmCache.Series[0].Points[0].LegendText == "Calculation Cache - Global Scope");
            Debug.Assert(chartWarmCache.Series[0].Points[1].LegendText == "Calculation Cache - Session Scope");
            Debug.Assert(chartWarmCache.Series[0].Points[2].LegendText == "Calculation Cache - Query Scope");
            Debug.Assert(chartWarmCache.Series[0].Points[3].LegendText == "Measure Group Cache");
            Debug.Assert(chartWarmCache.Series[0].Points[4].LegendText == "Persisted Cache");
            Debug.Assert(chartWarmCache.Series[0].Points[5].LegendText == "Flat Cache");
            Debug.Assert(chartWarmCache.Series[0].Points[6].LegendText == "Aggregations");
            Debug.Assert(chartWarmCache.Series[0].Points[7].LegendText == "Partitions");
            #endregion
            var warmCacheSerie = chartWarmCache.Series[0];
            {
                warmCacheSerie.Points[0].SetValueY(analyzerStatistics.DataRetrieveWarmCacheCalculationCacheGlobalScopeRead);
                warmCacheSerie.Points[1].SetValueY(analyzerStatistics.DataRetrieveWarmCacheCalculationCacheSessionScopeRead);
                warmCacheSerie.Points[2].SetValueY(analyzerStatistics.DataRetrieveWarmCacheCalculationCacheQueryScopeRead);
                warmCacheSerie.Points[3].SetValueY(analyzerStatistics.DataRetrieveWarmCacheMeasureGroupCacheRead);
                warmCacheSerie.Points[4].SetValueY(analyzerStatistics.DataRetrieveWarmCachePersistedCacheRead);
                warmCacheSerie.Points[5].SetValueY(analyzerStatistics.DataRetrieveWarmCacheFlatCacheRead);

                var read = analyzerStatistics.DataRetrieveWarmCacheAggregationsRead;
                var hit = analyzerStatistics.DataRetrieveWarmCacheAggregationsHit;
                warmCacheSerie.Points[6].SetValueY(read);
                if (read != hit)
                    warmCacheSerie.Points[6].Label = "{0} - [Hits {1}]".FormatWith(read, hit);

                read = analyzerStatistics.DataRetrieveWarmCachePartitionsRead;
                hit = analyzerStatistics.DataRetrieveWarmCachePartitionsHit;
                warmCacheSerie.Points[7].SetValueY(read);
                if (read != hit)
                    warmCacheSerie.Points[7].Label = "{0} - [Hits {1}]".FormatWith(read, hit);
            }

            foreach (var chart in new[] { chartColdCache, chartWarmCache })
            {
                var serie = chart.Series[0];

                foreach (var point in serie.Points)
                {
                    if (point.YValues.Single() == 0D)
                        point.IsEmpty = true;

                    if (point.IsEmpty)
                        point.Label = " ";
                }

                if (serie.Points.All((p) => p.IsEmpty))
                    chart.ChartAreas[0].Axes[1].IsLogarithmic = false;
            }

            #region Aggregations

            dataGridViewDetailsAggregationsColdCache.DataSource = analyzerStatistics.ColdCacheExecutionResult.AggregationsReads.ToSortableBindingList();
            dataGridViewDetailsAggregationsColdCache.Columns["AggregationDurationRatio"].DefaultCellStyle.Format = @"0.00\%";
            _coldTotalAggregationsCounter = analyzerStatistics.ColdCacheExecutionResult.AggregationsReads.ToSortableBindingList().Count;
            _coldZeroAggregationsRead = _coldTotalAggregationsCounter == 0;
            dataGridViewDetailsAggregationsColdCache.Visible = !_coldZeroAggregationsRead;

            dataGridViewDetailsAggregationsWarmCache.DataSource = analyzerStatistics.WarmCacheExecutionResult.AggregationsReads.ToSortableBindingList();
            _warmTotalAggregationsCounter = analyzerStatistics.WarmCacheExecutionResult.AggregationsReads.ToSortableBindingList().Count;
            _warmZeroAggregationsRead = _warmTotalAggregationsCounter == 0;
            dataGridViewDetailsAggregationsWarmCache.Visible = !_warmZeroAggregationsRead;

            #endregion

            #region Partitions

            dataGridViewDetailsPartitionsColdCache.DataSource = analyzerStatistics.ColdCacheExecutionResult.PartitionsReads.ToSortableBindingList();
            dataGridViewDetailsPartitionsColdCache.Columns["PartitionDurationRatio"].DefaultCellStyle.Format = @"0.00\%";
            _coldTotalPartitionsCounter = analyzerStatistics.ColdCacheExecutionResult.PartitionsReads.ToSortableBindingList().Count;
            _coldZeroPartitionsRead = _coldTotalPartitionsCounter == 0;
            dataGridViewDetailsPartitionsColdCache.Visible = !_coldZeroPartitionsRead;
            int transparentStep = 0;
            int alpha = 255;

            if (!_coldZeroPartitionsRead)
            {
                transparentStep = (255 / analyzerStatistics.ColdCacheExecutionResult.PartitionsReads.ToSortableBindingList().Count);
                Color coldBaseColor = Settings.Default.ColdCacheColor;
                foreach (var partitionRead in analyzerStatistics.ColdCacheExecutionResult.PartitionsReads)
                {
                    var point = chartPartitionsColdCache.Series[0].Points.Add();
                    point.Color = Color.FromArgb(alpha, coldBaseColor.R, coldBaseColor.G, coldBaseColor.B);
                    point.BorderColor = Settings.Default.ColdCacheColor;
                    point.BorderWidth = 1;
                    point.SetValueY(partitionRead.PartitionDurationRatio);
                    point.Label = "#PERCENT{P}";
                    point.LabelFormat = "";
                    point.LegendText = partitionRead.PartitionName;
                    alpha = (byte)(alpha - transparentStep);
                }
            }

            chartPartitionsColdCache.Visible = !_coldZeroPartitionsRead;

            dataGridViewDetailsPartitionsWarmCache.DataSource = analyzerStatistics.WarmCacheExecutionResult.PartitionsReads.ToSortableBindingList();
            _warmTotalPartitionsCounter = analyzerStatistics.WarmCacheExecutionResult.PartitionsReads.ToSortableBindingList().Count;
            _warmZeroPartitionsRead = _warmTotalPartitionsCounter == 0;
            dataGridViewDetailsPartitionsWarmCache.Visible = !_warmZeroPartitionsRead;
            transparentStep = 0;
            alpha = 255;

            if (!_warmZeroPartitionsRead)
            {
                transparentStep = (255 / analyzerStatistics.WarmCacheExecutionResult.PartitionsReads.ToSortableBindingList().Count);
                Color warmBaseColor = Settings.Default.WarmCacheColor;
                foreach (var partitionRead in analyzerStatistics.WarmCacheExecutionResult.PartitionsReads)
                {
                    var point = chartPartitionsWarmCache.Series[0].Points.Add();
                    point.Color = Color.FromArgb(alpha, warmBaseColor.R, warmBaseColor.G, warmBaseColor.B);
                    point.BorderColor = Settings.Default.WarmCacheColor;
                    point.BorderWidth = 1;
                    point.SetValueY(partitionRead.PartitionDurationRatio);
                    point.Label = "#PERCENT{P}";
                    point.LabelFormat = "";
                    point.LegendText = partitionRead.PartitionName;
                    alpha = (byte)(alpha - transparentStep);
                }
            }

            chartPartitionsWarmCache.Visible = !_warmZeroPartitionsRead;

            #endregion

            #region Caches

            dataGridViewDetailsCachesColdCache.DataSource = analyzerStatistics.ColdCacheExecutionResult.CachesReads.ToSortableBindingList();
            _coldTotalCachesCounter = analyzerStatistics.ColdCacheExecutionResult.CachesReads.ToSortableBindingList().Count;
            _coldZeroCachesRead = _coldTotalCachesCounter == 0;
            dataGridViewDetailsCachesColdCache.Visible = !_coldZeroCachesRead;

            dataGridViewDetailsCachesWarmCache.DataSource = analyzerStatistics.WarmCacheExecutionResult.CachesReads.ToSortableBindingList();
            _warmTotalCachesCounter = analyzerStatistics.WarmCacheExecutionResult.CachesReads.ToSortableBindingList().Count;
            _warmZeroCachesRead = _warmTotalCachesCounter == 0;
            dataGridViewDetailsCachesWarmCache.Visible = !_warmZeroCachesRead;

            #endregion

            InitializeContextMenuStrips();
        }

        private void DeselectAllDataPoints(DataPointCollection dpc)
        {
            foreach (DataPoint point in dpc)
            {
                if (point.Color == Settings.Default.HighlightColor)
                    point.Color = point.BackSecondaryColor;

                point.BackSecondaryColor = Color.White;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }
        }

        private void DeselectSingleDataPoint(DataPoint dp)
        {
            if (dp.Color == Settings.Default.HighlightColor)
                dp.Color = dp.BackSecondaryColor;

            dp.BackSecondaryColor = Color.White;
            dp.BackHatchStyle = ChartHatchStyle.None;
            dp.BorderWidth = 1;
        }

        private void SelectSingleDataPoint(DataPoint dp)
        {
            dp.BackSecondaryColor = dp.Color;
            dp.Color = Settings.Default.HighlightColor;
            dp.BorderWidth = 2;
        }

        private void OnPartitionGridViewSelectionChanged(object sender, EventArgs e)
        {
            Chart chart = null;

            if (sender == dataGridViewDetailsPartitionsColdCache)
                chart = chartPartitionsColdCache;
            else if (sender == dataGridViewDetailsPartitionsWarmCache)
                chart = chartPartitionsWarmCache;

            foreach (var point in chart.Series[0].Points)
            {
                DeselectSingleDataPoint(point);

                foreach (DataGridViewRow row in ((DataGridView)sender).SelectedRows)
                {
                    if (row.Cells["PartitionName"].Value.ToString() == point.LegendText)
                        SelectSingleDataPoint(point);
                }
            }

            RefreshSelectedObjects();
            UpdateLabelMessage();
            RefreshEntityNamesList();
        }

        private void OnChartMouseMove(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var hit = chart.HitTest(e.X, e.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                var point = chart.Series[0].Points[hit.PointIndex];
                if (_selectedDataPoint == null || point != _selectedDataPoint)
                {
                    if (_selectedDataPoint != null)
                        DeselectSingleDataPoint(_selectedDataPoint);

                    SelectSingleDataPoint(point);
                    _selectedDataPoint = point;
                }
            }
            else
            {
                if (hit.ChartElementType != ChartElementType.DataPointLabel)
                {
                    if (_selectedDataPoint != null)
                        DeselectSingleDataPoint(_selectedDataPoint);

                    _selectedDataPoint = null;
                }
            }
        }

        private void OnPartitionChartMouseMove(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var hit = chart.HitTest(e.X, e.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                var point = chart.Series[0].Points[hit.PointIndex];
                if (_selectedDataPoint == null || point != _selectedDataPoint)
                {
                    if (_selectedDataPoint != null)
                        DeselectSingleDataPoint(_selectedDataPoint);

                    SelectSingleDataPoint(point);
                    _selectedDataPoint = point;

                    #region Debug
                    Debug.Assert(_selectedGrid == dataGridViewDetailsPartitionsColdCache || _selectedGrid == dataGridViewDetailsPartitionsWarmCache);
                    #endregion

                    SelectGridCells(point.LegendText);
               }
            }
        }

        private void OnChartMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            _selectedChart = (Chart)sender;
            _showDetails.Visible = _selectedDataPoint != null;
            _tss.Visible = _selectedDataPoint != null;
        }

        private void RefreshSelectedObjects()
        {
            if (tabControlDetails.SelectedTab.Text == "Global")
                return;

            Debug.Assert(
                            (tabControlDetails.SelectedTab.Text == "Partitions") ||
                            (tabControlDetails.SelectedTab.Text == "Aggregations") ||
                            (tabControlDetails.SelectedTab.Text == "Caches")
                        );

            _selectedPresenterControl = this.GetResultPresenterControl();
            _selectedTimelineControl = _selectedPresenterControl.AnalyzerResultControl.TimelineControl;

            switch (tabControlDetails.SelectedTab.Text)
            {
                case "Partitions":
                    _selectedTabControl = tabControlDetailsPartitions;
                    _keyColumnName = "PartitionName";
                    switch (_selectedTabControl.SelectedTab.Text)
                    {
                        case "Cold Cache":
                            _selectedGrid = dataGridViewDetailsPartitionsColdCache;
                            _selectedTimelineChart = _selectedTimelineControl.chartCold;
                            _selectedCacheHelper = _selectedTimelineControl.ColdTimelineHelper;
                            _selectedMenuItem = _selectedCacheHelper._partitionsMenuItem;
                            _uncheckMenuItem = _selectedCacheHelper._uncheckAllPartitions;
                            break;
                        case "Warm Cache":
                            _selectedGrid = dataGridViewDetailsPartitionsWarmCache;
                            _selectedTimelineChart = _selectedTimelineControl.chartWarm;
                            _selectedCacheHelper = _selectedTimelineControl.WarmTimelineHelper;
                            _selectedMenuItem = _selectedCacheHelper._partitionsMenuItem;
                            _uncheckMenuItem = _selectedCacheHelper._uncheckAllPartitions;
                            break;
                    }
                    break;
                case "Aggregations":
                    _selectedTabControl = tabControlDetailsAggregations;
                    _keyColumnName = "AggregationID";
                    switch (_selectedTabControl.SelectedTab.Text)
                    {
                        case "Cold Cache":
                            _selectedGrid = dataGridViewDetailsAggregationsColdCache;
                            _selectedTimelineChart = _selectedTimelineControl.chartCold;
                            _selectedCacheHelper = _selectedTimelineControl.ColdTimelineHelper;
                            _selectedMenuItem = _selectedCacheHelper._aggregationsMenuItem;
                            _uncheckMenuItem = _selectedCacheHelper._uncheckAllAggregations;
                            break;
                        case "Warm Cache":
                            _selectedGrid = dataGridViewDetailsAggregationsWarmCache;
                            _selectedTimelineChart = _selectedTimelineControl.chartWarm;
                            _selectedCacheHelper = _selectedTimelineControl.WarmTimelineHelper;
                            _selectedMenuItem = _selectedCacheHelper._aggregationsMenuItem;
                            _uncheckMenuItem = _selectedCacheHelper._uncheckAllAggregations;
                            break;
                    }
                    break;
                case "Caches":
                    _selectedTabControl = tabControlDetailsCaches;
                    _keyColumnName = "CacheType";
                    switch (_selectedTabControl.SelectedTab.Text)
                    {
                        case "Cold Cache":
                            _selectedGrid = dataGridViewDetailsCachesColdCache;
                            _selectedTimelineChart = _selectedTimelineControl.chartCold;
                            _selectedCacheHelper = _selectedTimelineControl.ColdTimelineHelper;
                            _selectedMenuItem = _selectedCacheHelper._cachesMenuItem;
                            _uncheckMenuItem = _selectedCacheHelper._uncheckAllCaches;
                            break;
                        case "Warm Cache":
                            _selectedGrid = dataGridViewDetailsCachesWarmCache;
                            _selectedTimelineChart = _selectedTimelineControl.chartWarm;
                            _selectedCacheHelper = _selectedTimelineControl.WarmTimelineHelper;
                            _selectedMenuItem = _selectedCacheHelper._cachesMenuItem;
                            _uncheckMenuItem = _selectedCacheHelper._uncheckAllCaches;
                            break;
                    }
                    break;
            }

        }

        private void RefreshEntityNamesList()
        {
            _entityNames.Clear();

            for (int i = 0; i < _selectedGrid.SelectedCells.Count; i++)
            {
                var row = _selectedGrid.Rows[_selectedGrid.SelectedCells[i].RowIndex];
                var cell = row.Cells[_keyColumnName];

                if (!_entityNames.Contains(cell.Value.ToString()))
                    _entityNames.Add(cell.Value.ToString());
            }
        }

        private void ShowEventsInTimeline()
        {
            if (_selectedTabControl == null || _selectedPresenterControl == null)
                return;

            if (_selectedTimelineChart != null)
            {
                if (_selectedCacheHelper.ZoomMode)
                {
                    using (var resetTimelineZoomConfirmationForm = new ResetTimelineZoomConfirmationForm())
                    {
                        if (resetTimelineZoomConfirmationForm.ShowDialog() == DialogResult.No)
                            return;
                    }

                    _selectedCacheHelper.ResetZoomMode();
                }

                // Clear all menu sub items
                _selectedCacheHelper.ContextMenuItemPerformClick(_uncheckMenuItem, true);

                // Click on menu sub items corrisponding to the selected entity
                foreach (string name in _entityNames)
                {
                    foreach (ToolStripItem item in _selectedMenuItem.DropDownItems)
                    {
                        if (item.Name == name)
                        {
                            item.PerformClick();
                            break;
                        }
                    }
                }
            }

            _selectedPresenterControl.AnalyzerResultControl.SelectTabPageIndex(5);
        }

        private void splitContainer_Paint(object sender, PaintEventArgs e)
        {
            tableLayoutPanelCold.Refresh();
        }

        private void UpdateLabelMessage()
        {
            panelMessageExternal.Visible = true;
            switch (tabControlDetails.SelectedTab.Text)
            {
                case "Global": 
                    panelMessageExternal.Visible = false;
                    break;
                case "Partitions":
                case "Aggregations":
                case "Caches":
                    panelMessageExternal.SuspendLayout();
                    string labelText = "Total {0}: {1} - Selected {0}: {2}";
                    if (CurrentTotalCounter == 0)
                    {
                        labelText = "No {0} read!";
                        customLabelMessage.Text = labelText.FormatWith(tabControlDetails.SelectedTab.Text);
                    }
                    else
                    {
                        customLabelMessage.Text = labelText.FormatWith(
                                                                        tabControlDetails.SelectedTab.Text,
                                                                        CurrentTotalCounter.ToString(),
                                                                        CurrentDataGridView.SelectedRows.Count.ToString()
                                                                      );
                    }
                    panelMessageExternal.ResumeLayout();
                    break;
            }
        }
        
        private void customTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSelectedObjects();
            UpdateLabelMessage();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            RefreshSelectedObjects(); 
            UpdateLabelMessage();
            RefreshEntityNamesList();
        }
    }
}
