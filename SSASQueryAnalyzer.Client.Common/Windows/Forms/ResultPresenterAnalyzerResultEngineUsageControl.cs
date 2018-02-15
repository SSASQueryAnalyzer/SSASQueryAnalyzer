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
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using SSASQueryAnalyzer.Client.Common.Properties;

    public partial class ResultPresenterAnalyzerResultEngineUsageControl : UserControl
    {
        Chart _selectedChart;
        ContextMenuStrip _menu;

        public Chart ColdChart { get { return chartColdCache; } }
        public Chart WarmChart { get { return chartWarmCache; } }

        private ToolStripMenuItem _showBoth;
        private ToolStripMenuItem _showOnlyThis;
        private ToolStripMenuItem _resizeBoth;
        //private ToolStripSeparator _tss;
        private DataPoint _selectedDataPoint;

        public ResultPresenterAnalyzerResultEngineUsageControl()
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

            #region Data Points settings

            dataPointColdCache01.Label = "#PERCENT{P}";
            dataPointColdCache01.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache01.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache01.LabelFormat = "";
            dataPointColdCache01.LegendText = "Formula Engine";

            dataPointColdCache02.Label = "#PERCENT{P}";
            dataPointColdCache02.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache02.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache02.LabelFormat = "";
            dataPointColdCache02.LegendText = "Storage Engine";

            #endregion

            #region Serie settings

            seriesColdCache.BorderColor = System.Drawing.SystemColors.Control;
            seriesColdCache.ChartArea = "chartAreaColdCache";
            seriesColdCache.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            seriesColdCache.Legend = "legendColdCache";
            seriesColdCache.Name = "serieColdCache";

            seriesColdCache.Points.Add(dataPointColdCache01);
            seriesColdCache.Points.Add(dataPointColdCache02);

            chartColdCache.Series.Add(seriesColdCache);

            #endregion

            #endregion

            #region WarmCache Chart

            chartWarmCache.Series.Clear();

            System.Windows.Forms.DataVisualization.Charting.Series seriesWarmCache = new System.Windows.Forms.DataVisualization.Charting.Series();

            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache01 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache02 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 4D);

            #region Data Points settings

            dataPointWarmCache01.Label = "#PERCENT{P}";
            dataPointWarmCache01.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache01.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache01.LabelFormat = "";
            dataPointWarmCache01.LegendText = "Formula Engine";

            dataPointWarmCache02.Label = "#PERCENT{P}";
            dataPointWarmCache02.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache02.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache02.LabelFormat = "";
            dataPointWarmCache02.LegendText = "Storage Engine";

            #endregion

            #region Serie settings

            seriesWarmCache.BorderColor = System.Drawing.SystemColors.Control;
            seriesWarmCache.ChartArea = "chartAreaWarmCache";
            seriesWarmCache.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            seriesWarmCache.Legend = "legendWarmCache";
            seriesWarmCache.Name = "serieWarmCache";

            seriesWarmCache.Points.Add(dataPointWarmCache01);
            seriesWarmCache.Points.Add(dataPointWarmCache02);

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

            //_tss = new ToolStripSeparator();
            //_tss.Visible = true;
            //_menu.Items.Add(_tss);

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
                else if (_selectedChart == chartWarmCache)
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
            labelWarmCacheExecutionImprovementPercentage.Text = "WARM execution improvement: {0:0.00} %".FormatWith(analyzerStatistics.EngineUsageWarmCacheExecutionImprovementPercentage);
 
            labelColdCacheQueryDuration.Text = "Query duration: {0}".FormatWith(analyzerStatistics.EngineUsageColdCacheQueryDuration.ToFormattedTime());
            labelColdCacheFormulaEngineDuration.Text = "FE duration: {0}".FormatWith(analyzerStatistics.EngineUsageColdCacheFormulaEngineDuration.ToFormattedTime());
            labelColdCacheStorageEngineDuration.Text = "SE duration: {0}".FormatWith(analyzerStatistics.EngineUsageColdCacheStorageEngineDuration.ToFormattedTime());

            labelWarmCacheQueryDuration.Text = "Query duration: {0}".FormatWith(analyzerStatistics.EngineUsageWarmCacheQueryDuration.ToFormattedTime());
            labelWarmCacheFormulaEngineDuration.Text = "FE duration: {0}".FormatWith(analyzerStatistics.EngineUsageWarmCacheFormulaEngineDuration.ToFormattedTime());
            labelWarmCacheStorageEngineDuration.Text = "SE duration: {0}".FormatWith(analyzerStatistics.EngineUsageWarmCacheStorageEngineDuration.ToFormattedTime());

            #region assert
            Debug.Assert(chartColdCache.Series.Count == 1);
            Debug.Assert(chartColdCache.Series[0].Points.Count == 2);
            Debug.Assert(chartColdCache.Series[0].Points[0].LegendText == "Formula Engine");
            Debug.Assert(chartColdCache.Series[0].Points[1].LegendText == "Storage Engine");
            #endregion
            var coldCacheSerie = chartColdCache.Series[0];
            {
                coldCacheSerie.Points[0].SetValueY(analyzerStatistics.EngineUsageColdCacheFormulaEngineDuration.Ticks);
                coldCacheSerie.Points[1].SetValueY(analyzerStatistics.EngineUsageColdCacheStorageEngineDuration.Ticks);
            }

            #region assert
            Debug.Assert(chartWarmCache.Series.Count == 1);
            Debug.Assert(chartWarmCache.Series[0].Points.Count == 2);
            Debug.Assert(chartWarmCache.Series[0].Points[0].LegendText == "Formula Engine");
            Debug.Assert(chartWarmCache.Series[0].Points[1].LegendText == "Storage Engine");
            #endregion
            var warmCacheSerie = chartWarmCache.Series[0];
            {
                warmCacheSerie.Points[0].SetValueY(analyzerStatistics.EngineUsageWarmCacheFormulaEngineDuration.Ticks);
                warmCacheSerie.Points[1].SetValueY(analyzerStatistics.EngineUsageWarmCacheStorageEngineDuration.Ticks);
            }

            InitializeContextMenuStrips();
        }

        //private void OnChartMouseMove(object sender, MouseEventArgs e)
        //{
        //    var chart = (Chart)sender;
        //    var hit = chart.HitTest(e.X, e.Y);

        //    foreach (DataPoint point in chart.Series[0].Points)
        //    {
        //        if (point.Color == Color.Yellow)
        //            point.Color = point.BackSecondaryColor;

        //        point.BackSecondaryColor = Color.White;
        //        point.BackHatchStyle = ChartHatchStyle.None;
        //        point.BorderWidth = 1;
        //        //point["Exploded"] = "False";
        //    }

        //    if (hit.ChartElementType == ChartElementType.DataPoint)
        //    {
        //        var point = chart.Series[0].Points[hit.PointIndex];
        //        if (point.Color != Color.LightGray)
        //        {
        //            point.BackSecondaryColor = point.Color;
        //        }
        //        point.Color = Color.Yellow;
        //        point.BorderWidth = 2;
        //       // point["Exploded"] = "True";
        //    }
        //}

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

        private void OnChartMouseMove(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var hit = chart.HitTest(e.X, e.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                var point = chart.Series[0].Points[hit.PointIndex];
                if ((_selectedDataPoint == null) || (point != _selectedDataPoint))
                {
                    if (_selectedDataPoint != null)
                    {
                        DeselectSingleDataPoint(_selectedDataPoint);
                    }

                    SelectSingleDataPoint(point);

                    _selectedDataPoint = point;
                }
            }
            else
            {
                if (hit.ChartElementType != ChartElementType.DataPointLabel)
                {
                    if (_selectedDataPoint != null)
                    {
                        DeselectSingleDataPoint(_selectedDataPoint);
                    }
                    _selectedDataPoint = null;
                }

            }
        }

        private void OnChartMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            _selectedChart = (Chart)sender;
        }

    }
}
