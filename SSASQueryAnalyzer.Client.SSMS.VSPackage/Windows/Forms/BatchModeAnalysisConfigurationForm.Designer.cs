namespace SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms
{
    partial class BatchModeAnalysisConfigurationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureAnalysisName = new System.Windows.Forms.PictureBox();
            this.pictureSQLInstance = new System.Windows.Forms.PictureBox();
            this.textBoxBatchName = new System.Windows.Forms.TextBox();
            this.laberlBatchName = new System.Windows.Forms.Label();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.comboBoxConnections = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelBatchMode = new System.Windows.Forms.Panel();
            this.pictureBatchMode = new System.Windows.Forms.PictureBox();
            this.panelBatchModeBottom = new System.Windows.Forms.Panel();
            this.labelAnalysisNameTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSQLInstanceTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.customLabelBatchModeTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnalysisName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSQLInstance)).BeginInit();
            this.panelBatchMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBatchMode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureAnalysisName);
            this.panel1.Controls.Add(this.labelAnalysisNameTitle);
            this.panel1.Controls.Add(this.pictureSQLInstance);
            this.panel1.Controls.Add(this.labelSQLInstanceTitle);
            this.panel1.Controls.Add(this.textBoxBatchName);
            this.panel1.Controls.Add(this.laberlBatchName);
            this.panel1.Controls.Add(this.labelConnectionString);
            this.panel1.Controls.Add(this.comboBoxConnections);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 226);
            this.panel1.TabIndex = 1;
            // 
            // pictureAnalysisName
            // 
            this.pictureAnalysisName.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.InsertName_32x32;
            this.pictureAnalysisName.Location = new System.Drawing.Point(8, 98);
            this.pictureAnalysisName.Name = "pictureAnalysisName";
            this.pictureAnalysisName.Size = new System.Drawing.Size(34, 34);
            this.pictureAnalysisName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureAnalysisName.TabIndex = 93;
            this.pictureAnalysisName.TabStop = false;
            // 
            // pictureSQLInstance
            // 
            this.pictureSQLInstance.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.SQLServer_32x32;
            this.pictureSQLInstance.Location = new System.Drawing.Point(8, 8);
            this.pictureSQLInstance.Name = "pictureSQLInstance";
            this.pictureSQLInstance.Size = new System.Drawing.Size(34, 34);
            this.pictureSQLInstance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureSQLInstance.TabIndex = 91;
            this.pictureSQLInstance.TabStop = false;
            // 
            // textBoxBatchName
            // 
            this.textBoxBatchName.Location = new System.Drawing.Point(44, 155);
            this.textBoxBatchName.Name = "textBoxBatchName";
            this.textBoxBatchName.Size = new System.Drawing.Size(306, 20);
            this.textBoxBatchName.TabIndex = 8;
            // 
            // laberlBatchName
            // 
            this.laberlBatchName.AutoSize = true;
            this.laberlBatchName.Location = new System.Drawing.Point(44, 138);
            this.laberlBatchName.Margin = new System.Windows.Forms.Padding(0);
            this.laberlBatchName.Name = "laberlBatchName";
            this.laberlBatchName.Size = new System.Drawing.Size(147, 13);
            this.laberlBatchName.TabIndex = 7;
            this.laberlBatchName.Text = "Enter a name for this analysis:";
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(44, 48);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(302, 13);
            this.labelConnectionString.TabIndex = 6;
            this.labelConnectionString.Text = "Select the SQL Server instance where to save analysis results:";
            // 
            // comboBoxConnections
            // 
            this.comboBoxConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConnections.FormattingEnabled = true;
            this.comboBoxConnections.Location = new System.Drawing.Point(44, 63);
            this.comboBoxConnections.Name = "comboBoxConnections";
            this.comboBoxConnections.Size = new System.Drawing.Size(306, 21);
            this.comboBoxConnections.TabIndex = 5;
            this.comboBoxConnections.DropDown += new System.EventHandler(this.ComboBoxConnections_DropDown);
            this.comboBoxConnections.DropDownClosed += new System.EventHandler(this.ComboBoxConnections_DropDownClosed);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(171, 186);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(86, 28);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(264, 186);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 28);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panelBatchMode
            // 
            this.panelBatchMode.BackColor = System.Drawing.Color.Transparent;
            this.panelBatchMode.Controls.Add(this.pictureBatchMode);
            this.panelBatchMode.Controls.Add(this.customLabelBatchModeTitle);
            this.panelBatchMode.Controls.Add(this.panelBatchModeBottom);
            this.panelBatchMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBatchMode.Location = new System.Drawing.Point(0, 0);
            this.panelBatchMode.Name = "panelBatchMode";
            this.panelBatchMode.Size = new System.Drawing.Size(367, 48);
            this.panelBatchMode.TabIndex = 84;
            // 
            // pictureBatchMode
            // 
            this.pictureBatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBatchMode.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.BatchMode_32x32;
            this.pictureBatchMode.Location = new System.Drawing.Point(326, 8);
            this.pictureBatchMode.Name = "pictureBatchMode";
            this.pictureBatchMode.Size = new System.Drawing.Size(34, 34);
            this.pictureBatchMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBatchMode.TabIndex = 78;
            this.pictureBatchMode.TabStop = false;
            // 
            // panelBatchModeBottom
            // 
            this.panelBatchModeBottom.BackColor = System.Drawing.Color.Black;
            this.panelBatchModeBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBatchModeBottom.Location = new System.Drawing.Point(0, 47);
            this.panelBatchModeBottom.Name = "panelBatchModeBottom";
            this.panelBatchModeBottom.Size = new System.Drawing.Size(367, 1);
            this.panelBatchModeBottom.TabIndex = 86;
            // 
            // labelAnalysisNameTitle
            // 
            this.labelAnalysisNameTitle.AutoSize = true;
            this.labelAnalysisNameTitle.BorderColor = System.Drawing.Color.Black;
            this.labelAnalysisNameTitle.BorderHeightOffset = 2;
            this.labelAnalysisNameTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelAnalysisNameTitle.BorderWidthOffset = 2;
            this.labelAnalysisNameTitle.DrawBorder = false;
            this.labelAnalysisNameTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnalysisNameTitle.Location = new System.Drawing.Point(48, 107);
            this.labelAnalysisNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelAnalysisNameTitle.Name = "labelAnalysisNameTitle";
            this.labelAnalysisNameTitle.Size = new System.Drawing.Size(122, 12);
            this.labelAnalysisNameTitle.TabIndex = 92;
            this.labelAnalysisNameTitle.Text = "Analysis name [Optional]";
            this.labelAnalysisNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSQLInstanceTitle
            // 
            this.labelSQLInstanceTitle.AutoSize = true;
            this.labelSQLInstanceTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSQLInstanceTitle.BorderHeightOffset = 2;
            this.labelSQLInstanceTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSQLInstanceTitle.BorderWidthOffset = 2;
            this.labelSQLInstanceTitle.DrawBorder = false;
            this.labelSQLInstanceTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLInstanceTitle.Location = new System.Drawing.Point(48, 17);
            this.labelSQLInstanceTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSQLInstanceTitle.Name = "labelSQLInstanceTitle";
            this.labelSQLInstanceTitle.Size = new System.Drawing.Size(97, 12);
            this.labelSQLInstanceTitle.TabIndex = 90;
            this.labelSQLInstanceTitle.Text = "SQL Server instance";
            this.labelSQLInstanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customLabelBatchModeTitle
            // 
            this.customLabelBatchModeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customLabelBatchModeTitle.AutoSize = true;
            this.customLabelBatchModeTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelBatchModeTitle.BorderHeightOffset = 2;
            this.customLabelBatchModeTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelBatchModeTitle.BorderWidthOffset = 2;
            this.customLabelBatchModeTitle.DrawBorder = false;
            this.customLabelBatchModeTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelBatchModeTitle.Location = new System.Drawing.Point(222, 19);
            this.customLabelBatchModeTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelBatchModeTitle.Name = "customLabelBatchModeTitle";
            this.customLabelBatchModeTitle.Size = new System.Drawing.Size(98, 12);
            this.customLabelBatchModeTitle.TabIndex = 79;
            this.customLabelBatchModeTitle.Text = "Batch mode analysis";
            this.customLabelBatchModeTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // BatchModeAnalysisConfigurationForm
            // 
            this.AcceptButton = this.buttonCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(367, 274);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBatchMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BatchModeAnalysisConfigurationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASQA - Configure Batch Mode analysis";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnalysisName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSQLInstance)).EndInit();
            this.panelBatchMode.ResumeLayout(false);
            this.panelBatchMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBatchMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxConnections;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.Label laberlBatchName;
        private System.Windows.Forms.TextBox textBoxBatchName;
        private System.Windows.Forms.PictureBox pictureSQLInstance;
        private Common.Windows.Forms.CustomLabelControl labelSQLInstanceTitle;
        private System.Windows.Forms.PictureBox pictureAnalysisName;
        private Common.Windows.Forms.CustomLabelControl labelAnalysisNameTitle;
        private System.Windows.Forms.Panel panelBatchMode;
        private System.Windows.Forms.PictureBox pictureBatchMode;
        private Common.Windows.Forms.CustomLabelControl customLabelBatchModeTitle;
        private System.Windows.Forms.Panel panelBatchModeBottom;
        private System.Windows.Forms.Button buttonCancel;
    }
}