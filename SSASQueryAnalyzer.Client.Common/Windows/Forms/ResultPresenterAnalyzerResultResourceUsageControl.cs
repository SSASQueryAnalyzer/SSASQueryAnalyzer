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
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Drawing;

    public partial class ResultPresenterAnalyzerResultResourceUsageControl : UserControl
    {
        Chart _selectedChart;
        ContextMenuStrip _menu;

        private ToolStripMenuItem _showBoth;
        private ToolStripMenuItem _showOnlyThis;
        private ToolStripMenuItem _resizeBoth;

        public ResultPresenterAnalyzerResultResourceUsageControl()
        {
            InitializeComponent();

            InitializeChartSettings();
        }

        public void InitializeChartSettings()
        {
            #region ColdCache Chart

            chartColdCache.Series.Clear();

            System.Windows.Forms.DataVisualization.Charting.Series seriesColdCache = new System.Windows.Forms.DataVisualization.Charting.Series();

            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache01 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache02 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 4D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache03 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache04 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache05 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache06 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache07 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);

            #region Data Points settings

            dataPointColdCache01.AxisLabel = "Reads";
            dataPointColdCache01.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache01.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache01.Label = "#VAL{N0}";
            dataPointColdCache01.LegendText = "Reads";

            dataPointColdCache02.AxisLabel = "Read KB";
            dataPointColdCache02.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache02.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache02.Label = "#VAL{N0}";
            dataPointColdCache02.LegendText = "Read KB";

            dataPointColdCache03.AxisLabel = "Writes";
            dataPointColdCache03.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache03.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache03.Label = "#VAL{N0}";
            dataPointColdCache03.LegendText = "Writes";

            dataPointColdCache04.AxisLabel = "Write KB";
            dataPointColdCache04.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache04.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache04.Label = "#VAL{N0}";
            dataPointColdCache04.LegendText = "Write KB";

            dataPointColdCache05.AxisLabel = "CPU Time MS";
            dataPointColdCache05.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache05.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache05.Label = "#VAL{N0}";
            dataPointColdCache05.LegendText = "CPU Time MS";

            dataPointColdCache06.AxisLabel = "Rows Scanned";
            dataPointColdCache06.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache06.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache06.Label = "#VAL{N0}";
            dataPointColdCache06.LegendText = "Rows Scanned";

            dataPointColdCache07.AxisLabel = "Rows Returned";
            dataPointColdCache07.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache07.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache07.Label = "#VAL{N0}";
            dataPointColdCache07.LegendText = "Rows Returned";

            #endregion

            #region Serie settings

            seriesColdCache.ChartArea = "chartAreaColdCache";
            seriesColdCache.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            seriesColdCache.LegendText = "#LABEL";
            seriesColdCache.Name = "chartSerieColdCache";

            seriesColdCache.Points.Add(dataPointColdCache01);
            seriesColdCache.Points.Add(dataPointColdCache02);
            seriesColdCache.Points.Add(dataPointColdCache03);
            seriesColdCache.Points.Add(dataPointColdCache04);
            seriesColdCache.Points.Add(dataPointColdCache05);
            seriesColdCache.Points.Add(dataPointColdCache06);
            seriesColdCache.Points.Add(dataPointColdCache07);

            chartColdCache.Series.Add(seriesColdCache);

            #endregion

            #endregion

            #region WarmCache Chart

            chartWarmCache.Series.Clear();

            System.Windows.Forms.DataVisualization.Charting.Series seriesWarmCache = new System.Windows.Forms.DataVisualization.Charting.Series();

            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache01 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache02 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 4D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache03 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache04 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache05 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache06 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache07 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);

            #region Data Points settings

            dataPointWarmCache01.AxisLabel = "Reads";
            dataPointWarmCache01.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache01.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache01.Label = "#VAL{N0}";
            dataPointWarmCache01.LegendText = "Reads";

            dataPointWarmCache02.AxisLabel = "Read KB";
            dataPointWarmCache02.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache02.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache02.Label = "#VAL{N0}";
            dataPointWarmCache02.LegendText = "Read KB";

            dataPointWarmCache03.AxisLabel = "Writes";
            dataPointWarmCache03.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache03.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache03.Label = "#VAL{N0}";
            dataPointWarmCache03.LegendText = "Writes";

            dataPointWarmCache04.AxisLabel = "Write KB";
            dataPointWarmCache04.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache04.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache04.Label = "#VAL{N0}";
            dataPointWarmCache04.LabelForeColor = System.Drawing.Color.Black;
            dataPointWarmCache04.LegendText = "Write KB";

            dataPointWarmCache05.AxisLabel = "CPU Time MS";
            dataPointWarmCache05.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache05.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache05.Label = "#VAL{N0}";
            dataPointWarmCache05.LegendText = "CPU Time MS";

            dataPointWarmCache06.AxisLabel = "Rows Scanned";
            dataPointWarmCache06.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache06.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache06.Label = "#VAL{N0}";
            dataPointWarmCache06.LegendText = "Rows Scanned";

            dataPointWarmCache07.AxisLabel = "Rows Returned";
            dataPointWarmCache07.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache07.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache07.Label = "#VAL{N0}";
            dataPointWarmCache07.LegendText = "Rows Returned";

            #endregion

            #region Serie settings

            seriesWarmCache.ChartArea = "chartAreaWarmCache";
            seriesWarmCache.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            seriesWarmCache.LegendText = "#LABEL";
            seriesWarmCache.Name = "chartSerieWarmCache";

            seriesWarmCache.Points.Add(dataPointWarmCache01);
            seriesWarmCache.Points.Add(dataPointWarmCache02);
            seriesWarmCache.Points.Add(dataPointWarmCache03);
            seriesWarmCache.Points.Add(dataPointWarmCache04);
            seriesWarmCache.Points.Add(dataPointWarmCache05);
            seriesWarmCache.Points.Add(dataPointWarmCache06);
            seriesWarmCache.Points.Add(dataPointWarmCache07);

            chartWarmCache.Series.Add(seriesWarmCache);

            #endregion

            #endregion

        }

        private void InitializeContextMenuStrips()
        {
            Debug.Assert(chartColdCache.ContextMenuStrip == null);
            Debug.Assert(chartWarmCache.ContextMenuStrip == null);

            _menu = new ContextMenuStrip();

            #region Charts visibility

            _showBoth = new ToolStripMenuItem("Show both charts");
            _showBoth.Click += (object sender, EventArgs e) =>
            {
                splitContainer.SplitterDistance = splitContainer.Width / 2;
                splitContainer.Panel1Collapsed = false;
                splitContainer.Panel2Collapsed = false;
                _showBoth.Checked = false;
                _showBoth.Visible = false;
                _showOnlyThis.Visible = true;
                _resizeBoth.Visible = true;
            };
            _showBoth.Checked = false;
            _showBoth.Visible = false;
            _menu.Items.Add(_showBoth);

            _showOnlyThis = new ToolStripMenuItem("Show only this chart");
            _showOnlyThis.Click += (object sender, EventArgs e) =>
            {
                if (_selectedChart == chartColdCache)
                {
                    splitContainer.Panel1Collapsed = false;
                    splitContainer.Panel2Collapsed = true;
                }
                else
                    if (_selectedChart == chartWarmCache)
                    {
                        splitContainer.Panel1Collapsed = true;
                        splitContainer.Panel2Collapsed = false;
                    }
                _showOnlyThis.Checked = false;
                _showOnlyThis.Visible = false;
                _showBoth.Visible = true;
                _resizeBoth.Visible = false;
            };
            _showOnlyThis.Checked = false;
            _showOnlyThis.Visible = true;
            _menu.Items.Add(_showOnlyThis);

            _resizeBoth = new ToolStripMenuItem("Resize both charts");
            _resizeBoth.Click += (object sender, EventArgs e) =>
            {
                splitContainer.SplitterDistance = splitContainer.Width / 2;
                splitContainer.Panel1Collapsed = false;
                splitContainer.Panel2Collapsed = false;
                _resizeBoth.Checked = false;
            };
            _resizeBoth.Checked = false;
            _resizeBoth.Visible = true;
            _menu.Items.Add(_resizeBoth);

            #endregion

            chartColdCache.ContextMenuStrip = _menu;
            chartWarmCache.ContextMenuStrip = _menu;
        }

        public void UpdateStatistics(AnalyzerStatistics analyzerStatistics)
        {
            #region assert
            Debug.Assert(chartColdCache.Series.Count == 1);
            Debug.Assert(chartColdCache.Series[0].Points.Count == 7);
            Debug.Assert(chartColdCache.Series[0].Points[0].LegendText == "Reads");
            Debug.Assert(chartColdCache.Series[0].Points[1].LegendText == "Read KB");
            Debug.Assert(chartColdCache.Series[0].Points[2].LegendText == "Writes");
            Debug.Assert(chartColdCache.Series[0].Points[3].LegendText == "Write KB");
            Debug.Assert(chartColdCache.Series[0].Points[4].LegendText == "CPU Time MS");
            Debug.Assert(chartColdCache.Series[0].Points[5].LegendText == "Rows Scanned");
            Debug.Assert(chartColdCache.Series[0].Points[6].LegendText == "Rows Returned");
            #endregion
            var coldCacheSerie = chartColdCache.Series[0];
            {
                coldCacheSerie.Points[0].SetValueY(analyzerStatistics.ResourceUsageColdCacheReads);
                coldCacheSerie.Points[1].SetValueY(analyzerStatistics.ResourceUsageColdCacheReadKB);
                coldCacheSerie.Points[2].SetValueY(analyzerStatistics.ResourceUsageColdCacheWrites);
                coldCacheSerie.Points[3].SetValueY(analyzerStatistics.ResourceUsageColdCacheWriteKB);
                coldCacheSerie.Points[4].SetValueY(analyzerStatistics.ResourceUsageColdCacheCpuTimeMS);
                coldCacheSerie.Points[5].SetValueY(analyzerStatistics.ResourceUsageColdCacheRowsScanned);
                coldCacheSerie.Points[6].SetValueY(analyzerStatistics.ResourceUsageColdCacheRowsReturned);
            }

            #region assert
            Debug.Assert(chartWarmCache.Series.Count == 1);
            Debug.Assert(chartWarmCache.Series[0].Points.Count == 7);
            Debug.Assert(chartWarmCache.Series[0].Points[0].LegendText == "Reads");
            Debug.Assert(chartWarmCache.Series[0].Points[1].LegendText == "Read KB");
            Debug.Assert(chartWarmCache.Series[0].Points[2].LegendText == "Writes");
            Debug.Assert(chartWarmCache.Series[0].Points[3].LegendText == "Write KB");
            Debug.Assert(chartWarmCache.Series[0].Points[4].LegendText == "CPU Time MS");
            Debug.Assert(chartWarmCache.Series[0].Points[5].LegendText == "Rows Scanned");
            Debug.Assert(chartWarmCache.Series[0].Points[6].LegendText == "Rows Returned");
            #endregion
            var warmCacheSerie = chartWarmCache.Series[0];
            {
                warmCacheSerie.Points[0].SetValueY(analyzerStatistics.ResourceUsageWarmCacheReads);
                warmCacheSerie.Points[1].SetValueY(analyzerStatistics.ResourceUsageWarmCacheReadKB);
                warmCacheSerie.Points[2].SetValueY(analyzerStatistics.ResourceUsageWarmCacheWrites);
                warmCacheSerie.Points[3].SetValueY(analyzerStatistics.ResourceUsageWarmCacheWriteKB);
                warmCacheSerie.Points[4].SetValueY(analyzerStatistics.ResourceUsageWarmCacheCpuTimeMS);
                warmCacheSerie.Points[5].SetValueY(analyzerStatistics.ResourceUsageWarmCacheRowsScanned);
                warmCacheSerie.Points[6].SetValueY(analyzerStatistics.ResourceUsageWarmCacheRowsReturned);
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

            InitializeContextMenuStrips();

            pictureBoxMessage.Image = SystemIcons.Information.ToBitmap();
        }

        private void OnChartMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            _selectedChart = (Chart)sender;
        }

    }
}
