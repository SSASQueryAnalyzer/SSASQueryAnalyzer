//----------------------------------------------------------------------------
// MIT License
// 
// Copyright (c) 2017 SSASQueryAnalyzer
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//----------------------------------------------------------------------------

namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    public partial class ResultPresenterControl : UserControl
    {
        private AnalyzerStatistics _analyzerStatistics;

        #region Properties

        public ResultPresenterAnalyzerResultControl AnalyzerResultControl
        {
            get
            {
                return resultPresenterAnalyzerResultControl1;
            }
        }

        public AnalyzerStatistics AnalyzerStatistics
        {
            get
            {
                return _analyzerStatistics;
            }
        }

        #endregion

        public static ResultPresenterControl Create(AnalyzerStatistics analyzerStatistics)
        {
            return new ResultPresenterControl(analyzerStatistics, liveMode: true, batchMode: false, loadBatchMode: false);
        }

        public static ResultPresenterControl CreateForBatch(AnalyzerStatistics analyzerStatistics)
        {
            return new ResultPresenterControl(analyzerStatistics, liveMode: false, batchMode: true, loadBatchMode: false);
        }

        public static ResultPresenterControl CreateForLoadBatch(AnalyzerStatistics analyzerStatistics)
        {
            return new ResultPresenterControl(analyzerStatistics, liveMode: false, batchMode: false, loadBatchMode: true);
        }

        private ResultPresenterControl(AnalyzerStatistics analyzerStatistics, bool liveMode, bool batchMode, bool loadBatchMode)
        {
            #region Argument exception

            if (analyzerStatistics == null)
                throw new ArgumentNullException("analyzerStatistics");

            #endregion

            InitializeComponent();

            Debug.Assert(liveMode ^ (batchMode || loadBatchMode));

            _analyzerStatistics = analyzerStatistics;

            tabControlAnalyzerResult.TabPages.Remove(tabPageQueryResult);
            tabControlAnalyzerResult.TabPages.Remove(tabPageAnalysisResult);
            tabControlAnalyzerResult.TabPages.Remove(tabPageAnalysisInfo);
            tabControlAnalyzerResult.TabPages.Remove(tabPageAbout);

            if (tabControlAnalyzerResult.TabCount > 0)
                tabControlAnalyzerResult.SelectedIndex = 0;

            var renderingBegin = DateTime.UtcNow;

            if (liveMode)
            {
                #region Query Result tab

                if (analyzerStatistics.ColdCacheExecutionResult.QueryResults.Rows.Count > 0 || analyzerStatistics.WarmCacheExecutionResult.QueryResults.Rows.Count > 0)
                {
                    resultPresenterQueryResultControl1.UpdateStatistics(_analyzerStatistics);
                    tabControlAnalyzerResult.TabPages.Add(tabPageQueryResult);
                    tabPageQueryResult.Visible = true;
                }

                #endregion
            }

            if (liveMode || loadBatchMode)
            {
                #region Analyzer Result tab
                resultPresenterAnalyzerResultControl1.UpdateStatistics(_analyzerStatistics);
                tabControlAnalyzerResult.TabPages.Add(tabPageAnalysisResult);
                tabPageAnalysisResult.Visible = true;
                #endregion
            }

            #region Analysis Info tab
            resultPresenterExecutionInfoControl1.UpdateStatistics(_analyzerStatistics, liveMode, batchMode, loadBatchMode, renderingBegin);
            if (tabControlAnalyzerResult.TabCount > 0)
                tabControlAnalyzerResult.TabPages.Insert(0, tabPageAnalysisInfo);
            else
                tabControlAnalyzerResult.TabPages.Add(tabPageAnalysisInfo);
            tabControlAnalyzerResult.SelectedIndex = 0;
            tabPageAnalysisInfo.Visible = true;
            #endregion

            #region About tab
            tabControlAnalyzerResult.TabPages.Add(tabPageAbout);
            tabPageAbout.Visible = true;
            #endregion

            Dock = DockStyle.Fill;
        }

        public void SelectTabPageIndex(int index)
        {
            tabControlAnalyzerResult.SelectedIndex = index;
        }
    }
}
