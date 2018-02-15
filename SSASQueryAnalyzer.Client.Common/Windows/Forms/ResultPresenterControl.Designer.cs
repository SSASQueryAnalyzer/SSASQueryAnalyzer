namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    partial class ResultPresenterControl
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
            if (disposing)
            {
                if (components != null) 
                    components.Dispose();

                if (_analyzerStatistics != null)
                    _analyzerStatistics.Dispose();
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
            this.tabControlAnalyzerResult = new System.Windows.Forms.TabControl();
            this.tabPageAnalysisInfo = new System.Windows.Forms.TabPage();
            this.resultPresenterExecutionInfoControl1 = new SSASQueryAnalyzer.Client.Common.Windows.Forms.ResultPresenterExecutionInfoControl();
            this.tabPageQueryResult = new System.Windows.Forms.TabPage();
            this.resultPresenterQueryResultControl1 = new SSASQueryAnalyzer.Client.Common.Windows.Forms.ResultPresenterQueryResultControl();
            this.tabPageAnalysisResult = new System.Windows.Forms.TabPage();
            this.resultPresenterAnalyzerResultControl1 = new SSASQueryAnalyzer.Client.Common.Windows.Forms.ResultPresenterAnalyzerResultControl();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.resultPresenterAboutControl1 = new SSASQueryAnalyzer.Client.Common.Windows.Forms.ResultPresenterAboutControl();
            this.tabControlAnalyzerResult.SuspendLayout();
            this.tabPageAnalysisInfo.SuspendLayout();
            this.tabPageQueryResult.SuspendLayout();
            this.tabPageAnalysisResult.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAnalyzerResult
            // 
            this.tabControlAnalyzerResult.Controls.Add(this.tabPageAnalysisInfo);
            this.tabControlAnalyzerResult.Controls.Add(this.tabPageQueryResult);
            this.tabControlAnalyzerResult.Controls.Add(this.tabPageAnalysisResult);
            this.tabControlAnalyzerResult.Controls.Add(this.tabPageAbout);
            this.tabControlAnalyzerResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAnalyzerResult.Location = new System.Drawing.Point(0, 0);
            this.tabControlAnalyzerResult.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlAnalyzerResult.Name = "tabControlAnalyzerResult";
            this.tabControlAnalyzerResult.SelectedIndex = 0;
            this.tabControlAnalyzerResult.Size = new System.Drawing.Size(1153, 603);
            this.tabControlAnalyzerResult.TabIndex = 0;
            // 
            // tabPageAnalysisInfo
            // 
            this.tabPageAnalysisInfo.Controls.Add(this.resultPresenterExecutionInfoControl1);
            this.tabPageAnalysisInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalysisInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAnalysisInfo.Name = "tabPageAnalysisInfo";
            this.tabPageAnalysisInfo.Size = new System.Drawing.Size(1145, 577);
            this.tabPageAnalysisInfo.TabIndex = 6;
            this.tabPageAnalysisInfo.Text = "Analysis Info";
            this.tabPageAnalysisInfo.UseVisualStyleBackColor = true;
            // 
            // resultPresenterExecutionInfoControl1
            // 
            this.resultPresenterExecutionInfoControl1.BackColor = System.Drawing.Color.White;
            this.resultPresenterExecutionInfoControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPresenterExecutionInfoControl1.Location = new System.Drawing.Point(0, 0);
            this.resultPresenterExecutionInfoControl1.Margin = new System.Windows.Forms.Padding(5);
            this.resultPresenterExecutionInfoControl1.Name = "resultPresenterExecutionInfoControl1";
            this.resultPresenterExecutionInfoControl1.Size = new System.Drawing.Size(1145, 577);
            this.resultPresenterExecutionInfoControl1.TabIndex = 0;
            // 
            // tabPageQueryResult
            // 
            this.tabPageQueryResult.Controls.Add(this.resultPresenterQueryResultControl1);
            this.tabPageQueryResult.Location = new System.Drawing.Point(4, 22);
            this.tabPageQueryResult.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageQueryResult.Name = "tabPageQueryResult";
            this.tabPageQueryResult.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageQueryResult.Size = new System.Drawing.Size(192, 74);
            this.tabPageQueryResult.TabIndex = 0;
            this.tabPageQueryResult.Text = "Query Results";
            this.tabPageQueryResult.UseVisualStyleBackColor = true;
            // 
            // resultPresenterQueryResultControl1
            // 
            this.resultPresenterQueryResultControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPresenterQueryResultControl1.Location = new System.Drawing.Point(4, 4);
            this.resultPresenterQueryResultControl1.Margin = new System.Windows.Forms.Padding(5);
            this.resultPresenterQueryResultControl1.Name = "resultPresenterQueryResultControl1";
            this.resultPresenterQueryResultControl1.Size = new System.Drawing.Size(184, 66);
            this.resultPresenterQueryResultControl1.TabIndex = 0;
            // 
            // tabPageAnalysisResult
            // 
            this.tabPageAnalysisResult.Controls.Add(this.resultPresenterAnalyzerResultControl1);
            this.tabPageAnalysisResult.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalysisResult.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAnalysisResult.Name = "tabPageAnalysisResult";
            this.tabPageAnalysisResult.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAnalysisResult.Size = new System.Drawing.Size(1145, 577);
            this.tabPageAnalysisResult.TabIndex = 1;
            this.tabPageAnalysisResult.Text = "Analysis Results";
            this.tabPageAnalysisResult.UseVisualStyleBackColor = true;
            // 
            // resultPresenterAnalyzerResultControl1
            // 
            this.resultPresenterAnalyzerResultControl1.BackColor = System.Drawing.SystemColors.Control;
            this.resultPresenterAnalyzerResultControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPresenterAnalyzerResultControl1.Location = new System.Drawing.Point(4, 4);
            this.resultPresenterAnalyzerResultControl1.Margin = new System.Windows.Forms.Padding(5);
            this.resultPresenterAnalyzerResultControl1.Name = "resultPresenterAnalyzerResultControl1";
            this.resultPresenterAnalyzerResultControl1.Size = new System.Drawing.Size(1137, 569);
            this.resultPresenterAnalyzerResultControl1.TabIndex = 0;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.resultPresenterAboutControl1);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAbout.Size = new System.Drawing.Size(192, 74);
            this.tabPageAbout.TabIndex = 5;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // resultPresenterAboutControl1
            // 
            this.resultPresenterAboutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPresenterAboutControl1.Location = new System.Drawing.Point(3, 2);
            this.resultPresenterAboutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultPresenterAboutControl1.Name = "resultPresenterAboutControl1";
            this.resultPresenterAboutControl1.Size = new System.Drawing.Size(186, 70);
            this.resultPresenterAboutControl1.TabIndex = 0;
            // 
            // ResultPresenterControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tabControlAnalyzerResult);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultPresenterControl";
            this.Size = new System.Drawing.Size(1153, 603);
            this.tabControlAnalyzerResult.ResumeLayout(false);
            this.tabPageAnalysisInfo.ResumeLayout(false);
            this.tabPageQueryResult.ResumeLayout(false);
            this.tabPageAnalysisResult.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.TabControl tabControlAnalyzerResult;
        private System.Windows.Forms.TabPage tabPageQueryResult;
        private System.Windows.Forms.TabPage tabPageAnalysisResult;
        public ResultPresenterAnalyzerResultControl resultPresenterAnalyzerResultControl1;
        private ResultPresenterQueryResultControl resultPresenterQueryResultControl1;
        private System.Windows.Forms.TabPage tabPageAbout;
        private ResultPresenterAboutControl resultPresenterAboutControl1;
        private System.Windows.Forms.TabPage tabPageAnalysisInfo;
        public ResultPresenterExecutionInfoControl resultPresenterExecutionInfoControl1;
    }
}
