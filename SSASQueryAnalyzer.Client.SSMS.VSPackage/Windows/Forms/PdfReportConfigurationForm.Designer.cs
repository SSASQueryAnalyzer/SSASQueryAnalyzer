namespace SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms
{
    partial class PdfReportConfigurationForm
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
            this.panelPdfReportMode = new System.Windows.Forms.Panel();
            this.panelPdfReportModeBottom = new System.Windows.Forms.Panel();
            this.checkBoxSaveReport = new System.Windows.Forms.CheckBox();
            this.checkBoxShowReport = new System.Windows.Forms.CheckBox();
            this.checkBoxExecuteAnalysis = new System.Windows.Forms.CheckBox();
            this.panelPdfReportTitle = new System.Windows.Forms.Panel();
            this.picturePdfDocument = new System.Windows.Forms.PictureBox();
            this.panelPdfReportTitleBottom = new System.Windows.Forms.Panel();
            this.panelPdfReportSave = new System.Windows.Forms.Panel();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.panelPdfReportButtons = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.savePdfReportDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonSaveDialog = new System.Windows.Forms.Button();
            this.customLabelPdfReportTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelPdfReportMode.SuspendLayout();
            this.panelPdfReportTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePdfDocument)).BeginInit();
            this.panelPdfReportSave.SuspendLayout();
            this.panelPdfReportButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPdfReportMode
            // 
            this.panelPdfReportMode.Controls.Add(this.panelPdfReportModeBottom);
            this.panelPdfReportMode.Controls.Add(this.checkBoxSaveReport);
            this.panelPdfReportMode.Controls.Add(this.checkBoxShowReport);
            this.panelPdfReportMode.Controls.Add(this.checkBoxExecuteAnalysis);
            this.panelPdfReportMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPdfReportMode.Location = new System.Drawing.Point(0, 48);
            this.panelPdfReportMode.Name = "panelPdfReportMode";
            this.panelPdfReportMode.Size = new System.Drawing.Size(390, 34);
            this.panelPdfReportMode.TabIndex = 1;
            // 
            // panelPdfReportModeBottom
            // 
            this.panelPdfReportModeBottom.BackColor = System.Drawing.Color.Black;
            this.panelPdfReportModeBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPdfReportModeBottom.Location = new System.Drawing.Point(0, 33);
            this.panelPdfReportModeBottom.Name = "panelPdfReportModeBottom";
            this.panelPdfReportModeBottom.Size = new System.Drawing.Size(390, 1);
            this.panelPdfReportModeBottom.TabIndex = 97;
            // 
            // checkBoxSaveReport
            // 
            this.checkBoxSaveReport.Location = new System.Drawing.Point(302, 8);
            this.checkBoxSaveReport.Name = "checkBoxSaveReport";
            this.checkBoxSaveReport.Size = new System.Drawing.Size(86, 17);
            this.checkBoxSaveReport.TabIndex = 96;
            this.checkBoxSaveReport.Text = "Save Report";
            this.checkBoxSaveReport.UseVisualStyleBackColor = true;
            this.checkBoxSaveReport.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // checkBoxShowReport
            // 
            this.checkBoxShowReport.AutoSize = true;
            this.checkBoxShowReport.Checked = true;
            this.checkBoxShowReport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowReport.Location = new System.Drawing.Point(164, 8);
            this.checkBoxShowReport.Name = "checkBoxShowReport";
            this.checkBoxShowReport.Size = new System.Drawing.Size(88, 17);
            this.checkBoxShowReport.TabIndex = 95;
            this.checkBoxShowReport.Text = "Show Report";
            this.checkBoxShowReport.UseVisualStyleBackColor = true;
            this.checkBoxShowReport.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // checkBoxExecuteAnalysis
            // 
            this.checkBoxExecuteAnalysis.AutoSize = true;
            this.checkBoxExecuteAnalysis.Location = new System.Drawing.Point(8, 8);
            this.checkBoxExecuteAnalysis.Name = "checkBoxExecuteAnalysis";
            this.checkBoxExecuteAnalysis.Size = new System.Drawing.Size(106, 17);
            this.checkBoxExecuteAnalysis.TabIndex = 94;
            this.checkBoxExecuteAnalysis.Text = "Execute Analysis";
            this.checkBoxExecuteAnalysis.UseVisualStyleBackColor = true;
            this.checkBoxExecuteAnalysis.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // panelPdfReportTitle
            // 
            this.panelPdfReportTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelPdfReportTitle.Controls.Add(this.picturePdfDocument);
            this.panelPdfReportTitle.Controls.Add(this.customLabelPdfReportTitle);
            this.panelPdfReportTitle.Controls.Add(this.panelPdfReportTitleBottom);
            this.panelPdfReportTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPdfReportTitle.Location = new System.Drawing.Point(0, 0);
            this.panelPdfReportTitle.Name = "panelPdfReportTitle";
            this.panelPdfReportTitle.Size = new System.Drawing.Size(390, 48);
            this.panelPdfReportTitle.TabIndex = 84;
            // 
            // picturePdfDocument
            // 
            this.picturePdfDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePdfDocument.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.Pdf_Icon_32x32;
            this.picturePdfDocument.Location = new System.Drawing.Point(349, 8);
            this.picturePdfDocument.Name = "picturePdfDocument";
            this.picturePdfDocument.Size = new System.Drawing.Size(34, 34);
            this.picturePdfDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturePdfDocument.TabIndex = 78;
            this.picturePdfDocument.TabStop = false;
            // 
            // panelPdfReportTitleBottom
            // 
            this.panelPdfReportTitleBottom.BackColor = System.Drawing.Color.Black;
            this.panelPdfReportTitleBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPdfReportTitleBottom.Location = new System.Drawing.Point(0, 47);
            this.panelPdfReportTitleBottom.Name = "panelPdfReportTitleBottom";
            this.panelPdfReportTitleBottom.Size = new System.Drawing.Size(390, 1);
            this.panelPdfReportTitleBottom.TabIndex = 86;
            // 
            // panelPdfReportSave
            // 
            this.panelPdfReportSave.Controls.Add(this.buttonSaveDialog);
            this.panelPdfReportSave.Controls.Add(this.textBoxFilePath);
            this.panelPdfReportSave.Controls.Add(this.labelFilePath);
            this.panelPdfReportSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPdfReportSave.Location = new System.Drawing.Point(0, 82);
            this.panelPdfReportSave.Name = "panelPdfReportSave";
            this.panelPdfReportSave.Size = new System.Drawing.Size(390, 51);
            this.panelPdfReportSave.TabIndex = 85;
            this.panelPdfReportSave.Visible = false;
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Enabled = false;
            this.textBoxFilePath.Location = new System.Drawing.Point(52, 16);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(301, 20);
            this.textBoxFilePath.TabIndex = 1;
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Enabled = false;
            this.labelFilePath.Location = new System.Drawing.Point(8, 19);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(45, 13);
            this.labelFilePath.TabIndex = 0;
            this.labelFilePath.Text = "FilePath";
            // 
            // panelPdfReportButtons
            // 
            this.panelPdfReportButtons.Controls.Add(this.buttonCancel);
            this.panelPdfReportButtons.Controls.Add(this.buttonOK);
            this.panelPdfReportButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPdfReportButtons.Location = new System.Drawing.Point(0, 133);
            this.panelPdfReportButtons.Name = "panelPdfReportButtons";
            this.panelPdfReportButtons.Size = new System.Drawing.Size(390, 58);
            this.panelPdfReportButtons.TabIndex = 86;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(204, 15);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(86, 28);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // savePdfReportDialog
            // 
            this.savePdfReportDialog.Filter = "Pdf Files|*.pdf";
            // 
            // buttonSaveDialog
            // 
            this.buttonSaveDialog.Location = new System.Drawing.Point(357, 13);
            this.buttonSaveDialog.Name = "buttonSaveDialog";
            this.buttonSaveDialog.Size = new System.Drawing.Size(26, 26);
            this.buttonSaveDialog.TabIndex = 2;
            this.buttonSaveDialog.Text = "...";
            this.buttonSaveDialog.UseVisualStyleBackColor = true;
            this.buttonSaveDialog.Click += new System.EventHandler(this.ButtonSaveDialog_Click);
            // 
            // customLabelPdfReportTitle
            // 
            this.customLabelPdfReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customLabelPdfReportTitle.AutoSize = true;
            this.customLabelPdfReportTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelPdfReportTitle.BorderHeightOffset = 2;
            this.customLabelPdfReportTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelPdfReportTitle.BorderWidthOffset = 2;
            this.customLabelPdfReportTitle.DrawBorder = false;
            this.customLabelPdfReportTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelPdfReportTitle.Location = new System.Drawing.Point(252, 19);
            this.customLabelPdfReportTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelPdfReportTitle.Name = "customLabelPdfReportTitle";
            this.customLabelPdfReportTitle.Size = new System.Drawing.Size(94, 12);
            this.customLabelPdfReportTitle.TabIndex = 79;
            this.customLabelPdfReportTitle.Text = "Pdf report creation";
            this.customLabelPdfReportTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(297, 15);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 28);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // PdfReportConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(390, 191);
            this.ControlBox = false;
            this.Controls.Add(this.panelPdfReportSave);
            this.Controls.Add(this.panelPdfReportButtons);
            this.Controls.Add(this.panelPdfReportMode);
            this.Controls.Add(this.panelPdfReportTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PdfReportConfigurationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASQA - Configure pdf Report";
            this.panelPdfReportMode.ResumeLayout(false);
            this.panelPdfReportMode.PerformLayout();
            this.panelPdfReportTitle.ResumeLayout(false);
            this.panelPdfReportTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePdfDocument)).EndInit();
            this.panelPdfReportSave.ResumeLayout(false);
            this.panelPdfReportSave.PerformLayout();
            this.panelPdfReportButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPdfReportMode;
        private System.Windows.Forms.Panel panelPdfReportTitle;
        private System.Windows.Forms.PictureBox picturePdfDocument;
        private Common.Windows.Forms.CustomLabelControl customLabelPdfReportTitle;
        private System.Windows.Forms.Panel panelPdfReportTitleBottom;
        private System.Windows.Forms.Panel panelPdfReportSave;
        private System.Windows.Forms.Panel panelPdfReportButtons;
        public System.Windows.Forms.CheckBox checkBoxExecuteAnalysis;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.CheckBox checkBoxSaveReport;
        public System.Windows.Forms.CheckBox checkBoxShowReport;
        private System.Windows.Forms.Panel panelPdfReportModeBottom;
        public System.Windows.Forms.SaveFileDialog savePdfReportDialog;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Button buttonSaveDialog;
        private System.Windows.Forms.Button buttonCancel;
    }
}