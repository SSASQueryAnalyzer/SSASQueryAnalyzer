namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;

    partial class ResultPresenterAnalyzerResultEngineUsageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 83D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 17D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 17D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 83D);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelWarmCacheExecutionImprovementPercentage = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelCold = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCold = new System.Windows.Forms.TableLayoutPanel();
            this.panelColdCacheChart = new System.Windows.Forms.Panel();
            this.chartColdCache = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelColdCacheStorageEngineLegend = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelColdCacheStorageEngineDuration = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelColdCacheFormulaEngineDuration = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelColdCacheFormulaEngineLegend = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelColdCacheQueryDuration = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelColdCacheTitle = new System.Windows.Forms.Label();
            this.panelWarm = new System.Windows.Forms.Panel();
            this.tableLayoutPanelWarm = new System.Windows.Forms.TableLayoutPanel();
            this.panelWarmCacheChart = new System.Windows.Forms.Panel();
            this.chartWarmCache = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelWarmCacheStorageEngineLegend = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelWarmCacheStorageEngineDuration = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelWarmCacheFormulaEngineDuration = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelWarmCacheFormulaEngineLegend = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelWarmCacheQueryDuration = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelWarmCacheTitle = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelCold.SuspendLayout();
            this.tableLayoutPanelCold.SuspendLayout();
            this.panelColdCacheChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartColdCache)).BeginInit();
            this.panelWarm.SuspendLayout();
            this.tableLayoutPanelWarm.SuspendLayout();
            this.panelWarmCacheChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWarmCache)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.Window;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.labelWarmCacheExecutionImprovementPercentage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 448);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(849, 26);
            this.panelBottom.TabIndex = 1;
            // 
            // labelWarmCacheExecutionImprovementPercentage
            // 
            this.labelWarmCacheExecutionImprovementPercentage.BorderColor = System.Drawing.Color.Black;
            this.labelWarmCacheExecutionImprovementPercentage.BorderHeightOffset = 2;
            this.labelWarmCacheExecutionImprovementPercentage.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.labelWarmCacheExecutionImprovementPercentage.BorderWidthOffset = 2;
            this.labelWarmCacheExecutionImprovementPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWarmCacheExecutionImprovementPercentage.DrawBorder = false;
            this.labelWarmCacheExecutionImprovementPercentage.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarmCacheExecutionImprovementPercentage.Location = new System.Drawing.Point(0, 0);
            this.labelWarmCacheExecutionImprovementPercentage.Name = "labelWarmCacheExecutionImprovementPercentage";
            this.labelWarmCacheExecutionImprovementPercentage.Size = new System.Drawing.Size(847, 24);
            this.labelWarmCacheExecutionImprovementPercentage.TabIndex = 15;
            this.labelWarmCacheExecutionImprovementPercentage.Text = "WARM execution improvement: {0:0.00} %";
            this.labelWarmCacheExecutionImprovementPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 444);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 4);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelCold);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelWarm);
            this.splitContainer.Size = new System.Drawing.Size(849, 444);
            this.splitContainer.SplitterDistance = 425;
            this.splitContainer.TabIndex = 3;
            // 
            // panelCold
            // 
            this.panelCold.BackColor = System.Drawing.Color.Transparent;
            this.panelCold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCold.Controls.Add(this.tableLayoutPanelCold);
            this.panelCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCold.Location = new System.Drawing.Point(0, 0);
            this.panelCold.Name = "panelCold";
            this.panelCold.Size = new System.Drawing.Size(425, 444);
            this.panelCold.TabIndex = 0;
            // 
            // tableLayoutPanelCold
            // 
            this.tableLayoutPanelCold.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelCold.ColumnCount = 7;
            this.tableLayoutPanelCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanelCold.Controls.Add(this.panelColdCacheChart, 1, 4);
            this.tableLayoutPanelCold.Controls.Add(this.labelColdCacheStorageEngineLegend, 5, 3);
            this.tableLayoutPanelCold.Controls.Add(this.labelColdCacheStorageEngineDuration, 4, 3);
            this.tableLayoutPanelCold.Controls.Add(this.labelColdCacheFormulaEngineDuration, 2, 3);
            this.tableLayoutPanelCold.Controls.Add(this.labelColdCacheFormulaEngineLegend, 1, 3);
            this.tableLayoutPanelCold.Controls.Add(this.labelColdCacheQueryDuration, 1, 2);
            this.tableLayoutPanelCold.Controls.Add(this.labelColdCacheTitle, 1, 1);
            this.tableLayoutPanelCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCold.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCold.Name = "tableLayoutPanelCold";
            this.tableLayoutPanelCold.RowCount = 6;
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCold.Size = new System.Drawing.Size(423, 442);
            this.tableLayoutPanelCold.TabIndex = 1;
            // 
            // panelColdCacheChart
            // 
            this.tableLayoutPanelCold.SetColumnSpan(this.panelColdCacheChart, 5);
            this.panelColdCacheChart.Controls.Add(this.chartColdCache);
            this.panelColdCacheChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColdCacheChart.Location = new System.Drawing.Point(5, 75);
            this.panelColdCacheChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelColdCacheChart.Name = "panelColdCacheChart";
            this.panelColdCacheChart.Size = new System.Drawing.Size(412, 363);
            this.panelColdCacheChart.TabIndex = 13;
            // 
            // chartColdCache
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.Name = "chartAreaColdCache";
            this.chartColdCache.ChartAreas.Add(chartArea1);
            this.chartColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "legendColdCache";
            this.chartColdCache.Legends.Add(legend1);
            this.chartColdCache.Location = new System.Drawing.Point(0, 0);
            this.chartColdCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartColdCache.Name = "chartColdCache";
            series1.BorderColor = System.Drawing.SystemColors.Control;
            series1.ChartArea = "chartAreaColdCache";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series1.Legend = "legendColdCache";
            series1.Name = "serieColdCache";
            dataPoint1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataPoint1.IsValueShownAsLabel = true;
            dataPoint1.Label = "#PERCENT{P}";
            dataPoint1.LabelFormat = "";
            dataPoint1.LegendText = "Formula Engine";
            dataPoint2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint2.Color = System.Drawing.SystemColors.Window;
            dataPoint2.Label = "#PERCENT{P}";
            dataPoint2.LegendText = "Storage Engine";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            this.chartColdCache.Series.Add(series1);
            this.chartColdCache.Size = new System.Drawing.Size(412, 363);
            this.chartColdCache.TabIndex = 0;
            this.chartColdCache.Text = "chartColdCache";
            this.chartColdCache.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseMove);
            this.chartColdCache.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseUp);
            // 
            // labelColdCacheStorageEngineLegend
            // 
            this.labelColdCacheStorageEngineLegend.AutoSize = true;
            this.labelColdCacheStorageEngineLegend.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheGraphBarColor2;
            this.labelColdCacheStorageEngineLegend.BorderColor = System.Drawing.Color.Black;
            this.labelColdCacheStorageEngineLegend.BorderHeightOffset = 2;
            this.labelColdCacheStorageEngineLegend.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelColdCacheStorageEngineLegend.BorderWidthOffset = 2;
            this.labelColdCacheStorageEngineLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelColdCacheStorageEngineLegend.DrawBorder = true;
            this.labelColdCacheStorageEngineLegend.Location = new System.Drawing.Point(400, 57);
            this.labelColdCacheStorageEngineLegend.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labelColdCacheStorageEngineLegend.Name = "labelColdCacheStorageEngineLegend";
            this.labelColdCacheStorageEngineLegend.Size = new System.Drawing.Size(15, 16);
            this.labelColdCacheStorageEngineLegend.TabIndex = 11;
            // 
            // labelColdCacheStorageEngineDuration
            // 
            this.labelColdCacheStorageEngineDuration.AutoSize = true;
            this.labelColdCacheStorageEngineDuration.BorderColor = System.Drawing.Color.Black;
            this.labelColdCacheStorageEngineDuration.BorderHeightOffset = 2;
            this.labelColdCacheStorageEngineDuration.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelColdCacheStorageEngineDuration.BorderWidthOffset = 2;
            this.labelColdCacheStorageEngineDuration.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelColdCacheStorageEngineDuration.DrawBorder = false;
            this.labelColdCacheStorageEngineDuration.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColdCacheStorageEngineDuration.Location = new System.Drawing.Point(312, 57);
            this.labelColdCacheStorageEngineDuration.Name = "labelColdCacheStorageEngineDuration";
            this.labelColdCacheStorageEngineDuration.Size = new System.Drawing.Size(85, 16);
            this.labelColdCacheStorageEngineDuration.TabIndex = 10;
            this.labelColdCacheStorageEngineDuration.Text = "SE duration: {0}";
            // 
            // labelColdCacheFormulaEngineDuration
            // 
            this.labelColdCacheFormulaEngineDuration.AutoSize = true;
            this.labelColdCacheFormulaEngineDuration.BorderColor = System.Drawing.Color.Black;
            this.labelColdCacheFormulaEngineDuration.BorderHeightOffset = 2;
            this.labelColdCacheFormulaEngineDuration.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelColdCacheFormulaEngineDuration.BorderWidthOffset = 2;
            this.labelColdCacheFormulaEngineDuration.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelColdCacheFormulaEngineDuration.DrawBorder = false;
            this.labelColdCacheFormulaEngineDuration.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColdCacheFormulaEngineDuration.Location = new System.Drawing.Point(25, 57);
            this.labelColdCacheFormulaEngineDuration.Name = "labelColdCacheFormulaEngineDuration";
            this.labelColdCacheFormulaEngineDuration.Size = new System.Drawing.Size(85, 16);
            this.labelColdCacheFormulaEngineDuration.TabIndex = 8;
            this.labelColdCacheFormulaEngineDuration.Text = "FE duration: {0}";
            // 
            // labelColdCacheFormulaEngineLegend
            // 
            this.labelColdCacheFormulaEngineLegend.AutoSize = true;
            this.labelColdCacheFormulaEngineLegend.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheGraphBarColor1;
            this.labelColdCacheFormulaEngineLegend.BorderColor = System.Drawing.Color.Black;
            this.labelColdCacheFormulaEngineLegend.BorderHeightOffset = 2;
            this.labelColdCacheFormulaEngineLegend.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelColdCacheFormulaEngineLegend.BorderWidthOffset = 2;
            this.labelColdCacheFormulaEngineLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelColdCacheFormulaEngineLegend.DrawBorder = true;
            this.labelColdCacheFormulaEngineLegend.Location = new System.Drawing.Point(7, 57);
            this.labelColdCacheFormulaEngineLegend.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelColdCacheFormulaEngineLegend.Name = "labelColdCacheFormulaEngineLegend";
            this.labelColdCacheFormulaEngineLegend.Size = new System.Drawing.Size(15, 16);
            this.labelColdCacheFormulaEngineLegend.TabIndex = 4;
            // 
            // labelColdCacheQueryDuration
            // 
            this.labelColdCacheQueryDuration.AutoSize = true;
            this.labelColdCacheQueryDuration.BorderColor = System.Drawing.Color.Black;
            this.labelColdCacheQueryDuration.BorderHeightOffset = 2;
            this.labelColdCacheQueryDuration.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelColdCacheQueryDuration.BorderWidthOffset = 2;
            this.tableLayoutPanelCold.SetColumnSpan(this.labelColdCacheQueryDuration, 5);
            this.labelColdCacheQueryDuration.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelColdCacheQueryDuration.DrawBorder = false;
            this.labelColdCacheQueryDuration.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColdCacheQueryDuration.Location = new System.Drawing.Point(5, 37);
            this.labelColdCacheQueryDuration.Name = "labelColdCacheQueryDuration";
            this.labelColdCacheQueryDuration.Size = new System.Drawing.Size(412, 13);
            this.labelColdCacheQueryDuration.TabIndex = 3;
            this.labelColdCacheQueryDuration.Text = "Query duration: {0}";
            this.labelColdCacheQueryDuration.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelColdCacheTitle
            // 
            this.labelColdCacheTitle.AutoSize = true;
            this.labelColdCacheTitle.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheColor;
            this.tableLayoutPanelCold.SetColumnSpan(this.labelColdCacheTitle, 5);
            this.labelColdCacheTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelColdCacheTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColdCacheTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.labelColdCacheTitle.Location = new System.Drawing.Point(7, 8);
            this.labelColdCacheTitle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelColdCacheTitle.Name = "labelColdCacheTitle";
            this.labelColdCacheTitle.Size = new System.Drawing.Size(408, 15);
            this.labelColdCacheTitle.TabIndex = 1;
            this.labelColdCacheTitle.Text = "COLD CACHE";
            this.labelColdCacheTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelWarm
            // 
            this.panelWarm.BackColor = System.Drawing.Color.Transparent;
            this.panelWarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWarm.Controls.Add(this.tableLayoutPanelWarm);
            this.panelWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWarm.Location = new System.Drawing.Point(0, 0);
            this.panelWarm.Name = "panelWarm";
            this.panelWarm.Size = new System.Drawing.Size(420, 444);
            this.panelWarm.TabIndex = 0;
            // 
            // tableLayoutPanelWarm
            // 
            this.tableLayoutPanelWarm.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelWarm.ColumnCount = 7;
            this.tableLayoutPanelWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelWarm.Controls.Add(this.panelWarmCacheChart, 1, 4);
            this.tableLayoutPanelWarm.Controls.Add(this.labelWarmCacheStorageEngineLegend, 5, 3);
            this.tableLayoutPanelWarm.Controls.Add(this.labelWarmCacheStorageEngineDuration, 4, 3);
            this.tableLayoutPanelWarm.Controls.Add(this.labelWarmCacheFormulaEngineDuration, 2, 3);
            this.tableLayoutPanelWarm.Controls.Add(this.labelWarmCacheFormulaEngineLegend, 1, 3);
            this.tableLayoutPanelWarm.Controls.Add(this.labelWarmCacheQueryDuration, 1, 2);
            this.tableLayoutPanelWarm.Controls.Add(this.labelWarmCacheTitle, 1, 1);
            this.tableLayoutPanelWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWarm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelWarm.Name = "tableLayoutPanelWarm";
            this.tableLayoutPanelWarm.RowCount = 6;
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWarm.Size = new System.Drawing.Size(418, 442);
            this.tableLayoutPanelWarm.TabIndex = 2;
            // 
            // panelWarmCacheChart
            // 
            this.tableLayoutPanelWarm.SetColumnSpan(this.panelWarmCacheChart, 5);
            this.panelWarmCacheChart.Controls.Add(this.chartWarmCache);
            this.panelWarmCacheChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWarmCacheChart.Location = new System.Drawing.Point(5, 75);
            this.panelWarmCacheChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelWarmCacheChart.Name = "panelWarmCacheChart";
            this.panelWarmCacheChart.Size = new System.Drawing.Size(406, 363);
            this.panelWarmCacheChart.TabIndex = 20;
            // 
            // chartWarmCache
            // 
            chartArea2.Name = "chartAreaWarmCache";
            this.chartWarmCache.ChartAreas.Add(chartArea2);
            this.chartWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "legendWarmCache";
            this.chartWarmCache.Legends.Add(legend2);
            this.chartWarmCache.Location = new System.Drawing.Point(0, 0);
            this.chartWarmCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartWarmCache.Name = "chartWarmCache";
            series2.ChartArea = "chartAreaWarmCache";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "legendWarmCache";
            series2.Name = "serieWarmCache";
            dataPoint3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint3.IsValueShownAsLabel = true;
            dataPoint3.Label = "#PERCENT{P}";
            dataPoint3.LabelFormat = "";
            dataPoint3.LegendText = "Formula Engine";
            dataPoint4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint4.Color = System.Drawing.SystemColors.Window;
            dataPoint4.Label = "#PERCENT{P}";
            dataPoint4.LegendText = "Storage Engine";
            series2.Points.Add(dataPoint3);
            series2.Points.Add(dataPoint4);
            this.chartWarmCache.Series.Add(series2);
            this.chartWarmCache.Size = new System.Drawing.Size(406, 363);
            this.chartWarmCache.TabIndex = 14;
            this.chartWarmCache.Text = "chartWarmCache";
            this.chartWarmCache.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseMove);
            this.chartWarmCache.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseUp);
            // 
            // labelWarmCacheStorageEngineLegend
            // 
            this.labelWarmCacheStorageEngineLegend.AutoSize = true;
            this.labelWarmCacheStorageEngineLegend.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheGraphBarColor2;
            this.labelWarmCacheStorageEngineLegend.BorderColor = System.Drawing.Color.Black;
            this.labelWarmCacheStorageEngineLegend.BorderHeightOffset = 2;
            this.labelWarmCacheStorageEngineLegend.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelWarmCacheStorageEngineLegend.BorderWidthOffset = 2;
            this.labelWarmCacheStorageEngineLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWarmCacheStorageEngineLegend.DrawBorder = true;
            this.labelWarmCacheStorageEngineLegend.Location = new System.Drawing.Point(394, 57);
            this.labelWarmCacheStorageEngineLegend.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labelWarmCacheStorageEngineLegend.Name = "labelWarmCacheStorageEngineLegend";
            this.labelWarmCacheStorageEngineLegend.Size = new System.Drawing.Size(15, 16);
            this.labelWarmCacheStorageEngineLegend.TabIndex = 19;
            // 
            // labelWarmCacheStorageEngineDuration
            // 
            this.labelWarmCacheStorageEngineDuration.AutoSize = true;
            this.labelWarmCacheStorageEngineDuration.BorderColor = System.Drawing.Color.Black;
            this.labelWarmCacheStorageEngineDuration.BorderHeightOffset = 2;
            this.labelWarmCacheStorageEngineDuration.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelWarmCacheStorageEngineDuration.BorderWidthOffset = 2;
            this.labelWarmCacheStorageEngineDuration.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelWarmCacheStorageEngineDuration.DrawBorder = false;
            this.labelWarmCacheStorageEngineDuration.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarmCacheStorageEngineDuration.Location = new System.Drawing.Point(306, 57);
            this.labelWarmCacheStorageEngineDuration.Name = "labelWarmCacheStorageEngineDuration";
            this.labelWarmCacheStorageEngineDuration.Size = new System.Drawing.Size(85, 16);
            this.labelWarmCacheStorageEngineDuration.TabIndex = 18;
            this.labelWarmCacheStorageEngineDuration.Text = "SE duration: {0}";
            // 
            // labelWarmCacheFormulaEngineDuration
            // 
            this.labelWarmCacheFormulaEngineDuration.AutoSize = true;
            this.labelWarmCacheFormulaEngineDuration.BorderColor = System.Drawing.Color.Black;
            this.labelWarmCacheFormulaEngineDuration.BorderHeightOffset = 2;
            this.labelWarmCacheFormulaEngineDuration.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelWarmCacheFormulaEngineDuration.BorderWidthOffset = 2;
            this.labelWarmCacheFormulaEngineDuration.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelWarmCacheFormulaEngineDuration.DrawBorder = false;
            this.labelWarmCacheFormulaEngineDuration.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarmCacheFormulaEngineDuration.Location = new System.Drawing.Point(25, 57);
            this.labelWarmCacheFormulaEngineDuration.Name = "labelWarmCacheFormulaEngineDuration";
            this.labelWarmCacheFormulaEngineDuration.Size = new System.Drawing.Size(85, 16);
            this.labelWarmCacheFormulaEngineDuration.TabIndex = 17;
            this.labelWarmCacheFormulaEngineDuration.Text = "FE duration: {0}";
            // 
            // labelWarmCacheFormulaEngineLegend
            // 
            this.labelWarmCacheFormulaEngineLegend.AutoSize = true;
            this.labelWarmCacheFormulaEngineLegend.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheGraphBarColor1;
            this.labelWarmCacheFormulaEngineLegend.BorderColor = System.Drawing.Color.Black;
            this.labelWarmCacheFormulaEngineLegend.BorderHeightOffset = 2;
            this.labelWarmCacheFormulaEngineLegend.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelWarmCacheFormulaEngineLegend.BorderWidthOffset = 2;
            this.labelWarmCacheFormulaEngineLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWarmCacheFormulaEngineLegend.DrawBorder = true;
            this.labelWarmCacheFormulaEngineLegend.Location = new System.Drawing.Point(7, 57);
            this.labelWarmCacheFormulaEngineLegend.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labelWarmCacheFormulaEngineLegend.Name = "labelWarmCacheFormulaEngineLegend";
            this.labelWarmCacheFormulaEngineLegend.Size = new System.Drawing.Size(15, 16);
            this.labelWarmCacheFormulaEngineLegend.TabIndex = 16;
            // 
            // labelWarmCacheQueryDuration
            // 
            this.labelWarmCacheQueryDuration.AutoSize = true;
            this.labelWarmCacheQueryDuration.BorderColor = System.Drawing.Color.Black;
            this.labelWarmCacheQueryDuration.BorderHeightOffset = 2;
            this.labelWarmCacheQueryDuration.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelWarmCacheQueryDuration.BorderWidthOffset = 2;
            this.tableLayoutPanelWarm.SetColumnSpan(this.labelWarmCacheQueryDuration, 5);
            this.labelWarmCacheQueryDuration.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelWarmCacheQueryDuration.DrawBorder = false;
            this.labelWarmCacheQueryDuration.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarmCacheQueryDuration.Location = new System.Drawing.Point(5, 37);
            this.labelWarmCacheQueryDuration.Name = "labelWarmCacheQueryDuration";
            this.labelWarmCacheQueryDuration.Size = new System.Drawing.Size(406, 13);
            this.labelWarmCacheQueryDuration.TabIndex = 15;
            this.labelWarmCacheQueryDuration.Text = "Query duration: {0}";
            this.labelWarmCacheQueryDuration.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelWarmCacheTitle
            // 
            this.labelWarmCacheTitle.AutoSize = true;
            this.labelWarmCacheTitle.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.tableLayoutPanelWarm.SetColumnSpan(this.labelWarmCacheTitle, 5);
            this.labelWarmCacheTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelWarmCacheTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarmCacheTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.labelWarmCacheTitle.Location = new System.Drawing.Point(7, 8);
            this.labelWarmCacheTitle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelWarmCacheTitle.Name = "labelWarmCacheTitle";
            this.labelWarmCacheTitle.Size = new System.Drawing.Size(402, 15);
            this.labelWarmCacheTitle.TabIndex = 14;
            this.labelWarmCacheTitle.Text = "WARM CACHE";
            this.labelWarmCacheTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultPresenterAnalyzerResultEngineUsageControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultPresenterAnalyzerResultEngineUsageControl";
            this.Size = new System.Drawing.Size(849, 474);
            this.panelBottom.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelCold.ResumeLayout(false);
            this.tableLayoutPanelCold.ResumeLayout(false);
            this.tableLayoutPanelCold.PerformLayout();
            this.panelColdCacheChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartColdCache)).EndInit();
            this.panelWarm.ResumeLayout(false);
            this.tableLayoutPanelWarm.ResumeLayout(false);
            this.tableLayoutPanelWarm.PerformLayout();
            this.panelWarmCacheChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartWarmCache)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        public CustomLabelControl labelWarmCacheExecutionImprovementPercentage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelCold;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCold;
        private System.Windows.Forms.Panel panelColdCacheChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColdCache;
        private CustomLabelControl labelColdCacheStorageEngineLegend;
        public CustomLabelControl labelColdCacheStorageEngineDuration;
        public CustomLabelControl labelColdCacheFormulaEngineDuration;
        public CustomLabelControl labelColdCacheFormulaEngineLegend;
        public CustomLabelControl labelColdCacheQueryDuration;
        private System.Windows.Forms.Label labelColdCacheTitle;
        private System.Windows.Forms.Panel panelWarm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWarm;
        private System.Windows.Forms.Panel panelWarmCacheChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWarmCache;
        private CustomLabelControl labelWarmCacheStorageEngineLegend;
        public CustomLabelControl labelWarmCacheStorageEngineDuration;
        public CustomLabelControl labelWarmCacheFormulaEngineDuration;
        private CustomLabelControl labelWarmCacheFormulaEngineLegend;
        public CustomLabelControl labelWarmCacheQueryDuration;
        private System.Windows.Forms.Label labelWarmCacheTitle;


    }
}
