namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;

    partial class ResultPresenterAnalyzerResultTimelineControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelCold = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCold = new System.Windows.Forms.TableLayoutPanel();
            this.panelSelectionInfoCold = new System.Windows.Forms.Panel();
            this.labelSelectionDurationCold = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelYAxisNameCold = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelChartCold = new System.Windows.Forms.Panel();
            this.chartCold = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelTitleCold = new System.Windows.Forms.Label();
            this.tableLayoutZoomCold = new System.Windows.Forms.TableLayoutPanel();
            this.panelTimelineZoomCold = new System.Windows.Forms.Panel();
            this.buttonTimelineZoomCold = new System.Windows.Forms.Button();
            this.panelMessageExternalCold = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageExternalCold = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessageInternalCold = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageColdInternal = new System.Windows.Forms.TableLayoutPanel();
            this.customLabelMessageCold = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMessageBandCold = new System.Windows.Forms.Panel();
            this.pictureBoxMessageCold = new System.Windows.Forms.PictureBox();
            this.panelWarm = new System.Windows.Forms.Panel();
            this.tableLayoutPanelWarm = new System.Windows.Forms.TableLayoutPanel();
            this.panelSelectionInfoWarm = new System.Windows.Forms.Panel();
            this.labelSelectionDurationWarm = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelYAxisNameWarm = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelChartWarm = new System.Windows.Forms.Panel();
            this.chartWarm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelTitleWarm = new System.Windows.Forms.Label();
            this.tableLayoutZoomWarm = new System.Windows.Forms.TableLayoutPanel();
            this.panelTimelineZoomWarm = new System.Windows.Forms.Panel();
            this.buttonTimelineZoomWarm = new System.Windows.Forms.Button();
            this.panelMessageExternalWarm = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageExternalWarm = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessageInternalWarm = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageInternalWarm = new System.Windows.Forms.TableLayoutPanel();
            this.customLabelMessageWarm = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMessageBandWarm = new System.Windows.Forms.Panel();
            this.pictureBoxMessageWarm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelCold.SuspendLayout();
            this.tableLayoutPanelCold.SuspendLayout();
            this.panelSelectionInfoCold.SuspendLayout();
            this.panelChartCold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCold)).BeginInit();
            this.tableLayoutZoomCold.SuspendLayout();
            this.panelTimelineZoomCold.SuspendLayout();
            this.panelMessageExternalCold.SuspendLayout();
            this.tableLayoutPanelMessageExternalCold.SuspendLayout();
            this.panelMessageInternalCold.SuspendLayout();
            this.tableLayoutPanelMessageColdInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessageCold)).BeginInit();
            this.panelWarm.SuspendLayout();
            this.tableLayoutPanelWarm.SuspendLayout();
            this.panelSelectionInfoWarm.SuspendLayout();
            this.panelChartWarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWarm)).BeginInit();
            this.tableLayoutZoomWarm.SuspendLayout();
            this.panelTimelineZoomWarm.SuspendLayout();
            this.panelMessageExternalWarm.SuspendLayout();
            this.tableLayoutPanelMessageExternalWarm.SuspendLayout();
            this.panelMessageInternalWarm.SuspendLayout();
            this.tableLayoutPanelMessageInternalWarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessageWarm)).BeginInit();
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
            this.splitContainer.Panel1.Controls.Add(this.panelCold);
            this.splitContainer.Panel1.Controls.Add(this.panelMessageExternalCold);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelWarm);
            this.splitContainer.Panel2.Controls.Add(this.panelMessageExternalWarm);
            this.splitContainer.Size = new System.Drawing.Size(849, 474);
            this.splitContainer.SplitterDistance = 425;
            this.splitContainer.TabIndex = 1;
            // 
            // panelCold
            // 
            this.panelCold.BackColor = System.Drawing.Color.White;
            this.panelCold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCold.Controls.Add(this.tableLayoutPanelCold);
            this.panelCold.Controls.Add(this.tableLayoutZoomCold);
            this.panelCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCold.Location = new System.Drawing.Point(0, 0);
            this.panelCold.Name = "panelCold";
            this.panelCold.Size = new System.Drawing.Size(425, 448);
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
            this.tableLayoutPanelCold.Controls.Add(this.panelSelectionInfoCold, 1, 3);
            this.tableLayoutPanelCold.Controls.Add(this.labelYAxisNameCold, 1, 2);
            this.tableLayoutPanelCold.Controls.Add(this.panelChartCold, 1, 4);
            this.tableLayoutPanelCold.Controls.Add(this.labelTitleCold, 1, 1);
            this.tableLayoutPanelCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCold.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCold.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCold.Name = "tableLayoutPanelCold";
            this.tableLayoutPanelCold.RowCount = 6;
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelCold.Size = new System.Drawing.Size(423, 410);
            this.tableLayoutPanelCold.TabIndex = 1;
            this.tableLayoutPanelCold.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelCold_Paint);
            // 
            // panelSelectionInfoCold
            // 
            this.tableLayoutPanelCold.SetColumnSpan(this.panelSelectionInfoCold, 5);
            this.panelSelectionInfoCold.Controls.Add(this.labelSelectionDurationCold);
            this.panelSelectionInfoCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelectionInfoCold.Location = new System.Drawing.Point(5, 56);
            this.panelSelectionInfoCold.Name = "panelSelectionInfoCold";
            this.panelSelectionInfoCold.Size = new System.Drawing.Size(412, 18);
            this.panelSelectionInfoCold.TabIndex = 37;
            // 
            // labelSelectionDurationCold
            // 
            this.labelSelectionDurationCold.BackColor = System.Drawing.SystemColors.Info;
            this.labelSelectionDurationCold.BorderColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheColor;
            this.labelSelectionDurationCold.BorderHeightOffset = 2;
            this.labelSelectionDurationCold.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSelectionDurationCold.BorderWidthOffset = 2;
            this.labelSelectionDurationCold.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelSelectionDurationCold.DrawBorder = true;
            this.labelSelectionDurationCold.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectionDurationCold.ForeColor = System.Drawing.Color.Black;
            this.labelSelectionDurationCold.Location = new System.Drawing.Point(0, -2);
            this.labelSelectionDurationCold.Name = "labelSelectionDurationCold";
            this.labelSelectionDurationCold.Size = new System.Drawing.Size(412, 20);
            this.labelSelectionDurationCold.TabIndex = 35;
            this.labelSelectionDurationCold.Text = "No selection!";
            this.labelSelectionDurationCold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSelectionDurationCold.Visible = false;
            // 
            // labelYAxisNameCold
            // 
            this.labelYAxisNameCold.AutoSize = true;
            this.labelYAxisNameCold.BackColor = System.Drawing.SystemColors.Window;
            this.labelYAxisNameCold.BorderColor = System.Drawing.Color.Black;
            this.labelYAxisNameCold.BorderHeightOffset = 2;
            this.labelYAxisNameCold.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelYAxisNameCold.BorderWidthOffset = 2;
            this.tableLayoutPanelCold.SetColumnSpan(this.labelYAxisNameCold, 5);
            this.labelYAxisNameCold.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelYAxisNameCold.DrawBorder = false;
            this.labelYAxisNameCold.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYAxisNameCold.ForeColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheColor;
            this.labelYAxisNameCold.Location = new System.Drawing.Point(5, 37);
            this.labelYAxisNameCold.Name = "labelYAxisNameCold";
            this.labelYAxisNameCold.Size = new System.Drawing.Size(412, 13);
            this.labelYAxisNameCold.TabIndex = 23;
            this.labelYAxisNameCold.Text = "{0}";
            this.labelYAxisNameCold.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelChartCold
            // 
            this.tableLayoutPanelCold.SetColumnSpan(this.panelChartCold, 5);
            this.panelChartCold.Controls.Add(this.chartCold);
            this.panelChartCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChartCold.Location = new System.Drawing.Point(5, 79);
            this.panelChartCold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelChartCold.Name = "panelChartCold";
            this.panelChartCold.Size = new System.Drawing.Size(412, 324);
            this.panelChartCold.TabIndex = 13;
            // 
            // chartCold
            // 
            this.chartCold.BorderlineColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheColor;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7F);
            chartArea1.AxisX.LabelStyle.Format = "hh:mm:ss.fff";
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Yellow;
            chartArea1.Name = "linesChartAreaColdCache";
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.AlignWithChartArea = "linesChartAreaColdCache";
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Angle = -90;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7F);
            chartArea2.AxisY.LabelStyle.Format = "hh:mm:ss.fff";
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.CursorX.LineColor = System.Drawing.Color.Yellow;
            chartArea2.Name = "rangesChartAreaColdCache";
            this.chartCold.ChartAreas.Add(chartArea1);
            this.chartCold.ChartAreas.Add(chartArea2);
            this.chartCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCold.Location = new System.Drawing.Point(0, 0);
            this.chartCold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartCold.Name = "chartCold";
            this.chartCold.Size = new System.Drawing.Size(412, 324);
            this.chartCold.TabIndex = 7;
            this.chartCold.Text = "chart1";
            // 
            // labelTitleCold
            // 
            this.labelTitleCold.AutoSize = true;
            this.labelTitleCold.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheColor;
            this.tableLayoutPanelCold.SetColumnSpan(this.labelTitleCold, 5);
            this.labelTitleCold.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitleCold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleCold.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTitleCold.Location = new System.Drawing.Point(7, 8);
            this.labelTitleCold.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelTitleCold.Name = "labelTitleCold";
            this.labelTitleCold.Size = new System.Drawing.Size(408, 15);
            this.labelTitleCold.TabIndex = 1;
            this.labelTitleCold.Text = "COLD CACHE";
            this.labelTitleCold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutZoomCold
            // 
            this.tableLayoutZoomCold.BackColor = System.Drawing.Color.White;
            this.tableLayoutZoomCold.ColumnCount = 6;
            this.tableLayoutZoomCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutZoomCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutZoomCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutZoomCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutZoomCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutZoomCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutZoomCold.Controls.Add(this.panelTimelineZoomCold, 2, 0);
            this.tableLayoutZoomCold.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutZoomCold.Location = new System.Drawing.Point(0, 410);
            this.tableLayoutZoomCold.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutZoomCold.Name = "tableLayoutZoomCold";
            this.tableLayoutZoomCold.RowCount = 1;
            this.tableLayoutZoomCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutZoomCold.Size = new System.Drawing.Size(423, 36);
            this.tableLayoutZoomCold.TabIndex = 2;
            this.tableLayoutZoomCold.Visible = false;
            // 
            // panelTimelineZoomCold
            // 
            this.panelTimelineZoomCold.BackColor = System.Drawing.Color.White;
            this.tableLayoutZoomCold.SetColumnSpan(this.panelTimelineZoomCold, 2);
            this.panelTimelineZoomCold.Controls.Add(this.buttonTimelineZoomCold);
            this.panelTimelineZoomCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTimelineZoomCold.Location = new System.Drawing.Point(22, 0);
            this.panelTimelineZoomCold.Margin = new System.Windows.Forms.Padding(0);
            this.panelTimelineZoomCold.Name = "panelTimelineZoomCold";
            this.panelTimelineZoomCold.Size = new System.Drawing.Size(378, 36);
            this.panelTimelineZoomCold.TabIndex = 41;
            // 
            // buttonTimelineZoomCold
            // 
            this.buttonTimelineZoomCold.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheColor;
            this.buttonTimelineZoomCold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTimelineZoomCold.Location = new System.Drawing.Point(170, 0);
            this.buttonTimelineZoomCold.Name = "buttonTimelineZoomCold";
            this.buttonTimelineZoomCold.Size = new System.Drawing.Size(75, 14);
            this.buttonTimelineZoomCold.TabIndex = 1;
            this.buttonTimelineZoomCold.UseVisualStyleBackColor = false;
            // 
            // panelMessageExternalCold
            // 
            this.panelMessageExternalCold.BackColor = System.Drawing.SystemColors.Control;
            this.panelMessageExternalCold.Controls.Add(this.tableLayoutPanelMessageExternalCold);
            this.panelMessageExternalCold.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMessageExternalCold.Location = new System.Drawing.Point(0, 448);
            this.panelMessageExternalCold.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageExternalCold.Name = "panelMessageExternalCold";
            this.panelMessageExternalCold.Size = new System.Drawing.Size(425, 26);
            this.panelMessageExternalCold.TabIndex = 8;
            this.panelMessageExternalCold.Visible = false;
            // 
            // tableLayoutPanelMessageExternalCold
            // 
            this.tableLayoutPanelMessageExternalCold.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelMessageExternalCold.ColumnCount = 1;
            this.tableLayoutPanelMessageExternalCold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageExternalCold.Controls.Add(this.panelMessageInternalCold, 0, 1);
            this.tableLayoutPanelMessageExternalCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMessageExternalCold.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMessageExternalCold.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMessageExternalCold.Name = "tableLayoutPanelMessageExternalCold";
            this.tableLayoutPanelMessageExternalCold.RowCount = 3;
            this.tableLayoutPanelMessageExternalCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageExternalCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageExternalCold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageExternalCold.Size = new System.Drawing.Size(425, 26);
            this.tableLayoutPanelMessageExternalCold.TabIndex = 1;
            // 
            // panelMessageInternalCold
            // 
            this.panelMessageInternalCold.BackColor = System.Drawing.Color.White;
            this.panelMessageInternalCold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMessageInternalCold.Controls.Add(this.tableLayoutPanelMessageColdInternal);
            this.panelMessageInternalCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageInternalCold.Location = new System.Drawing.Point(0, 1);
            this.panelMessageInternalCold.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageInternalCold.Name = "panelMessageInternalCold";
            this.panelMessageInternalCold.Size = new System.Drawing.Size(425, 24);
            this.panelMessageInternalCold.TabIndex = 2;
            // 
            // tableLayoutPanelMessageColdInternal
            // 
            this.tableLayoutPanelMessageColdInternal.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelMessageColdInternal.ColumnCount = 6;
            this.tableLayoutPanelMessageColdInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageColdInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelMessageColdInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageColdInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelMessageColdInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelMessageColdInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageColdInternal.Controls.Add(this.customLabelMessageCold, 5, 2);
            this.tableLayoutPanelMessageColdInternal.Controls.Add(this.panelMessageBandCold, 3, 2);
            this.tableLayoutPanelMessageColdInternal.Controls.Add(this.pictureBoxMessageCold, 1, 2);
            this.tableLayoutPanelMessageColdInternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMessageColdInternal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMessageColdInternal.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMessageColdInternal.Name = "tableLayoutPanelMessageColdInternal";
            this.tableLayoutPanelMessageColdInternal.RowCount = 7;
            this.tableLayoutPanelMessageColdInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMessageColdInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageColdInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageColdInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelMessageColdInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageColdInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageColdInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMessageColdInternal.Size = new System.Drawing.Size(423, 22);
            this.tableLayoutPanelMessageColdInternal.TabIndex = 0;
            // 
            // customLabelMessageCold
            // 
            this.customLabelMessageCold.BackColor = System.Drawing.Color.White;
            this.customLabelMessageCold.BorderColor = System.Drawing.Color.Black;
            this.customLabelMessageCold.BorderHeightOffset = 2;
            this.customLabelMessageCold.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.customLabelMessageCold.BorderWidthOffset = 2;
            this.customLabelMessageCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabelMessageCold.DrawBorder = true;
            this.customLabelMessageCold.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.customLabelMessageCold.ForeColor = System.Drawing.SystemColors.InfoText;
            this.customLabelMessageCold.Location = new System.Drawing.Point(30, 2);
            this.customLabelMessageCold.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelMessageCold.Name = "customLabelMessageCold";
            this.tableLayoutPanelMessageColdInternal.SetRowSpan(this.customLabelMessageCold, 3);
            this.customLabelMessageCold.Size = new System.Drawing.Size(393, 18);
            this.customLabelMessageCold.TabIndex = 28;
            this.customLabelMessageCold.Text = "Zoom mode activated.";
            this.customLabelMessageCold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMessageBandCold
            // 
            this.panelMessageBandCold.BackColor = System.Drawing.Color.Navy;
            this.panelMessageBandCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageBandCold.Location = new System.Drawing.Point(26, 2);
            this.panelMessageBandCold.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageBandCold.Name = "panelMessageBandCold";
            this.tableLayoutPanelMessageColdInternal.SetRowSpan(this.panelMessageBandCold, 3);
            this.panelMessageBandCold.Size = new System.Drawing.Size(2, 18);
            this.panelMessageBandCold.TabIndex = 4;
            // 
            // pictureBoxMessageCold
            // 
            this.pictureBoxMessageCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMessageCold.Location = new System.Drawing.Point(4, 2);
            this.pictureBoxMessageCold.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxMessageCold.Name = "pictureBoxMessageCold";
            this.tableLayoutPanelMessageColdInternal.SetRowSpan(this.pictureBoxMessageCold, 3);
            this.pictureBoxMessageCold.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxMessageCold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMessageCold.TabIndex = 3;
            this.pictureBoxMessageCold.TabStop = false;
            // 
            // panelWarm
            // 
            this.panelWarm.BackColor = System.Drawing.Color.White;
            this.panelWarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWarm.Controls.Add(this.tableLayoutPanelWarm);
            this.panelWarm.Controls.Add(this.tableLayoutZoomWarm);
            this.panelWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWarm.Location = new System.Drawing.Point(0, 0);
            this.panelWarm.Name = "panelWarm";
            this.panelWarm.Size = new System.Drawing.Size(420, 448);
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
            this.tableLayoutPanelWarm.Controls.Add(this.panelSelectionInfoWarm, 1, 3);
            this.tableLayoutPanelWarm.Controls.Add(this.labelYAxisNameWarm, 1, 2);
            this.tableLayoutPanelWarm.Controls.Add(this.panelChartWarm, 1, 4);
            this.tableLayoutPanelWarm.Controls.Add(this.labelTitleWarm, 1, 1);
            this.tableLayoutPanelWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWarm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelWarm.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelWarm.Name = "tableLayoutPanelWarm";
            this.tableLayoutPanelWarm.RowCount = 6;
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelWarm.Size = new System.Drawing.Size(418, 410);
            this.tableLayoutPanelWarm.TabIndex = 2;
            this.tableLayoutPanelWarm.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelWarm_Paint);
            // 
            // panelSelectionInfoWarm
            // 
            this.tableLayoutPanelWarm.SetColumnSpan(this.panelSelectionInfoWarm, 5);
            this.panelSelectionInfoWarm.Controls.Add(this.labelSelectionDurationWarm);
            this.panelSelectionInfoWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelectionInfoWarm.Location = new System.Drawing.Point(5, 56);
            this.panelSelectionInfoWarm.Name = "panelSelectionInfoWarm";
            this.panelSelectionInfoWarm.Size = new System.Drawing.Size(406, 18);
            this.panelSelectionInfoWarm.TabIndex = 40;
            // 
            // labelSelectionDurationWarm
            // 
            this.labelSelectionDurationWarm.BackColor = System.Drawing.SystemColors.Info;
            this.labelSelectionDurationWarm.BorderColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.labelSelectionDurationWarm.BorderHeightOffset = 2;
            this.labelSelectionDurationWarm.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSelectionDurationWarm.BorderWidthOffset = 2;
            this.labelSelectionDurationWarm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelSelectionDurationWarm.DrawBorder = true;
            this.labelSelectionDurationWarm.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectionDurationWarm.ForeColor = System.Drawing.Color.Black;
            this.labelSelectionDurationWarm.Location = new System.Drawing.Point(0, -2);
            this.labelSelectionDurationWarm.Name = "labelSelectionDurationWarm";
            this.labelSelectionDurationWarm.Size = new System.Drawing.Size(406, 20);
            this.labelSelectionDurationWarm.TabIndex = 35;
            this.labelSelectionDurationWarm.Text = "No selection!";
            this.labelSelectionDurationWarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSelectionDurationWarm.Visible = false;
            // 
            // labelYAxisNameWarm
            // 
            this.labelYAxisNameWarm.AutoSize = true;
            this.labelYAxisNameWarm.BackColor = System.Drawing.SystemColors.Window;
            this.labelYAxisNameWarm.BorderColor = System.Drawing.Color.Black;
            this.labelYAxisNameWarm.BorderHeightOffset = 2;
            this.labelYAxisNameWarm.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelYAxisNameWarm.BorderWidthOffset = 2;
            this.tableLayoutPanelWarm.SetColumnSpan(this.labelYAxisNameWarm, 5);
            this.labelYAxisNameWarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelYAxisNameWarm.DrawBorder = false;
            this.labelYAxisNameWarm.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYAxisNameWarm.ForeColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.labelYAxisNameWarm.Location = new System.Drawing.Point(5, 37);
            this.labelYAxisNameWarm.Name = "labelYAxisNameWarm";
            this.labelYAxisNameWarm.Size = new System.Drawing.Size(406, 13);
            this.labelYAxisNameWarm.TabIndex = 24;
            this.labelYAxisNameWarm.Text = "{0}";
            this.labelYAxisNameWarm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelChartWarm
            // 
            this.tableLayoutPanelWarm.SetColumnSpan(this.panelChartWarm, 5);
            this.panelChartWarm.Controls.Add(this.chartWarm);
            this.panelChartWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChartWarm.Location = new System.Drawing.Point(5, 79);
            this.panelChartWarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelChartWarm.Name = "panelChartWarm";
            this.panelChartWarm.Size = new System.Drawing.Size(406, 324);
            this.panelChartWarm.TabIndex = 20;
            // 
            // chartWarm
            // 
            this.chartWarm.BorderlineColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            chartArea3.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Angle = -90;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7F);
            chartArea3.AxisX.LabelStyle.Format = "hh:mm:ss.fff";
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.CursorX.LineColor = System.Drawing.Color.Yellow;
            chartArea3.Name = "linesChartAreaWarmCache";
            chartArea4.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea4.AlignWithChartArea = "linesChartAreaWarmCache";
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Milliseconds;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Angle = -90;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7F);
            chartArea4.AxisY.LabelStyle.Format = "hh:mm:ss.fff";
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorTickMark.Enabled = false;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.CursorX.LineColor = System.Drawing.Color.Yellow;
            chartArea4.Name = "rangesChartAreaWarmCache";
            this.chartWarm.ChartAreas.Add(chartArea3);
            this.chartWarm.ChartAreas.Add(chartArea4);
            this.chartWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartWarm.Location = new System.Drawing.Point(0, 0);
            this.chartWarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartWarm.Name = "chartWarm";
            this.chartWarm.Size = new System.Drawing.Size(406, 324);
            this.chartWarm.TabIndex = 6;
            this.chartWarm.Text = "chartWarmCache";
            // 
            // labelTitleWarm
            // 
            this.labelTitleWarm.AutoSize = true;
            this.labelTitleWarm.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.tableLayoutPanelWarm.SetColumnSpan(this.labelTitleWarm, 5);
            this.labelTitleWarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitleWarm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleWarm.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTitleWarm.Location = new System.Drawing.Point(7, 8);
            this.labelTitleWarm.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelTitleWarm.Name = "labelTitleWarm";
            this.labelTitleWarm.Size = new System.Drawing.Size(402, 15);
            this.labelTitleWarm.TabIndex = 14;
            this.labelTitleWarm.Text = "WARM CACHE";
            this.labelTitleWarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutZoomWarm
            // 
            this.tableLayoutZoomWarm.BackColor = System.Drawing.Color.White;
            this.tableLayoutZoomWarm.ColumnCount = 6;
            this.tableLayoutZoomWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutZoomWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutZoomWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutZoomWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutZoomWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutZoomWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutZoomWarm.Controls.Add(this.panelTimelineZoomWarm, 2, 0);
            this.tableLayoutZoomWarm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutZoomWarm.Location = new System.Drawing.Point(0, 410);
            this.tableLayoutZoomWarm.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutZoomWarm.Name = "tableLayoutZoomWarm";
            this.tableLayoutZoomWarm.RowCount = 1;
            this.tableLayoutZoomWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutZoomWarm.Size = new System.Drawing.Size(418, 36);
            this.tableLayoutZoomWarm.TabIndex = 10;
            this.tableLayoutZoomWarm.Visible = false;
            // 
            // panelTimelineZoomWarm
            // 
            this.tableLayoutZoomWarm.SetColumnSpan(this.panelTimelineZoomWarm, 2);
            this.panelTimelineZoomWarm.Controls.Add(this.buttonTimelineZoomWarm);
            this.panelTimelineZoomWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTimelineZoomWarm.Location = new System.Drawing.Point(22, 0);
            this.panelTimelineZoomWarm.Margin = new System.Windows.Forms.Padding(0);
            this.panelTimelineZoomWarm.Name = "panelTimelineZoomWarm";
            this.panelTimelineZoomWarm.Size = new System.Drawing.Size(374, 36);
            this.panelTimelineZoomWarm.TabIndex = 42;
            // 
            // buttonTimelineZoomWarm
            // 
            this.buttonTimelineZoomWarm.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.buttonTimelineZoomWarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTimelineZoomWarm.Location = new System.Drawing.Point(170, 0);
            this.buttonTimelineZoomWarm.Name = "buttonTimelineZoomWarm";
            this.buttonTimelineZoomWarm.Size = new System.Drawing.Size(75, 14);
            this.buttonTimelineZoomWarm.TabIndex = 2;
            this.buttonTimelineZoomWarm.Text = "button1";
            this.buttonTimelineZoomWarm.UseVisualStyleBackColor = false;
            // 
            // panelMessageExternalWarm
            // 
            this.panelMessageExternalWarm.BackColor = System.Drawing.SystemColors.Control;
            this.panelMessageExternalWarm.Controls.Add(this.tableLayoutPanelMessageExternalWarm);
            this.panelMessageExternalWarm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMessageExternalWarm.Location = new System.Drawing.Point(0, 448);
            this.panelMessageExternalWarm.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageExternalWarm.Name = "panelMessageExternalWarm";
            this.panelMessageExternalWarm.Size = new System.Drawing.Size(420, 26);
            this.panelMessageExternalWarm.TabIndex = 9;
            this.panelMessageExternalWarm.Visible = false;
            // 
            // tableLayoutPanelMessageExternalWarm
            // 
            this.tableLayoutPanelMessageExternalWarm.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelMessageExternalWarm.ColumnCount = 1;
            this.tableLayoutPanelMessageExternalWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageExternalWarm.Controls.Add(this.panelMessageInternalWarm, 0, 1);
            this.tableLayoutPanelMessageExternalWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMessageExternalWarm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMessageExternalWarm.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMessageExternalWarm.Name = "tableLayoutPanelMessageExternalWarm";
            this.tableLayoutPanelMessageExternalWarm.RowCount = 3;
            this.tableLayoutPanelMessageExternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageExternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageExternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageExternalWarm.Size = new System.Drawing.Size(420, 26);
            this.tableLayoutPanelMessageExternalWarm.TabIndex = 1;
            // 
            // panelMessageInternalWarm
            // 
            this.panelMessageInternalWarm.BackColor = System.Drawing.Color.White;
            this.panelMessageInternalWarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMessageInternalWarm.Controls.Add(this.tableLayoutPanelMessageInternalWarm);
            this.panelMessageInternalWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageInternalWarm.Location = new System.Drawing.Point(0, 1);
            this.panelMessageInternalWarm.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageInternalWarm.Name = "panelMessageInternalWarm";
            this.panelMessageInternalWarm.Size = new System.Drawing.Size(420, 24);
            this.panelMessageInternalWarm.TabIndex = 2;
            // 
            // tableLayoutPanelMessageInternalWarm
            // 
            this.tableLayoutPanelMessageInternalWarm.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelMessageInternalWarm.ColumnCount = 6;
            this.tableLayoutPanelMessageInternalWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageInternalWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelMessageInternalWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageInternalWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelMessageInternalWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanelMessageInternalWarm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMessageInternalWarm.Controls.Add(this.customLabelMessageWarm, 5, 2);
            this.tableLayoutPanelMessageInternalWarm.Controls.Add(this.panelMessageBandWarm, 3, 2);
            this.tableLayoutPanelMessageInternalWarm.Controls.Add(this.pictureBoxMessageWarm, 1, 2);
            this.tableLayoutPanelMessageInternalWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMessageInternalWarm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMessageInternalWarm.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMessageInternalWarm.Name = "tableLayoutPanelMessageInternalWarm";
            this.tableLayoutPanelMessageInternalWarm.RowCount = 7;
            this.tableLayoutPanelMessageInternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMessageInternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageInternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageInternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelMessageInternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMessageInternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMessageInternalWarm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMessageInternalWarm.Size = new System.Drawing.Size(418, 22);
            this.tableLayoutPanelMessageInternalWarm.TabIndex = 0;
            // 
            // customLabelMessageWarm
            // 
            this.customLabelMessageWarm.BackColor = System.Drawing.Color.White;
            this.customLabelMessageWarm.BorderColor = System.Drawing.Color.Black;
            this.customLabelMessageWarm.BorderHeightOffset = 2;
            this.customLabelMessageWarm.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.customLabelMessageWarm.BorderWidthOffset = 2;
            this.customLabelMessageWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabelMessageWarm.DrawBorder = true;
            this.customLabelMessageWarm.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.customLabelMessageWarm.ForeColor = System.Drawing.SystemColors.InfoText;
            this.customLabelMessageWarm.Location = new System.Drawing.Point(30, 2);
            this.customLabelMessageWarm.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelMessageWarm.Name = "customLabelMessageWarm";
            this.tableLayoutPanelMessageInternalWarm.SetRowSpan(this.customLabelMessageWarm, 3);
            this.customLabelMessageWarm.Size = new System.Drawing.Size(388, 18);
            this.customLabelMessageWarm.TabIndex = 28;
            this.customLabelMessageWarm.Text = "Zoom mode activated.";
            this.customLabelMessageWarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMessageBandWarm
            // 
            this.panelMessageBandWarm.BackColor = System.Drawing.Color.Navy;
            this.panelMessageBandWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageBandWarm.Location = new System.Drawing.Point(26, 2);
            this.panelMessageBandWarm.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageBandWarm.Name = "panelMessageBandWarm";
            this.tableLayoutPanelMessageInternalWarm.SetRowSpan(this.panelMessageBandWarm, 3);
            this.panelMessageBandWarm.Size = new System.Drawing.Size(2, 18);
            this.panelMessageBandWarm.TabIndex = 4;
            // 
            // pictureBoxMessageWarm
            // 
            this.pictureBoxMessageWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMessageWarm.Location = new System.Drawing.Point(4, 2);
            this.pictureBoxMessageWarm.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxMessageWarm.Name = "pictureBoxMessageWarm";
            this.tableLayoutPanelMessageInternalWarm.SetRowSpan(this.pictureBoxMessageWarm, 3);
            this.pictureBoxMessageWarm.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxMessageWarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMessageWarm.TabIndex = 3;
            this.pictureBoxMessageWarm.TabStop = false;
            // 
            // ResultPresenterAnalyzerResultTimelineControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultPresenterAnalyzerResultTimelineControl";
            this.Size = new System.Drawing.Size(849, 474);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelCold.ResumeLayout(false);
            this.tableLayoutPanelCold.ResumeLayout(false);
            this.tableLayoutPanelCold.PerformLayout();
            this.panelSelectionInfoCold.ResumeLayout(false);
            this.panelChartCold.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCold)).EndInit();
            this.tableLayoutZoomCold.ResumeLayout(false);
            this.panelTimelineZoomCold.ResumeLayout(false);
            this.panelMessageExternalCold.ResumeLayout(false);
            this.tableLayoutPanelMessageExternalCold.ResumeLayout(false);
            this.panelMessageInternalCold.ResumeLayout(false);
            this.tableLayoutPanelMessageColdInternal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessageCold)).EndInit();
            this.panelWarm.ResumeLayout(false);
            this.tableLayoutPanelWarm.ResumeLayout(false);
            this.tableLayoutPanelWarm.PerformLayout();
            this.panelSelectionInfoWarm.ResumeLayout(false);
            this.panelChartWarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartWarm)).EndInit();
            this.tableLayoutZoomWarm.ResumeLayout(false);
            this.panelTimelineZoomWarm.ResumeLayout(false);
            this.panelMessageExternalWarm.ResumeLayout(false);
            this.tableLayoutPanelMessageExternalWarm.ResumeLayout(false);
            this.panelMessageInternalWarm.ResumeLayout(false);
            this.tableLayoutPanelMessageInternalWarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessageWarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelCold;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCold;
        private System.Windows.Forms.Panel panelTimelineZoomCold;
        private System.Windows.Forms.Button buttonTimelineZoomCold;
        private System.Windows.Forms.Panel panelSelectionInfoCold;
        private CustomLabelControl labelSelectionDurationCold;
        private CustomLabelControl labelYAxisNameCold;
        private System.Windows.Forms.Panel panelChartCold;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartCold;
        private System.Windows.Forms.Label labelTitleCold;
        private System.Windows.Forms.Panel panelWarm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWarm;
        private System.Windows.Forms.Panel panelTimelineZoomWarm;
        private System.Windows.Forms.Button buttonTimelineZoomWarm;
        private System.Windows.Forms.Panel panelSelectionInfoWarm;
        private CustomLabelControl labelSelectionDurationWarm;
        private CustomLabelControl labelYAxisNameWarm;
        private System.Windows.Forms.Panel panelChartWarm;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartWarm;
        private System.Windows.Forms.Label labelTitleWarm;
        private System.Windows.Forms.Panel panelMessageExternalCold;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageExternalCold;
        private System.Windows.Forms.Panel panelMessageInternalCold;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageColdInternal;
        private CustomLabelControl customLabelMessageCold;
        private System.Windows.Forms.Panel panelMessageBandCold;
        private System.Windows.Forms.PictureBox pictureBoxMessageCold;
        private System.Windows.Forms.Panel panelMessageExternalWarm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageExternalWarm;
        private System.Windows.Forms.Panel panelMessageInternalWarm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageInternalWarm;
        private CustomLabelControl customLabelMessageWarm;
        private System.Windows.Forms.Panel panelMessageBandWarm;
        private System.Windows.Forms.PictureBox pictureBoxMessageWarm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutZoomCold;
        private System.Windows.Forms.TableLayoutPanel tableLayoutZoomWarm;


    }
}
