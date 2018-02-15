namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;

    partial class ResultPresenterExecutionProgressControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultPresenterExecutionProgressControl));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelResult_PostWarm_RenderingData = new System.Windows.Forms.Label();
            this.labelName_PostWarm_RenderingData = new System.Windows.Forms.Label();
            this.labelResult_PostCold_RetrieveData = new System.Windows.Forms.Label();
            this.labelName_PostCold_RetrieveData = new System.Windows.Forms.Label();
            this.panelExecutionBandPostCold = new System.Windows.Forms.Panel();
            this.panelExecutionTaskPostCold = new System.Windows.Forms.Panel();
            this.labelTitlePostCold = new System.Windows.Forms.Label();
            this.pictureBoxExecutionPicturePostCold = new System.Windows.Forms.PictureBox();
            this.pictureBoxArrowDownCenter2 = new System.Windows.Forms.PictureBox();
            this.labelResult_PostWarm_RetrieveData = new System.Windows.Forms.Label();
            this.labelName_PostWarm_RetrieveData = new System.Windows.Forms.Label();
            this.labelResult_Warm_CalculateMetrics = new System.Windows.Forms.Label();
            this.labelResult_Warm_ExecuteMDX = new System.Windows.Forms.Label();
            this.labelResult_Warm_CollectData = new System.Windows.Forms.Label();
            this.labelResult_Warm_RunTraces = new System.Windows.Forms.Label();
            this.labelName_Warm_CollectData = new System.Windows.Forms.Label();
            this.labelName_Warm_ExecuteMDX = new System.Windows.Forms.Label();
            this.labelName_Warm_CalculateMetrics = new System.Windows.Forms.Label();
            this.labelName_Warm_RunTraces = new System.Windows.Forms.Label();
            this.labelResult_Cold_CollectData = new System.Windows.Forms.Label();
            this.labelName_Cold_CollectData = new System.Windows.Forms.Label();
            this.labelResult_Cold_ExecuteMDX = new System.Windows.Forms.Label();
            this.labelName_Cold_ExecuteMDX = new System.Windows.Forms.Label();
            this.labelResult_Cold_CalculateMetrics = new System.Windows.Forms.Label();
            this.labelName_Cold_CalculateMetrics = new System.Windows.Forms.Label();
            this.labelResult_Cold_RunTraces = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelName_Cold_RunTraces = new System.Windows.Forms.Label();
            this.labelResult_Pre_LoadCubeMDXScript = new System.Windows.Forms.Label();
            this.labelResult_Pre_ClearCache = new System.Windows.Forms.Label();
            this.labelResult_Pre_VerifyMDX = new System.Windows.Forms.Label();
            this.labelName_Pre_LoadCubeMDXScript = new System.Windows.Forms.Label();
            this.labelName_Pre_ClearCache = new System.Windows.Forms.Label();
            this.panelExecutionBandPostWarm = new System.Windows.Forms.Panel();
            this.panelExecutionTaskPostWarm = new System.Windows.Forms.Panel();
            this.labelTitlePostWarm = new System.Windows.Forms.Label();
            this.pictureBoxExecutionPicturePostWarm = new System.Windows.Forms.PictureBox();
            this.panelExecutionBandWarmCache = new System.Windows.Forms.Panel();
            this.pictureBoxArrowDownBottom = new System.Windows.Forms.PictureBox();
            this.panelExecutionTaskWarmCache = new System.Windows.Forms.Panel();
            this.labelTitleWarmCache = new System.Windows.Forms.Label();
            this.pictureBoxExecutionPictureWarm = new System.Windows.Forms.PictureBox();
            this.panelExecutionBandColdCache = new System.Windows.Forms.Panel();
            this.panelExecutionTaskColdCache = new System.Windows.Forms.Panel();
            this.labelTitleColdCache = new System.Windows.Forms.Label();
            this.pictureBoxExecutionPictureCold = new System.Windows.Forms.PictureBox();
            this.pictureBoxArrowDownCenter1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxArrowDownTop = new System.Windows.Forms.PictureBox();
            this.panelBorderBottomRightInt = new System.Windows.Forms.Panel();
            this.panelBorderBottomRightExt = new System.Windows.Forms.Panel();
            this.panelBorderBottomLeftExt = new System.Windows.Forms.Panel();
            this.panelBorderBottomLeftInt = new System.Windows.Forms.Panel();
            this.panelBorderTopRightInt = new System.Windows.Forms.Panel();
            this.panelBorderTopLeftInt = new System.Windows.Forms.Panel();
            this.panelBorderRightInt = new System.Windows.Forms.Panel();
            this.panelBorderLeftInt = new System.Windows.Forms.Panel();
            this.panelBorderTopRightExt = new System.Windows.Forms.Panel();
            this.panelBorderLeftExt = new System.Windows.Forms.Panel();
            this.panelBorderTopLeftExt = new System.Windows.Forms.Panel();
            this.pictureBoxProgress = new System.Windows.Forms.PictureBox();
            this.panelBorderRightExt = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelExecutionBandPre = new System.Windows.Forms.Panel();
            this.panelExecutionTaskPre = new System.Windows.Forms.Panel();
            this.labelTitlePre = new System.Windows.Forms.Label();
            this.pictureBoxExecutionPicturePre = new System.Windows.Forms.PictureBox();
            this.labelName_Pre_VerifyMDX = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelExecutionTaskPostCold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePostCold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDownCenter2)).BeginInit();
            this.panelExecutionTaskPostWarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePostWarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDownBottom)).BeginInit();
            this.panelExecutionTaskWarmCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPictureWarm)).BeginInit();
            this.panelExecutionTaskColdCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPictureCold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDownCenter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDownTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).BeginInit();
            this.panelExecutionTaskPre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePre)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelMain.ColumnCount = 23;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_PostWarm_RenderingData, 15, 26);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_PostWarm_RenderingData, 8, 26);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_PostCold_RetrieveData, 15, 17);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_PostCold_RetrieveData, 8, 17);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionBandPostCold, 5, 17);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionTaskPostCold, 6, 17);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxArrowDownCenter2, 6, 18);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_PostWarm_RetrieveData, 15, 25);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_PostWarm_RetrieveData, 8, 25);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Warm_CalculateMetrics, 15, 22);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Warm_ExecuteMDX, 15, 20);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Warm_CollectData, 15, 21);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Warm_RunTraces, 15, 19);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Warm_CollectData, 8, 21);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Warm_ExecuteMDX, 8, 20);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Warm_CalculateMetrics, 8, 22);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Warm_RunTraces, 8, 19);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Cold_CollectData, 15, 14);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Cold_CollectData, 8, 14);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Cold_ExecuteMDX, 15, 13);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Cold_ExecuteMDX, 8, 13);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Cold_CalculateMetrics, 15, 15);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Cold_CalculateMetrics, 8, 15);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Cold_RunTraces, 15, 12);
            this.tableLayoutPanelMain.Controls.Add(this.labelTitle, 6, 6);
            this.tableLayoutPanelMain.Controls.Add(this.labelTimer, 9, 28);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Cold_RunTraces, 8, 12);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Pre_LoadCubeMDXScript, 15, 10);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Pre_ClearCache, 15, 9);
            this.tableLayoutPanelMain.Controls.Add(this.labelResult_Pre_VerifyMDX, 15, 8);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Pre_LoadCubeMDXScript, 8, 10);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Pre_ClearCache, 8, 9);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionBandPostWarm, 5, 24);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionTaskPostWarm, 6, 24);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionBandWarmCache, 5, 19);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxArrowDownBottom, 6, 23);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionTaskWarmCache, 6, 19);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionBandColdCache, 5, 12);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionTaskColdCache, 6, 12);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxArrowDownCenter1, 6, 16);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxArrowDownTop, 6, 11);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderBottomRightInt, 13, 31);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderBottomRightExt, 13, 33);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderBottomLeftExt, 2, 33);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderBottomLeftInt, 4, 31);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderTopRightInt, 12, 4);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderTopLeftInt, 4, 4);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderRightInt, 19, 4);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderLeftInt, 3, 4);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderTopRightExt, 12, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderLeftExt, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderTopLeftExt, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxProgress, 11, 1);
            this.tableLayoutPanelMain.Controls.Add(this.panelBorderRightExt, 21, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonCancel, 11, 30);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionBandPre, 5, 8);
            this.tableLayoutPanelMain.Controls.Add(this.panelExecutionTaskPre, 6, 8);
            this.tableLayoutPanelMain.Controls.Add(this.labelName_Pre_VerifyMDX, 8, 8);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 36;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(772, 600);
            this.tableLayoutPanelMain.TabIndex = 67;
            // 
            // labelResult_PostWarm_RenderingData
            // 
            this.labelResult_PostWarm_RenderingData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_PostWarm_RenderingData, 3);
            this.labelResult_PostWarm_RenderingData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_PostWarm_RenderingData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_PostWarm_RenderingData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_PostWarm_RenderingData.Location = new System.Drawing.Point(504, 499);
            this.labelResult_PostWarm_RenderingData.Name = "labelResult_PostWarm_RenderingData";
            this.labelResult_PostWarm_RenderingData.Size = new System.Drawing.Size(130, 16);
            this.labelResult_PostWarm_RenderingData.TabIndex = 67;
            this.labelResult_PostWarm_RenderingData.Text = "waiting for execution";
            this.labelResult_PostWarm_RenderingData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_PostWarm_RenderingData.Visible = false;
            // 
            // labelName_PostWarm_RenderingData
            // 
            this.labelName_PostWarm_RenderingData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_PostWarm_RenderingData, 7);
            this.labelName_PostWarm_RenderingData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_PostWarm_RenderingData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_PostWarm_RenderingData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_PostWarm_RenderingData.Location = new System.Drawing.Point(274, 499);
            this.labelName_PostWarm_RenderingData.Name = "labelName_PostWarm_RenderingData";
            this.labelName_PostWarm_RenderingData.Size = new System.Drawing.Size(224, 16);
            this.labelName_PostWarm_RenderingData.TabIndex = 66;
            this.labelName_PostWarm_RenderingData.Text = "Rendering data";
            this.labelName_PostWarm_RenderingData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_PostWarm_RenderingData.Visible = false;
            // 
            // labelResult_PostCold_RetrieveData
            // 
            this.labelResult_PostCold_RetrieveData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_PostCold_RetrieveData, 3);
            this.labelResult_PostCold_RetrieveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_PostCold_RetrieveData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_PostCold_RetrieveData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_PostCold_RetrieveData.Location = new System.Drawing.Point(504, 288);
            this.labelResult_PostCold_RetrieveData.Name = "labelResult_PostCold_RetrieveData";
            this.labelResult_PostCold_RetrieveData.Size = new System.Drawing.Size(130, 63);
            this.labelResult_PostCold_RetrieveData.TabIndex = 65;
            this.labelResult_PostCold_RetrieveData.Text = "waiting for execution";
            this.labelResult_PostCold_RetrieveData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_PostCold_RetrieveData.Visible = false;
            // 
            // labelName_PostCold_RetrieveData
            // 
            this.labelName_PostCold_RetrieveData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_PostCold_RetrieveData, 7);
            this.labelName_PostCold_RetrieveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_PostCold_RetrieveData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_PostCold_RetrieveData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_PostCold_RetrieveData.Location = new System.Drawing.Point(274, 288);
            this.labelName_PostCold_RetrieveData.Name = "labelName_PostCold_RetrieveData";
            this.labelName_PostCold_RetrieveData.Size = new System.Drawing.Size(224, 63);
            this.labelName_PostCold_RetrieveData.TabIndex = 64;
            this.labelName_PostCold_RetrieveData.Text = "Retrieving data";
            this.labelName_PostCold_RetrieveData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_PostCold_RetrieveData.Visible = false;
            // 
            // panelExecutionBandPostCold
            // 
            this.panelExecutionBandPostCold.BackColor = System.Drawing.Color.Gray;
            this.panelExecutionBandPostCold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandPostCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandPostCold.Location = new System.Drawing.Point(135, 288);
            this.panelExecutionBandPostCold.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandPostCold.Name = "panelExecutionBandPostCold";
            this.panelExecutionBandPostCold.Size = new System.Drawing.Size(5, 63);
            this.panelExecutionBandPostCold.TabIndex = 63;
            this.panelExecutionBandPostCold.Visible = false;
            // 
            // panelExecutionTaskPostCold
            // 
            this.panelExecutionTaskPostCold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionTaskPostCold.Controls.Add(this.labelTitlePostCold);
            this.panelExecutionTaskPostCold.Controls.Add(this.pictureBoxExecutionPicturePostCold);
            this.panelExecutionTaskPostCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskPostCold.Location = new System.Drawing.Point(140, 288);
            this.panelExecutionTaskPostCold.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskPostCold.Name = "panelExecutionTaskPostCold";
            this.panelExecutionTaskPostCold.Size = new System.Drawing.Size(120, 63);
            this.panelExecutionTaskPostCold.TabIndex = 62;
            this.panelExecutionTaskPostCold.Visible = false;
            // 
            // labelTitlePostCold
            // 
            this.labelTitlePostCold.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitlePostCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePostCold.Location = new System.Drawing.Point(0, 0);
            this.labelTitlePostCold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitlePostCold.Name = "labelTitlePostCold";
            this.labelTitlePostCold.Size = new System.Drawing.Size(72, 61);
            this.labelTitlePostCold.TabIndex = 39;
            this.labelTitlePostCold.Text = "POST COLD EXECUTION ACTIVITIES";
            this.labelTitlePostCold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxExecutionPicturePostCold
            // 
            this.pictureBoxExecutionPicturePostCold.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPicturePostCold.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPicturePostCold.Image")));
            this.pictureBoxExecutionPicturePostCold.Location = new System.Drawing.Point(70, 0);
            this.pictureBoxExecutionPicturePostCold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPicturePostCold.Name = "pictureBoxExecutionPicturePostCold";
            this.pictureBoxExecutionPicturePostCold.Size = new System.Drawing.Size(48, 61);
            this.pictureBoxExecutionPicturePostCold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPicturePostCold.TabIndex = 5;
            this.pictureBoxExecutionPicturePostCold.TabStop = false;
            // 
            // pictureBoxArrowDownCenter2
            // 
            this.pictureBoxArrowDownCenter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxArrowDownCenter2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxArrowDownCenter2.Image")));
            this.pictureBoxArrowDownCenter2.Location = new System.Drawing.Point(140, 353);
            this.pictureBoxArrowDownCenter2.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBoxArrowDownCenter2.Name = "pictureBoxArrowDownCenter2";
            this.pictureBoxArrowDownCenter2.Size = new System.Drawing.Size(120, 24);
            this.pictureBoxArrowDownCenter2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxArrowDownCenter2.TabIndex = 61;
            this.pictureBoxArrowDownCenter2.TabStop = false;
            this.pictureBoxArrowDownCenter2.Visible = false;
            // 
            // labelResult_PostWarm_RetrieveData
            // 
            this.labelResult_PostWarm_RetrieveData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_PostWarm_RetrieveData, 3);
            this.labelResult_PostWarm_RetrieveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_PostWarm_RetrieveData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_PostWarm_RetrieveData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_PostWarm_RetrieveData.Location = new System.Drawing.Point(504, 483);
            this.labelResult_PostWarm_RetrieveData.Name = "labelResult_PostWarm_RetrieveData";
            this.labelResult_PostWarm_RetrieveData.Size = new System.Drawing.Size(130, 16);
            this.labelResult_PostWarm_RetrieveData.TabIndex = 60;
            this.labelResult_PostWarm_RetrieveData.Text = "waiting for execution";
            this.labelResult_PostWarm_RetrieveData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_PostWarm_RetrieveData.Visible = false;
            // 
            // labelName_PostWarm_RetrieveData
            // 
            this.labelName_PostWarm_RetrieveData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_PostWarm_RetrieveData, 7);
            this.labelName_PostWarm_RetrieveData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_PostWarm_RetrieveData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_PostWarm_RetrieveData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_PostWarm_RetrieveData.Location = new System.Drawing.Point(274, 483);
            this.labelName_PostWarm_RetrieveData.Name = "labelName_PostWarm_RetrieveData";
            this.labelName_PostWarm_RetrieveData.Size = new System.Drawing.Size(224, 16);
            this.labelName_PostWarm_RetrieveData.TabIndex = 59;
            this.labelName_PostWarm_RetrieveData.Text = "Retrieving data";
            this.labelName_PostWarm_RetrieveData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_PostWarm_RetrieveData.Visible = false;
            // 
            // labelResult_Warm_CalculateMetrics
            // 
            this.labelResult_Warm_CalculateMetrics.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Warm_CalculateMetrics, 3);
            this.labelResult_Warm_CalculateMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Warm_CalculateMetrics.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Warm_CalculateMetrics.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Warm_CalculateMetrics.Location = new System.Drawing.Point(504, 425);
            this.labelResult_Warm_CalculateMetrics.Name = "labelResult_Warm_CalculateMetrics";
            this.labelResult_Warm_CalculateMetrics.Size = new System.Drawing.Size(130, 16);
            this.labelResult_Warm_CalculateMetrics.TabIndex = 58;
            this.labelResult_Warm_CalculateMetrics.Text = "waiting for execution";
            this.labelResult_Warm_CalculateMetrics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Warm_CalculateMetrics.Visible = false;
            // 
            // labelResult_Warm_ExecuteMDX
            // 
            this.labelResult_Warm_ExecuteMDX.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Warm_ExecuteMDX, 3);
            this.labelResult_Warm_ExecuteMDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Warm_ExecuteMDX.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Warm_ExecuteMDX.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Warm_ExecuteMDX.Location = new System.Drawing.Point(504, 393);
            this.labelResult_Warm_ExecuteMDX.Name = "labelResult_Warm_ExecuteMDX";
            this.labelResult_Warm_ExecuteMDX.Size = new System.Drawing.Size(130, 16);
            this.labelResult_Warm_ExecuteMDX.TabIndex = 57;
            this.labelResult_Warm_ExecuteMDX.Text = "waiting for execution";
            this.labelResult_Warm_ExecuteMDX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Warm_ExecuteMDX.Visible = false;
            // 
            // labelResult_Warm_CollectData
            // 
            this.labelResult_Warm_CollectData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Warm_CollectData, 3);
            this.labelResult_Warm_CollectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Warm_CollectData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Warm_CollectData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Warm_CollectData.Location = new System.Drawing.Point(504, 409);
            this.labelResult_Warm_CollectData.Name = "labelResult_Warm_CollectData";
            this.labelResult_Warm_CollectData.Size = new System.Drawing.Size(130, 16);
            this.labelResult_Warm_CollectData.TabIndex = 56;
            this.labelResult_Warm_CollectData.Text = "waiting for execution";
            this.labelResult_Warm_CollectData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Warm_CollectData.Visible = false;
            // 
            // labelResult_Warm_RunTraces
            // 
            this.labelResult_Warm_RunTraces.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Warm_RunTraces, 3);
            this.labelResult_Warm_RunTraces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Warm_RunTraces.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Warm_RunTraces.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Warm_RunTraces.Location = new System.Drawing.Point(504, 377);
            this.labelResult_Warm_RunTraces.Name = "labelResult_Warm_RunTraces";
            this.labelResult_Warm_RunTraces.Size = new System.Drawing.Size(130, 16);
            this.labelResult_Warm_RunTraces.TabIndex = 55;
            this.labelResult_Warm_RunTraces.Text = "waiting for execution";
            this.labelResult_Warm_RunTraces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Warm_RunTraces.Visible = false;
            // 
            // labelName_Warm_CollectData
            // 
            this.labelName_Warm_CollectData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Warm_CollectData, 7);
            this.labelName_Warm_CollectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Warm_CollectData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Warm_CollectData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Warm_CollectData.Location = new System.Drawing.Point(274, 409);
            this.labelName_Warm_CollectData.Name = "labelName_Warm_CollectData";
            this.labelName_Warm_CollectData.Size = new System.Drawing.Size(224, 16);
            this.labelName_Warm_CollectData.TabIndex = 54;
            this.labelName_Warm_CollectData.Text = "Collect data";
            this.labelName_Warm_CollectData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Warm_CollectData.Visible = false;
            // 
            // labelName_Warm_ExecuteMDX
            // 
            this.labelName_Warm_ExecuteMDX.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Warm_ExecuteMDX, 7);
            this.labelName_Warm_ExecuteMDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Warm_ExecuteMDX.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Warm_ExecuteMDX.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Warm_ExecuteMDX.Location = new System.Drawing.Point(274, 393);
            this.labelName_Warm_ExecuteMDX.Name = "labelName_Warm_ExecuteMDX";
            this.labelName_Warm_ExecuteMDX.Size = new System.Drawing.Size(224, 16);
            this.labelName_Warm_ExecuteMDX.TabIndex = 53;
            this.labelName_Warm_ExecuteMDX.Text = "Execute MDX";
            this.labelName_Warm_ExecuteMDX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Warm_ExecuteMDX.Visible = false;
            // 
            // labelName_Warm_CalculateMetrics
            // 
            this.labelName_Warm_CalculateMetrics.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Warm_CalculateMetrics, 7);
            this.labelName_Warm_CalculateMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Warm_CalculateMetrics.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Warm_CalculateMetrics.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Warm_CalculateMetrics.Location = new System.Drawing.Point(274, 425);
            this.labelName_Warm_CalculateMetrics.Name = "labelName_Warm_CalculateMetrics";
            this.labelName_Warm_CalculateMetrics.Size = new System.Drawing.Size(224, 16);
            this.labelName_Warm_CalculateMetrics.TabIndex = 52;
            this.labelName_Warm_CalculateMetrics.Text = "Calculate metrics";
            this.labelName_Warm_CalculateMetrics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Warm_CalculateMetrics.Visible = false;
            // 
            // labelName_Warm_RunTraces
            // 
            this.labelName_Warm_RunTraces.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Warm_RunTraces, 7);
            this.labelName_Warm_RunTraces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Warm_RunTraces.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Warm_RunTraces.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Warm_RunTraces.Location = new System.Drawing.Point(274, 377);
            this.labelName_Warm_RunTraces.Name = "labelName_Warm_RunTraces";
            this.labelName_Warm_RunTraces.Size = new System.Drawing.Size(224, 16);
            this.labelName_Warm_RunTraces.TabIndex = 51;
            this.labelName_Warm_RunTraces.Text = "Run traces";
            this.labelName_Warm_RunTraces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Warm_RunTraces.Visible = false;
            // 
            // labelResult_Cold_CollectData
            // 
            this.labelResult_Cold_CollectData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Cold_CollectData, 3);
            this.labelResult_Cold_CollectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Cold_CollectData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Cold_CollectData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Cold_CollectData.Location = new System.Drawing.Point(504, 230);
            this.labelResult_Cold_CollectData.Name = "labelResult_Cold_CollectData";
            this.labelResult_Cold_CollectData.Size = new System.Drawing.Size(130, 16);
            this.labelResult_Cold_CollectData.TabIndex = 50;
            this.labelResult_Cold_CollectData.Text = "waiting for execution";
            this.labelResult_Cold_CollectData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Cold_CollectData.Visible = false;
            // 
            // labelName_Cold_CollectData
            // 
            this.labelName_Cold_CollectData.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Cold_CollectData, 7);
            this.labelName_Cold_CollectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Cold_CollectData.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Cold_CollectData.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Cold_CollectData.Location = new System.Drawing.Point(274, 230);
            this.labelName_Cold_CollectData.Name = "labelName_Cold_CollectData";
            this.labelName_Cold_CollectData.Size = new System.Drawing.Size(224, 16);
            this.labelName_Cold_CollectData.TabIndex = 49;
            this.labelName_Cold_CollectData.Text = "Collect data";
            this.labelName_Cold_CollectData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Cold_CollectData.Visible = false;
            // 
            // labelResult_Cold_ExecuteMDX
            // 
            this.labelResult_Cold_ExecuteMDX.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Cold_ExecuteMDX, 3);
            this.labelResult_Cold_ExecuteMDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Cold_ExecuteMDX.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Cold_ExecuteMDX.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Cold_ExecuteMDX.Location = new System.Drawing.Point(504, 214);
            this.labelResult_Cold_ExecuteMDX.Name = "labelResult_Cold_ExecuteMDX";
            this.labelResult_Cold_ExecuteMDX.Size = new System.Drawing.Size(130, 16);
            this.labelResult_Cold_ExecuteMDX.TabIndex = 48;
            this.labelResult_Cold_ExecuteMDX.Text = "waiting for execution";
            this.labelResult_Cold_ExecuteMDX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Cold_ExecuteMDX.Visible = false;
            // 
            // labelName_Cold_ExecuteMDX
            // 
            this.labelName_Cold_ExecuteMDX.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Cold_ExecuteMDX, 7);
            this.labelName_Cold_ExecuteMDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Cold_ExecuteMDX.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Cold_ExecuteMDX.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Cold_ExecuteMDX.Location = new System.Drawing.Point(274, 214);
            this.labelName_Cold_ExecuteMDX.Name = "labelName_Cold_ExecuteMDX";
            this.labelName_Cold_ExecuteMDX.Size = new System.Drawing.Size(224, 16);
            this.labelName_Cold_ExecuteMDX.TabIndex = 47;
            this.labelName_Cold_ExecuteMDX.Text = "Execute MDX";
            this.labelName_Cold_ExecuteMDX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Cold_ExecuteMDX.Visible = false;
            // 
            // labelResult_Cold_CalculateMetrics
            // 
            this.labelResult_Cold_CalculateMetrics.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Cold_CalculateMetrics, 3);
            this.labelResult_Cold_CalculateMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Cold_CalculateMetrics.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Cold_CalculateMetrics.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Cold_CalculateMetrics.Location = new System.Drawing.Point(504, 246);
            this.labelResult_Cold_CalculateMetrics.Name = "labelResult_Cold_CalculateMetrics";
            this.labelResult_Cold_CalculateMetrics.Size = new System.Drawing.Size(130, 16);
            this.labelResult_Cold_CalculateMetrics.TabIndex = 46;
            this.labelResult_Cold_CalculateMetrics.Text = "waiting for execution";
            this.labelResult_Cold_CalculateMetrics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Cold_CalculateMetrics.Visible = false;
            // 
            // labelName_Cold_CalculateMetrics
            // 
            this.labelName_Cold_CalculateMetrics.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Cold_CalculateMetrics, 7);
            this.labelName_Cold_CalculateMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Cold_CalculateMetrics.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Cold_CalculateMetrics.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Cold_CalculateMetrics.Location = new System.Drawing.Point(274, 246);
            this.labelName_Cold_CalculateMetrics.Name = "labelName_Cold_CalculateMetrics";
            this.labelName_Cold_CalculateMetrics.Size = new System.Drawing.Size(224, 16);
            this.labelName_Cold_CalculateMetrics.TabIndex = 45;
            this.labelName_Cold_CalculateMetrics.Text = "Calculate metrics";
            this.labelName_Cold_CalculateMetrics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Cold_CalculateMetrics.Visible = false;
            // 
            // labelResult_Cold_RunTraces
            // 
            this.labelResult_Cold_RunTraces.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Cold_RunTraces, 3);
            this.labelResult_Cold_RunTraces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Cold_RunTraces.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Cold_RunTraces.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Cold_RunTraces.Location = new System.Drawing.Point(504, 198);
            this.labelResult_Cold_RunTraces.Name = "labelResult_Cold_RunTraces";
            this.labelResult_Cold_RunTraces.Size = new System.Drawing.Size(130, 16);
            this.labelResult_Cold_RunTraces.TabIndex = 44;
            this.labelResult_Cold_RunTraces.Text = "waiting for execution";
            this.labelResult_Cold_RunTraces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Cold_RunTraces.Visible = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelTitle, 11);
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.labelTitle.Location = new System.Drawing.Point(143, 68);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(486, 26);
            this.labelTitle.TabIndex = 43;
            this.labelTitle.Text = "ANALYSIS IN PROGRESS! PLEASE WAIT … ";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelTimer, 5);
            this.labelTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimer.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.ForeColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.labelTimer.Location = new System.Drawing.Point(294, 531);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(184, 26);
            this.labelTimer.TabIndex = 42;
            this.labelTimer.Text = "00:00:0.000";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName_Cold_RunTraces
            // 
            this.labelName_Cold_RunTraces.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Cold_RunTraces, 7);
            this.labelName_Cold_RunTraces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Cold_RunTraces.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Cold_RunTraces.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Cold_RunTraces.Location = new System.Drawing.Point(274, 198);
            this.labelName_Cold_RunTraces.Name = "labelName_Cold_RunTraces";
            this.labelName_Cold_RunTraces.Size = new System.Drawing.Size(224, 16);
            this.labelName_Cold_RunTraces.TabIndex = 41;
            this.labelName_Cold_RunTraces.Text = "Run traces";
            this.labelName_Cold_RunTraces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Cold_RunTraces.Visible = false;
            // 
            // labelResult_Pre_LoadCubeMDXScript
            // 
            this.labelResult_Pre_LoadCubeMDXScript.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Pre_LoadCubeMDXScript, 3);
            this.labelResult_Pre_LoadCubeMDXScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Pre_LoadCubeMDXScript.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Pre_LoadCubeMDXScript.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Pre_LoadCubeMDXScript.Location = new System.Drawing.Point(504, 151);
            this.labelResult_Pre_LoadCubeMDXScript.Name = "labelResult_Pre_LoadCubeMDXScript";
            this.labelResult_Pre_LoadCubeMDXScript.Size = new System.Drawing.Size(130, 21);
            this.labelResult_Pre_LoadCubeMDXScript.TabIndex = 40;
            this.labelResult_Pre_LoadCubeMDXScript.Text = "waiting for execution";
            this.labelResult_Pre_LoadCubeMDXScript.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Pre_LoadCubeMDXScript.Visible = false;
            // 
            // labelResult_Pre_ClearCache
            // 
            this.labelResult_Pre_ClearCache.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Pre_ClearCache, 3);
            this.labelResult_Pre_ClearCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Pre_ClearCache.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Pre_ClearCache.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Pre_ClearCache.Location = new System.Drawing.Point(504, 130);
            this.labelResult_Pre_ClearCache.Name = "labelResult_Pre_ClearCache";
            this.labelResult_Pre_ClearCache.Size = new System.Drawing.Size(130, 21);
            this.labelResult_Pre_ClearCache.TabIndex = 39;
            this.labelResult_Pre_ClearCache.Text = "waiting for execution";
            this.labelResult_Pre_ClearCache.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Pre_ClearCache.Visible = false;
            // 
            // labelResult_Pre_VerifyMDX
            // 
            this.labelResult_Pre_VerifyMDX.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelResult_Pre_VerifyMDX, 3);
            this.labelResult_Pre_VerifyMDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelResult_Pre_VerifyMDX.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult_Pre_VerifyMDX.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelResult_Pre_VerifyMDX.Location = new System.Drawing.Point(504, 109);
            this.labelResult_Pre_VerifyMDX.Name = "labelResult_Pre_VerifyMDX";
            this.labelResult_Pre_VerifyMDX.Size = new System.Drawing.Size(130, 21);
            this.labelResult_Pre_VerifyMDX.TabIndex = 38;
            this.labelResult_Pre_VerifyMDX.Text = "waiting for execution";
            this.labelResult_Pre_VerifyMDX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult_Pre_VerifyMDX.Visible = false;
            // 
            // labelName_Pre_LoadCubeMDXScript
            // 
            this.labelName_Pre_LoadCubeMDXScript.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Pre_LoadCubeMDXScript, 7);
            this.labelName_Pre_LoadCubeMDXScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Pre_LoadCubeMDXScript.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Pre_LoadCubeMDXScript.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Pre_LoadCubeMDXScript.Location = new System.Drawing.Point(274, 151);
            this.labelName_Pre_LoadCubeMDXScript.Name = "labelName_Pre_LoadCubeMDXScript";
            this.labelName_Pre_LoadCubeMDXScript.Size = new System.Drawing.Size(224, 21);
            this.labelName_Pre_LoadCubeMDXScript.TabIndex = 37;
            this.labelName_Pre_LoadCubeMDXScript.Text = "Load cube MDX scripts";
            this.labelName_Pre_LoadCubeMDXScript.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Pre_LoadCubeMDXScript.Visible = false;
            // 
            // labelName_Pre_ClearCache
            // 
            this.labelName_Pre_ClearCache.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Pre_ClearCache, 7);
            this.labelName_Pre_ClearCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Pre_ClearCache.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Pre_ClearCache.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Pre_ClearCache.Location = new System.Drawing.Point(274, 130);
            this.labelName_Pre_ClearCache.Name = "labelName_Pre_ClearCache";
            this.labelName_Pre_ClearCache.Size = new System.Drawing.Size(224, 21);
            this.labelName_Pre_ClearCache.TabIndex = 36;
            this.labelName_Pre_ClearCache.Text = "Clear caches";
            this.labelName_Pre_ClearCache.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Pre_ClearCache.Visible = false;
            // 
            // panelExecutionBandPostWarm
            // 
            this.panelExecutionBandPostWarm.BackColor = System.Drawing.Color.Gray;
            this.panelExecutionBandPostWarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandPostWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandPostWarm.Location = new System.Drawing.Point(135, 467);
            this.panelExecutionBandPostWarm.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandPostWarm.Name = "panelExecutionBandPostWarm";
            this.tableLayoutPanelMain.SetRowSpan(this.panelExecutionBandPostWarm, 4);
            this.panelExecutionBandPostWarm.Size = new System.Drawing.Size(5, 64);
            this.panelExecutionBandPostWarm.TabIndex = 34;
            this.panelExecutionBandPostWarm.Visible = false;
            // 
            // panelExecutionTaskPostWarm
            // 
            this.panelExecutionTaskPostWarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionTaskPostWarm.Controls.Add(this.labelTitlePostWarm);
            this.panelExecutionTaskPostWarm.Controls.Add(this.pictureBoxExecutionPicturePostWarm);
            this.panelExecutionTaskPostWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskPostWarm.Location = new System.Drawing.Point(140, 467);
            this.panelExecutionTaskPostWarm.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskPostWarm.Name = "panelExecutionTaskPostWarm";
            this.tableLayoutPanelMain.SetRowSpan(this.panelExecutionTaskPostWarm, 4);
            this.panelExecutionTaskPostWarm.Size = new System.Drawing.Size(120, 64);
            this.panelExecutionTaskPostWarm.TabIndex = 33;
            this.panelExecutionTaskPostWarm.Visible = false;
            // 
            // labelTitlePostWarm
            // 
            this.labelTitlePostWarm.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitlePostWarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePostWarm.Location = new System.Drawing.Point(0, 0);
            this.labelTitlePostWarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitlePostWarm.Name = "labelTitlePostWarm";
            this.labelTitlePostWarm.Size = new System.Drawing.Size(72, 62);
            this.labelTitlePostWarm.TabIndex = 39;
            this.labelTitlePostWarm.Text = "POST WARM EXECUTION ACTIVITIES";
            this.labelTitlePostWarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxExecutionPicturePostWarm
            // 
            this.pictureBoxExecutionPicturePostWarm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPicturePostWarm.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPicturePostWarm.Image")));
            this.pictureBoxExecutionPicturePostWarm.Location = new System.Drawing.Point(70, 0);
            this.pictureBoxExecutionPicturePostWarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPicturePostWarm.Name = "pictureBoxExecutionPicturePostWarm";
            this.pictureBoxExecutionPicturePostWarm.Size = new System.Drawing.Size(48, 62);
            this.pictureBoxExecutionPicturePostWarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPicturePostWarm.TabIndex = 5;
            this.pictureBoxExecutionPicturePostWarm.TabStop = false;
            // 
            // panelExecutionBandWarmCache
            // 
            this.panelExecutionBandWarmCache.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.panelExecutionBandWarmCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandWarmCache.Location = new System.Drawing.Point(135, 377);
            this.panelExecutionBandWarmCache.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandWarmCache.Name = "panelExecutionBandWarmCache";
            this.tableLayoutPanelMain.SetRowSpan(this.panelExecutionBandWarmCache, 4);
            this.panelExecutionBandWarmCache.Size = new System.Drawing.Size(5, 64);
            this.panelExecutionBandWarmCache.TabIndex = 32;
            this.panelExecutionBandWarmCache.Visible = false;
            // 
            // pictureBoxArrowDownBottom
            // 
            this.pictureBoxArrowDownBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxArrowDownBottom.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxArrowDownBottom.Image")));
            this.pictureBoxArrowDownBottom.Location = new System.Drawing.Point(140, 443);
            this.pictureBoxArrowDownBottom.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBoxArrowDownBottom.Name = "pictureBoxArrowDownBottom";
            this.pictureBoxArrowDownBottom.Size = new System.Drawing.Size(120, 24);
            this.pictureBoxArrowDownBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxArrowDownBottom.TabIndex = 31;
            this.pictureBoxArrowDownBottom.TabStop = false;
            this.pictureBoxArrowDownBottom.Visible = false;
            // 
            // panelExecutionTaskWarmCache
            // 
            this.panelExecutionTaskWarmCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionTaskWarmCache.Controls.Add(this.labelTitleWarmCache);
            this.panelExecutionTaskWarmCache.Controls.Add(this.pictureBoxExecutionPictureWarm);
            this.panelExecutionTaskWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskWarmCache.Location = new System.Drawing.Point(140, 377);
            this.panelExecutionTaskWarmCache.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskWarmCache.Name = "panelExecutionTaskWarmCache";
            this.tableLayoutPanelMain.SetRowSpan(this.panelExecutionTaskWarmCache, 4);
            this.panelExecutionTaskWarmCache.Size = new System.Drawing.Size(120, 64);
            this.panelExecutionTaskWarmCache.TabIndex = 30;
            this.panelExecutionTaskWarmCache.Visible = false;
            // 
            // labelTitleWarmCache
            // 
            this.labelTitleWarmCache.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitleWarmCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleWarmCache.Location = new System.Drawing.Point(0, 0);
            this.labelTitleWarmCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitleWarmCache.Name = "labelTitleWarmCache";
            this.labelTitleWarmCache.Size = new System.Drawing.Size(72, 62);
            this.labelTitleWarmCache.TabIndex = 40;
            this.labelTitleWarmCache.Text = "WARM CACHE ACTIVITIES";
            this.labelTitleWarmCache.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxExecutionPictureWarm
            // 
            this.pictureBoxExecutionPictureWarm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPictureWarm.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPictureWarm.Image")));
            this.pictureBoxExecutionPictureWarm.Location = new System.Drawing.Point(70, 0);
            this.pictureBoxExecutionPictureWarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPictureWarm.Name = "pictureBoxExecutionPictureWarm";
            this.pictureBoxExecutionPictureWarm.Size = new System.Drawing.Size(48, 62);
            this.pictureBoxExecutionPictureWarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPictureWarm.TabIndex = 5;
            this.pictureBoxExecutionPictureWarm.TabStop = false;
            // 
            // panelExecutionBandColdCache
            // 
            this.panelExecutionBandColdCache.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.ColdCacheColor;
            this.panelExecutionBandColdCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandColdCache.Location = new System.Drawing.Point(135, 198);
            this.panelExecutionBandColdCache.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandColdCache.Name = "panelExecutionBandColdCache";
            this.tableLayoutPanelMain.SetRowSpan(this.panelExecutionBandColdCache, 4);
            this.panelExecutionBandColdCache.Size = new System.Drawing.Size(5, 64);
            this.panelExecutionBandColdCache.TabIndex = 29;
            this.panelExecutionBandColdCache.Visible = false;
            // 
            // panelExecutionTaskColdCache
            // 
            this.panelExecutionTaskColdCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionTaskColdCache.Controls.Add(this.labelTitleColdCache);
            this.panelExecutionTaskColdCache.Controls.Add(this.pictureBoxExecutionPictureCold);
            this.panelExecutionTaskColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskColdCache.Location = new System.Drawing.Point(140, 198);
            this.panelExecutionTaskColdCache.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskColdCache.Name = "panelExecutionTaskColdCache";
            this.tableLayoutPanelMain.SetRowSpan(this.panelExecutionTaskColdCache, 4);
            this.panelExecutionTaskColdCache.Size = new System.Drawing.Size(120, 64);
            this.panelExecutionTaskColdCache.TabIndex = 28;
            this.panelExecutionTaskColdCache.Visible = false;
            // 
            // labelTitleColdCache
            // 
            this.labelTitleColdCache.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitleColdCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleColdCache.Location = new System.Drawing.Point(0, 0);
            this.labelTitleColdCache.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitleColdCache.Name = "labelTitleColdCache";
            this.labelTitleColdCache.Size = new System.Drawing.Size(72, 62);
            this.labelTitleColdCache.TabIndex = 39;
            this.labelTitleColdCache.Text = "COLD CACHE ACTIVITIES";
            this.labelTitleColdCache.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxExecutionPictureCold
            // 
            this.pictureBoxExecutionPictureCold.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPictureCold.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPictureCold.Image")));
            this.pictureBoxExecutionPictureCold.Location = new System.Drawing.Point(70, 0);
            this.pictureBoxExecutionPictureCold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPictureCold.Name = "pictureBoxExecutionPictureCold";
            this.pictureBoxExecutionPictureCold.Size = new System.Drawing.Size(48, 62);
            this.pictureBoxExecutionPictureCold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPictureCold.TabIndex = 5;
            this.pictureBoxExecutionPictureCold.TabStop = false;
            // 
            // pictureBoxArrowDownCenter1
            // 
            this.pictureBoxArrowDownCenter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxArrowDownCenter1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxArrowDownCenter1.Image")));
            this.pictureBoxArrowDownCenter1.Location = new System.Drawing.Point(140, 264);
            this.pictureBoxArrowDownCenter1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBoxArrowDownCenter1.Name = "pictureBoxArrowDownCenter1";
            this.pictureBoxArrowDownCenter1.Size = new System.Drawing.Size(120, 24);
            this.pictureBoxArrowDownCenter1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxArrowDownCenter1.TabIndex = 27;
            this.pictureBoxArrowDownCenter1.TabStop = false;
            this.pictureBoxArrowDownCenter1.Visible = false;
            // 
            // pictureBoxArrowDownTop
            // 
            this.pictureBoxArrowDownTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxArrowDownTop.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxArrowDownTop.Image")));
            this.pictureBoxArrowDownTop.Location = new System.Drawing.Point(140, 174);
            this.pictureBoxArrowDownTop.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pictureBoxArrowDownTop.Name = "pictureBoxArrowDownTop";
            this.pictureBoxArrowDownTop.Size = new System.Drawing.Size(120, 24);
            this.pictureBoxArrowDownTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxArrowDownTop.TabIndex = 26;
            this.pictureBoxArrowDownTop.TabStop = false;
            this.pictureBoxArrowDownTop.Visible = false;
            // 
            // panelBorderBottomRightInt
            // 
            this.panelBorderBottomRightInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelBorderBottomRightInt, 6);
            this.panelBorderBottomRightInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderBottomRightInt.Location = new System.Drawing.Point(441, 577);
            this.panelBorderBottomRightInt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderBottomRightInt.Name = "panelBorderBottomRightInt";
            this.panelBorderBottomRightInt.Size = new System.Drawing.Size(225, 1);
            this.panelBorderBottomRightInt.TabIndex = 23;
            // 
            // panelBorderBottomRightExt
            // 
            this.panelBorderBottomRightExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelBorderBottomRightExt, 8);
            this.panelBorderBottomRightExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderBottomRightExt.Location = new System.Drawing.Point(441, 582);
            this.panelBorderBottomRightExt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderBottomRightExt.Name = "panelBorderBottomRightExt";
            this.panelBorderBottomRightExt.Size = new System.Drawing.Size(230, 1);
            this.panelBorderBottomRightExt.TabIndex = 22;
            // 
            // panelBorderBottomLeftExt
            // 
            this.panelBorderBottomLeftExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelBorderBottomLeftExt, 8);
            this.panelBorderBottomLeftExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderBottomLeftExt.Location = new System.Drawing.Point(101, 582);
            this.panelBorderBottomLeftExt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderBottomLeftExt.Name = "panelBorderBottomLeftExt";
            this.panelBorderBottomLeftExt.Size = new System.Drawing.Size(230, 1);
            this.panelBorderBottomLeftExt.TabIndex = 21;
            // 
            // panelBorderBottomLeftInt
            // 
            this.panelBorderBottomLeftInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelBorderBottomLeftInt, 6);
            this.panelBorderBottomLeftInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderBottomLeftInt.Location = new System.Drawing.Point(106, 577);
            this.panelBorderBottomLeftInt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderBottomLeftInt.Name = "panelBorderBottomLeftInt";
            this.panelBorderBottomLeftInt.Size = new System.Drawing.Size(225, 1);
            this.panelBorderBottomLeftInt.TabIndex = 20;
            // 
            // panelBorderTopRightInt
            // 
            this.panelBorderTopRightInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelBorderTopRightInt, 7);
            this.panelBorderTopRightInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderTopRightInt.Location = new System.Drawing.Point(436, 37);
            this.panelBorderTopRightInt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderTopRightInt.Name = "panelBorderTopRightInt";
            this.panelBorderTopRightInt.Size = new System.Drawing.Size(230, 1);
            this.panelBorderTopRightInt.TabIndex = 17;
            // 
            // panelBorderTopLeftInt
            // 
            this.panelBorderTopLeftInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelBorderTopLeftInt, 7);
            this.panelBorderTopLeftInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderTopLeftInt.Location = new System.Drawing.Point(106, 37);
            this.panelBorderTopLeftInt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderTopLeftInt.Name = "panelBorderTopLeftInt";
            this.panelBorderTopLeftInt.Size = new System.Drawing.Size(230, 1);
            this.panelBorderTopLeftInt.TabIndex = 16;
            // 
            // panelBorderRightInt
            // 
            this.panelBorderRightInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBorderRightInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderRightInt.Location = new System.Drawing.Point(666, 37);
            this.panelBorderRightInt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderRightInt.Name = "panelBorderRightInt";
            this.tableLayoutPanelMain.SetRowSpan(this.panelBorderRightInt, 28);
            this.panelBorderRightInt.Size = new System.Drawing.Size(1, 541);
            this.panelBorderRightInt.TabIndex = 15;
            // 
            // panelBorderLeftInt
            // 
            this.panelBorderLeftInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBorderLeftInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderLeftInt.Location = new System.Drawing.Point(105, 37);
            this.panelBorderLeftInt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderLeftInt.Name = "panelBorderLeftInt";
            this.tableLayoutPanelMain.SetRowSpan(this.panelBorderLeftInt, 28);
            this.panelBorderLeftInt.Size = new System.Drawing.Size(1, 541);
            this.panelBorderLeftInt.TabIndex = 10;
            // 
            // panelBorderTopRightExt
            // 
            this.panelBorderTopRightExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelBorderTopRightExt, 9);
            this.panelBorderTopRightExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderTopRightExt.Location = new System.Drawing.Point(436, 32);
            this.panelBorderTopRightExt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderTopRightExt.Name = "panelBorderTopRightExt";
            this.panelBorderTopRightExt.Size = new System.Drawing.Size(235, 1);
            this.panelBorderTopRightExt.TabIndex = 9;
            // 
            // panelBorderLeftExt
            // 
            this.panelBorderLeftExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBorderLeftExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderLeftExt.Location = new System.Drawing.Point(100, 32);
            this.panelBorderLeftExt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderLeftExt.Name = "panelBorderLeftExt";
            this.tableLayoutPanelMain.SetRowSpan(this.panelBorderLeftExt, 32);
            this.panelBorderLeftExt.Size = new System.Drawing.Size(1, 551);
            this.panelBorderLeftExt.TabIndex = 8;
            // 
            // panelBorderTopLeftExt
            // 
            this.panelBorderTopLeftExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelBorderTopLeftExt, 9);
            this.panelBorderTopLeftExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderTopLeftExt.Location = new System.Drawing.Point(101, 32);
            this.panelBorderTopLeftExt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderTopLeftExt.Name = "panelBorderTopLeftExt";
            this.panelBorderTopLeftExt.Size = new System.Drawing.Size(235, 1);
            this.panelBorderTopLeftExt.TabIndex = 6;
            // 
            // pictureBoxProgress
            // 
            this.pictureBoxProgress.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxProgress.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.ASQA_ExecutionProgress_100ms;
            this.pictureBoxProgress.InitialImage = null;
            this.pictureBoxProgress.Location = new System.Drawing.Point(336, 2);
            this.pictureBoxProgress.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxProgress.Name = "pictureBoxProgress";
            this.tableLayoutPanelMain.SetRowSpan(this.pictureBoxProgress, 5);
            this.pictureBoxProgress.Size = new System.Drawing.Size(100, 66);
            this.pictureBoxProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxProgress.TabIndex = 4;
            this.pictureBoxProgress.TabStop = false;
            // 
            // panelBorderRightExt
            // 
            this.panelBorderRightExt.BackColor = System.Drawing.SystemColors.Window;
            this.panelBorderRightExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBorderRightExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderRightExt.ForeColor = System.Drawing.Color.Black;
            this.panelBorderRightExt.Location = new System.Drawing.Point(671, 32);
            this.panelBorderRightExt.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorderRightExt.Name = "panelBorderRightExt";
            this.tableLayoutPanelMain.SetRowSpan(this.panelBorderRightExt, 32);
            this.panelBorderRightExt.Size = new System.Drawing.Size(1, 551);
            this.panelBorderRightExt.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(339, 564);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.tableLayoutPanelMain.SetRowSpan(this.buttonCancel, 5);
            this.buttonCancel.Size = new System.Drawing.Size(94, 32);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "C A N C E L";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnButtonCancel_Click);
            // 
            // panelExecutionBandPre
            // 
            this.panelExecutionBandPre.BackColor = System.Drawing.Color.Gray;
            this.panelExecutionBandPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionBandPre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionBandPre.Location = new System.Drawing.Point(135, 109);
            this.panelExecutionBandPre.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionBandPre.Name = "panelExecutionBandPre";
            this.tableLayoutPanelMain.SetRowSpan(this.panelExecutionBandPre, 3);
            this.panelExecutionBandPre.Size = new System.Drawing.Size(5, 63);
            this.panelExecutionBandPre.TabIndex = 24;
            this.panelExecutionBandPre.Visible = false;
            // 
            // panelExecutionTaskPre
            // 
            this.panelExecutionTaskPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExecutionTaskPre.Controls.Add(this.labelTitlePre);
            this.panelExecutionTaskPre.Controls.Add(this.pictureBoxExecutionPicturePre);
            this.panelExecutionTaskPre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExecutionTaskPre.Location = new System.Drawing.Point(140, 109);
            this.panelExecutionTaskPre.Margin = new System.Windows.Forms.Padding(0);
            this.panelExecutionTaskPre.Name = "panelExecutionTaskPre";
            this.tableLayoutPanelMain.SetRowSpan(this.panelExecutionTaskPre, 3);
            this.panelExecutionTaskPre.Size = new System.Drawing.Size(120, 63);
            this.panelExecutionTaskPre.TabIndex = 25;
            this.panelExecutionTaskPre.Visible = false;
            // 
            // labelTitlePre
            // 
            this.labelTitlePre.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitlePre.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePre.Location = new System.Drawing.Point(0, 0);
            this.labelTitlePre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelTitlePre.Name = "labelTitlePre";
            this.labelTitlePre.Size = new System.Drawing.Size(72, 61);
            this.labelTitlePre.TabIndex = 38;
            this.labelTitlePre.Text = "PRE EXECUTION ACTIVITIES";
            this.labelTitlePre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxExecutionPicturePre
            // 
            this.pictureBoxExecutionPicturePre.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxExecutionPicturePre.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExecutionPicturePre.Image")));
            this.pictureBoxExecutionPicturePre.Location = new System.Drawing.Point(70, 0);
            this.pictureBoxExecutionPicturePre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExecutionPicturePre.Name = "pictureBoxExecutionPicturePre";
            this.pictureBoxExecutionPicturePre.Size = new System.Drawing.Size(48, 61);
            this.pictureBoxExecutionPicturePre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExecutionPicturePre.TabIndex = 5;
            this.pictureBoxExecutionPicturePre.TabStop = false;
            // 
            // labelName_Pre_VerifyMDX
            // 
            this.labelName_Pre_VerifyMDX.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName_Pre_VerifyMDX, 7);
            this.labelName_Pre_VerifyMDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName_Pre_VerifyMDX.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName_Pre_VerifyMDX.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelName_Pre_VerifyMDX.Location = new System.Drawing.Point(274, 109);
            this.labelName_Pre_VerifyMDX.Name = "labelName_Pre_VerifyMDX";
            this.labelName_Pre_VerifyMDX.Size = new System.Drawing.Size(224, 21);
            this.labelName_Pre_VerifyMDX.TabIndex = 35;
            this.labelName_Pre_VerifyMDX.Text = "Verify MDX";
            this.labelName_Pre_VerifyMDX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelName_Pre_VerifyMDX.Visible = false;
            // 
            // ResultPresenterExecutionProgressControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ResultPresenterExecutionProgressControl";
            this.Size = new System.Drawing.Size(772, 600);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.panelExecutionTaskPostCold.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePostCold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDownCenter2)).EndInit();
            this.panelExecutionTaskPostWarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePostWarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDownBottom)).EndInit();
            this.panelExecutionTaskWarmCache.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPictureWarm)).EndInit();
            this.panelExecutionTaskColdCache.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPictureCold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDownCenter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrowDownTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).EndInit();
            this.panelExecutionTaskPre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecutionPicturePre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Panel panelBorderBottomRightInt;
        private System.Windows.Forms.Panel panelBorderBottomRightExt;
        private System.Windows.Forms.Panel panelBorderBottomLeftExt;
        private System.Windows.Forms.Panel panelBorderBottomLeftInt;
        private System.Windows.Forms.Panel panelBorderTopRightInt;
        private System.Windows.Forms.Panel panelBorderTopLeftInt;
        private System.Windows.Forms.Panel panelBorderRightInt;
        private System.Windows.Forms.Panel panelBorderLeftInt;
        private System.Windows.Forms.Panel panelBorderTopRightExt;
        private System.Windows.Forms.Panel panelBorderLeftExt;
        private System.Windows.Forms.Panel panelBorderTopLeftExt;
        private System.Windows.Forms.PictureBox pictureBoxProgress;
        private System.Windows.Forms.Panel panelBorderRightExt;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelResult_PostWarm_RenderingData;
        private System.Windows.Forms.Label labelName_PostWarm_RenderingData;
        private System.Windows.Forms.Label labelResult_PostCold_RetrieveData;
        private System.Windows.Forms.Label labelName_PostCold_RetrieveData;
        private System.Windows.Forms.Panel panelExecutionBandPostCold;
        private System.Windows.Forms.Panel panelExecutionTaskPostCold;
        private System.Windows.Forms.Label labelTitlePostCold;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPicturePostCold;
        private System.Windows.Forms.PictureBox pictureBoxArrowDownCenter2;
        private System.Windows.Forms.Label labelResult_PostWarm_RetrieveData;
        private System.Windows.Forms.Label labelName_PostWarm_RetrieveData;
        private System.Windows.Forms.Label labelResult_Warm_CalculateMetrics;
        private System.Windows.Forms.Label labelResult_Warm_ExecuteMDX;
        private System.Windows.Forms.Label labelResult_Warm_CollectData;
        private System.Windows.Forms.Label labelResult_Warm_RunTraces;
        private System.Windows.Forms.Label labelName_Warm_CollectData;
        private System.Windows.Forms.Label labelName_Warm_ExecuteMDX;
        private System.Windows.Forms.Label labelName_Warm_CalculateMetrics;
        private System.Windows.Forms.Label labelName_Warm_RunTraces;
        private System.Windows.Forms.Label labelResult_Cold_CollectData;
        private System.Windows.Forms.Label labelName_Cold_CollectData;
        private System.Windows.Forms.Label labelResult_Cold_ExecuteMDX;
        private System.Windows.Forms.Label labelName_Cold_ExecuteMDX;
        private System.Windows.Forms.Label labelResult_Cold_CalculateMetrics;
        private System.Windows.Forms.Label labelName_Cold_CalculateMetrics;
        private System.Windows.Forms.Label labelResult_Cold_RunTraces;
        private System.Windows.Forms.Label labelName_Cold_RunTraces;
        private System.Windows.Forms.Label labelResult_Pre_LoadCubeMDXScript;
        private System.Windows.Forms.Label labelResult_Pre_ClearCache;
        private System.Windows.Forms.Label labelResult_Pre_VerifyMDX;
        private System.Windows.Forms.Label labelName_Pre_LoadCubeMDXScript;
        private System.Windows.Forms.Label labelName_Pre_ClearCache;
        private System.Windows.Forms.Panel panelExecutionBandPostWarm;
        private System.Windows.Forms.Panel panelExecutionTaskPostWarm;
        private System.Windows.Forms.Label labelTitlePostWarm;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPicturePostWarm;
        private System.Windows.Forms.Panel panelExecutionBandWarmCache;
        private System.Windows.Forms.PictureBox pictureBoxArrowDownBottom;
        private System.Windows.Forms.Panel panelExecutionTaskWarmCache;
        private System.Windows.Forms.Label labelTitleWarmCache;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPictureWarm;
        private System.Windows.Forms.Panel panelExecutionBandColdCache;
        private System.Windows.Forms.Panel panelExecutionTaskColdCache;
        private System.Windows.Forms.Label labelTitleColdCache;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPictureCold;
        private System.Windows.Forms.PictureBox pictureBoxArrowDownCenter1;
        private System.Windows.Forms.PictureBox pictureBoxArrowDownTop;
        private System.Windows.Forms.Panel panelExecutionBandPre;
        private System.Windows.Forms.Panel panelExecutionTaskPre;
        private System.Windows.Forms.Label labelTitlePre;
        private System.Windows.Forms.PictureBox pictureBoxExecutionPicturePre;
        private System.Windows.Forms.Label labelName_Pre_VerifyMDX;



    }
}
