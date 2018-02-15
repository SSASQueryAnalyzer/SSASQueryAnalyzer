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
    using SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Server.Profiler;
    using SSASQueryAnalyzer.Client.Common.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Server.Performance;

    public partial class ResultPresenterTraceEventsControl : UserControl
    {
        private AnalyzerStatistics _analyzerStatistics;
        private DataPoint _selectedDataPoint;

        private object _warmSelectedClass;
        private object _coldSelectedClass;
        private object _warmSelectedSubclass;
        private object _coldSelectedSubclass;
        private int _coldTotalEventsCounter;
        private int _warmTotalEventsCounter;

        private const string ParameterDefaultValue = "<ALL>";

        private int CurrentTotalEventsCounter
        {
            get
            {
                if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                    return _coldTotalEventsCounter;
                else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                    return _warmTotalEventsCounter;

                throw new ApplicationException("Invalid counter for CurrentTotalEventsCounter");
            }
        }

        private AnalyzerExecutionResult CurrentExecutionResult
        {
            get
            {
                if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                    return _analyzerStatistics.ColdCacheExecutionResult;
                else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                    return _analyzerStatistics.WarmCacheExecutionResult;

                throw new ApplicationException("Invalid type for CurrentExecutionResult");
            }
        }

        private CustomDataGridViewControl CurrentDataGridView
        {
            get
            {
                if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                    return dataGridViewColdCache;
                else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                    return dataGridViewWarmCache;

                throw new ApplicationException("Invalid type for CurrentDataGridView");
            }
        }

        private object CurrentSelectedClass
        {
            get
            {
                if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                    return _coldSelectedClass;
                else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                    return _warmSelectedClass;

                throw new ApplicationException("Invalid type for get CurrentSelectedClass");
            }
            set
            {
                if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                    _coldSelectedClass = value;
                else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                    _warmSelectedClass = value;
                else
                    throw new ApplicationException("Invalid type for set CurrentSelectedClass");
            }
        }

        private object CurrentSelectedSubclass
        {
            get
            {
                if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                    return _coldSelectedSubclass;
                else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                    return _warmSelectedSubclass;

                throw new ApplicationException("Invalid type for get CurrentSelectedSubclass");
            }
            set
            {
                if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                    _coldSelectedSubclass = value;
                else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                    _warmSelectedSubclass = value;
                else
                    throw new ApplicationException("Invalid type for set CurrentSelectedSubclass");
            }
        }

        private PerformanceItemCollectionList CurrentSelectedPerformances
        {
            get
            {
                if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                    return _analyzerStatistics.ColdCacheExecutionResult.Performances;
                else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                    return _analyzerStatistics.WarmCacheExecutionResult.Performances;

                throw new ApplicationException("Invalid type for CurrentPerformanceItems");
            }
        }

        public CustomDataGridViewControl GetCurrentDataGridView()
        {
            return CurrentDataGridView;
        }

        public ResultPresenterTraceEventsControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            #region ColdCache Datagrid

            System.Windows.Forms.DataGridViewCellStyle ColumnHeadersCellStyleColdCache = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle CellStyleColdCache = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle RowHeadersCellStyleColdCache = new System.Windows.Forms.DataGridViewCellStyle();

            #region Column Headers template

            ColumnHeadersCellStyleColdCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersCellStyleColdCache.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ColumnHeadersCellStyleColdCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ColumnHeadersCellStyleColdCache.BackColor = Properties.Settings.Default.ColdCacheColor;
            ColumnHeadersCellStyleColdCache.ForeColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersCellStyleColdCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersCellStyleColdCache.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region Row Headers template

            RowHeadersCellStyleColdCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            RowHeadersCellStyleColdCache.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            RowHeadersCellStyleColdCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RowHeadersCellStyleColdCache.BackColor = Properties.Settings.Default.ColdCacheColor;
            RowHeadersCellStyleColdCache.ForeColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersCellStyleColdCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersCellStyleColdCache.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region Cells template

            CellStyleColdCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            CellStyleColdCache.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            CellStyleColdCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CellStyleColdCache.BackColor = System.Drawing.SystemColors.Window;
            CellStyleColdCache.ForeColor = System.Drawing.Color.Black;
            CellStyleColdCache.SelectionBackColor = Properties.Settings.Default.HighlightColor;
            CellStyleColdCache.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region Data Grid View settings

            this.dataGridViewColdCache.ColumnHeadersDefaultCellStyle = ColumnHeadersCellStyleColdCache;
            this.dataGridViewColdCache.DefaultCellStyle = CellStyleColdCache;
            this.dataGridViewColdCache.RowHeadersDefaultCellStyle = RowHeadersCellStyleColdCache;

            this.dataGridViewColdCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewColdCache.GridColor = System.Drawing.Color.Black;
            this.dataGridViewColdCache.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewColdCache.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewColdCache.Name = "dataGridViewColdCache";
            this.dataGridViewColdCache.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewColdCache.RowHeadersVisible = false;
            this.dataGridViewColdCache.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewColdCache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            #endregion

            #endregion

            #region WarmCache Datagrid

            System.Windows.Forms.DataGridViewCellStyle ColumnHeadersCellStyleWarmCache = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle CellStyleWarmCache = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle RowHeadersCellStyleWarmCache = new System.Windows.Forms.DataGridViewCellStyle();

            #region Column Headers template

            ColumnHeadersCellStyleWarmCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersCellStyleWarmCache.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            ColumnHeadersCellStyleWarmCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ColumnHeadersCellStyleWarmCache.BackColor = Properties.Settings.Default.WarmCacheColor;
            ColumnHeadersCellStyleWarmCache.ForeColor = System.Drawing.Color.Black;
            ColumnHeadersCellStyleWarmCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadersCellStyleWarmCache.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region Row Headers template

            RowHeadersCellStyleWarmCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            RowHeadersCellStyleWarmCache.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            RowHeadersCellStyleWarmCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RowHeadersCellStyleWarmCache.BackColor = Properties.Settings.Default.WarmCacheColor;
            RowHeadersCellStyleWarmCache.ForeColor = System.Drawing.Color.Black;
            RowHeadersCellStyleWarmCache.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            RowHeadersCellStyleWarmCache.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region Cells template

            CellStyleWarmCache.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            CellStyleWarmCache.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            CellStyleWarmCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CellStyleWarmCache.BackColor = System.Drawing.SystemColors.Window;
            CellStyleWarmCache.ForeColor = System.Drawing.Color.Black;
            CellStyleWarmCache.SelectionBackColor = Properties.Settings.Default.HighlightColor;
            CellStyleWarmCache.SelectionForeColor = System.Drawing.Color.White;

            #endregion

            #region Data Grid View settings

            this.dataGridViewWarmCache.ColumnHeadersDefaultCellStyle = ColumnHeadersCellStyleWarmCache;
            this.dataGridViewWarmCache.DefaultCellStyle = CellStyleWarmCache;
            this.dataGridViewWarmCache.RowHeadersDefaultCellStyle = RowHeadersCellStyleWarmCache;

            this.dataGridViewWarmCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWarmCache.GridColor = System.Drawing.Color.Black;
            this.dataGridViewWarmCache.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewWarmCache.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewWarmCache.Name = "dataGridViewWarmCache";
            this.dataGridViewWarmCache.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewWarmCache.RowHeadersVisible = false;
            this.dataGridViewWarmCache.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWarmCache.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            #endregion

            #endregion

            panelTop.Height = panelEventsTitle.Height;
        }

        public void UpdateStatistics(AnalyzerStatistics analyzerStatistics)
        {
            _analyzerStatistics = analyzerStatistics;

            _coldTotalEventsCounter = _analyzerStatistics.ColdCacheExecutionResult.Profilers
                .SelectMany((p) => p.ToList())
                .Count();

            _warmTotalEventsCounter = _analyzerStatistics.WarmCacheExecutionResult.Profilers
                .SelectMany((p) => p.ToList())
                .Count();

            dataGridViewColdCache.DataSource = _analyzerStatistics.ColdCacheExecutionResult.Profilers
                .SelectMany((p) => p.ToList())
                .OrderBy((p) => p.ID)
                .ToSortableBindingList();
            dataGridViewColdCache.HideEmptyColumns();

            dataGridViewWarmCache.DataSource = _analyzerStatistics.WarmCacheExecutionResult.Profilers
                .SelectMany((p) => p.ToList())
                .OrderBy((p) => p.ID)
                .ToSortableBindingList();
            dataGridViewWarmCache.HideEmptyColumns();

            RefreshClassFilter();
            RefreshSubclassFilter();
            InitializeContextMenuStrips();

            pictureBoxMessage.Image = SystemIcons.Information.ToBitmap();
        }

        #region Others

        private void RefreshClassFilter(object selectedItem = null)
        {
            var query = CurrentExecutionResult.Profilers.EventClasses
                .Select((e) => e.ToName());

            comboBoxClass.Items.Clear();
            comboBoxClass.Items.AddRange(query.ToArray());
            comboBoxClass.Items.Insert(0, ParameterDefaultValue);
            comboBoxClass.SelectedIndex = 0;

            if (selectedItem != null)
                comboBoxClass.SelectedItem = selectedItem;
        }

        private void RefreshSubclassFilter(object selectedItem = null)
        {
            var query = CurrentExecutionResult.Profilers
                .SelectMany((p) => p)
                .Where((i) => i.EventSubclass.HasValue);

            if (comboBoxClass.Text != ParameterDefaultValue)
                query = query.Where((e) => e.EventClass.Value.ToName() == comboBoxClass.Text);

            var subclasses = query
                .Select((e) => e.EventSubclass.Value.ToName())
                .Distinct();

            comboBoxSubclass.Items.Clear();
            comboBoxSubclass.Items.AddRange(subclasses.ToArray());
            comboBoxSubclass.Items.Insert(0, ParameterDefaultValue);
            comboBoxSubclass.SelectedIndex = 0;

            if (selectedItem != null)
                comboBoxSubclass.SelectedItem = selectedItem;
        }

        private void CheckBoxFilterControlsCheckedChanged(object sender, EventArgs e)
        {
            panelTop.Height = panelEventsTitle.Height;

            if (!checkBoxFilterControls.Checked)
                panelTop.Height += panelEventsFilters.Height;

            panelEventsFilters.Visible = !checkBoxFilterControls.Checked;
        }

        private void ComboBoxTraceEventFiltersSelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSelectedClass = comboBoxClass.SelectedItem;
            CurrentSelectedSubclass = comboBoxSubclass.SelectedItem;

            var currentComboBox = sender as ComboBox;
            if (currentComboBox == comboBoxClass)
                RefreshSubclassFilter();

            var query = CurrentExecutionResult.Profilers
                .SelectMany((p) => p.ToList());

            if (comboBoxClass.Text != ParameterDefaultValue)
                query = query.Where((p) => p.EventClass.Value == comboBoxClass.Text.ToEventClass());

            if (comboBoxSubclass.Text != ParameterDefaultValue)
                query = query.Where((p) => p.EventSubclass.HasValue && p.EventSubclass.Value == comboBoxSubclass.Text.ToEventSubclass());

            query = query.OrderBy((p) => p.ID)
                .ToSortableBindingList();

            CurrentDataGridView.DataSource = null;
            CurrentDataGridView.DataSource = query;
            CurrentDataGridView.HideEmptyColumns();

            UpdateLabelMessage();
        }

        private void TabControlTraceEventsSelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshClassFilter(CurrentSelectedClass);
            RefreshSubclassFilter(CurrentSelectedSubclass);
            UpdateDetails();
        }

        public void SelectTabPageIndex(int index)
        {
            tabControlTraceEvents.SelectedIndex = index;
        }

        private void UpdateLabelMessage()
        {
            // HACK : https://danielsaidi.wordpress.com/2009/03/23/datagridview-selectionchanged-event-behaves-strange/
            int showedEventsCount = CurrentTotalEventsCounter;
            if (DataGridViewIsCurrentFiltered())
                showedEventsCount = CurrentDataGridView.RowCount;
            int filteredEventsCount = CurrentTotalEventsCounter - showedEventsCount;
            if (CurrentDataGridView.SelectedRows.Count > 0)
            {
                if(checkBoxShowPerformanceCounters.Checked)
                {
                    customLabelControlDetailsTitle.Text = "Performance Counters related to row [{0}]:".FormatWith(CurrentDataGridView.SelectedRows[0].Cells["ID"].Value);
                    customLabelMessage.Text = "Values (Y axes) are logarithmic.";
                }
                else
                {
                    customLabelControlDetailsTitle.Text = "[TextData] field content of row [{0}]:".FormatWith(CurrentDataGridView.SelectedRows[0].Cells["ID"].Value);
                    customLabelMessage.Text = "Total events: {0} - Showed events: {1} - Filtered events: {2} - Selected events: {3}".FormatWith(CurrentTotalEventsCounter, showedEventsCount, filteredEventsCount, CurrentDataGridView.SelectedRows.Count);
                }
            }
        }

        private void UpdateDetails()
        {
            if (CurrentDataGridView.SelectedRows.Count > 0)
            {
                if  (checkBoxShowPerformanceCounters.Checked) 
                {
                    ShowRelatedPerformanceCounters();
                    panelPerformanceCounters.Visible = true;
                    panelTextData.Visible = false;
                }
                else
                {
                    richTextBoxTextData.Text = Convert.ToString(CurrentDataGridView.SelectedRows[0].Cells["TextData"].Value);
                    panelTextData.Visible = true;
                    panelPerformanceCounters.Visible = false;
                }

                UpdateLabelMessage();
            }
        }

        private void CheckBoxShowPerformanceCountersCheckedChanged(object sender, EventArgs e)
        {
            UpdateDetails();
        }

        #endregion

        #region Context menu

        private void InitializeContextMenuStrips()
        {
            Debug.Assert(dataGridViewColdCache.ContextMenuStrip == null);
            Debug.Assert(dataGridViewWarmCache.ContextMenuStrip == null);
            Debug.Assert(richTextBoxTextData.ContextMenuStrip == null);

            var dataGridViewContextMenu = new ContextMenuStrip();
            dataGridViewContextMenu.Items.Add(new ToolStripMenuItem("Show on Timeline", null, (s, e) => ShowSelectedTraceEventsInTimeline()));

            dataGridViewColdCache.ContextMenuStrip = dataGridViewContextMenu;
            dataGridViewWarmCache.ContextMenuStrip = dataGridViewContextMenu;

            var richTextBoxTextDataContextMenu = new ContextMenuStrip();
            richTextBoxTextDataContextMenu.Items.Add(new ToolStripMenuItem("Copy", null, (s, e) => RichTextBoxTextDataCopy()));
            richTextBoxTextData.ContextMenuStrip = richTextBoxTextDataContextMenu;

            var chartPerformanceCountersContextMenu = new ContextMenuStrip();
            chartPerformanceCountersContextMenu.Items.Add(new ToolStripMenuItem("Set as Performance Counter on Timeline", null, (s, e) => ShowSelectedPerformanceCounterInTimeline()));
            chartPerformanceCounters.ContextMenuStrip = chartPerformanceCountersContextMenu;
        }

        private void ShowSelectedTraceEventsInTimeline()
        {
            var selectedEvents = new List<ProfilerItem>();

            //int minRow = CurrentDataGridView.RowCount;
            int minRow = (int)CurrentDataGridView.Rows[CurrentDataGridView.RowCount -1].Cells["ID"].Value;
            int maxRow = 0;

            var dataSource = (BindingList<ProfilerItem>)CurrentDataGridView.DataSource;

            for (int counter = 0; counter < (CurrentDataGridView.SelectedRows.Count); counter++)
            {
                int rowIndex = (int)CurrentDataGridView.SelectedRows[counter].Cells["ID"].Value;

                //int rowIndex = CurrentDataGridView.SelectedRows[counter].Index + 1;
                if (rowIndex > maxRow) maxRow = rowIndex;
                if (rowIndex < minRow) minRow = rowIndex;

                var currentSelectedEvent = dataSource.Where((i) => i.ID == rowIndex).SingleOrDefault();
                if (currentSelectedEvent != null)
                {
                    if ((currentSelectedEvent.EventClass.Value.ToString() != TraceEventClass.QueryBegin.ToName()) ||
                         (currentSelectedEvent.EventClass.Value.ToString() != TraceEventClass.QueryEnd.ToName()) ||
                         (currentSelectedEvent.EventClass.Value.ToString() != TraceEventClass.ResourceUsage.ToName()))
                    {
                        selectedEvents.Add(currentSelectedEvent);
                    }
                }
            }

            var minValue = dataSource.Where((i) => i.ID == minRow)
                .Select((i) => i.CurrentTime.Value)
                .FirstOrDefault();
            var maxValue = dataSource.Where((i) => i.ID == maxRow)
                .Select((i) => i.CurrentTime.Value)
                .FirstOrDefault();
            if (minValue == null || maxValue == null)
                return;

            var resultPresenterControl = this.GetResultPresenterControl();

            var timelineControl = resultPresenterControl.AnalyzerResultControl.TimelineControl;
            ResultPresenterAnalyzerResultTimelineControl.TimelineHelper timelineHelper = null;
            Chart timelineChart = null;

            if (CurrentDataGridView == dataGridViewColdCache)
            {
                timelineChart = timelineControl.chartCold;
                timelineHelper = timelineControl.ColdTimelineHelper;
            }
            else if (CurrentDataGridView == dataGridViewWarmCache)
            {
                timelineChart = timelineControl.chartWarm;
                timelineHelper = timelineControl.WarmTimelineHelper;
            }

            var selectedEventClasses = selectedEvents
                .Where((e) => e.EventClass.HasValue)
                .GroupBy((e) => e.EventClass)
                .Select((g) => new
                {
                    ItemName = g.Min((p) => p.EventClass.ToString()),
                    OccurrencesCount = g.Count()
                })
                .ToList();

            if (timelineChart != null)
            {
                if (timelineHelper.ZoomMode)
                {
                    ResetTimelineZoomConfirmationForm resetTimelineZoomConfirmationForm = new ResetTimelineZoomConfirmationForm();
                    if (resetTimelineZoomConfirmationForm.ShowDialog() == DialogResult.No)
                        return;
                    timelineHelper.ResetZoomMode();
                }

                // Clear all Profiler menu sub items
                timelineHelper.ContextMenuItemPerformClick(timelineHelper._uncheckAllProfilers, true);

                // Set Filtered Profiler Events in CacheHelper
                timelineHelper.FilteredProfilerEvents = selectedEvents;

                // Click on Profiler menu sub items corrisponding to the selected Event Classes
                foreach (var eventCount in selectedEventClasses)
                {
                    foreach (var subItem in timelineHelper._profilerMenuItem.DropDownItems)
                    {
                        if ((subItem is ToolStripMenuItem) &&
                             (((ToolStripMenuItem)subItem).Name == eventCount.ItemName) &&
                             (!((ToolStripMenuItem)subItem).Checked))
                        {
                            ((ToolStripMenuItem)subItem).PerformClick();
                        }
                    }
                }

                if (maxValue.Subtract(minValue).TotalMilliseconds >= 1)
                {
                    // Select the chart area corrisponding to the selected rows
                    timelineChart.ChartAreas[0].CursorX.SelectionStart = ((DateTime)minValue).ToOADate();
                    timelineChart.ChartAreas[0].CursorX.SelectionEnd = ((DateTime)maxValue).ToOADate();

                    // Update labels to show info about the selected chart area
                    timelineHelper.ResetTimelineLabelSelectionDuration();
                }

                // Clear the used lists
                timelineHelper.FilteredProfilerEvents.Clear();
                selectedEvents.Clear();
            }

            resultPresenterControl.AnalyzerResultControl.SelectTabPageIndex(5);

        }

        private void ShowRelatedPerformanceCounters()
        {
            if (CurrentDataGridView.SelectedRows.Count == 1)
            {
                var selectedEvent = ((BindingList<ProfilerItem>)CurrentDataGridView.DataSource)
                    //.Where((i) => i.ID == CurrentDataGridView.CurrentCell.RowIndex + 1)
                    .Where((i) => i.ID == (int)(CurrentDataGridView.SelectedRows[0].Cells["ID"].Value))
                    .SingleOrDefault();
                if (selectedEvent == null)
                    return;

                var performances = CurrentSelectedPerformances
                     .OrderBy((n) => n.FullName)
                     .Select((p) => new
                     {
                         FullName = p.FullName,
                         Item = p
                            .Where((c) => c.TraceEventTime <= selectedEvent.CurrentTime)
                            .OrderByDescending((c) => c.TraceEventTime)
                            .First()
                     });

                chartPerformanceCounters.Series.Clear();
                chartPerformanceCounters.ChartAreas[0].BackColor = Color.Transparent;

                var borderColor = Properties.Settings.Default.ColdCacheColor;
                var primaryColor = Properties.Settings.Default.ColdCacheGraphBarColor1;
                var secondaryColor = Properties.Settings.Default.ColdCacheGraphBarColor2;

                if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                {
                    borderColor = Properties.Settings.Default.WarmCacheColor;
                    primaryColor = Properties.Settings.Default.WarmCacheGraphBarColor1;
                    secondaryColor = Properties.Settings.Default.WarmCacheGraphBarColor2;
                }

                var performanceCountersSerie = new Series();
                performanceCountersSerie.ChartArea = chartPerformanceCounters.ChartAreas[0].Name;
                performanceCountersSerie.ChartType = SeriesChartType.Bar;
                performanceCountersSerie.IsValueShownAsLabel = true;
                performanceCountersSerie.Label = "#VAL";
                performanceCountersSerie.LegendText = "#LEGENDTEXT";
                performanceCountersSerie.Name = "PerformanceCounters";
                performanceCountersSerie.Enabled = true;

                var index = 0;
                foreach (var counter in performances)
                {
                    var point = new DataPoint();
                    point.AxisLabel = counter.FullName;
                    point.LegendText = counter.FullName;
                    point.BorderColor = borderColor;
                    point.IsValueShownAsLabel = true;
                    point.Label = "#VAL";
                    point.BorderWidth = 1;
                    point.Color = index++ % 2 == 0 ? primaryColor : secondaryColor;

                    if (counter.FullName.Equals("Memory : Memory usage KB"))
                    {
                        if (counter.Item.Value < 0L)
                        {
                            point.Label = string.Format("{0:n0}", counter.Item.Value);
                            point.SetValueY(0L);
                        }
                        else
                        {
                            point.Label = "#VAL{N0}";
                            point.SetValueY(counter.Item.Value);
                        }
                    }
                    else
                    {
                        point.SetValueY(counter.Item.Value);
                        point.Label = string.Format("{0:n0}", counter.Item.Value);
                    }

                    if (point.YValues.Single() == 0D)
                        point.IsEmpty = true;

                    if (point.IsEmpty)
                        point.Label = " ";

                    performanceCountersSerie.Points.Add(point);
                }

                if (performanceCountersSerie.Points.All((p) => p.IsEmpty))
                    chartPerformanceCounters.ChartAreas[0].Axes[1].IsLogarithmic = false;

                chartPerformanceCounters.Series.Add(performanceCountersSerie);


                //panelPerformanceCounters.Visible = true;
            }
        }

        private void ShowSelectedPerformanceCounterInTimeline()
        {
            if (_selectedDataPoint != null)
            {
                string PerformanceCounterName = _selectedDataPoint.AxisLabel;


                if (PerformanceCounterName != "")
                {
                    var resultPresenterControl = this.GetResultPresenterControl();
                    resultPresenterControl.AnalyzerResultControl.SelectTabPageIndex(5);

                    Chart timelineChart = null;
                    if (tabControlTraceEvents.SelectedTab == tabPageColdCache)
                        timelineChart = resultPresenterControl.AnalyzerResultControl.TimelineControl.chartCold;
                    else if (tabControlTraceEvents.SelectedTab == tabPageWarmCache)
                        timelineChart = resultPresenterControl.AnalyzerResultControl.TimelineControl.chartWarm;

                    foreach (var item in timelineChart.ContextMenuStrip.Items)
                    {
                        if (item is ToolStripMenuItem)
                        {
                            var menuItem = (ToolStripMenuItem)item;
                            if (menuItem.Text == "Performance Counters")
                            {
                                foreach (ToolStripItem tsitem in menuItem.DropDownItems)
                                {
                                    if (tsitem.Text.Equals(PerformanceCounterName, StringComparison.OrdinalIgnoreCase))
                                    {
                                        tsitem.PerformClick();
                                        break;
                                    }
                                }

                                break;
                            }
                        }
                    }

                }
            }
        }

        
        #endregion

        #region DataGridView

        private void DataGridViewCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            var gridView = (DataGridView)sender;
            gridView.ContextMenuStrip.Visible = e.Button == MouseButtons.Right && e.RowIndex >= 0 && gridView.Rows[e.RowIndex].Selected;            
        }

        private void DataGridViewSelectionChanged(object sender, EventArgs e)
        {
            UpdateDetails();
        }

        public void DataGridViewResetCurrentFilter()
        {
            comboBoxClass.SelectedItem = comboBoxClass.Items[comboBoxClass.Items.IndexOf(ParameterDefaultValue)];
            ComboBoxTraceEventFiltersSelectionChangeCommitted(comboBoxClass, null);

            comboBoxSubclass.SelectedItem = comboBoxSubclass.Items[comboBoxSubclass.Items.IndexOf(ParameterDefaultValue)];
            ComboBoxTraceEventFiltersSelectionChangeCommitted(comboBoxSubclass, null);
        }

        public bool DataGridViewIsCurrentFiltered()
        {
            return comboBoxClass.Text != ParameterDefaultValue || comboBoxSubclass.Text != ParameterDefaultValue;
        }

        #endregion

        #region RichTextBox

        private void RichTextBoxTextDataCopy()
        {
            if (richTextBoxTextData.SelectionLength > 0)
                richTextBoxTextData.Copy();
        }

        private void RichTextBoxTextDataMouseUp(object sender, MouseEventArgs e)
        {
            var richTextBox = (RichTextBox)sender;

            richTextBox.ContextMenuStrip.Visible = e.Button == MouseButtons.Right && richTextBox.SelectionLength > 0;
        }

        #endregion

        #region Mouse on charts events

        private void OnChartMouseMove(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var hit = chart.HitTest(e.X, e.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                var point = chart.Series[0].Points[hit.PointIndex];
                if (_selectedDataPoint == null || point != _selectedDataPoint)
                {
                    if (_selectedDataPoint != null)
                        DeselectSingleDataPoint(_selectedDataPoint);

                    SelectSingleDataPoint(point);
                    _selectedDataPoint = point;
                }
            }
            else
            {
                if (hit.ChartElementType != ChartElementType.DataPointLabel)
                {
                    if (_selectedDataPoint != null)
                        DeselectSingleDataPoint(_selectedDataPoint);

                    _selectedDataPoint = null;
                }
            }
        }

        private void DeselectSingleDataPoint(DataPoint point)
        {
            if (point.Color == Settings.Default.HighlightColor)
                point.Color = point.BackSecondaryColor;

            point.BackSecondaryColor = Color.White;
            point.BackHatchStyle = ChartHatchStyle.None;
            point.BorderWidth = 1;
        }

        private void SelectSingleDataPoint(DataPoint point)
        {
            point.BackSecondaryColor = point.Color;
            point.Color = Settings.Default.HighlightColor;
            point.BorderWidth = 2;
        }

        private void OnChartMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            //_selectedChart = (Chart)sender;
            //_showOnTimeline.Visible = _selectedDataPoint != null;
            //_stripSeparator.Visible = _selectedDataPoint != null;
        }

        #endregion
    }
}
