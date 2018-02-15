namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;

    partial class ResultPresenterTraceEventsControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.panelTraceEvents = new System.Windows.Forms.Panel();
            this.splitContainerTraceEvents = new System.Windows.Forms.SplitContainer();
            this.tabControlTraceEvents = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomTabControlControl();
            this.tabPageColdCache = new System.Windows.Forms.TabPage();
            this.dataGridViewColdCache = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomDataGridViewControl();
            this.tabPageWarmCache = new System.Windows.Forms.TabPage();
            this.dataGridViewWarmCache = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomDataGridViewControl();
            this.panelPerformanceCounters = new System.Windows.Forms.Panel();
            this.panelPerformanceCountersChart = new System.Windows.Forms.Panel();
            this.chartPerformanceCounters = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTextData = new System.Windows.Forms.Panel();
            this.panelTextDataContent = new System.Windows.Forms.Panel();
            this.richTextBoxTextData = new System.Windows.Forms.RichTextBox();
            this.PanelDetailsTitle = new System.Windows.Forms.Panel();
            this.checkBoxShowPerformanceCounters = new System.Windows.Forms.CheckBox();
            this.customLabelControlDetailsTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelEventsFilters = new System.Windows.Forms.Panel();
            this.labelEventSubclass = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.comboBoxSubclass = new System.Windows.Forms.ComboBox();
            this.labelEventClass = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.panelEventsTitle = new System.Windows.Forms.Panel();
            this.customLabelTraceEventsTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxFilterControls = new System.Windows.Forms.CheckBox();
            this.panelMessageExternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageExternal = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessageInternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageInternal = new System.Windows.Forms.TableLayoutPanel();
            this.customLabelMessage = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMessageBand = new System.Windows.Forms.Panel();
            this.pictureBoxMessage = new System.Windows.Forms.PictureBox();
            this.panelTraceEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTraceEvents)).BeginInit();
            this.splitContainerTraceEvents.Panel1.SuspendLayout();
            this.splitContainerTraceEvents.Panel2.SuspendLayout();
            this.splitContainerTraceEvents.SuspendLayout();
            this.tabControlTraceEvents.SuspendLayout();
            this.tabPageColdCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColdCache)).BeginInit();
            this.tabPageWarmCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarmCache)).BeginInit();
            this.panelPerformanceCounters.SuspendLayout();
            this.panelPerformanceCountersChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformanceCounters)).BeginInit();
            this.panelTextData.SuspendLayout();
            this.panelTextDataContent.SuspendLayout();
            this.PanelDetailsTitle.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelEventsFilters.SuspendLayout();
            this.panelEventsTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMessageExternal.SuspendLayout();
            this.tableLayoutPanelMessageExternal.SuspendLayout();
            this.panelMessageInternal.SuspendLayout();
            this.tableLayoutPanelMessageInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTraceEvents
            // 
            this.panelTraceEvents.BackColor = System.Drawing.Color.White;
            this.panelTraceEvents.Controls.Add(this.splitContainerTraceEvents);
            this.panelTraceEvents.Controls.Add(this.panelTop);
            this.panelTraceEvents.Controls.Add(this.panelMessageExternal);
            this.panelTraceEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTraceEvents.Location = new System.Drawing.Point(0, 0);
            this.panelTraceEvents.Name = "panelTraceEvents";
            this.panelTraceEvents.Size = new System.Drawing.Size(923, 475);
            this.panelTraceEvents.TabIndex = 2;
            // 
            // splitContainerTraceEvents
            // 
            this.splitContainerTraceEvents.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerTraceEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTraceEvents.Location = new System.Drawing.Point(0, 127);
            this.splitContainerTraceEvents.Name = "splitContainerTraceEvents";
            this.splitContainerTraceEvents.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTraceEvents.Panel1
            // 
            this.splitContainerTraceEvents.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainerTraceEvents.Panel1.Controls.Add(this.tabControlTraceEvents);
            // 
            // splitContainerTraceEvents.Panel2
            // 
            this.splitContainerTraceEvents.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainerTraceEvents.Panel2.Controls.Add(this.panelPerformanceCounters);
            this.splitContainerTraceEvents.Panel2.Controls.Add(this.panelTextData);
            this.splitContainerTraceEvents.Panel2.Controls.Add(this.PanelDetailsTitle);
            this.splitContainerTraceEvents.Size = new System.Drawing.Size(923, 322);
            this.splitContainerTraceEvents.SplitterDistance = 194;
            this.splitContainerTraceEvents.TabIndex = 98;
            // 
            // tabControlTraceEvents
            // 
            this.tabControlTraceEvents.Controls.Add(this.tabPageColdCache);
            this.tabControlTraceEvents.Controls.Add(this.tabPageWarmCache);
            this.tabControlTraceEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTraceEvents.Location = new System.Drawing.Point(0, 0);
            this.tabControlTraceEvents.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlTraceEvents.Name = "tabControlTraceEvents";
            this.tabControlTraceEvents.SelectedIndex = 0;
            this.tabControlTraceEvents.Size = new System.Drawing.Size(923, 194);
            this.tabControlTraceEvents.TabIndex = 98;
            this.tabControlTraceEvents.SelectedIndexChanged += new System.EventHandler(this.TabControlTraceEventsSelectedIndexChanged);
            // 
            // tabPageColdCache
            // 
            this.tabPageColdCache.Controls.Add(this.dataGridViewColdCache);
            this.tabPageColdCache.Location = new System.Drawing.Point(4, 22);
            this.tabPageColdCache.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageColdCache.Name = "tabPageColdCache";
            this.tabPageColdCache.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageColdCache.Size = new System.Drawing.Size(915, 168);
            this.tabPageColdCache.TabIndex = 0;
            this.tabPageColdCache.Text = "Cold Cache";
            this.tabPageColdCache.UseVisualStyleBackColor = true;
            // 
            // dataGridViewColdCache
            // 
            this.dataGridViewColdCache.AllowUserToAddRows = false;
            this.dataGridViewColdCache.AllowUserToDeleteRows = false;
            this.dataGridViewColdCache.AllowUserToOrderColumns = true;
            this.dataGridViewColdCache.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewColdCache.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewColdCache.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewColdCache.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewColdCache.GridColor = System.Drawing.Color.Black;
            this.dataGridViewColdCache.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewColdCache.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewColdCache.Name = "dataGridViewColdCache";
            this.dataGridViewColdCache.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewColdCache.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewColdCache.RowHeadersVisible = false;
            this.dataGridViewColdCache.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewColdCache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewColdCache.Size = new System.Drawing.Size(907, 160);
            this.dataGridViewColdCache.TabIndex = 1;
            this.dataGridViewColdCache.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewCellMouseUp);
            this.dataGridViewColdCache.SelectionChanged += new System.EventHandler(this.DataGridViewSelectionChanged);
            // 
            // tabPageWarmCache
            // 
            this.tabPageWarmCache.Controls.Add(this.dataGridViewWarmCache);
            this.tabPageWarmCache.Location = new System.Drawing.Point(4, 22);
            this.tabPageWarmCache.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageWarmCache.Name = "tabPageWarmCache";
            this.tabPageWarmCache.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageWarmCache.Size = new System.Drawing.Size(915, 168);
            this.tabPageWarmCache.TabIndex = 1;
            this.tabPageWarmCache.Text = "Warm Cache";
            this.tabPageWarmCache.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWarmCache
            // 
            this.dataGridViewWarmCache.AllowUserToAddRows = false;
            this.dataGridViewWarmCache.AllowUserToDeleteRows = false;
            this.dataGridViewWarmCache.AllowUserToOrderColumns = true;
            this.dataGridViewWarmCache.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewWarmCache.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWarmCache.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWarmCache.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWarmCache.GridColor = System.Drawing.Color.Black;
            this.dataGridViewWarmCache.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewWarmCache.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewWarmCache.Name = "dataGridViewWarmCache";
            this.dataGridViewWarmCache.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWarmCache.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewWarmCache.RowHeadersVisible = false;
            this.dataGridViewWarmCache.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWarmCache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWarmCache.Size = new System.Drawing.Size(907, 160);
            this.dataGridViewWarmCache.TabIndex = 1;
            this.dataGridViewWarmCache.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewCellMouseUp);
            this.dataGridViewWarmCache.SelectionChanged += new System.EventHandler(this.DataGridViewSelectionChanged);
            // 
            // panelPerformanceCounters
            // 
            this.panelPerformanceCounters.BackColor = System.Drawing.SystemColors.Control;
            this.panelPerformanceCounters.Controls.Add(this.panelPerformanceCountersChart);
            this.panelPerformanceCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPerformanceCounters.Location = new System.Drawing.Point(0, 18);
            this.panelPerformanceCounters.Margin = new System.Windows.Forms.Padding(0);
            this.panelPerformanceCounters.Name = "panelPerformanceCounters";
            this.panelPerformanceCounters.Size = new System.Drawing.Size(923, 106);
            this.panelPerformanceCounters.TabIndex = 20;
            this.panelPerformanceCounters.Visible = false;
            // 
            // panelPerformanceCountersChart
            // 
            this.panelPerformanceCountersChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPerformanceCountersChart.Controls.Add(this.chartPerformanceCounters);
            this.panelPerformanceCountersChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPerformanceCountersChart.Location = new System.Drawing.Point(0, 0);
            this.panelPerformanceCountersChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPerformanceCountersChart.Name = "panelPerformanceCountersChart";
            this.panelPerformanceCountersChart.Size = new System.Drawing.Size(923, 106);
            this.panelPerformanceCountersChart.TabIndex = 16;
            // 
            // chartPerformanceCounters
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
            chartArea1.Name = "chartAreaPerformanceCounters";
            this.chartPerformanceCounters.ChartAreas.Add(chartArea1);
            this.chartPerformanceCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPerformanceCounters.Location = new System.Drawing.Point(0, 0);
            this.chartPerformanceCounters.Name = "chartPerformanceCounters";
            this.chartPerformanceCounters.Size = new System.Drawing.Size(921, 104);
            this.chartPerformanceCounters.TabIndex = 16;
            this.chartPerformanceCounters.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseMove);
            this.chartPerformanceCounters.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnChartMouseUp);
            // 
            // panelTextData
            // 
            this.panelTextData.BackColor = System.Drawing.SystemColors.Control;
            this.panelTextData.Controls.Add(this.panelTextDataContent);
            this.panelTextData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTextData.Location = new System.Drawing.Point(0, 18);
            this.panelTextData.Margin = new System.Windows.Forms.Padding(0);
            this.panelTextData.Name = "panelTextData";
            this.panelTextData.Size = new System.Drawing.Size(923, 106);
            this.panelTextData.TabIndex = 19;
            // 
            // panelTextDataContent
            // 
            this.panelTextDataContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTextDataContent.Controls.Add(this.richTextBoxTextData);
            this.panelTextDataContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTextDataContent.Location = new System.Drawing.Point(0, 0);
            this.panelTextDataContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelTextDataContent.Name = "panelTextDataContent";
            this.panelTextDataContent.Size = new System.Drawing.Size(923, 106);
            this.panelTextDataContent.TabIndex = 4;
            // 
            // richTextBoxTextData
            // 
            this.richTextBoxTextData.BackColor = System.Drawing.Color.White;
            this.richTextBoxTextData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxTextData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxTextData.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxTextData.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxTextData.Name = "richTextBoxTextData";
            this.richTextBoxTextData.ReadOnly = true;
            this.richTextBoxTextData.Size = new System.Drawing.Size(921, 104);
            this.richTextBoxTextData.TabIndex = 2;
            this.richTextBoxTextData.Text = "";
            this.richTextBoxTextData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxTextDataMouseUp);
            // 
            // PanelDetailsTitle
            // 
            this.PanelDetailsTitle.Controls.Add(this.checkBoxShowPerformanceCounters);
            this.PanelDetailsTitle.Controls.Add(this.customLabelControlDetailsTitle);
            this.PanelDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDetailsTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelDetailsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.PanelDetailsTitle.Name = "PanelDetailsTitle";
            this.PanelDetailsTitle.Size = new System.Drawing.Size(923, 18);
            this.PanelDetailsTitle.TabIndex = 18;
            // 
            // checkBoxShowPerformanceCounters
            // 
            this.checkBoxShowPerformanceCounters.AutoSize = true;
            this.checkBoxShowPerformanceCounters.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxShowPerformanceCounters.Location = new System.Drawing.Point(8, -2);
            this.checkBoxShowPerformanceCounters.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxShowPerformanceCounters.Name = "checkBoxShowPerformanceCounters";
            this.checkBoxShowPerformanceCounters.Size = new System.Drawing.Size(161, 17);
            this.checkBoxShowPerformanceCounters.TabIndex = 91;
            this.checkBoxShowPerformanceCounters.Text = "Show Performance Counters";
            this.checkBoxShowPerformanceCounters.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxShowPerformanceCounters.UseVisualStyleBackColor = false;
            this.checkBoxShowPerformanceCounters.CheckedChanged += new System.EventHandler(this.CheckBoxShowPerformanceCountersCheckedChanged);
            // 
            // customLabelControlDetailsTitle
            // 
            this.customLabelControlDetailsTitle.BackColor = System.Drawing.SystemColors.Control;
            this.customLabelControlDetailsTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelControlDetailsTitle.BorderHeightOffset = 2;
            this.customLabelControlDetailsTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelControlDetailsTitle.BorderWidthOffset = 2;
            this.customLabelControlDetailsTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabelControlDetailsTitle.DrawBorder = false;
            this.customLabelControlDetailsTitle.Location = new System.Drawing.Point(0, 0);
            this.customLabelControlDetailsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelControlDetailsTitle.Name = "customLabelControlDetailsTitle";
            this.customLabelControlDetailsTitle.Size = new System.Drawing.Size(923, 18);
            this.customLabelControlDetailsTitle.TabIndex = 1;
            this.customLabelControlDetailsTitle.Text = "Performance Counters related to row [{0}]:";
            this.customLabelControlDetailsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.panelEventsFilters);
            this.panelTop.Controls.Add(this.panelEventsTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(923, 127);
            this.panelTop.TabIndex = 97;
            // 
            // panelEventsFilters
            // 
            this.panelEventsFilters.Controls.Add(this.labelEventSubclass);
            this.panelEventsFilters.Controls.Add(this.comboBoxSubclass);
            this.panelEventsFilters.Controls.Add(this.labelEventClass);
            this.panelEventsFilters.Controls.Add(this.comboBoxClass);
            this.panelEventsFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEventsFilters.Location = new System.Drawing.Point(0, 48);
            this.panelEventsFilters.Name = "panelEventsFilters";
            this.panelEventsFilters.Size = new System.Drawing.Size(921, 79);
            this.panelEventsFilters.TabIndex = 1;
            this.panelEventsFilters.Visible = false;
            // 
            // labelEventSubclass
            // 
            this.labelEventSubclass.BorderColor = System.Drawing.Color.Black;
            this.labelEventSubclass.BorderHeightOffset = 2;
            this.labelEventSubclass.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelEventSubclass.BorderWidthOffset = 2;
            this.labelEventSubclass.DrawBorder = false;
            this.labelEventSubclass.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventSubclass.Location = new System.Drawing.Point(44, 41);
            this.labelEventSubclass.Margin = new System.Windows.Forms.Padding(0);
            this.labelEventSubclass.Name = "labelEventSubclass";
            this.labelEventSubclass.Size = new System.Drawing.Size(74, 26);
            this.labelEventSubclass.TabIndex = 96;
            this.labelEventSubclass.Text = "EventSubclass";
            this.labelEventSubclass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxSubclass
            // 
            this.comboBoxSubclass.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxSubclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubclass.FormattingEnabled = true;
            this.comboBoxSubclass.Location = new System.Drawing.Point(141, 44);
            this.comboBoxSubclass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSubclass.Name = "comboBoxSubclass";
            this.comboBoxSubclass.Size = new System.Drawing.Size(299, 21);
            this.comboBoxSubclass.Sorted = true;
            this.comboBoxSubclass.TabIndex = 95;
            this.comboBoxSubclass.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxTraceEventFiltersSelectionChangeCommitted);
            // 
            // labelEventClass
            // 
            this.labelEventClass.BorderColor = System.Drawing.Color.Black;
            this.labelEventClass.BorderHeightOffset = 2;
            this.labelEventClass.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelEventClass.BorderWidthOffset = 2;
            this.labelEventClass.DrawBorder = false;
            this.labelEventClass.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventClass.Location = new System.Drawing.Point(44, 10);
            this.labelEventClass.Margin = new System.Windows.Forms.Padding(0);
            this.labelEventClass.Name = "labelEventClass";
            this.labelEventClass.Size = new System.Drawing.Size(65, 26);
            this.labelEventClass.TabIndex = 92;
            this.labelEventClass.Text = "EventClass";
            this.labelEventClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(141, 13);
            this.comboBoxClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(299, 21);
            this.comboBoxClass.Sorted = true;
            this.comboBoxClass.TabIndex = 91;
            this.comboBoxClass.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxTraceEventFiltersSelectionChangeCommitted);
            // 
            // panelEventsTitle
            // 
            this.panelEventsTitle.Controls.Add(this.customLabelTraceEventsTitle);
            this.panelEventsTitle.Controls.Add(this.pictureBox1);
            this.panelEventsTitle.Controls.Add(this.checkBoxFilterControls);
            this.panelEventsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEventsTitle.Location = new System.Drawing.Point(0, 0);
            this.panelEventsTitle.Name = "panelEventsTitle";
            this.panelEventsTitle.Size = new System.Drawing.Size(921, 48);
            this.panelEventsTitle.TabIndex = 3;
            // 
            // customLabelTraceEventsTitle
            // 
            this.customLabelTraceEventsTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelTraceEventsTitle.BorderHeightOffset = 2;
            this.customLabelTraceEventsTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelTraceEventsTitle.BorderWidthOffset = 2;
            this.customLabelTraceEventsTitle.DrawBorder = false;
            this.customLabelTraceEventsTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelTraceEventsTitle.Location = new System.Drawing.Point(44, 12);
            this.customLabelTraceEventsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelTraceEventsTitle.Name = "customLabelTraceEventsTitle";
            this.customLabelTraceEventsTitle.Size = new System.Drawing.Size(74, 26);
            this.customLabelTraceEventsTitle.TabIndex = 94;
            this.customLabelTraceEventsTitle.Text = "Trace Events";
            this.customLabelTraceEventsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.Profiler_32x32;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 93;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxFilterControls
            // 
            this.checkBoxFilterControls.AutoSize = true;
            this.checkBoxFilterControls.Checked = true;
            this.checkBoxFilterControls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterControls.Location = new System.Drawing.Point(141, 17);
            this.checkBoxFilterControls.Name = "checkBoxFilterControls";
            this.checkBoxFilterControls.Size = new System.Drawing.Size(110, 17);
            this.checkBoxFilterControls.TabIndex = 90;
            this.checkBoxFilterControls.Text = "Hide filter controls";
            this.checkBoxFilterControls.UseVisualStyleBackColor = true;
            this.checkBoxFilterControls.CheckedChanged += new System.EventHandler(this.CheckBoxFilterControlsCheckedChanged);
            // 
            // panelMessageExternal
            // 
            this.panelMessageExternal.BackColor = System.Drawing.SystemColors.Control;
            this.panelMessageExternal.Controls.Add(this.tableLayoutPanelMessageExternal);
            this.panelMessageExternal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMessageExternal.Location = new System.Drawing.Point(0, 449);
            this.panelMessageExternal.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageExternal.Name = "panelMessageExternal";
            this.panelMessageExternal.Size = new System.Drawing.Size(923, 26);
            this.panelMessageExternal.TabIndex = 99;
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
            this.tableLayoutPanelMessageExternal.Size = new System.Drawing.Size(923, 26);
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
            this.panelMessageInternal.Size = new System.Drawing.Size(923, 24);
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
            this.tableLayoutPanelMessageInternal.Size = new System.Drawing.Size(921, 22);
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
            this.customLabelMessage.Size = new System.Drawing.Size(891, 18);
            this.customLabelMessage.TabIndex = 28;
            this.customLabelMessage.Text = "Total events: {0} - Filtered events: {1} - Selected events: {2}";
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
            // ResultPresenterTraceEventsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panelTraceEvents);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultPresenterTraceEventsControl";
            this.Size = new System.Drawing.Size(923, 475);
            this.panelTraceEvents.ResumeLayout(false);
            this.splitContainerTraceEvents.Panel1.ResumeLayout(false);
            this.splitContainerTraceEvents.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTraceEvents)).EndInit();
            this.splitContainerTraceEvents.ResumeLayout(false);
            this.tabControlTraceEvents.ResumeLayout(false);
            this.tabPageColdCache.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColdCache)).EndInit();
            this.tabPageWarmCache.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarmCache)).EndInit();
            this.panelPerformanceCounters.ResumeLayout(false);
            this.panelPerformanceCountersChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformanceCounters)).EndInit();
            this.panelTextData.ResumeLayout(false);
            this.panelTextDataContent.ResumeLayout(false);
            this.PanelDetailsTitle.ResumeLayout(false);
            this.PanelDetailsTitle.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelEventsFilters.ResumeLayout(false);
            this.panelEventsTitle.ResumeLayout(false);
            this.panelEventsTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMessageExternal.ResumeLayout(false);
            this.tableLayoutPanelMessageExternal.ResumeLayout(false);
            this.panelMessageInternal.ResumeLayout(false);
            this.tableLayoutPanelMessageInternal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTraceEvents;
        private System.Windows.Forms.Panel panelEventsFilters;
        private CustomLabelControl labelEventClass;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private CustomLabelControl labelEventSubclass;
        private System.Windows.Forms.ComboBox comboBoxSubclass;
        private System.Windows.Forms.Panel panelEventsTitle;
        private CustomLabelControl customLabelTraceEventsTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxFilterControls;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.SplitContainer splitContainerTraceEvents;
        private CustomTabControlControl tabControlTraceEvents;
        public System.Windows.Forms.TabPage tabPageColdCache;
        private CustomDataGridViewControl dataGridViewColdCache;
        public System.Windows.Forms.TabPage tabPageWarmCache;
        private CustomDataGridViewControl dataGridViewWarmCache;
        private System.Windows.Forms.Panel panelMessageExternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageExternal;
        private System.Windows.Forms.Panel panelMessageInternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageInternal;
        private CustomLabelControl customLabelMessage;
        private System.Windows.Forms.Panel panelMessageBand;
        private System.Windows.Forms.PictureBox pictureBoxMessage;
        private System.Windows.Forms.Panel panelPerformanceCounters;
        private System.Windows.Forms.Panel panelPerformanceCountersChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerformanceCounters;
        private System.Windows.Forms.Panel panelTextData;
        private System.Windows.Forms.Panel panelTextDataContent;
        private System.Windows.Forms.RichTextBox richTextBoxTextData;
        private System.Windows.Forms.Panel PanelDetailsTitle;
        private System.Windows.Forms.CheckBox checkBoxShowPerformanceCounters;
        private CustomLabelControl customLabelControlDetailsTitle;


    }
}
