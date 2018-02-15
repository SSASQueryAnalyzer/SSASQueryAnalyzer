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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;

    public partial class ResultPresenterAnalyzerResultPerformanceCounterControl : UserControl
    {
        private Chart _selectedChart;
        private ContextMenuStrip _menu;
        private ToolStripMenuItem _showBoth;
        private ToolStripMenuItem _showOnlyThis;
        private ToolStripMenuItem _resizeBoth;
        private ToolStripMenuItem _showOnTimeline;
        private ToolStripSeparator _stripSeparator;
        private DataPoint _selectedDataPoint;

        private Dictionary<string, string> performanceCountersTranslation = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public ResultPresenterAnalyzerResultPerformanceCounterControl()
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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache08 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache09 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointColdCache13 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);

            #region Data Points settings

            dataPointColdCache01.AxisLabel = "Memory usage KB";
            dataPointColdCache01.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache01.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache01.Label = "#VAL{N0}";
            dataPointColdCache01.LegendText = "Memory usage KB";

            dataPointColdCache02.AxisLabel = "Cache lookups";
            dataPointColdCache02.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache02.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache02.Label = "#VAL{N0}";
            dataPointColdCache02.LegendText = "Cache lookups";

            dataPointColdCache03.AxisLabel = "Cache inserts";
            dataPointColdCache03.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache03.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache03.Label = "#VAL{N0}";
            dataPointColdCache03.LegendText = "Cache inserts";

            dataPointColdCache04.AxisLabel = "Cache misses";
            dataPointColdCache04.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache04.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache04.Label = "#VAL{N0}";
            dataPointColdCache04.LegendText = "Cache misses";

            dataPointColdCache05.AxisLabel = "Cache hits";
            dataPointColdCache05.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache05.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache05.Label = "#VAL{N0}";
            dataPointColdCache05.LegendText = "Cache hits";

            dataPointColdCache06.AxisLabel = "Flat cache insert";
            dataPointColdCache06.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache06.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache06.Label = "#VAL{N0}";
            dataPointColdCache06.LegendText = "Flat cache insert";

            dataPointColdCache07.AxisLabel = "SE queries";
            dataPointColdCache07.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache07.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache07.Label = "#VAL{N0}";
            dataPointColdCache07.LegendText = "SE queries";

            dataPointColdCache08.AxisLabel = "EXISTINGS";
            dataPointColdCache08.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache08.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache08.Label = "#VAL{N0}";
            dataPointColdCache08.LegendText = "EXISTINGS";

            dataPointColdCache09.AxisLabel = "Autoexists";
            dataPointColdCache09.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache09.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache09.Label = "#VAL{N0}";
            dataPointColdCache09.LegendText = "Autoexists";

            dataPointColdCache10.AxisLabel = "NON EMPTYs";
            dataPointColdCache10.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache10.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache10.Label = "#VAL{N0}";
            dataPointColdCache10.LegendText = "NON EMPTYs";

            dataPointColdCache11.AxisLabel = "Sonar subcubes";
            dataPointColdCache11.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache11.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache11.Label = "#VAL{N0}";
            dataPointColdCache11.LegendText = "Sonar subcubes";

            dataPointColdCache12.AxisLabel = "Cells calculated";
            dataPointColdCache12.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache12.Color = System.Drawing.SystemColors.Window;
            dataPointColdCache12.Label = "#VAL{N0}";
            dataPointColdCache12.LegendText = "Cells calculated";

            dataPointColdCache13.AxisLabel = "Calc covers";
            dataPointColdCache13.BorderColor = Properties.Settings.Default.ColdCacheColor;
            dataPointColdCache13.Color = Properties.Settings.Default.ColdCacheGraphBarColor1;
            dataPointColdCache13.Label = "#VAL{N0}";
            dataPointColdCache13.LegendText = "Calc covers";

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
            seriesColdCache.Points.Add(dataPointColdCache08);
            seriesColdCache.Points.Add(dataPointColdCache09);
            seriesColdCache.Points.Add(dataPointColdCache10);
            seriesColdCache.Points.Add(dataPointColdCache11);
            seriesColdCache.Points.Add(dataPointColdCache12);
            seriesColdCache.Points.Add(dataPointColdCache13);
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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache08 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache09 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPointWarmCache13 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);

            #region Data Points settings

            dataPointWarmCache01.AxisLabel = "Memory usage KB";
            dataPointWarmCache01.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache01.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache01.Label = "#VAL{N0}";
            dataPointWarmCache01.LegendText = "Memory usage KB";

            dataPointWarmCache02.AxisLabel = "Cache lookups";
            dataPointWarmCache02.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache02.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache02.Label = "#VAL{N0}";
            dataPointWarmCache02.LegendText = "Cache lookups";

            dataPointWarmCache03.AxisLabel = "Cache inserts";
            dataPointWarmCache03.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache03.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache03.Label = "#VAL{N0}";
            dataPointWarmCache03.LegendText = "Cache inserts";

            dataPointWarmCache04.AxisLabel = "Cache misses";
            dataPointWarmCache04.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache04.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache04.Label = "#VAL{N0}";
            dataPointWarmCache04.LegendText = "Cache misses";

            dataPointWarmCache05.AxisLabel = "Cache hits";
            dataPointWarmCache05.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache05.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache05.Label = "#VAL{N0}";
            dataPointWarmCache05.LegendText = "Cache hits";

            dataPointWarmCache06.AxisLabel = "Flat cache insert";
            dataPointWarmCache06.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache06.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache06.Label = "#VAL{N0}";
            dataPointWarmCache06.LegendText = "Flat cache insert";

            dataPointWarmCache07.AxisLabel = "SE queries";
            dataPointWarmCache07.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache07.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache07.Label = "#VAL{N0}";
            dataPointWarmCache07.LegendText = "SE queries";

            dataPointWarmCache08.AxisLabel = "EXISTINGS";
            dataPointWarmCache08.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache08.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache08.Label = "#VAL{N0}";
            dataPointWarmCache08.LegendText = "EXISTINGS";

            dataPointWarmCache09.AxisLabel = "Autoexists";
            dataPointWarmCache09.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache09.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache09.Label = "#VAL{N0}";
            dataPointWarmCache09.LegendText = "Autoexists";

            dataPointWarmCache10.AxisLabel = "NON EMPTYs";
            dataPointWarmCache10.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache10.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache10.Label = "#VAL{N0}";
            dataPointWarmCache10.LegendText = "NON EMPTYs";

            dataPointWarmCache11.AxisLabel = "Sonar subcubes";
            dataPointWarmCache11.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache11.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache11.Label = "#VAL{N0}";
            dataPointWarmCache11.LegendText = "Sonar subcubes";

            dataPointWarmCache12.AxisLabel = "Cells calculated";
            dataPointWarmCache12.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache12.Color = System.Drawing.SystemColors.Window;
            dataPointWarmCache12.Label = "#VAL{N0}";
            dataPointWarmCache12.LegendText = "Cells calculated";

            dataPointWarmCache13.AxisLabel = "Calc covers";
            dataPointWarmCache13.BorderColor = Properties.Settings.Default.WarmCacheColor;
            dataPointWarmCache13.Color = Properties.Settings.Default.WarmCacheGraphBarColor1;
            dataPointWarmCache13.Label = "#VAL{N0}";
            dataPointWarmCache13.LegendText = "Calc covers";

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
            seriesWarmCache.Points.Add(dataPointWarmCache08);
            seriesWarmCache.Points.Add(dataPointWarmCache09);
            seriesWarmCache.Points.Add(dataPointWarmCache10);
            seriesWarmCache.Points.Add(dataPointWarmCache11);
            seriesWarmCache.Points.Add(dataPointWarmCache12);
            seriesWarmCache.Points.Add(dataPointWarmCache13);
            chartWarmCache.Series.Add(seriesWarmCache);

            #endregion

            #endregion
        }

        public void UpdateStatistics(AnalyzerStatistics analyzerStatistics)
        {
            // dictionary structure: (<MDXStudioName>,<PerformanceCounterName>)
            performanceCountersTranslation.Add("Calc covers", "Number of calculation covers");
            performanceCountersTranslation.Add("Cells calculated", "Total cells calculated");
            performanceCountersTranslation.Add("Sonar subcubes", "Total sonar subcubes");
            performanceCountersTranslation.Add("NON EMPTYs", "Total NON EMPTY");
            performanceCountersTranslation.Add("Autoexists", "Total Autoexist");
            performanceCountersTranslation.Add("EXISTINGS", "Total EXISTING");
            performanceCountersTranslation.Add("SE queries", "Total measure group queries");
            performanceCountersTranslation.Add("Flat cache insert", "Total flat cache inserts");
            performanceCountersTranslation.Add("Cache hits", "Total direct hits");
            performanceCountersTranslation.Add("Cache misses", "Total misses");
            performanceCountersTranslation.Add("Cache inserts", "Total inserts");
            performanceCountersTranslation.Add("Cache lookups", "Total lookups");
            performanceCountersTranslation.Add("Memory usage KB", "Memory usage KB");

            #region assert
            Debug.Assert(chartColdCache.Series.Count == 1);
            Debug.Assert(chartColdCache.Series[0].Points.Count == 13);
            Debug.Assert(chartColdCache.Series[0].Points[0].LegendText == "Memory usage KB");
            Debug.Assert(chartColdCache.Series[0].Points[1].LegendText == "Cache lookups");
            Debug.Assert(chartColdCache.Series[0].Points[2].LegendText == "Cache inserts");
            Debug.Assert(chartColdCache.Series[0].Points[3].LegendText == "Cache misses");
            Debug.Assert(chartColdCache.Series[0].Points[4].LegendText == "Cache hits");
            Debug.Assert(chartColdCache.Series[0].Points[5].LegendText == "Flat cache insert");
            Debug.Assert(chartColdCache.Series[0].Points[6].LegendText == "SE queries");
            Debug.Assert(chartColdCache.Series[0].Points[7].LegendText == "EXISTINGS");
            Debug.Assert(chartColdCache.Series[0].Points[8].LegendText == "Autoexists");
            Debug.Assert(chartColdCache.Series[0].Points[9].LegendText == "NON EMPTYs");
            Debug.Assert(chartColdCache.Series[0].Points[10].LegendText == "Sonar subcubes");
            Debug.Assert(chartColdCache.Series[0].Points[11].LegendText == "Cells calculated");
            Debug.Assert(chartColdCache.Series[0].Points[12].LegendText == "Calc covers");
            #endregion

            var coldCacheSerie = chartColdCache.Series[0];
            {
                coldCacheSerie.Points[1].SetValueY(analyzerStatistics.PerformanceCountersColdCacheCacheTotalLookups);
                coldCacheSerie.Points[2].SetValueY(analyzerStatistics.PerformanceCountersColdCacheCacheTotalInserts);
                coldCacheSerie.Points[3].SetValueY(analyzerStatistics.PerformanceCountersColdCacheCacheTotalMisses);
                coldCacheSerie.Points[4].SetValueY(analyzerStatistics.PerformanceCountersColdCacheCacheTotalDirectHits);
                coldCacheSerie.Points[5].SetValueY(analyzerStatistics.PerformanceCountersColdCacheMdxTotalFlatCacheInserts);
                coldCacheSerie.Points[6].SetValueY(analyzerStatistics.PerformanceCountersColdCacheStorageEngineQueryTotalMeasureGroupQueries);
                coldCacheSerie.Points[7].SetValueY(analyzerStatistics.PerformanceCountersColdCacheMdxTotalExisting);
                coldCacheSerie.Points[8].SetValueY(analyzerStatistics.PerformanceCountersColdCacheMdxTotalAutoexist);
                coldCacheSerie.Points[9].SetValueY(analyzerStatistics.PerformanceCountersColdCacheMdxTotalNonEmpty);
                coldCacheSerie.Points[10].SetValueY(analyzerStatistics.PerformanceCountersColdCacheMdxTotalSonarSubcubes);
                coldCacheSerie.Points[11].SetValueY(analyzerStatistics.PerformanceCountersColdCacheMdxTotalCellsCalculated);
                coldCacheSerie.Points[12].SetValueY(analyzerStatistics.PerformanceCountersColdCacheMdxNumberOfCalculationCovers);

                var value = analyzerStatistics.PerformanceCountersColdCacheMemoryMemoryUsageKB;
                if (value < 0L)
                {
                    coldCacheSerie.Points[0].Label = string.Format("{0:n0}", value);
                    coldCacheSerie.Points[0].SetValueY(0L);
                }
                else
                {
                    coldCacheSerie.Points[0].Label = "#VAL{N0}";
                    coldCacheSerie.Points[0].SetValueY(value);
                }
            }

            #region assert
            Debug.Assert(chartWarmCache.Series.Count == 1);
            Debug.Assert(chartWarmCache.Series[0].Points.Count == 13);
            Debug.Assert(chartWarmCache.Series[0].Points[0].LegendText == "Memory usage KB");
            Debug.Assert(chartWarmCache.Series[0].Points[1].LegendText == "Cache lookups");
            Debug.Assert(chartWarmCache.Series[0].Points[2].LegendText == "Cache inserts");
            Debug.Assert(chartWarmCache.Series[0].Points[3].LegendText == "Cache misses");
            Debug.Assert(chartWarmCache.Series[0].Points[4].LegendText == "Cache hits");
            Debug.Assert(chartWarmCache.Series[0].Points[5].LegendText == "Flat cache insert");
            Debug.Assert(chartWarmCache.Series[0].Points[6].LegendText == "SE queries");
            Debug.Assert(chartWarmCache.Series[0].Points[7].LegendText == "EXISTINGS");
            Debug.Assert(chartWarmCache.Series[0].Points[8].LegendText == "Autoexists");
            Debug.Assert(chartWarmCache.Series[0].Points[9].LegendText == "NON EMPTYs");
            Debug.Assert(chartWarmCache.Series[0].Points[10].LegendText == "Sonar subcubes");
            Debug.Assert(chartWarmCache.Series[0].Points[11].LegendText == "Cells calculated");
            Debug.Assert(chartWarmCache.Series[0].Points[12].LegendText == "Calc covers");
            #endregion

            var warmCacheSerie = chartWarmCache.Series[0];
            {
                warmCacheSerie.Points[1].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheCacheTotalLookups);
                warmCacheSerie.Points[2].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheCacheTotalInserts);
                warmCacheSerie.Points[3].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheCacheTotalMisses);
                warmCacheSerie.Points[4].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheCacheTotalDirectHits);
                warmCacheSerie.Points[5].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheMdxTotalFlatCacheInserts);
                warmCacheSerie.Points[6].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheStorageEngineQueryTotalMeasureGroupQueries);
                warmCacheSerie.Points[7].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheMdxTotalExisting);
                warmCacheSerie.Points[8].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheMdxTotalAutoexist);
                warmCacheSerie.Points[9].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheMdxTotalNonEmpty);
                warmCacheSerie.Points[10].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheMdxTotalSonarSubcubes);
                warmCacheSerie.Points[11].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheMdxTotalCellsCalculated);
                warmCacheSerie.Points[12].SetValueY(analyzerStatistics.PerformanceCountersWarmCacheMdxNumberOfCalculationCovers);

                var value = analyzerStatistics.PerformanceCountersWarmCacheMemoryMemoryUsageKB;
                if (value < 0L)
                {
                    warmCacheSerie.Points[0].Label = string.Format("{0:n0}", value);
                    warmCacheSerie.Points[0].SetValueY(0L);
                }
                else
                {
                    warmCacheSerie.Points[0].Label = "#VAL{N0}";
                    warmCacheSerie.Points[0].SetValueY(value);
                }
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

        #region Context menu

        private void InitializeContextMenuStrips()
        {
            Debug.Assert(chartColdCache.ContextMenuStrip == null);
            Debug.Assert(chartWarmCache.ContextMenuStrip == null);

            _menu = new ContextMenuStrip();

            #region Charts visibility

            _showOnTimeline = new ToolStripMenuItem("Set as Performance Counter on Timeline");
            _showOnTimeline.Click += (s, e) => ShowPerformanceCounterInTimeline();
            _showOnTimeline.Checked = false;
            _showOnTimeline.Visible = true;
            _menu.Items.Add(_showOnTimeline);

            _stripSeparator = new ToolStripSeparator();
            _stripSeparator.Visible = true;
            _menu.Items.Add(_stripSeparator);

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

        private void ShowPerformanceCounterInTimeline()
        {
            if (_selectedDataPoint != null)
            {
                string updatedPerformanceCounterName = "";
                string originalPerformanceCounterName = _selectedDataPoint.AxisLabel;

                if (performanceCountersTranslation.ContainsKey(originalPerformanceCounterName))
                    updatedPerformanceCounterName = performanceCountersTranslation[originalPerformanceCounterName];

                if (originalPerformanceCounterName != "" && updatedPerformanceCounterName != "")
                {
                    var resultPresenterControl = this.GetResultPresenterControl();
                    resultPresenterControl.AnalyzerResultControl.SelectTabPageIndex(5);

                    Chart timelineChart = null;
                    if (_selectedChart == chartColdCache)
                        timelineChart = resultPresenterControl.AnalyzerResultControl.TimelineControl.chartCold;
                    else if (_selectedChart == chartWarmCache)
                        timelineChart = resultPresenterControl.AnalyzerResultControl.TimelineControl.chartWarm;

                    foreach (var item in timelineChart.ContextMenuStrip.Items)
                    {
                        if (item is ToolStripMenuItem)
                        {
                            var menuItem = (ToolStripMenuItem)item;
                            if (menuItem.Text == "Performance Counters")
                            {
                                foreach (ToolStripItem tsitem in menuItem.DropDownItems)
                                {
                                    if (tsitem.Text.Substring(tsitem.Text.IndexOf(':') + 2).Equals(updatedPerformanceCounterName, StringComparison.OrdinalIgnoreCase))
                                    {
                                        tsitem.PerformClick();
                                        break;
                                    }
                                }

                                break;
                            }
                        }
                    }

                }
            }
        }

        #endregion

        #region Mouse events

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

        private void DeselectSingleDataPoint(DataPoint point)
        {
            if (point.Color == Settings.Default.HighlightColor)
                point.Color = point.BackSecondaryColor;

            point.BackSecondaryColor = Color.White;
            point.BackHatchStyle = ChartHatchStyle.None;
            point.BorderWidth = 1;
        }

        private void SelectSingleDataPoint(DataPoint point)
        {
            point.BackSecondaryColor = point.Color;
            point.Color = Settings.Default.HighlightColor;
            point.BorderWidth = 2;
        }

        private void OnChartMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            _selectedChart = (Chart)sender;
            _showOnTimeline.Visible = _selectedDataPoint != null;
            _stripSeparator.Visible = _selectedDataPoint != null;
        }

        #endregion
    }
}
