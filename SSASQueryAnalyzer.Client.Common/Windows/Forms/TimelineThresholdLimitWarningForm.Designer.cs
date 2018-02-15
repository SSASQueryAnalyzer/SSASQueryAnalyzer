namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    partial class TimelineThresholdLimitWarningForm
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.LabelMessageSecondRow = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureInfo = new System.Windows.Forms.PictureBox();
            this.LabelMessageFirstRow = new System.Windows.Forms.Label();
            this.panelBatchMode = new System.Windows.Forms.Panel();
            this.pictureTraceEventsFilter = new System.Windows.Forms.PictureBox();
            this.panelBatchModeBottom = new System.Windows.Forms.Panel();
            this.customLabelTraceEventsTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInfo)).BeginInit();
            this.panelBatchMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTraceEventsFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonCancel);
            this.panel1.Controls.Add(this.LabelMessageSecondRow);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.pictureInfo);
            this.panel1.Controls.Add(this.LabelMessageFirstRow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 101);
            this.panel1.TabIndex = 1;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.Location = new System.Drawing.Point(164, 64);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(88, 28);
            this.ButtonCancel.TabIndex = 13;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Visible = false;
            // 
            // LabelMessageSecondRow
            // 
            this.LabelMessageSecondRow.AutoSize = true;
            this.LabelMessageSecondRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMessageSecondRow.Location = new System.Drawing.Point(49, 28);
            this.LabelMessageSecondRow.Margin = new System.Windows.Forms.Padding(0);
            this.LabelMessageSecondRow.MaximumSize = new System.Drawing.Size(300, 0);
            this.LabelMessageSecondRow.Name = "LabelMessageSecondRow";
            this.LabelMessageSecondRow.Size = new System.Drawing.Size(142, 15);
            this.LabelMessageSecondRow.TabIndex = 12;
            this.LabelMessageSecondRow.Text = "Still {0} objects selectable!";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(264, 64);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(94, 28);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // pictureInfo
            // 
            this.pictureInfo.Location = new System.Drawing.Point(8, 8);
            this.pictureInfo.Margin = new System.Windows.Forms.Padding(0);
            this.pictureInfo.Name = "pictureInfo";
            this.pictureInfo.Size = new System.Drawing.Size(34, 34);
            this.pictureInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureInfo.TabIndex = 7;
            this.pictureInfo.TabStop = false;
            // 
            // LabelMessageFirstRow
            // 
            this.LabelMessageFirstRow.AutoSize = true;
            this.LabelMessageFirstRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMessageFirstRow.Location = new System.Drawing.Point(49, 8);
            this.LabelMessageFirstRow.Margin = new System.Windows.Forms.Padding(0);
            this.LabelMessageFirstRow.MaximumSize = new System.Drawing.Size(280, 0);
            this.LabelMessageFirstRow.Name = "LabelMessageFirstRow";
            this.LabelMessageFirstRow.Size = new System.Drawing.Size(151, 15);
            this.LabelMessageFirstRow.TabIndex = 6;
            this.LabelMessageFirstRow.Text = "Too many objects selected.";
            // 
            // panelBatchMode
            // 
            this.panelBatchMode.BackColor = System.Drawing.Color.Transparent;
            this.panelBatchMode.Controls.Add(this.pictureTraceEventsFilter);
            this.panelBatchMode.Controls.Add(this.customLabelTraceEventsTitle);
            this.panelBatchMode.Controls.Add(this.panelBatchModeBottom);
            this.panelBatchMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBatchMode.Location = new System.Drawing.Point(0, 0);
            this.panelBatchMode.Name = "panelBatchMode";
            this.panelBatchMode.Size = new System.Drawing.Size(367, 48);
            this.panelBatchMode.TabIndex = 84;
            // 
            // pictureTraceEventsFilter
            // 
            this.pictureTraceEventsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureTraceEventsFilter.Image = global::SSASQueryAnalyzer.Client.Common.Properties.Resources.Timeline_Threshold_32x32;
            this.pictureTraceEventsFilter.Location = new System.Drawing.Point(326, 8);
            this.pictureTraceEventsFilter.Name = "pictureTraceEventsFilter";
            this.pictureTraceEventsFilter.Size = new System.Drawing.Size(34, 34);
            this.pictureTraceEventsFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureTraceEventsFilter.TabIndex = 78;
            this.pictureTraceEventsFilter.TabStop = false;
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
            // customLabelTraceEventsTitle
            // 
            this.customLabelTraceEventsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customLabelTraceEventsTitle.AutoSize = true;
            this.customLabelTraceEventsTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelTraceEventsTitle.BorderHeightOffset = 2;
            this.customLabelTraceEventsTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelTraceEventsTitle.BorderWidthOffset = 2;
            this.customLabelTraceEventsTitle.DrawBorder = false;
            this.customLabelTraceEventsTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelTraceEventsTitle.Location = new System.Drawing.Point(162, 19);
            this.customLabelTraceEventsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelTraceEventsTitle.Name = "customLabelTraceEventsTitle";
            this.customLabelTraceEventsTitle.Size = new System.Drawing.Size(163, 12);
            this.customLabelTraceEventsTitle.TabIndex = 79;
            this.customLabelTraceEventsTitle.Text = "Timeline events number threshold";
            this.customLabelTraceEventsTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TimelineThresholdLimitWarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(367, 149);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBatchMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TimelineThresholdLimitWarningForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASQA - Warning";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInfo)).EndInit();
            this.panelBatchMode.ResumeLayout(false);
            this.panelBatchMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTraceEventsFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBatchMode;
        private System.Windows.Forms.PictureBox pictureTraceEventsFilter;
        private Common.Windows.Forms.CustomLabelControl customLabelTraceEventsTitle;
        private System.Windows.Forms.Panel panelBatchModeBottom;
        private System.Windows.Forms.PictureBox pictureInfo;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.Label LabelMessageSecondRow;
        public System.Windows.Forms.Label LabelMessageFirstRow;
        public System.Windows.Forms.Button ButtonCancel;
    }
}