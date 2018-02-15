namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;

    partial class ResultPresenterExecutionInfoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultPresenterExecutionInfoControl));
            this.tabPageSQLServer = new System.Windows.Forms.TabPage();
            this.panelSQLServer = new System.Windows.Forms.Panel();
            this.tableLayoutPanelSQLServer = new System.Windows.Forms.TableLayoutPanel();
            this.labelSQLEditionValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSQLEditionTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSQLVersionValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSQLVersionTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSQLInstanceNameTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSQLInstanceNameValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.tabPageSSAS = new System.Windows.Forms.TabPage();
            this.splitContainerSSAS = new System.Windows.Forms.SplitContainer();
            this.panelSSASTop = new System.Windows.Forms.Panel();
            this.tableLayoutSSASGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.labelOperatingSystemValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelOperatingSystemTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelRAMValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelRAMTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelNumberOfCoresValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelNumberOfCoresTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASEditionTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASEditionValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASVersionValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASVersionTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelASQAAssemblyVersionTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelASQAAssemblyVersionValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASCubeValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASCubeTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASDatabaseValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASDatabaseTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASInstanceNameValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSSASInstanceNameTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMDXScript = new System.Windows.Forms.Panel();
            this.tableLayoutMDXScript = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBoxMDXScript = new System.Windows.Forms.RichTextBox();
            this.panelMDXScriptTitle = new System.Windows.Forms.Panel();
            this.customLabelMDXScript = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.pictureBoxMDXScript = new System.Windows.Forms.PictureBox();
            this.panelMDXScriptBottom = new System.Windows.Forms.Panel();
            this.panelCubeMetadata = new System.Windows.Forms.Panel();
            this.tableLayoutCubeMetadata = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewCubeMetadata = new System.Windows.Forms.TreeView();
            this.panelCubeMetadataTitle = new System.Windows.Forms.Panel();
            this.customLabelCubeMetadata = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.pictureBoxCubeMetadata = new System.Windows.Forms.PictureBox();
            this.panelCubeMetadataBottom = new System.Windows.Forms.Panel();
            this.panelIniFile = new System.Windows.Forms.Panel();
            this.tableLayoutSSASIniFile = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewIniFile = new System.Windows.Forms.TreeView();
            this.panelIniFileTitle = new System.Windows.Forms.Panel();
            this.customLabelIniFile = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.pictureBoxIniFile = new System.Windows.Forms.PictureBox();
            this.panelIniFileBottom = new System.Windows.Forms.Panel();
            this.PanelSSASDetailsTitle = new System.Windows.Forms.Panel();
            this.radioButtonShowMDXScript = new System.Windows.Forms.RadioButton();
            this.radioButtonShowCubeMetadata = new System.Windows.Forms.RadioButton();
            this.radioButtonShowIniFile = new System.Windows.Forms.RadioButton();
            this.tabPageExecution = new System.Windows.Forms.TabPage();
            this.panelExecution = new System.Windows.Forms.Panel();
            this.tableLayoutExecution = new System.Windows.Forms.TableLayoutPanel();
            this.panelExecutionInfo = new System.Windows.Forms.Panel();
            this.tableLayoutPanelExecutionInfo = new System.Windows.Forms.TableLayoutPanel();
            this.labelExecutionIDTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionTypeValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionTypeTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionEndValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionEndTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionBeginTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionBeginValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionIDValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionNameTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionNameValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelAnalysisDurationValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelExecutionDurationTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.pictureExecutionMode = new System.Windows.Forms.PictureBox();
            this.panelActivities = new System.Windows.Forms.Panel();
            this.tableLayoutPanelActivities = new System.Windows.Forms.TableLayoutPanel();
            this.labelResult_PostWarm_DataRendering = new System.Windows.Forms.Label();
            this.labelName_PostWarm_DataRendering = new System.Windows.Forms.Label();
            this.labelDurationTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelResult_Pre_EnvironmentSetup = new System.Windows.Forms.Label();
            this.labelName_Pre_EnvironmentSetup = new System.Windows.Forms.Label();
            this.labelActivityTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelResult_PostCold_DataRetrieval = new System.Windows.Forms.Label();
            this.labelName_PostCold_DataRetrieval = new System.Windows.Forms.Label();
            this.panelExecutionBandPostCold = new System.Windows.Forms.Panel();
            this.panelExecutionTaskPostCold = new System.Windows.Forms.Panel();
            this.pictureBoxExecutionPicturePostCold = new System.Windows.Forms.PictureBox();
            this.labelTitlePostCold = new System.Windows.Forms.Label();
            this.labelResult_PostWarm_DataRetrieval = new System.Windows.Forms.Label();
            this.labelName_PostWarm_DataRetrieval = new System.Windows.Forms.Label();
            this.labelResult_Warm_MetricsCalculation = new System.Windows.Forms.Label();
            this.labelResult_Warm_QueryExecution = new System.Windows.Forms.Label();
            this.labelResult_Warm_TracesStartup = new System.Windows.Forms.Label();
            this.labelName_Warm_QueryExecution = new System.Windows.Forms.Label();
            this.labelName_Warm_MetricsCalculation = new System.Windows.Forms.Label();
            this.labelName_Warm_TracesStartup = new System.Windows.Forms.Label();
            this.labelResult_Cold_QueryExecution = new System.Windows.Forms.Label();
            this.labelName_Cold_QueryExecution = new System.Windows.Forms.Label();
            this.labelResult_Cold_MetricsCalculation = new System.Windows.Forms.Label();
            this.labelName_Cold_MetricsCalculation = new System.Windows.Forms.Label();
            this.labelResult_Cold_TracesStartup = new System.Windows.Forms.Label();
            this.labelName_Cold_TracesStartup = new System.Windows.Forms.Label();
            this.labelResult_Pre_CubeScriptLoading = new System.Windows.Forms.Label();
            this.labelResult_Pre_CacheClearing = new System.Windows.Forms.Label();
            this.labelResult_Pre_QuerySyntaxValidation = new System.Windows.Forms.Label();
            this.labelName_Pre_CubeScriptLoading = new System.Windows.Forms.Label();
            this.labelName_Pre_CacheClearing = new System.Windows.Forms.Label();
            this.panelExecutionBandPostWarm = new System.Windows.Forms.Panel();
            this.panelExecutionTaskPostWarm = new System.Windows.Forms.Panel();
            this.pictureBoxExecutionPicturePostWarm = new System.Windows.Forms.PictureBox();
            this.labelTitlePostWarm = new System.Windows.Forms.Label();
            this.panelExecutionBandWarmCache = new System.Windows.Forms.Panel();
            this.panelExecutionTaskWarmCache = new System.Windows.Forms.Panel();
            this.pictureBoxExecutionPictureWarm = new System.Windows.Forms.PictureBox();
            this.labelTitleWarmCache = new System.Windows.Forms.Label();
            this.panelExecutionBandColdCache = new System.Windows.Forms.Panel();
            this.panelExecutionTaskColdCache = new System.Windows.Forms.Panel();
            this.pictureBoxExecutionPictureCold = new System.Windows.Forms.PictureBox();
            this.labelTitleColdCache = new System.Windows.Forms.Label();
            this.panelExecutionBandPre = new System.Windows.Forms.Panel();
            this.panelExecutionTaskPre = new System.Windows.Forms.Panel();
            this.pictureBoxExecutionPicturePre = new System.Windows.Forms.PictureBox();
            this.labelTitlePre = new System.Windows.Forms.Label();
            this.labelName_Pre_QuerySyntaxValidation = new System.Windows.Forms.Label();
            this.tabControlExecutionInfo = new System.Windows.Forms.TabControl();
            this.tabPageEnvironment = new System.Windows.Forms.TabPage();
            this.tabControlEnvironmentDetails = new System.Windows.Forms.TabControl();
            this.tabPageClient = new System.Windows.Forms.TabPage();
            this.panelClient = new System.Windows.Forms.Panel();
            this.tableLayoutPanelClient = new System.Windows.Forms.TableLayoutPanel();
            this.labelClientTypeTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelUserNameTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelUserNameValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelClientVersionTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelClientVersionValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelClientTypeValue = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.tabPageASQASSASAssembly = new System.Windows.Forms.TabPage();
            this.splitContainerASQAAssembly = new System.Windows.Forms.SplitContainer();
            this.panelASQAAssembly = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelASQAAssemblyVersion_ASQATab_Title = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelASQAAssemblyVersion_ASQATab_Value = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMessageExternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageExternal = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessageInternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageInternal = new System.Windows.Forms.TableLayoutPanel();
            this.customLabelMessage = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMessageBand = new System.Windows.Forms.Panel();
            this.pictureBoxMessage = new System.Windows.Forms.PictureBox();
            this.panelEngineSettings = new System.Windows.Forms.Panel();
            this.tableLayoutEngineSettings = new System.Windows.Forms.TableLayoutPanel();
            this.customLabelControlCache = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.pictureBoxCache = new System.Windows.Forms.PictureBox();
            this.groupBoxClearCacheMode = new System.Windows.Forms.GroupBox();
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem = new System.Windows.Forms.RadioButton();
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem = new System.Windows.Forms.RadioButton();
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem = new System.Windows.Forms.RadioButton();
            this.radioButtonClearCacheModeAllDatabases = new System.Windows.Forms.RadioButton();
            this.radioButtonClearCacheModeCurrentDatabase = new System.Windows.Forms.RadioButton();
            this.radioButtonClearCacheModeCurrentCube = new System.Windows.Forms.RadioButton();
            this.panelOptionalProfilerEvents = new System.Windows.Forms.Panel();
            this.tableLayoutPanelProfilerEvents = new System.Windows.Forms.TableLayoutPanel();
            this.panelProfilerEventsBottom = new System.Windows.Forms.Panel();
            this.groupBoxEventsThreshold = new System.Windows.Forms.GroupBox();
            this.numericUpDownEventsThreshold = new System.Windows.Forms.NumericUpDown();
            this.radioButtonEventsThresholdLimited = new System.Windows.Forms.RadioButton();
            this.radioButtonEventsThresholdUnlimited = new System.Windows.Forms.RadioButton();
            this.treeViewProfilerEvents = new System.Windows.Forms.TreeView();
            this.panelProfilerEventsTitle = new System.Windows.Forms.Panel();
            this.customLabelProfilerEventsTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.pictureBoxProfilerEvents = new System.Windows.Forms.PictureBox();
            this.panelOptionalPerformanceCounters = new System.Windows.Forms.Panel();
            this.tableLayoutPanelPerformanceCounters = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewPerformanceCounters = new System.Windows.Forms.TreeView();
            this.panelPerformanceCountersTitle = new System.Windows.Forms.Panel();
            this.customLabelPerformanceCountersTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.pictureBoxPerformanceCounters = new System.Windows.Forms.PictureBox();
            this.panelPerformanceCountersBottom = new System.Windows.Forms.Panel();
            this.panelSSASASQADetailsTitle = new System.Windows.Forms.Panel();
            this.radioButtonPerformanceCounters = new System.Windows.Forms.RadioButton();
            this.radioButtonProfilerEvents = new System.Windows.Forms.RadioButton();
            this.radioButtonEngine = new System.Windows.Forms.RadioButton();
            this.radioButtonClearCacheModeFileSystemOnly = new System.Windows.Forms.RadioButton();
            this.tabPageSQLServer.SuspendLayout();
            this.panelSQLServer.SuspendLayout();
            this.tableLayoutPanelSQLServer.SuspendLayout();
            this.tabPageSSAS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSSAS)).BeginInit();
            this.splitContainerSSAS.Panel1.SuspendLayout();
            this.splitContainerSSAS.Panel2.SuspendLayout();
            this.splitContainerSSAS.SuspendLayout();
            this.panelSSASTop.SuspendLayout();
            this.tableLayoutSSASGeneral.SuspendLayout();
            this.panelMDXScript.SuspendLayout();
            this.tableLayoutMDXScript.SuspendLayout();
            this.panelMDXScriptTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMDXScript)).BeginInit();
            this.panelCubeMetadata.SuspendLayout();
            this.tableLayoutCubeMetadata.SuspendLayout();
            this.panelCubeMetadataTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCubeMetadata)).BeginInit();
            this.panelIniFile.SuspendLayout();
            this.tableLayoutSSASIniFile.SuspendLayout();
            this.panelIniFileTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIniFile)).BeginInit();
            this.PanelSSASDetailsTitle.SuspendLayout();
            this.tabPageExecution.SuspendLayout();
            this.panelExecution.SuspendLayout();
            this.tableLayoutExecution.SuspendLayout();
            this.panelExecutionInfo.SuspendLayout();
            this.tableLayoutPanelExecutionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureExecutionMode)).BeginInit();
            this.panelActivities.SuspendLayout();
            this.tableLayoutPanelActivities.SuspendLayout();
            this.panelExecutionTaskPostCold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePostCold)).BeginInit();
            this.panelExecutionTaskPostWarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePostWarm)).BeginInit();
            this.panelExecutionTaskWarmCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPictureWarm)).BeginInit();
            this.panelExecutionTaskColdCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPictureCold)).BeginInit();
            this.panelExecutionTaskPre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePre)).BeginInit();
            this.tabControlExecutionInfo.SuspendLayout();
            this.tabPageEnvironment.SuspendLayout();
            this.tabControlEnvironmentDetails.SuspendLayout();
            this.tabPageClient.SuspendLayout();
            this.panelClient.SuspendLayout();
            this.tableLayoutPanelClient.SuspendLayout();
            this.tabPageASQASSASAssembly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerASQAAssembly)).BeginInit();
            this.splitContainerASQAAssembly.Panel1.SuspendLayout();
            this.splitContainerASQAAssembly.Panel2.SuspendLayout();
            this.splitContainerASQAAssembly.SuspendLayout();
            this.panelASQAAssembly.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelMessageExternal.SuspendLayout();
            this.tableLayoutPanelMessageExternal.SuspendLayout();
            this.panelMessageInternal.SuspendLayout();
            this.tableLayoutPanelMessageInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).BeginInit();
            this.panelEngineSettings.SuspendLayout();
            this.tableLayoutEngineSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCache)).BeginInit();
            this.groupBoxClearCacheMode.SuspendLayout();
            this.panelOptionalProfilerEvents.SuspendLayout();
            this.tableLayoutPanelProfilerEvents.SuspendLayout();
            this.groupBoxEventsThreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEventsThreshold)).BeginInit();
            this.panelProfilerEventsTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilerEvents)).BeginInit();
            this.panelOptionalPerformanceCounters.SuspendLayout();
            this.tableLayoutPanelPerformanceCounters.SuspendLayout();
            this.panelPerformanceCountersTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerformanceCounters)).BeginInit();
            this.panelSSASASQADetailsTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageSQLServer
            // 
            this.tabPageSQLServer.Controls.Add(this.panelSQLServer);
            this.tabPageSQLServer.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQLServer.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSQLServer.Name = "tabPageSQLServer";
            this.tabPageSQLServer.Size = new System.Drawing.Size(1116, 642);
            this.tabPageSQLServer.TabIndex = 2;
            this.tabPageSQLServer.Text = "SQL Server instance";
            this.tabPageSQLServer.UseVisualStyleBackColor = true;
            // 
            // panelSQLServer
            // 
            this.panelSQLServer.BackColor = System.Drawing.Color.White;
            this.panelSQLServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSQLServer.Controls.Add(this.tableLayoutPanelSQLServer);
            this.panelSQLServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSQLServer.Location = new System.Drawing.Point(0, 0);
            this.panelSQLServer.Name = "panelSQLServer";
            this.panelSQLServer.Size = new System.Drawing.Size(1116, 642);
            this.panelSQLServer.TabIndex = 113;
            // 
            // tableLayoutPanelSQLServer
            // 
            this.tableLayoutPanelSQLServer.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelSQLServer.ColumnCount = 7;
            this.tableLayoutPanelSQLServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSQLServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelSQLServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutPanelSQLServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelSQLServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutPanelSQLServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelSQLServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSQLServer.Controls.Add(this.labelSQLEditionValue, 4, 3);
            this.tableLayoutPanelSQLServer.Controls.Add(this.labelSQLEditionTitle, 2, 3);
            this.tableLayoutPanelSQLServer.Controls.Add(this.labelSQLVersionValue, 4, 4);
            this.tableLayoutPanelSQLServer.Controls.Add(this.labelSQLVersionTitle, 2, 4);
            this.tableLayoutPanelSQLServer.Controls.Add(this.labelSQLInstanceNameTitle, 2, 2);
            this.tableLayoutPanelSQLServer.Controls.Add(this.labelSQLInstanceNameValue, 4, 2);
            this.tableLayoutPanelSQLServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSQLServer.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSQLServer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelSQLServer.Name = "tableLayoutPanelSQLServer";
            this.tableLayoutPanelSQLServer.RowCount = 7;
            this.tableLayoutPanelSQLServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelSQLServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSQLServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSQLServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSQLServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSQLServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSQLServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelSQLServer.Size = new System.Drawing.Size(1114, 640);
            this.tableLayoutPanelSQLServer.TabIndex = 112;
            // 
            // labelSQLEditionValue
            // 
            this.labelSQLEditionValue.AutoSize = true;
            this.labelSQLEditionValue.BorderColor = System.Drawing.Color.Black;
            this.labelSQLEditionValue.BorderHeightOffset = 2;
            this.labelSQLEditionValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSQLEditionValue.BorderWidthOffset = 2;
            this.labelSQLEditionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSQLEditionValue.DrawBorder = false;
            this.labelSQLEditionValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLEditionValue.Location = new System.Drawing.Point(559, 310);
            this.labelSQLEditionValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelSQLEditionValue.Name = "labelSQLEditionValue";
            this.labelSQLEditionValue.Size = new System.Drawing.Size(318, 20);
            this.labelSQLEditionValue.TabIndex = 104;
            this.labelSQLEditionValue.Text = "SQL instance edition";
            this.labelSQLEditionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSQLEditionTitle
            // 
            this.labelSQLEditionTitle.AutoSize = true;
            this.labelSQLEditionTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSQLEditionTitle.BorderHeightOffset = 2;
            this.labelSQLEditionTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSQLEditionTitle.BorderWidthOffset = 2;
            this.labelSQLEditionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSQLEditionTitle.DrawBorder = false;
            this.labelSQLEditionTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLEditionTitle.Location = new System.Drawing.Point(236, 310);
            this.labelSQLEditionTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSQLEditionTitle.Name = "labelSQLEditionTitle";
            this.labelSQLEditionTitle.Size = new System.Drawing.Size(318, 20);
            this.labelSQLEditionTitle.TabIndex = 102;
            this.labelSQLEditionTitle.Text = "Edition";
            this.labelSQLEditionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSQLVersionValue
            // 
            this.labelSQLVersionValue.AutoSize = true;
            this.labelSQLVersionValue.BorderColor = System.Drawing.Color.Black;
            this.labelSQLVersionValue.BorderHeightOffset = 2;
            this.labelSQLVersionValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSQLVersionValue.BorderWidthOffset = 2;
            this.labelSQLVersionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSQLVersionValue.DrawBorder = false;
            this.labelSQLVersionValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLVersionValue.Location = new System.Drawing.Point(559, 330);
            this.labelSQLVersionValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelSQLVersionValue.Name = "labelSQLVersionValue";
            this.labelSQLVersionValue.Size = new System.Drawing.Size(318, 20);
            this.labelSQLVersionValue.TabIndex = 99;
            this.labelSQLVersionValue.Text = "SQL instance version";
            this.labelSQLVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSQLVersionTitle
            // 
            this.labelSQLVersionTitle.AutoSize = true;
            this.labelSQLVersionTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSQLVersionTitle.BorderHeightOffset = 2;
            this.labelSQLVersionTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSQLVersionTitle.BorderWidthOffset = 2;
            this.labelSQLVersionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSQLVersionTitle.DrawBorder = false;
            this.labelSQLVersionTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLVersionTitle.Location = new System.Drawing.Point(236, 330);
            this.labelSQLVersionTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSQLVersionTitle.Name = "labelSQLVersionTitle";
            this.labelSQLVersionTitle.Size = new System.Drawing.Size(318, 20);
            this.labelSQLVersionTitle.TabIndex = 98;
            this.labelSQLVersionTitle.Text = "Version";
            this.labelSQLVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSQLInstanceNameTitle
            // 
            this.labelSQLInstanceNameTitle.AutoSize = true;
            this.labelSQLInstanceNameTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSQLInstanceNameTitle.BorderHeightOffset = 2;
            this.labelSQLInstanceNameTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSQLInstanceNameTitle.BorderWidthOffset = 2;
            this.labelSQLInstanceNameTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSQLInstanceNameTitle.DrawBorder = false;
            this.labelSQLInstanceNameTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLInstanceNameTitle.Location = new System.Drawing.Point(236, 290);
            this.labelSQLInstanceNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSQLInstanceNameTitle.Name = "labelSQLInstanceNameTitle";
            this.labelSQLInstanceNameTitle.Size = new System.Drawing.Size(318, 20);
            this.labelSQLInstanceNameTitle.TabIndex = 97;
            this.labelSQLInstanceNameTitle.Text = "Name";
            this.labelSQLInstanceNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSQLInstanceNameValue
            // 
            this.labelSQLInstanceNameValue.AutoSize = true;
            this.labelSQLInstanceNameValue.BorderColor = System.Drawing.Color.Black;
            this.labelSQLInstanceNameValue.BorderHeightOffset = 2;
            this.labelSQLInstanceNameValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSQLInstanceNameValue.BorderWidthOffset = 2;
            this.labelSQLInstanceNameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSQLInstanceNameValue.DrawBorder = false;
            this.labelSQLInstanceNameValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLInstanceNameValue.Location = new System.Drawing.Point(559, 290);
            this.labelSQLInstanceNameValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelSQLInstanceNameValue.Name = "labelSQLInstanceNameValue";
            this.labelSQLInstanceNameValue.Size = new System.Drawing.Size(318, 20);
            this.labelSQLInstanceNameValue.TabIndex = 96;
            this.labelSQLInstanceNameValue.Text = "SQL instance name";
            this.labelSQLInstanceNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageSSAS
            // 
            this.tabPageSSAS.Controls.Add(this.splitContainerSSAS);
            this.tabPageSSAS.Location = new System.Drawing.Point(4, 22);
            this.tabPageSSAS.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSSAS.Name = "tabPageSSAS";
            this.tabPageSSAS.Size = new System.Drawing.Size(1116, 642);
            this.tabPageSSAS.TabIndex = 1;
            this.tabPageSSAS.Text = "SSAS instance";
            this.tabPageSSAS.UseVisualStyleBackColor = true;
            // 
            // splitContainerSSAS
            // 
            this.splitContainerSSAS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSSAS.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSSAS.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerSSAS.Name = "splitContainerSSAS";
            this.splitContainerSSAS.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSSAS.Panel1
            // 
            this.splitContainerSSAS.Panel1.Controls.Add(this.panelSSASTop);
            // 
            // splitContainerSSAS.Panel2
            // 
            this.splitContainerSSAS.Panel2.Controls.Add(this.panelMDXScript);
            this.splitContainerSSAS.Panel2.Controls.Add(this.panelCubeMetadata);
            this.splitContainerSSAS.Panel2.Controls.Add(this.panelIniFile);
            this.splitContainerSSAS.Panel2.Controls.Add(this.PanelSSASDetailsTitle);
            this.splitContainerSSAS.Size = new System.Drawing.Size(1116, 642);
            this.splitContainerSSAS.SplitterDistance = 248;
            this.splitContainerSSAS.TabIndex = 111;
            // 
            // panelSSASTop
            // 
            this.panelSSASTop.BackColor = System.Drawing.Color.White;
            this.panelSSASTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSSASTop.Controls.Add(this.tableLayoutSSASGeneral);
            this.panelSSASTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSSASTop.Location = new System.Drawing.Point(0, 0);
            this.panelSSASTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelSSASTop.Name = "panelSSASTop";
            this.panelSSASTop.Size = new System.Drawing.Size(1116, 248);
            this.panelSSASTop.TabIndex = 112;
            // 
            // tableLayoutSSASGeneral
            // 
            this.tableLayoutSSASGeneral.BackColor = System.Drawing.Color.White;
            this.tableLayoutSSASGeneral.ColumnCount = 7;
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.Controls.Add(this.labelOperatingSystemValue, 4, 5);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelOperatingSystemTitle, 2, 5);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelRAMValue, 4, 7);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelRAMTitle, 2, 7);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelNumberOfCoresValue, 4, 6);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelNumberOfCoresTitle, 2, 6);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASEditionTitle, 2, 3);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASEditionValue, 4, 3);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASVersionValue, 4, 4);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASVersionTitle, 2, 4);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelASQAAssemblyVersionTitle, 2, 10);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelASQAAssemblyVersionValue, 4, 10);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASCubeValue, 4, 9);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASCubeTitle, 2, 9);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASDatabaseValue, 4, 8);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASDatabaseTitle, 2, 8);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASInstanceNameValue, 4, 2);
            this.tableLayoutSSASGeneral.Controls.Add(this.labelSSASInstanceNameTitle, 2, 2);
            this.tableLayoutSSASGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSSASGeneral.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutSSASGeneral.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutSSASGeneral.Name = "tableLayoutSSASGeneral";
            this.tableLayoutSSASGeneral.RowCount = 13;
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSSASGeneral.Size = new System.Drawing.Size(1114, 246);
            this.tableLayoutSSASGeneral.TabIndex = 2;
            // 
            // labelOperatingSystemValue
            // 
            this.labelOperatingSystemValue.AutoSize = true;
            this.labelOperatingSystemValue.BorderColor = System.Drawing.Color.Black;
            this.labelOperatingSystemValue.BorderHeightOffset = 2;
            this.labelOperatingSystemValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelOperatingSystemValue.BorderWidthOffset = 2;
            this.labelOperatingSystemValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOperatingSystemValue.DrawBorder = false;
            this.labelOperatingSystemValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperatingSystemValue.Location = new System.Drawing.Point(559, 93);
            this.labelOperatingSystemValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelOperatingSystemValue.Name = "labelOperatingSystemValue";
            this.labelOperatingSystemValue.Size = new System.Drawing.Size(318, 20);
            this.labelOperatingSystemValue.TabIndex = 123;
            this.labelOperatingSystemValue.Text = "Operating Sysytem";
            this.labelOperatingSystemValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOperatingSystemTitle
            // 
            this.labelOperatingSystemTitle.AutoSize = true;
            this.labelOperatingSystemTitle.BorderColor = System.Drawing.Color.Black;
            this.labelOperatingSystemTitle.BorderHeightOffset = 2;
            this.labelOperatingSystemTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelOperatingSystemTitle.BorderWidthOffset = 2;
            this.labelOperatingSystemTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOperatingSystemTitle.DrawBorder = false;
            this.labelOperatingSystemTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperatingSystemTitle.Location = new System.Drawing.Point(236, 93);
            this.labelOperatingSystemTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelOperatingSystemTitle.Name = "labelOperatingSystemTitle";
            this.labelOperatingSystemTitle.Size = new System.Drawing.Size(318, 20);
            this.labelOperatingSystemTitle.TabIndex = 122;
            this.labelOperatingSystemTitle.Text = "Operating Sysytem";
            this.labelOperatingSystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRAMValue
            // 
            this.labelRAMValue.AutoSize = true;
            this.labelRAMValue.BorderColor = System.Drawing.Color.Black;
            this.labelRAMValue.BorderHeightOffset = 2;
            this.labelRAMValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelRAMValue.BorderWidthOffset = 2;
            this.labelRAMValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRAMValue.DrawBorder = false;
            this.labelRAMValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRAMValue.Location = new System.Drawing.Point(559, 133);
            this.labelRAMValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelRAMValue.Name = "labelRAMValue";
            this.labelRAMValue.Size = new System.Drawing.Size(318, 20);
            this.labelRAMValue.TabIndex = 121;
            this.labelRAMValue.Text = "Physical RAM";
            this.labelRAMValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRAMTitle
            // 
            this.labelRAMTitle.AutoSize = true;
            this.labelRAMTitle.BorderColor = System.Drawing.Color.Black;
            this.labelRAMTitle.BorderHeightOffset = 2;
            this.labelRAMTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelRAMTitle.BorderWidthOffset = 2;
            this.labelRAMTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRAMTitle.DrawBorder = false;
            this.labelRAMTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRAMTitle.Location = new System.Drawing.Point(236, 133);
            this.labelRAMTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelRAMTitle.Name = "labelRAMTitle";
            this.labelRAMTitle.Size = new System.Drawing.Size(318, 20);
            this.labelRAMTitle.TabIndex = 120;
            this.labelRAMTitle.Text = "RAM (Kb)";
            this.labelRAMTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNumberOfCoresValue
            // 
            this.labelNumberOfCoresValue.AutoSize = true;
            this.labelNumberOfCoresValue.BorderColor = System.Drawing.Color.Black;
            this.labelNumberOfCoresValue.BorderHeightOffset = 2;
            this.labelNumberOfCoresValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelNumberOfCoresValue.BorderWidthOffset = 2;
            this.labelNumberOfCoresValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNumberOfCoresValue.DrawBorder = false;
            this.labelNumberOfCoresValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfCoresValue.Location = new System.Drawing.Point(559, 113);
            this.labelNumberOfCoresValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelNumberOfCoresValue.Name = "labelNumberOfCoresValue";
            this.labelNumberOfCoresValue.Size = new System.Drawing.Size(318, 20);
            this.labelNumberOfCoresValue.TabIndex = 119;
            this.labelNumberOfCoresValue.Text = "Number of cores";
            this.labelNumberOfCoresValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNumberOfCoresTitle
            // 
            this.labelNumberOfCoresTitle.AutoSize = true;
            this.labelNumberOfCoresTitle.BorderColor = System.Drawing.Color.Black;
            this.labelNumberOfCoresTitle.BorderHeightOffset = 2;
            this.labelNumberOfCoresTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelNumberOfCoresTitle.BorderWidthOffset = 2;
            this.labelNumberOfCoresTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNumberOfCoresTitle.DrawBorder = false;
            this.labelNumberOfCoresTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfCoresTitle.Location = new System.Drawing.Point(236, 113);
            this.labelNumberOfCoresTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelNumberOfCoresTitle.Name = "labelNumberOfCoresTitle";
            this.labelNumberOfCoresTitle.Size = new System.Drawing.Size(318, 20);
            this.labelNumberOfCoresTitle.TabIndex = 118;
            this.labelNumberOfCoresTitle.Text = "Number of logical cores";
            this.labelNumberOfCoresTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSSASEditionTitle
            // 
            this.labelSSASEditionTitle.AutoSize = true;
            this.labelSSASEditionTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSSASEditionTitle.BorderHeightOffset = 2;
            this.labelSSASEditionTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASEditionTitle.BorderWidthOffset = 2;
            this.labelSSASEditionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASEditionTitle.DrawBorder = false;
            this.labelSSASEditionTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASEditionTitle.Location = new System.Drawing.Point(236, 53);
            this.labelSSASEditionTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASEditionTitle.Name = "labelSSASEditionTitle";
            this.labelSSASEditionTitle.Size = new System.Drawing.Size(318, 20);
            this.labelSSASEditionTitle.TabIndex = 101;
            this.labelSSASEditionTitle.Text = "Edition";
            this.labelSSASEditionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSSASEditionValue
            // 
            this.labelSSASEditionValue.AutoSize = true;
            this.labelSSASEditionValue.BorderColor = System.Drawing.Color.Black;
            this.labelSSASEditionValue.BorderHeightOffset = 2;
            this.labelSSASEditionValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASEditionValue.BorderWidthOffset = 2;
            this.labelSSASEditionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASEditionValue.DrawBorder = false;
            this.labelSSASEditionValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASEditionValue.Location = new System.Drawing.Point(559, 53);
            this.labelSSASEditionValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASEditionValue.Name = "labelSSASEditionValue";
            this.labelSSASEditionValue.Size = new System.Drawing.Size(318, 20);
            this.labelSSASEditionValue.TabIndex = 100;
            this.labelSSASEditionValue.Text = "SSAS instance edition";
            this.labelSSASEditionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSSASVersionValue
            // 
            this.labelSSASVersionValue.AutoSize = true;
            this.labelSSASVersionValue.BorderColor = System.Drawing.Color.Black;
            this.labelSSASVersionValue.BorderHeightOffset = 2;
            this.labelSSASVersionValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASVersionValue.BorderWidthOffset = 2;
            this.labelSSASVersionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASVersionValue.DrawBorder = false;
            this.labelSSASVersionValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASVersionValue.Location = new System.Drawing.Point(559, 73);
            this.labelSSASVersionValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASVersionValue.Name = "labelSSASVersionValue";
            this.labelSSASVersionValue.Size = new System.Drawing.Size(318, 20);
            this.labelSSASVersionValue.TabIndex = 95;
            this.labelSSASVersionValue.Text = "SSAS Version";
            this.labelSSASVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSSASVersionTitle
            // 
            this.labelSSASVersionTitle.AutoSize = true;
            this.labelSSASVersionTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSSASVersionTitle.BorderHeightOffset = 2;
            this.labelSSASVersionTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASVersionTitle.BorderWidthOffset = 2;
            this.labelSSASVersionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASVersionTitle.DrawBorder = false;
            this.labelSSASVersionTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASVersionTitle.Location = new System.Drawing.Point(236, 73);
            this.labelSSASVersionTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASVersionTitle.Name = "labelSSASVersionTitle";
            this.labelSSASVersionTitle.Size = new System.Drawing.Size(318, 20);
            this.labelSSASVersionTitle.TabIndex = 94;
            this.labelSSASVersionTitle.Text = "Version";
            this.labelSSASVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelASQAAssemblyVersionTitle
            // 
            this.labelASQAAssemblyVersionTitle.AutoSize = true;
            this.labelASQAAssemblyVersionTitle.BorderColor = System.Drawing.Color.Black;
            this.labelASQAAssemblyVersionTitle.BorderHeightOffset = 2;
            this.labelASQAAssemblyVersionTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelASQAAssemblyVersionTitle.BorderWidthOffset = 2;
            this.labelASQAAssemblyVersionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelASQAAssemblyVersionTitle.DrawBorder = false;
            this.labelASQAAssemblyVersionTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelASQAAssemblyVersionTitle.Location = new System.Drawing.Point(236, 193);
            this.labelASQAAssemblyVersionTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelASQAAssemblyVersionTitle.Name = "labelASQAAssemblyVersionTitle";
            this.labelASQAAssemblyVersionTitle.Size = new System.Drawing.Size(318, 20);
            this.labelASQAAssemblyVersionTitle.TabIndex = 85;
            this.labelASQAAssemblyVersionTitle.Text = "ASQA SSAS Assembly version";
            this.labelASQAAssemblyVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelASQAAssemblyVersionValue
            // 
            this.labelASQAAssemblyVersionValue.AutoSize = true;
            this.labelASQAAssemblyVersionValue.BorderColor = System.Drawing.Color.Black;
            this.labelASQAAssemblyVersionValue.BorderHeightOffset = 2;
            this.labelASQAAssemblyVersionValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelASQAAssemblyVersionValue.BorderWidthOffset = 2;
            this.labelASQAAssemblyVersionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelASQAAssemblyVersionValue.DrawBorder = false;
            this.labelASQAAssemblyVersionValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelASQAAssemblyVersionValue.Location = new System.Drawing.Point(559, 193);
            this.labelASQAAssemblyVersionValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelASQAAssemblyVersionValue.Name = "labelASQAAssemblyVersionValue";
            this.labelASQAAssemblyVersionValue.Size = new System.Drawing.Size(318, 20);
            this.labelASQAAssemblyVersionValue.TabIndex = 84;
            this.labelASQAAssemblyVersionValue.Text = "ASQA SSAS Assembly version";
            this.labelASQAAssemblyVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSSASCubeValue
            // 
            this.labelSSASCubeValue.AutoSize = true;
            this.labelSSASCubeValue.BorderColor = System.Drawing.Color.Black;
            this.labelSSASCubeValue.BorderHeightOffset = 2;
            this.labelSSASCubeValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASCubeValue.BorderWidthOffset = 2;
            this.labelSSASCubeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASCubeValue.DrawBorder = false;
            this.labelSSASCubeValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASCubeValue.Location = new System.Drawing.Point(559, 173);
            this.labelSSASCubeValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASCubeValue.Name = "labelSSASCubeValue";
            this.labelSSASCubeValue.Size = new System.Drawing.Size(318, 20);
            this.labelSSASCubeValue.TabIndex = 77;
            this.labelSSASCubeValue.Text = "Cube name";
            this.labelSSASCubeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSSASCubeTitle
            // 
            this.labelSSASCubeTitle.AutoSize = true;
            this.labelSSASCubeTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSSASCubeTitle.BorderHeightOffset = 2;
            this.labelSSASCubeTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASCubeTitle.BorderWidthOffset = 2;
            this.labelSSASCubeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASCubeTitle.DrawBorder = false;
            this.labelSSASCubeTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASCubeTitle.Location = new System.Drawing.Point(236, 173);
            this.labelSSASCubeTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASCubeTitle.Name = "labelSSASCubeTitle";
            this.labelSSASCubeTitle.Size = new System.Drawing.Size(318, 20);
            this.labelSSASCubeTitle.TabIndex = 76;
            this.labelSSASCubeTitle.Text = "Cube";
            this.labelSSASCubeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSSASDatabaseValue
            // 
            this.labelSSASDatabaseValue.AutoSize = true;
            this.labelSSASDatabaseValue.BorderColor = System.Drawing.Color.Black;
            this.labelSSASDatabaseValue.BorderHeightOffset = 2;
            this.labelSSASDatabaseValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASDatabaseValue.BorderWidthOffset = 2;
            this.labelSSASDatabaseValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASDatabaseValue.DrawBorder = false;
            this.labelSSASDatabaseValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASDatabaseValue.Location = new System.Drawing.Point(559, 153);
            this.labelSSASDatabaseValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASDatabaseValue.Name = "labelSSASDatabaseValue";
            this.labelSSASDatabaseValue.Size = new System.Drawing.Size(318, 20);
            this.labelSSASDatabaseValue.TabIndex = 75;
            this.labelSSASDatabaseValue.Text = "Database name";
            this.labelSSASDatabaseValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSSASDatabaseTitle
            // 
            this.labelSSASDatabaseTitle.AutoSize = true;
            this.labelSSASDatabaseTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSSASDatabaseTitle.BorderHeightOffset = 2;
            this.labelSSASDatabaseTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASDatabaseTitle.BorderWidthOffset = 2;
            this.labelSSASDatabaseTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASDatabaseTitle.DrawBorder = false;
            this.labelSSASDatabaseTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASDatabaseTitle.Location = new System.Drawing.Point(236, 153);
            this.labelSSASDatabaseTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASDatabaseTitle.Name = "labelSSASDatabaseTitle";
            this.labelSSASDatabaseTitle.Size = new System.Drawing.Size(318, 20);
            this.labelSSASDatabaseTitle.TabIndex = 74;
            this.labelSSASDatabaseTitle.Text = "Database";
            this.labelSSASDatabaseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSSASInstanceNameValue
            // 
            this.labelSSASInstanceNameValue.AutoSize = true;
            this.labelSSASInstanceNameValue.BorderColor = System.Drawing.Color.Black;
            this.labelSSASInstanceNameValue.BorderHeightOffset = 2;
            this.labelSSASInstanceNameValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASInstanceNameValue.BorderWidthOffset = 2;
            this.labelSSASInstanceNameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASInstanceNameValue.DrawBorder = false;
            this.labelSSASInstanceNameValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASInstanceNameValue.Location = new System.Drawing.Point(559, 33);
            this.labelSSASInstanceNameValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASInstanceNameValue.Name = "labelSSASInstanceNameValue";
            this.labelSSASInstanceNameValue.Size = new System.Drawing.Size(318, 20);
            this.labelSSASInstanceNameValue.TabIndex = 69;
            this.labelSSASInstanceNameValue.Text = "SSAS instance name";
            this.labelSSASInstanceNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSSASInstanceNameTitle
            // 
            this.labelSSASInstanceNameTitle.AutoSize = true;
            this.labelSSASInstanceNameTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSSASInstanceNameTitle.BorderHeightOffset = 2;
            this.labelSSASInstanceNameTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSSASInstanceNameTitle.BorderWidthOffset = 2;
            this.labelSSASInstanceNameTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSSASInstanceNameTitle.DrawBorder = false;
            this.labelSSASInstanceNameTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSASInstanceNameTitle.Location = new System.Drawing.Point(236, 33);
            this.labelSSASInstanceNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSSASInstanceNameTitle.Name = "labelSSASInstanceNameTitle";
            this.labelSSASInstanceNameTitle.Size = new System.Drawing.Size(318, 20);
            this.labelSSASInstanceNameTitle.TabIndex = 68;
            this.labelSSASInstanceNameTitle.Text = "Name";
            this.labelSSASInstanceNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelMDXScript
            // 
            this.panelMDXScript.BackColor = System.Drawing.Color.White;
            this.panelMDXScript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMDXScript.Controls.Add(this.tableLayoutMDXScript);
            this.panelMDXScript.Controls.Add(this.panelMDXScriptTitle);
            this.panelMDXScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMDXScript.Location = new System.Drawing.Point(0, 18);
            this.panelMDXScript.Margin = new System.Windows.Forms.Padding(0);
            this.panelMDXScript.Name = "panelMDXScript";
            this.panelMDXScript.Size = new System.Drawing.Size(1116, 372);
            this.panelMDXScript.TabIndex = 90;
            this.panelMDXScript.Visible = false;
            // 
            // tableLayoutMDXScript
            // 
            this.tableLayoutMDXScript.BackColor = System.Drawing.Color.White;
            this.tableLayoutMDXScript.ColumnCount = 3;
            this.tableLayoutMDXScript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutMDXScript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMDXScript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutMDXScript.Controls.Add(this.richTextBoxMDXScript, 1, 1);
            this.tableLayoutMDXScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMDXScript.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutMDXScript.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutMDXScript.Name = "tableLayoutMDXScript";
            this.tableLayoutMDXScript.RowCount = 3;
            this.tableLayoutMDXScript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutMDXScript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMDXScript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutMDXScript.Size = new System.Drawing.Size(1114, 322);
            this.tableLayoutMDXScript.TabIndex = 2;
            // 
            // richTextBoxMDXScript
            // 
            this.richTextBoxMDXScript.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMDXScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMDXScript.Location = new System.Drawing.Point(8, 8);
            this.richTextBoxMDXScript.Name = "richTextBoxMDXScript";
            this.richTextBoxMDXScript.ReadOnly = true;
            this.richTextBoxMDXScript.Size = new System.Drawing.Size(1098, 306);
            this.richTextBoxMDXScript.TabIndex = 0;
            this.richTextBoxMDXScript.Text = "";
            this.richTextBoxMDXScript.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RichTextBoxMdxScriptMouseUp);
            // 
            // panelMDXScriptTitle
            // 
            this.panelMDXScriptTitle.Controls.Add(this.customLabelMDXScript);
            this.panelMDXScriptTitle.Controls.Add(this.pictureBoxMDXScript);
            this.panelMDXScriptTitle.Controls.Add(this.panelMDXScriptBottom);
            this.panelMDXScriptTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMDXScriptTitle.Location = new System.Drawing.Point(0, 0);
            this.panelMDXScriptTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelMDXScriptTitle.Name = "panelMDXScriptTitle";
            this.panelMDXScriptTitle.Size = new System.Drawing.Size(1114, 48);
            this.panelMDXScriptTitle.TabIndex = 101;
            // 
            // customLabelMDXScript
            // 
            this.customLabelMDXScript.AutoSize = true;
            this.customLabelMDXScript.BorderColor = System.Drawing.Color.Black;
            this.customLabelMDXScript.BorderHeightOffset = 2;
            this.customLabelMDXScript.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelMDXScript.BorderWidthOffset = 2;
            this.customLabelMDXScript.DrawBorder = false;
            this.customLabelMDXScript.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelMDXScript.Location = new System.Drawing.Point(39, 16);
            this.customLabelMDXScript.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelMDXScript.Name = "customLabelMDXScript";
            this.customLabelMDXScript.Size = new System.Drawing.Size(58, 12);
            this.customLabelMDXScript.TabIndex = 77;
            this.customLabelMDXScript.Text = "MDX script";
            this.customLabelMDXScript.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBoxMDXScript
            // 
            this.pictureBoxMDXScript.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.MDXScriptFile_32x32;
            this.pictureBoxMDXScript.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxMDXScript.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxMDXScript.Name = "pictureBoxMDXScript";
            this.pictureBoxMDXScript.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxMDXScript.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxMDXScript.TabIndex = 76;
            this.pictureBoxMDXScript.TabStop = false;
            // 
            // panelMDXScriptBottom
            // 
            this.panelMDXScriptBottom.BackColor = System.Drawing.Color.Black;
            this.panelMDXScriptBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMDXScriptBottom.Location = new System.Drawing.Point(0, 47);
            this.panelMDXScriptBottom.Name = "panelMDXScriptBottom";
            this.panelMDXScriptBottom.Size = new System.Drawing.Size(1114, 1);
            this.panelMDXScriptBottom.TabIndex = 91;
            // 
            // panelCubeMetadata
            // 
            this.panelCubeMetadata.BackColor = System.Drawing.Color.White;
            this.panelCubeMetadata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCubeMetadata.Controls.Add(this.tableLayoutCubeMetadata);
            this.panelCubeMetadata.Controls.Add(this.panelCubeMetadataTitle);
            this.panelCubeMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCubeMetadata.Location = new System.Drawing.Point(0, 18);
            this.panelCubeMetadata.Margin = new System.Windows.Forms.Padding(0);
            this.panelCubeMetadata.Name = "panelCubeMetadata";
            this.panelCubeMetadata.Size = new System.Drawing.Size(1116, 372);
            this.panelCubeMetadata.TabIndex = 89;
            this.panelCubeMetadata.Visible = false;
            // 
            // tableLayoutCubeMetadata
            // 
            this.tableLayoutCubeMetadata.BackColor = System.Drawing.Color.White;
            this.tableLayoutCubeMetadata.ColumnCount = 3;
            this.tableLayoutCubeMetadata.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutCubeMetadata.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCubeMetadata.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutCubeMetadata.Controls.Add(this.treeViewCubeMetadata, 1, 1);
            this.tableLayoutCubeMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCubeMetadata.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutCubeMetadata.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutCubeMetadata.Name = "tableLayoutCubeMetadata";
            this.tableLayoutCubeMetadata.RowCount = 3;
            this.tableLayoutCubeMetadata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutCubeMetadata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCubeMetadata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutCubeMetadata.Size = new System.Drawing.Size(1114, 322);
            this.tableLayoutCubeMetadata.TabIndex = 2;
            // 
            // treeViewCubeMetadata
            // 
            this.treeViewCubeMetadata.BackColor = System.Drawing.Color.White;
            this.treeViewCubeMetadata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewCubeMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCubeMetadata.Location = new System.Drawing.Point(8, 8);
            this.treeViewCubeMetadata.Name = "treeViewCubeMetadata";
            this.treeViewCubeMetadata.Size = new System.Drawing.Size(1098, 306);
            this.treeViewCubeMetadata.TabIndex = 1;
            // 
            // panelCubeMetadataTitle
            // 
            this.panelCubeMetadataTitle.Controls.Add(this.customLabelCubeMetadata);
            this.panelCubeMetadataTitle.Controls.Add(this.pictureBoxCubeMetadata);
            this.panelCubeMetadataTitle.Controls.Add(this.panelCubeMetadataBottom);
            this.panelCubeMetadataTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCubeMetadataTitle.Location = new System.Drawing.Point(0, 0);
            this.panelCubeMetadataTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelCubeMetadataTitle.Name = "panelCubeMetadataTitle";
            this.panelCubeMetadataTitle.Size = new System.Drawing.Size(1114, 48);
            this.panelCubeMetadataTitle.TabIndex = 102;
            // 
            // customLabelCubeMetadata
            // 
            this.customLabelCubeMetadata.AutoSize = true;
            this.customLabelCubeMetadata.BorderColor = System.Drawing.Color.Black;
            this.customLabelCubeMetadata.BorderHeightOffset = 2;
            this.customLabelCubeMetadata.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelCubeMetadata.BorderWidthOffset = 2;
            this.customLabelCubeMetadata.DrawBorder = false;
            this.customLabelCubeMetadata.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelCubeMetadata.Location = new System.Drawing.Point(39, 16);
            this.customLabelCubeMetadata.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelCubeMetadata.Name = "customLabelCubeMetadata";
            this.customLabelCubeMetadata.Size = new System.Drawing.Size(74, 12);
            this.customLabelCubeMetadata.TabIndex = 77;
            this.customLabelCubeMetadata.Text = "Cube metadata";
            this.customLabelCubeMetadata.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBoxCubeMetadata
            // 
            this.pictureBoxCubeMetadata.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.CubeMetadata_32x32;
            this.pictureBoxCubeMetadata.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxCubeMetadata.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxCubeMetadata.Name = "pictureBoxCubeMetadata";
            this.pictureBoxCubeMetadata.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxCubeMetadata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxCubeMetadata.TabIndex = 76;
            this.pictureBoxCubeMetadata.TabStop = false;
            // 
            // panelCubeMetadataBottom
            // 
            this.panelCubeMetadataBottom.BackColor = System.Drawing.Color.Black;
            this.panelCubeMetadataBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCubeMetadataBottom.Location = new System.Drawing.Point(0, 47);
            this.panelCubeMetadataBottom.Name = "panelCubeMetadataBottom";
            this.panelCubeMetadataBottom.Size = new System.Drawing.Size(1114, 1);
            this.panelCubeMetadataBottom.TabIndex = 91;
            // 
            // panelIniFile
            // 
            this.panelIniFile.BackColor = System.Drawing.Color.White;
            this.panelIniFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIniFile.Controls.Add(this.tableLayoutSSASIniFile);
            this.panelIniFile.Controls.Add(this.panelIniFileTitle);
            this.panelIniFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIniFile.Location = new System.Drawing.Point(0, 18);
            this.panelIniFile.Margin = new System.Windows.Forms.Padding(0);
            this.panelIniFile.Name = "panelIniFile";
            this.panelIniFile.Size = new System.Drawing.Size(1116, 372);
            this.panelIniFile.TabIndex = 88;
            // 
            // tableLayoutSSASIniFile
            // 
            this.tableLayoutSSASIniFile.BackColor = System.Drawing.Color.White;
            this.tableLayoutSSASIniFile.ColumnCount = 3;
            this.tableLayoutSSASIniFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutSSASIniFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSSASIniFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutSSASIniFile.Controls.Add(this.treeViewIniFile, 1, 1);
            this.tableLayoutSSASIniFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSSASIniFile.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutSSASIniFile.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutSSASIniFile.Name = "tableLayoutSSASIniFile";
            this.tableLayoutSSASIniFile.RowCount = 3;
            this.tableLayoutSSASIniFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutSSASIniFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSSASIniFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutSSASIniFile.Size = new System.Drawing.Size(1114, 322);
            this.tableLayoutSSASIniFile.TabIndex = 2;
            // 
            // treeViewIniFile
            // 
            this.treeViewIniFile.BackColor = System.Drawing.Color.White;
            this.treeViewIniFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewIniFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewIniFile.Location = new System.Drawing.Point(5, 5);
            this.treeViewIniFile.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewIniFile.Name = "treeViewIniFile";
            this.treeViewIniFile.Size = new System.Drawing.Size(1104, 312);
            this.treeViewIniFile.TabIndex = 1;
            // 
            // panelIniFileTitle
            // 
            this.panelIniFileTitle.Controls.Add(this.customLabelIniFile);
            this.panelIniFileTitle.Controls.Add(this.pictureBoxIniFile);
            this.panelIniFileTitle.Controls.Add(this.panelIniFileBottom);
            this.panelIniFileTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIniFileTitle.Location = new System.Drawing.Point(0, 0);
            this.panelIniFileTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelIniFileTitle.Name = "panelIniFileTitle";
            this.panelIniFileTitle.Size = new System.Drawing.Size(1114, 48);
            this.panelIniFileTitle.TabIndex = 103;
            // 
            // customLabelIniFile
            // 
            this.customLabelIniFile.AutoSize = true;
            this.customLabelIniFile.BorderColor = System.Drawing.Color.Black;
            this.customLabelIniFile.BorderHeightOffset = 2;
            this.customLabelIniFile.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelIniFile.BorderWidthOffset = 2;
            this.customLabelIniFile.DrawBorder = false;
            this.customLabelIniFile.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelIniFile.Location = new System.Drawing.Point(39, 16);
            this.customLabelIniFile.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelIniFile.Name = "customLabelIniFile";
            this.customLabelIniFile.Size = new System.Drawing.Size(78, 12);
            this.customLabelIniFile.TabIndex = 77;
            this.customLabelIniFile.Text = "msmdsrv.ini file";
            this.customLabelIniFile.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBoxIniFile
            // 
            this.pictureBoxIniFile.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.MsmdsrvIniFile_32x32;
            this.pictureBoxIniFile.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxIniFile.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIniFile.Name = "pictureBoxIniFile";
            this.pictureBoxIniFile.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxIniFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIniFile.TabIndex = 76;
            this.pictureBoxIniFile.TabStop = false;
            // 
            // panelIniFileBottom
            // 
            this.panelIniFileBottom.BackColor = System.Drawing.Color.Black;
            this.panelIniFileBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelIniFileBottom.Location = new System.Drawing.Point(0, 47);
            this.panelIniFileBottom.Name = "panelIniFileBottom";
            this.panelIniFileBottom.Size = new System.Drawing.Size(1114, 1);
            this.panelIniFileBottom.TabIndex = 91;
            // 
            // PanelSSASDetailsTitle
            // 
            this.PanelSSASDetailsTitle.Controls.Add(this.radioButtonShowMDXScript);
            this.PanelSSASDetailsTitle.Controls.Add(this.radioButtonShowCubeMetadata);
            this.PanelSSASDetailsTitle.Controls.Add(this.radioButtonShowIniFile);
            this.PanelSSASDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSSASDetailsTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelSSASDetailsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.PanelSSASDetailsTitle.Name = "PanelSSASDetailsTitle";
            this.PanelSSASDetailsTitle.Size = new System.Drawing.Size(1116, 18);
            this.PanelSSASDetailsTitle.TabIndex = 19;
            // 
            // radioButtonShowMDXScript
            // 
            this.radioButtonShowMDXScript.AutoSize = true;
            this.radioButtonShowMDXScript.Location = new System.Drawing.Point(300, 0);
            this.radioButtonShowMDXScript.Name = "radioButtonShowMDXScript";
            this.radioButtonShowMDXScript.Size = new System.Drawing.Size(77, 17);
            this.radioButtonShowMDXScript.TabIndex = 95;
            this.radioButtonShowMDXScript.Text = "MDX script";
            this.radioButtonShowMDXScript.UseVisualStyleBackColor = true;
            this.radioButtonShowMDXScript.Click += new System.EventHandler(this.OnRadioButtonsSSAS_Click);
            // 
            // radioButtonShowCubeMetadata
            // 
            this.radioButtonShowCubeMetadata.AutoSize = true;
            this.radioButtonShowCubeMetadata.Location = new System.Drawing.Point(140, 0);
            this.radioButtonShowCubeMetadata.Name = "radioButtonShowCubeMetadata";
            this.radioButtonShowCubeMetadata.Size = new System.Drawing.Size(97, 17);
            this.radioButtonShowCubeMetadata.TabIndex = 94;
            this.radioButtonShowCubeMetadata.Text = "Cube metadata";
            this.radioButtonShowCubeMetadata.UseVisualStyleBackColor = true;
            this.radioButtonShowCubeMetadata.Click += new System.EventHandler(this.OnRadioButtonsSSAS_Click);
            // 
            // radioButtonShowIniFile
            // 
            this.radioButtonShowIniFile.AutoSize = true;
            this.radioButtonShowIniFile.Checked = true;
            this.radioButtonShowIniFile.Location = new System.Drawing.Point(8, 0);
            this.radioButtonShowIniFile.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonShowIniFile.Name = "radioButtonShowIniFile";
            this.radioButtonShowIniFile.Size = new System.Drawing.Size(98, 17);
            this.radioButtonShowIniFile.TabIndex = 93;
            this.radioButtonShowIniFile.TabStop = true;
            this.radioButtonShowIniFile.Text = "File msmdsrv.ini";
            this.radioButtonShowIniFile.UseVisualStyleBackColor = true;
            this.radioButtonShowIniFile.Click += new System.EventHandler(this.OnRadioButtonsSSAS_Click);
            // 
            // tabPageExecution
            // 
            this.tabPageExecution.Controls.Add(this.panelExecution);
            this.tabPageExecution.Location = new System.Drawing.Point(4, 22);
            this.tabPageExecution.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageExecution.Name = "tabPageExecution";
            this.tabPageExecution.Size = new System.Drawing.Size(1130, 674);
            this.tabPageExecution.TabIndex = 0;
            this.tabPageExecution.Text = "Execution";
            this.tabPageExecution.UseVisualStyleBackColor = true;
            // 
            // panelExecution
            // 
            this.panelExecution.BackColor = System.Drawing.Color.White;
            this.panelExecution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecution.Controls.Add(this.tableLayoutExecution);
            this.panelExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecution.Location = new System.Drawing.Point(0, 0);
            this.panelExecution.Name = "panelExecution";
            this.panelExecution.Size = new System.Drawing.Size(1130, 674);
            this.panelExecution.TabIndex = 87;
            // 
            // tableLayoutExecution
            // 
            this.tableLayoutExecution.ColumnCount = 3;
            this.tableLayoutExecution.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutExecution.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.tableLayoutExecution.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutExecution.Controls.Add(this.panelExecutionInfo, 1, 1);
            this.tableLayoutExecution.Controls.Add(this.panelActivities, 1, 2);
            this.tableLayoutExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutExecution.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutExecution.Name = "tableLayoutExecution";
            this.tableLayoutExecution.RowCount = 4;
            this.tableLayoutExecution.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutExecution.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutExecution.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutExecution.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutExecution.Size = new System.Drawing.Size(1128, 672);
            this.tableLayoutExecution.TabIndex = 126;
            // 
            // panelExecutionInfo
            // 
            this.panelExecutionInfo.BackColor = System.Drawing.Color.White;
            this.panelExecutionInfo.Controls.Add(this.tableLayoutPanelExecutionInfo);
            this.panelExecutionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionInfo.Location = new System.Drawing.Point(379, 76);
            this.panelExecutionInfo.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionInfo.Name = "panelExecutionInfo";
            this.panelExecutionInfo.Size = new System.Drawing.Size(370, 140);
            this.panelExecutionInfo.TabIndex = 124;
            // 
            // tableLayoutPanelExecutionInfo
            // 
            this.tableLayoutPanelExecutionInfo.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelExecutionInfo.ColumnCount = 4;
            this.tableLayoutPanelExecutionInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanelExecutionInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelExecutionInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelExecutionInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionIDTitle, 0, 1);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionTypeValue, 3, 2);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionTypeTitle, 0, 2);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionEndValue, 2, 5);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionEndTitle, 0, 5);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionBeginTitle, 0, 4);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionBeginValue, 2, 4);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionIDValue, 2, 1);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionNameTitle, 0, 3);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionNameValue, 2, 3);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelAnalysisDurationValue, 2, 6);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.labelExecutionDurationTitle, 0, 6);
            this.tableLayoutPanelExecutionInfo.Controls.Add(this.pictureExecutionMode, 2, 2);
            this.tableLayoutPanelExecutionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelExecutionInfo.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelExecutionInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelExecutionInfo.Name = "tableLayoutPanelExecutionInfo";
            this.tableLayoutPanelExecutionInfo.RowCount = 8;
            this.tableLayoutPanelExecutionInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelExecutionInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExecutionInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExecutionInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExecutionInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExecutionInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExecutionInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExecutionInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelExecutionInfo.Size = new System.Drawing.Size(370, 140);
            this.tableLayoutPanelExecutionInfo.TabIndex = 111;
            this.tableLayoutPanelExecutionInfo.Visible = false;
            // 
            // labelExecutionIDTitle
            // 
            this.labelExecutionIDTitle.AutoSize = true;
            this.labelExecutionIDTitle.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionIDTitle.BorderHeightOffset = 2;
            this.labelExecutionIDTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionIDTitle.BorderWidthOffset = 2;
            this.labelExecutionIDTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionIDTitle.DrawBorder = false;
            this.labelExecutionIDTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionIDTitle.Location = new System.Drawing.Point(0, 10);
            this.labelExecutionIDTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionIDTitle.Name = "labelExecutionIDTitle";
            this.labelExecutionIDTitle.Size = new System.Drawing.Size(110, 20);
            this.labelExecutionIDTitle.TabIndex = 114;
            this.labelExecutionIDTitle.Text = "ID";
            this.labelExecutionIDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelExecutionTypeValue
            // 
            this.labelExecutionTypeValue.AutoSize = true;
            this.labelExecutionTypeValue.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionTypeValue.BorderHeightOffset = 2;
            this.labelExecutionTypeValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionTypeValue.BorderWidthOffset = 2;
            this.labelExecutionTypeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionTypeValue.DrawBorder = false;
            this.labelExecutionTypeValue.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.labelExecutionTypeValue.Location = new System.Drawing.Point(133, 30);
            this.labelExecutionTypeValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionTypeValue.Name = "labelExecutionTypeValue";
            this.labelExecutionTypeValue.Size = new System.Drawing.Size(250, 20);
            this.labelExecutionTypeValue.TabIndex = 113;
            this.labelExecutionTypeValue.Text = "{0}";
            this.labelExecutionTypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelExecutionTypeTitle
            // 
            this.labelExecutionTypeTitle.AutoSize = true;
            this.labelExecutionTypeTitle.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionTypeTitle.BorderHeightOffset = 2;
            this.labelExecutionTypeTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionTypeTitle.BorderWidthOffset = 2;
            this.labelExecutionTypeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionTypeTitle.DrawBorder = false;
            this.labelExecutionTypeTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionTypeTitle.Location = new System.Drawing.Point(0, 30);
            this.labelExecutionTypeTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionTypeTitle.Name = "labelExecutionTypeTitle";
            this.labelExecutionTypeTitle.Size = new System.Drawing.Size(110, 20);
            this.labelExecutionTypeTitle.TabIndex = 112;
            this.labelExecutionTypeTitle.Text = "Type";
            this.labelExecutionTypeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelExecutionEndValue
            // 
            this.labelExecutionEndValue.AutoSize = true;
            this.labelExecutionEndValue.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionEndValue.BorderHeightOffset = 2;
            this.labelExecutionEndValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionEndValue.BorderWidthOffset = 2;
            this.tableLayoutPanelExecutionInfo.SetColumnSpan(this.labelExecutionEndValue, 2);
            this.labelExecutionEndValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionEndValue.DrawBorder = false;
            this.labelExecutionEndValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionEndValue.Location = new System.Drawing.Point(115, 90);
            this.labelExecutionEndValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionEndValue.Name = "labelExecutionEndValue";
            this.labelExecutionEndValue.Size = new System.Drawing.Size(268, 20);
            this.labelExecutionEndValue.TabIndex = 111;
            this.labelExecutionEndValue.Text = "Execution End";
            this.labelExecutionEndValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelExecutionEndTitle
            // 
            this.labelExecutionEndTitle.AutoSize = true;
            this.labelExecutionEndTitle.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionEndTitle.BorderHeightOffset = 2;
            this.labelExecutionEndTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionEndTitle.BorderWidthOffset = 2;
            this.labelExecutionEndTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionEndTitle.DrawBorder = false;
            this.labelExecutionEndTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionEndTitle.Location = new System.Drawing.Point(0, 90);
            this.labelExecutionEndTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionEndTitle.Name = "labelExecutionEndTitle";
            this.labelExecutionEndTitle.Size = new System.Drawing.Size(110, 20);
            this.labelExecutionEndTitle.TabIndex = 110;
            this.labelExecutionEndTitle.Text = "End time";
            this.labelExecutionEndTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelExecutionBeginTitle
            // 
            this.labelExecutionBeginTitle.AutoSize = true;
            this.labelExecutionBeginTitle.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionBeginTitle.BorderHeightOffset = 2;
            this.labelExecutionBeginTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionBeginTitle.BorderWidthOffset = 2;
            this.labelExecutionBeginTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionBeginTitle.DrawBorder = false;
            this.labelExecutionBeginTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionBeginTitle.Location = new System.Drawing.Point(0, 70);
            this.labelExecutionBeginTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionBeginTitle.Name = "labelExecutionBeginTitle";
            this.labelExecutionBeginTitle.Size = new System.Drawing.Size(110, 20);
            this.labelExecutionBeginTitle.TabIndex = 109;
            this.labelExecutionBeginTitle.Text = "Begin time";
            this.labelExecutionBeginTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelExecutionBeginValue
            // 
            this.labelExecutionBeginValue.AutoSize = true;
            this.labelExecutionBeginValue.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionBeginValue.BorderHeightOffset = 2;
            this.labelExecutionBeginValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionBeginValue.BorderWidthOffset = 2;
            this.tableLayoutPanelExecutionInfo.SetColumnSpan(this.labelExecutionBeginValue, 2);
            this.labelExecutionBeginValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionBeginValue.DrawBorder = false;
            this.labelExecutionBeginValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionBeginValue.Location = new System.Drawing.Point(115, 70);
            this.labelExecutionBeginValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionBeginValue.Name = "labelExecutionBeginValue";
            this.labelExecutionBeginValue.Size = new System.Drawing.Size(268, 20);
            this.labelExecutionBeginValue.TabIndex = 108;
            this.labelExecutionBeginValue.Text = "Execution Begin";
            this.labelExecutionBeginValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelExecutionIDValue
            // 
            this.labelExecutionIDValue.AutoSize = true;
            this.labelExecutionIDValue.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionIDValue.BorderHeightOffset = 2;
            this.labelExecutionIDValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionIDValue.BorderWidthOffset = 2;
            this.tableLayoutPanelExecutionInfo.SetColumnSpan(this.labelExecutionIDValue, 2);
            this.labelExecutionIDValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionIDValue.DrawBorder = false;
            this.labelExecutionIDValue.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.labelExecutionIDValue.Location = new System.Drawing.Point(115, 10);
            this.labelExecutionIDValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionIDValue.Name = "labelExecutionIDValue";
            this.labelExecutionIDValue.Size = new System.Drawing.Size(268, 20);
            this.labelExecutionIDValue.TabIndex = 87;
            this.labelExecutionIDValue.Text = "[{1}]";
            this.labelExecutionIDValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelExecutionNameTitle
            // 
            this.labelExecutionNameTitle.AutoSize = true;
            this.labelExecutionNameTitle.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionNameTitle.BorderHeightOffset = 2;
            this.labelExecutionNameTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionNameTitle.BorderWidthOffset = 2;
            this.labelExecutionNameTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionNameTitle.DrawBorder = false;
            this.labelExecutionNameTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionNameTitle.Location = new System.Drawing.Point(0, 50);
            this.labelExecutionNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionNameTitle.Name = "labelExecutionNameTitle";
            this.labelExecutionNameTitle.Size = new System.Drawing.Size(110, 20);
            this.labelExecutionNameTitle.TabIndex = 86;
            this.labelExecutionNameTitle.Text = "Name";
            this.labelExecutionNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelExecutionNameValue
            // 
            this.labelExecutionNameValue.AutoSize = true;
            this.labelExecutionNameValue.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionNameValue.BorderHeightOffset = 2;
            this.labelExecutionNameValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionNameValue.BorderWidthOffset = 2;
            this.tableLayoutPanelExecutionInfo.SetColumnSpan(this.labelExecutionNameValue, 2);
            this.labelExecutionNameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionNameValue.DrawBorder = false;
            this.labelExecutionNameValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionNameValue.Location = new System.Drawing.Point(115, 50);
            this.labelExecutionNameValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionNameValue.Name = "labelExecutionNameValue";
            this.labelExecutionNameValue.Size = new System.Drawing.Size(268, 20);
            this.labelExecutionNameValue.TabIndex = 83;
            this.labelExecutionNameValue.Text = "Execution name";
            this.labelExecutionNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAnalysisDurationValue
            // 
            this.labelAnalysisDurationValue.AutoSize = true;
            this.labelAnalysisDurationValue.BorderColor = System.Drawing.Color.Black;
            this.labelAnalysisDurationValue.BorderHeightOffset = 2;
            this.labelAnalysisDurationValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelAnalysisDurationValue.BorderWidthOffset = 2;
            this.tableLayoutPanelExecutionInfo.SetColumnSpan(this.labelAnalysisDurationValue, 2);
            this.labelAnalysisDurationValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAnalysisDurationValue.DrawBorder = false;
            this.labelAnalysisDurationValue.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnalysisDurationValue.Location = new System.Drawing.Point(115, 110);
            this.labelAnalysisDurationValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelAnalysisDurationValue.Name = "labelAnalysisDurationValue";
            this.labelAnalysisDurationValue.Size = new System.Drawing.Size(268, 20);
            this.labelAnalysisDurationValue.TabIndex = 73;
            this.labelAnalysisDurationValue.Text = "Execution Duration";
            this.labelAnalysisDurationValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelExecutionDurationTitle
            // 
            this.labelExecutionDurationTitle.AutoSize = true;
            this.labelExecutionDurationTitle.BorderColor = System.Drawing.Color.Black;
            this.labelExecutionDurationTitle.BorderHeightOffset = 2;
            this.labelExecutionDurationTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelExecutionDurationTitle.BorderWidthOffset = 2;
            this.labelExecutionDurationTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelExecutionDurationTitle.DrawBorder = false;
            this.labelExecutionDurationTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExecutionDurationTitle.Location = new System.Drawing.Point(0, 110);
            this.labelExecutionDurationTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelExecutionDurationTitle.Name = "labelExecutionDurationTitle";
            this.labelExecutionDurationTitle.Size = new System.Drawing.Size(110, 20);
            this.labelExecutionDurationTitle.TabIndex = 72;
            this.labelExecutionDurationTitle.Text = "Duration";
            this.labelExecutionDurationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureExecutionMode
            // 
            this.pictureExecutionMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureExecutionMode.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.LiveMode_16x16;
            this.pictureExecutionMode.Location = new System.Drawing.Point(115, 30);
            this.pictureExecutionMode.Margin = new System.Windows.Forms.Padding(0);
            this.pictureExecutionMode.Name = "pictureExecutionMode";
            this.pictureExecutionMode.Size = new System.Drawing.Size(18, 20);
            this.pictureExecutionMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureExecutionMode.TabIndex = 107;
            this.pictureExecutionMode.TabStop = false;
            // 
            // panelActivities
            // 
            this.panelActivities.Controls.Add(this.tableLayoutPanelActivities);
            this.panelActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActivities.Location = new System.Drawing.Point(379, 216);
            this.panelActivities.Margin = new System.Windows.Forms.Padding(0);
            this.panelActivities.Name = "panelActivities";
            this.panelActivities.Size = new System.Drawing.Size(370, 380);
            this.panelActivities.TabIndex = 125;
            // 
            // tableLayoutPanelActivities
            // 
            this.tableLayoutPanelActivities.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelActivities.ColumnCount = 10;
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelActivities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_PostWarm_DataRendering, 8, 21);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_PostWarm_DataRendering, 4, 21);
            this.tableLayoutPanelActivities.Controls.Add(this.labelDurationTitle, 8, 0);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Pre_EnvironmentSetup, 8, 2);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Pre_EnvironmentSetup, 4, 2);
            this.tableLayoutPanelActivities.Controls.Add(this.labelActivityTitle, 4, 0);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_PostCold_DataRetrieval, 8, 12);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_PostCold_DataRetrieval, 4, 12);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionBandPostCold, 0, 12);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionTaskPostCold, 1, 12);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_PostWarm_DataRetrieval, 8, 20);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_PostWarm_DataRetrieval, 4, 20);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Warm_MetricsCalculation, 8, 17);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Warm_QueryExecution, 8, 15);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Warm_TracesStartup, 8, 14);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Warm_QueryExecution, 4, 15);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Warm_MetricsCalculation, 4, 17);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Warm_TracesStartup, 4, 14);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Cold_QueryExecution, 8, 8);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Cold_QueryExecution, 4, 8);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Cold_MetricsCalculation, 8, 10);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Cold_MetricsCalculation, 4, 10);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Cold_TracesStartup, 8, 7);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Cold_TracesStartup, 4, 7);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Pre_CubeScriptLoading, 8, 5);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Pre_CacheClearing, 8, 4);
            this.tableLayoutPanelActivities.Controls.Add(this.labelResult_Pre_QuerySyntaxValidation, 8, 3);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Pre_CubeScriptLoading, 4, 5);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Pre_CacheClearing, 4, 4);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionBandPostWarm, 0, 19);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionTaskPostWarm, 1, 19);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionBandWarmCache, 0, 14);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionTaskWarmCache, 1, 14);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionBandColdCache, 0, 7);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionTaskColdCache, 1, 7);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionBandPre, 0, 2);
            this.tableLayoutPanelActivities.Controls.Add(this.panelExecutionTaskPre, 1, 2);
            this.tableLayoutPanelActivities.Controls.Add(this.labelName_Pre_QuerySyntaxValidation, 4, 3);
            this.tableLayoutPanelActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelActivities.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelActivities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanelActivities.Name = "tableLayoutPanelActivities";
            this.tableLayoutPanelActivities.RowCount = 24;
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelActivities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanelActivities.Size = new System.Drawing.Size(370, 380);
            this.tableLayoutPanelActivities.TabIndex = 2;
            this.tableLayoutPanelActivities.Visible = false;
            // 
            // labelResult_PostWarm_DataRendering
            // 
            this.labelResult_PostWarm_DataRendering.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_PostWarm_DataRendering, 2);
            this.labelResult_PostWarm_DataRendering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_PostWarm_DataRendering.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_PostWarm_DataRendering.ForeColor = System.Drawing.Color.Black;
            this.labelResult_PostWarm_DataRendering.Location = new System.Drawing.Point(260, 342);
            this.labelResult_PostWarm_DataRendering.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_PostWarm_DataRendering.Name = "labelResult_PostWarm_DataRendering";
            this.labelResult_PostWarm_DataRendering.Size = new System.Drawing.Size(110, 16);
            this.labelResult_PostWarm_DataRendering.TabIndex = 84;
            this.labelResult_PostWarm_DataRendering.Text = "waiting for execution";
            this.labelResult_PostWarm_DataRendering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_PostWarm_DataRendering
            // 
            this.labelName_PostWarm_DataRendering.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_PostWarm_DataRendering, 3);
            this.labelName_PostWarm_DataRendering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_PostWarm_DataRendering.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_PostWarm_DataRendering.ForeColor = System.Drawing.Color.Black;
            this.labelName_PostWarm_DataRendering.Location = new System.Drawing.Point(115, 342);
            this.labelName_PostWarm_DataRendering.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_PostWarm_DataRendering.Name = "labelName_PostWarm_DataRendering";
            this.labelName_PostWarm_DataRendering.Size = new System.Drawing.Size(140, 16);
            this.labelName_PostWarm_DataRendering.TabIndex = 83;
            this.labelName_PostWarm_DataRendering.Text = "Data rendering";
            this.labelName_PostWarm_DataRendering.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDurationTitle
            // 
            this.labelDurationTitle.AutoSize = true;
            this.labelDurationTitle.BorderColor = System.Drawing.Color.Black;
            this.labelDurationTitle.BorderHeightOffset = 2;
            this.labelDurationTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelDurationTitle.BorderWidthOffset = 2;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelDurationTitle, 2);
            this.labelDurationTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDurationTitle.DrawBorder = false;
            this.labelDurationTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDurationTitle.Location = new System.Drawing.Point(263, 0);
            this.labelDurationTitle.Name = "labelDurationTitle";
            this.labelDurationTitle.Size = new System.Drawing.Size(104, 18);
            this.labelDurationTitle.TabIndex = 82;
            this.labelDurationTitle.Text = "Duration";
            this.labelDurationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult_Pre_EnvironmentSetup
            // 
            this.labelResult_Pre_EnvironmentSetup.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Pre_EnvironmentSetup, 2);
            this.labelResult_Pre_EnvironmentSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Pre_EnvironmentSetup.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Pre_EnvironmentSetup.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Pre_EnvironmentSetup.Location = new System.Drawing.Point(260, 23);
            this.labelResult_Pre_EnvironmentSetup.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Pre_EnvironmentSetup.Name = "labelResult_Pre_EnvironmentSetup";
            this.labelResult_Pre_EnvironmentSetup.Size = new System.Drawing.Size(110, 16);
            this.labelResult_Pre_EnvironmentSetup.TabIndex = 81;
            this.labelResult_Pre_EnvironmentSetup.Text = "waiting for execution";
            this.labelResult_Pre_EnvironmentSetup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_Pre_EnvironmentSetup
            // 
            this.labelName_Pre_EnvironmentSetup.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Pre_EnvironmentSetup, 3);
            this.labelName_Pre_EnvironmentSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Pre_EnvironmentSetup.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Pre_EnvironmentSetup.ForeColor = System.Drawing.Color.Black;
            this.labelName_Pre_EnvironmentSetup.Location = new System.Drawing.Point(115, 23);
            this.labelName_Pre_EnvironmentSetup.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Pre_EnvironmentSetup.Name = "labelName_Pre_EnvironmentSetup";
            this.labelName_Pre_EnvironmentSetup.Size = new System.Drawing.Size(140, 16);
            this.labelName_Pre_EnvironmentSetup.TabIndex = 80;
            this.labelName_Pre_EnvironmentSetup.Text = "Environment setup";
            this.labelName_Pre_EnvironmentSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelActivityTitle
            // 
            this.labelActivityTitle.AutoSize = true;
            this.labelActivityTitle.BorderColor = System.Drawing.Color.Black;
            this.labelActivityTitle.BorderHeightOffset = 2;
            this.labelActivityTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelActivityTitle.BorderWidthOffset = 2;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelActivityTitle, 3);
            this.labelActivityTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelActivityTitle.DrawBorder = false;
            this.labelActivityTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActivityTitle.Location = new System.Drawing.Point(118, 0);
            this.labelActivityTitle.Name = "labelActivityTitle";
            this.labelActivityTitle.Size = new System.Drawing.Size(134, 18);
            this.labelActivityTitle.TabIndex = 79;
            this.labelActivityTitle.Text = "Activities";
            this.labelActivityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult_PostCold_DataRetrieval
            // 
            this.labelResult_PostCold_DataRetrieval.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_PostCold_DataRetrieval, 2);
            this.labelResult_PostCold_DataRetrieval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_PostCold_DataRetrieval.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_PostCold_DataRetrieval.ForeColor = System.Drawing.Color.Black;
            this.labelResult_PostCold_DataRetrieval.Location = new System.Drawing.Point(260, 167);
            this.labelResult_PostCold_DataRetrieval.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_PostCold_DataRetrieval.Name = "labelResult_PostCold_DataRetrieval";
            this.labelResult_PostCold_DataRetrieval.Size = new System.Drawing.Size(110, 63);
            this.labelResult_PostCold_DataRetrieval.TabIndex = 65;
            this.labelResult_PostCold_DataRetrieval.Text = "waiting for execution";
            this.labelResult_PostCold_DataRetrieval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_PostCold_DataRetrieval
            // 
            this.labelName_PostCold_DataRetrieval.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_PostCold_DataRetrieval, 3);
            this.labelName_PostCold_DataRetrieval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_PostCold_DataRetrieval.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_PostCold_DataRetrieval.ForeColor = System.Drawing.Color.Black;
            this.labelName_PostCold_DataRetrieval.Location = new System.Drawing.Point(115, 167);
            this.labelName_PostCold_DataRetrieval.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_PostCold_DataRetrieval.Name = "labelName_PostCold_DataRetrieval";
            this.labelName_PostCold_DataRetrieval.Size = new System.Drawing.Size(140, 63);
            this.labelName_PostCold_DataRetrieval.TabIndex = 64;
            this.labelName_PostCold_DataRetrieval.Text = "Data retrieval";
            this.labelName_PostCold_DataRetrieval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExecutionBandPostCold
            // 
            this.panelExecutionBandPostCold.BackColor = System.Drawing.Color.Gray;
            this.panelExecutionBandPostCold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandPostCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandPostCold.Location = new System.Drawing.Point(0, 167);
            this.panelExecutionBandPostCold.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandPostCold.Name = "panelExecutionBandPostCold";
            this.panelExecutionBandPostCold.Size = new System.Drawing.Size(5, 63);
            this.panelExecutionBandPostCold.TabIndex = 63;
            // 
            // panelExecutionTaskPostCold
            // 
            this.panelExecutionTaskPostCold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelActivities.SetColumnSpan(this.panelExecutionTaskPostCold, 2);
            this.panelExecutionTaskPostCold.Controls.Add(this.pictureBoxExecutionPicturePostCold);
            this.panelExecutionTaskPostCold.Controls.Add(this.labelTitlePostCold);
            this.panelExecutionTaskPostCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskPostCold.Location = new System.Drawing.Point(5, 167);
            this.panelExecutionTaskPostCold.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskPostCold.Name = "panelExecutionTaskPostCold";
            this.panelExecutionTaskPostCold.Size = new System.Drawing.Size(105, 63);
            this.panelExecutionTaskPostCold.TabIndex = 62;
            // 
            // pictureBoxExecutionPicturePostCold
            // 
            this.pictureBoxExecutionPicturePostCold.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPicturePostCold.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPicturePostCold.Image")));
            this.pictureBoxExecutionPicturePostCold.Location = new System.Drawing.Point(69, 0);
            this.pictureBoxExecutionPicturePostCold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPicturePostCold.Name = "pictureBoxExecutionPicturePostCold";
            this.pictureBoxExecutionPicturePostCold.Size = new System.Drawing.Size(34, 61);
            this.pictureBoxExecutionPicturePostCold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPicturePostCold.TabIndex = 5;
            this.pictureBoxExecutionPicturePostCold.TabStop = false;
            // 
            // labelTitlePostCold
            // 
            this.labelTitlePostCold.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitlePostCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePostCold.Location = new System.Drawing.Point(0, 0);
            this.labelTitlePostCold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitlePostCold.Name = "labelTitlePostCold";
            this.labelTitlePostCold.Size = new System.Drawing.Size(71, 61);
            this.labelTitlePostCold.TabIndex = 39;
            this.labelTitlePostCold.Text = "POST COLD EXECUTION ACTIVITIES";
            this.labelTitlePostCold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult_PostWarm_DataRetrieval
            // 
            this.labelResult_PostWarm_DataRetrieval.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_PostWarm_DataRetrieval, 2);
            this.labelResult_PostWarm_DataRetrieval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_PostWarm_DataRetrieval.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_PostWarm_DataRetrieval.ForeColor = System.Drawing.Color.Black;
            this.labelResult_PostWarm_DataRetrieval.Location = new System.Drawing.Point(260, 326);
            this.labelResult_PostWarm_DataRetrieval.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_PostWarm_DataRetrieval.Name = "labelResult_PostWarm_DataRetrieval";
            this.labelResult_PostWarm_DataRetrieval.Size = new System.Drawing.Size(110, 16);
            this.labelResult_PostWarm_DataRetrieval.TabIndex = 60;
            this.labelResult_PostWarm_DataRetrieval.Text = "waiting for execution";
            this.labelResult_PostWarm_DataRetrieval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_PostWarm_DataRetrieval
            // 
            this.labelName_PostWarm_DataRetrieval.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_PostWarm_DataRetrieval, 3);
            this.labelName_PostWarm_DataRetrieval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_PostWarm_DataRetrieval.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_PostWarm_DataRetrieval.ForeColor = System.Drawing.Color.Black;
            this.labelName_PostWarm_DataRetrieval.Location = new System.Drawing.Point(115, 326);
            this.labelName_PostWarm_DataRetrieval.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_PostWarm_DataRetrieval.Name = "labelName_PostWarm_DataRetrieval";
            this.labelName_PostWarm_DataRetrieval.Size = new System.Drawing.Size(140, 16);
            this.labelName_PostWarm_DataRetrieval.TabIndex = 59;
            this.labelName_PostWarm_DataRetrieval.Text = "Data retrieval";
            this.labelName_PostWarm_DataRetrieval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelResult_Warm_MetricsCalculation
            // 
            this.labelResult_Warm_MetricsCalculation.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Warm_MetricsCalculation, 2);
            this.labelResult_Warm_MetricsCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Warm_MetricsCalculation.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Warm_MetricsCalculation.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Warm_MetricsCalculation.Location = new System.Drawing.Point(260, 286);
            this.labelResult_Warm_MetricsCalculation.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Warm_MetricsCalculation.Name = "labelResult_Warm_MetricsCalculation";
            this.labelResult_Warm_MetricsCalculation.Size = new System.Drawing.Size(110, 16);
            this.labelResult_Warm_MetricsCalculation.TabIndex = 58;
            this.labelResult_Warm_MetricsCalculation.Text = "waiting for execution";
            this.labelResult_Warm_MetricsCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult_Warm_QueryExecution
            // 
            this.labelResult_Warm_QueryExecution.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Warm_QueryExecution, 2);
            this.labelResult_Warm_QueryExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Warm_QueryExecution.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Warm_QueryExecution.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Warm_QueryExecution.Location = new System.Drawing.Point(260, 254);
            this.labelResult_Warm_QueryExecution.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Warm_QueryExecution.Name = "labelResult_Warm_QueryExecution";
            this.tableLayoutPanelActivities.SetRowSpan(this.labelResult_Warm_QueryExecution, 2);
            this.labelResult_Warm_QueryExecution.Size = new System.Drawing.Size(110, 32);
            this.labelResult_Warm_QueryExecution.TabIndex = 57;
            this.labelResult_Warm_QueryExecution.Text = "waiting for execution";
            this.labelResult_Warm_QueryExecution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult_Warm_TracesStartup
            // 
            this.labelResult_Warm_TracesStartup.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Warm_TracesStartup, 2);
            this.labelResult_Warm_TracesStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Warm_TracesStartup.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Warm_TracesStartup.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Warm_TracesStartup.Location = new System.Drawing.Point(260, 238);
            this.labelResult_Warm_TracesStartup.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Warm_TracesStartup.Name = "labelResult_Warm_TracesStartup";
            this.labelResult_Warm_TracesStartup.Size = new System.Drawing.Size(110, 16);
            this.labelResult_Warm_TracesStartup.TabIndex = 55;
            this.labelResult_Warm_TracesStartup.Text = "waiting for execution";
            this.labelResult_Warm_TracesStartup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_Warm_QueryExecution
            // 
            this.labelName_Warm_QueryExecution.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Warm_QueryExecution, 3);
            this.labelName_Warm_QueryExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Warm_QueryExecution.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Warm_QueryExecution.ForeColor = System.Drawing.Color.Black;
            this.labelName_Warm_QueryExecution.Location = new System.Drawing.Point(115, 254);
            this.labelName_Warm_QueryExecution.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Warm_QueryExecution.Name = "labelName_Warm_QueryExecution";
            this.tableLayoutPanelActivities.SetRowSpan(this.labelName_Warm_QueryExecution, 2);
            this.labelName_Warm_QueryExecution.Size = new System.Drawing.Size(140, 32);
            this.labelName_Warm_QueryExecution.TabIndex = 53;
            this.labelName_Warm_QueryExecution.Text = "Query execution and data collection";
            this.labelName_Warm_QueryExecution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelName_Warm_MetricsCalculation
            // 
            this.labelName_Warm_MetricsCalculation.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Warm_MetricsCalculation, 3);
            this.labelName_Warm_MetricsCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Warm_MetricsCalculation.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Warm_MetricsCalculation.ForeColor = System.Drawing.Color.Black;
            this.labelName_Warm_MetricsCalculation.Location = new System.Drawing.Point(115, 286);
            this.labelName_Warm_MetricsCalculation.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Warm_MetricsCalculation.Name = "labelName_Warm_MetricsCalculation";
            this.labelName_Warm_MetricsCalculation.Size = new System.Drawing.Size(140, 16);
            this.labelName_Warm_MetricsCalculation.TabIndex = 52;
            this.labelName_Warm_MetricsCalculation.Text = "Metrics calculation";
            this.labelName_Warm_MetricsCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelName_Warm_TracesStartup
            // 
            this.labelName_Warm_TracesStartup.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Warm_TracesStartup, 3);
            this.labelName_Warm_TracesStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Warm_TracesStartup.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Warm_TracesStartup.ForeColor = System.Drawing.Color.Black;
            this.labelName_Warm_TracesStartup.Location = new System.Drawing.Point(115, 238);
            this.labelName_Warm_TracesStartup.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Warm_TracesStartup.Name = "labelName_Warm_TracesStartup";
            this.labelName_Warm_TracesStartup.Size = new System.Drawing.Size(140, 16);
            this.labelName_Warm_TracesStartup.TabIndex = 51;
            this.labelName_Warm_TracesStartup.Text = "Traces startup";
            this.labelName_Warm_TracesStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelResult_Cold_QueryExecution
            // 
            this.labelResult_Cold_QueryExecution.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Cold_QueryExecution, 2);
            this.labelResult_Cold_QueryExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Cold_QueryExecution.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Cold_QueryExecution.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Cold_QueryExecution.Location = new System.Drawing.Point(260, 111);
            this.labelResult_Cold_QueryExecution.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Cold_QueryExecution.Name = "labelResult_Cold_QueryExecution";
            this.tableLayoutPanelActivities.SetRowSpan(this.labelResult_Cold_QueryExecution, 2);
            this.labelResult_Cold_QueryExecution.Size = new System.Drawing.Size(110, 32);
            this.labelResult_Cold_QueryExecution.TabIndex = 48;
            this.labelResult_Cold_QueryExecution.Text = "waiting for execution";
            this.labelResult_Cold_QueryExecution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_Cold_QueryExecution
            // 
            this.labelName_Cold_QueryExecution.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Cold_QueryExecution, 3);
            this.labelName_Cold_QueryExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Cold_QueryExecution.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Cold_QueryExecution.ForeColor = System.Drawing.Color.Black;
            this.labelName_Cold_QueryExecution.Location = new System.Drawing.Point(115, 111);
            this.labelName_Cold_QueryExecution.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Cold_QueryExecution.Name = "labelName_Cold_QueryExecution";
            this.tableLayoutPanelActivities.SetRowSpan(this.labelName_Cold_QueryExecution, 2);
            this.labelName_Cold_QueryExecution.Size = new System.Drawing.Size(140, 32);
            this.labelName_Cold_QueryExecution.TabIndex = 47;
            this.labelName_Cold_QueryExecution.Text = "Query execution and data collection";
            this.labelName_Cold_QueryExecution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelResult_Cold_MetricsCalculation
            // 
            this.labelResult_Cold_MetricsCalculation.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Cold_MetricsCalculation, 2);
            this.labelResult_Cold_MetricsCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Cold_MetricsCalculation.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Cold_MetricsCalculation.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Cold_MetricsCalculation.Location = new System.Drawing.Point(260, 143);
            this.labelResult_Cold_MetricsCalculation.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Cold_MetricsCalculation.Name = "labelResult_Cold_MetricsCalculation";
            this.labelResult_Cold_MetricsCalculation.Size = new System.Drawing.Size(110, 16);
            this.labelResult_Cold_MetricsCalculation.TabIndex = 46;
            this.labelResult_Cold_MetricsCalculation.Text = "waiting for execution";
            this.labelResult_Cold_MetricsCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_Cold_MetricsCalculation
            // 
            this.labelName_Cold_MetricsCalculation.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Cold_MetricsCalculation, 3);
            this.labelName_Cold_MetricsCalculation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Cold_MetricsCalculation.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Cold_MetricsCalculation.ForeColor = System.Drawing.Color.Black;
            this.labelName_Cold_MetricsCalculation.Location = new System.Drawing.Point(115, 143);
            this.labelName_Cold_MetricsCalculation.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Cold_MetricsCalculation.Name = "labelName_Cold_MetricsCalculation";
            this.labelName_Cold_MetricsCalculation.Size = new System.Drawing.Size(140, 16);
            this.labelName_Cold_MetricsCalculation.TabIndex = 45;
            this.labelName_Cold_MetricsCalculation.Text = "Metrics calculation";
            this.labelName_Cold_MetricsCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelResult_Cold_TracesStartup
            // 
            this.labelResult_Cold_TracesStartup.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Cold_TracesStartup, 2);
            this.labelResult_Cold_TracesStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Cold_TracesStartup.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Cold_TracesStartup.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Cold_TracesStartup.Location = new System.Drawing.Point(260, 95);
            this.labelResult_Cold_TracesStartup.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Cold_TracesStartup.Name = "labelResult_Cold_TracesStartup";
            this.labelResult_Cold_TracesStartup.Size = new System.Drawing.Size(110, 16);
            this.labelResult_Cold_TracesStartup.TabIndex = 44;
            this.labelResult_Cold_TracesStartup.Text = "waiting for execution";
            this.labelResult_Cold_TracesStartup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_Cold_TracesStartup
            // 
            this.labelName_Cold_TracesStartup.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Cold_TracesStartup, 3);
            this.labelName_Cold_TracesStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Cold_TracesStartup.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Cold_TracesStartup.ForeColor = System.Drawing.Color.Black;
            this.labelName_Cold_TracesStartup.Location = new System.Drawing.Point(115, 95);
            this.labelName_Cold_TracesStartup.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Cold_TracesStartup.Name = "labelName_Cold_TracesStartup";
            this.labelName_Cold_TracesStartup.Size = new System.Drawing.Size(140, 16);
            this.labelName_Cold_TracesStartup.TabIndex = 41;
            this.labelName_Cold_TracesStartup.Text = "Traces startup";
            this.labelName_Cold_TracesStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelResult_Pre_CubeScriptLoading
            // 
            this.labelResult_Pre_CubeScriptLoading.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Pre_CubeScriptLoading, 2);
            this.labelResult_Pre_CubeScriptLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Pre_CubeScriptLoading.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Pre_CubeScriptLoading.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Pre_CubeScriptLoading.Location = new System.Drawing.Point(260, 71);
            this.labelResult_Pre_CubeScriptLoading.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Pre_CubeScriptLoading.Name = "labelResult_Pre_CubeScriptLoading";
            this.labelResult_Pre_CubeScriptLoading.Size = new System.Drawing.Size(110, 16);
            this.labelResult_Pre_CubeScriptLoading.TabIndex = 40;
            this.labelResult_Pre_CubeScriptLoading.Text = "waiting for execution";
            this.labelResult_Pre_CubeScriptLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult_Pre_CacheClearing
            // 
            this.labelResult_Pre_CacheClearing.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Pre_CacheClearing, 2);
            this.labelResult_Pre_CacheClearing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Pre_CacheClearing.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Pre_CacheClearing.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Pre_CacheClearing.Location = new System.Drawing.Point(260, 55);
            this.labelResult_Pre_CacheClearing.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Pre_CacheClearing.Name = "labelResult_Pre_CacheClearing";
            this.labelResult_Pre_CacheClearing.Size = new System.Drawing.Size(110, 16);
            this.labelResult_Pre_CacheClearing.TabIndex = 39;
            this.labelResult_Pre_CacheClearing.Text = "waiting for execution";
            this.labelResult_Pre_CacheClearing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult_Pre_QuerySyntaxValidation
            // 
            this.labelResult_Pre_QuerySyntaxValidation.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelResult_Pre_QuerySyntaxValidation, 2);
            this.labelResult_Pre_QuerySyntaxValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Pre_QuerySyntaxValidation.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Pre_QuerySyntaxValidation.ForeColor = System.Drawing.Color.Black;
            this.labelResult_Pre_QuerySyntaxValidation.Location = new System.Drawing.Point(260, 39);
            this.labelResult_Pre_QuerySyntaxValidation.Margin = new System.Windows.Forms.Padding(0);
            this.labelResult_Pre_QuerySyntaxValidation.Name = "labelResult_Pre_QuerySyntaxValidation";
            this.labelResult_Pre_QuerySyntaxValidation.Size = new System.Drawing.Size(110, 16);
            this.labelResult_Pre_QuerySyntaxValidation.TabIndex = 38;
            this.labelResult_Pre_QuerySyntaxValidation.Text = "waiting for execution";
            this.labelResult_Pre_QuerySyntaxValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_Pre_CubeScriptLoading
            // 
            this.labelName_Pre_CubeScriptLoading.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Pre_CubeScriptLoading, 3);
            this.labelName_Pre_CubeScriptLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Pre_CubeScriptLoading.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Pre_CubeScriptLoading.ForeColor = System.Drawing.Color.Black;
            this.labelName_Pre_CubeScriptLoading.Location = new System.Drawing.Point(115, 71);
            this.labelName_Pre_CubeScriptLoading.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Pre_CubeScriptLoading.Name = "labelName_Pre_CubeScriptLoading";
            this.labelName_Pre_CubeScriptLoading.Size = new System.Drawing.Size(140, 16);
            this.labelName_Pre_CubeScriptLoading.TabIndex = 37;
            this.labelName_Pre_CubeScriptLoading.Text = "Cube script loading";
            this.labelName_Pre_CubeScriptLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelName_Pre_CacheClearing
            // 
            this.labelName_Pre_CacheClearing.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Pre_CacheClearing, 3);
            this.labelName_Pre_CacheClearing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Pre_CacheClearing.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Pre_CacheClearing.ForeColor = System.Drawing.Color.Black;
            this.labelName_Pre_CacheClearing.Location = new System.Drawing.Point(115, 55);
            this.labelName_Pre_CacheClearing.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Pre_CacheClearing.Name = "labelName_Pre_CacheClearing";
            this.labelName_Pre_CacheClearing.Size = new System.Drawing.Size(140, 16);
            this.labelName_Pre_CacheClearing.TabIndex = 36;
            this.labelName_Pre_CacheClearing.Text = "Cache clearing";
            this.labelName_Pre_CacheClearing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExecutionBandPostWarm
            // 
            this.panelExecutionBandPostWarm.BackColor = System.Drawing.Color.Gray;
            this.panelExecutionBandPostWarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandPostWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandPostWarm.Location = new System.Drawing.Point(0, 310);
            this.panelExecutionBandPostWarm.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandPostWarm.Name = "panelExecutionBandPostWarm";
            this.tableLayoutPanelActivities.SetRowSpan(this.panelExecutionBandPostWarm, 4);
            this.panelExecutionBandPostWarm.Size = new System.Drawing.Size(5, 64);
            this.panelExecutionBandPostWarm.TabIndex = 34;
            // 
            // panelExecutionTaskPostWarm
            // 
            this.panelExecutionTaskPostWarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelActivities.SetColumnSpan(this.panelExecutionTaskPostWarm, 2);
            this.panelExecutionTaskPostWarm.Controls.Add(this.pictureBoxExecutionPicturePostWarm);
            this.panelExecutionTaskPostWarm.Controls.Add(this.labelTitlePostWarm);
            this.panelExecutionTaskPostWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskPostWarm.Location = new System.Drawing.Point(5, 310);
            this.panelExecutionTaskPostWarm.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskPostWarm.Name = "panelExecutionTaskPostWarm";
            this.tableLayoutPanelActivities.SetRowSpan(this.panelExecutionTaskPostWarm, 4);
            this.panelExecutionTaskPostWarm.Size = new System.Drawing.Size(105, 64);
            this.panelExecutionTaskPostWarm.TabIndex = 33;
            // 
            // pictureBoxExecutionPicturePostWarm
            // 
            this.pictureBoxExecutionPicturePostWarm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPicturePostWarm.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPicturePostWarm.Image")));
            this.pictureBoxExecutionPicturePostWarm.Location = new System.Drawing.Point(69, 0);
            this.pictureBoxExecutionPicturePostWarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPicturePostWarm.Name = "pictureBoxExecutionPicturePostWarm";
            this.pictureBoxExecutionPicturePostWarm.Size = new System.Drawing.Size(34, 62);
            this.pictureBoxExecutionPicturePostWarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPicturePostWarm.TabIndex = 5;
            this.pictureBoxExecutionPicturePostWarm.TabStop = false;
            // 
            // labelTitlePostWarm
            // 
            this.labelTitlePostWarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitlePostWarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePostWarm.Location = new System.Drawing.Point(0, 0);
            this.labelTitlePostWarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitlePostWarm.Name = "labelTitlePostWarm";
            this.labelTitlePostWarm.Size = new System.Drawing.Size(71, 62);
            this.labelTitlePostWarm.TabIndex = 39;
            this.labelTitlePostWarm.Text = "POST WARM EXECUTION ACTIVITIES";
            this.labelTitlePostWarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelExecutionBandWarmCache
            // 
            this.panelExecutionBandWarmCache.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.panelExecutionBandWarmCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandWarmCache.Location = new System.Drawing.Point(0, 238);
            this.panelExecutionBandWarmCache.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandWarmCache.Name = "panelExecutionBandWarmCache";
            this.tableLayoutPanelActivities.SetRowSpan(this.panelExecutionBandWarmCache, 4);
            this.panelExecutionBandWarmCache.Size = new System.Drawing.Size(5, 64);
            this.panelExecutionBandWarmCache.TabIndex = 32;
            // 
            // panelExecutionTaskWarmCache
            // 
            this.panelExecutionTaskWarmCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelActivities.SetColumnSpan(this.panelExecutionTaskWarmCache, 2);
            this.panelExecutionTaskWarmCache.Controls.Add(this.pictureBoxExecutionPictureWarm);
            this.panelExecutionTaskWarmCache.Controls.Add(this.labelTitleWarmCache);
            this.panelExecutionTaskWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskWarmCache.Location = new System.Drawing.Point(5, 238);
            this.panelExecutionTaskWarmCache.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskWarmCache.Name = "panelExecutionTaskWarmCache";
            this.tableLayoutPanelActivities.SetRowSpan(this.panelExecutionTaskWarmCache, 4);
            this.panelExecutionTaskWarmCache.Size = new System.Drawing.Size(105, 64);
            this.panelExecutionTaskWarmCache.TabIndex = 30;
            // 
            // pictureBoxExecutionPictureWarm
            // 
            this.pictureBoxExecutionPictureWarm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPictureWarm.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPictureWarm.Image")));
            this.pictureBoxExecutionPictureWarm.Location = new System.Drawing.Point(69, 0);
            this.pictureBoxExecutionPictureWarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPictureWarm.Name = "pictureBoxExecutionPictureWarm";
            this.pictureBoxExecutionPictureWarm.Size = new System.Drawing.Size(34, 62);
            this.pictureBoxExecutionPictureWarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPictureWarm.TabIndex = 5;
            this.pictureBoxExecutionPictureWarm.TabStop = false;
            // 
            // labelTitleWarmCache
            // 
            this.labelTitleWarmCache.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitleWarmCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleWarmCache.Location = new System.Drawing.Point(0, 0);
            this.labelTitleWarmCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitleWarmCache.Name = "labelTitleWarmCache";
            this.labelTitleWarmCache.Size = new System.Drawing.Size(71, 62);
            this.labelTitleWarmCache.TabIndex = 40;
            this.labelTitleWarmCache.Text = "WARM CACHE ACTIVITIES";
            this.labelTitleWarmCache.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelExecutionBandColdCache
            // 
            this.panelExecutionBandColdCache.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheColor;
            this.panelExecutionBandColdCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandColdCache.Location = new System.Drawing.Point(0, 95);
            this.panelExecutionBandColdCache.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandColdCache.Name = "panelExecutionBandColdCache";
            this.tableLayoutPanelActivities.SetRowSpan(this.panelExecutionBandColdCache, 4);
            this.panelExecutionBandColdCache.Size = new System.Drawing.Size(5, 64);
            this.panelExecutionBandColdCache.TabIndex = 29;
            // 
            // panelExecutionTaskColdCache
            // 
            this.panelExecutionTaskColdCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelActivities.SetColumnSpan(this.panelExecutionTaskColdCache, 2);
            this.panelExecutionTaskColdCache.Controls.Add(this.pictureBoxExecutionPictureCold);
            this.panelExecutionTaskColdCache.Controls.Add(this.labelTitleColdCache);
            this.panelExecutionTaskColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskColdCache.Location = new System.Drawing.Point(5, 95);
            this.panelExecutionTaskColdCache.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskColdCache.Name = "panelExecutionTaskColdCache";
            this.tableLayoutPanelActivities.SetRowSpan(this.panelExecutionTaskColdCache, 4);
            this.panelExecutionTaskColdCache.Size = new System.Drawing.Size(105, 64);
            this.panelExecutionTaskColdCache.TabIndex = 28;
            // 
            // pictureBoxExecutionPictureCold
            // 
            this.pictureBoxExecutionPictureCold.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPictureCold.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPictureCold.Image")));
            this.pictureBoxExecutionPictureCold.Location = new System.Drawing.Point(69, 0);
            this.pictureBoxExecutionPictureCold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPictureCold.Name = "pictureBoxExecutionPictureCold";
            this.pictureBoxExecutionPictureCold.Size = new System.Drawing.Size(34, 62);
            this.pictureBoxExecutionPictureCold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPictureCold.TabIndex = 5;
            this.pictureBoxExecutionPictureCold.TabStop = false;
            // 
            // labelTitleColdCache
            // 
            this.labelTitleColdCache.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitleColdCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleColdCache.Location = new System.Drawing.Point(0, 0);
            this.labelTitleColdCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitleColdCache.Name = "labelTitleColdCache";
            this.labelTitleColdCache.Size = new System.Drawing.Size(71, 62);
            this.labelTitleColdCache.TabIndex = 39;
            this.labelTitleColdCache.Text = "COLD CACHE ACTIVITIES";
            this.labelTitleColdCache.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelExecutionBandPre
            // 
            this.panelExecutionBandPre.BackColor = System.Drawing.Color.Gray;
            this.panelExecutionBandPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandPre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandPre.Location = new System.Drawing.Point(0, 23);
            this.panelExecutionBandPre.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandPre.Name = "panelExecutionBandPre";
            this.tableLayoutPanelActivities.SetRowSpan(this.panelExecutionBandPre, 4);
            this.panelExecutionBandPre.Size = new System.Drawing.Size(5, 64);
            this.panelExecutionBandPre.TabIndex = 24;
            // 
            // panelExecutionTaskPre
            // 
            this.panelExecutionTaskPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelActivities.SetColumnSpan(this.panelExecutionTaskPre, 2);
            this.panelExecutionTaskPre.Controls.Add(this.pictureBoxExecutionPicturePre);
            this.panelExecutionTaskPre.Controls.Add(this.labelTitlePre);
            this.panelExecutionTaskPre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskPre.Location = new System.Drawing.Point(5, 23);
            this.panelExecutionTaskPre.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskPre.Name = "panelExecutionTaskPre";
            this.tableLayoutPanelActivities.SetRowSpan(this.panelExecutionTaskPre, 4);
            this.panelExecutionTaskPre.Size = new System.Drawing.Size(105, 64);
            this.panelExecutionTaskPre.TabIndex = 25;
            // 
            // pictureBoxExecutionPicturePre
            // 
            this.pictureBoxExecutionPicturePre.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPicturePre.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPicturePre.Image")));
            this.pictureBoxExecutionPicturePre.Location = new System.Drawing.Point(69, 0);
            this.pictureBoxExecutionPicturePre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPicturePre.Name = "pictureBoxExecutionPicturePre";
            this.pictureBoxExecutionPicturePre.Size = new System.Drawing.Size(34, 62);
            this.pictureBoxExecutionPicturePre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPicturePre.TabIndex = 5;
            this.pictureBoxExecutionPicturePre.TabStop = false;
            // 
            // labelTitlePre
            // 
            this.labelTitlePre.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitlePre.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePre.Location = new System.Drawing.Point(0, 0);
            this.labelTitlePre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitlePre.Name = "labelTitlePre";
            this.labelTitlePre.Size = new System.Drawing.Size(71, 62);
            this.labelTitlePre.TabIndex = 38;
            this.labelTitlePre.Text = "PRE EXECUTION ACTIVITIES";
            this.labelTitlePre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_Pre_QuerySyntaxValidation
            // 
            this.labelName_Pre_QuerySyntaxValidation.AutoSize = true;
            this.tableLayoutPanelActivities.SetColumnSpan(this.labelName_Pre_QuerySyntaxValidation, 3);
            this.labelName_Pre_QuerySyntaxValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Pre_QuerySyntaxValidation.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Pre_QuerySyntaxValidation.ForeColor = System.Drawing.Color.Black;
            this.labelName_Pre_QuerySyntaxValidation.Location = new System.Drawing.Point(115, 39);
            this.labelName_Pre_QuerySyntaxValidation.Margin = new System.Windows.Forms.Padding(0);
            this.labelName_Pre_QuerySyntaxValidation.Name = "labelName_Pre_QuerySyntaxValidation";
            this.labelName_Pre_QuerySyntaxValidation.Size = new System.Drawing.Size(140, 16);
            this.labelName_Pre_QuerySyntaxValidation.TabIndex = 35;
            this.labelName_Pre_QuerySyntaxValidation.Text = "Query syntax validation";
            this.labelName_Pre_QuerySyntaxValidation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlExecutionInfo
            // 
            this.tabControlExecutionInfo.Controls.Add(this.tabPageExecution);
            this.tabControlExecutionInfo.Controls.Add(this.tabPageEnvironment);
            this.tabControlExecutionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlExecutionInfo.Location = new System.Drawing.Point(0, 0);
            this.tabControlExecutionInfo.Name = "tabControlExecutionInfo";
            this.tabControlExecutionInfo.SelectedIndex = 0;
            this.tabControlExecutionInfo.Size = new System.Drawing.Size(1138, 700);
            this.tabControlExecutionInfo.TabIndex = 124;
            // 
            // tabPageEnvironment
            // 
            this.tabPageEnvironment.Controls.Add(this.tabControlEnvironmentDetails);
            this.tabPageEnvironment.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnvironment.Name = "tabPageEnvironment";
            this.tabPageEnvironment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEnvironment.Size = new System.Drawing.Size(1130, 674);
            this.tabPageEnvironment.TabIndex = 3;
            this.tabPageEnvironment.Text = "Environment";
            this.tabPageEnvironment.UseVisualStyleBackColor = true;
            // 
            // tabControlEnvironmentDetails
            // 
            this.tabControlEnvironmentDetails.Controls.Add(this.tabPageClient);
            this.tabControlEnvironmentDetails.Controls.Add(this.tabPageASQASSASAssembly);
            this.tabControlEnvironmentDetails.Controls.Add(this.tabPageSSAS);
            this.tabControlEnvironmentDetails.Controls.Add(this.tabPageSQLServer);
            this.tabControlEnvironmentDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEnvironmentDetails.Location = new System.Drawing.Point(3, 3);
            this.tabControlEnvironmentDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlEnvironmentDetails.Name = "tabControlEnvironmentDetails";
            this.tabControlEnvironmentDetails.SelectedIndex = 0;
            this.tabControlEnvironmentDetails.Size = new System.Drawing.Size(1124, 668);
            this.tabControlEnvironmentDetails.TabIndex = 0;
            // 
            // tabPageClient
            // 
            this.tabPageClient.Controls.Add(this.panelClient);
            this.tabPageClient.Location = new System.Drawing.Point(4, 22);
            this.tabPageClient.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageClient.Name = "tabPageClient";
            this.tabPageClient.Size = new System.Drawing.Size(1116, 642);
            this.tabPageClient.TabIndex = 3;
            this.tabPageClient.Text = "Client";
            this.tabPageClient.UseVisualStyleBackColor = true;
            // 
            // panelClient
            // 
            this.panelClient.BackColor = System.Drawing.Color.White;
            this.panelClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClient.Controls.Add(this.tableLayoutPanelClient);
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClient.Location = new System.Drawing.Point(0, 0);
            this.panelClient.Margin = new System.Windows.Forms.Padding(0);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(1116, 642);
            this.panelClient.TabIndex = 0;
            // 
            // tableLayoutPanelClient
            // 
            this.tableLayoutPanelClient.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelClient.ColumnCount = 7;
            this.tableLayoutPanelClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutPanelClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutPanelClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClient.Controls.Add(this.labelClientTypeTitle, 2, 2);
            this.tableLayoutPanelClient.Controls.Add(this.labelUserNameTitle, 2, 4);
            this.tableLayoutPanelClient.Controls.Add(this.labelUserNameValue, 4, 4);
            this.tableLayoutPanelClient.Controls.Add(this.labelClientVersionTitle, 2, 3);
            this.tableLayoutPanelClient.Controls.Add(this.labelClientVersionValue, 4, 3);
            this.tableLayoutPanelClient.Controls.Add(this.labelClientTypeValue, 4, 2);
            this.tableLayoutPanelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelClient.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelClient.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelClient.Name = "tableLayoutPanelClient";
            this.tableLayoutPanelClient.RowCount = 7;
            this.tableLayoutPanelClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelClient.Size = new System.Drawing.Size(1114, 640);
            this.tableLayoutPanelClient.TabIndex = 113;
            // 
            // labelClientTypeTitle
            // 
            this.labelClientTypeTitle.AutoSize = true;
            this.labelClientTypeTitle.BorderColor = System.Drawing.Color.Black;
            this.labelClientTypeTitle.BorderHeightOffset = 2;
            this.labelClientTypeTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelClientTypeTitle.BorderWidthOffset = 2;
            this.labelClientTypeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelClientTypeTitle.DrawBorder = false;
            this.labelClientTypeTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelClientTypeTitle.Location = new System.Drawing.Point(236, 290);
            this.labelClientTypeTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelClientTypeTitle.Name = "labelClientTypeTitle";
            this.labelClientTypeTitle.Size = new System.Drawing.Size(318, 20);
            this.labelClientTypeTitle.TabIndex = 0;
            this.labelClientTypeTitle.Text = "Type";
            this.labelClientTypeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelUserNameTitle
            // 
            this.labelUserNameTitle.AutoSize = true;
            this.labelUserNameTitle.BorderColor = System.Drawing.Color.Black;
            this.labelUserNameTitle.BorderHeightOffset = 2;
            this.labelUserNameTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelUserNameTitle.BorderWidthOffset = 2;
            this.labelUserNameTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUserNameTitle.DrawBorder = false;
            this.labelUserNameTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelUserNameTitle.Location = new System.Drawing.Point(236, 330);
            this.labelUserNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelUserNameTitle.Name = "labelUserNameTitle";
            this.labelUserNameTitle.Size = new System.Drawing.Size(318, 20);
            this.labelUserNameTitle.TabIndex = 1;
            this.labelUserNameTitle.Text = "User name";
            this.labelUserNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelUserNameValue
            // 
            this.labelUserNameValue.AutoSize = true;
            this.labelUserNameValue.BorderColor = System.Drawing.Color.Black;
            this.labelUserNameValue.BorderHeightOffset = 2;
            this.labelUserNameValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelUserNameValue.BorderWidthOffset = 2;
            this.labelUserNameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUserNameValue.DrawBorder = false;
            this.labelUserNameValue.Location = new System.Drawing.Point(559, 330);
            this.labelUserNameValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelUserNameValue.Name = "labelUserNameValue";
            this.labelUserNameValue.Size = new System.Drawing.Size(318, 20);
            this.labelUserNameValue.TabIndex = 2;
            this.labelUserNameValue.Text = "User name";
            this.labelUserNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelClientVersionTitle
            // 
            this.labelClientVersionTitle.AutoSize = true;
            this.labelClientVersionTitle.BorderColor = System.Drawing.Color.Black;
            this.labelClientVersionTitle.BorderHeightOffset = 2;
            this.labelClientVersionTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelClientVersionTitle.BorderWidthOffset = 2;
            this.labelClientVersionTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelClientVersionTitle.DrawBorder = false;
            this.labelClientVersionTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelClientVersionTitle.Location = new System.Drawing.Point(236, 310);
            this.labelClientVersionTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelClientVersionTitle.Name = "labelClientVersionTitle";
            this.labelClientVersionTitle.Size = new System.Drawing.Size(318, 20);
            this.labelClientVersionTitle.TabIndex = 3;
            this.labelClientVersionTitle.Text = "Version";
            this.labelClientVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelClientVersionValue
            // 
            this.labelClientVersionValue.AutoSize = true;
            this.labelClientVersionValue.BorderColor = System.Drawing.Color.Black;
            this.labelClientVersionValue.BorderHeightOffset = 2;
            this.labelClientVersionValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelClientVersionValue.BorderWidthOffset = 2;
            this.labelClientVersionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelClientVersionValue.DrawBorder = false;
            this.labelClientVersionValue.Location = new System.Drawing.Point(559, 310);
            this.labelClientVersionValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelClientVersionValue.Name = "labelClientVersionValue";
            this.labelClientVersionValue.Size = new System.Drawing.Size(318, 20);
            this.labelClientVersionValue.TabIndex = 4;
            this.labelClientVersionValue.Text = "Version";
            this.labelClientVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelClientTypeValue
            // 
            this.labelClientTypeValue.AutoSize = true;
            this.labelClientTypeValue.BorderColor = System.Drawing.Color.Black;
            this.labelClientTypeValue.BorderHeightOffset = 2;
            this.labelClientTypeValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelClientTypeValue.BorderWidthOffset = 2;
            this.labelClientTypeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelClientTypeValue.DrawBorder = false;
            this.labelClientTypeValue.Location = new System.Drawing.Point(559, 290);
            this.labelClientTypeValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelClientTypeValue.Name = "labelClientTypeValue";
            this.labelClientTypeValue.Size = new System.Drawing.Size(318, 20);
            this.labelClientTypeValue.TabIndex = 5;
            this.labelClientTypeValue.Text = "Type";
            this.labelClientTypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageASQASSASAssembly
            // 
            this.tabPageASQASSASAssembly.Controls.Add(this.splitContainerASQAAssembly);
            this.tabPageASQASSASAssembly.Location = new System.Drawing.Point(4, 22);
            this.tabPageASQASSASAssembly.Name = "tabPageASQASSASAssembly";
            this.tabPageASQASSASAssembly.Size = new System.Drawing.Size(1116, 642);
            this.tabPageASQASSASAssembly.TabIndex = 4;
            this.tabPageASQASSASAssembly.Text = "ASQA SSAS Assembly";
            this.tabPageASQASSASAssembly.UseVisualStyleBackColor = true;
            // 
            // splitContainerASQAAssembly
            // 
            this.splitContainerASQAAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerASQAAssembly.Location = new System.Drawing.Point(0, 0);
            this.splitContainerASQAAssembly.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerASQAAssembly.Name = "splitContainerASQAAssembly";
            this.splitContainerASQAAssembly.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerASQAAssembly.Panel1
            // 
            this.splitContainerASQAAssembly.Panel1.Controls.Add(this.panelASQAAssembly);
            // 
            // splitContainerASQAAssembly.Panel2
            // 
            this.splitContainerASQAAssembly.Panel2.Controls.Add(this.panelMessageExternal);
            this.splitContainerASQAAssembly.Panel2.Controls.Add(this.panelEngineSettings);
            this.splitContainerASQAAssembly.Panel2.Controls.Add(this.panelOptionalProfilerEvents);
            this.splitContainerASQAAssembly.Panel2.Controls.Add(this.panelOptionalPerformanceCounters);
            this.splitContainerASQAAssembly.Panel2.Controls.Add(this.panelSSASASQADetailsTitle);
            this.splitContainerASQAAssembly.Size = new System.Drawing.Size(1116, 642);
            this.splitContainerASQAAssembly.SplitterDistance = 248;
            this.splitContainerASQAAssembly.TabIndex = 112;
            // 
            // panelASQAAssembly
            // 
            this.panelASQAAssembly.BackColor = System.Drawing.Color.White;
            this.panelASQAAssembly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelASQAAssembly.Controls.Add(this.tableLayoutPanel1);
            this.panelASQAAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelASQAAssembly.Location = new System.Drawing.Point(0, 0);
            this.panelASQAAssembly.Margin = new System.Windows.Forms.Padding(0);
            this.panelASQAAssembly.Name = "panelASQAAssembly";
            this.panelASQAAssembly.Size = new System.Drawing.Size(1116, 248);
            this.panelASQAAssembly.TabIndex = 112;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelASQAAssemblyVersion_ASQATab_Title, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelASQAAssemblyVersion_ASQATab_Value, 6, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 246);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelASQAAssemblyVersion_ASQATab_Title
            // 
            this.labelASQAAssemblyVersion_ASQATab_Title.AutoSize = true;
            this.labelASQAAssemblyVersion_ASQATab_Title.BorderColor = System.Drawing.Color.Black;
            this.labelASQAAssemblyVersion_ASQATab_Title.BorderHeightOffset = 2;
            this.labelASQAAssemblyVersion_ASQATab_Title.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelASQAAssemblyVersion_ASQATab_Title.BorderWidthOffset = 2;
            this.labelASQAAssemblyVersion_ASQATab_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelASQAAssemblyVersion_ASQATab_Title.DrawBorder = false;
            this.labelASQAAssemblyVersion_ASQATab_Title.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelASQAAssemblyVersion_ASQATab_Title.Location = new System.Drawing.Point(257, 114);
            this.labelASQAAssemblyVersion_ASQATab_Title.Margin = new System.Windows.Forms.Padding(0);
            this.labelASQAAssemblyVersion_ASQATab_Title.Name = "labelASQAAssemblyVersion_ASQATab_Title";
            this.labelASQAAssemblyVersion_ASQATab_Title.Size = new System.Drawing.Size(318, 20);
            this.labelASQAAssemblyVersion_ASQATab_Title.TabIndex = 85;
            this.labelASQAAssemblyVersion_ASQATab_Title.Text = "ASQA SSAS Assembly version";
            this.labelASQAAssemblyVersion_ASQATab_Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelASQAAssemblyVersion_ASQATab_Value
            // 
            this.labelASQAAssemblyVersion_ASQATab_Value.AutoSize = true;
            this.labelASQAAssemblyVersion_ASQATab_Value.BorderColor = System.Drawing.Color.Black;
            this.labelASQAAssemblyVersion_ASQATab_Value.BorderHeightOffset = 2;
            this.labelASQAAssemblyVersion_ASQATab_Value.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelASQAAssemblyVersion_ASQATab_Value.BorderWidthOffset = 2;
            this.labelASQAAssemblyVersion_ASQATab_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelASQAAssemblyVersion_ASQATab_Value.DrawBorder = false;
            this.labelASQAAssemblyVersion_ASQATab_Value.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelASQAAssemblyVersion_ASQATab_Value.Location = new System.Drawing.Point(580, 114);
            this.labelASQAAssemblyVersion_ASQATab_Value.Margin = new System.Windows.Forms.Padding(0);
            this.labelASQAAssemblyVersion_ASQATab_Value.Name = "labelASQAAssemblyVersion_ASQATab_Value";
            this.labelASQAAssemblyVersion_ASQATab_Value.Size = new System.Drawing.Size(318, 20);
            this.labelASQAAssemblyVersion_ASQATab_Value.TabIndex = 84;
            this.labelASQAAssemblyVersion_ASQATab_Value.Text = "ASQA SSAS Assembly version";
            this.labelASQAAssemblyVersion_ASQATab_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMessageExternal
            // 
            this.panelMessageExternal.BackColor = System.Drawing.SystemColors.Control;
            this.panelMessageExternal.Controls.Add(this.tableLayoutPanelMessageExternal);
            this.panelMessageExternal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMessageExternal.Location = new System.Drawing.Point(0, 364);
            this.panelMessageExternal.Margin = new System.Windows.Forms.Padding(0);
            this.panelMessageExternal.Name = "panelMessageExternal";
            this.panelMessageExternal.Size = new System.Drawing.Size(1116, 26);
            this.panelMessageExternal.TabIndex = 91;
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
            this.tableLayoutPanelMessageExternal.Size = new System.Drawing.Size(1116, 26);
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
            this.panelMessageInternal.Size = new System.Drawing.Size(1116, 24);
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
            this.tableLayoutPanelMessageInternal.Size = new System.Drawing.Size(1114, 22);
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
            this.customLabelMessage.Size = new System.Drawing.Size(1084, 18);
            this.customLabelMessage.TabIndex = 28;
            this.customLabelMessage.Text = "No optional {0}!";
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
            // panelEngineSettings
            // 
            this.panelEngineSettings.BackColor = System.Drawing.Color.White;
            this.panelEngineSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEngineSettings.Controls.Add(this.tableLayoutEngineSettings);
            this.panelEngineSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEngineSettings.Location = new System.Drawing.Point(0, 18);
            this.panelEngineSettings.Margin = new System.Windows.Forms.Padding(0);
            this.panelEngineSettings.Name = "panelEngineSettings";
            this.panelEngineSettings.Size = new System.Drawing.Size(1116, 372);
            this.panelEngineSettings.TabIndex = 90;
            // 
            // tableLayoutEngineSettings
            // 
            this.tableLayoutEngineSettings.BackColor = System.Drawing.Color.White;
            this.tableLayoutEngineSettings.ColumnCount = 9;
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 561F));
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutEngineSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutEngineSettings.Controls.Add(this.customLabelControlCache, 2, 1);
            this.tableLayoutEngineSettings.Controls.Add(this.pictureBoxCache, 1, 1);
            this.tableLayoutEngineSettings.Controls.Add(this.groupBoxClearCacheMode, 2, 2);
            this.tableLayoutEngineSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutEngineSettings.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutEngineSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutEngineSettings.Name = "tableLayoutEngineSettings";
            this.tableLayoutEngineSettings.RowCount = 6;
            this.tableLayoutEngineSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutEngineSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutEngineSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutEngineSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutEngineSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutEngineSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutEngineSettings.Size = new System.Drawing.Size(1114, 370);
            this.tableLayoutEngineSettings.TabIndex = 2;
            // 
            // customLabelControlCache
            // 
            this.customLabelControlCache.BorderColor = System.Drawing.Color.Black;
            this.customLabelControlCache.BorderHeightOffset = 2;
            this.customLabelControlCache.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelControlCache.BorderWidthOffset = 2;
            this.customLabelControlCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabelControlCache.DrawBorder = false;
            this.customLabelControlCache.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelControlCache.Location = new System.Drawing.Point(39, 5);
            this.customLabelControlCache.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelControlCache.Name = "customLabelControlCache";
            this.customLabelControlCache.Size = new System.Drawing.Size(160, 34);
            this.customLabelControlCache.TabIndex = 96;
            this.customLabelControlCache.Text = "Cache";
            this.customLabelControlCache.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxCache
            // 
            this.pictureBoxCache.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.Cache_32x32;
            this.pictureBoxCache.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxCache.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxCache.Name = "pictureBoxCache";
            this.pictureBoxCache.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxCache.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxCache.TabIndex = 94;
            this.pictureBoxCache.TabStop = false;
            // 
            // groupBoxClearCacheMode
            // 
            this.tableLayoutEngineSettings.SetColumnSpan(this.groupBoxClearCacheMode, 5);
            this.groupBoxClearCacheMode.Controls.Add(this.radioButtonClearCacheModeFileSystemOnly);
            this.groupBoxClearCacheMode.Controls.Add(this.radioButtonClearCacheModeAllDatabasesAndFileSystem);
            this.groupBoxClearCacheMode.Controls.Add(this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem);
            this.groupBoxClearCacheMode.Controls.Add(this.radioButtonClearCacheModeCurrentCubeAndFileSystem);
            this.groupBoxClearCacheMode.Controls.Add(this.radioButtonClearCacheModeAllDatabases);
            this.groupBoxClearCacheMode.Controls.Add(this.radioButtonClearCacheModeCurrentDatabase);
            this.groupBoxClearCacheMode.Controls.Add(this.radioButtonClearCacheModeCurrentCube);
            this.groupBoxClearCacheMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxClearCacheMode.Enabled = false;
            this.groupBoxClearCacheMode.Location = new System.Drawing.Point(39, 39);
            this.groupBoxClearCacheMode.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxClearCacheMode.Name = "groupBoxClearCacheMode";
            this.groupBoxClearCacheMode.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxClearCacheMode.Size = new System.Drawing.Size(926, 70);
            this.groupBoxClearCacheMode.TabIndex = 12;
            this.groupBoxClearCacheMode.TabStop = false;
            this.groupBoxClearCacheMode.Text = "Clear cache mode";
            // 
            // radioButtonClearCacheModeAllDatabasesAndFileSystem
            // 
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.AutoSize = true;
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.Location = new System.Drawing.Point(656, 30);
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.Name = "radioButtonClearCacheModeAllDatabasesAndFileSystem";
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.Size = new System.Drawing.Size(156, 17);
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.TabIndex = 126;
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.TabStop = true;
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.Text = "AllDatabasesAndFileSystem";
            this.radioButtonClearCacheModeAllDatabasesAndFileSystem.UseVisualStyleBackColor = true;
            // 
            // radioButtonClearCacheModeCurrentDatabaseAndFileSystem
            // 
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.AutoSize = true;
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.Location = new System.Drawing.Point(474, 30);
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.Name = "radioButtonClearCacheModeCurrentDatabaseAndFileSystem";
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.Size = new System.Drawing.Size(174, 17);
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.TabIndex = 4;
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.TabStop = true;
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.Text = "CurrentDatabaseAndFileSystem";
            this.radioButtonClearCacheModeCurrentDatabaseAndFileSystem.UseVisualStyleBackColor = true;
            // 
            // radioButtonClearCacheModeCurrentCubeAndFileSystem
            // 
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.AutoSize = true;
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.Location = new System.Drawing.Point(313, 30);
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.Name = "radioButtonClearCacheModeCurrentCubeAndFileSystem";
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.Size = new System.Drawing.Size(153, 17);
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.TabIndex = 3;
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.TabStop = true;
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.Text = "CurrentCubeAndFileSystem";
            this.radioButtonClearCacheModeCurrentCubeAndFileSystem.UseVisualStyleBackColor = true;
            // 
            // radioButtonClearCacheModeAllDatabases
            // 
            this.radioButtonClearCacheModeAllDatabases.AutoSize = true;
            this.radioButtonClearCacheModeAllDatabases.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonClearCacheModeAllDatabases.Location = new System.Drawing.Point(221, 30);
            this.radioButtonClearCacheModeAllDatabases.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonClearCacheModeAllDatabases.Name = "radioButtonClearCacheModeAllDatabases";
            this.radioButtonClearCacheModeAllDatabases.Size = new System.Drawing.Size(87, 17);
            this.radioButtonClearCacheModeAllDatabases.TabIndex = 2;
            this.radioButtonClearCacheModeAllDatabases.TabStop = true;
            this.radioButtonClearCacheModeAllDatabases.Text = "AllDatabases";
            this.radioButtonClearCacheModeAllDatabases.UseVisualStyleBackColor = true;
            // 
            // radioButtonClearCacheModeCurrentDatabase
            // 
            this.radioButtonClearCacheModeCurrentDatabase.AutoSize = true;
            this.radioButtonClearCacheModeCurrentDatabase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonClearCacheModeCurrentDatabase.Location = new System.Drawing.Point(105, 30);
            this.radioButtonClearCacheModeCurrentDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonClearCacheModeCurrentDatabase.Name = "radioButtonClearCacheModeCurrentDatabase";
            this.radioButtonClearCacheModeCurrentDatabase.Size = new System.Drawing.Size(105, 17);
            this.radioButtonClearCacheModeCurrentDatabase.TabIndex = 1;
            this.radioButtonClearCacheModeCurrentDatabase.Text = "CurrentDatabase";
            this.radioButtonClearCacheModeCurrentDatabase.UseVisualStyleBackColor = true;
            // 
            // radioButtonClearCacheModeCurrentCube
            // 
            this.radioButtonClearCacheModeCurrentCube.AutoSize = true;
            this.radioButtonClearCacheModeCurrentCube.Location = new System.Drawing.Point(13, 30);
            this.radioButtonClearCacheModeCurrentCube.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonClearCacheModeCurrentCube.Name = "radioButtonClearCacheModeCurrentCube";
            this.radioButtonClearCacheModeCurrentCube.Size = new System.Drawing.Size(84, 17);
            this.radioButtonClearCacheModeCurrentCube.TabIndex = 0;
            this.radioButtonClearCacheModeCurrentCube.Text = "CurrentCube";
            this.radioButtonClearCacheModeCurrentCube.UseVisualStyleBackColor = true;
            // 
            // panelOptionalProfilerEvents
            // 
            this.panelOptionalProfilerEvents.BackColor = System.Drawing.Color.White;
            this.panelOptionalProfilerEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptionalProfilerEvents.Controls.Add(this.tableLayoutPanelProfilerEvents);
            this.panelOptionalProfilerEvents.Controls.Add(this.panelProfilerEventsTitle);
            this.panelOptionalProfilerEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOptionalProfilerEvents.Location = new System.Drawing.Point(0, 18);
            this.panelOptionalProfilerEvents.Margin = new System.Windows.Forms.Padding(0);
            this.panelOptionalProfilerEvents.Name = "panelOptionalProfilerEvents";
            this.panelOptionalProfilerEvents.Size = new System.Drawing.Size(1116, 372);
            this.panelOptionalProfilerEvents.TabIndex = 89;
            // 
            // tableLayoutPanelProfilerEvents
            // 
            this.tableLayoutPanelProfilerEvents.ColumnCount = 7;
            this.tableLayoutPanelProfilerEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelProfilerEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelProfilerEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelProfilerEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelProfilerEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanelProfilerEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProfilerEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelProfilerEvents.Controls.Add(this.panelProfilerEventsBottom, 0, 3);
            this.tableLayoutPanelProfilerEvents.Controls.Add(this.groupBoxEventsThreshold, 2, 1);
            this.tableLayoutPanelProfilerEvents.Controls.Add(this.treeViewProfilerEvents, 0, 4);
            this.tableLayoutPanelProfilerEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProfilerEvents.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanelProfilerEvents.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelProfilerEvents.Name = "tableLayoutPanelProfilerEvents";
            this.tableLayoutPanelProfilerEvents.RowCount = 6;
            this.tableLayoutPanelProfilerEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelProfilerEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelProfilerEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelProfilerEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelProfilerEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProfilerEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelProfilerEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelProfilerEvents.Size = new System.Drawing.Size(1114, 322);
            this.tableLayoutPanelProfilerEvents.TabIndex = 98;
            // 
            // panelProfilerEventsBottom
            // 
            this.panelProfilerEventsBottom.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanelProfilerEvents.SetColumnSpan(this.panelProfilerEventsBottom, 7);
            this.panelProfilerEventsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelProfilerEventsBottom.Location = new System.Drawing.Point(0, 80);
            this.panelProfilerEventsBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelProfilerEventsBottom.Name = "panelProfilerEventsBottom";
            this.panelProfilerEventsBottom.Size = new System.Drawing.Size(1114, 1);
            this.panelProfilerEventsBottom.TabIndex = 92;
            // 
            // groupBoxEventsThreshold
            // 
            this.tableLayoutPanelProfilerEvents.SetColumnSpan(this.groupBoxEventsThreshold, 4);
            this.groupBoxEventsThreshold.Controls.Add(this.numericUpDownEventsThreshold);
            this.groupBoxEventsThreshold.Controls.Add(this.radioButtonEventsThresholdLimited);
            this.groupBoxEventsThreshold.Controls.Add(this.radioButtonEventsThresholdUnlimited);
            this.groupBoxEventsThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEventsThreshold.Enabled = false;
            this.groupBoxEventsThreshold.Location = new System.Drawing.Point(39, 5);
            this.groupBoxEventsThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxEventsThreshold.Name = "groupBoxEventsThreshold";
            this.groupBoxEventsThreshold.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxEventsThreshold.Size = new System.Drawing.Size(1070, 70);
            this.groupBoxEventsThreshold.TabIndex = 14;
            this.groupBoxEventsThreshold.TabStop = false;
            this.groupBoxEventsThreshold.Text = "Events number threshold";
            // 
            // numericUpDownEventsThreshold
            // 
            this.numericUpDownEventsThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownEventsThreshold.Enabled = false;
            this.numericUpDownEventsThreshold.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numericUpDownEventsThreshold.Location = new System.Drawing.Point(304, 28);
            this.numericUpDownEventsThreshold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownEventsThreshold.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownEventsThreshold.Name = "numericUpDownEventsThreshold";
            this.numericUpDownEventsThreshold.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownEventsThreshold.TabIndex = 4;
            this.numericUpDownEventsThreshold.ThousandsSeparator = true;
            this.numericUpDownEventsThreshold.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // radioButtonEventsThresholdLimited
            // 
            this.radioButtonEventsThresholdLimited.AutoSize = true;
            this.radioButtonEventsThresholdLimited.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonEventsThresholdLimited.Location = new System.Drawing.Point(247, 30);
            this.radioButtonEventsThresholdLimited.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonEventsThresholdLimited.Name = "radioButtonEventsThresholdLimited";
            this.radioButtonEventsThresholdLimited.Size = new System.Drawing.Size(58, 17);
            this.radioButtonEventsThresholdLimited.TabIndex = 2;
            this.radioButtonEventsThresholdLimited.Text = "Limit to";
            this.radioButtonEventsThresholdLimited.UseVisualStyleBackColor = true;
            // 
            // radioButtonEventsThresholdUnlimited
            // 
            this.radioButtonEventsThresholdUnlimited.AutoSize = true;
            this.radioButtonEventsThresholdUnlimited.Checked = true;
            this.radioButtonEventsThresholdUnlimited.Location = new System.Drawing.Point(13, 30);
            this.radioButtonEventsThresholdUnlimited.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonEventsThresholdUnlimited.Name = "radioButtonEventsThresholdUnlimited";
            this.radioButtonEventsThresholdUnlimited.Size = new System.Drawing.Size(68, 17);
            this.radioButtonEventsThresholdUnlimited.TabIndex = 1;
            this.radioButtonEventsThresholdUnlimited.TabStop = true;
            this.radioButtonEventsThresholdUnlimited.Text = "Unlimited";
            this.radioButtonEventsThresholdUnlimited.UseVisualStyleBackColor = true;
            // 
            // treeViewProfilerEvents
            // 
            this.treeViewProfilerEvents.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewProfilerEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewProfilerEvents.CheckBoxes = true;
            this.tableLayoutPanelProfilerEvents.SetColumnSpan(this.treeViewProfilerEvents, 6);
            this.treeViewProfilerEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewProfilerEvents.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeViewProfilerEvents.Location = new System.Drawing.Point(0, 81);
            this.treeViewProfilerEvents.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewProfilerEvents.Name = "treeViewProfilerEvents";
            this.tableLayoutPanelProfilerEvents.SetRowSpan(this.treeViewProfilerEvents, 2);
            this.treeViewProfilerEvents.ShowLines = false;
            this.treeViewProfilerEvents.ShowNodeToolTips = true;
            this.treeViewProfilerEvents.Size = new System.Drawing.Size(1109, 241);
            this.treeViewProfilerEvents.TabIndex = 13;
            this.treeViewProfilerEvents.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.OnTreeView_DrawNode);
            // 
            // panelProfilerEventsTitle
            // 
            this.panelProfilerEventsTitle.Controls.Add(this.customLabelProfilerEventsTitle);
            this.panelProfilerEventsTitle.Controls.Add(this.pictureBoxProfilerEvents);
            this.panelProfilerEventsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProfilerEventsTitle.Location = new System.Drawing.Point(0, 0);
            this.panelProfilerEventsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelProfilerEventsTitle.Name = "panelProfilerEventsTitle";
            this.panelProfilerEventsTitle.Size = new System.Drawing.Size(1114, 48);
            this.panelProfilerEventsTitle.TabIndex = 99;
            // 
            // customLabelProfilerEventsTitle
            // 
            this.customLabelProfilerEventsTitle.AutoSize = true;
            this.customLabelProfilerEventsTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelProfilerEventsTitle.BorderHeightOffset = 2;
            this.customLabelProfilerEventsTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelProfilerEventsTitle.BorderWidthOffset = 2;
            this.customLabelProfilerEventsTitle.DrawBorder = false;
            this.customLabelProfilerEventsTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelProfilerEventsTitle.Location = new System.Drawing.Point(39, 16);
            this.customLabelProfilerEventsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelProfilerEventsTitle.Name = "customLabelProfilerEventsTitle";
            this.customLabelProfilerEventsTitle.Size = new System.Drawing.Size(72, 12);
            this.customLabelProfilerEventsTitle.TabIndex = 77;
            this.customLabelProfilerEventsTitle.Text = "Profiler Events";
            this.customLabelProfilerEventsTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBoxProfilerEvents
            // 
            this.pictureBoxProfilerEvents.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.Profiler_32x32;
            this.pictureBoxProfilerEvents.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxProfilerEvents.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxProfilerEvents.Name = "pictureBoxProfilerEvents";
            this.pictureBoxProfilerEvents.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxProfilerEvents.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxProfilerEvents.TabIndex = 76;
            this.pictureBoxProfilerEvents.TabStop = false;
            // 
            // panelOptionalPerformanceCounters
            // 
            this.panelOptionalPerformanceCounters.BackColor = System.Drawing.Color.White;
            this.panelOptionalPerformanceCounters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptionalPerformanceCounters.Controls.Add(this.tableLayoutPanelPerformanceCounters);
            this.panelOptionalPerformanceCounters.Controls.Add(this.panelPerformanceCountersTitle);
            this.panelOptionalPerformanceCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOptionalPerformanceCounters.Location = new System.Drawing.Point(0, 18);
            this.panelOptionalPerformanceCounters.Margin = new System.Windows.Forms.Padding(0);
            this.panelOptionalPerformanceCounters.Name = "panelOptionalPerformanceCounters";
            this.panelOptionalPerformanceCounters.Size = new System.Drawing.Size(1116, 372);
            this.panelOptionalPerformanceCounters.TabIndex = 88;
            // 
            // tableLayoutPanelPerformanceCounters
            // 
            this.tableLayoutPanelPerformanceCounters.ColumnCount = 1;
            this.tableLayoutPanelPerformanceCounters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPerformanceCounters.Controls.Add(this.treeViewPerformanceCounters, 0, 1);
            this.tableLayoutPanelPerformanceCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPerformanceCounters.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanelPerformanceCounters.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelPerformanceCounters.Name = "tableLayoutPanelPerformanceCounters";
            this.tableLayoutPanelPerformanceCounters.RowCount = 2;
            this.tableLayoutPanelPerformanceCounters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelPerformanceCounters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPerformanceCounters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPerformanceCounters.Size = new System.Drawing.Size(1114, 322);
            this.tableLayoutPanelPerformanceCounters.TabIndex = 99;
            // 
            // treeViewPerformanceCounters
            // 
            this.treeViewPerformanceCounters.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewPerformanceCounters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewPerformanceCounters.CheckBoxes = true;
            this.treeViewPerformanceCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewPerformanceCounters.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeViewPerformanceCounters.Location = new System.Drawing.Point(0, 5);
            this.treeViewPerformanceCounters.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewPerformanceCounters.Name = "treeViewPerformanceCounters";
            this.tableLayoutPanelPerformanceCounters.SetRowSpan(this.treeViewPerformanceCounters, 2);
            this.treeViewPerformanceCounters.ShowLines = false;
            this.treeViewPerformanceCounters.ShowNodeToolTips = true;
            this.treeViewPerformanceCounters.Size = new System.Drawing.Size(1114, 317);
            this.treeViewPerformanceCounters.TabIndex = 14;
            this.treeViewPerformanceCounters.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.OnTreeView_DrawNode);
            // 
            // panelPerformanceCountersTitle
            // 
            this.panelPerformanceCountersTitle.Controls.Add(this.customLabelPerformanceCountersTitle);
            this.panelPerformanceCountersTitle.Controls.Add(this.pictureBoxPerformanceCounters);
            this.panelPerformanceCountersTitle.Controls.Add(this.panelPerformanceCountersBottom);
            this.panelPerformanceCountersTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPerformanceCountersTitle.Location = new System.Drawing.Point(0, 0);
            this.panelPerformanceCountersTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelPerformanceCountersTitle.Name = "panelPerformanceCountersTitle";
            this.panelPerformanceCountersTitle.Size = new System.Drawing.Size(1114, 48);
            this.panelPerformanceCountersTitle.TabIndex = 100;
            // 
            // customLabelPerformanceCountersTitle
            // 
            this.customLabelPerformanceCountersTitle.AutoSize = true;
            this.customLabelPerformanceCountersTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelPerformanceCountersTitle.BorderHeightOffset = 2;
            this.customLabelPerformanceCountersTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelPerformanceCountersTitle.BorderWidthOffset = 2;
            this.customLabelPerformanceCountersTitle.DrawBorder = false;
            this.customLabelPerformanceCountersTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelPerformanceCountersTitle.Location = new System.Drawing.Point(39, 16);
            this.customLabelPerformanceCountersTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelPerformanceCountersTitle.Name = "customLabelPerformanceCountersTitle";
            this.customLabelPerformanceCountersTitle.Size = new System.Drawing.Size(108, 12);
            this.customLabelPerformanceCountersTitle.TabIndex = 77;
            this.customLabelPerformanceCountersTitle.Text = "Performance Counters";
            this.customLabelPerformanceCountersTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBoxPerformanceCounters
            // 
            this.pictureBoxPerformanceCounters.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.PerformanceCounter_32x32;
            this.pictureBoxPerformanceCounters.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxPerformanceCounters.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPerformanceCounters.Name = "pictureBoxPerformanceCounters";
            this.pictureBoxPerformanceCounters.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxPerformanceCounters.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPerformanceCounters.TabIndex = 76;
            this.pictureBoxPerformanceCounters.TabStop = false;
            // 
            // panelPerformanceCountersBottom
            // 
            this.panelPerformanceCountersBottom.BackColor = System.Drawing.Color.Black;
            this.panelPerformanceCountersBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPerformanceCountersBottom.Location = new System.Drawing.Point(0, 47);
            this.panelPerformanceCountersBottom.Name = "panelPerformanceCountersBottom";
            this.panelPerformanceCountersBottom.Size = new System.Drawing.Size(1114, 1);
            this.panelPerformanceCountersBottom.TabIndex = 91;
            // 
            // panelSSASASQADetailsTitle
            // 
            this.panelSSASASQADetailsTitle.Controls.Add(this.radioButtonPerformanceCounters);
            this.panelSSASASQADetailsTitle.Controls.Add(this.radioButtonProfilerEvents);
            this.panelSSASASQADetailsTitle.Controls.Add(this.radioButtonEngine);
            this.panelSSASASQADetailsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSSASASQADetailsTitle.Location = new System.Drawing.Point(0, 0);
            this.panelSSASASQADetailsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelSSASASQADetailsTitle.Name = "panelSSASASQADetailsTitle";
            this.panelSSASASQADetailsTitle.Size = new System.Drawing.Size(1116, 18);
            this.panelSSASASQADetailsTitle.TabIndex = 19;
            // 
            // radioButtonPerformanceCounters
            // 
            this.radioButtonPerformanceCounters.AutoSize = true;
            this.radioButtonPerformanceCounters.Location = new System.Drawing.Point(300, 0);
            this.radioButtonPerformanceCounters.Name = "radioButtonPerformanceCounters";
            this.radioButtonPerformanceCounters.Size = new System.Drawing.Size(130, 17);
            this.radioButtonPerformanceCounters.TabIndex = 95;
            this.radioButtonPerformanceCounters.Text = "Performance Counters";
            this.radioButtonPerformanceCounters.UseVisualStyleBackColor = true;
            this.radioButtonPerformanceCounters.Click += new System.EventHandler(this.OnRadioButtonsASQAAssembly_Click);
            // 
            // radioButtonProfilerEvents
            // 
            this.radioButtonProfilerEvents.AutoSize = true;
            this.radioButtonProfilerEvents.Location = new System.Drawing.Point(140, 0);
            this.radioButtonProfilerEvents.Name = "radioButtonProfilerEvents";
            this.radioButtonProfilerEvents.Size = new System.Drawing.Size(93, 17);
            this.radioButtonProfilerEvents.TabIndex = 94;
            this.radioButtonProfilerEvents.Text = "Profiler Events";
            this.radioButtonProfilerEvents.UseVisualStyleBackColor = true;
            this.radioButtonProfilerEvents.Click += new System.EventHandler(this.OnRadioButtonsASQAAssembly_Click);
            // 
            // radioButtonEngine
            // 
            this.radioButtonEngine.AutoSize = true;
            this.radioButtonEngine.Checked = true;
            this.radioButtonEngine.Location = new System.Drawing.Point(8, 0);
            this.radioButtonEngine.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonEngine.Name = "radioButtonEngine";
            this.radioButtonEngine.Size = new System.Drawing.Size(97, 17);
            this.radioButtonEngine.TabIndex = 93;
            this.radioButtonEngine.TabStop = true;
            this.radioButtonEngine.Text = "Engine settings";
            this.radioButtonEngine.UseVisualStyleBackColor = true;
            this.radioButtonEngine.Click += new System.EventHandler(this.OnRadioButtonsASQAAssembly_Click);
            // 
            // radioButtonClearCacheModeFileSystemOnly
            // 
            this.radioButtonClearCacheModeFileSystemOnly.AutoSize = true;
            this.radioButtonClearCacheModeFileSystemOnly.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonClearCacheModeFileSystemOnly.Location = new System.Drawing.Point(820, 30);
            this.radioButtonClearCacheModeFileSystemOnly.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonClearCacheModeFileSystemOnly.Name = "radioButtonClearCacheModeFileSystemOnly";
            this.radioButtonClearCacheModeFileSystemOnly.Size = new System.Drawing.Size(96, 17);
            this.radioButtonClearCacheModeFileSystemOnly.TabIndex = 127;
            this.radioButtonClearCacheModeFileSystemOnly.TabStop = true;
            this.radioButtonClearCacheModeFileSystemOnly.Text = "FileSystemOnly";
            this.radioButtonClearCacheModeFileSystemOnly.UseVisualStyleBackColor = true;
            // 
            // ResultPresenterExecutionInfoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControlExecutionInfo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ResultPresenterExecutionInfoControl";
            this.Size = new System.Drawing.Size(1138, 700);
            this.tabPageSQLServer.ResumeLayout(false);
            this.panelSQLServer.ResumeLayout(false);
            this.tableLayoutPanelSQLServer.ResumeLayout(false);
            this.tableLayoutPanelSQLServer.PerformLayout();
            this.tabPageSSAS.ResumeLayout(false);
            this.splitContainerSSAS.Panel1.ResumeLayout(false);
            this.splitContainerSSAS.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSSAS)).EndInit();
            this.splitContainerSSAS.ResumeLayout(false);
            this.panelSSASTop.ResumeLayout(false);
            this.tableLayoutSSASGeneral.ResumeLayout(false);
            this.tableLayoutSSASGeneral.PerformLayout();
            this.panelMDXScript.ResumeLayout(false);
            this.tableLayoutMDXScript.ResumeLayout(false);
            this.panelMDXScriptTitle.ResumeLayout(false);
            this.panelMDXScriptTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMDXScript)).EndInit();
            this.panelCubeMetadata.ResumeLayout(false);
            this.tableLayoutCubeMetadata.ResumeLayout(false);
            this.panelCubeMetadataTitle.ResumeLayout(false);
            this.panelCubeMetadataTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCubeMetadata)).EndInit();
            this.panelIniFile.ResumeLayout(false);
            this.tableLayoutSSASIniFile.ResumeLayout(false);
            this.panelIniFileTitle.ResumeLayout(false);
            this.panelIniFileTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIniFile)).EndInit();
            this.PanelSSASDetailsTitle.ResumeLayout(false);
            this.PanelSSASDetailsTitle.PerformLayout();
            this.tabPageExecution.ResumeLayout(false);
            this.panelExecution.ResumeLayout(false);
            this.tableLayoutExecution.ResumeLayout(false);
            this.panelExecutionInfo.ResumeLayout(false);
            this.tableLayoutPanelExecutionInfo.ResumeLayout(false);
            this.tableLayoutPanelExecutionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureExecutionMode)).EndInit();
            this.panelActivities.ResumeLayout(false);
            this.tableLayoutPanelActivities.ResumeLayout(false);
            this.tableLayoutPanelActivities.PerformLayout();
            this.panelExecutionTaskPostCold.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePostCold)).EndInit();
            this.panelExecutionTaskPostWarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePostWarm)).EndInit();
            this.panelExecutionTaskWarmCache.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPictureWarm)).EndInit();
            this.panelExecutionTaskColdCache.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPictureCold)).EndInit();
            this.panelExecutionTaskPre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePre)).EndInit();
            this.tabControlExecutionInfo.ResumeLayout(false);
            this.tabPageEnvironment.ResumeLayout(false);
            this.tabControlEnvironmentDetails.ResumeLayout(false);
            this.tabPageClient.ResumeLayout(false);
            this.panelClient.ResumeLayout(false);
            this.tableLayoutPanelClient.ResumeLayout(false);
            this.tableLayoutPanelClient.PerformLayout();
            this.tabPageASQASSASAssembly.ResumeLayout(false);
            this.splitContainerASQAAssembly.Panel1.ResumeLayout(false);
            this.splitContainerASQAAssembly.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerASQAAssembly)).EndInit();
            this.splitContainerASQAAssembly.ResumeLayout(false);
            this.panelASQAAssembly.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelMessageExternal.ResumeLayout(false);
            this.tableLayoutPanelMessageExternal.ResumeLayout(false);
            this.panelMessageInternal.ResumeLayout(false);
            this.tableLayoutPanelMessageInternal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).EndInit();
            this.panelEngineSettings.ResumeLayout(false);
            this.tableLayoutEngineSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCache)).EndInit();
            this.groupBoxClearCacheMode.ResumeLayout(false);
            this.groupBoxClearCacheMode.PerformLayout();
            this.panelOptionalProfilerEvents.ResumeLayout(false);
            this.tableLayoutPanelProfilerEvents.ResumeLayout(false);
            this.groupBoxEventsThreshold.ResumeLayout(false);
            this.groupBoxEventsThreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEventsThreshold)).EndInit();
            this.panelProfilerEventsTitle.ResumeLayout(false);
            this.panelProfilerEventsTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilerEvents)).EndInit();
            this.panelOptionalPerformanceCounters.ResumeLayout(false);
            this.tableLayoutPanelPerformanceCounters.ResumeLayout(false);
            this.panelPerformanceCountersTitle.ResumeLayout(false);
            this.panelPerformanceCountersTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerformanceCounters)).EndInit();
            this.panelSSASASQADetailsTitle.ResumeLayout(false);
            this.panelSSASASQADetailsTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageSQLServer;
        private System.Windows.Forms.TabPage tabPageSSAS;
        private System.Windows.Forms.TabPage tabPageExecution;
        private System.Windows.Forms.TabControl tabControlExecutionInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelActivities;
        private System.Windows.Forms.Label labelResult_PostWarm_DataRendering;
        private System.Windows.Forms.Label labelName_PostWarm_DataRendering;
        private CustomLabelControl labelDurationTitle;
        private System.Windows.Forms.Label labelResult_Pre_EnvironmentSetup;
        private System.Windows.Forms.Label labelName_Pre_EnvironmentSetup;
        private CustomLabelControl labelActivityTitle;
        private System.Windows.Forms.Label labelResult_PostCold_DataRetrieval;
        private System.Windows.Forms.Label labelName_PostCold_DataRetrieval;
        private System.Windows.Forms.Panel panelExecutionTaskPostCold;
        private System.Windows.Forms.Label labelTitlePostCold;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPicturePostCold;
        private System.Windows.Forms.Label labelResult_PostWarm_DataRetrieval;
        private System.Windows.Forms.Label labelName_PostWarm_DataRetrieval;
        private System.Windows.Forms.Label labelResult_Warm_MetricsCalculation;
        private System.Windows.Forms.Label labelResult_Warm_QueryExecution;
        private System.Windows.Forms.Label labelResult_Warm_TracesStartup;
        private System.Windows.Forms.Label labelName_Warm_QueryExecution;
        private System.Windows.Forms.Label labelName_Warm_MetricsCalculation;
        private System.Windows.Forms.Label labelName_Warm_TracesStartup;
        private System.Windows.Forms.Label labelResult_Cold_QueryExecution;
        private System.Windows.Forms.Label labelName_Cold_QueryExecution;
        private System.Windows.Forms.Label labelResult_Cold_MetricsCalculation;
        private System.Windows.Forms.Label labelName_Cold_MetricsCalculation;
        private System.Windows.Forms.Label labelResult_Cold_TracesStartup;
        private System.Windows.Forms.Label labelName_Cold_TracesStartup;
        private System.Windows.Forms.Label labelResult_Pre_CubeScriptLoading;
        private System.Windows.Forms.Label labelResult_Pre_CacheClearing;
        private System.Windows.Forms.Label labelResult_Pre_QuerySyntaxValidation;
        private System.Windows.Forms.Label labelName_Pre_CubeScriptLoading;
        private System.Windows.Forms.Label labelName_Pre_CacheClearing;
        private System.Windows.Forms.Panel panelExecutionTaskPostWarm;
        private System.Windows.Forms.Label labelTitlePostWarm;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPicturePostWarm;
        private System.Windows.Forms.Panel panelExecutionTaskWarmCache;
        private System.Windows.Forms.Label labelTitleWarmCache;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPictureWarm;
        private System.Windows.Forms.Panel panelExecutionTaskColdCache;
        private System.Windows.Forms.Label labelTitleColdCache;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPictureCold;
        private System.Windows.Forms.Panel panelExecutionTaskPre;
        private System.Windows.Forms.Label labelTitlePre;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPicturePre;
        private System.Windows.Forms.Label labelName_Pre_QuerySyntaxValidation;
        private System.Windows.Forms.SplitContainer splitContainerSSAS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSSASGeneral;
        public CustomLabelControl labelRAMValue;
        private CustomLabelControl labelRAMTitle;
        public CustomLabelControl labelNumberOfCoresValue;
        private CustomLabelControl labelNumberOfCoresTitle;
        private CustomLabelControl labelSSASEditionTitle;
        public CustomLabelControl labelSSASEditionValue;
        public CustomLabelControl labelSSASVersionValue;
        private CustomLabelControl labelSSASVersionTitle;
        public CustomLabelControl labelASQAAssemblyVersionValue;
        public CustomLabelControl labelSSASCubeValue;
        private CustomLabelControl labelSSASCubeTitle;
        public CustomLabelControl labelSSASDatabaseValue;
        private CustomLabelControl labelSSASDatabaseTitle;
        public CustomLabelControl labelSSASInstanceNameValue;
        private CustomLabelControl labelSSASInstanceNameTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSSASIniFile;
        private System.Windows.Forms.Panel PanelSSASDetailsTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSQLServer;
        public CustomLabelControl labelSQLEditionValue;
        private CustomLabelControl labelSQLEditionTitle;
        public CustomLabelControl labelSQLVersionValue;
        private CustomLabelControl labelSQLVersionTitle;
        private CustomLabelControl labelSQLInstanceNameTitle;
        public CustomLabelControl labelSQLInstanceNameValue;
        private System.Windows.Forms.TreeView treeViewIniFile;
        private System.Windows.Forms.Panel panelSQLServer;
        private System.Windows.Forms.Panel panelSSASTop;
        private System.Windows.Forms.Panel panelExecution;
        private System.Windows.Forms.Panel panelIniFile;
        private System.Windows.Forms.RadioButton radioButtonShowIniFile;
        private System.Windows.Forms.RadioButton radioButtonShowCubeMetadata;
        private System.Windows.Forms.Panel panelCubeMetadata;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCubeMetadata;
        private System.Windows.Forms.TreeView treeViewCubeMetadata;
        private System.Windows.Forms.TabPage tabPageEnvironment;
        private System.Windows.Forms.TabControl tabControlEnvironmentDetails;
        private System.Windows.Forms.TabPage tabPageClient;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelClient;
        private CustomLabelControl labelClientTypeTitle;
        private CustomLabelControl labelUserNameTitle;
        public CustomLabelControl labelUserNameValue;
        private CustomLabelControl labelClientVersionTitle;
        public CustomLabelControl labelClientVersionValue;
        public CustomLabelControl labelClientTypeValue;
        private System.Windows.Forms.Panel panelExecutionInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExecutionInfo;
        private CustomLabelControl labelExecutionIDTitle;
        public CustomLabelControl labelExecutionTypeValue;
        private CustomLabelControl labelExecutionTypeTitle;
        public CustomLabelControl labelExecutionEndValue;
        private CustomLabelControl labelExecutionEndTitle;
        private CustomLabelControl labelExecutionBeginTitle;
        public CustomLabelControl labelExecutionBeginValue;
        public CustomLabelControl labelExecutionIDValue;
        private CustomLabelControl labelExecutionNameTitle;
        public CustomLabelControl labelExecutionNameValue;
        public CustomLabelControl labelAnalysisDurationValue;
        private CustomLabelControl labelExecutionDurationTitle;
        private System.Windows.Forms.PictureBox pictureExecutionMode;
        private System.Windows.Forms.Panel panelExecutionBandPostCold;
        private System.Windows.Forms.Panel panelExecutionBandPostWarm;
        private System.Windows.Forms.Panel panelExecutionBandWarmCache;
        private System.Windows.Forms.Panel panelExecutionBandColdCache;
        private System.Windows.Forms.Panel panelExecutionBandPre;
        private System.Windows.Forms.TableLayoutPanel tableLayoutExecution;
        private System.Windows.Forms.Panel panelActivities;
        public CustomLabelControl labelOperatingSystemValue;
        private CustomLabelControl labelOperatingSystemTitle;
        private System.Windows.Forms.RadioButton radioButtonShowMDXScript;
        private System.Windows.Forms.Panel panelMDXScript;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMDXScript;
        private System.Windows.Forms.RichTextBox richTextBoxMDXScript;
        private System.Windows.Forms.TabPage tabPageASQASSASAssembly;
        private System.Windows.Forms.SplitContainer splitContainerASQAAssembly;
        private System.Windows.Forms.Panel panelASQAAssembly;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomLabelControl labelASQAAssemblyVersion_ASQATab_Title;
        private CustomLabelControl labelASQAAssemblyVersion_ASQATab_Value;
        private System.Windows.Forms.Panel panelEngineSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutEngineSettings;
        private System.Windows.Forms.Panel panelOptionalProfilerEvents;
        private System.Windows.Forms.Panel panelOptionalPerformanceCounters;
        private System.Windows.Forms.Panel panelSSASASQADetailsTitle;
        private System.Windows.Forms.RadioButton radioButtonPerformanceCounters;
        private System.Windows.Forms.RadioButton radioButtonProfilerEvents;
        private System.Windows.Forms.RadioButton radioButtonEngine;
        private CustomLabelControl labelASQAAssemblyVersionTitle;
        private System.Windows.Forms.GroupBox groupBoxClearCacheMode;
        private System.Windows.Forms.RadioButton radioButtonClearCacheModeAllDatabases;
        private System.Windows.Forms.RadioButton radioButtonClearCacheModeCurrentDatabase;
        private System.Windows.Forms.RadioButton radioButtonClearCacheModeCurrentCube;
        private System.Windows.Forms.PictureBox pictureBoxCache;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProfilerEvents;
        private System.Windows.Forms.Panel panelProfilerEventsBottom;
        private System.Windows.Forms.GroupBox groupBoxEventsThreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownEventsThreshold;
        private System.Windows.Forms.RadioButton radioButtonEventsThresholdLimited;
        private System.Windows.Forms.RadioButton radioButtonEventsThresholdUnlimited;
        public System.Windows.Forms.TreeView treeViewProfilerEvents;
        private System.Windows.Forms.Panel panelProfilerEventsTitle;
        private CustomLabelControl customLabelProfilerEventsTitle;
        private System.Windows.Forms.PictureBox pictureBoxProfilerEvents;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPerformanceCounters;
        private System.Windows.Forms.Panel panelPerformanceCountersTitle;
        private CustomLabelControl customLabelPerformanceCountersTitle;
        private System.Windows.Forms.PictureBox pictureBoxPerformanceCounters;
        private System.Windows.Forms.Panel panelPerformanceCountersBottom;
        private System.Windows.Forms.Panel panelMDXScriptTitle;
        private CustomLabelControl customLabelMDXScript;
        private System.Windows.Forms.PictureBox pictureBoxMDXScript;
        private System.Windows.Forms.Panel panelMDXScriptBottom;
        private System.Windows.Forms.Panel panelCubeMetadataTitle;
        private CustomLabelControl customLabelCubeMetadata;
        private System.Windows.Forms.PictureBox pictureBoxCubeMetadata;
        private System.Windows.Forms.Panel panelCubeMetadataBottom;
        private System.Windows.Forms.Panel panelIniFileTitle;
        private CustomLabelControl customLabelIniFile;
        private System.Windows.Forms.PictureBox pictureBoxIniFile;
        private System.Windows.Forms.Panel panelIniFileBottom;
        private CustomLabelControl customLabelControlCache;
        public System.Windows.Forms.TreeView treeViewPerformanceCounters;
        private System.Windows.Forms.Panel panelMessageExternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageExternal;
        private System.Windows.Forms.Panel panelMessageInternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageInternal;
        private CustomLabelControl customLabelMessage;
        private System.Windows.Forms.Panel panelMessageBand;
        private System.Windows.Forms.PictureBox pictureBoxMessage;
        private System.Windows.Forms.RadioButton radioButtonClearCacheModeCurrentDatabaseAndFileSystem;
        private System.Windows.Forms.RadioButton radioButtonClearCacheModeCurrentCubeAndFileSystem;
        private System.Windows.Forms.RadioButton radioButtonClearCacheModeAllDatabasesAndFileSystem;
        private System.Windows.Forms.RadioButton radioButtonClearCacheModeFileSystemOnly;
    }
}
