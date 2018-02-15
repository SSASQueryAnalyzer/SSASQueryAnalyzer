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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System.Drawing;

    public struct ResultPresenterConfiguration
    {
        #region Engine

        //public enum MandatoryProfilerEvents : int
        //{
        //    Progress_Report_Begin = 5,
        //    Progress_Report_End = 6,
        //    Query_Begin = 9,
        //    Query_End = 10,
        //    Query_Subcube = 11,
        //    Get_Data_From_Aggregation = 60,
        //    Get_Data_From_Cache = 61,
        //    Calculate_Non_Empty_Begin = 72,
        //    Calculate_Non_Empty_Current = 73,
        //    Calculate_Non_Empty_End = 74,
        //    Serialize_Results_Begin = 75,
        //    Serialize_Results_Current = 76,
        //    Serialize_Results_End = 77,
        //    Resource_Usage = 84
        //};

        //public static StringCollection DefaultOptionalProfilerEvents = new StringCollection();

        //public enum MandatoryPerformanceCounters : int
        //{
        //    // to do
        //};

        //public static StringCollection DefaultOptionalPerformanceCounters = new StringCollection();

        #endregion

        #region General

        public static Color DefaultLabelsColor = SystemColors.WindowText;
        public static Color DefaultLinesColor = SystemColors.WindowText;
        public static Color DefaultObjectsBackColor = SystemColors.Control;
        public static Color DefaultWindowBackColor = SystemColors.Window;
        public static int DefaultMaxRowsReturned = 0;

        #endregion

        #region SSMS

        public static Color DefaultASQAWindowTitleTextColor = Color.Yellow;
        public static bool DefaultAddInAutomaticallyCheckNewVersion = true;
        public static bool DefaultDebugEnabled = false;
        public static bool DefaultExecutionProgressActivitiesEnabled = false;

        #endregion

        #region Result Presenter Analyzer Result Objects

        #region Common

        public static Color DefaultColdCacheColor = CustomColor.ColdColor;
        public static Color DefaultColdCacheGraphBarColor1 = CustomColor.ColdColorLight;
        public static Color DefaultColdCacheGraphBarColor2 = SystemColors.Window;
        public static Color DefaultWarmCacheColor = CustomColor.WarmColor;
        public static Color DefaultWarmCacheGraphBarColor1 = CustomColor.WarmColorLight;
        public static Color DefaultWarmCacheGraphBarColor2 = SystemColors.Window;        
        public static Color DefaultHighlightColor = CustomColor.HighlightColor;

        #endregion

        #region Timeline colors

        public static Color DefaultProfilerEventsColor = CustomColor.ProfilerEventsColor;
        public static Color DefaultPerformanceCountersColor = CustomColor.PerformanceCountersColor;
        public static Color DefaultCachesColor = CustomColor.CachesColor;
        public static Color DefaultAggregationsColor = CustomColor.AggregationsColor;
        public static Color DefaultPartitionsColor = CustomColor.PartitionsColor;
        public static Color DefaultCachedDimensionsColor = CustomColor.CachedDimensionsColor;
        public static Color DefaultNonCachedDimensionsColor = CustomColor.NonCachedDimensionsColor;
        public static Color DefaultRegularMeasuresColor = CustomColor.RegularMeasuresColor;
        public static Color DefaultCalculatedMeasuresColor = CustomColor.CalculatedMeasuresColor;
        public static Color DefaultNonEmptyActivitiesColor = CustomColor.NonEmptyActivitiesColor;
        public static Color DefaultSerializationActivitiesColor = CustomColor.SerializationActivitiesColor;

        #endregion

        #region Timeline others

        public static int DefaultTimelineEventsNumberThreshold = 1000;
        public static bool TimelineCachesVisible = false;
        public static bool TimelineAggregationsVisible = false;
        public static bool TimelinePartitionsVisible = false;
        public static bool TimelineDimensionsVisible = false;
        public static bool TimelineMeasuresVisible = false;
        public static bool TimelineNonEmptyActivitiesVisible = false;
        public static bool TimelineSerializationActivitiesVisible = false;

        #endregion

        #region Data Retrieve

        //public static Color DefaultColdCacheComputationModeGaugesONBackColor = CustomColor.ColdColor;
        //public static Color DefaultWarmCacheComputationModeGaugesONBackColor = CustomColor.WarmColor;

        #endregion

        #region Progress

        public static Color DefaultInProgressTextColor = CustomColor.InProgressColor;
        public static Color DefaultCompletedTextColor = CustomColor.CompletedColor;
        public static Color DefaultStoppedTextColor = CustomColor.StoppedColor;
        public static Color DefaultInactiveTextColor = CustomColor.InactiveColor;
        public static Color DefaultActiveTextColor = CustomColor.ActiveColor;

        #endregion

        #endregion
    }
}
