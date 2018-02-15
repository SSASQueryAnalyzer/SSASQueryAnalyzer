using SSASQueryAnalyzer.Client.Common.Properties;

namespace SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms
{
    partial class AsqaHelperControl
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageAddin = new System.Windows.Forms.TabPage();
            this.asqaHelperAddinControl1 = new SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms.AsqaHelperAddinControl();
            this.tabPageLiveMode = new System.Windows.Forms.TabPage();
            this.asqaHelperLiveModeControl1 = new SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms.AsqaHelperLiveModeControl();
            this.tabPageBatchMode = new System.Windows.Forms.TabPage();
            this.asqaHelperBatchModeControl1 = new SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms.AsqaHelperBatchModeControl();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.resultPresenterAboutControl1 = new SSASQueryAnalyzer.Client.Common.Windows.Forms.ResultPresenterAboutControl();
            this.panelWaiting = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelWait = new System.Windows.Forms.Label();
            this.pictureBoxProgress = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonSaveConfiguration = new System.Windows.Forms.Button();
            this.buttonRestoreDefaultConfiguration = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageAddin.SuspendLayout();
            this.tabPageLiveMode.SuspendLayout();
            this.tabPageBatchMode.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.panelWaiting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.tabControlMain);
            this.panelMain.Controls.Add(this.panelWaiting);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(460, 773);
            this.panelMain.TabIndex = 1;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageAddin);
            this.tabControlMain.Controls.Add(this.tabPageLiveMode);
            this.tabControlMain.Controls.Add(this.tabPageBatchMode);
            this.tabControlMain.Controls.Add(this.tabPageAbout);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(460, 665);
            this.tabControlMain.TabIndex = 4;
            this.tabControlMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabControlMain_Selected);
            // 
            // tabPageAddin
            // 
            this.tabPageAddin.BackColor = System.Drawing.Color.White;
            this.tabPageAddin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageAddin.Controls.Add(this.asqaHelperAddinControl1);
            this.tabPageAddin.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddin.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageAddin.Name = "tabPageAddin";
            this.tabPageAddin.Size = new System.Drawing.Size(452, 639);
            this.tabPageAddin.TabIndex = 3;
            this.tabPageAddin.Text = "Addin";
            // 
            // asqaHelperAddinControl1
            // 
            this.asqaHelperAddinControl1.BackColor = System.Drawing.Color.White;
            this.asqaHelperAddinControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asqaHelperAddinControl1.Location = new System.Drawing.Point(0, 0);
            this.asqaHelperAddinControl1.Margin = new System.Windows.Forms.Padding(4);
            this.asqaHelperAddinControl1.Name = "asqaHelperAddinControl1";
            this.asqaHelperAddinControl1.Size = new System.Drawing.Size(450, 637);
            this.asqaHelperAddinControl1.TabIndex = 2;
            // 
            // tabPageLiveMode
            // 
            this.tabPageLiveMode.BackColor = System.Drawing.Color.White;
            this.tabPageLiveMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageLiveMode.Controls.Add(this.asqaHelperLiveModeControl1);
            this.tabPageLiveMode.Location = new System.Drawing.Point(4, 22);
            this.tabPageLiveMode.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageLiveMode.Name = "tabPageLiveMode";
            this.tabPageLiveMode.Size = new System.Drawing.Size(452, 639);
            this.tabPageLiveMode.TabIndex = 4;
            this.tabPageLiveMode.Text = "Live mode";
            // 
            // asqaHelperLiveModeControl1
            // 
            this.asqaHelperLiveModeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asqaHelperLiveModeControl1.Location = new System.Drawing.Point(0, 0);
            this.asqaHelperLiveModeControl1.Margin = new System.Windows.Forms.Padding(4);
            this.asqaHelperLiveModeControl1.Name = "asqaHelperLiveModeControl1";
            this.asqaHelperLiveModeControl1.Size = new System.Drawing.Size(450, 637);
            this.asqaHelperLiveModeControl1.TabIndex = 0;
            // 
            // tabPageBatchMode
            // 
            this.tabPageBatchMode.BackColor = System.Drawing.Color.White;
            this.tabPageBatchMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageBatchMode.Controls.Add(this.asqaHelperBatchModeControl1);
            this.tabPageBatchMode.Location = new System.Drawing.Point(4, 22);
            this.tabPageBatchMode.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageBatchMode.Name = "tabPageBatchMode";
            this.tabPageBatchMode.Size = new System.Drawing.Size(452, 639);
            this.tabPageBatchMode.TabIndex = 5;
            this.tabPageBatchMode.Text = "Batch mode";
            // 
            // asqaHelperBatchModeControl1
            // 
            this.asqaHelperBatchModeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asqaHelperBatchModeControl1.Location = new System.Drawing.Point(0, 0);
            this.asqaHelperBatchModeControl1.Margin = new System.Windows.Forms.Padding(4);
            this.asqaHelperBatchModeControl1.Name = "asqaHelperBatchModeControl1";
            this.asqaHelperBatchModeControl1.Size = new System.Drawing.Size(450, 637);
            this.asqaHelperBatchModeControl1.TabIndex = 0;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.BackColor = System.Drawing.Color.White;
            this.tabPageAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageAbout.Controls.Add(this.resultPresenterAboutControl1);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Size = new System.Drawing.Size(452, 639);
            this.tabPageAbout.TabIndex = 2;
            this.tabPageAbout.Text = "About";
            // 
            // resultPresenterAboutControl1
            // 
            this.resultPresenterAboutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPresenterAboutControl1.Location = new System.Drawing.Point(0, 0);
            this.resultPresenterAboutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultPresenterAboutControl1.Name = "resultPresenterAboutControl1";
            this.resultPresenterAboutControl1.Size = new System.Drawing.Size(450, 637);
            this.resultPresenterAboutControl1.TabIndex = 0;
            // 
            // panelWaiting
            // 
            this.panelWaiting.BackColor = System.Drawing.Color.White;
            this.panelWaiting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWaiting.Controls.Add(this.tableLayoutPanel1);
            this.panelWaiting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelWaiting.Location = new System.Drawing.Point(0, 665);
            this.panelWaiting.Margin = new System.Windows.Forms.Padding(0);
            this.panelWaiting.Name = "panelWaiting";
            this.panelWaiting.Size = new System.Drawing.Size(460, 66);
            this.panelWaiting.TabIndex = 5;
            this.panelWaiting.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.labelWait, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxProgress, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 64);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelWait
            // 
            this.labelWait.AutoSize = true;
            this.labelWait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWait.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWait.ForeColor = System.Drawing.Color.Black;
            this.labelWait.Location = new System.Drawing.Point(187, 0);
            this.labelWait.Name = "labelWait";
            this.labelWait.Size = new System.Drawing.Size(184, 64);
            this.labelWait.TabIndex = 44;
            this.labelWait.Text = "Please wait ...";
            this.labelWait.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxProgress
            // 
            this.pictureBoxProgress.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxProgress.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.ASQA_ExecutionProgress_100ms;
            this.pictureBoxProgress.InitialImage = null;
            this.pictureBoxProgress.Location = new System.Drawing.Point(384, 0);
            this.pictureBoxProgress.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxProgress.Name = "pictureBoxProgress";
            this.pictureBoxProgress.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxProgress.TabIndex = 5;
            this.pictureBoxProgress.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.buttonSaveConfiguration);
            this.panelBottom.Controls.Add(this.buttonRestoreDefaultConfiguration);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 731);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(460, 42);
            this.panelBottom.TabIndex = 2;
            // 
            // buttonSaveConfiguration
            // 
            this.buttonSaveConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveConfiguration.Location = new System.Drawing.Point(282, 6);
            this.buttonSaveConfiguration.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSaveConfiguration.Name = "buttonSaveConfiguration";
            this.buttonSaveConfiguration.Size = new System.Drawing.Size(170, 28);
            this.buttonSaveConfiguration.TabIndex = 2;
            this.buttonSaveConfiguration.Text = "Save";
            this.buttonSaveConfiguration.UseVisualStyleBackColor = true;
            this.buttonSaveConfiguration.Click += new System.EventHandler(this.OnButtonSaveConfiguration_Click);
            // 
            // buttonRestoreDefaultConfiguration
            // 
            this.buttonRestoreDefaultConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRestoreDefaultConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestoreDefaultConfiguration.Location = new System.Drawing.Point(103, 6);
            this.buttonRestoreDefaultConfiguration.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRestoreDefaultConfiguration.Name = "buttonRestoreDefaultConfiguration";
            this.buttonRestoreDefaultConfiguration.Size = new System.Drawing.Size(166, 28);
            this.buttonRestoreDefaultConfiguration.TabIndex = 0;
            this.buttonRestoreDefaultConfiguration.Text = "Restore default";
            this.buttonRestoreDefaultConfiguration.UseVisualStyleBackColor = true;
            this.buttonRestoreDefaultConfiguration.Click += new System.EventHandler(this.OnButtonRestoreDefaultConfiguration_Click);
            // 
            // AsqaHelperControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panelMain);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AsqaHelperControl";
            this.Size = new System.Drawing.Size(460, 773);
            this.panelMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageAddin.ResumeLayout(false);
            this.tabPageLiveMode.ResumeLayout(false);
            this.tabPageBatchMode.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
            this.panelWaiting.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageAddin;
        private AsqaHelperAddinControl asqaHelperAddinControl1;
        private System.Windows.Forms.TabPage tabPageLiveMode;
        private AsqaHelperLiveModeControl asqaHelperLiveModeControl1;
        private System.Windows.Forms.TabPage tabPageBatchMode;
        private AsqaHelperBatchModeControl asqaHelperBatchModeControl1;
        private System.Windows.Forms.TabPage tabPageAbout;
        private Common.Windows.Forms.ResultPresenterAboutControl resultPresenterAboutControl1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonSaveConfiguration;
        private System.Windows.Forms.Button buttonRestoreDefaultConfiguration;
        private System.Windows.Forms.Panel panelWaiting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxProgress;
        private System.Windows.Forms.Label labelWait;



    }
}
