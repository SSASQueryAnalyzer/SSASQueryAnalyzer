namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;

    partial class ResultPresenterAnalyzerResultResourceUsageControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint15 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint16 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint18 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint19 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint20 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint21 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 70D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint22 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint23 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint24 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint25 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 70D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint26 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint27 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 90D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint28 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCold = new System.Windows.Forms.TableLayoutPanel();
            this.panelColdCacheChart = new System.Windows.Forms.Panel();
            this.chartColdCache = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelColdCacheTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelWarm = new System.Windows.Forms.TableLayoutPanel();
            this.panelWarmCacheChart = new System.Windows.Forms.Panel();
            this.chartWarmCache = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelWarmCacheTitle = new System.Windows.Forms.Label();
            this.panelMessageExternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageExternal = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessageInternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageInternal = new System.Windows.Forms.TableLayoutPanel();
            this.customLabelMessage = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMessageBand = new System.Windows.Forms.Panel();
            this.pictureBoxMessage = new System.Windows.Forms.PictureBox();
            this.ColdCacheNoSelectedEventsLabel = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanelCold.SuspendLayout();
            this.panelColdCacheChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartColdCache)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanelWarm.SuspendLayout();
            this.panelWarmCacheChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWarmCache)).BeginInit();
            this.panelMessageExternal.SuspendLayout();
            this.tableLayoutPanelMessageExternal.SuspendLayout();
            this.panelMessageInternal.SuspendLayout();
            this.tableLayoutPanelMessageInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel3);
            this.splitContainer.Size = new System.Drawing.Size(849, 448);
            this.splitContainer.SplitterDistance = 425;
            this.splitContainer.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tableLayoutPanelCold);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 448);
            this.panel2.TabIndex = 0;
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
            this.tableLayoutPanelCold.Controls.Add(this.panelColdCacheChart, 1, 2);
            this.tableLayoutPanelCold.Controls.Add(this.labelColdCacheTitle, 1, 1);
            this.tableLayoutPanelCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCold.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCold.Name = "tableLayoutPanelCold";
            this.tableLayoutPanelCold.RowCount = 4;
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCold.Size = new System.Drawing.Size(423, 446);
            this.tableLayoutPanelCold.TabIndex = 1;
            // 
            // panelColdCacheChart
            // 
            this.tableLayoutPanelCold.SetColumnSpan(this.panelColdCacheChart, 5);
            this.panelColdCacheChart.Controls.Add(this.chartColdCache);
            this.panelColdCacheChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColdCacheChart.Location = new System.Drawing.Point(5, 39);
            this.panelColdCacheChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelColdCacheChart.Name = "panelColdCacheChart";
            this.panelColdCacheChart.Size = new System.Drawing.Size(412, 403);
            this.panelColdCacheChart.TabIndex = 13;
            // 
            // chartColdCache
            // 
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.IsLogarithmic = true;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.Name = "chartAreaColdCache";
            this.chartColdCache.ChartAreas.Add(chartArea3);
            this.chartColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartColdCache.Location = new System.Drawing.Point(0, 0);
            this.chartColdCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartColdCache.Name = "chartColdCache";
            series3.ChartArea = "chartAreaColdCache";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.LegendText = "#LABEL";
            series3.Name = "chartSerieColdCache";
            dataPoint15.AxisLabel = "Reads";
            dataPoint15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint15.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint15.IsValueShownAsLabel = true;
            dataPoint15.Label = "#VAL{N0}";
            dataPoint15.LabelForeColor = System.Drawing.Color.Black;
            dataPoint15.LabelFormat = "";
            dataPoint15.LegendText = "Reads";
            dataPoint16.AxisLabel = "Read KB";
            dataPoint16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint16.Color = System.Drawing.SystemColors.Window;
            dataPoint16.IsValueShownAsLabel = false;
            dataPoint16.IsVisibleInLegend = true;
            dataPoint16.Label = "#VAL{N0}";
            dataPoint16.LabelForeColor = System.Drawing.Color.Black;
            dataPoint16.LegendText = "Read KB";
            dataPoint17.AxisLabel = "Writes";
            dataPoint17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint17.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint17.IsValueShownAsLabel = true;
            dataPoint17.Label = "#VAL{N0}";
            dataPoint17.LabelForeColor = System.Drawing.Color.Black;
            dataPoint17.LegendText = "Writes";
            dataPoint18.AxisLabel = "Write KB";
            dataPoint18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint18.Color = System.Drawing.SystemColors.Window;
            dataPoint18.Label = "#VAL{N0}";
            dataPoint18.LabelForeColor = System.Drawing.Color.Black;
            dataPoint18.LegendText = "Write KB";
            dataPoint19.AxisLabel = "CPU Time MS";
            dataPoint19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint19.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint19.Label = "#VAL{N0}";
            dataPoint19.LabelForeColor = System.Drawing.Color.Black;
            dataPoint19.LegendText = "CPU Time MS";
            dataPoint20.AxisLabel = "Rows Scanned";
            dataPoint20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint20.Color = System.Drawing.SystemColors.Window;
            dataPoint20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataPoint20.IsValueShownAsLabel = true;
            dataPoint20.Label = "#VAL{N0}";
            dataPoint20.LabelForeColor = System.Drawing.Color.Black;
            dataPoint20.LegendText = "Rows Scanned";
            dataPoint21.AxisLabel = "Rows Returned";
            dataPoint21.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint21.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint21.Label = "#VAL{N0}";
            dataPoint21.LabelForeColor = System.Drawing.Color.Black;
            dataPoint21.LegendText = "Rows Returned";
            series3.Points.Add(dataPoint15);
            series3.Points.Add(dataPoint16);
            series3.Points.Add(dataPoint17);
            series3.Points.Add(dataPoint18);
            series3.Points.Add(dataPoint19);
            series3.Points.Add(dataPoint20);
            series3.Points.Add(dataPoint21);
            this.chartColdCache.Series.Add(series3);
            this.chartColdCache.Size = new System.Drawing.Size(412, 403);
            this.chartColdCache.TabIndex = 1;
            this.chartColdCache.Text = "chart1";
            this.chartColdCache.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseUp);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanelWarm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(420, 448);
            this.panel3.TabIndex = 0;
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
            this.tableLayoutPanelWarm.Controls.Add(this.panelWarmCacheChart, 1, 2);
            this.tableLayoutPanelWarm.Controls.Add(this.labelWarmCacheTitle, 1, 1);
            this.tableLayoutPanelWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWarm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelWarm.Name = "tableLayoutPanelWarm";
            this.tableLayoutPanelWarm.RowCount = 4;
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWarm.Size = new System.Drawing.Size(418, 446);
            this.tableLayoutPanelWarm.TabIndex = 2;
            // 
            // panelWarmCacheChart
            // 
            this.tableLayoutPanelWarm.SetColumnSpan(this.panelWarmCacheChart, 5);
            this.panelWarmCacheChart.Controls.Add(this.chartWarmCache);
            this.panelWarmCacheChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWarmCacheChart.Location = new System.Drawing.Point(5, 39);
            this.panelWarmCacheChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelWarmCacheChart.Name = "panelWarmCacheChart";
            this.panelWarmCacheChart.Size = new System.Drawing.Size(406, 403);
            this.panelWarmCacheChart.TabIndex = 20;
            // 
            // chartWarmCache
            // 
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.IsLogarithmic = true;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorTickMark.Enabled = false;
            chartArea4.Name = "chartAreaWarmCache";
            this.chartWarmCache.ChartAreas.Add(chartArea4);
            this.chartWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWarmCache.Location = new System.Drawing.Point(0, 0);
            this.chartWarmCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartWarmCache.Name = "chartWarmCache";
            series4.ChartArea = "chartAreaWarmCache";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.LegendText = "#LABEL";
            series4.Name = "chartSerieWarmCache";
            dataPoint22.AxisLabel = "Reads";
            dataPoint22.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint22.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint22.IsValueShownAsLabel = true;
            dataPoint22.Label = "#VAL{N0}";
            dataPoint22.LabelForeColor = System.Drawing.Color.Black;
            dataPoint22.LabelFormat = "";
            dataPoint22.LegendText = "Reads";
            dataPoint23.AxisLabel = "Read KB";
            dataPoint23.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint23.Color = System.Drawing.SystemColors.Window;
            dataPoint23.Label = "#VAL{N0}";
            dataPoint23.LabelForeColor = System.Drawing.Color.Black;
            dataPoint23.LegendText = "Read KB";
            dataPoint24.AxisLabel = "Writes";
            dataPoint24.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint24.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint24.IsValueShownAsLabel = true;
            dataPoint24.Label = "#VAL{N0}";
            dataPoint24.LabelForeColor = System.Drawing.Color.Black;
            dataPoint24.LegendText = "Writes";
            dataPoint25.AxisLabel = "Write KB";
            dataPoint25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint25.Color = System.Drawing.SystemColors.Window;
            dataPoint25.Label = "#VAL{N0}";
            dataPoint25.LabelForeColor = System.Drawing.Color.Black;
            dataPoint25.LegendText = "Write KB";
            dataPoint26.AxisLabel = "CPU Time MS";
            dataPoint26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint26.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint26.Label = "#VAL{N0}";
            dataPoint26.LabelForeColor = System.Drawing.Color.Black;
            dataPoint26.LegendText = "CPU Time MS";
            dataPoint27.AxisLabel = "Rows Scanned";
            dataPoint27.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint27.Color = System.Drawing.SystemColors.Window;
            dataPoint27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataPoint27.IsValueShownAsLabel = true;
            dataPoint27.Label = "#VAL{N0}";
            dataPoint27.LabelForeColor = System.Drawing.Color.Black;
            dataPoint27.LegendText = "Rows Scanned";
            dataPoint28.AxisLabel = "Rows Returned";
            dataPoint28.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint28.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint28.Label = "#VAL{N0}";
            dataPoint28.LabelForeColor = System.Drawing.Color.Black;
            dataPoint28.LegendText = "Rows Returned";
            series4.Points.Add(dataPoint22);
            series4.Points.Add(dataPoint23);
            series4.Points.Add(dataPoint24);
            series4.Points.Add(dataPoint25);
            series4.Points.Add(dataPoint26);
            series4.Points.Add(dataPoint27);
            series4.Points.Add(dataPoint28);
            this.chartWarmCache.Series.Add(series4);
            this.chartWarmCache.Size = new System.Drawing.Size(406, 403);
            this.chartWarmCache.TabIndex = 2;
            this.chartWarmCache.Text = "chart1";
            this.chartWarmCache.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseUp);
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
            // panelMessageExternal
            // 
            this.panelMessageExternal.BackColor = System.Drawing.SystemColors.Control;
            this.panelMessageExternal.Controls.Add(this.tableLayoutPanelMessageExternal);
            this.panelMessageExternal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMessageExternal.Location = new System.Drawing.Point(0, 448);
            this.panelMessageExternal.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageExternal.Name = "panelMessageExternal";
            this.panelMessageExternal.Size = new System.Drawing.Size(849, 26);
            this.panelMessageExternal.TabIndex = 7;
            // 
            // tableLayoutPanelMessageExternal
            // 
            this.tableLayoutPanelMessageExternal.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelMessageExternal.ColumnCount = 1;
            this.tableLayoutPanelMessageExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageExternal.Controls.Add(this.panelMessageInternal, 0, 1);
            this.tableLayoutPanelMessageExternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMessageExternal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMessageExternal.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMessageExternal.Name = "tableLayoutPanelMessageExternal";
            this.tableLayoutPanelMessageExternal.RowCount = 3;
            this.tableLayoutPanelMessageExternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageExternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageExternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageExternal.Size = new System.Drawing.Size(849, 26);
            this.tableLayoutPanelMessageExternal.TabIndex = 1;
            // 
            // panelMessageInternal
            // 
            this.panelMessageInternal.BackColor = System.Drawing.Color.White;
            this.panelMessageInternal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMessageInternal.Controls.Add(this.tableLayoutPanelMessageInternal);
            this.panelMessageInternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageInternal.Location = new System.Drawing.Point(0, 1);
            this.panelMessageInternal.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageInternal.Name = "panelMessageInternal";
            this.panelMessageInternal.Size = new System.Drawing.Size(849, 24);
            this.panelMessageInternal.TabIndex = 2;
            // 
            // tableLayoutPanelMessageInternal
            // 
            this.tableLayoutPanelMessageInternal.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelMessageInternal.ColumnCount = 6;
            this.tableLayoutPanelMessageInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelMessageInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelMessageInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelMessageInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageInternal.Controls.Add(this.customLabelMessage, 5, 2);
            this.tableLayoutPanelMessageInternal.Controls.Add(this.panelMessageBand, 3, 2);
            this.tableLayoutPanelMessageInternal.Controls.Add(this.pictureBoxMessage, 1, 2);
            this.tableLayoutPanelMessageInternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMessageInternal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMessageInternal.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMessageInternal.Name = "tableLayoutPanelMessageInternal";
            this.tableLayoutPanelMessageInternal.RowCount = 7;
            this.tableLayoutPanelMessageInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMessageInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelMessageInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMessageInternal.Size = new System.Drawing.Size(847, 22);
            this.tableLayoutPanelMessageInternal.TabIndex = 0;
            // 
            // customLabelMessage
            // 
            this.customLabelMessage.BackColor = System.Drawing.Color.White;
            this.customLabelMessage.BorderColor = System.Drawing.Color.Black;
            this.customLabelMessage.BorderHeightOffset = 2;
            this.customLabelMessage.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.customLabelMessage.BorderWidthOffset = 2;
            this.customLabelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabelMessage.DrawBorder = true;
            this.customLabelMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.customLabelMessage.ForeColor = System.Drawing.SystemColors.InfoText;
            this.customLabelMessage.Location = new System.Drawing.Point(30, 2);
            this.customLabelMessage.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelMessage.Name = "customLabelMessage";
            this.tableLayoutPanelMessageInternal.SetRowSpan(this.customLabelMessage, 3);
            this.customLabelMessage.Size = new System.Drawing.Size(817, 18);
            this.customLabelMessage.TabIndex = 28;
            this.customLabelMessage.Text = "Values (Y axes) are logarithmic.";
            this.customLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMessageBand
            // 
            this.panelMessageBand.BackColor = System.Drawing.Color.Navy;
            this.panelMessageBand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageBand.Location = new System.Drawing.Point(26, 2);
            this.panelMessageBand.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageBand.Name = "panelMessageBand";
            this.tableLayoutPanelMessageInternal.SetRowSpan(this.panelMessageBand, 3);
            this.panelMessageBand.Size = new System.Drawing.Size(2, 18);
            this.panelMessageBand.TabIndex = 4;
            // 
            // pictureBoxMessage
            // 
            this.pictureBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMessage.Location = new System.Drawing.Point(4, 2);
            this.pictureBoxMessage.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxMessage.Name = "pictureBoxMessage";
            this.tableLayoutPanelMessageInternal.SetRowSpan(this.pictureBoxMessage, 3);
            this.pictureBoxMessage.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMessage.TabIndex = 3;
            this.pictureBoxMessage.TabStop = false;
            // 
            // ColdCacheNoSelectedEventsLabel
            // 
            this.ColdCacheNoSelectedEventsLabel.BackColor = System.Drawing.SystemColors.Info;
            this.ColdCacheNoSelectedEventsLabel.BorderColor = System.Drawing.Color.Black;
            this.ColdCacheNoSelectedEventsLabel.BorderHeightOffset = 2;
            this.ColdCacheNoSelectedEventsLabel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.ColdCacheNoSelectedEventsLabel.BorderWidthOffset = 2;
            this.ColdCacheNoSelectedEventsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColdCacheNoSelectedEventsLabel.DrawBorder = true;
            this.ColdCacheNoSelectedEventsLabel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.ColdCacheNoSelectedEventsLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ColdCacheNoSelectedEventsLabel.Location = new System.Drawing.Point(0, 0);
            this.ColdCacheNoSelectedEventsLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 6);
            this.ColdCacheNoSelectedEventsLabel.Name = "ColdCacheNoSelectedEventsLabel";
            this.ColdCacheNoSelectedEventsLabel.Size = new System.Drawing.Size(847, 24);
            this.ColdCacheNoSelectedEventsLabel.TabIndex = 27;
            this.ColdCacheNoSelectedEventsLabel.Text = "INFO: Y (Values) axes are logarithmic";
            this.ColdCacheNoSelectedEventsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultPresenterAnalyzerResultResourceUsageControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelMessageExternal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultPresenterAnalyzerResultResourceUsageControl";
            this.Size = new System.Drawing.Size(849, 474);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanelCold.ResumeLayout(false);
            this.tableLayoutPanelCold.PerformLayout();
            this.panelColdCacheChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartColdCache)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanelWarm.ResumeLayout(false);
            this.tableLayoutPanelWarm.PerformLayout();
            this.panelWarmCacheChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartWarmCache)).EndInit();
            this.panelMessageExternal.ResumeLayout(false);
            this.tableLayoutPanelMessageExternal.ResumeLayout(false);
            this.panelMessageInternal.ResumeLayout(false);
            this.tableLayoutPanelMessageInternal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomLabelControl ColdCacheNoSelectedEventsLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCold;
        private System.Windows.Forms.Panel panelColdCacheChart;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartColdCache;
        private System.Windows.Forms.Label labelColdCacheTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWarm;
        private System.Windows.Forms.Panel panelWarmCacheChart;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartWarmCache;
        private System.Windows.Forms.Label labelWarmCacheTitle;
        private System.Windows.Forms.Panel panelMessageExternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageInternal;
        private System.Windows.Forms.PictureBox pictureBoxMessage;
        private System.Windows.Forms.Panel panelMessageBand;
        private CustomLabelControl customLabelMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageExternal;
        private System.Windows.Forms.Panel panelMessageInternal;





    }
}
