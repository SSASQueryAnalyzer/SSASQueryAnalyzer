namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;

    partial class ResultPresenterQueryResultControl
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControlQueryResults = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomTabControlControl();
            this.tabPageColdCache = new System.Windows.Forms.TabPage();
            this.dataGridViewColdCache = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomDataGridViewControl();
            this.tabPageWarmCache = new System.Windows.Forms.TabPage();
            this.dataGridViewWarmCache = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomDataGridViewControl();
            this.panelMessages = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageExternal = new System.Windows.Forms.TableLayoutPanel();
            this.panelMessageInternal = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMessageInternal = new System.Windows.Forms.TableLayoutPanel();
            this.customLabelMessage = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelMessageBand = new System.Windows.Forms.Panel();
            this.pictureBoxMessage = new System.Windows.Forms.PictureBox();
            this.panelMain.SuspendLayout();
            this.tabControlQueryResults.SuspendLayout();
            this.tabPageColdCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColdCache)).BeginInit();
            this.tabPageWarmCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarmCache)).BeginInit();
            this.panelMessages.SuspendLayout();
            this.tableLayoutPanelMessageExternal.SuspendLayout();
            this.panelMessageInternal.SuspendLayout();
            this.tableLayoutPanelMessageInternal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControlQueryResults);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(843, 535);
            this.panelMain.TabIndex = 1;
            // 
            // tabControlQueryResults
            // 
            this.tabControlQueryResults.Controls.Add(this.tabPageColdCache);
            this.tabControlQueryResults.Controls.Add(this.tabPageWarmCache);
            this.tabControlQueryResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlQueryResults.Location = new System.Drawing.Point(0, 0);
            this.tabControlQueryResults.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlQueryResults.Name = "tabControlQueryResults";
            this.tabControlQueryResults.SelectedIndex = 0;
            this.tabControlQueryResults.Size = new System.Drawing.Size(843, 535);
            this.tabControlQueryResults.TabIndex = 1;
            // 
            // tabPageColdCache
            // 
            this.tabPageColdCache.Controls.Add(this.dataGridViewColdCache);
            this.tabPageColdCache.Location = new System.Drawing.Point(4, 22);
            this.tabPageColdCache.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageColdCache.Name = "tabPageColdCache";
            this.tabPageColdCache.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageColdCache.Size = new System.Drawing.Size(835, 509);
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
            this.dataGridViewColdCache.ColumnHeadersVisible = false;
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
            this.dataGridViewColdCache.RowHeadersVisible = false;
            this.dataGridViewColdCache.RowTemplate.ReadOnly = true;
            this.dataGridViewColdCache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewColdCache.Size = new System.Drawing.Size(827, 501);
            this.dataGridViewColdCache.TabIndex = 0;
            // 
            // tabPageWarmCache
            // 
            this.tabPageWarmCache.Controls.Add(this.dataGridViewWarmCache);
            this.tabPageWarmCache.Location = new System.Drawing.Point(4, 22);
            this.tabPageWarmCache.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageWarmCache.Name = "tabPageWarmCache";
            this.tabPageWarmCache.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageWarmCache.Size = new System.Drawing.Size(835, 509);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWarmCache.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewWarmCache.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWarmCache.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWarmCache.GridColor = System.Drawing.Color.Black;
            this.dataGridViewWarmCache.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewWarmCache.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewWarmCache.Name = "dataGridViewWarmCache";
            this.dataGridViewWarmCache.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewWarmCache.RowHeadersVisible = false;
            this.dataGridViewWarmCache.RowTemplate.ReadOnly = true;
            this.dataGridViewWarmCache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewWarmCache.Size = new System.Drawing.Size(827, 501);
            this.dataGridViewWarmCache.TabIndex = 0;
            // 
            // panelMessages
            // 
            this.panelMessages.Controls.Add(this.tableLayoutPanelMessageExternal);
            this.panelMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMessages.Location = new System.Drawing.Point(0, 535);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.Size = new System.Drawing.Size(843, 26);
            this.panelMessages.TabIndex = 1;
            this.panelMessages.Visible = false;
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
            this.tableLayoutPanelMessageExternal.Size = new System.Drawing.Size(843, 26);
            this.tableLayoutPanelMessageExternal.TabIndex = 2;
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
            this.panelMessageInternal.Size = new System.Drawing.Size(843, 24);
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
            this.tableLayoutPanelMessageInternal.Size = new System.Drawing.Size(841, 22);
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
            this.customLabelMessage.Size = new System.Drawing.Size(811, 18);
            this.customLabelMessage.TabIndex = 28;
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
            // ResultPresenterQueryResultControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMessages);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultPresenterQueryResultControl";
            this.Size = new System.Drawing.Size(843, 561);
            this.panelMain.ResumeLayout(false);
            this.tabControlQueryResults.ResumeLayout(false);
            this.tabPageColdCache.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColdCache)).EndInit();
            this.tabPageWarmCache.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarmCache)).EndInit();
            this.panelMessages.ResumeLayout(false);
            this.tableLayoutPanelMessageExternal.ResumeLayout(false);
            this.panelMessageInternal.ResumeLayout(false);
            this.tableLayoutPanelMessageInternal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTabControlControl tabControlQueryResults;
        private System.Windows.Forms.TabPage tabPageColdCache;
        private CustomDataGridViewControl dataGridViewColdCache;
        private System.Windows.Forms.TabPage tabPageWarmCache;
        private CustomDataGridViewControl dataGridViewWarmCache;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMessages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageExternal;
        private System.Windows.Forms.Panel panelMessageInternal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMessageInternal;
        private CustomLabelControl customLabelMessage;
        private System.Windows.Forms.Panel panelMessageBand;
        private System.Windows.Forms.PictureBox pictureBoxMessage;
    }
}
