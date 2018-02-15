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
    using SSASQueryAnalyzer.Client.Common.Windows.Forms;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Server.Performance;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Server.Profiler;
    using SSASQueryAnalyzer.Client.Common.Properties;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Xml.Linq;
    using System.Configuration;

	public partial class ResultPresenterAnalyzerResultTimelineControl : UserControl
    {
        internal enum AnalysisTypes
        {
            Cold,
            Warm
        }
        
        #region [ TimelineHelper internal class ]
        
        internal class TimelineHelper
		{
            #region [ Properties ]

            private SplitContainer TimelineSplitContainer
            {
                get
                {
                    return TimelineControl.splitContainer;
                }
            }

            private Chart TimelineChart
            {
                get
                {
                    switch (AnalysisType)
	                {
		                case AnalysisTypes.Cold:
                            return TimelineControl.chartCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.chartWarm;
	                }

                    throw new ApplicationException("Invalid _analysisType[TimelineChart]");
                }
            }

            private Color TimelineColor
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return Settings.Default.ColdCacheColor;
                        case AnalysisTypes.Warm:
                            return Settings.Default.WarmCacheColor;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelineColor]");
                }
            }

            private ContextMenuStrip TimelineChartContextMenu;
            
            private CustomLabelControl TimelineLabelYAxis
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.labelYAxisNameCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.labelYAxisNameWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelineLabelYAxis]");
                }
            }

            private CustomLabelControl TimelineLabelMessage
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.customLabelMessageCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.customLabelMessageWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelineLabelMessage]");
                }
            }

            private Panel TimelinePanelMessage
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.panelMessageExternalCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.panelMessageExternalWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelinePanelMessage]");
                }
            }

            private PictureBox TimelinePanelMessagePictureBox
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.pictureBoxMessageCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.pictureBoxMessageWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelinePanelMessagePictureBox]");
                }
            }

            private Panel TimelinePanelSelectionInfo
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.panelSelectionInfoCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.panelSelectionInfoWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelinePanelSelectionInfo]");
                }
            }
            
            private Button TimelineButtonZoom
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.buttonTimelineZoomCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.buttonTimelineZoomWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelineButtonZoom]");
                }
            }

            private Label TimelineLabelTitle
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.labelTitleCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.labelTitleWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelineLabelTitle]");
                }
            }

            private Label TimelineLabelSelectionDuration
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.labelSelectionDurationCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.labelSelectionDurationWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelineLabelSelectionDuration]"); 
                }
            }

            private Panel TimelinePanelZoom
            {
                get
                {
                    switch (AnalysisType)
                    {
                        case AnalysisTypes.Cold:
                            return TimelineControl.panelTimelineZoomCold;
                        case AnalysisTypes.Warm:
                            return TimelineControl.panelTimelineZoomWarm;
                    }

                    throw new ApplicationException("Invalid _analysisType[TimelinePanelZoom]");
                }
            }

            private DateTime QueryBeginTime
            {
                get
                {
                    if (!_queryBeginTime.HasValue)
                    {
                        _queryBeginTime = ExecutionResult.Profilers
                            .Single((p) => p.EventClass == TraceEventClass.QueryBegin)
                            .Single()
                            .CurrentTime.Value;
                    }

                    return _queryBeginTime.Value;
                }
            }

            private DateTime QueryEndTime
            {
                get
                {
                    if (!_queryEndTime.HasValue)
                    {
                        _queryEndTime = ExecutionResult.Profilers
                            .Single((p) => p.EventClass == TraceEventClass.QueryEnd)
                            .Single()
                            .CurrentTime.Value;
                    }

                    return _queryEndTime.Value;
                }
            }

            private DateTime ChartBeginTime
            {
                get
                {
                    if (!_chartBeginTime.HasValue)
                        _chartBeginTime = QueryBeginTime;

                    return _chartBeginTime.Value;
                }
                set
                {
                    _chartBeginTime = value;
                }
            }

            private DateTime ChartEndTime
            {
                get
                {
                    if (!_chartEndTime.HasValue)
                        _chartEndTime = QueryEndTime;

                    return _chartEndTime.Value;
                }
                set
                {
                    _chartEndTime = value;
                }
            }

            private Series CurrentPerformanceCounterSerie
            {
                get
                {
                    return _currentPerformanceCounterSerie;
                }
                set
                {
                    _currentPerformanceCounterSerie = value;
                    TimelineLabelYAxis.Text = "Axis Y (Performance Counters): {0}".FormatWith(_currentPerformanceCounterSerie.Name);
                    _currentPerformanceCounterSerieCounters = PerformanceCounters
                            .Where((c) => c.FullName == _currentPerformanceCounterSerie.Name)
                            .SelectMany((c) => c)
                            .Distinct()
                            .ToList();
                }
            }

            private Series MultipleObjectsSerie
            {
                get
                {
                    return _multipleObjectsSerie;
                }
                set
                {
                    _multipleObjectsSerie = value;
                }
            }

            private Double QueryDuration
            {
                get
                {
                    _queryDuration = QueryEndTime.Subtract(QueryBeginTime).TotalMilliseconds;

                    return _queryDuration;
                }
            }

            private Double ZoomMinimumValue
            {
                get
                {
                    return ChartBeginTime.Subtract(QueryBeginTime).TotalMilliseconds;
                }
            }

            private Double ZoomMaximumValue
            {
                get
                {
                    return ChartEndTime.Subtract(QueryBeginTime).TotalMilliseconds;
                }
            }

            public bool ZoomMode
            {
                get
                {
                    return ChartBeginTime.CompareTo(QueryBeginTime) != 0 || ChartEndTime.CompareTo(QueryEndTime) != 0;
                }
            }

            private Double ZoomDuration
            {
                get
                {
                    if (ZoomMode)
                        return ChartEndTime.Subtract(ChartBeginTime).TotalMilliseconds;

                    return 0D;
                }
            }

            private string ZoomDurationString
            {
                get
                {
                    if (ZoomMode)
                        return ChartEndTime.Subtract(ChartBeginTime).ToFormattedTime();

                    return "";
                }
            }

            private DateTime SelectionStartTime
            {
                get
                {
                    if (!Double.IsNaN(LinesChartArea.CursorX.SelectionStart))
                    {
                        _selectionStartTime = DateTime.FromOADate(LinesChartArea.CursorX.SelectionStart);
                    }
                    return _selectionStartTime.Value;
                }
            }

            private DateTime SelectionEndTime
            {
                get
                {
                    if (!Double.IsNaN(LinesChartArea.CursorX.SelectionEnd))
                    {
                        _selectionEndTime = DateTime.FromOADate(LinesChartArea.CursorX.SelectionEnd);
                    }
                    return _selectionEndTime.Value;
                }
            }

            private Double SelectionDuration
            {
                get
                {
                    if (_selectionStartTime.HasValue && _selectionEndTime.HasValue)
                        return SelectionEndTime.Subtract(SelectionStartTime).TotalMilliseconds;

                    return 0D;
                }
            }

            private string SelectionDurationString
            {
                get
                {
                    string _selectionDurationString = "No selection!";

                    if (_selectionStartTime.HasValue && _selectionEndTime.HasValue)
                    {
                        if (SelectionEndTime > SelectionStartTime)
                        {
                            _selectionDurationString = SelectionEndTime.Subtract(SelectionStartTime).ToFormattedTime();
                        }
                        else if (SelectionEndTime < SelectionStartTime)
                        {
                            _selectionDurationString = SelectionStartTime.Subtract(SelectionEndTime).ToFormattedTime();
                        }
                    }

                    return _selectionDurationString;
                }
            }

            private bool ChartAreaSelected
            {
                get
                {
                    return SelectionDuration != 0;
                }
            }

            private ChartArea LinesChartArea
            {
                get
                {
                    return TimelineChart.ChartAreas[0];
                }
            }

            private ChartArea RangesChartArea
            {
                get
                {
                    return TimelineChart.ChartAreas[1];
                }
            }

            private Double AxisXOffset
            {
                get
                {
                    ChartAxisXOffset = (ChartEndTime.ToOADate() - ChartBeginTime.ToOADate()) / (Double)1000;

                    ChartLabelsXOffset = 1; // (_axisXOffset / 2);

                    return ChartAxisXOffset;
                }
            }

            private IEnumerable<ProfilerItemCollection> ProfilerEvents
            {
                get
                {
                    return ExecutionResult.Profilers;
                }
            }

            private IEnumerable<PerformanceItemCollection> PerformanceCounters
            {
                get
                {
                    return ExecutionResult.Performances;
                }
            }

            #endregion

            #region [ Fields ]

            private enum SeriesType
            {
                MultipleObjects,
                Profiler,
                Performance,
                Aggregation,
                Partition,
                Serialization,
                Cache,
                Measure,
                Dimension,
                NonEmpty
            };

            /// <summary>
            /// Aggregations, Partitions, Caches, NonEmpty, Serializations, Measures
            /// </summary>
            private class ComplexObject
            {
                public Series Serie;
                public Color? SerieColor;
                public string ComplexObjectName;
                public string ComplexObjectVisible;
                public string ComplexObjectID; 
                public int BeginEventID;
                public DateTime? BeginEventTime;
                public Double? BeginEventTimeOADate;
                public int EndEventID;
                public DateTime? EndEventTime;
                public Double? EndEventTimeOADate;
                public string MeasureGroupID;
                public string ComplexObjectType; // "Aggregation", "Partition", "Serialization", "NonEmpty" "Measure", "Dimension"
                public string ComplexObjectSubType; // For Measures: "Real" or "Calculated" - For Dimensions: "Cached" or "Non cached" - For the others EventType: "null"
                public string ComplexObjectPath;
                public string ComplexObjectTextData;
                public string ComplexObjectProgressTotalUnitMeasure;
                public long? ComplexObjectDuration;     //--> This is the Duration exposed by Profiler Trace
                public long? ComplexObjectReadDuration; //--> This is a Duration calculated subtracting the BeginTime from the EndTime
                public long? ComplexObjectProgressTotal;
            }

            private class MenuItemsCounter
            {
                public string MenuName;
                public int MenuCounter;
            }

            private List<MeasureMetadata> MeasureMetadataCollection;
            private class MeasureMetadata
            {
                public string ID;
                public string Name;
                public string Visible;
                public bool InRange;
                public DateTime? BeginTime;
                public DateTime? EndTime;
                public int? BeginID;
                public int? EndID;
                public string Expression;
                public string MeasureGroupID;
            }

            public List<ProfilerItem> FilteredProfilerEvents { get; set; }            

            private Graphics _graphicsObj;
            private DateTime? _selectionStartTime;
            private DateTime? _selectionEndTime;
            private Double _queryDuration;
            private bool zoomMoving;
            private int linesChartAreaAxisYMaximum = 1;
            private int rangesChartAreaAxisXMaximum = 2;

            private int _buttonTimeLineXPosition;
            private int _buttonLeftPosition;

            private int _xOffset = 2;
            Pen _timeLinePen, _cancelPen;
            private int _timeLinePixelLength;
            private double _timeEntityPerPixelTotal;
            private int _timeLineStart;
            private int _timeLineStop;            
            private double _pixelPerTimeEntityTotal;
            private int _zoomedAreaStart;
            private int _zoomedAreaStop;
            private int _zoomedAreaWidth;
            private int _halfHeightVerticalLines;
            private int _yCenterTimeLine;
            private int _heightTimeLine;
            private int _heightZoomButton;
            private int _yCenterCancelLine;
            private int _heightCancelLine;
            private int _minIDCalculatedMeasures = 2000000000;

            private int ThresholdCurrentObjectsSelected;
            private int ThresholdCurrentObjectsAvailable;
            private double _zoomDuration;
            private string _zoomDurationText = "";
            private int _zoomDurationTextWidth;
            private Font _zoomDurationLabelFont = new Font("Segoe UI", 6);
            private SolidBrush _zoomDurationLabelBrush;
            private List<ToolStripMenuItem> ZoomInEnabledManuItems = new List<ToolStripMenuItem>();

            private DataPoint _selectedpoint;

            #region Context Menus

            private ContextMenuStrip _timeConsumingObjectsMenu;

            private ToolStripMenuItem _showComplexObjectInTrace;

            public ToolStripMenuItem _uncheckAllProfilers;
            public ToolStripMenuItem _uncheckAllCaches;
            public ToolStripMenuItem _uncheckAllAggregations;
            public ToolStripMenuItem _uncheckAllPartitions;

            public ToolStripMenuItem _profilerMenuItem;
            public ToolStripMenuItem _performanceCountersMenuItem;
            public ToolStripMenuItem _cachesMenuItem;
            public ToolStripMenuItem _aggregationsMenuItem;
            public ToolStripMenuItem _partitionsMenuItem;
            public ToolStripMenuItem _dimensionsMenuItem;
            public ToolStripMenuItem _measuresMenuItem;
            public ToolStripMenuItem _nonEmptysMenuItem;
            public ToolStripMenuItem _serializationsMenuItem;
            #endregion

            private List<CustomLabel> _customLabelsInCurrentRange = new List<CustomLabel>();
            private List<StripLine> _stripLinesInCurrentRange = new List<StripLine>();

            private List<Series> PerformanceCounterSeries = new List<Series>();
            private List<Series> ProfilerEventSeries = new List<Series>();

            private List<ProfilerItem> ProfilerEventsInWholeQuery = new List<ProfilerItem>();
            private List<ProfilerItem> ProfilerEventsInCurrentRange = new List<ProfilerItem>();

            #region Complex Objects lists

            private List<ComplexObject> DimensionComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> DimensionComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> PartitionComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> PartitionComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> MeasureComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> MeasureComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> NonEmptyGlobalComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> NonEmptyGlobalComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> NonEmptyGetDataComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> NonEmptyGetDataComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> NonEmptyPostOrderComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> NonEmptyPostOrderComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> SerializeGlobalComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> SerializeGlobalComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> SerializeAxesComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> SerializeAxesComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> SerializeCellsComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> SerializeCellsComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> AggregationComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> AggregationComplexObjectsInWholeQuery = new List<ComplexObject>();

            private List<ComplexObject> CacheComplexObjectsInCurrentRange = new List<ComplexObject>();
            private List<ComplexObject> CacheComplexObjectsInWholeQuery = new List<ComplexObject>();

            #endregion

            private ComplexObject SelectedComplexObject = null;

            private int _lastEventID;

            private readonly ResultPresenterAnalyzerResultTimelineControl TimelineControl;
            private readonly AnalyzerExecutionResult ExecutionResult;
            private readonly AnalysisTypes AnalysisType;
            private readonly SettingsPropertyValueCollection ClonedSettings;

            private bool MouseOnChartDowned = false;
            private bool MouseOnZoomDowned = false;
            private Double ChartLabelsXOffset = 0.001;
            private Double ChartAxisXOffset = 0.001;

            private DateTime? _queryBeginTime;
            private DateTime? _queryEndTime;
            private DateTime? _chartBeginTime;
            private DateTime? _chartEndTime;

            private Series _currentPerformanceCounterSerie;
            private List<PerformanceItem> _currentPerformanceCounterSerieCounters;
            private Series _multipleObjectsSerie;
            private List<string> subSeriesName = new List<string>();

            private const string nonEmptyGlobalSerieName = "NonEmpty Global";
            private const string nonEmptyGetDataSerieName = "NonEmpty GetData";
            private const string nonEmptyPostOrderSerieName = "NonEmpty PostOrder";
            private const string serializeGlobalSerieName = "Serialize Global";
            private const string serializeCellsAxisSerieName = "Serialize Cells";

            #endregion

            #region [ Main ]

            public TimelineHelper(ResultPresenterAnalyzerResultTimelineControl timelineControl, AnalysisTypes analysisType, AnalyzerExecutionResult executionResult)
            {
                TimelineControl = timelineControl;
                ExecutionResult = executionResult;
                AnalysisType = analysisType;

                ClonedSettings = new SettingsPropertyValueCollection();
                foreach (SettingsPropertyValue value in Settings.Default.PropertyValues)
                    ClonedSettings.Add(new SettingsPropertyValue(new SettingsProperty(value.Property)) { PropertyValue = value.PropertyValue });

                InitializeExecutionTimeline();
            }

            private void InitializeExecutionTimeline()
            {
                TimelineChart.Cursor = Cursors.WaitCursor;
                try
                {
                    GlobalInitialize();
                    _stripLinesInCurrentRange.Clear();
                    _customLabelsInCurrentRange.Clear();
                    InitializeChart();
                    InitializeMultipleObjectsSerie();
                    //--> One Performance Counters series has to exists and has to be always selected, hence PerformanceSeries are the first objects must be created 
                    InitializePerformanceSeries();
                    InitializeProfilerEvents();
                    InitializeAllComplexObjects();
                    DrawPerformanceCountersOnChart(CurrentPerformanceCounterSerie);
                }
                finally
                {
                    TimelineChart.Cursor = Cursors.Default;
                }
            }

            private void UpdateExecutionTimeline()
            {
                TimelineChart.Cursor = Cursors.WaitCursor;
                try
                {
                    _stripLinesInCurrentRange.Clear();
                    _customLabelsInCurrentRange.Clear();
                    ResetChart();
                    TimelinePanelZoom.Parent.Visible = ZoomMode;
                    UpdateProfilerEvents();
                    UpdateAllComplexObjects();
                    UpdateTimelineLabelMessage();
                }
                finally
                {
                    TimelineChart.Cursor = Cursors.Default;
                }
            }

            #endregion

            #region [ Helper ]

            private void ShowTimeConsumingObjectInTraceEvents(ComplexObject complexObject)
            {
                ContextMenuSelectRangeInTraceEvents(complexObject.BeginEventID - 1, complexObject.EndEventID - 1, false);
            }

            #endregion

            #region [ Context Menu ]

            private void InitializeContextMenuStrips()
            {
                Debug.Assert(TimelineChart.ContextMenuStrip == null);

                TimelineChartContextMenu = new ContextMenuStrip();

                var menuItemCheckAllName = "Check all";
                var menuItemUncheckAllName = "Uncheck all";

                var menuItemGlobalUncheckAllName = "Uncheck all";
                TimelineChartContextMenu.Items.Add(new ToolStripMenuItem(text: menuItemGlobalUncheckAllName, image: null, onClick: (s, e) => ClearChart(s), name: menuItemGlobalUncheckAllName));
                TimelineChartContextMenu.Items.Add(new ToolStripSeparator());

                var menuItemZoomInName = "Zoom in";
                var menuItemZoomOutName = "Zoom out";
                TimelineChartContextMenu.Items.Add(new ToolStripMenuItem(text: menuItemZoomInName, image: null, onClick: ContextMenuZoomIn_Click, name: menuItemZoomInName));
                TimelineChartContextMenu.Items.Add(new ToolStripMenuItem(text: menuItemZoomOutName, image: null, onClick: ContextMenuZoomOut_Click, name: menuItemZoomOutName));
                TimelineChartContextMenu.Items.Add(new ToolStripSeparator());

                var menuItemShowSelectionInTraceEventsName = "Show selection in Trace Events grid";
                TimelineChartContextMenu.Items.Add(new ToolStripMenuItem(text: menuItemShowSelectionInTraceEventsName, image: null, onClick: ContextMenuShowSelectionInTraceEvents_Click, name: menuItemShowSelectionInTraceEventsName));
                TimelineChartContextMenu.Items.Add(new ToolStripSeparator());

                var menuItemProfilerEventsName = "Profiler Events";
                var menuItem = new ToolStripMenuItem(text: menuItemProfilerEventsName, image: null, onClick: null, name: menuItemProfilerEventsName);
                menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemCheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, true), name: menuItemCheckAllName));
                menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemUncheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, false), name: menuItemUncheckAllName));
                menuItem.DropDownItems.Add(new ToolStripSeparator());
                TimelineChartContextMenu.Items.Add(menuItem);
                // *** rimuovere
                _profilerMenuItem = menuItem;
                _uncheckAllProfilers = (ToolStripMenuItem)menuItem.DropDownItems[menuItemUncheckAllName]; //--> This code needs to TraceEventsControl in ShowSelectedTraceEventsInTimeline()
                // ***

                var menuItemPerformanceCountersName = "Performance Counters";
                menuItem = new ToolStripMenuItem(text: menuItemPerformanceCountersName, image: null, onClick: null, name: menuItemPerformanceCountersName);
                menuItem.DropDownItemClicked += ContextMenuPerformanceCounters_DropDownItemClicked;
                TimelineChartContextMenu.Items.Add(menuItem);
                TimelineChartContextMenu.Items.Add(new ToolStripSeparator());
                // *** rimuovere
                _performanceCountersMenuItem = menuItem;
                // ***

                int countTimeConsumingMenu = 0;
                
                var menuItemCachesName = "Caches";
                if ((bool)ClonedSettings["TimelineCachesVisible"].PropertyValue)
                {
                    countTimeConsumingMenu++;
                    menuItem = new ToolStripMenuItem(text: menuItemCachesName, image: null, onClick: null, name: menuItemCachesName);
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemCheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, true), name: menuItemCheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemUncheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, false), name: menuItemUncheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripSeparator());
                    TimelineChartContextMenu.Items.Add(menuItem);
                    // *** rimuovere
                    _cachesMenuItem = menuItem;
                    _uncheckAllCaches = (ToolStripMenuItem)menuItem.DropDownItems[menuItemUncheckAllName]; //--> This code needs to DataRetrieveControl in RefreshSelectedObjects() event
                    // ***
                }
                
                var menuItemAggregationsName = "Aggregations";
                if ((bool)ClonedSettings["TimelineAggregationsVisible"].PropertyValue)
                {
                    countTimeConsumingMenu++;
                    menuItem = new ToolStripMenuItem(text: menuItemAggregationsName, image: null, onClick: null, name: menuItemAggregationsName);
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemCheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, true), name: menuItemCheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemUncheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, false), name: menuItemUncheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripSeparator());
                    TimelineChartContextMenu.Items.Add(menuItem);
                    // *** rimuovere
                    _aggregationsMenuItem = menuItem;
                    _uncheckAllAggregations = (ToolStripMenuItem)menuItem.DropDownItems[menuItemUncheckAllName]; //--> This code needs to DataRetrieveControl in RefreshSelectedObjects() event
                    // ***
                }
                
                var menuItemPartitionsName = "Partitions";
                if ((bool)ClonedSettings["TimelinePartitionsVisible"].PropertyValue)
                {
                    countTimeConsumingMenu++;
                    menuItem = new ToolStripMenuItem(text: menuItemPartitionsName, image: null, onClick: null, name: menuItemPartitionsName);
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemCheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, true), name: menuItemCheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemUncheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, false), name: menuItemUncheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripSeparator());
                    TimelineChartContextMenu.Items.Add(menuItem);
                    // *** rimuovere
                    _partitionsMenuItem = menuItem;
                    _uncheckAllPartitions = (ToolStripMenuItem)menuItem.DropDownItems[menuItemUncheckAllName]; //--> This code needs to DataRetrieveControl in RefreshSelectedObjects() event
                    // ***
                }
                
                var menuItemDimensionsName = "Dimensions";
                if ((bool)ClonedSettings["TimelineDimensionsVisible"].PropertyValue)
                {
                    countTimeConsumingMenu++;
                    menuItem = new ToolStripMenuItem(text: menuItemDimensionsName, image: null, onClick: null, name: menuItemDimensionsName);
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemCheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, true), name: menuItemCheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemUncheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, false), name: menuItemUncheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripSeparator());
                    TimelineChartContextMenu.Items.Add(menuItem);
                    // *** rimuovere
                    _dimensionsMenuItem = menuItem;
                    // ***       
                }
                
                var menuItemMeasuresName = "Measures";
                if ((bool)ClonedSettings["TimelineMeasuresVisible"].PropertyValue)
                {
                    countTimeConsumingMenu++;
                    menuItem = new ToolStripMenuItem(text: menuItemMeasuresName, image: null, onClick: null, name: menuItemMeasuresName);
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemCheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, true), name: menuItemCheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemUncheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, false), name: menuItemUncheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripSeparator());
                    TimelineChartContextMenu.Items.Add(menuItem);
                    // *** rimuovere
                    _measuresMenuItem = menuItem;
                    // ***                
                }
                
                var menuItemNonEmptyActivitiesName = "NonEmpty Activities";
                if ((bool)ClonedSettings["TimelineNonEmptyActivitiesVisible"].PropertyValue)
                {
                    countTimeConsumingMenu++;
                    menuItem = new ToolStripMenuItem(text: menuItemNonEmptyActivitiesName, image: null, onClick: null, name: menuItemNonEmptyActivitiesName);
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemCheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, true), name: menuItemCheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemUncheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, false), name: menuItemUncheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripSeparator());
                    TimelineChartContextMenu.Items.Add(menuItem);
                    // *** rimuovere
                    _nonEmptysMenuItem = menuItem;
                    // ***
                }
                
                var menuItemSerializationsName = "Serialization Activities";
                if ((bool)ClonedSettings["TimelineSerializationActivitiesVisible"].PropertyValue)
                {
                    countTimeConsumingMenu++;
                    menuItem = new ToolStripMenuItem(text: menuItemSerializationsName, image: null, onClick: null, name: menuItemSerializationsName);
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemCheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, true), name: menuItemCheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripMenuItem(text: menuItemUncheckAllName, image: null, onClick: (s, e) => CheckUncheckAllClick(s, false), name: menuItemUncheckAllName));
                    menuItem.DropDownItems.Add(new ToolStripSeparator());
                    TimelineChartContextMenu.Items.Add(menuItem);
                    // *** rimuovere
                    _serializationsMenuItem = menuItem;
                    // ***
                }

                if (countTimeConsumingMenu > 0)
                    TimelineChartContextMenu.Items.Add(new ToolStripSeparator());

                var menuItemShowBothChartsName = "Show both charts";
                menuItem = new ToolStripMenuItem(text: menuItemShowBothChartsName, image: null, onClick: ContextMenuShowBothCharts_Click, name: menuItemShowBothChartsName);
                TimelineChartContextMenu.Items.Add(menuItem);

                var menuItemShowOnlyThisChartName = "Show only this chart";
                menuItem = new ToolStripMenuItem(text: menuItemShowOnlyThisChartName, image: null, onClick: ContextMenuShowOnlyThisChart_Click, name: menuItemShowOnlyThisChartName);
                TimelineChartContextMenu.Items.Add(menuItem);

                var menuItemResizeBothChartsName = "Resize both charts";
                menuItem = new ToolStripMenuItem(text: menuItemResizeBothChartsName, image: null, onClick: ContextMenuResizeBothCharts_Click, name: menuItemResizeBothChartsName);
                TimelineChartContextMenu.Items.Add(menuItem);

                TimelineChartContextMenu.Opening += (sender, e) =>
                {
                    var menu = (ContextMenuStrip)sender;

                    var dropDownMenuItems = menu.Items.OfType<ToolStripMenuItem>()
                        .Where((i) => new[] { menuItemProfilerEventsName, menuItemCachesName, menuItemAggregationsName, menuItemPartitionsName, menuItemDimensionsName, menuItemMeasuresName, menuItemNonEmptyActivitiesName, menuItemSerializationsName }.Contains(i.Name));

                    menu.Items[menuItemGlobalUncheckAllName].Enabled = dropDownMenuItems.Any((i) => i.DropDownItems.OfType<ToolStripMenuItem>().Any((d) => d.Checked && d.Enabled));
                    foreach (var item in dropDownMenuItems)
                    {
                        var itemChild = item.DropDownItems.OfType<ToolStripMenuItem>().ToList();

                        item.DropDownItems[menuItemCheckAllName].Enabled = itemChild.Any((d) => new[] { menuItemCheckAllName, menuItemUncheckAllName }.Contains(d.Name) == false && !d.Checked && d.Enabled);
                        item.DropDownItems[menuItemUncheckAllName].Enabled = itemChild.Any((d) => d.Checked && d.Enabled);
                        item.Enabled = itemChild.Any((d) => new[] { menuItemCheckAllName, menuItemUncheckAllName }.Contains(d.Name) == false);
                    }

                    menu.Items[menuItemZoomOutName].Enabled = ZoomMode;
                    menu.Items[menuItemZoomInName].Enabled = ChartAreaSelected;
                    menu.Items[menuItemShowSelectionInTraceEventsName].Enabled = ChartAreaSelected;
                    menu.Items[menuItemShowBothChartsName].Visible = TimelineSplitContainer.Panel1Collapsed || TimelineSplitContainer.Panel2Collapsed;
                    menu.Items[menuItemShowOnlyThisChartName].Visible = !TimelineSplitContainer.Panel1Collapsed && !TimelineSplitContainer.Panel2Collapsed;
                    menu.Items[menuItemResizeBothChartsName].Visible = TimelineSplitContainer.SplitterDistance != TimelineSplitContainer.Width / 2;
                };

                TimelineChart.ContextMenuStrip = TimelineChartContextMenu;

                #region Time Consuming Objects menu

                _timeConsumingObjectsMenu = new ContextMenuStrip();
                _showComplexObjectInTrace = new ToolStripMenuItem("Show selected object in Trace Events grid");
                _showComplexObjectInTrace.Click += (s, e) => ShowTimeConsumingObjectInTraceEvents(SelectedComplexObject);
                _showComplexObjectInTrace.Enabled = true;
                _showComplexObjectInTrace.Visible = true;
                _timeConsumingObjectsMenu.Items.Add(_showComplexObjectInTrace);

                #endregion
            }

            private bool ThresholdReachedForCurrentSelectedEvents(bool considerDisabled, bool isZoomOut = false, bool isMouseMove = false)
            {
                if (Settings.Default.TimelineEventsNumberThreshold == 0)
                {
                    ThresholdCurrentObjectsAvailable = 0;
                    ThresholdCurrentObjectsSelected = 0;
                }

                var activemMenuItems = new List<ToolStripMenuItem>();

                if (_profilerMenuItem != null && _profilerMenuItem.Enabled)
                    activemMenuItems.AddRange(_profilerMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => (m.Enabled || considerDisabled) && m.Checked));

                if (_serializationsMenuItem != null && _serializationsMenuItem.Enabled)
                    activemMenuItems.AddRange(_serializationsMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => (m.Enabled || considerDisabled) && m.Checked));

                if (_nonEmptysMenuItem != null && _nonEmptysMenuItem.Enabled)
                    activemMenuItems.AddRange(_nonEmptysMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => (m.Enabled || considerDisabled) && m.Checked));

                if (_measuresMenuItem != null && _measuresMenuItem.Enabled)
                    activemMenuItems.AddRange(_measuresMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => (m.Enabled || considerDisabled) && m.Checked));

                if (_dimensionsMenuItem != null && _dimensionsMenuItem.Enabled)
                    activemMenuItems.AddRange(_dimensionsMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => (m.Enabled || considerDisabled) && m.Checked));

                if (_partitionsMenuItem != null && _partitionsMenuItem.Enabled)
                    activemMenuItems.AddRange(_partitionsMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => (m.Enabled || considerDisabled) && m.Checked));

                if (_aggregationsMenuItem != null && _aggregationsMenuItem.Enabled)
                    activemMenuItems.AddRange(_aggregationsMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => (m.Enabled || considerDisabled) && m.Checked));

                if (_cachesMenuItem != null && _cachesMenuItem.Enabled)
                    activemMenuItems.AddRange(_cachesMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => (m.Enabled || considerDisabled) && m.Checked));

                ThresholdCurrentObjectsSelected = activemMenuItems.Sum((m) =>
                {
                    var match = Regex.Match(m.Text, @"\((\d+)\)");
                    if (!match.Success && !match.Groups[1].Success)
                        return 0;

                    return int.Parse(match.Groups[1].Value);
                });

                if (Settings.Default.TimelineEventsNumberThreshold > 0)
                    ThresholdCurrentObjectsAvailable = Settings.Default.TimelineEventsNumberThreshold - ThresholdCurrentObjectsSelected;

                if (ThresholdCurrentObjectsAvailable < 0 && !isZoomOut && !isMouseMove)
                {
                    using (var form = new TimelineThresholdLimitWarningForm())
                    {
                        form.LabelMessageFirstRow.Text = "Threshold value reached";
                        form.LabelMessageSecondRow.Text = "No more objects selectable";
                        form.ShowDialog();
                    }
                } 
                else
                    UpdateTimelineLabelMessage(isZoomOut);

                return ThresholdCurrentObjectsAvailable < 0; 
            }

            public void CheckUncheckAllClick(object sender, bool checkAll)
            {
                var itemSender = sender as ToolStripMenuItem;
                if (itemSender == null)
                    return;

                TimelineChart.Cursor = Cursors.WaitCursor;
                ClearChartSeries(CurrentPerformanceCounterSerie); //--> Clear the actual Performance serie

                var seriesToEnableDisable = new List<Series>();

                // Enable/disable all menu items and related Chart series based on the checkAll parameter
                foreach (var menuItem in ((ToolStripMenuItem)itemSender.OwnerItem).DropDownItems.OfType<ToolStripMenuItem>())
                {
                    if (menuItem != sender && menuItem.Enabled)
                    {
                        var tuple = (Tuple<TimelineHelper, Series>)menuItem.Tag;
                        if (tuple != null)
                        {
                            menuItem.Checked = checkAll;

                            if (checkAll && ThresholdReachedForCurrentSelectedEvents(!ZoomMode))
                            {
                                menuItem.Checked = !checkAll;
                                break;
                            }

                            seriesToEnableDisable.Add(tuple.Item2);                            
                        }
                    }
                }

                ThresholdReachedForCurrentSelectedEvents(!ZoomMode);

                if(!checkAll)
                {
                    foreach(Series serie in seriesToEnableDisable)
                    {
                        ClearChartSeries(serie);
                        serie.Enabled = checkAll;
                    }
                }
                else
                {
                    foreach (Series serie in seriesToEnableDisable)
                    {
                        switch ((SeriesType)serie.Tag)
                        {
                            case SeriesType.Profiler:
                                LoadProfilerEvents(serie);
                                break;
                            case SeriesType.Performance:
                                CurrentPerformanceCounterSerie = serie; //--> Possibly change the Performance serie
                                break;
                            case SeriesType.Measure:
                            case SeriesType.Aggregation:
                            case SeriesType.Cache:
                            case SeriesType.Dimension:
                            case SeriesType.Partition:
                            case SeriesType.NonEmpty:
                            case SeriesType.Serialization:
                                DrawComplexObjectsOnChart(serie);
                                break;
                            default:
                                break;
                        }

                        serie.Enabled = checkAll;
                    }
                }

                DrawLinesAndLabelsOnChart();
                ResetChartBoundaries();
                DrawPerformanceCountersOnChart(CurrentPerformanceCounterSerie); //--> Refresh the Performance serie

                TimelineChart.Cursor = Cursors.Default;
            }

            public void ContextMenuItemPerformClick(object sender, bool @checked, bool disable = true)
            {
                var itemSender = sender as ToolStripMenuItem;
                if (itemSender == null)
                    return;

                if (disable)
                    itemSender.Enabled = false;

                // Enable/disable all other menu items based on the @checked parameter
                foreach (var menuItem in ((ToolStripMenuItem)itemSender.OwnerItem).DropDownItems.OfType<ToolStripMenuItem>())
                {
                    if (menuItem != sender && menuItem.Checked == @checked)
                        menuItem.PerformClick();
                }
            }

            private ToolStripMenuItem CreateContextMenuItem(ToolStripMenuItem parentMenuItem, Series serie, SeriesType type, Boolean sorted = true)
            {
                // If the serie is just in the menu: exit
                for (int index = 0; index < parentMenuItem.DropDownItems.Count; index++)
                {
                    if (parentMenuItem.DropDownItems[index].Name == serie.Name)
                        return parentMenuItem.DropDownItems[index] as ToolStripMenuItem;
                }

                // Create the menu item
                var menuItem = new ToolStripMenuItem(serie.Name);
                menuItem.Name = serie.Name;
                menuItem.CheckOnClick = true;
                menuItem.Checked = serie.Enabled;
                menuItem.Tag = Tuple.Create(this, serie);
                menuItem.Click += (object sender, EventArgs e) =>
                {
                    var eventMenuItem = (ToolStripMenuItem)sender;
                    var tuple = (Tuple<TimelineHelper, Series>)eventMenuItem.Tag;

                    if (ThresholdReachedForCurrentSelectedEvents(!ZoomMode))
                    {
                        eventMenuItem.Checked = false;
                        return;
                    }

                    UpdateObjectsSingleChartSeries(tuple.Item2, type, eventMenuItem.Checked);
                 };

                int fixedMenu = 2;
                if (type == SeriesType.Performance)
                    fixedMenu = 0;

                // If this is the first serie or if a menu has to be unsorted 
                if ((parentMenuItem.DropDownItems.Count == fixedMenu) || (!sorted))
                    parentMenuItem.DropDownItems.Add(menuItem);
                else
                {
                    // If this is NOT the first serie //AND if it is NOT a Serialization serie// it has to be insert in alphabetical order
                    for (int index = fixedMenu; index < parentMenuItem.DropDownItems.Count; index++)
                    {
                        // If the serie (in alphabetical order) is previous than the menu item: --> INSERT
                        if (string.Compare(serie.Name, parentMenuItem.DropDownItems[index].Name) < 0)
                        {
                            parentMenuItem.DropDownItems.Insert(index, menuItem);
                            break;
                        }
                        // If the serie (in alphabetical order) is next the last menu item: --> ADD
                        else if (index == parentMenuItem.DropDownItems.Count - 1)
                        {
                            parentMenuItem.DropDownItems.Add(menuItem);
                            break;
                        }
                    }
                }

                return menuItem;
            }

            private void UpdateAllContextMenuItems(List<MenuItemsCounter> menuItemsCounters, ToolStripMenuItem parentMenuItem, SeriesType seriesType, List<string> subSeriesName = null)
            {
                int fixedMenu = 3;
                if (seriesType == SeriesType.Performance)
                    fixedMenu = 0;

                for (int index = fixedMenu; index < parentMenuItem.DropDownItems.Count; index++)
                {
                    if (parentMenuItem.DropDownItems[index] is ToolStripMenuItem)
                    {
                        var menuItem = (ToolStripMenuItem)parentMenuItem.DropDownItems[index];

                        if (subSeriesName == null)
                            menuItem.Enabled = false;
                        else if (subSeriesName.Contains(menuItem.Name))
                            menuItem.Enabled = false;

                        foreach (MenuItemsCounter menuItemsCounter in menuItemsCounters)
                        {
                            if (menuItemsCounter.MenuName == menuItem.Name && menuItemsCounter.MenuCounter > 0)
                            {
                                menuItem.Text = menuItemsCounter.MenuName + " ({0})".FormatWith(menuItemsCounter.MenuCounter);
                                menuItem.Enabled = true;
                            }
                        }
                    }
                }
            }

            private ToolStripMenuItem GetMenuContextMenuItem(SeriesType serieType)
            {
                ToolStripMenuItem menuItem = null;

                switch (serieType)
                {
                    case SeriesType.Aggregation:
                        menuItem = _aggregationsMenuItem;
                        break;
                    case SeriesType.Cache:
                        menuItem = _cachesMenuItem;
                        break;
                    case SeriesType.Dimension:
                        menuItem = _dimensionsMenuItem;
                        break;
                    case SeriesType.Partition:
                        menuItem = _partitionsMenuItem;
                        break;
                    case SeriesType.Measure:
                        menuItem = _measuresMenuItem;
                        break;
                    case SeriesType.Profiler:
                        menuItem = _profilerMenuItem;
                        break;
                    case SeriesType.NonEmpty:
                        menuItem = _nonEmptysMenuItem;
                        break;
                    case SeriesType.Serialization:
                        menuItem = _serializationsMenuItem;
                        break;
                    default:
                        throw new ApplicationException("GetMenuContextMenuItem not found for [{0}]".FormatWith(serieType));
                }

                return menuItem;
            }

            #region [Context Menu Events]

            private void ContextMenuZoomIn_Click(object sender, EventArgs e)
            {
                var isFirstZoomIn = !ZoomMode;

                if (SelectionDuration > 0)
                {
                    ChartBeginTime = SelectionStartTime;
                    ChartEndTime = SelectionEndTime;
                }
                else if (SelectionDuration < 0)
                {
                    ChartBeginTime = SelectionEndTime;
                    ChartEndTime = SelectionStartTime;
                }

                _zoomDuration = ZoomDuration;
                UpdateExecutionTimeline();
                InitializeTimelineZoom();

                ThresholdReachedForCurrentSelectedEvents(considerDisabled: false);

                #region Collect active menu items

                if (Settings.Default.TimelineEventsNumberThreshold > 0 && isFirstZoomIn)
                {
                    ZoomInEnabledManuItems.Clear();

                    if (_profilerMenuItem != null && _profilerMenuItem.Enabled)
                        ZoomInEnabledManuItems.AddRange(_profilerMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => m.Checked));

                    if (_serializationsMenuItem != null && _serializationsMenuItem.Enabled)
                        ZoomInEnabledManuItems.AddRange(_serializationsMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => m.Checked));

                    if (_nonEmptysMenuItem != null && _nonEmptysMenuItem.Enabled)
                        ZoomInEnabledManuItems.AddRange(_nonEmptysMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => m.Checked));

                    if (_measuresMenuItem != null && _measuresMenuItem.Enabled)
                        ZoomInEnabledManuItems.AddRange(_measuresMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => m.Checked));

                    if (_dimensionsMenuItem != null && _dimensionsMenuItem.Enabled)
                        ZoomInEnabledManuItems.AddRange(_dimensionsMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => m.Checked));

                    if (_partitionsMenuItem != null && _partitionsMenuItem.Enabled)
                        ZoomInEnabledManuItems.AddRange(_partitionsMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => m.Checked));

                    if (_aggregationsMenuItem != null && _aggregationsMenuItem.Enabled)
                        ZoomInEnabledManuItems.AddRange(_aggregationsMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => m.Checked));

                    if (_cachesMenuItem != null && _cachesMenuItem.Enabled)
                        ZoomInEnabledManuItems.AddRange(_cachesMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where((m) => m.Checked));
                }

                #endregion
            }

            public void ResetZoomMode()
            {
                ChartBeginTime = QueryBeginTime;
                ChartEndTime = QueryEndTime;

                UpdateExecutionTimeline();
            }

            private void ContextMenuZoomOut_Click(object sender, EventArgs e)
            {
                if (Settings.Default.TimelineEventsNumberThreshold > 0)
                {
                    using (var form = new TimelineThresholdLimitWarningForm())
                    {
                        form.LabelMessageFirstRow.Text = "Zooming out will reset all object selections";
                        form.LabelMessageSecondRow.Text = "possibly made in zoom mode!";
                        form.ButtonCancel.Visible = true;

                        if (form.ShowDialog() == DialogResult.Cancel)
                            return;
                    }

                    #region Restore pre-zoomin active menu items

                    if (_profilerMenuItem != null && _profilerMenuItem.Enabled)
                        foreach (var menuItem in _profilerMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
		                    if (!ZoomInEnabledManuItems.Contains(menuItem))
                                menuItem.Checked = false;

                    if (_serializationsMenuItem != null && _serializationsMenuItem.Enabled)
                        foreach (var menuItem in _serializationsMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
                            if (!ZoomInEnabledManuItems.Contains(menuItem))
                                menuItem.Checked = false;

                    if (_nonEmptysMenuItem != null && _nonEmptysMenuItem.Enabled)
                        foreach (var menuItem in _nonEmptysMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
                            if (!ZoomInEnabledManuItems.Contains(menuItem))
                                menuItem.Checked = false;

                    if (_measuresMenuItem != null && _measuresMenuItem.Enabled)
                        foreach (var menuItem in _measuresMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
                            if (!ZoomInEnabledManuItems.Contains(menuItem))
                                menuItem.Checked = false;

                    if (_dimensionsMenuItem != null && _dimensionsMenuItem.Enabled)
                        foreach (var menuItem in _dimensionsMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
                            if (!ZoomInEnabledManuItems.Contains(menuItem))
                                menuItem.Checked = false;

                    if (_partitionsMenuItem != null && _partitionsMenuItem.Enabled)
                        foreach (var menuItem in _partitionsMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
                            if (!ZoomInEnabledManuItems.Contains(menuItem))
                                menuItem.Checked = false;

                    if (_aggregationsMenuItem != null && _aggregationsMenuItem.Enabled)
                        foreach (var menuItem in _aggregationsMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
                            if (!ZoomInEnabledManuItems.Contains(menuItem))
                                menuItem.Checked = false;

                    if (_cachesMenuItem != null && _cachesMenuItem.Enabled)
                        foreach (var menuItem in _cachesMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
                            if (!ZoomInEnabledManuItems.Contains(menuItem))
                                menuItem.Checked = false;

                    #endregion
                }

                ResetZoomMode();

                ThresholdReachedForCurrentSelectedEvents(considerDisabled: true, isZoomOut: true);
            }

            private void ContextMenuSelectRangeInTraceEvents(int rowBegin = 0, int rowEnd = 0, bool selectAllRange = false)
            {
                // Get ResultPresenterControl and TraceEventsControl
                var resultPresenterControl = TimelineSplitContainer.GetResultPresenterControl();
                var traceEventsControl = resultPresenterControl.AnalyzerResultControl.TraceEventsControl;

                // Possibly reset all filters
                if (traceEventsControl.DataGridViewIsCurrentFiltered())
                {
                    using (var resetTraceEventsFilterConfirmationForm = new ResetTraceEventsFilterConfirmationForm())
                    {
                        if (resetTraceEventsFilterConfirmationForm.ShowDialog() == DialogResult.No)
                            return;
                    }

                    traceEventsControl.DataGridViewResetCurrentFilter();
                }

                // Select correct tab pages
                traceEventsControl.SelectTabPageIndex(AnalysisType == AnalysisTypes.Cold ? 0 : 1);
                resultPresenterControl.AnalyzerResultControl.SelectTabPageIndex(3);

                // Get CurrentDataGridView 
                var grid = traceEventsControl.GetCurrentDataGridView();

                // If grid is empty exit
                if (grid.RowCount < 1)
                    return;

                // Clear all selections
                grid.ClearSelection();
                grid.CurrentCell = null;
                
                // Do some checks on rowBegin and rowEnd 

                if (rowBegin < 0)
                {
                    rowBegin = 0;
                }
                else
                {
                    if (rowBegin > grid.RowCount - 1)
                        rowBegin = grid.RowCount - 1;
                }

                if (rowEnd < 0)
                {
                    rowEnd = 0;
                }
                else
                {
                    if (rowEnd > grid.RowCount - 1)
                        rowEnd = grid.RowCount - 1;
                }
                if (rowBegin > rowEnd)
                {
                    // This code swap the value of the two variables using XOR operator
                    rowBegin = rowBegin ^ rowEnd;
                    rowEnd = rowBegin ^ rowEnd;
                    rowBegin = rowBegin ^ rowEnd;
                }

                // Select the events boundary of the range covers by the selected object 
                grid.FirstDisplayedScrollingRowIndex = rowBegin;

                if (selectAllRange)
                {
                    for (int counter = rowBegin; counter <= rowEnd; counter++)
                        grid.Rows[counter].Selected = true;
                }
                else
                {
                    grid.Rows[rowBegin].Selected = true;
                    grid.Rows[rowEnd].Selected = true;
                }
            }

            private void ContextMenuShowSelectionInTraceEvents_Click(object sender, EventArgs e)
            {
                var minSelectedEvent = ProfilerEventsInCurrentRange
                    .Where((i) => i.CurrentTime >= SelectionStartTime)
                    .OrderBy((i) => i.ID)
                    .FirstOrDefault();

                var maxSelectedEvent = ProfilerEventsInCurrentRange
                    .Where((i) => i.CurrentTime <= SelectionEndTime)
                    .OrderBy((i) => i.ID)
                    .LastOrDefault();

                if ((minSelectedEvent != null) && (maxSelectedEvent != null))
                    ContextMenuSelectRangeInTraceEvents(minSelectedEvent.ID - 1, maxSelectedEvent.ID - 1, true);
            }

            private void ContextMenuPerformanceCounters_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {
                var itemSender = e.ClickedItem as ToolStripMenuItem;
                if (itemSender == null)
                    return;

                // Performance menu item cannot be unselected
                // Hence, if you try to unselect a Performance Counter nothing has to happen
                // This method is called "before" the menu item click so if the "itemSender" is "checked" nothing has to happen
                ContextMenuItemPerformClick(e.ClickedItem, true, disable: false); //--> uncheck all the other menu items
            }

            private void ContextMenuShowBothCharts_Click(object sender, EventArgs e)
            {
                TimelineSplitContainer.SplitterDistance = TimelineSplitContainer.Width / 2;
                TimelineSplitContainer.Panel1Collapsed = false;
                TimelineSplitContainer.Panel2Collapsed = false;
            }

            private void ContextMenuShowOnlyThisChart_Click(object sender, EventArgs e)
            {
                switch (AnalysisType)
                {
                    case AnalysisTypes.Cold:
                        TimelineSplitContainer.Panel1Collapsed = false;
                        TimelineSplitContainer.Panel2Collapsed = true;
                        break;
                    case AnalysisTypes.Warm:
                        TimelineSplitContainer.Panel1Collapsed = true;
                        TimelineSplitContainer.Panel2Collapsed = false;
                        break;
                }
            }

            private void ContextMenuResizeBothCharts_Click(object sender, EventArgs e)
            {
                TimelineSplitContainer.SplitterDistance = TimelineSplitContainer.Width / 2;
                TimelineSplitContainer.Panel1Collapsed = false;
                TimelineSplitContainer.Panel2Collapsed = false;
            }

            #endregion

            #endregion

            #region [ Execution Timeline Chart ]

            public void ClearChart(object sender)
            {
                var itemSender = sender as ToolStripMenuItem;
                if (itemSender == null)
                    return;

                foreach (var menuItem in TimelineChartContextMenu.Items.OfType<ToolStripMenuItem>())
                {
                    if (menuItem != sender)
                    {
                        switch (menuItem.Text)
                        {
                            case "Profiler Events":
                            case "Caches":
                            case "Aggregations":
                            case "Partitions":
                            case "Dimensions":
                            case "Measures":
                            case "NonEmpty Activities":
                            case "Serialization Activities":
                                {
                                    foreach (var submenuItem in ((ToolStripMenuItem)menuItem).DropDownItems.OfType<ToolStripMenuItem>())
                                    {
                                        if ((submenuItem.Text == "Check all") || (submenuItem.Text == "Uncheck all"))
                                            continue;
                                        if (submenuItem != sender && submenuItem.Checked)
                                            submenuItem.PerformClick();
                                    }
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }

                ThresholdReachedForCurrentSelectedEvents(!ZoomMode);
            }

            private void DrawLinesAndLabelsOnChart()
            {
                if (MultipleObjectsSerie == null)
                    return;

                TimelineChart.SuspendLayout();
                LinesChartArea.AxisX.StripLines.SuspendUpdates();
                LinesChartArea.AxisX.CustomLabels.SuspendUpdates();

                ClearChartAreas();

                if ((_customLabelsInCurrentRange != null && _customLabelsInCurrentRange.Count() > 0) && (_stripLinesInCurrentRange != null && _stripLinesInCurrentRange.Count() > 0))
                {
                    #region Single objects

                    var singleCustomLabelsInCurrentRange = _customLabelsInCurrentRange.AsParallel()
                        .GroupBy((s) => s.FromPosition)
                        .Where((n) => n.Count() == 1)
                        .Select((grp) => grp.First());

                    foreach (CustomLabel singleCustomLabel in singleCustomLabelsInCurrentRange.ToList())
                    {
                        LinesChartArea.AxisX.StripLines.Add(item: new StripLine()
                        {
                            BorderColor = ResultPresenterConfiguration.DefaultLinesColor,
                            BorderDashStyle = ChartDashStyle.Solid,
                            BorderWidth = 1,
                            IntervalOffset = singleCustomLabel.FromPosition + ChartLabelsXOffset,
                            Tag = singleCustomLabel.Tag
                        });

                        LinesChartArea.AxisX.CustomLabels.Add(singleCustomLabel);
                    }

                    #endregion

                    #region Multiple objects

                    var multipleStripLinesInCurrentRange = _stripLinesInCurrentRange.AsParallel()
                        .GroupBy((s) => s.IntervalOffset)
                        .Select((g) => new
                        {
                            IntervalOffset = g.Min((p) => p.IntervalOffset),
                            Text = "Multiple Objects",
                            Tag = MultipleObjectsSerie,
                            Count = g.Count()
                        })
                        .Where((n) => n.Count > 1);

                    foreach (var multipleStripLine in multipleStripLinesInCurrentRange.ToList())
                    {
                        double fromPosition = multipleStripLine.IntervalOffset - ChartLabelsXOffset;
                        double toPosition = multipleStripLine.IntervalOffset + ChartLabelsXOffset;
                        var labelText = "{0} {1:HH:mm:ss.fff}".FormatWith(multipleStripLine.Text, DateTime.FromOADate(multipleStripLine.IntervalOffset));

                        LinesChartArea.AxisX.StripLines.Add(item: new StripLine()
                        {
                            BorderColor = ResultPresenterConfiguration.DefaultLinesColor,
                            BorderDashStyle = ChartDashStyle.Solid,
                            BorderWidth = 1,
                            IntervalOffset = multipleStripLine.IntervalOffset,
                            Tag = MultipleObjectsSerie
                        });

                        var label = LinesChartArea.AxisX.CustomLabels.Add(
                            fromPosition,
                            toPosition,
                            labelText,
                            0,
                            LabelMarkStyle.LineSideMark);
                        label.GridTicks = GridTickTypes.Gridline;
                        label.ForeColor = ResultPresenterConfiguration.DefaultLabelsColor;
                        label.Tag = MultipleObjectsSerie;
                    }

                    #endregion
                }

                LinesChartArea.AxisX.CustomLabels.ResumeUpdates();
                LinesChartArea.AxisX.StripLines.ResumeUpdates();
                TimelineChart.ResumeLayout();
            }

            private void RegisterTimeExecution(string message, TimeSpan duration)
            {
                string message_duration;
                message_duration = message.FormatWith(duration.Milliseconds.ToString());
                Debug.WriteLine(message_duration);
            }

            private void UpdateObjectsAllChartSeries(SeriesType seriesType)
            {
                var parentMenuItem = GetMenuContextMenuItem(seriesType);

                int fixedMenu = 3;
                if (seriesType == SeriesType.Performance)
                    fixedMenu = 0;

                for (int index = fixedMenu; index < parentMenuItem.DropDownItems.Count; index++)
                {
                    if (parentMenuItem.DropDownItems[index] is ToolStripMenuItem)
                    {
                        var menuItem = (ToolStripMenuItem)parentMenuItem.DropDownItems[index];
                        if (menuItem.Checked)
                        {
                            var tuple = (Tuple<TimelineHelper, Series>)menuItem.Tag;
                            var eventSeries = tuple.Item2;
                            UpdateObjectsSingleChartSeries(eventSeries, seriesType, menuItem.Checked);
                        }
                    }
                }
            }

            private void UpdateObjectsSingleChartSeries(Series serie, SeriesType serieType, bool enable)
            {
                TimelineChart.Cursor = Cursors.WaitCursor;
                try
                {
                    //TimelineChart.SuspendLayout();
                    //TimeSpan duration;
                    //DateTime startUpdateObjectsSingleChartSeries = DateTime.Now;

                    // The Performance serie must be always repainted if something change in any of the series!

                    ClearChartSeries(CurrentPerformanceCounterSerie); //--> Clear the actual Performance serie

                    if (!enable && serieType != SeriesType.Performance)
                    {
                        ClearChartSeries(serie);
                    }
                    else
                    {
                        switch (serieType)
                        {
                            case SeriesType.Profiler:
                                LoadProfilerEvents(serie);
                                break;
                            case SeriesType.Performance:
                                CurrentPerformanceCounterSerie = serie; //--> Possibly change the Performance serie
                                break;
                            case SeriesType.Measure:
                            case SeriesType.Aggregation:
                            case SeriesType.Cache:
                            case SeriesType.Dimension:
                            case SeriesType.Partition:
                            case SeriesType.NonEmpty:
                            case SeriesType.Serialization:
                                //DateTime startDrawComplexObjectsOnChart = DateTime.Now;

                                DrawComplexObjectsOnChart(serie);

                                //DateTime endDrawComplexObjectsOnChart = DateTime.Now;
                                //duration = endDrawComplexObjectsOnChart.Subtract(startDrawComplexObjectsOnChart);
                                //RegisterTimeExecution("Duration DrawComplexObjectsOnChart: {0} ms", duration);

                                break;
                            default:
                                break;
                        }

                    }


                    //DateTime startDrawLinesAndLabelsOnChart = DateTime.Now;

                    DrawLinesAndLabelsOnChart();

                    //DateTime endDrawLinesAndLabelsOnChart = DateTime.Now;
                    //duration = endDrawLinesAndLabelsOnChart.Subtract(startDrawLinesAndLabelsOnChart);
                    //RegisterTimeExecution("Duration DrawLinesAndLabelsOnChart: {0} ms", duration);

                    ResetChartBoundaries();

                    //DateTime startDrawPerformanceCountersOnChart = DateTime.Now;

                    DrawPerformanceCountersOnChart(CurrentPerformanceCounterSerie); //--> Refresh the Performance serie

                    //DateTime endDrawPerformanceCountersOnChart = DateTime.Now;
                    //duration = endDrawPerformanceCountersOnChart.Subtract(startDrawPerformanceCountersOnChart);
                    //RegisterTimeExecution("Duration DrawPerformanceCountersOnChart: {0} ms", duration);

                    //UpdateTimelineLabelMessage();        

                    //DateTime endUpdateObjectsSingleChartSeries = DateTime.Now;

                    //duration = endUpdateObjectsSingleChartSeries.Subtract(startUpdateObjectsSingleChartSeries);

                    //RegisterTimeExecution("Duration UpdateObjectsSingleChartSeries: {0} ms", duration);

                   
                    serie.Enabled = enable;

                    //TimelineChart.ResumeLayout();
                }
                finally
                {
                    TimelineChart.Cursor = Cursors.Default;
                }
            }

            private void GlobalInitialize()
            {
                ThresholdCurrentObjectsSelected = 0;
                ThresholdCurrentObjectsAvailable = Settings.Default.TimelineEventsNumberThreshold - ThresholdCurrentObjectsSelected;

                FilteredProfilerEvents = new List<ProfilerItem>();

                _lastEventID = ProfilerEvents.SelectMany((e) => e).Max((p) => p.ID);

                InitializeContextMenuStrips();
            }

            private void InitializeChartAreas()
            {
                var als = new LabelStyle();
                als.ForeColor = Color.Transparent;
                als.Font = new Font("Segoe UI", 0.1F);

                #region linesChartArea
                // LinesChartArea is used by all Profiler Events and by all the StripLines and CustomLabels

                LinesChartArea.Position.X = 0; // 0.5F;
                LinesChartArea.Position.Width = 98;
                LinesChartArea.Position.Y = 0; // 1;
                LinesChartArea.Position.Height = 98;

                LinesChartArea.BackColor = Color.Transparent;

                // Vertical Axis (not used)
                LinesChartArea.AxisY.LabelStyle = als;
                LinesChartArea.AxisY.IsLabelAutoFit = false;
                LinesChartArea.AxisY.LineWidth = 0;

                // Horizontal Axis (time)
                LinesChartArea.AxisX.Interval = 1;
                LinesChartArea.AxisX.IntervalType = DateTimeIntervalType.Milliseconds;
                LinesChartArea.AxisX.LineColor = Color.Black;

                #endregion

                #region rangesChartArea 

                // RangesChartArea is used by all the Complex Objects series
                // In this chart area the axes are inverted (X and Y) due to the RangeBar
                RangesChartArea.BackColor = Color.Transparent;

                // Vertical Axis (Performance Counters)
                RangesChartArea.AxisX.LabelStyle = als;
                RangesChartArea.AxisX.IsLabelAutoFit = false;
                RangesChartArea.AxisX.LineWidth = 0;

                // Horizontal Axis (time)
                RangesChartArea.AxisY.Interval = 1;
                RangesChartArea.AxisY.IntervalType = DateTimeIntervalType.Milliseconds;
                RangesChartArea.AxisY.LineColor = Color.Black;

                #endregion
            }

            private void ClearChartAreas()
            {
                LinesChartArea.AxisX.CustomLabels.Clear();
                LinesChartArea.AxisX.StripLines.Clear();
                LinesChartArea.AxisY.CustomLabels.Clear();
                LinesChartArea.AxisY.StripLines.Clear();
                LinesChartArea.BackColor = ZoomMode ? Color.LightYellow : Color.White;

                RangesChartArea.AxisX.CustomLabels.Clear();
                RangesChartArea.AxisX.StripLines.Clear();
                RangesChartArea.AxisY.CustomLabels.Clear();
                RangesChartArea.AxisY.StripLines.Clear();
            }

            private void ClearChartSeries()
            {
                // Remove all serie points
                foreach (Series serie in TimelineChart.Series)
                {                  
                    serie.Points.SuspendUpdates();
                    serie.Points.Clear(); 
                    serie.Points.ResumeUpdates();
                }
            }

            private void ClearChartSeries(Series serie)
            {
                // Remove serie points
                serie.Points.SuspendUpdates();
                serie.Points.Clear(); //Force refresh.
                serie.Points.ResumeUpdates();

                var stripLineToRemove = _stripLinesInCurrentRange.Where((s) => s.Tag == serie).ToList();
                if (stripLineToRemove != null)
                {
                    foreach (StripLine stripLine in stripLineToRemove)
                        _stripLinesInCurrentRange.Remove(stripLine);
                }

                var labelsToRemove = _customLabelsInCurrentRange.Where((s) => s.Tag == serie).ToList();
                if (labelsToRemove != null)
                {
                    foreach (CustomLabel label in labelsToRemove)
                        _customLabelsInCurrentRange.Remove(label);
                }
            }

            private void ResetAxesRanges()
            {
                LinesChartArea.AxisY.Maximum = linesChartAreaAxisYMaximum;

                LinesChartArea.AxisX.Minimum = ChartBeginTime.ToOADate() - AxisXOffset;
                LinesChartArea.AxisX.Maximum = ChartEndTime.ToOADate() + AxisXOffset;

                RangesChartArea.AxisX.Maximum = rangesChartAreaAxisXMaximum;

                RangesChartArea.AxisY.Minimum = ChartBeginTime.ToOADate() - AxisXOffset;
                RangesChartArea.AxisY.Maximum = ChartEndTime.ToOADate() + AxisXOffset;
            }

            private void ResetChart()
            {
                ClearChartAreas();
                ClearChartSeries();
                ResetAxesRanges();

                ResetChartAreaSelection();
                //UpdateTimelineLabelMessage();
                ResetChartBoundaries();
            }

            private void InitializeChartEvents()
            {
                TimelineChart.MouseDown += TimelineChart_MouseDown;
                TimelineChart.MouseMove += TimelineChart_MouseMove;
                TimelineChart.MouseUp += TimelineChart_MouseUp;

                TimelinePanelZoom.Paint += TimelinePanelZoom_Paint;

                TimelineButtonZoom.Tag = AnalysisType == AnalysisTypes.Cold ? Properties.Settings.Default.ColdCacheColor : Properties.Settings.Default.WarmCacheColor;
                TimelineButtonZoom.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
                TimelineButtonZoom.FlatAppearance.MouseOverBackColor = TimelineButtonZoom.BackColor;

                TimelineButtonZoom.MouseDown += TimelineButtonZoom_MouseDown;
                TimelineButtonZoom.MouseMove += TimelineButtonZoom_MouseMove;
                TimelineButtonZoom.MouseUp += TimelineButtonZoom_MouseUp;
                TimelineButtonZoom.MouseEnter += Extension.OnFlatTimelineZoomButton_MouseEnter;
                TimelineButtonZoom.MouseLeave += Extension.OnFlatTimelineZoomButton_MouseLeave;
            }

            private void InitializeChart()
            {
                TimelineChart.AntiAliasing = AntiAliasingStyles.None;
                TimelineButtonZoom.Text = string.Empty;
                TimelineChart.Series.Clear();
                InitializeChartAreas();

                ClearChartAreas();
                ClearChartSeries();
                ResetAxesRanges();

                InitializeChartEvents();

                ResetChartAreaSelection();
                UpdateTimelineLabelMessage();
                ResetChartBoundaries();
            }

            private void ResetChartAreaSelection()
            {
                LinesChartArea.CursorX.SelectionStart = LinesChartArea.CursorX.SelectionEnd;
                LinesChartArea.CursorY.SelectionStart = LinesChartArea.CursorY.SelectionEnd;
                _selectionStartTime = ChartBeginTime;
                _selectionEndTime = ChartBeginTime;

                ResetTimelineLabelSelectionDuration();
            }

            private void ResetChartBoundaries()
            {
                string ChartLabelTemplate = "";
                CustomLabel labelBegin;
                CustomLabel labelEnd;
                ChartArea chartArea;
                Color LabelColor = TimelineColor;
                Color LineColor = TimelineColor;
                int LineWidth = 2;

                var serieChartBoundaries = TimelineChart.Series.FindByName("ChartBoundaries");
                if (serieChartBoundaries == null)
                {
                    serieChartBoundaries = new Series("ChartBoundaries");
                    serieChartBoundaries.ChartType = SeriesChartType.Line;
                    serieChartBoundaries.ChartArea = LinesChartArea.Name;
                    serieChartBoundaries.Enabled = true; 
                    TimelineChart.Series.Add(serieChartBoundaries);
                }
                else
                {
                    // Remove serie points
                    serieChartBoundaries.Points.SuspendUpdates();
                    serieChartBoundaries.Points.Clear(); //Force refresh.
                    serieChartBoundaries.Points.ResumeUpdates();
                }

                // Begin
                int pointIndex = serieChartBoundaries.Points.AddXY(ChartBeginTime, yValue: 0);
                serieChartBoundaries.Points[pointIndex].MarkerSize = 1;

                // End
                pointIndex = serieChartBoundaries.Points.AddXY(ChartEndTime, yValue: 0);
                serieChartBoundaries.Points[pointIndex].MarkerSize = 1;
                
                #region ChartBegin line

                ChartLabelTemplate = !ZoomMode ? "Query Begin {0:HH:mm:ss.fff}" : "Zoom begin {0:HH:mm:ss.fff}";
                
                chartArea = LinesChartArea;
                labelBegin = chartArea.AxisX.CustomLabels.Add(
                    ChartBeginTime.ToOADate() - ChartLabelsXOffset,
                    ChartBeginTime.ToOADate() + ChartLabelsXOffset,
                    ChartLabelTemplate.FormatWith(ChartBeginTime),
                    0,
                    LabelMarkStyle.LineSideMark);
                labelBegin.GridTicks = GridTickTypes.Gridline;
                labelBegin.ForeColor = LabelColor;
                labelBegin.Tag = serieChartBoundaries;

                chartArea.AxisX.StripLines.Add(item: new StripLine()
                {
                    BorderWidth = LineWidth,
                    BorderColor = LineColor,
                    BorderDashStyle = ChartDashStyle.Solid,
                    IntervalOffset = ChartBeginTime.ToOADate(),
                    Tag = serieChartBoundaries
                });

                // This has to be drawn otherwise with no CustomLabels on the RangesChartArea all the "default" labels would be drawn 
                chartArea = RangesChartArea;
                labelBegin = chartArea.AxisY.CustomLabels.Add(
                    ChartBeginTime.ToOADate() - ChartLabelsXOffset,
                    ChartBeginTime.ToOADate() + ChartLabelsXOffset,
                    ChartLabelTemplate.FormatWith(ChartBeginTime),
                    0,
                    LabelMarkStyle.LineSideMark);
                labelBegin.GridTicks = GridTickTypes.Gridline;
                labelBegin.ForeColor = LabelColor;
                labelBegin.Tag = serieChartBoundaries;

                #endregion

                #region ChartEnd line

                ChartLabelTemplate = !ZoomMode ? "Query End {0:HH:mm:ss.fff}" : "Zoom end {0:HH:mm:ss.fff}";

                chartArea = LinesChartArea;
                labelEnd = chartArea.AxisX.CustomLabels.Add(
                    ChartEndTime.ToOADate() - ChartLabelsXOffset,
                    ChartEndTime.ToOADate() + ChartLabelsXOffset,
                    ChartLabelTemplate.FormatWith(ChartEndTime),
                    0,
                    LabelMarkStyle.LineSideMark
                    );
                labelEnd.GridTicks = GridTickTypes.Gridline;
                labelEnd.ForeColor = LabelColor;
                labelEnd.Tag = serieChartBoundaries;

                chartArea.AxisX.StripLines.Add(item: new StripLine()
                {
                    BorderWidth = LineWidth,
                    BorderColor = LineColor,
                    BorderDashStyle = ChartDashStyle.Solid,
                    IntervalOffset = ChartEndTime.ToOADate(),
                    Tag = serieChartBoundaries
                });

                // This has to be drawn otherwise with no CustomLabels on the RangesChartArea all the "default" labels would be drawn 
                chartArea = RangesChartArea;
                labelEnd = chartArea.AxisY.CustomLabels.Add(
                    ChartEndTime.ToOADate() - ChartLabelsXOffset,
                    ChartEndTime.ToOADate() + ChartLabelsXOffset,
                    ChartLabelTemplate.FormatWith(ChartEndTime),
                    0,
                    LabelMarkStyle.LineSideMark
                    );
                labelEnd.GridTicks = GridTickTypes.Gridline;
                labelEnd.ForeColor = LabelColor;
                labelEnd.Tag = serieChartBoundaries;

                #endregion                
            }

            private void UpdateTimelineLabelMessage(bool isZoomOut = false)
            {
                var iconInfo = SystemIcons.Information.ToBitmap();
                var iconWarning = SystemIcons.Warning.ToBitmap();
                var iconZoom = Properties.Resources.ZoomMode_16x16;
                TimelinePanelMessagePictureBox.Image = ZoomMode ? iconZoom : iconInfo;
                TimelinePanelZoom.Parent.Visible = ZoomMode;
                if (zoomMoving)
                {
                    var zoomDuration = TimeSpan.FromMilliseconds(_zoomDuration).ToFormattedTime();
                    TimelineLabelMessage.Text = "Zoom range start at: {0:HH:mm:ss.fff} - Zoom range end at {1:HH:mm:ss.fff} - Duration: {2}".FormatWith(ChartBeginTime, ChartEndTime, zoomDuration);
                    TimelinePanelMessage.Visible = true;
                    return;
                }

                if (Settings.Default.TimelineEventsNumberThreshold > 0)
                {
                    TimelinePanelMessagePictureBox.Image = ThresholdCurrentObjectsAvailable > 0 ? TimelinePanelMessagePictureBox.Image : iconWarning;
                    TimelineLabelMessage.ForeColor = ThresholdCurrentObjectsAvailable > 0 ? Color.Black : Color.Red;
                    TimelinePanelMessage.BackColor = ThresholdCurrentObjectsAvailable > 0 ? Color.White : Color.Yellow;
                }

                var messageText = string.Empty;
                if (Settings.Default.TimelineEventsNumberThreshold > 0)
                    messageText += "Threshold value: {0} - ".FormatWith(Settings.Default.TimelineEventsNumberThreshold);

                messageText +=  "Selected objects : {0}".FormatWith(ThresholdCurrentObjectsSelected);
                if (Settings.Default.TimelineEventsNumberThreshold > 0)
                    messageText += ThresholdCurrentObjectsAvailable == 0 ? " - No more objects selectable" : " - Still selectable: {0}".FormatWith(ThresholdCurrentObjectsAvailable);

                TimelineLabelMessage.Text = messageText;
                TimelinePanelMessage.Visible = true;
            }

            public void ResetTimelineLabelSelectionDuration()
            {
                var text = "No selection!";
                var visible = false;

                if (SelectionDuration > 0)
                {
                    text = "Selection start at: {0:HH:mm:ss.fff} - Selection end at: {1:HH:mm:ss.fff} - Duration: {2}".FormatWith(SelectionStartTime, SelectionEndTime, SelectionDurationString);
                    visible = true;
                }
                else if (SelectionDuration < 0)
                {
                    text = "Selection start at: {0:HH:mm:ss.fff} - Selection end at: {1:HH:mm:ss.fff} - Duration: {2}".FormatWith(SelectionEndTime, SelectionStartTime, SelectionDurationString);
                    visible = true;
                }

                if (TimelineLabelSelectionDuration.Text.Equals(text, StringComparison.InvariantCultureIgnoreCase))
                    return;

                TimelineLabelSelectionDuration.Visible = visible;
                TimelineLabelSelectionDuration.Text = text;
                TimelineLabelSelectionDuration.Refresh();
            }

            #region [ Execution Timeline Chart - Zoom Area ]

            private void RefreshChartBoundary()
            {
                int leftSpace = (TimelineButtonZoom.Left - _timeLineStart);
                double leftMilliSeconds = (double)leftSpace * (double)_timeEntityPerPixelTotal;

                int buttonZoomRight = TimelineButtonZoom.Left + TimelineButtonZoom.Width;
                int rightSpace = (_timeLineStop - buttonZoomRight);
                double rightMilliSeconds = (double)rightSpace * (double)_timeEntityPerPixelTotal;

                ChartBeginTime = QueryBeginTime.AddMilliseconds(leftMilliSeconds);
                ChartEndTime = QueryEndTime.AddMilliseconds(rightMilliSeconds * -1);
            }

            private void TimelineZoomCompletePaint()
            {
                if (ZoomMode)
                {
                    if (_zoomedAreaWidth < 5)
                        _zoomedAreaWidth = 5;

                    InitializeTimelineZoom();
                    TimelineZoomPartialPaint();
                }
            }

            private void TimelineZoomPartialPaint()
            {
                if (ZoomMode)
                {
                    #region Cancel timeline

                    // Draw a white line with Height = TimelinePanelZoom.Height and length as the timeline (excluded the vertical line)
                    _cancelPen = new Pen(Color.White, _heightCancelLine);
                    _graphicsObj.DrawLine(_cancelPen,
                                          0,
                                          _yCenterCancelLine,
                                          TimelinePanelZoom.Width,
                                          _yCenterCancelLine);

                    #endregion

                    #region Draw timeline

                    _timeLinePen = new Pen(TimelineColor, _heightTimeLine);
                    // Draw Time line
                    _graphicsObj.DrawLine(_timeLinePen,
                                          _timeLineStart,
                                          _yCenterTimeLine,
                                          _timeLineStop,
                                          _yCenterTimeLine);

                    #endregion

                    #region Draw timeline boundary

                    _timeLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    // Draw vertical line at begin
                    _graphicsObj.DrawLine(_timeLinePen, _timeLineStart, _yCenterTimeLine - _halfHeightVerticalLines, _timeLineStart, _yCenterTimeLine + (_halfHeightVerticalLines * 2));
                    // Draw vertical line at end
                    _graphicsObj.DrawLine(_timeLinePen, _timeLineStop, _yCenterTimeLine - _halfHeightVerticalLines, _timeLineStop, _yCenterTimeLine + (_halfHeightVerticalLines * 2));

                    #endregion

                    #region Draw button vertical line

                    _timeLinePen = new Pen(TimelineColor, _heightTimeLine);
                    _timeLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    int beginVerticalLine_X = TimelineButtonZoom.Left;
                    int endVerticalLine_X = TimelineButtonZoom.Left + TimelineButtonZoom.Width - 1;

                    // Draw vertical line at begin
                    _graphicsObj.DrawLine(_timeLinePen, beginVerticalLine_X, _yCenterTimeLine - _halfHeightVerticalLines, beginVerticalLine_X, _yCenterTimeLine + (_halfHeightVerticalLines * 2));
                    // Draw vertical line at end
                    _graphicsObj.DrawLine(_timeLinePen, endVerticalLine_X, _yCenterTimeLine - _halfHeightVerticalLines, endVerticalLine_X, _yCenterTimeLine + (_halfHeightVerticalLines * 2));

                    #endregion

                    #region Draw button time text
                    if (TimelineButtonZoom.Width > _zoomDurationTextWidth + 2)
                    {
                        int XzoomDurationTextPoint = TimelineButtonZoom.Left + (TimelineButtonZoom.Width - _zoomDurationTextWidth) / 2;
                        int YzoomDurationTextPoint = _halfHeightVerticalLines * 2;
                        Point zoomDurationTextPoint = new Point(XzoomDurationTextPoint, YzoomDurationTextPoint);
                        _graphicsObj.DrawString(_zoomDurationText, _zoomDurationLabelFont, _zoomDurationLabelBrush, zoomDurationTextPoint);
                    }
                    #endregion

                    #region Draw left time string

                    string leftDurationTimeText = "<- {0} ->".FormatWith(ChartBeginTime.Subtract(QueryBeginTime).ToFormattedTime());
                    int leftSpace = (TimelineButtonZoom.Left - _timeLineStart);
                    int leftDurationTimeTextWidth = TextRenderer.MeasureText(leftDurationTimeText, _zoomDurationLabelFont).Width;

                    if (leftSpace > leftDurationTimeTextWidth + 2)
                    {
                        int leftXDurationTextPoint = ((leftSpace - leftDurationTimeTextWidth) / 2) + _xOffset;
                        int leftDurationTextHeight = TextRenderer.MeasureText(leftDurationTimeText, _zoomDurationLabelFont).Height;
                        int leftYDurationTextPoint = _halfHeightVerticalLines * 2;
                        Point leftTextPoint = new Point(leftXDurationTextPoint, leftYDurationTextPoint);
                        _graphicsObj.DrawString(leftDurationTimeText, _zoomDurationLabelFont, _zoomDurationLabelBrush, leftTextPoint);
                    }

                    #endregion

                    #region Draw right time string

                    string rightDurationTimeText = "<- {0} ->".FormatWith(QueryEndTime.Subtract(ChartEndTime).ToFormattedTime());
                    int buttonZoomRight = TimelineButtonZoom.Left + TimelineButtonZoom.Width;
                    int rightSpace = (_timeLineStop - buttonZoomRight);
                    int righDurationTimeTextWidth = TextRenderer.MeasureText(rightDurationTimeText, _zoomDurationLabelFont).Width;

                    if (rightSpace > righDurationTimeTextWidth + 2)
                    {
                        int rightXDurationTextPoint = buttonZoomRight + ((rightSpace - righDurationTimeTextWidth) / 2);
                        int rightDurationTextHeight = TextRenderer.MeasureText(rightDurationTimeText, _zoomDurationLabelFont).Height;
                        int rightYDurationTextPoint = _halfHeightVerticalLines * 2;
                        Point rightDurationTextPoint = new Point(rightXDurationTextPoint, rightYDurationTextPoint);
                        _graphicsObj.DrawString(rightDurationTimeText, _zoomDurationLabelFont, _zoomDurationLabelBrush, rightDurationTextPoint);
                    }

                    #endregion
                }
            }

            private void InitializeTimelineZoom()
            {
                #region Pixels

                _timeLinePixelLength = TimelinePanelZoom.Width - (_xOffset * 2);
                _timeEntityPerPixelTotal = QueryDuration / (double)_timeLinePixelLength;
                // Calculate pixel scaling
                _pixelPerTimeEntityTotal = (double)_timeLinePixelLength / QueryDuration;

                Debug.WriteLine("DEBUG:: InitializeTimelineZoom._timeLinePixelLength = [{0}]", _timeLinePixelLength);

                #endregion

                #region Variables & Objects

                _graphicsObj = TimelinePanelZoom.CreateGraphics();
                _halfHeightVerticalLines = TimelinePanelZoom.Height / 4;
                _yCenterTimeLine = _halfHeightVerticalLines;
                _heightTimeLine = 1;
                _heightZoomButton = _yCenterTimeLine;
                _yCenterCancelLine = _halfHeightVerticalLines * 2;
                _heightCancelLine = TimelinePanelZoom.Height;

                _timeLineStart = _xOffset;
                _timeLineStop = _timeLineStart + _timeLinePixelLength; 


                _zoomedAreaStart = Convert.ToInt32((ZoomMinimumValue * _pixelPerTimeEntityTotal));
                _zoomedAreaStop = Convert.ToInt32((ZoomMaximumValue * _pixelPerTimeEntityTotal));
                _zoomedAreaWidth = _zoomedAreaStop - _zoomedAreaStart;

                #endregion

                #region TimelineButtonZoom

                TimelineButtonZoom.Height = _halfHeightVerticalLines;
                TimelineButtonZoom.Left = _zoomedAreaStart;
                TimelineButtonZoom.Width = _zoomedAreaWidth;
                TimelineButtonZoom.Top = _yCenterTimeLine - (TimelineButtonZoom.Height / 2);

                _zoomDurationText = "<- {0} ->".FormatWith(ZoomDurationString);
                _zoomDurationTextWidth = TextRenderer.MeasureText(_zoomDurationText, _zoomDurationLabelFont).Width;
                _zoomDurationLabelBrush = new SolidBrush(TimelineColor);

                #endregion
            }

            private void MoveTimelineButtonZoom(int pixelXMovement)
            {
                int newLeft = TimelineButtonZoom.Left + pixelXMovement;

                if (TimelineButtonZoom.Left + TimelineButtonZoom.Width + pixelXMovement > _timeLineStop)
                    newLeft = _timeLineStop - TimelineButtonZoom.Width + 1;
                else if (TimelineButtonZoom.Left + pixelXMovement < _timeLineStart)
                    newLeft = _timeLineStart;

                if (newLeft != TimelineButtonZoom.Left)
                    TimelineButtonZoom.Left = newLeft;
            }

            #region Timeline button zoom events

            private void TimelineButtonZoom_MouseDown(object sender, MouseEventArgs e)
            {
                Extension.OnFlatTimelineZoomButton_MouseDown(sender, e);

                if (e.Button != MouseButtons.Left)
                    return;

                MouseOnZoomDowned = true;
                TimelinePanelZoom.Paint -= TimelinePanelZoom_Paint;
                TimelinePanelZoom.Paint += TimelinePanelZoom_PartialPaint;
                _buttonTimeLineXPosition = e.Location.X;
                _buttonLeftPosition = TimelineButtonZoom.Left;
            }

            private void TimelineButtonZoom_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                    return;

                if (MouseOnZoomDowned)
                {
                    int pixelXMovement = e.Location.X - _buttonTimeLineXPosition;
                    if (pixelXMovement != 0)
                    {
                        zoomMoving = true;
                        MoveTimelineButtonZoom(pixelXMovement);
                        RefreshChartBoundary();
                        TimelineButtonZoom.Refresh();
                        ThresholdReachedForCurrentSelectedEvents(considerDisabled: !ZoomMode, isZoomOut: false, isMouseMove: true);
                        zoomMoving = false;
                    }
                }
            }

            private void TimelineButtonZoom_MouseUp(object sender, MouseEventArgs e)
            {
                Extension.OnFlatTimelineZoomButton_MouseUp(sender, e);

                if (e.Button != MouseButtons.Left)
                    return;

                MouseOnZoomDowned = false;
                UpdateExecutionTimeline();

                TimelinePanelZoom.Paint -= TimelinePanelZoom_PartialPaint;
                TimelinePanelZoom.Paint += TimelinePanelZoom_Paint;
            }

            #endregion

            #region Timeline panel zoom events

            private void TimelinePanelZoom_Paint(object sender, PaintEventArgs e)
            {
                TimelineZoomCompletePaint();
            }

            private void TimelinePanelZoom_PartialPaint(object sender, PaintEventArgs e)
            {
                TimelineZoomPartialPaint();
            }

            #endregion

            #endregion

            #region [ Execution Timeline Chart Events ]

            private struct PointD
            {
                public double X;
                public double Y;

                public PointD(double X, double Y)
                {
                    this.X = X;
                    this.Y = Y;
                }
            }

            private bool LocationInChart(double xMouse, double yMouse)
            {
                var ca = LinesChartArea;
                bool inChart = true;

                //Position inside the control, from 0 to 100
                var relPosInControl = new PointD
                (
                  ((double)xMouse / (double)TimelineChart.Width) * 100,
                  ((double)yMouse / (double)TimelineChart.Height) * 100
                );

                //Verify we are inside the Chart Area
                if (relPosInControl.X < ca.Position.X || relPosInControl.X > ca.Position.Right || relPosInControl.Y < ca.Position.Y || relPosInControl.Y > ca.Position.Bottom)
                    inChart = false;

                return inChart;
            }

            private void TimelineChart_MouseDown(object sender, MouseEventArgs e)
            {
                //DateTime startMouseDown = DateTime.Now;

                if (e.Button != MouseButtons.Left)
                {
                    UpdatePoints(e);

                    if (SelectedComplexObject != null)
                    {
                        TimelineChart.ContextMenuStrip = _timeConsumingObjectsMenu;
                        _showComplexObjectInTrace.Text = "Show [{0}] in Trace Events grid".FormatWith(((SelectedComplexObject).ComplexObjectName));
                    }
                    else
                    {
                        TimelineChart.ContextMenuStrip = TimelineChartContextMenu;
                        //UpdateMenus();
                    }

                    return;
                }

                if (LocationInChart(e.Location.X, e.Location.Y))
                {
                    ResetChartAreaSelection();

                    MouseOnChartDowned = true;
                    TimelineLabelSelectionDuration.Text = "";
                    double selY = LinesChartArea.AxisY.Maximum;
                    double selX = LinesChartArea.AxisX.PixelPositionToValue(e.Location.X);

                    if (selX < QueryBeginTime.ToOADate())
                    {
                        selX = QueryBeginTime.ToOADate();
                    }
                    else
                    {
                        if (selX > QueryEndTime.ToOADate())
                            selX = QueryEndTime.ToOADate();
                    }

                    LinesChartArea.CursorX.SelectionStart = selX;
                    LinesChartArea.CursorX.SelectionEnd = selX;
                    ResetTimelineLabelSelectionDuration();
                }

                //DateTime endMouseDown = DateTime.Now;

                //TimeSpan duration = endMouseDown.Subtract(startMouseDown);

                //RegisterTimeExecution("Duration MouseDown: {0} ms", duration);

            }

            private DataPoint GetPointFromHit(HitTestResult hit)
            {
                DataPoint point = null;

                if (hit.ChartElementType == ChartElementType.DataPoint)
                {
                    if ((string)hit.Series.ChartArea == RangesChartArea.Name)
                        point = (DataPoint)hit.Series.Points[hit.PointIndex];
                }

                return point;
            }

            //private ComplexObject GetComplexObjectFromDataPoint(DataPoint point, Series serie)
            //{
            //    //DateTime startGetComplexObjectFromDataPoint = DateTime.Now;

            //    if (SelectedComplexObject != null)
            //        return null;

            //    var beginTime = point.YValues[0];
            //    var endTime = point.YValues[1];

            //    switch ((SeriesType)serie.Tag)
            //    {
            //        case SeriesType.Aggregation:
            //            foreach (var item in AggregationComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            break;
            //        case SeriesType.Partition:
            //            foreach (var item in PartitionComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            break;
            //        case SeriesType.Serialization:
            //            foreach (var item in SerializeGlobalComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            foreach (var item in SerializeAxesComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            foreach (var item in SerializeCellsComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            break;
            //        case SeriesType.Cache:
            //            foreach (var item in CacheComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            break;
            //        case SeriesType.Measure:
            //            foreach (var item in MeasureComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            break;
            //        case SeriesType.Dimension:
            //            foreach (var item in DimensionComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            break;
            //        case SeriesType.NonEmpty:
            //            foreach (var item in NonEmptyGlobalComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            foreach (var item in NonEmptyGetDataComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            foreach (var item in NonEmptyPostOrderComplexObjectsInCurrentRange)
            //                if (item.ComplexObjectName == serie.Name && item.BeginEventTimeOADate == beginTime && item.EndEventTimeOADate == endTime)
            //                    return item;
            //            break;
            //        case SeriesType.MultipleObjects:
            //        case SeriesType.Profiler:
            //        case SeriesType.Performance:
            //        default:
            //            break;
            //    }
 
            //    //DateTime endGetComplexObjectFromDataPoint = DateTime.Now;

            //    //TimeSpan duration = endGetComplexObjectFromDataPoint.Subtract(startGetComplexObjectFromDataPoint);

            //    //RegisterTimeExecution("Duration GetComplexObjectFromDataPoint: {0} ms", duration);

            //    return null;
            //}

            private void UpdateTooltip(Series serie)
            {
                serie.ToolTip = "Object Name:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectName);
                serie.ToolTip += "\r\nObject ID:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectID);
                serie.ToolTip += "\r\nObject Type:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectType);
                serie.ToolTip += "\r\nObject Subtype:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectSubType);
                serie.ToolTip += "\r\nObject Visible:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectVisible ?? "N/A");
                serie.ToolTip += "\r\nText Data:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectTextData);

                if (SelectedComplexObject.BeginEventID > -1)
                    serie.ToolTip += "\r\nBegin Event ID:\t\t{0}".FormatWith(SelectedComplexObject.BeginEventID);
                else
                    serie.ToolTip += "\r\nBegin Event ID:\t\tN/A";

                serie.ToolTip += "\r\nBegin Event Time:\t\t{0:HH:mm:ss.fff}".FormatWith(SelectedComplexObject.BeginEventTime);

                if (SelectedComplexObject.EndEventID > -1)
                    serie.ToolTip += "\r\nEnd Event ID:\t\t{0}".FormatWith(SelectedComplexObject.EndEventID);
                else
                    serie.ToolTip += "\r\nEnd Event ID:\t\tN/A";

                serie.ToolTip += "\r\nEnd Event Time:\t\t{0:HH:mm:ss.fff}".FormatWith(SelectedComplexObject.EndEventTime);

                if (SelectedComplexObject.ComplexObjectProgressTotal > -1)
                    serie.ToolTip += "\r\nProgress total:\t\t{0} {1}".FormatWith(SelectedComplexObject.ComplexObjectProgressTotal, SelectedComplexObject.ComplexObjectProgressTotalUnitMeasure);
                else
                    serie.ToolTip += "\r\nProgress total:\t\tN/A";

                if (SelectedComplexObject.ComplexObjectDuration > -1)
                    serie.ToolTip += "\r\nDuration:\t\t{0} ms".FormatWith(SelectedComplexObject.ComplexObjectDuration);
                else
                    serie.ToolTip += "\r\nDuration:\t\tN/A";

                if (SelectedComplexObject.ComplexObjectReadDuration > -1)
                    serie.ToolTip += "\r\nRead Duration:\t\t{0} ms".FormatWith(SelectedComplexObject.ComplexObjectReadDuration);
                else
                    serie.ToolTip += "\r\nRead Duration:\t\tN/A";

                serie.ToolTip += "\r\nPath:\t\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectPath);
                serie.ToolTip += "\r\nMeasure Group ID:\t{0}".FormatWith(SelectedComplexObject.MeasureGroupID);
            }

            private void UpdatePoints(MouseEventArgs e)
            {

                //SelectedComplexObject = null;

                var hit = TimelineChart.HitTest(e.Location.X, e.Location.Y);
                var hitPoint = GetPointFromHit(hit);
                if (hitPoint == _selectedpoint)
                    return;
                else
                {
                    SelectedComplexObject = null;
                    DeHighlightPoint(_selectedpoint);
                    _selectedpoint = hitPoint;
                }
                if (hitPoint != null)
                {

                    //var complexObject = GetComplexObjectFromDataPoint(hitPoint, hit.Series);
                    SelectedComplexObject = (ComplexObject)hitPoint.Tag;
                    if (SelectedComplexObject != null)
                    {
                        Debug.WriteLine("SelectedComplexObject: " + SelectedComplexObject.ComplexObjectName);

                        HighlightPoint(hitPoint);

                        UpdateTooltip(hit.Series);

                    }
                }

                //DateTime endUpdatePoints = DateTime.Now;

                //TimeSpan duration = endUpdatePoints.Subtract(startUpdatePoints);

                //RegisterTimeExecution("Duration UpdatePoints: {0} ms", duration);

            }

            //private void UpdatePoints(MouseEventArgs e)
            //{
            //    //DateTime startUpdatePoints = DateTime.Now;

            //    #region De-higlight all series points

            //    SelectedComplexObject = null;

            //    foreach (Series serie in TimelineChart.Series)
            //    {
            //        if (serie.ChartArea == RangesChartArea.Name)
            //        {
            //            foreach (DataPoint point in serie.Points)
            //            {
            //                if (point.Color == Settings.Default.HighlightColor)
            //                    point.Color = point.BackSecondaryColor;

            //                point.BackSecondaryColor = Color.White;
            //                point.BackHatchStyle = ChartHatchStyle.None;
            //                point.BorderWidth = 1;
            //            }
            //        }
            //    }

            //    #endregion

            //    #region Highlight series points

            //    var hit = TimelineChart.HitTest(e.Location.X, e.Location.Y);
            //    var hitPoint = GetPointFromHit(hit);
            //    if (hitPoint != null)
            //    {
            //        var complexObject = GetComplexObjectFromDataPoint(hitPoint, hit.Series);
            //        if (complexObject != null)
            //        {
            //            HighlightPoint(hitPoint);

            //            SelectedComplexObject = complexObject;
                        
            //            hit.Series.ToolTip = "Object Name:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectName);
            //            hit.Series.ToolTip += "\r\nObject ID:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectID);
            //            hit.Series.ToolTip += "\r\nObject Type:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectType);
            //            hit.Series.ToolTip += "\r\nObject Subtype:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectSubType);
            //            hit.Series.ToolTip += "\r\nObject Visible:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectVisible ?? "N/A");
            //            hit.Series.ToolTip += "\r\nText Data:\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectTextData);

            //            if (SelectedComplexObject.BeginEventID > -1)
            //                hit.Series.ToolTip += "\r\nBegin Event ID:\t\t{0}".FormatWith(SelectedComplexObject.BeginEventID);
            //            else
            //                hit.Series.ToolTip += "\r\nBegin Event ID:\t\tN/A";

            //            hit.Series.ToolTip += "\r\nBegin Event Time:\t{0:HH:mm:ss.fff}".FormatWith(SelectedComplexObject.BeginEventTime);

            //            if (SelectedComplexObject.EndEventID > -1)
            //                hit.Series.ToolTip += "\r\nEnd Event ID:\t\t{0}".FormatWith(SelectedComplexObject.EndEventID);
            //            else
            //                hit.Series.ToolTip += "\r\nEnd Event ID:\t\tN/A";

            //            hit.Series.ToolTip += "\r\nEnd Event Time:\t\t{0:HH:mm:ss.fff}".FormatWith(SelectedComplexObject.EndEventTime);

            //            if (SelectedComplexObject.ComplexObjectProgressTotal > -1)
            //                hit.Series.ToolTip += "\r\nProgress total:\t\t{0} {1}".FormatWith(SelectedComplexObject.ComplexObjectProgressTotal, SelectedComplexObject.ComplexObjectProgressTotalUnitMeasure);
            //            else
            //                hit.Series.ToolTip += "\r\nProgress total:\t\tN/A";

            //            if (SelectedComplexObject.ComplexObjectDuration > -1)
            //                hit.Series.ToolTip += "\r\nDuration:\t\t{0} ms".FormatWith(SelectedComplexObject.ComplexObjectDuration);
            //            else
            //                hit.Series.ToolTip += "\r\nDuration:\t\tN/A";

            //            if (SelectedComplexObject.ComplexObjectReadDuration > -1)
            //                hit.Series.ToolTip += "\r\nRead Duration:\t\t{0} ms".FormatWith(SelectedComplexObject.ComplexObjectReadDuration);
            //            else
            //                hit.Series.ToolTip += "\r\nRead Duration:\t\tN/A";

            //            hit.Series.ToolTip += "\r\nPath:\t\t\t{0}".FormatWith(SelectedComplexObject.ComplexObjectPath);
            //            hit.Series.ToolTip += "\r\nMeasure Group ID:\t{0}".FormatWith(SelectedComplexObject.MeasureGroupID);
            //        }
            //    }

            //    //DateTime endUpdatePoints = DateTime.Now;

            //    //TimeSpan duration = endUpdatePoints.Subtract(startUpdatePoints);

            //    //RegisterTimeExecution("Duration UpdatePoints: {0} ms", duration);
                
            //    #endregion
            //}

            private void DeHighlightPoint(DataPoint point)
            {
                if (point != null)
                {
                    if (point.Color == Settings.Default.HighlightColor)
                    {
                        point.Color = _selectedpoint.BackSecondaryColor;
                        point.BackSecondaryColor = Color.White;
                        point.BackHatchStyle = ChartHatchStyle.None;
                        point.BorderWidth = 1;
                    }
                }
            }

            private void HighlightPoint(DataPoint point)
            {
                if (point.Color != Color.White && point.Color != Settings.Default.HighlightColor)
                {
                    point.BackSecondaryColor = point.Color;
                    point.Color = Settings.Default.HighlightColor;
                    point.BorderWidth = 2;
                }
            }

            private void TimelineChart_MouseMove(object sender, MouseEventArgs e)
            {
                if (MouseOnChartDowned)
                {
                    if (LocationInChart(e.Location.X, e.Location.Y))
                    {
                        double selY = LinesChartArea.AxisY.Maximum;
                        double selX = LinesChartArea.AxisX.PixelPositionToValue(e.Location.X);

                        if (selX < QueryBeginTime.ToOADate())
                            selX = QueryBeginTime.ToOADate();
                        else
                        {
                            if (selX > QueryEndTime.ToOADate())
                                selX = QueryEndTime.ToOADate();
                        }

                        LinesChartArea.CursorX.SelectionEnd = selX;
                        LinesChartArea.CursorY.SelectionEnd = selY;
                        ResetTimelineLabelSelectionDuration();
                    }

                    return;
                }

                UpdatePoints(e);
            }

            private void TimelineChart_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                    return;

                MouseOnChartDowned = false;
            }

            #endregion

            #endregion

            #region [ Multiple Objects ]

            private void InitializeMultipleObjectsSerie()
            {
                _multipleObjectsSerie = TimelineChart.Series.FindByName("Multiple Objects");
                if (_multipleObjectsSerie == null)
                {
                    _multipleObjectsSerie = new Series("Multiple Objects");
                    _multipleObjectsSerie.ChartType = SeriesChartType.Line;
                    _multipleObjectsSerie.ChartArea = LinesChartArea.Name;
                    _multipleObjectsSerie.Enabled = true;
                    _multipleObjectsSerie.Color = Color.Transparent;
                    TimelineChart.Series.Add(_multipleObjectsSerie);
                }
                else
                {
                    ClearChartSeries(_multipleObjectsSerie);
                }
            }

            #endregion

            #region [ ProfilerEvents ]

            private Series CreateProfilerEventsTimelineChartSeries(ToolStripMenuItem menuItem, SeriesType serieType, string serieName, Color serieColor)
            {
                var serie = TimelineChart.Series.FindByName(serieName);
                if (serie == null)
                {
                    serie = new Series(serieName);
                    serie.ChartType = SeriesChartType.Line;
                    serie.ChartArea = LinesChartArea.Name;
                    serie.Color = serieColor;
                    serie.Enabled = false;
                    serie.ToolTip = serieName;
                    serie.Tag = serieType;
                    TimelineChart.Series.Add(serie);
                    CreateContextMenuItem(menuItem, serie, serieType);
                }

                return serie;
            }

            private void InitializeProfilerEventsInCurrentRange()
            {
                ProfilerEventsInWholeQuery = ProfilerEvents.AsParallel()
                    .SelectMany((e) => e)
                    .Where((p) => (p.EventClass != TraceEventClass.QueryBegin) && (p.EventClass != TraceEventClass.QueryEnd))
                    .ToList();

                ProfilerEventsInCurrentRange = ProfilerEventsInWholeQuery.ToList();

                var queryEventClasses = ProfilerEventsInCurrentRange
                    .Where((i) => i.EventClass.HasValue)
                    .Select((i) => i.EventClass.Value)
                    .Distinct()
                    .OrderBy((c) => c.ToName());

                foreach (TraceEventClass eventClass in queryEventClasses)
                {
                    var serie = CreateProfilerEventsTimelineChartSeries(_profilerMenuItem,
                                                                        SeriesType.Profiler,
                                                                        eventClass.ToName(),
                                                                        //ResultPresenterConfiguration.DefaultProfilerEventsColor
                                                                        Color.Transparent
                                                                        );
                }
            }

            private void InitializeProfilerEvents()
            {
                InitializeProfilerEventsInCurrentRange();

                UpdateProfilerEventsContextMenuItems(ProfilerEventsInCurrentRange, _profilerMenuItem, SeriesType.Profiler);
            }

            private void UpdateProfilerEvents()
            {
                UpdateProfilerEventsInCurrentRange();

                UpdateProfilerEventsContextMenuItems(ProfilerEventsInCurrentRange, _profilerMenuItem, SeriesType.Profiler);

                UpdateObjectsAllChartSeries(SeriesType.Profiler);
            }

            private void UpdateProfilerEventsInCurrentRange()
            {
                ProfilerEventsInCurrentRange = ExecutionResult.Profilers.AsParallel()
                    .SelectMany((e) => e)
                    .Where((p) => p.CurrentTime.Value >= ChartBeginTime && p.CurrentTime.Value <= ChartEndTime)
                    .ToList();
            }

            private void UpdateProfilerEventsContextMenuItems(List<ProfilerItem> profilerEventsList, ToolStripMenuItem parentMenuItem, SeriesType seriesType)
            {
                var menuItemsCounter = profilerEventsList
                   .Where((e) => e.EventClass.HasValue)
                   .GroupBy((e) => e.EventClass)
                   .Select((g) => new MenuItemsCounter
                   {
                       MenuName = g.Min((p) => p.EventClass.ToString()),
                       MenuCounter = g.Count()
                   })
                   .ToList();

                UpdateAllContextMenuItems(menuItemsCounter, parentMenuItem, seriesType);
            }

            private void LoadProfilerEvents(Series serie)
            {
                TimelineChart.SuspendLayout();
                serie.Points.SuspendUpdates();

                var queryEventsInTimeRange = ProfilerEventsInCurrentRange.AsParallel()
                    .Where((e) => e.EventClass.ToString() == serie.Name);

                var isNotQueryBegin = serie.Name != TraceEventClass.QueryBegin.ToName();

                foreach (var eventTime in queryEventsInTimeRange.ToList())
                {                    
                    AddProfilerEventsPoint(
                        serie: serie,
                        drawLabel: isNotQueryBegin,
                        labelText: "[{0}] {1} {2:HH:mm:ss.fff}".FormatWith(eventTime.ID, serie.Name, eventTime.CurrentTime),
                        labelColor: Settings.Default.ProfilerEventsColor,
                        drawLine: isNotQueryBegin,
                        lineColor: Settings.Default.ProfilerEventsColor,
                        time: eventTime.CurrentTime.Value,
                        timeOADate: eventTime.CurrentTime.Value.ToOADate(),
                        ID: eventTime.ID,
                        value: 0
                        );
                }

                serie.Points.ResumeUpdates();
                TimelineChart.ResumeLayout();
            }

            private void AddProfilerEventsPoint(Series serie, bool drawLabel, string labelText, Color labelColor, bool drawLine, Color lineColor, DateTime time, Double timeOADate, int ID, long value)
            {
                ProfilerItem profilerItemToLoad = null;
                if (FilteredProfilerEvents.Count > 0)
                    profilerItemToLoad = FilteredProfilerEvents.Where((i) => i.ID == ID).SingleOrDefault();

                if (profilerItemToLoad != null || FilteredProfilerEvents.Count == 0)
                {
                    int pointIndex = serie.Points.AddXY(xValue: time, yValue: value);
                    serie.Points[pointIndex].MarkerSize = 1;

                    if (drawLabel)
                    {
                        var label = new CustomLabel();
                        label.FromPosition = timeOADate - ChartLabelsXOffset;
                        label.ToPosition = timeOADate + ChartLabelsXOffset;
                        label.Text = labelText;
                        label.RowIndex = 0;
                        label.LabelMark = LabelMarkStyle.LineSideMark;
                        label.GridTicks = GridTickTypes.Gridline;
                        label.ForeColor = labelColor;
                        label.Tag = serie;
                        _customLabelsInCurrentRange.Add(label);
                    }

                    if (drawLine)
                    {
                        var stripLine = new StripLine();
                        stripLine.BorderColor = lineColor;
                        stripLine.BorderDashStyle = ChartDashStyle.Solid;
                        stripLine.BorderWidth = 1;
                        stripLine.IntervalOffset = timeOADate;
                        stripLine.Tag = serie;
                        _stripLinesInCurrentRange.Add(stripLine);
                    }
                }
            }

            #endregion

            #region [ Performance Counters ]

            private Series CreatePerformanceCountersTimelineChartSeries(ToolStripMenuItem menuItem, SeriesType serieType, string serieName, bool serieEnabled, Color serieColor)
            {
                var serie = TimelineChart.Series.FindByName(serieName);
                if (serie == null)
                {
                    serie = new Series(serieName);
                    serie.ChartType = SeriesChartType.Line;
                    serie.ChartArea = LinesChartArea.Name;
                    serie.Color = serieColor;
                    serie.ToolTip = serieName;
                    serie.Tag = serieType;
                    serie.Enabled = serieEnabled;
                    if (serieEnabled)
                        CurrentPerformanceCounterSerie = serie;
                    TimelineChart.Series.Add(serie);
                    var contextMenuItem = CreateContextMenuItem(menuItem, serie, serieType);
                    contextMenuItem.Checked = serieEnabled;
                }

                return serie;
            }

            private void InitializePerformanceSeries()
            {
                int counter = 0;
                foreach (string counterName in ExecutionResult.Performances.CounterFullNames.OrderBy((n) => n))
                {
                    Series serie = CreatePerformanceCountersTimelineChartSeries(_performanceCountersMenuItem,
                                                    SeriesType.Performance,
                                                    counterName,
                                                    counter == 0,
                                                    ResultPresenterConfiguration.DefaultPerformanceCountersColor);
                    counter++;
                }

                //UpdateAllFixedContextMenuItems(_performanceCountersMenuItem, SeriesType.Performance);
            }

            private void DrawPerformanceCountersOnChart(Series serie)
            {
                TimelineChart.SuspendLayout();
                serie.Points.SuspendUpdates();

                var stripLinesInCurrentRange_Copy = LinesChartArea.AxisX.StripLines
                    .GroupBy((s) => s.IntervalOffset)
                    .Select(grp => grp.First())
                    .ToList()
                    .OrderBy((s) => s.IntervalOffset);

                double maxPerformanceCounterValue = 0D;

                foreach (StripLine stripLine in stripLinesInCurrentRange_Copy)
                {
                    var performanceCounter = _currentPerformanceCounterSerieCounters
                        .Where((p) => p.TraceEventTime.ToOADate() <= stripLine.IntervalOffset)
                        .OrderByDescending((p) => p.TraceEventTime)
                        .First();

                    if (performanceCounter != null)
                    {
                        maxPerformanceCounterValue = Math.Max(maxPerformanceCounterValue, performanceCounter.Value);
                        int index = serie.Points.AddXY(xValue: stripLine.IntervalOffset, yValue: performanceCounter.Value);
                        serie.Points[index].MarkerSize = 5;
                        serie.Points[index].MarkerStyle = MarkerStyle.Circle;
                        serie.Points[index].Color = Settings.Default.PerformanceCountersColor;
                        serie.Points[index].Font = new Font("Segoe UI", 7);
                        serie.Points[index].Label = Convert.ToString(performanceCounter.Value);
                        serie.Points[index].LabelForeColor = Settings.Default.PerformanceCountersColor;
                    }
                }

                LinesChartArea.AxisY.Maximum = (maxPerformanceCounterValue > 0) ? (maxPerformanceCounterValue * 1.1) : linesChartAreaAxisYMaximum;

                serie.Points.ResumeUpdates();
                TimelineChart.ResumeLayout();
            }

            #endregion

            #region [ Complex Objects ]

            private void InitializeAllComplexObjects()
            {
                #region Dimensions

                if ((bool)ClonedSettings["TimelineDimensionsVisible"].PropertyValue)
                {
                    InitializeDimensionComplexObjects();
                }

                #endregion

                #region Caches

                if ((bool)ClonedSettings["TimelineCachesVisible"].PropertyValue)
                {
                    InitializeCacheComplexObjects();
                }

                #endregion

                #region Aggregations

                if ((bool)ClonedSettings["TimelineAggregationsVisible"].PropertyValue)
                {
                    InitializeAggregationComplexObjects();
                }

                #endregion

                #region Partitions

                if ((bool)ClonedSettings["TimelinePartitionsVisible"].PropertyValue)
                {
                    InitializePartitionComplexObjects();
                }

                #endregion

                #region Measures

                if ((bool)ClonedSettings["TimelineMeasuresVisible"].PropertyValue)
                {
                    InitializeMeasureComplexObjects();
                }

                #endregion

                #region NonEmpty Activities

                if ((bool)ClonedSettings["TimelineNonEmptyActivitiesVisible"].PropertyValue)
                {
                    InitializeNonEmptyGlobalComplexObjects();
                    InitializeNonEmptyGetDataComplexObjects();
                    InitializeNonEmptyPostOrderComplexObjects();
                }

                #endregion

                #region Serialization Activities

                if ((bool)ClonedSettings["TimelineSerializationActivitiesVisible"].PropertyValue)
                {
                    InitializeSerializeGlobalComplexObjects();
                    InitializeSerializeAxesComplexObjects();
                    InitializeSerializeCellsComplexObjects();
                }

                #endregion
            }

            private void UpdateAllComplexObjects()
            {
                #region Caches

                if ((bool)ClonedSettings["TimelineCachesVisible"].PropertyValue)
                {
                    UpdateComplexObjectsInCurrentRange(CacheComplexObjectsInWholeQuery, CacheComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(CacheComplexObjectsInCurrentRange, SeriesType.Cache);
                    UpdateObjectsAllChartSeries(SeriesType.Cache);
                }

                #endregion

                #region Dimensions

                if ((bool)ClonedSettings["TimelineDimensionsVisible"].PropertyValue)
                {
                    UpdateComplexObjectsInCurrentRange(DimensionComplexObjectsInWholeQuery, DimensionComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(DimensionComplexObjectsInCurrentRange, SeriesType.Dimension);
                    UpdateObjectsAllChartSeries(SeriesType.Dimension);
                }

                #endregion

                #region Aggregations

                if ((bool)ClonedSettings["TimelineAggregationsVisible"].PropertyValue)
                {
                    UpdateComplexObjectsInCurrentRange(AggregationComplexObjectsInWholeQuery, AggregationComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(AggregationComplexObjectsInCurrentRange, SeriesType.Aggregation);
                    UpdateObjectsAllChartSeries(SeriesType.Aggregation);
                }

                #endregion

                #region Partitions

                if ((bool)ClonedSettings["TimelinePartitionsVisible"].PropertyValue)
                {
                    UpdateComplexObjectsInCurrentRange(PartitionComplexObjectsInWholeQuery, PartitionComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(PartitionComplexObjectsInCurrentRange, SeriesType.Partition);
                    UpdateObjectsAllChartSeries(SeriesType.Partition);
                }

                #endregion

                #region Measures

                if ((bool)ClonedSettings["TimelineMeasuresVisible"].PropertyValue)
                {
                    UpdateComplexObjectsInCurrentRange(MeasureComplexObjectsInWholeQuery, MeasureComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(MeasureComplexObjectsInCurrentRange, SeriesType.Measure);
                    UpdateObjectsAllChartSeries(SeriesType.Measure);
                }

                #endregion

                #region NonEmpty Activities

                if ((bool)ClonedSettings["TimelineNonEmptyActivitiesVisible"].PropertyValue)
                {
                    subSeriesName.Clear();
                    subSeriesName = NonEmptyGlobalComplexObjectsInWholeQuery
                            .Select(co => co.ComplexObjectName)
                            .Distinct()
                            .ToList();

                    UpdateComplexObjectsInCurrentRange(NonEmptyGlobalComplexObjectsInWholeQuery, NonEmptyGlobalComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(NonEmptyGlobalComplexObjectsInCurrentRange, SeriesType.NonEmpty, subSeriesName);

                    subSeriesName.Clear();
                    subSeriesName = NonEmptyGetDataComplexObjectsInWholeQuery
                            .Select(co => co.ComplexObjectName)
                            .Distinct()
                            .ToList();

                    UpdateComplexObjectsInCurrentRange(NonEmptyGetDataComplexObjectsInWholeQuery, NonEmptyGetDataComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(NonEmptyGetDataComplexObjectsInCurrentRange, SeriesType.NonEmpty, subSeriesName);

                    subSeriesName.Clear();
                    subSeriesName = NonEmptyPostOrderComplexObjectsInWholeQuery
                            .Select(co => co.ComplexObjectName)
                            .Distinct()
                            .ToList();

                    UpdateComplexObjectsInCurrentRange(NonEmptyPostOrderComplexObjectsInWholeQuery, NonEmptyPostOrderComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(NonEmptyPostOrderComplexObjectsInCurrentRange, SeriesType.NonEmpty, subSeriesName);

                    UpdateObjectsAllChartSeries(SeriesType.NonEmpty);

                }

                #endregion

                #region Serialization Activities

                if ((bool)ClonedSettings["TimelineSerializationActivitiesVisible"].PropertyValue)
                {
                    subSeriesName.Clear();
                    subSeriesName = SerializeGlobalComplexObjectsInWholeQuery
                            .Select(co => co.ComplexObjectName)
                            .Distinct()
                            .ToList();

                    UpdateComplexObjectsInCurrentRange(SerializeGlobalComplexObjectsInWholeQuery, SerializeGlobalComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(SerializeGlobalComplexObjectsInCurrentRange, SeriesType.Serialization, subSeriesName);

                    subSeriesName.Clear();
                    subSeriesName = SerializeAxesComplexObjectsInWholeQuery
                            .Select(co => co.ComplexObjectName)
                            .Distinct()
                            .ToList();

                    UpdateComplexObjectsInCurrentRange(SerializeAxesComplexObjectsInWholeQuery, SerializeAxesComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(SerializeAxesComplexObjectsInCurrentRange, SeriesType.Serialization, subSeriesName);

                    subSeriesName.Clear();
                    subSeriesName = SerializeCellsComplexObjectsInWholeQuery
                            .Select(co => co.ComplexObjectName)
                            .Distinct()
                            .ToList();

                    UpdateComplexObjectsInCurrentRange(SerializeCellsComplexObjectsInWholeQuery, SerializeCellsComplexObjectsInCurrentRange);
                    UpdateComplexObjectsContextMenuItems(SerializeCellsComplexObjectsInCurrentRange, SeriesType.Serialization, subSeriesName);

                    UpdateObjectsAllChartSeries(SeriesType.Serialization);
                }

                #endregion
            }

            private Series CreateComplexObjectsChartSeries(ToolStripMenuItem menuItem, SeriesType serieType, string serieName, Color serieColor)
            {
                var serie = TimelineChart.Series.FindByName(serieName);
                if (serie == null)
                {
                    serie = new Series(serieName);
                    serie.ChartType = SeriesChartType.RangeBar;
                    serie.ChartArea = RangesChartArea.Name;
                    serie.Color = serieColor;
                    serie.BorderColor = CustomColor.ObjectsBorderColor;
                    serie.Enabled = false;
                    serie.ToolTip = serieName;
                    serie.Tag = serieType;
                    TimelineChart.Series.Add(serie);
                    CreateContextMenuItem(menuItem, serie, serieType);
                }
                return serie;
            }

            private void UpdateComplexObjectsContextMenuItems(List<ComplexObject> complexObjectsList, SeriesType seriesType, List<string> subSeriesName = null)
            {
                var parentMenuItem = GetMenuContextMenuItem(seriesType);

                var menuItemsCounter = complexObjectsList
                    .GroupBy((e) => e.ComplexObjectName)
                    .Select((g) => new MenuItemsCounter
                    {
                        MenuName = g.Min((p) => p.ComplexObjectName),
                        MenuCounter = g.Count()
                    })
                    .ToList();

                UpdateAllContextMenuItems(menuItemsCounter, parentMenuItem, seriesType, subSeriesName);
            }

            private void UpdateComplexObjectsInCurrentRange(List<ComplexObject> eventsInQuery, List<ComplexObject> eventsInRange)
            {
                eventsInRange.Clear();

                foreach (var @event in eventsInQuery)
                {
                    if ((@event.BeginEventTime < ChartBeginTime && @event.EndEventTime >= ChartBeginTime) || (@event.BeginEventTime >= ChartBeginTime && @event.BeginEventTime <= ChartEndTime))
                        eventsInRange.Add(@event);
                }
            }

            private IEnumerable<ComplexObject> GetSingleSerieComplexObjectsList(Series serie)
            {
                IEnumerable<ComplexObject> complexObjectsInRange = null;
                var serieType = (SeriesType)serie.Tag;

                switch (serieType)
                {
                    case SeriesType.Cache:
                        complexObjectsInRange = CacheComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                        break;
                    case SeriesType.Dimension:
                        complexObjectsInRange = DimensionComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                        break;
                    case SeriesType.Partition:
                        complexObjectsInRange = PartitionComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                        break;
                    case SeriesType.Aggregation:
                        complexObjectsInRange = AggregationComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                        break;
                    case SeriesType.Measure:
                        complexObjectsInRange = MeasureComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                        break;
                    case SeriesType.NonEmpty:
                        switch (serie.Name)
                        {
                            case nonEmptyGlobalSerieName:
                                complexObjectsInRange = NonEmptyGlobalComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                                break;
                            case nonEmptyGetDataSerieName:
                                complexObjectsInRange = NonEmptyGetDataComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                                break;
                            case nonEmptyPostOrderSerieName:
                                complexObjectsInRange = NonEmptyPostOrderComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                                break;
                        }
                        break;
                    case SeriesType.Serialization:
                        switch (serie.Name)
                        {
                            case serializeGlobalSerieName:
                                complexObjectsInRange = SerializeGlobalComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                                break;
                            case serializeCellsAxisSerieName:
                                complexObjectsInRange = SerializeCellsComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                                break;
                            // Serialize Axes series has differents name (Axes 0, Axes 1, Axes Slice) so they do not match a single case
                            default:
                                complexObjectsInRange = SerializeAxesComplexObjectsInCurrentRange.Where((c) => c.Serie == serie);
                                break;
                        }
                        break;
                    default:
                        throw new ApplicationException("GetSingleSerieComplexObjectsList not found for [{0}]".FormatWith(serieType));
                }

                return complexObjectsInRange;
            }

            private void DrawComplexObjectsOnChart(Series serie)
            {
                TimelineChart.SuspendLayout();
                serie.Points.SuspendUpdates();

                var complexObjectsToRefresh = GetSingleSerieComplexObjectsList(serie);
                Debug.Assert(complexObjectsToRefresh != null);

                foreach (var @event in complexObjectsToRefresh)
                {
                    #region Serie points

                    int pointIndex = @event.Serie.Points.AddXY(1D, @event.BeginEventTimeOADate, @event.EndEventTimeOADate);
                    @event.Serie.Points[pointIndex].Tag = (ComplexObject)@event;
                    #endregion

                    #region Begin & End labels

                    if (@event.BeginEventTime == @event.EndEventTime)
                    {
                        var labelYPointsText = "[{0}(2)] {1} {2:HH:mm:ss.fff}".FormatWith(@event.BeginEventID, @event.Serie.Name + " [Begin/End]", @event.BeginEventTime);
                        var label = new CustomLabel();
                        label.FromPosition = @event.BeginEventTimeOADate.Value - ChartLabelsXOffset;
                        label.ToPosition = @event.BeginEventTimeOADate.Value + ChartLabelsXOffset;
                        label.Text = labelYPointsText;
                        label.RowIndex = 0;
                        label.LabelMark = LabelMarkStyle.LineSideMark;
                        label.GridTicks = GridTickTypes.Gridline;
                        label.ForeColor = @event.SerieColor.Value;
                        label.Tag = serie;
                        _customLabelsInCurrentRange.Add(label);
                    }
                    else
                    {
                        var labelYPointsText = "[{0}] {1} {2:HH:mm:ss.fff}".FormatWith(@event.BeginEventID, @event.Serie.Name + " [Begin]", @event.BeginEventTime);
                        var label = new CustomLabel();
                        label.FromPosition = @event.BeginEventTimeOADate.Value - ChartLabelsXOffset;
                        label.ToPosition = @event.BeginEventTimeOADate.Value + ChartLabelsXOffset;
                        label.Text = labelYPointsText;
                        label.RowIndex = 0;
                        label.LabelMark = LabelMarkStyle.LineSideMark;
                        label.GridTicks = GridTickTypes.Gridline;
                        label.ForeColor = @event.SerieColor.Value;
                        label.Tag = serie;
                        _customLabelsInCurrentRange.Add(label);

                        labelYPointsText = "[{0}] {1} {2:HH:mm:ss.fff}".FormatWith(@event.EndEventID, @event.Serie.Name + " [End]", @event.EndEventTime);
                        label = new CustomLabel();
                        label.FromPosition = @event.EndEventTimeOADate.Value - ChartLabelsXOffset;
                        label.ToPosition = @event.EndEventTimeOADate.Value + ChartLabelsXOffset;
                        label.Text = labelYPointsText;
                        label.RowIndex = 0;
                        label.LabelMark = LabelMarkStyle.LineSideMark;
                        label.GridTicks = GridTickTypes.Gridline;
                        label.ForeColor = @event.SerieColor.Value;
                        label.Tag = serie;
                        _customLabelsInCurrentRange.Add(label);
                    }
                    #endregion

                    #region Begin & End lines

                    if (@event.BeginEventTime == @event.EndEventTime)
                    {
                        var stripLine = new StripLine();
                        stripLine.BorderColor = @event.SerieColor.Value;
                        stripLine.BorderDashStyle = ChartDashStyle.Solid;
                        stripLine.BorderWidth = 1;
                        stripLine.IntervalOffset = @event.BeginEventTimeOADate.Value;
                        stripLine.Tag = serie;
                        _stripLinesInCurrentRange.Add(stripLine);
                    }
                    else
                    {
                        var stripLine = new StripLine();
                        stripLine.BorderColor = @event.SerieColor.Value;
                        stripLine.BorderDashStyle = ChartDashStyle.Solid;
                        stripLine.BorderWidth = 1;
                        stripLine.IntervalOffset = @event.BeginEventTimeOADate.Value;
                        stripLine.Tag = serie;
                        _stripLinesInCurrentRange.Add(stripLine);

                        stripLine = new StripLine();
                        stripLine.BorderColor = @event.SerieColor.Value;
                        stripLine.BorderDashStyle = ChartDashStyle.Solid;
                        stripLine.BorderWidth = 1;
                        stripLine.IntervalOffset = @event.EndEventTimeOADate.Value;
                        stripLine.Tag = serie;
                        _stripLinesInCurrentRange.Add(stripLine);
                    }

                    #endregion
                }

                serie.Points.ResumeUpdates();
                TimelineChart.ResumeLayout();
            }

            private void MergeBeginEndComplexObjects(List<ComplexObject> complexObjectsInQuery, List<ComplexObject> complexObjectBeginInTimeRange, List<ComplexObject> complexObjectEndInTimeRange, string eventType)
            {
	            // TODO: rivedere se fattibile rimuovere i ComplexObjectTimes
	            ComplexObject mergedComplexObject;
	            bool foundedComplexObject;
	            bool logicTest;
	            string progressTotalUnitMeasure = "";

	            switch (eventType)
	            {
		            case serializeGlobalSerieName:
			            progressTotalUnitMeasure = "N/A";
			            break;
		            case "Serialize Axes":
			            progressTotalUnitMeasure = "tuple";
			            break;
		            case serializeCellsAxisSerieName:
			            progressTotalUnitMeasure = "cell";
			            break;
		            default:
			            break;
	            }

	            #region Matching all Begin events with relative End event

                for (int beginIndex = 0; beginIndex < complexObjectBeginInTimeRange.Count; beginIndex++)
	            {
                    ComplexObject currentComplexObjectBegin = complexObjectBeginInTimeRange[beginIndex];
				   
		            mergedComplexObject = new ComplexObject
		            {
                        Serie = currentComplexObjectBegin.Serie,
                        SerieColor = currentComplexObjectBegin.Serie.Color,
			            ComplexObjectName = currentComplexObjectBegin.ComplexObjectName,
			            ComplexObjectID = currentComplexObjectBegin.ComplexObjectID,
			            BeginEventID = currentComplexObjectBegin.BeginEventID,
                        BeginEventTime = currentComplexObjectBegin.BeginEventTime,
                        BeginEventTimeOADate = currentComplexObjectBegin.BeginEventTimeOADate,
                        EndEventID = currentComplexObjectBegin.BeginEventID,
                        EndEventTime = currentComplexObjectBegin.BeginEventTime,
                        EndEventTimeOADate = currentComplexObjectBegin.EndEventTimeOADate,
                        MeasureGroupID = currentComplexObjectBegin.MeasureGroupID,
			            ComplexObjectDuration = currentComplexObjectBegin.ComplexObjectDuration,
                        ComplexObjectReadDuration = currentComplexObjectBegin.ComplexObjectReadDuration,
                        ComplexObjectType = currentComplexObjectBegin.ComplexObjectType,
                        ComplexObjectSubType = currentComplexObjectBegin.ComplexObjectSubType,
                        ComplexObjectPath = currentComplexObjectBegin.ComplexObjectPath,
                        ComplexObjectTextData = currentComplexObjectBegin.ComplexObjectTextData,
                        ComplexObjectProgressTotal = currentComplexObjectBegin.ComplexObjectProgressTotal,
			            ComplexObjectProgressTotalUnitMeasure = progressTotalUnitMeasure,
		            };

		            foundedComplexObject = false;

		            // TODO: rivedere codice con LINQ
		            for (int endIndex = 0; endIndex < complexObjectEndInTimeRange.Count; endIndex++)
		            {
			            logicTest = (
							            (complexObjectEndInTimeRange[endIndex].ComplexObjectName == currentComplexObjectBegin.ComplexObjectName) &&
                                        (complexObjectEndInTimeRange[endIndex].ComplexObjectPath == currentComplexObjectBegin.ComplexObjectPath) &&
							            //(complexObjectEndInTimeRange[endIndex].EventCurrentTime >= currentComplexObjectBegin.EventCurrentTime) &&
                                        (complexObjectEndInTimeRange[endIndex].EndEventID >= currentComplexObjectBegin.BeginEventID)
						            );

			            if (logicTest)
			            {
				            foundedComplexObject = true;
                            mergedComplexObject.EndEventID = complexObjectEndInTimeRange[endIndex].EndEventID;
                            mergedComplexObject.EndEventTime = complexObjectEndInTimeRange[endIndex].EndEventTime;
                            mergedComplexObject.EndEventTimeOADate = complexObjectEndInTimeRange[endIndex].EndEventTimeOADate;
                            mergedComplexObject.ComplexObjectReadDuration = (long?)complexObjectEndInTimeRange[endIndex].EndEventTime.Value.Subtract(currentComplexObjectBegin.BeginEventTime.Value).TotalMilliseconds;

                            if (complexObjectEndInTimeRange[endIndex].ComplexObjectDuration.HasValue)
                                mergedComplexObject.ComplexObjectDuration = complexObjectEndInTimeRange[endIndex].ComplexObjectDuration;

                            if (complexObjectEndInTimeRange[endIndex].ComplexObjectProgressTotal.HasValue)
				            {
                                mergedComplexObject.ComplexObjectProgressTotal = complexObjectEndInTimeRange[endIndex].ComplexObjectProgressTotal;
					            mergedComplexObject.ComplexObjectProgressTotalUnitMeasure = progressTotalUnitMeasure;

                                if (complexObjectEndInTimeRange[endIndex].ComplexObjectProgressTotal > 0)
						            mergedComplexObject.ComplexObjectProgressTotalUnitMeasure = mergedComplexObject.ComplexObjectProgressTotalUnitMeasure + "s";
				            }

				            complexObjectEndInTimeRange.RemoveAt(endIndex);
				            break;
			            }

		            }
		            if (!foundedComplexObject) //--> If not matched the TimeConsumingObject bar ends at ChartEndTime
		            {
			            mergedComplexObject.EndEventID = _lastEventID;
			            mergedComplexObject.EndEventTime = ChartEndTime;
			            mergedComplexObject.EndEventTimeOADate = ChartEndTime.ToOADate();
			            mergedComplexObject.ComplexObjectReadDuration = (long?)ChartEndTime.Subtract(mergedComplexObject.BeginEventTime.Value).TotalMilliseconds;
		            }

		            complexObjectsInQuery.Add(mergedComplexObject);
	            }
	            #endregion

	            #region End events without Begin //--> If not matched the TimeConsumingObject bar Begins at ChartBeginTime

	            foreach (var complexObjectEnd in complexObjectEndInTimeRange)
	            {
		            if (
                         ((complexObjectBeginInTimeRange.Count() > 0) &&
                         (complexObjectEnd.EndEventID < complexObjectBeginInTimeRange.First().BeginEventID))
			            ||
                        (complexObjectBeginInTimeRange.Count() == 0)
		               )
		            {
                        // If in Zoom mode this situation can happen
                        // If not in Zoom mode there is an error
                        if (!ZoomMode)
                        {
                            // TOFIX: manage error!
                        }
                        else
                        {
                            mergedComplexObject = new ComplexObject
                            {
                                Serie = complexObjectEnd.Serie,
                                SerieColor = complexObjectEnd.SerieColor,
                                ComplexObjectName = complexObjectEnd.ComplexObjectName,
                                ComplexObjectID = complexObjectEnd.ComplexObjectID,
                                BeginEventID = -1,
                                BeginEventTime = ChartBeginTime,
                                BeginEventTimeOADate = ChartBeginTime.ToOADate(),
                                EndEventID = complexObjectEnd.EndEventID,
                                EndEventTime = complexObjectEnd.EndEventTime,
                                EndEventTimeOADate = complexObjectEnd.EndEventTimeOADate,
                                MeasureGroupID = complexObjectEnd.MeasureGroupID,
                                ComplexObjectDuration = complexObjectEnd.ComplexObjectDuration,
                                ComplexObjectReadDuration = (long?)complexObjectEnd.EndEventTime.Value.Subtract(ChartBeginTime).TotalMilliseconds,
                                ComplexObjectType = complexObjectEnd.ComplexObjectType,
                                ComplexObjectSubType = complexObjectEnd.ComplexObjectSubType,
                                ComplexObjectPath = complexObjectEnd.ComplexObjectPath,
                                ComplexObjectTextData = complexObjectEnd.ComplexObjectTextData,
                                ComplexObjectProgressTotal = complexObjectEnd.ComplexObjectProgressTotal,
                                ComplexObjectProgressTotalUnitMeasure = complexObjectEnd.ComplexObjectProgressTotalUnitMeasure,
                            };

                            if (mergedComplexObject.ComplexObjectProgressTotal > 0)
                                mergedComplexObject.ComplexObjectProgressTotalUnitMeasure = mergedComplexObject.ComplexObjectProgressTotalUnitMeasure + "s";

                            complexObjectsInQuery.Add(mergedComplexObject);
                        }
		            }
	            }

	            #endregion
            }

            #region Caches

            private string TranslateCacheSerieName(string originalName)
            {
                string translatedName = "N/A";

                switch (originalName)
                {
                    case "Global Scope":
                        translatedName = "Calculation Cache - Global Scope";
                        break;
                    case "Session Scope":
                        translatedName = "Calculation Cache - Session Scope";
                        break;
                    case "Query Scope":
                        translatedName = "Calculation Cache - Query Scope";
                        break;
                    case "GetDataFromMeasureGroupCache":
                        translatedName = "Measure Group Cache";
                        break;
                    case "GetDataFromFlatCache":
                        translatedName = "Flat Cache";
                        break;
                    case "GetDataFromPersistedCache":
                        translatedName = "Persisted Cache";
                        break;
                    default:
                        translatedName = originalName;
                        break;
                }

                return translatedName;
            }

            private void InitializeCacheComplexObjectsInQuery()
            {
                var CachesBeginInQuery = ProfilerEventsInCurrentRange
                    .Where((e) => e.EventClass == TraceEventClass.GetDataFromCache)
                    .Select((g) => new ComplexObject
                    {
                        Serie = null,
                        SerieColor = Settings.Default.CachesColor,
                        ComplexObjectName = TranslateCacheSerieName(
                                                                    (g.EventSubclass != TraceEventSubclass.GetDataFromCalculationCache) ? g.EventSubclass.Value.ToName() :
                                                                    (g.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache) ? Convert.ToString(g.TextData) : "N/A"
                                                                   ),
                        ComplexObjectID = TranslateCacheSerieName(
                                                                    (g.EventSubclass != TraceEventSubclass.GetDataFromCalculationCache) ? g.EventSubclass.Value.ToName() :
                                                                    (g.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache) ? Convert.ToString(g.TextData) : "N/A"
                                                                 ),
                        BeginEventID = g.ID,
                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                        EndEventID = g.ID,
                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                        MeasureGroupID = "N/A",
                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                        ComplexObjectType = "Cache",
                        ComplexObjectSubType = "N/A",
                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                    })
                    .OrderBy((y) => y.BeginEventID)
                    .ToList();

                for (int beginIndex = 0; beginIndex < CachesBeginInQuery.Count; beginIndex++)
                {
                    ComplexObject currentComplexObject = CachesBeginInQuery[beginIndex];

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _cachesMenuItem,
                                                                           SeriesType.Cache,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);

                    CacheComplexObjectsInWholeQuery.Add(currentComplexObject);
                }


                CacheComplexObjectsInCurrentRange = CacheComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeCacheComplexObjects()
            {
                InitializeCacheComplexObjectsInQuery();

                UpdateComplexObjectsContextMenuItems(CacheComplexObjectsInCurrentRange, SeriesType.Cache);
            }

            #endregion

            #region Dimensions

            private void InitializeDimensionComplexObjectsInQuery()
            {
                var dimensionsInQuery = ProfilerEventsInCurrentRange
                    .Where((e) => e.EventClass == TraceEventClass.QueryDimension)
                    .Select((g) => new ComplexObject
                    {
                        Serie = null,
                        SerieColor = (g.EventSubclass.ToString() == null) ? Settings.Default.CachedDimensionsColor :
                                        (g.EventSubclass.ToString() == "CacheData") ? Settings.Default.CachedDimensionsColor :
                                        (g.EventSubclass.ToString() == "NonCacheData") ? Settings.Default.NonCachedDimensionsColor :
                                        Settings.Default.CachedDimensionsColor,
                        ComplexObjectName = "N/A",
                        ComplexObjectID = (g.ObjectPath != null) ?
                                            g.ObjectPath.ToString().
                                            Substring((g.ObjectPath.ToString().LastIndexOf(".") + 1),
                                                    (g.ObjectPath.ToString().Length - g.ObjectPath.ToString().LastIndexOf(".")) - 1) :
                                            "N/A",
                        BeginEventID = g.ID,
                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                        EndEventID = g.ID,
                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                        MeasureGroupID = "N/A",
                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                        ComplexObjectType = "Dimension",
                        ComplexObjectSubType = (g.EventSubclass.ToString() == "CacheData") ? "Cached" :
                                                (g.EventSubclass.ToString() == "NonCacheData") ? "Non Cached" :
                                                "Cached",
                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                    })
                    .OrderBy((y) => y.BeginEventID)
                    .ToList();

                var xdoc = XDocument.Parse(ExecutionResult.CubeMetadata);

                for (int beginIndex = 0; beginIndex < dimensionsInQuery.Count; beginIndex++)
                {
                    ComplexObject currentComplexObject = dimensionsInQuery[beginIndex];

                    var dimension = xdoc.Descendants("CubeDimension")
                        .Where(x => (string)x.Attribute("DimensionID") == currentComplexObject.ComplexObjectID)
                        .FirstOrDefault();

                    if (dimension != null)
                    {
                        currentComplexObject.ComplexObjectName = dimension.Attribute("Name").Value.ToString();
                    }

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _dimensionsMenuItem,
                                                                           SeriesType.Dimension,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);

                    DimensionComplexObjectsInWholeQuery.Add(currentComplexObject);
                }


                DimensionComplexObjectsInCurrentRange = DimensionComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeDimensionComplexObjects()
            {
                InitializeDimensionComplexObjectsInQuery();

                UpdateComplexObjectsContextMenuItems(DimensionComplexObjectsInCurrentRange, SeriesType.Dimension);
            }

            #endregion

            #region Aggregations

            private void InitializeAggregationComplexObjectsInQuery()
            {
                var aggregationComplexObjectsBeginInQuery = ProfilerEventsInCurrentRange
                    .Where((e) => e.EventClass == TraceEventClass.ProgressReportBegin && e.EventSubclass == TraceEventSubclass.Query && e.ObjectType == null)
                    .Select((g) => new ComplexObject
                        {
                            Serie = null,
                            SerieColor = Settings.Default.AggregationsColor,
                            ComplexObjectName = g.ObjectName ?? "N/A",
                            ComplexObjectID = g.ObjectID ?? "N/A",
                            BeginEventID = g.ID,
                            BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                            BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                            EndEventID = -1,
                            EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                            EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                            MeasureGroupID = g.ObjectPath.Split('.')[3],
                            ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                            ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                            ComplexObjectType = "Aggregation",
                            ComplexObjectSubType = "N/A",
                            ComplexObjectPath = g.ObjectPath ?? "N/A",
                            ComplexObjectTextData = g.TextData ?? "N/A",
                            ComplexObjectProgressTotal = g.ProgressTotal ?? 0,
                            ComplexObjectProgressTotalUnitMeasure = string.Empty,
                        })
                    .OrderBy((y) => y.BeginEventID)
                    .ToList();

                var aggregationComplexObjectsEndInQuery = ProfilerEventsInCurrentRange
                    .Where((e) => e.EventClass == TraceEventClass.ProgressReportEnd && e.EventSubclass == TraceEventSubclass.Query && e.ObjectType == null)
                    .Select((g) => new ComplexObject
                    {
                        Serie = null,
                        SerieColor = Settings.Default.AggregationsColor,
                        ComplexObjectName = g.ObjectName ?? "N/A",
                        ComplexObjectID = g.ObjectID ?? "N/A",
                        BeginEventID = -1,
                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                        EndEventID = g.ID,
                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                        MeasureGroupID = g.ObjectPath.Split('.')[3],
                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                        ComplexObjectType = "Aggregation",
                        ComplexObjectSubType = "N/A",
                        ComplexObjectPath = g.ObjectPath ?? "N/A",
                        ComplexObjectTextData = g.TextData ?? "N/A",
                        ComplexObjectProgressTotal = g.ProgressTotal ?? 0,
                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                    })
                    .OrderBy((y) => y.BeginEventID)
                    .ToList();

                for (int beginIndex = 0; beginIndex < aggregationComplexObjectsBeginInQuery.Count; beginIndex++)
                {
                    var currentComplexObject = aggregationComplexObjectsBeginInQuery[beginIndex];

                    var getDataFromAggregationEvent = ProfilerEventsInCurrentRange
                                            .Where((e) =>
                                                e.EventClass == TraceEventClass.GetDataFromAggregation 
                                                ).Select((e) =>
	                                            {
		                                            Debug.Assert(e.TextData != null);

		                                            var values = e.TextData.Split('\n');

		                                            Debug.Assert(values.Length == 2);

		                                            return new
		                                            {
			                                            AggregationObjectPath = "{0}.{1}".FormatWith(e.ObjectPath, values.First()),
                                                        AggregationID = values.First(),
                                                        TextData = values[1]
		                                            };
                                                }
                                                )
                                                .Where((g) =>
                                                    g.AggregationID == currentComplexObject.ComplexObjectID &&
                                                    g.AggregationObjectPath == currentComplexObject.ComplexObjectPath
                                                    ).FirstOrDefault();

                    if (getDataFromAggregationEvent != null)
                        currentComplexObject.ComplexObjectTextData = getDataFromAggregationEvent.TextData;

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _aggregationsMenuItem,
                                                                           SeriesType.Aggregation,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);
                }

                MergeBeginEndComplexObjects(
                                    AggregationComplexObjectsInWholeQuery,
                                    aggregationComplexObjectsBeginInQuery,
                                    aggregationComplexObjectsEndInQuery,
                                    "Aggregation"
                                    );

                AggregationComplexObjectsInCurrentRange = AggregationComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeAggregationComplexObjects()
            {
                InitializeAggregationComplexObjectsInQuery();

                UpdateComplexObjectsContextMenuItems(AggregationComplexObjectsInCurrentRange, SeriesType.Aggregation);
            }

            #endregion

            #region Partitions

            private void InitializePartitionComplexObjectsInQuery()
            {
                var partitionComplexObjectsBeginInQuery = ProfilerEventsInCurrentRange
                    .Where((e) => e.EventClass == TraceEventClass.ProgressReportBegin && e.EventSubclass == TraceEventSubclass.Query && e.ObjectType != null && e.ObjectType.Name == "Partition")
                    .Select((g) => new ComplexObject
                        {
                            Serie = null,
                            SerieColor = Settings.Default.PartitionsColor,
                            ComplexObjectName = g.ObjectName ?? "N/A",
                            ComplexObjectID = g.ObjectID ?? "N/A",
                            BeginEventID = g.ID,
                            BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                            BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                            EndEventID = -1,
                            EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                            EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                            MeasureGroupID = XDocument.Parse(g.ObjectReference, LoadOptions.None).Root.Element("MeasureGroupID").Value,
                            ComplexObjectDuration = g.Duration ?? 0,
                            ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                            ComplexObjectType = "Partition",
                            ComplexObjectSubType = "N/A",
                            ComplexObjectPath = g.ObjectPath ?? "N/A",
                            ComplexObjectTextData = g.TextData ?? "N/A",
                            ComplexObjectProgressTotal = g.ProgressTotal ?? 0L,
                            ComplexObjectProgressTotalUnitMeasure = string.Empty,
                        })
                    .OrderBy((y) => y.BeginEventID)
                    .ToList();

                var partitionComplexObjectsEndInQuery = ProfilerEventsInCurrentRange
                    .Where((e) => e.EventClass == TraceEventClass.ProgressReportEnd && e.EventSubclass == TraceEventSubclass.Query && e.ObjectType != null && e.ObjectType.Name == "Partition")
                    .Select((g) => new ComplexObject
                        {
                            Serie = null,
                            SerieColor = Settings.Default.PartitionsColor,
                            ComplexObjectName = g.ObjectName ?? "N/A",
                            ComplexObjectID = g.ObjectID ?? "N/A",
                            BeginEventID = -1,
                            BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                            BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                            EndEventID = g.ID,
                            EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                            EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                            MeasureGroupID = XDocument.Parse(g.ObjectReference, LoadOptions.None).Root.Element("MeasureGroupID").Value,
                            ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                            ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                            ComplexObjectType = "Partition",
                            ComplexObjectSubType = "N/A",
                            ComplexObjectPath = g.ObjectPath ?? "N/A",
                            ComplexObjectTextData = g.TextData ?? "N/A",
                            ComplexObjectProgressTotal = g.ProgressTotal ?? 0,
                            ComplexObjectProgressTotalUnitMeasure = string.Empty,
                        })
                    .OrderBy((y) => y.BeginEventID)
                    .ToList();

                for (int beginIndex = 0; beginIndex < partitionComplexObjectsBeginInQuery.Count; beginIndex++)
                {
                    var currentComplexObject = partitionComplexObjectsBeginInQuery[beginIndex];

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _partitionsMenuItem,
                                                                           SeriesType.Partition,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);
                }

                MergeBeginEndComplexObjects(
                                    PartitionComplexObjectsInWholeQuery,
                                    partitionComplexObjectsBeginInQuery,
                                    partitionComplexObjectsEndInQuery,
                                    "Partition"
                                    );

                PartitionComplexObjectsInCurrentRange = PartitionComplexObjectsInWholeQuery.ToList();
            }

            private void InitializePartitionComplexObjects()
            {
                InitializePartitionComplexObjectsInQuery();

                UpdateComplexObjectsContextMenuItems(PartitionComplexObjectsInCurrentRange, SeriesType.Partition);
            }

            #endregion

            #region Measures

            private void InitializeMeasureComplexObjectsInQuery()
            {
                InitializeMeasureMetadataCollection();

                MeasureComplexObjectsInWholeQuery = MeasureMetadataCollection
                    .Where((m) => m.BeginID.HasValue && m.BeginTime.HasValue && m.EndID.HasValue && m.EndTime.HasValue)
                    .Select((m) => new ComplexObject
                    {
                        Serie = null,
                        SerieColor = (int.Parse(m.ID) > _minIDCalculatedMeasures) ? Settings.Default.CalculatedMeasuresColor : Settings.Default.RegularMeasuresColor,
                        ComplexObjectName = m.Name ?? "N/A",
                        ComplexObjectVisible = m.Visible ?? false.ToString(),
                        ComplexObjectID = m.ID ?? "N/A",
                        BeginEventID = m.BeginID.Value,
                        BeginEventTime = m.BeginTime.Value,
                        BeginEventTimeOADate = m.BeginTime.Value.ToOADate(),
                        EndEventID = m.EndID.Value,
                        EndEventTime = m.EndTime.Value,
                        EndEventTimeOADate = m.EndTime.Value.ToOADate(),
                        MeasureGroupID = m.MeasureGroupID ?? "N/A",
                        ComplexObjectDuration = 0,
                        ComplexObjectReadDuration = (long?)m.EndTime.Value.Subtract(m.BeginTime.Value).TotalMilliseconds,
                        ComplexObjectType = "Measure",
                        ComplexObjectSubType = (int.Parse(m.ID) > _minIDCalculatedMeasures) ? "Calculated" : "Regular",
                        ComplexObjectPath = "N/A",
                        ComplexObjectTextData = m.Expression ?? "N/A",
                        ComplexObjectProgressTotal = 0,
                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                    })
                    .OrderBy((y) => y.BeginEventID)
                    .ToList();

                for (int i = 0; i < MeasureComplexObjectsInWholeQuery.Count; i++)
                {
                    var currentComplexObject = MeasureComplexObjectsInWholeQuery[i];
                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(_measuresMenuItem, SeriesType.Measure, currentComplexObject.ComplexObjectName, currentComplexObject.SerieColor.Value);
                }

                MeasureComplexObjectsInCurrentRange = MeasureComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeMeasureComplexObjects()
            {
                InitializeMeasureComplexObjectsInQuery();

                UpdateComplexObjectsContextMenuItems(MeasureComplexObjectsInCurrentRange, SeriesType.Measure);
            }

            private void InitializeMeasureMetadataCollection()
            {
                var document = XDocument.Parse(ExecutionResult.CubeMetadata, LoadOptions.None);

                MeasureMetadataCollection = document.Root.Element("MeasuresExtended").Elements("Measure")
                    .Select((m) =>
                    {
                        var measureGroupID = default(string);
                        var measureVisible = default(string);
                        var measure = document.Root.Element("Cube").Element("MeasureGroups").Elements("MeasureGroup")
                            .SelectMany((e) => e.Element("Measures").Elements("Measure"))
                            .SingleOrDefault((e) => e.Attribute("ID").Value == m.Attribute("ID").Value);
                        if (measure != null)
                        {
                            measureGroupID = measure.Parent.Parent.Attribute("ID").Value;
                            measureVisible = measure.Attribute("Visible").Value;
                        }

                        return new MeasureMetadata
                        {
                            Name = m.Attribute("Name").Value,
                            ID = m.Attribute("IDOfCurrentMember").Value,
                            MeasureGroupID = measureGroupID,
                            Visible = measureVisible,
                        };
                    })
                    .ToList();

                var traceEvents = ExecutionResult.Profilers.SelectMany((e) => e).AsParallel()
                    .Where((p) => p.EventClass == TraceEventClass.CalculationEvaluation || p.EventClass == TraceEventClass.CalculationEvaluationDetailedInformation)
                    .Select((e) => new
                    {
                        ID = e.ID,
                        TextData = e.TextData,
                        CurrentTime = e.CurrentTime
                    })
                    .ToList();

                #region Parse TextData "ID"

                var measureIDRegex = new Regex(@"D:0\(Measures\)\s+\[(?<ID>\d+)\]\s+=&gt;\s+\(Measures\):\[(?<NAME>.*?)\]", RegexOptions.Compiled);
                var traceIDMeasures = traceEvents.AsParallel()
                    .Where((e) => measureIDRegex.IsMatch(e.TextData))
                    .GroupBy((e) =>
                    {
                        var match = measureIDRegex.Match(e.TextData);
                        return new
                        {
                            MeasureID = match.Groups["ID"].Value,
                            MeasureName = match.Groups["NAME"].Value,
                        };
                    })
                    .Select((g) =>
                    {
                        var expression = default(string);
                        var item = g.Where((p) => p.TextData.Contains("Expression:")).FirstOrDefault();
                        if (item != null)
                        {
                            var startIndex = item.TextData.IndexOf("Expression:") + "Expression:".Length;
                            expression = item.TextData.Substring(startIndex, item.TextData.IndexOf("</CalculationLocation>") - startIndex);
                        }

                        return new
                        {
                            MeasureID = g.Key.MeasureID,
                            MeasureName = g.Key.MeasureName,
                            MeasureExpression = expression,
                            BeginTime = g.Min((p) => p.CurrentTime.Value),
                            EndTime = g.Max((p) => p.CurrentTime.Value),
                            BeginID = g.Min((p) => p.ID),
                            EndID = g.Max((p) => p.ID),
                        };
                    })
                    .ToList();

                if (traceIDMeasures.Any())
                {
                    MeasureMetadataCollection.AddRange(traceIDMeasures
                        .Where((t) => !MeasureMetadataCollection.Any((m) => t.MeasureID == m.ID))
                        .Select((m) => new MeasureMetadata()
                        {
                            ID = m.MeasureID,
                            Name = m.MeasureName,
                            Expression = m.MeasureExpression
                        }));

                    Parallel.ForEach(MeasureMetadataCollection, (i) =>
                    {
                        i.BeginTime = null;
                        i.EndTime = null;
                        i.BeginID = null;
                        i.EndID = null;

                        var trace = traceIDMeasures.SingleOrDefault((m) => m.MeasureID == i.ID);
                        if (i.InRange = trace != null)
                        {
                            i.BeginTime = trace.BeginTime;
                            i.EndTime = trace.EndTime;
                            i.BeginID = trace.BeginID;
                            i.EndID = trace.EndID;

                            i.Expression = trace.MeasureExpression;
                        }
                    });
                }

                #endregion

                #region Parse TextData "+"

                var measurePlusRegex = new Regex(@"\+\s+0\s+\((?<IDS>(\d+|\s+)+)\)", RegexOptions.Compiled);
                var tracePlusMeasures = traceEvents.AsParallel()
                    .Where((e) => measurePlusRegex.IsMatch(e.TextData))
                    .SelectMany((e) => measurePlusRegex.Match(e.TextData).Groups["IDS"].Value.Split(' ').Select((i) => new
                    {
                        MeasureID = i,
                        CurrentTime = e.CurrentTime,
                        TextData = e.TextData,
                        ID = e.ID,
                    }))
                    .GroupBy((e) => e.MeasureID)
                    .Select((g) =>
                    {
                        var expression = default(string);
                        var item = g.Where((p) => p.TextData.Contains("Expression:")).FirstOrDefault();
                        if (item != null)
                        {
                            var startIndex = item.TextData.IndexOf("Expression:") + "Expression:".Length;
                            expression = item.TextData.Substring(startIndex, item.TextData.IndexOf("</CalculationLocation>") - startIndex);
                        }

                        return new
                        {
                            MeasureID = g.Key,
                            MeasureName = default(string),
                            MeasureExpression = expression,
                            BeginTime = g.Min((p) => p.CurrentTime.Value),
                            EndTime = g.Max((p) => p.CurrentTime.Value),
                            BeginID = g.Min((p) => p.ID),
                            EndID = g.Max((p) => p.ID),
                        };
                    })
                    .ToList();

                if (tracePlusMeasures.Any())
                {
                    Parallel.ForEach(MeasureMetadataCollection, (m) =>
                    {
                        var trace = tracePlusMeasures.SingleOrDefault((t) => t.MeasureID == m.ID);
                        if (trace != null)
                        {
                            if (!m.InRange || m.BeginTime > trace.BeginTime)
                            {
                                m.BeginTime = trace.BeginTime;
                                m.BeginID = trace.BeginID;
                            }

                            if (!m.InRange || m.EndTime < trace.EndTime)
                            {
                                m.EndTime = trace.EndTime;
                                m.EndID = trace.EndID;
                            }

                            m.InRange = true;

                            if (trace.MeasureExpression != null)
                                m.Expression = trace.MeasureExpression;
                        }
                    });
                }

                #endregion

                #region Parse TextData "*"

                var measureStarRegex = new Regex(@"D:0\(Measures\)\s+\[\*\]\s+=&gt;\s+\(Measures\):\*", RegexOptions.Compiled);
                var traceStarMeasures = traceEvents.AsParallel()
                    .Where((e) => measureStarRegex.IsMatch(e.TextData))
                    .GroupBy((e) => 1)
                    .Select((g) =>
                    {
                        var expression = default(string);
                        var item = g.Where((p) => p.TextData.Contains("Expression:")).FirstOrDefault();
                        if (item != null)
                        {
                            var startIndex = item.TextData.IndexOf("Expression:") + "Expression:".Length;
                            expression = item.TextData.Substring(startIndex, item.TextData.IndexOf("</CalculationLocation>") - startIndex);
                        }

                        return new
                        {
                            MeasureExpression = expression,
                            BeginTime = g.Min((p) => p.CurrentTime.Value),
                            EndTime = g.Max((p) => p.CurrentTime.Value),
                            BeginID = g.Min((p) => p.ID),
                            EndID = g.Max((p) => p.ID),
                        };
                    })
                    .SingleOrDefault();

                if (traceStarMeasures != null)
                {
                    Parallel.ForEach(MeasureMetadataCollection.Where((i) => i.InRange), (m) =>
                    {
                        if (m.BeginTime > traceStarMeasures.BeginTime)
                        {
                            m.BeginTime = traceStarMeasures.BeginTime;
                            m.BeginID = traceStarMeasures.BeginID;
                        }

                        if (m.EndTime < traceStarMeasures.EndTime)
                        {
                            m.EndTime = traceStarMeasures.EndTime;
                            m.EndID = traceStarMeasures.EndID;
                        }

                        if (traceStarMeasures.MeasureExpression != null)
                            m.Expression = traceStarMeasures.MeasureExpression;
                    });
                }

                #endregion

#if DEBUG
                foreach (var measure in MeasureMetadataCollection.OrderBy((m) => m.Name))
                    Debug.Print("{0} - {1} [{2}] - {3}/{4} - {5:HH:mm:ss.fff}/{6:HH:mm:ss.fff} - {7}", measure.ID, measure.Name, measure.InRange, measure.BeginID, measure.EndID, measure.BeginTime, measure.EndTime, measure.Expression);
#endif
            }

            #endregion

            #region NonEmpty Activities

            #region NonEmpty Global

            private void InitializeNonEmptyGlobalComplexObjectsInQuery()
            {
                var nonEmptyGlobalComplexObjectsBeginInQuery = ProfilerEventsInCurrentRange
                                                                .Where((e) => e.EventClass == TraceEventClass.CalculateNonEmptyBegin)
                                                                    .Select((g) => new ComplexObject
                                                                    {
                                                                        Serie = null,
                                                                        SerieColor = Settings.Default.NonEmptyActivitiesColor,
                                                                        ComplexObjectName = nonEmptyGlobalSerieName,
                                                                        ComplexObjectID = nonEmptyGlobalSerieName,
                                                                        BeginEventID = g.ID,
                                                                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                                                                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                                                                        EndEventID = -1,
                                                                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                                                                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                                                                        MeasureGroupID = "N/A",
                                                                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                                                                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                                                                        ComplexObjectType = nonEmptyGlobalSerieName,
                                                                        ComplexObjectSubType = "N/A",
                                                                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                                                                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                                                                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                                                                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                                    })
                                                                    .OrderBy((y) => y.BeginEventID)
                                                                    .ToList();

                var nonEmptyGlobalComplexObjectsEndInQuery = ProfilerEventsInCurrentRange
                                                                .Where((e) => e.EventClass == TraceEventClass.CalculateNonEmptyEnd)
                                                                    .Select((g) => new ComplexObject
                                                                    {
                                                                        Serie = null,
                                                                        SerieColor = Settings.Default.NonEmptyActivitiesColor,
                                                                        ComplexObjectName = nonEmptyGlobalSerieName,
                                                                        ComplexObjectID = nonEmptyGlobalSerieName,
                                                                        BeginEventID = -1,
                                                                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                                                                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),

                                                                        EndEventID = g.ID,
                                                                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                                                                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                                                                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                                                                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                                                                        ComplexObjectType = nonEmptyGlobalSerieName,
                                                                        ComplexObjectSubType = "N/A",
                                                                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                                                                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                                                                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                                                                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                                    })
                                                                    .OrderBy((y) => y.BeginEventID)
                                                                    .ToList();

                for (int beginIndex = 0; beginIndex < nonEmptyGlobalComplexObjectsBeginInQuery.Count; beginIndex++)
                {
                    ComplexObject currentComplexObject = nonEmptyGlobalComplexObjectsBeginInQuery[beginIndex];

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _nonEmptysMenuItem,
                                                                           SeriesType.NonEmpty,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);

                }



                MergeBeginEndComplexObjects(
                                    NonEmptyGlobalComplexObjectsInWholeQuery,
                                    nonEmptyGlobalComplexObjectsBeginInQuery,
                                    nonEmptyGlobalComplexObjectsEndInQuery,
                                    nonEmptyGlobalSerieName
                                    );

                NonEmptyGlobalComplexObjectsInCurrentRange = NonEmptyGlobalComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeNonEmptyGlobalComplexObjects()
            {
                InitializeNonEmptyGlobalComplexObjectsInQuery();

                subSeriesName.Clear();
                subSeriesName = NonEmptyGlobalComplexObjectsInWholeQuery
                        .Select(co => co.ComplexObjectName)
                        .Distinct()
                        .ToList(); 
                
                UpdateComplexObjectsContextMenuItems(NonEmptyGlobalComplexObjectsInCurrentRange, SeriesType.NonEmpty, subSeriesName);
            }

            #endregion

            #region NonEmpty GetData

            private void InitializeNonEmptyGetDataEvents(List<ProfilerItem> nonEmptyGetDataBeginInRange, List<ProfilerItem> nonEmptyGetDataEndInRange)
            {
                var AllNonEmptyEnd = ProfilerEventsInCurrentRange
                    .Where((e) => e.EventClass == TraceEventClass.CalculateNonEmptyEnd)
                    .OrderBy((e) => e.ID)
                    .ToList();

                // All GetData
                var AllGetData = ProfilerEventsInCurrentRange
                        .Where((e) => e.EventClass == TraceEventClass.CalculateNonEmptyCurrent &&
                            e.EventSubclass == TraceEventSubclass.GetData)
                        .OrderBy((e) => e.ID)
                        .ToList();

                // Remove possibly consecutives Begin taking only the first one (the one with the lower ID)
                int previousPostID = 0;
                for (int endIndex = 0; endIndex < AllNonEmptyEnd.Count; endIndex++)
                {
                    //NonEmptyGetDataEndInRange.Add(AllNonEmptyEnd[endIndex]);
                    int currentPostID = AllNonEmptyEnd[endIndex].ID;
                    var AllGetDataBeforeNonEmptyEnd = AllGetData
                            .Where((e) => e.ID > previousPostID &&
                            e.ID < currentPostID)
                        .OrderBy((e) => e.ID)
                        .ToList();
                    previousPostID = currentPostID;

                    int previous = -1; //--> (-1 --> unknown; 0 --> progress == 0; 1 --> progress > 0)
                    int current = -1; //--> (-1 --> unknown; 0 --> progress == 0; 1 --> progress > 0)
                    int next = -1; //--> (-1 --> unknown; 0 --> progress == 0; 1 --> progress > 0)
                    for (int getDataIndex = 0; getDataIndex < AllGetDataBeforeNonEmptyEnd.Count; getDataIndex++)
                    {
                        var currentGetData = AllGetDataBeforeNonEmptyEnd[getDataIndex];
                        current = (currentGetData.ProgressTotal > 0) ? 1 : 0;
                        if (current == 0)
                        {
                            if (previous != 0) //--> Surely it is a BEGIN
                            {
                                nonEmptyGetDataBeginInRange.Add(currentGetData);
                            }
                            previous = current;
                        }
                        else
                        {
                            if (getDataIndex == AllGetDataBeforeNonEmptyEnd.Count - 1) //--> Surely it is an END
                            {
                                nonEmptyGetDataEndInRange.Add(currentGetData);
                            }
                            else
                            {
                                var nexGetData = AllGetDataBeforeNonEmptyEnd[getDataIndex + 1];
                                next = (nexGetData.ProgressTotal > 0) ? 1 : 0;
                                if (next == 0) //--> Surely it is an END
                                {
                                    nonEmptyGetDataEndInRange.Add(currentGetData);
                                }
                                previous = current;
                            }
                        }
                    }
                }

            }

            private void InitializeNonEmptyGetDataComplexObjectsInQuery()
            {
                
                List<ProfilerItem> NonEmptyGetDataBeginInRange = new List<ProfilerItem>();
                List<ProfilerItem> NonEmptyGetDataEndInRange = new List<ProfilerItem>();

                InitializeNonEmptyGetDataEvents(NonEmptyGetDataBeginInRange, NonEmptyGetDataEndInRange);

                var nonEmptyGetDataComplexObjectsBeginInQuery = NonEmptyGetDataBeginInRange
                                                                    .Select((g) => new ComplexObject
                                                                    {
                                                                        Serie = null,
                                                                        SerieColor = Settings.Default.NonEmptyActivitiesColor,
                                                                        ComplexObjectName = nonEmptyGetDataSerieName,
                                                                        ComplexObjectID = nonEmptyGetDataSerieName,
                                                                        BeginEventID = g.ID,
                                                                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                                                                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                                                                        EndEventID = -1,
                                                                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                                                                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                                                                        MeasureGroupID = "N/A",
                                                                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                                                                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                                                                        ComplexObjectType = nonEmptyGetDataSerieName,
                                                                        ComplexObjectSubType = "N/A",
                                                                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                                                                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                                                                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                                                                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                                    })
                                                                    .OrderBy((y) => y.BeginEventID)
                                                                    .ToList();

                var nonEmptyGetDataComplexObjectsEndInQuery = NonEmptyGetDataEndInRange
                                                                    .Select((g) => new ComplexObject
                                                                    {
                                                                        Serie = null,
                                                                        SerieColor = Settings.Default.NonEmptyActivitiesColor,
                                                                        ComplexObjectName = nonEmptyGetDataSerieName,
                                                                        ComplexObjectID = nonEmptyGetDataSerieName,
                                                                        BeginEventID = -1,
                                                                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                                                                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),

                                                                        EndEventID = g.ID,
                                                                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                                                                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                                                                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                                                                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                                                                        ComplexObjectType = nonEmptyGetDataSerieName,
                                                                        ComplexObjectSubType = "N/A",
                                                                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                                                                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                                                                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                                                                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                                    })
                                                                    .OrderBy((y) => y.BeginEventID)
                                                                    .ToList();

                for (int beginIndex = 0; beginIndex < nonEmptyGetDataComplexObjectsBeginInQuery.Count; beginIndex++)
                {
                    ComplexObject currentComplexObject = nonEmptyGetDataComplexObjectsBeginInQuery[beginIndex];

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _nonEmptysMenuItem,
                                                                           SeriesType.NonEmpty,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);

                }



                MergeBeginEndComplexObjects(
                                    NonEmptyGetDataComplexObjectsInWholeQuery,
                                    nonEmptyGetDataComplexObjectsBeginInQuery,
                                    nonEmptyGetDataComplexObjectsEndInQuery,
                                    nonEmptyGetDataSerieName
                                    );

                NonEmptyGetDataComplexObjectsInCurrentRange = NonEmptyGetDataComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeNonEmptyGetDataComplexObjects()
            {
                InitializeNonEmptyGetDataComplexObjectsInQuery();

                subSeriesName.Clear();
                subSeriesName = NonEmptyGetDataComplexObjectsInWholeQuery
                        .Select(co => co.ComplexObjectName)
                        .Distinct()
                        .ToList(); 
                
                UpdateComplexObjectsContextMenuItems(NonEmptyGetDataComplexObjectsInCurrentRange, SeriesType.NonEmpty, subSeriesName);
            }

            #endregion

            #region NonEmpty PostOrder

            private void InitializeNonEmptyPostOrderComplexObjectsInQuery()
            {
                var NonEmptyPostOrdersInQuery = ProfilerEventsInCurrentRange
                    .Where((e) => e.EventClass == TraceEventClass.CalculateNonEmptyCurrent &&
                            e.EventSubclass == TraceEventSubclass.PostOrder)
                    .Select((g) => new ComplexObject
                    {
                        Serie = null,
                        SerieColor = Settings.Default.NonEmptyActivitiesColor,
                        ComplexObjectName = nonEmptyPostOrderSerieName,
                        ComplexObjectID = nonEmptyPostOrderSerieName,
                        BeginEventID = g.ID,
                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                        EndEventID = g.ID,
                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                        MeasureGroupID = "N/A",
                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                        ComplexObjectType = nonEmptyPostOrderSerieName,
                        ComplexObjectSubType = "N/A",
                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                    })
                    .OrderBy((y) => y.BeginEventID)
                    .ToList();

                for (int beginIndex = 0; beginIndex < NonEmptyPostOrdersInQuery.Count; beginIndex++)
                {
                    ComplexObject currentComplexObject = NonEmptyPostOrdersInQuery[beginIndex];

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//NonEmptyPostOrderSeries,
                                                                           _nonEmptysMenuItem,
                                                                           SeriesType.NonEmpty,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);

                    NonEmptyPostOrderComplexObjectsInWholeQuery.Add(currentComplexObject);
                }


                NonEmptyPostOrderComplexObjectsInCurrentRange = NonEmptyPostOrderComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeNonEmptyPostOrderComplexObjects()
            {
                InitializeNonEmptyPostOrderComplexObjectsInQuery();

                subSeriesName.Clear();
                subSeriesName = NonEmptyPostOrderComplexObjectsInWholeQuery
                        .Select(co => co.ComplexObjectName)
                        .Distinct()
                        .ToList(); 

                UpdateComplexObjectsContextMenuItems(NonEmptyPostOrderComplexObjectsInCurrentRange, SeriesType.NonEmpty, subSeriesName);
            }

            #endregion

            #endregion

            #region Serialization Activities

            #region Serialize Global

            private void InitializeSerializeGlobalComplexObjectsInQuery()
            {
                var SerializeGlobalComplexObjectsBeginInQuery = ProfilerEventsInCurrentRange
                                                                .Where((e) =>
                                                                    e.EventClass == TraceEventClass.SerializeResultsBegin
                                                                    )
                                                                    .Select((g) => new ComplexObject
                                                                    {
                                                                        Serie = null,
                                                                        SerieColor = Settings.Default.SerializationActivitiesColor,
                                                                        ComplexObjectName = serializeGlobalSerieName,
                                                                        ComplexObjectID = serializeGlobalSerieName,
                                                                        BeginEventID = g.ID,
                                                                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                                                                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                                                                        EndEventID = -1,
                                                                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                                                                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                                                                        MeasureGroupID = "N/A",
                                                                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                                                                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                                                                        ComplexObjectType = serializeGlobalSerieName,
                                                                        ComplexObjectSubType = "N/A",
                                                                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                                                                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                                                                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                                                                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                                    })
                                                                    .OrderBy((y) => y.BeginEventID)
                                                                    .ToList();

                var SerializeGlobalComplexObjectsEndInQuery = ProfilerEventsInCurrentRange
                                                                .Where((e) =>
                                                                    e.EventClass == TraceEventClass.SerializeResultsEnd
                                                                    ).Select((g) => new ComplexObject
                                                                    {
                                                                        Serie = null,
                                                                        SerieColor = Settings.Default.SerializationActivitiesColor,
                                                                        ComplexObjectName = serializeGlobalSerieName,
                                                                        ComplexObjectID = serializeGlobalSerieName,
                                                                        BeginEventID = -1,
                                                                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                                                                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                                                                        MeasureGroupID = "N/A",
                                                                        EndEventID = g.ID,
                                                                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                                                                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                                                                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                                                                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                                                                        ComplexObjectType = serializeGlobalSerieName,
                                                                        ComplexObjectSubType = "N/A",
                                                                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                                                                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                                                                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                                                                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                                    })
                                                                    .OrderBy((y) => y.BeginEventID)
                                                                    .ToList();

                for (int beginIndex = 0; beginIndex < SerializeGlobalComplexObjectsBeginInQuery.Count; beginIndex++)
                {
                    ComplexObject currentComplexObject = SerializeGlobalComplexObjectsBeginInQuery[beginIndex];

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _serializationsMenuItem,
                                                                           SeriesType.Serialization,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);

                }



                MergeBeginEndComplexObjects(
                                    SerializeGlobalComplexObjectsInWholeQuery,
                                    SerializeGlobalComplexObjectsBeginInQuery,
                                    SerializeGlobalComplexObjectsEndInQuery,
                                    "SerializeGlobal"
                                    );

                SerializeGlobalComplexObjectsInCurrentRange = SerializeGlobalComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeSerializeGlobalComplexObjects()
            {
                InitializeSerializeGlobalComplexObjectsInQuery();

                subSeriesName.Clear();
                subSeriesName = SerializeGlobalComplexObjectsInWholeQuery
                        .Select(co => co.ComplexObjectName)
                        .Distinct()
                        .ToList(); 

                UpdateComplexObjectsContextMenuItems(SerializeGlobalComplexObjectsInCurrentRange, SeriesType.Serialization, subSeriesName);
            }

            #endregion

            #region Serialize Axes

            private void InitializeSerializeAxesComplexObjectsInQuery()
            {
                var SerializeAxesComplexObjectsBeginInQuery = ProfilerEventsInCurrentRange
                                                                .Where((e) =>
                                                                    e.EventClass == TraceEventClass.SerializeResultsCurrent &&
                                                                    e.EventSubclass == TraceEventSubclass.SerializeAxes &&
                                                                    e.TextData != null &&
                                                                    e.ProgressTotal == null
                                                                    )
                                                                    .Select((g) => new ComplexObject
                                                                    {
                                                                        Serie = null,
                                                                        SerieColor = Settings.Default.SerializationActivitiesColor,
                                                                        ComplexObjectName = g.TextData,
                                                                        ComplexObjectID = g.TextData,
                                                                        BeginEventID = g.ID,
                                                                        BeginEventTime = (g.StartTime ?? g.CurrentTime).Value,
                                                                        BeginEventTimeOADate = (g.StartTime ?? g.CurrentTime).Value.ToOADate(),
                                                                        EndEventID = -1,
                                                                        EndEventTime = (g.CurrentTime ?? g.StartTime).Value,
                                                                        EndEventTimeOADate = (g.CurrentTime ?? g.StartTime).Value.ToOADate(),
                                                                        MeasureGroupID = "N/A",
                                                                        ComplexObjectDuration = (g.Duration != null) ? g.Duration : 0,
                                                                        ComplexObjectReadDuration = (long?)(g.CurrentTime ?? g.StartTime).Value.Subtract((g.StartTime ?? g.CurrentTime).Value).TotalMilliseconds,
                                                                        ComplexObjectType = g.TextData,
                                                                        ComplexObjectSubType = "N/A",
                                                                        ComplexObjectPath = (g.ObjectPath != null) ? g.ObjectPath : "N/A",
                                                                        ComplexObjectTextData = (g.TextData != null) ? g.TextData : "N/A",
                                                                        ComplexObjectProgressTotal = (g.ProgressTotal != null) ? g.ProgressTotal : 0,
                                                                        ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                                    })
                                                                    .OrderBy((y) => y.BeginEventID)
                                                                    .ToList();

                var SerializeAxesEndInQuery = ProfilerEventsInCurrentRange
                                                                .Where((e) =>
                                                                    e.EventClass == TraceEventClass.SerializeResultsCurrent &&
                                                                    e.EventSubclass == TraceEventSubclass.SerializeAxes &&
                                                                    e.TextData == null &&
                                                                    e.ProgressTotal != null
                                                                    )
                                                                    .OrderBy((y) => y.ID)
                                                                    .ToList();

                List<ComplexObject> SerializeAxesComplexObjectsEndInQuery = new List<ComplexObject>(); ;

                int nextID = -1;

                for (int beginIndex = 0; beginIndex < SerializeAxesComplexObjectsBeginInQuery.Count; beginIndex++)
                {
                    ComplexObject currentComplexObject = SerializeAxesComplexObjectsBeginInQuery[beginIndex];

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _serializationsMenuItem,
                                                                           SeriesType.Serialization,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);

                    var endEvents = SerializeAxesEndInQuery
                        .Where((g) => g.ID > currentComplexObject.BeginEventID);

                    if (beginIndex < SerializeAxesComplexObjectsBeginInQuery.Count - 1)
                    {
                        // nextID is equal to the one of the next Begin event of the same type
                        nextID = SerializeAxesComplexObjectsBeginInQuery[beginIndex + 1].BeginEventID;
                    }
                    else
                    {
                        nextID = _lastEventID;
                    }

                    if (nextID != -1)
                        endEvents = endEvents.Where((g) => g.ID < nextID);

                    var endEvent = endEvents.OrderBy((c) => c.ID).Last();

                    SerializeAxesComplexObjectsEndInQuery.Add(new ComplexObject
                                                            {
                                                                Serie = null,
                                                                SerieColor = Settings.Default.SerializationActivitiesColor,
                                                                ComplexObjectName = currentComplexObject.ComplexObjectName,
                                                                ComplexObjectID = currentComplexObject.ComplexObjectID,
                                                                BeginEventID = -1,
                                                                BeginEventTime = (endEvent.StartTime ?? endEvent.CurrentTime).Value,
                                                                BeginEventTimeOADate = (endEvent.StartTime ?? endEvent.CurrentTime).Value.ToOADate(),
                                                                MeasureGroupID = "N/A",
                                                                EndEventID = endEvent.ID,
                                                                EndEventTime = (endEvent.CurrentTime ?? endEvent.StartTime).Value,
                                                                EndEventTimeOADate = (endEvent.CurrentTime ?? endEvent.StartTime).Value.ToOADate(),
                                                                ComplexObjectDuration = (endEvent.Duration != null) ? endEvent.Duration : 0,
                                                                ComplexObjectReadDuration = (long?)(endEvent.CurrentTime ?? endEvent.StartTime).Value.Subtract((endEvent.StartTime ?? endEvent.CurrentTime).Value).TotalMilliseconds,
                                                                ComplexObjectType = currentComplexObject.ComplexObjectType,
                                                                ComplexObjectSubType = "N/A",
                                                                ComplexObjectPath = (endEvent.ObjectPath != null) ? endEvent.ObjectPath : "N/A",
                                                                ComplexObjectTextData = (endEvent.TextData != null) ? endEvent.TextData : "N/A",
                                                                ComplexObjectProgressTotal = (endEvent.ProgressTotal != null) ? endEvent.ProgressTotal : 0,
                                                                ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                            });
                }

                MergeBeginEndComplexObjects(
                                    SerializeAxesComplexObjectsInWholeQuery,
                                    SerializeAxesComplexObjectsBeginInQuery,
                                    SerializeAxesComplexObjectsEndInQuery,
                                    "SerializeAxes"
                                    );

                SerializeAxesComplexObjectsInCurrentRange = SerializeAxesComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeSerializeAxesComplexObjects()
            {
                InitializeSerializeAxesComplexObjectsInQuery();

                subSeriesName.Clear();
                subSeriesName = SerializeAxesComplexObjectsInWholeQuery
                        .Select(co => co.ComplexObjectName)
                        .Distinct()
                        .ToList(); 
                
                UpdateComplexObjectsContextMenuItems(SerializeAxesComplexObjectsInCurrentRange, SeriesType.Serialization, subSeriesName);
            }

            #endregion

            #region Serialize Cells

            private void InitializeSerializeCellsComplexObjectsInQuery()
            {
                List<ComplexObject> SerializeCellsComplexObjectsBeginInQuery = new List<ComplexObject>(); ;
                List<ComplexObject> SerializeCellsComplexObjectsEndInQuery = new List<ComplexObject>(); ;

                var SerializeCellsBeginInQuery = ProfilerEventsInCurrentRange
                                                    .Where((e) => e.EventClass == TraceEventClass.SerializeResultsCurrent && e.EventSubclass == TraceEventSubclass.SerializeCells && e.TextData == null && e.ProgressTotal != null)
                                                    .OrderBy((e) => e.ID)
                                                    .First();
                if (SerializeCellsBeginInQuery != null)
                {
                    SerializeCellsComplexObjectsBeginInQuery.Add(new ComplexObject
                                                        {
                                                            Serie = null,
                                                            SerieColor = Settings.Default.SerializationActivitiesColor,
                                                            ComplexObjectName = serializeCellsAxisSerieName,
                                                            ComplexObjectID = serializeCellsAxisSerieName,
                                                            BeginEventID = SerializeCellsBeginInQuery.ID,
                                                            BeginEventTime = (SerializeCellsBeginInQuery.StartTime ?? SerializeCellsBeginInQuery.CurrentTime).Value,
                                                            BeginEventTimeOADate = (SerializeCellsBeginInQuery.StartTime ?? SerializeCellsBeginInQuery.CurrentTime).Value.ToOADate(),
                                                            EndEventID = -1,
                                                            EndEventTime = (SerializeCellsBeginInQuery.CurrentTime ?? SerializeCellsBeginInQuery.StartTime).Value,
                                                            EndEventTimeOADate = (SerializeCellsBeginInQuery.CurrentTime ?? SerializeCellsBeginInQuery.StartTime).Value.ToOADate(),
                                                            MeasureGroupID = "N/A",
                                                            ComplexObjectDuration = (SerializeCellsBeginInQuery.Duration != null) ? SerializeCellsBeginInQuery.Duration : 0,
                                                            ComplexObjectReadDuration = (long?)(SerializeCellsBeginInQuery.CurrentTime ?? SerializeCellsBeginInQuery.StartTime).Value.Subtract((SerializeCellsBeginInQuery.StartTime ?? SerializeCellsBeginInQuery.CurrentTime).Value).TotalMilliseconds,
                                                            ComplexObjectType = serializeCellsAxisSerieName,
                                                            ComplexObjectSubType = "N/A",
                                                            ComplexObjectPath = (SerializeCellsBeginInQuery.ObjectPath != null) ? SerializeCellsBeginInQuery.ObjectPath : "N/A",
                                                            ComplexObjectTextData = (SerializeCellsBeginInQuery.TextData != null) ? SerializeCellsBeginInQuery.TextData : "N/A",
                                                            ComplexObjectProgressTotal = (SerializeCellsBeginInQuery.ProgressTotal != null) ? SerializeCellsBeginInQuery.ProgressTotal : 0,
                                                            ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                        });
                }

                var SerializeCellsEndInQuery = ProfilerEventsInCurrentRange
                                                    .Where((e) => e.EventClass == TraceEventClass.SerializeResultsCurrent && e.EventSubclass == TraceEventSubclass.SerializeCells && e.TextData == null && e.ProgressTotal != null)
                                                    .OrderBy((e) => e.ID)
                                                    .Last();
                if (SerializeCellsEndInQuery != null)
                {
                    SerializeCellsComplexObjectsEndInQuery.Add( new ComplexObject
                                                        {
                                                            Serie = null,
                                                            SerieColor = Settings.Default.SerializationActivitiesColor,
                                                            ComplexObjectName = serializeCellsAxisSerieName,
                                                            ComplexObjectID = serializeCellsAxisSerieName,
                                                            BeginEventID = -1,
                                                            BeginEventTime = (SerializeCellsEndInQuery.StartTime ?? SerializeCellsEndInQuery.CurrentTime).Value,
                                                            BeginEventTimeOADate = (SerializeCellsEndInQuery.StartTime ?? SerializeCellsEndInQuery.CurrentTime).Value.ToOADate(),
                                                            MeasureGroupID = "N/A",
                                                            EndEventID = SerializeCellsEndInQuery.ID,
                                                            EndEventTime = (SerializeCellsEndInQuery.CurrentTime ?? SerializeCellsEndInQuery.StartTime).Value,
                                                            EndEventTimeOADate = (SerializeCellsEndInQuery.CurrentTime ?? SerializeCellsEndInQuery.StartTime).Value.ToOADate(),
                                                            ComplexObjectDuration = (SerializeCellsEndInQuery.Duration != null) ? SerializeCellsEndInQuery.Duration : 0,
                                                            ComplexObjectReadDuration = (long?)(SerializeCellsEndInQuery.CurrentTime ?? SerializeCellsEndInQuery.StartTime).Value.Subtract((SerializeCellsEndInQuery.StartTime ?? SerializeCellsEndInQuery.CurrentTime).Value).TotalMilliseconds,
                                                            ComplexObjectType = serializeCellsAxisSerieName,
                                                            ComplexObjectSubType = "N/A",
                                                            ComplexObjectPath = (SerializeCellsEndInQuery.ObjectPath != null) ? SerializeCellsEndInQuery.ObjectPath : "N/A",
                                                            ComplexObjectTextData = (SerializeCellsEndInQuery.TextData != null) ? SerializeCellsEndInQuery.TextData : "N/A",
                                                            ComplexObjectProgressTotal = (SerializeCellsEndInQuery.ProgressTotal != null) ? SerializeCellsEndInQuery.ProgressTotal : 0,
                                                            ComplexObjectProgressTotalUnitMeasure = string.Empty,
                                                        });
    }
                for (int beginIndex = 0; beginIndex < SerializeCellsComplexObjectsBeginInQuery.Count; beginIndex++)
                {
                    var currentComplexObject = SerializeCellsComplexObjectsBeginInQuery[beginIndex];

                    currentComplexObject.Serie = CreateComplexObjectsChartSeries(//DimensionSeries,
                                                                           _serializationsMenuItem,
                                                                           SeriesType.Serialization,
                                                                           currentComplexObject.ComplexObjectName,
                                                                           currentComplexObject.SerieColor.Value);
                }

                MergeBeginEndComplexObjects(
                                    SerializeCellsComplexObjectsInWholeQuery,
                                    SerializeCellsComplexObjectsBeginInQuery,
                                    SerializeCellsComplexObjectsEndInQuery,
                                    "SerializeCells"
                                    );

                SerializeCellsComplexObjectsInCurrentRange = SerializeCellsComplexObjectsInWholeQuery.ToList();
            }

            private void InitializeSerializeCellsComplexObjects()
            {
                InitializeSerializeCellsComplexObjectsInQuery();

                subSeriesName.Clear();
                subSeriesName = SerializeCellsComplexObjectsInWholeQuery
                        .Select(co => co.ComplexObjectName)
                        .Distinct()
                        .ToList(); 
                
                UpdateComplexObjectsContextMenuItems(SerializeCellsComplexObjectsInCurrentRange, SeriesType.Serialization, subSeriesName);
            }
            

            #endregion

            #endregion

            #endregion
        }

        #endregion

        private AnalyzerStatistics _analyzerStatistics;

        internal TimelineHelper ColdTimelineHelper { get; private set; }
        internal TimelineHelper WarmTimelineHelper { get; private set; }  
      
        public ResultPresenterAnalyzerResultTimelineControl()
		{
            InitializeComponent();

            var iconBitmap = SystemIcons.Information.ToBitmap();
            pictureBoxMessageCold.Image = iconBitmap;
            pictureBoxMessageWarm.Image = iconBitmap;
		}

		public void UpdateStatistics(AnalyzerStatistics analyzerStatistics)
		{
			_analyzerStatistics = analyzerStatistics;

            ColdTimelineHelper = new TimelineHelper(this, AnalysisTypes.Cold, _analyzerStatistics.ColdCacheExecutionResult);
            WarmTimelineHelper = new TimelineHelper(this, AnalysisTypes.Warm, _analyzerStatistics.WarmCacheExecutionResult);
		}

        private void tableLayoutPanelCold_Paint(object sender, PaintEventArgs e)
        {
            panelTimelineZoomCold.Refresh();
        }

        private void tableLayoutPanelWarm_Paint(object sender, PaintEventArgs e)
        {
            panelTimelineZoomWarm.Refresh();
        }
	}
}