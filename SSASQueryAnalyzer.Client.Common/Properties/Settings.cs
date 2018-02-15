namespace SSASQueryAnalyzer.Client.Common.Properties
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using System.Configuration;

    public sealed partial class Settings
    {        
        public Settings()
        {
            this.SettingsLoaded += OnSettingsLoadedEventHandler;
        }

        private void OnSettingsLoadedEventHandler(object sender, SettingsLoadedEventArgs e)
        {
            #region Version

            if (this.PropertyValues["AddInAutomaticallyCheckNewVersion"].PropertyValue == null)
                this.AddInAutomaticallyCheckNewVersion = ResultPresenterConfiguration.DefaultAddInAutomaticallyCheckNewVersion;

            #endregion

            #region Global

            if (this.PropertyValues["ColdCacheColor"].PropertyValue == null)
                this.ColdCacheColor = ResultPresenterConfiguration.DefaultColdCacheColor;
            if (this.PropertyValues["ColdCacheGraphBarColor1"].PropertyValue == null)
                this.ColdCacheGraphBarColor1 = ResultPresenterConfiguration.DefaultColdCacheGraphBarColor1;
            if (this.PropertyValues["ColdCacheGraphBarColor2"].PropertyValue == null)
                this.ColdCacheGraphBarColor2 = ResultPresenterConfiguration.DefaultColdCacheGraphBarColor2;
            
            if (this.PropertyValues["WarmCacheColor"].PropertyValue == null)
                this.WarmCacheColor = ResultPresenterConfiguration.DefaultWarmCacheColor;
            if (this.PropertyValues["WarmCacheGraphBarColor1"].PropertyValue == null)
                this.WarmCacheGraphBarColor1 = ResultPresenterConfiguration.DefaultWarmCacheGraphBarColor1;
            if (this.PropertyValues["WarmCacheGraphBarColor2"].PropertyValue == null)
                this.WarmCacheGraphBarColor2 = ResultPresenterConfiguration.DefaultWarmCacheGraphBarColor2;

            if (this.PropertyValues["HighlightColor"].PropertyValue == null)
                this.HighlightColor = ResultPresenterConfiguration.DefaultHighlightColor;

            if (this.PropertyValues["MaxRowsReturned"].PropertyValue == null)
                this.MaxRowsReturned = ResultPresenterConfiguration.DefaultMaxRowsReturned;

            if (this.PropertyValues["DebugEnabled"].PropertyValue == null)
                this.DebugEnabled = ResultPresenterConfiguration.DefaultDebugEnabled;

            if (this.PropertyValues["ExecutionProgressActivitiesEnabled"].PropertyValue == null)
                this.ExecutionProgressActivitiesEnabled = ResultPresenterConfiguration.DefaultExecutionProgressActivitiesEnabled;
            #endregion

            #region Timeline Colors

            if (this.PropertyValues["ProfilerEventsColor"].PropertyValue == null)
                this.ProfilerEventsColor = ResultPresenterConfiguration.DefaultProfilerEventsColor;

            if (this.PropertyValues["PerformanceCountersColor"].PropertyValue == null)
                this.PerformanceCountersColor = ResultPresenterConfiguration.DefaultPerformanceCountersColor;

            if (this.PropertyValues["CachesColor"].PropertyValue == null)
                this.CachesColor = ResultPresenterConfiguration.DefaultCachesColor;

            if (this.PropertyValues["AggregationsColor"].PropertyValue == null)
                this.AggregationsColor = ResultPresenterConfiguration.DefaultAggregationsColor;

            if (this.PropertyValues["PartitionsColor"].PropertyValue == null)
                this.PartitionsColor = ResultPresenterConfiguration.DefaultPartitionsColor;

            if (this.PropertyValues["CachedDimensionsColor"].PropertyValue == null)
                this.CachedDimensionsColor = ResultPresenterConfiguration.DefaultCachedDimensionsColor;

            if (this.PropertyValues["NonCachedDimensionsColor"].PropertyValue == null)
                this.NonCachedDimensionsColor = ResultPresenterConfiguration.DefaultNonCachedDimensionsColor; 

            if (this.PropertyValues["RegularMeasuresColor"].PropertyValue == null)
                this.RegularMeasuresColor = ResultPresenterConfiguration.DefaultRegularMeasuresColor;

            if (this.PropertyValues["CalculatedMeasuresColor"].PropertyValue == null)
                this.CalculatedMeasuresColor = ResultPresenterConfiguration.DefaultCalculatedMeasuresColor; 
            
            if (this.PropertyValues["NonEmptyActivitiesColor"].PropertyValue == null)
                this.NonEmptyActivitiesColor = ResultPresenterConfiguration.DefaultNonEmptyActivitiesColor;

            if (this.PropertyValues["SerializationActivitiesColor"].PropertyValue == null)
                this.SerializationActivitiesColor = ResultPresenterConfiguration.DefaultSerializationActivitiesColor;

            #endregion

            #region Timeline others

            if (this.PropertyValues["TimelineEventsNumberThreshold"].PropertyValue == null)
                this.TimelineEventsNumberThreshold = ResultPresenterConfiguration.DefaultTimelineEventsNumberThreshold;

            if (this.PropertyValues["TimelineCachesVisible"].PropertyValue == null)
                this.TimelineCachesVisible = ResultPresenterConfiguration.TimelineCachesVisible;

            if (this.PropertyValues["TimelineAggregationsVisible"].PropertyValue == null)
                this.TimelineAggregationsVisible = ResultPresenterConfiguration.TimelineAggregationsVisible;

            if (this.PropertyValues["TimelinePartitionsVisible"].PropertyValue == null)
                this.TimelinePartitionsVisible = ResultPresenterConfiguration.TimelinePartitionsVisible;

            if (this.PropertyValues["TimelineDimensionsVisible"].PropertyValue == null)
                this.TimelineDimensionsVisible = ResultPresenterConfiguration.TimelineDimensionsVisible;

            if (this.PropertyValues["TimelineMeasuresVisible"].PropertyValue == null)
                this.TimelineMeasuresVisible = ResultPresenterConfiguration.TimelineMeasuresVisible;

            if (this.PropertyValues["TimelineNonEmptyActivitiesVisible"].PropertyValue == null)
                this.TimelineNonEmptyActivitiesVisible = ResultPresenterConfiguration.TimelineNonEmptyActivitiesVisible;

            if (this.PropertyValues["TimelineSerializationActivitiesVisible"].PropertyValue == null)
                this.TimelineSerializationActivitiesVisible = ResultPresenterConfiguration.TimelineSerializationActivitiesVisible;


            #endregion
        }
    }
}
