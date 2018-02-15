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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Server;
    using SSASQueryAnalyzer.Client.Common.Windows.Forms;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class AnalyzerExecutionResultHelper
    {
        public static Control BuildRawResultControl(AnalyzerStatistics analyzerStatistics)
        {
            if (analyzerStatistics == null)
                throw new ArgumentNullException("analyzerStatistics");

            var tab = new CustomTabControlControl();

            tab.SuspendLayout();
            tab.Dock = DockStyle.Fill;
            tab.SelectedIndex = 0;
            tab.TabIndex = 1;

            foreach (var executionResult in new [] { analyzerStatistics.ColdCacheExecutionResult, analyzerStatistics.WarmCacheExecutionResult })
            {
                #region common tab/page
                var enginePerformancePage = new TabPage(EnginePerformanceCollection.TableName);
                enginePerformancePage.Controls.Add(CustomDataGridViewControl.Create(executionResult.EnginePerformances));
                var aggregationsReadPage = new TabPage(AggregationsReadCollection.TableName);
                aggregationsReadPage.Controls.Add(CustomDataGridViewControl.Create(executionResult.AggregationsReads));
                var partitionsReadPage = new TabPage(PartitionsReadCollection.TableName);
                partitionsReadPage.Controls.Add(CustomDataGridViewControl.Create(executionResult.PartitionsReads));
                var cachesReadPage = new TabPage(CachesReadCollection.TableName);
                cachesReadPage.Controls.Add(CustomDataGridViewControl.Create(executionResult.CachesReads));
                var queryResultPage = new TabPage(QueryResult.TableName);
                queryResultPage.Controls.Add(CustomDataGridViewControl.Create(executionResult.QueryResults));
                var procedureEventPage = new TabPage(ProcedureEventCollection.TableName);
                procedureEventPage.Controls.Add(CustomDataGridViewControl.Create(executionResult.ProcedureEvents));

                var commonTab = new CustomTabControlControl() { Dock = DockStyle.Fill };
                commonTab.Controls.Add(enginePerformancePage);
                commonTab.Controls.Add(aggregationsReadPage);
                commonTab.Controls.Add(partitionsReadPage);
                commonTab.Controls.Add(cachesReadPage);
                commonTab.Controls.Add(queryResultPage);
                commonTab.Controls.Add(procedureEventPage);

                var commonPage = new TabPage("Common");
                commonPage.Controls.Add(commonTab);
                #endregion

                #region performance tab/page
                var performanceTab = new CustomTabControlControl() { Dock = DockStyle.Fill };
                foreach (var performance in executionResult.Performances)
                {
                    var page = new TabPage(performance.FullName);
                    page.Controls.Add(CustomDataGridViewControl.Create(performance));
                    performanceTab.Controls.Add(page);
                }

                var performancePage = new TabPage("Performance");
                performancePage.Controls.Add(performanceTab);
                #endregion

                #region profiler tab/page
                var profilerTab = new CustomTabControlControl() { Dock = DockStyle.Fill };
                foreach (var profiler in executionResult.Profilers)
                {
                    var page = new TabPage(profiler.EventClassName);
                    page.Controls.Add(CustomDataGridViewControl.Create(profiler));
                    profilerTab.Controls.Add(page);
                }

                var profilerPage = new TabPage("Profiler");
                profilerPage.Controls.Add(profilerTab);
                #endregion

                var rawResultTab = new CustomTabControlControl() { Dock = DockStyle.Fill };
                rawResultTab.Controls.Add(commonPage);
                rawResultTab.Controls.Add(performancePage);
                rawResultTab.Controls.Add(profilerPage);

                var rawResultPage = new TabPage((executionResult == analyzerStatistics.ColdCacheExecutionResult ? "Cold" : "Warm") + "Cache");
                rawResultPage.Controls.Add(rawResultTab);

                tab.Controls.Add(rawResultPage);
            }

            tab.ResumeLayout();

            return tab;
        }
    }
}
