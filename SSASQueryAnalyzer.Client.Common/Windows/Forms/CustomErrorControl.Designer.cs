using SSASQueryAnalyzer.Client.Common.Properties;

namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    partial class CustomErrorControl
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
            this.labelErrorMessage = new System.Windows.Forms.Label();
            this.labelErrorType = new System.Windows.Forms.Label();
            this.richTextBoxErrorDetails = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelError = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMaster = new System.Windows.Forms.TableLayoutPanel();
            this.panelErrorInternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelInternal = new System.Windows.Forms.TableLayoutPanel();
            this.panelErrorBand = new System.Windows.Forms.Panel();
            this.labelErrorFile = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonCopyAll = new System.Windows.Forms.Button();
            this.buttonShowDetails = new System.Windows.Forms.Button();
            this.panelMaster = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelError.SuspendLayout();
            this.tableLayoutPanelMaster.SuspendLayout();
            this.panelErrorInternal.SuspendLayout();
            this.tableLayoutPanelInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelErrorMessage
            // 
            this.labelErrorMessage.AllowDrop = true;
            this.labelErrorMessage.AutoSize = true;
            this.labelErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelErrorMessage.Location = new System.Drawing.Point(74, 30);
            this.labelErrorMessage.Margin = new System.Windows.Forms.Padding(0);
            this.labelErrorMessage.Name = "labelErrorMessage";
            this.labelErrorMessage.Size = new System.Drawing.Size(216, 80);
            this.labelErrorMessage.TabIndex = 1;
            this.labelErrorMessage.Text = "labelErrorMessage";
            this.labelErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelErrorType
            // 
            this.labelErrorType.AutoSize = true;
            this.labelErrorType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelErrorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorType.Location = new System.Drawing.Point(74, 0);
            this.labelErrorType.Margin = new System.Windows.Forms.Padding(0);
            this.labelErrorType.Name = "labelErrorType";
            this.labelErrorType.Size = new System.Drawing.Size(216, 30);
            this.labelErrorType.TabIndex = 0;
            this.labelErrorType.Text = "labelErrorType";
            this.labelErrorType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // richTextBoxErrorDetails
            // 
            this.richTextBoxErrorDetails.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxErrorDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxErrorDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxErrorDetails.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxErrorDetails.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxErrorDetails.Name = "richTextBoxErrorDetails";
            this.richTextBoxErrorDetails.ReadOnly = true;
            this.richTextBoxErrorDetails.Size = new System.Drawing.Size(854, 297);
            this.richTextBoxErrorDetails.TabIndex = 0;
            this.richTextBoxErrorDetails.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.panelError);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.panelDetails);
            this.splitContainer1.Size = new System.Drawing.Size(854, 597);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelError
            // 
            this.panelError.BackColor = System.Drawing.Color.White;
            this.panelError.Controls.Add(this.tableLayoutPanelMaster);
            this.panelError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelError.Location = new System.Drawing.Point(0, 0);
            this.panelError.Margin = new System.Windows.Forms.Padding(0);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(854, 295);
            this.panelError.TabIndex = 1;
            // 
            // tableLayoutPanelMaster
            // 
            this.tableLayoutPanelMaster.ColumnCount = 5;
            this.tableLayoutPanelMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanelMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelMaster.Controls.Add(this.panelErrorInternal, 2, 2);
            this.tableLayoutPanelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMaster.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMaster.Name = "tableLayoutPanelMaster";
            this.tableLayoutPanelMaster.RowCount = 7;
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelMaster.Size = new System.Drawing.Size(854, 295);
            this.tableLayoutPanelMaster.TabIndex = 3;
            // 
            // panelErrorInternal
            // 
            this.panelErrorInternal.BackColor = System.Drawing.Color.White;
            this.panelErrorInternal.Controls.Add(this.tableLayoutPanelInternal);
            this.panelErrorInternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelErrorInternal.Location = new System.Drawing.Point(277, 82);
            this.panelErrorInternal.Margin = new System.Windows.Forms.Padding(0);
            this.panelErrorInternal.Name = "panelErrorInternal";
            this.tableLayoutPanelMaster.SetRowSpan(this.panelErrorInternal, 3);
            this.panelErrorInternal.Size = new System.Drawing.Size(300, 130);
            this.panelErrorInternal.TabIndex = 8;
            // 
            // tableLayoutPanelInternal
            // 
            this.tableLayoutPanelInternal.ColumnCount = 7;
            this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelInternal.Controls.Add(this.labelErrorMessage, 5, 1);
            this.tableLayoutPanelInternal.Controls.Add(this.labelErrorType, 5, 0);
            this.tableLayoutPanelInternal.Controls.Add(this.panelErrorBand, 3, 0);
            this.tableLayoutPanelInternal.Controls.Add(this.labelErrorFile, 5, 2);
            this.tableLayoutPanelInternal.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanelInternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInternal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelInternal.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelInternal.Name = "tableLayoutPanelInternal";
            this.tableLayoutPanelInternal.RowCount = 3;
            this.tableLayoutPanelInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelInternal.Size = new System.Drawing.Size(300, 130);
            this.tableLayoutPanelInternal.TabIndex = 0;
            // 
            // panelErrorBand
            // 
            this.panelErrorBand.BackColor = global::SSASQueryAnalyzer.Client.Common.Properties.Settings.Default.WarmCacheColor;
            this.panelErrorBand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelErrorBand.Location = new System.Drawing.Point(60, 0);
            this.panelErrorBand.Margin = new System.Windows.Forms.Padding(0);
            this.panelErrorBand.Name = "panelErrorBand";
            this.tableLayoutPanelInternal.SetRowSpan(this.panelErrorBand, 3);
            this.panelErrorBand.Size = new System.Drawing.Size(4, 130);
            this.panelErrorBand.TabIndex = 3;
            // 
            // labelErrorFile
            // 
            this.labelErrorFile.AllowDrop = true;
            this.labelErrorFile.AutoSize = true;
            this.labelErrorFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelErrorFile.Location = new System.Drawing.Point(74, 110);
            this.labelErrorFile.Margin = new System.Windows.Forms.Padding(0);
            this.labelErrorFile.Name = "labelErrorFile";
            this.labelErrorFile.Size = new System.Drawing.Size(216, 20);
            this.labelErrorFile.TabIndex = 6;
            this.labelErrorFile.Text = "labelErrorFile";
            this.labelErrorFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelErrorFile.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(10, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanelInternal.SetRowSpan(this.pictureBox1, 3);
            this.pictureBox1.Size = new System.Drawing.Size(40, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.SystemColors.Control;
            this.panelDetails.Controls.Add(this.richTextBoxErrorDetails);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(854, 297);
            this.panelDetails.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.buttonCopyAll);
            this.panelBottom.Controls.Add(this.buttonShowDetails);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 597);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(854, 40);
            this.panelBottom.TabIndex = 110;
            // 
            // buttonCopyAll
            // 
            this.buttonCopyAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopyAll.Location = new System.Drawing.Point(671, 6);
            this.buttonCopyAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCopyAll.Name = "buttonCopyAll";
            this.buttonCopyAll.Size = new System.Drawing.Size(80, 28);
            this.buttonCopyAll.TabIndex = 109;
            this.buttonCopyAll.Text = "Copy all";
            this.buttonCopyAll.UseVisualStyleBackColor = true;
            this.buttonCopyAll.Visible = false;
            this.buttonCopyAll.Click += new System.EventHandler(this.OnButtonCopyAll_Click);
            // 
            // buttonShowDetails
            // 
            this.buttonShowDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowDetails.Location = new System.Drawing.Point(763, 6);
            this.buttonShowDetails.Margin = new System.Windows.Forms.Padding(0);
            this.buttonShowDetails.Name = "buttonShowDetails";
            this.buttonShowDetails.Size = new System.Drawing.Size(80, 28);
            this.buttonShowDetails.TabIndex = 108;
            this.buttonShowDetails.Text = "Show details";
            this.buttonShowDetails.UseVisualStyleBackColor = true;
            this.buttonShowDetails.Click += new System.EventHandler(this.OnButtonShowDetails_Click);
            // 
            // panelMaster
            // 
            this.panelMaster.BackColor = System.Drawing.Color.White;
            this.panelMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMaster.Controls.Add(this.splitContainer1);
            this.panelMaster.Controls.Add(this.panelBottom);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(856, 639);
            this.panelMaster.TabIndex = 1;
            // 
            // CustomErrorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelMaster);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomErrorControl";
            this.Size = new System.Drawing.Size(856, 639);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelError.ResumeLayout(false);
            this.tableLayoutPanelMaster.ResumeLayout(false);
            this.panelErrorInternal.ResumeLayout(false);
            this.tableLayoutPanelInternal.ResumeLayout(false);
            this.tableLayoutPanelInternal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelMaster.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxErrorDetails;
        private System.Windows.Forms.Label labelErrorType;
        private System.Windows.Forms.Label labelErrorMessage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMaster;
        private System.Windows.Forms.Panel panelErrorBand;
        private System.Windows.Forms.Label labelErrorFile;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonShowDetails;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Panel panelMaster;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Button buttonCopyAll;
        private System.Windows.Forms.Panel panelErrorInternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInternal;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
