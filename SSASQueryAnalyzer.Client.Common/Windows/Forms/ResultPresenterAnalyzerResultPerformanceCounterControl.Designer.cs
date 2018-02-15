namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;

    partial class ResultPresenterAnalyzerResultPerformanceCounterControl
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1345D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 187564D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 550D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 12D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 4D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1538D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 6555D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 14277D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 7478D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 17D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint13 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 101D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint14 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1345D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint15 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint16 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 187564D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 550D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint18 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 12D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint19 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 4D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint20 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1538D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint21 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint22 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 6555D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint23 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 14277D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint24 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 7478D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint25 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 17D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint26 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 101D);
            this.panelMessageExternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageExternal = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessageInternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageInternal = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessageBand = new System.Windows.Forms.Panel();
            this.pictureBoxMessage = new System.Windows.Forms.PictureBox();
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
            this.customLabelMessage = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMessageExternal.SuspendLayout();
            this.tableLayoutPanelMessageExternal.SuspendLayout();
            this.panelMessageInternal.SuspendLayout();
            this.tableLayoutPanelMessageInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).BeginInit();
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
            this.SuspendLayout();
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
            this.panelMessageExternal.TabIndex = 8;
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
            this.splitContainer.TabIndex = 9;
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
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsLogarithmic = true;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.Name = "chartAreaColdCache";
            this.chartColdCache.ChartAreas.Add(chartArea1);
            this.chartColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartColdCache.Location = new System.Drawing.Point(0, 0);
            this.chartColdCache.Name = "chartColdCache";
            series1.ChartArea = "chartAreaColdCache";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.LegendText = "#LABEL";
            series1.Name = "chartSerieColdCache";
            dataPoint1.AxisLabel = "Memory usage KB";
            dataPoint1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint1.IsValueShownAsLabel = true;
            dataPoint1.Label = "#VAL{N0}";
            dataPoint1.LegendText = "Memory usage KB";
            dataPoint2.AxisLabel = "Cache lookups";
            dataPoint2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint2.Color = System.Drawing.SystemColors.Window;
            dataPoint2.IsValueShownAsLabel = true;
            dataPoint2.Label = "#VAL{N0}";
            dataPoint2.LegendText = "Cache lookups";
            dataPoint3.AxisLabel = "Cache inserts";
            dataPoint3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint3.IsValueShownAsLabel = true;
            dataPoint3.Label = "#VAL{N0}";
            dataPoint3.LegendText = "Cache inserts";
            dataPoint4.AxisLabel = "Cache misses";
            dataPoint4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint4.Color = System.Drawing.SystemColors.Window;
            dataPoint4.IsValueShownAsLabel = true;
            dataPoint4.Label = "#VAL{N0}";
            dataPoint4.LegendText = "Cache misses";
            dataPoint5.AxisLabel = "Cache hits";
            dataPoint5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint5.IsValueShownAsLabel = true;
            dataPoint5.Label = "#VAL{N0}";
            dataPoint5.LegendText = "Cache hits";
            dataPoint6.AxisLabel = "Flat cache insert";
            dataPoint6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint6.Color = System.Drawing.SystemColors.Window;
            dataPoint6.IsValueShownAsLabel = true;
            dataPoint6.Label = "#VAL{N0}";
            dataPoint6.LegendText = "Flat cache insert";
            dataPoint7.AxisLabel = "SE queries";
            dataPoint7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint7.IsValueShownAsLabel = true;
            dataPoint7.Label = "#VAL{N0}";
            dataPoint7.LabelForeColor = System.Drawing.Color.Black;
            dataPoint7.LegendText = "SE queries";
            dataPoint8.AxisLabel = "EXISTINGS";
            dataPoint8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint8.Color = System.Drawing.SystemColors.Window;
            dataPoint8.IsValueShownAsLabel = true;
            dataPoint8.Label = "#VAL{N0}";
            dataPoint8.LabelForeColor = System.Drawing.Color.Black;
            dataPoint8.LegendText = "EXISTINGS";
            dataPoint9.AxisLabel = "Autoexists";
            dataPoint9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint9.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint9.IsValueShownAsLabel = true;
            dataPoint9.Label = "#VAL{N0}";
            dataPoint9.LabelForeColor = System.Drawing.Color.Black;
            dataPoint9.LegendText = "Autoexists";
            dataPoint10.AxisLabel = "NON EMPTYs";
            dataPoint10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint10.Color = System.Drawing.SystemColors.Window;
            dataPoint10.IsValueShownAsLabel = true;
            dataPoint10.Label = "#VAL{N0}";
            dataPoint10.LabelForeColor = System.Drawing.Color.Black;
            dataPoint10.LegendText = "NON EMPTYs";
            dataPoint11.AxisLabel = "Sonar subcubes";
            dataPoint11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint11.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataPoint11.IsValueShownAsLabel = true;
            dataPoint11.Label = "#VAL{N0}";
            dataPoint11.LabelForeColor = System.Drawing.Color.Black;
            dataPoint11.LegendText = "Sonar subcubes";
            dataPoint12.AxisLabel = "Cells calculated";
            dataPoint12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint12.Color = System.Drawing.SystemColors.Window;
            dataPoint12.IsValueShownAsLabel = true;
            dataPoint12.Label = "#VAL{N0}";
            dataPoint12.LabelForeColor = System.Drawing.Color.Black;
            dataPoint12.LegendText = "Cells calculated";
            dataPoint13.AxisLabel = "Calc covers";
            dataPoint13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataPoint13.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataPoint13.IsValueShownAsLabel = true;
            dataPoint13.Label = "#VAL{N0}";
            dataPoint13.LabelForeColor = System.Drawing.Color.Black;
            dataPoint13.LabelFormat = "";
            dataPoint13.LegendText = "Calc covers";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.Points.Add(dataPoint7);
            series1.Points.Add(dataPoint8);
            series1.Points.Add(dataPoint9);
            series1.Points.Add(dataPoint10);
            series1.Points.Add(dataPoint11);
            series1.Points.Add(dataPoint12);
            series1.Points.Add(dataPoint13);
            this.chartColdCache.Series.Add(series1);
            this.chartColdCache.Size = new System.Drawing.Size(412, 403);
            this.chartColdCache.TabIndex = 1;
            this.chartColdCache.Text = "chartColdCache";
            this.chartColdCache.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseMove);
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
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea2.AxisX.LabelStyle.Interval = 0D;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.IsLogarithmic = true;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.Name = "chartAreaWarmCache";
            this.chartWarmCache.ChartAreas.Add(chartArea2);
            this.chartWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWarmCache.Location = new System.Drawing.Point(0, 0);
            this.chartWarmCache.Name = "chartWarmCache";
            series2.ChartArea = "chartAreaWarmCache";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.LegendText = "#LABEL";
            series2.Name = "chartSerieWarmCache";
            dataPoint14.AxisLabel = "Memory usage KB";
            dataPoint14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint14.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint14.IsValueShownAsLabel = true;
            dataPoint14.Label = "#VAL{N0}";
            dataPoint14.LegendText = "Memory usage KB";
            dataPoint15.AxisLabel = "Cache lookups";
            dataPoint15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint15.Color = System.Drawing.SystemColors.Window;
            dataPoint15.IsValueShownAsLabel = true;
            dataPoint15.Label = "#VAL{N0}";
            dataPoint15.LegendText = "Cache lookups";
            dataPoint16.AxisLabel = "Cache inserts";
            dataPoint16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint16.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint16.IsValueShownAsLabel = true;
            dataPoint16.Label = "#VAL{N0}";
            dataPoint16.LegendText = "Cache inserts";
            dataPoint17.AxisLabel = "Cache misses";
            dataPoint17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint17.Color = System.Drawing.SystemColors.Window;
            dataPoint17.IsValueShownAsLabel = true;
            dataPoint17.Label = "#VAL{N0}";
            dataPoint17.LegendText = "Cache misses";
            dataPoint18.AxisLabel = "Cache hits";
            dataPoint18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint18.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint18.IsValueShownAsLabel = true;
            dataPoint18.Label = "#VAL{N0}";
            dataPoint18.LegendText = "Cache hits";
            dataPoint19.AxisLabel = "Flat cache insert";
            dataPoint19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint19.Color = System.Drawing.SystemColors.Window;
            dataPoint19.IsValueShownAsLabel = true;
            dataPoint19.Label = "#VAL{N0}";
            dataPoint19.LegendText = "Flat cache insert";
            dataPoint20.AxisLabel = "SE queries";
            dataPoint20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint20.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint20.IsValueShownAsLabel = true;
            dataPoint20.Label = "#VAL{N0}";
            dataPoint20.LabelForeColor = System.Drawing.Color.Black;
            dataPoint20.LegendText = "SE queries";
            dataPoint21.AxisLabel = "EXISTINGS";
            dataPoint21.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint21.Color = System.Drawing.SystemColors.Window;
            dataPoint21.IsValueShownAsLabel = true;
            dataPoint21.Label = "#VAL{N0}";
            dataPoint21.LabelForeColor = System.Drawing.Color.Black;
            dataPoint21.LegendText = "EXISTINGS";
            dataPoint22.AxisLabel = "Autoexists";
            dataPoint22.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint22.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint22.IsValueShownAsLabel = true;
            dataPoint22.Label = "#VAL{N0}";
            dataPoint22.LabelForeColor = System.Drawing.Color.Black;
            dataPoint22.LegendText = "Autoexists";
            dataPoint23.AxisLabel = "NON EMPTYs";
            dataPoint23.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint23.Color = System.Drawing.SystemColors.Window;
            dataPoint23.IsValueShownAsLabel = true;
            dataPoint23.Label = "#VAL{N0}";
            dataPoint23.LabelForeColor = System.Drawing.Color.Black;
            dataPoint23.LegendText = "NON EMPTYs";
            dataPoint24.AxisLabel = "Sonar subcubes";
            dataPoint24.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint24.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataPoint24.IsValueShownAsLabel = true;
            dataPoint24.Label = "#VAL{N0}";
            dataPoint24.LabelForeColor = System.Drawing.Color.Black;
            dataPoint24.LegendText = "Sonar subcubes";
            dataPoint25.AxisLabel = "Cells calculated";
            dataPoint25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint25.Color = System.Drawing.SystemColors.Window;
            dataPoint25.IsValueShownAsLabel = true;
            dataPoint25.Label = "#VAL{N0}";
            dataPoint25.LabelForeColor = System.Drawing.Color.Black;
            dataPoint25.LegendText = "Cells calculated";
            dataPoint26.AxisLabel = "Calc covers";
            dataPoint26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataPoint26.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataPoint26.IsValueShownAsLabel = true;
            dataPoint26.Label = "#VAL{N0}";
            dataPoint26.LabelForeColor = System.Drawing.Color.Black;
            dataPoint26.LabelFormat = "";
            dataPoint26.LegendText = "Calc covers";
            series2.Points.Add(dataPoint14);
            series2.Points.Add(dataPoint15);
            series2.Points.Add(dataPoint16);
            series2.Points.Add(dataPoint17);
            series2.Points.Add(dataPoint18);
            series2.Points.Add(dataPoint19);
            series2.Points.Add(dataPoint20);
            series2.Points.Add(dataPoint21);
            series2.Points.Add(dataPoint22);
            series2.Points.Add(dataPoint23);
            series2.Points.Add(dataPoint24);
            series2.Points.Add(dataPoint25);
            series2.Points.Add(dataPoint26);
            this.chartWarmCache.Series.Add(series2);
            this.chartWarmCache.Size = new System.Drawing.Size(406, 403);
            this.chartWarmCache.TabIndex = 2;
            this.chartWarmCache.Text = "chartWarmCache";
            this.chartWarmCache.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseMove);
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
            // ResultPresenterAnalyzerResultPerformanceCounterControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelMessageExternal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultPresenterAnalyzerResultPerformanceCounterControl";
            this.Size = new System.Drawing.Size(849, 474);
            this.panelMessageExternal.ResumeLayout(false);
            this.tableLayoutPanelMessageExternal.ResumeLayout(false);
            this.panelMessageInternal.ResumeLayout(false);
            this.tableLayoutPanelMessageInternal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMessageExternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageExternal;
        private System.Windows.Forms.Panel panelMessageInternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageInternal;
        private CustomLabelControl customLabelMessage;
        private System.Windows.Forms.Panel panelMessageBand;
        private System.Windows.Forms.PictureBox pictureBoxMessage;
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



    }
}
