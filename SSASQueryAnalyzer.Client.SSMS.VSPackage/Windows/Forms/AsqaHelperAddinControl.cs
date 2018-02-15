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

namespace SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms
{
    using Infrastructure;
    using SSASQueryAnalyzer.Client.Common;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;
    using SSASQueryAnalyzer.Client.Common.Properties;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class AsqaHelperAddinControl : UserControl
    {
        private const int MAXIMUM_CUSTOM_COLORS = 32;

        private int[] _customColors = new int[MAXIMUM_CUSTOM_COLORS];
        private int _customColorsCount = 0;
        private int _colorValue = 0;

        private string _globalColorsSelectedProperty;
        private string _timelineColorsSelectedProperty;

        public AsqaHelperAddinControl()
        {
            InitializeComponent();

            #region FlatButtons

            buttonDownloadUpdate.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonDownloadUpdate.FlatAppearance.MouseOverBackColor = Color.White;
            buttonDownloadUpdate.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonDownloadUpdate.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonDownloadUpdate.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonDownloadUpdate.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonCheckForUpdates.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonCheckForUpdates.FlatAppearance.MouseOverBackColor = Color.White;
            buttonCheckForUpdates.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonCheckForUpdates.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonCheckForUpdates.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonCheckForUpdates.MouseLeave += Extension.OnFlatButton_MouseLeave;   
            
            #endregion
            
            RefreshVersionSync();

            comboBoxGlobalProperties.SelectedIndex = 0;
            comboBoxTimelineProperties.SelectedIndex = 0;
            _globalColorsSelectedProperty = comboBoxGlobalProperties.Text;
            _timelineColorsSelectedProperty = comboBoxTimelineProperties.Text;

            RefreshColorButtons();
            InitializeTimelineObjects();
            RefreshTimelineObjectCounterThresholdsControls();
            RefreshMaxRowsReturnedControls();
            RefreshDebugControls();
            RefreshExecutionProgressActivitiesControls();

            LoadCustomColors();
        }

        #region Version

        private void RefreshVersionSyncControls()
        {
            labelASQAAddinVersion.Text = "<version>";
            labelASQAAddinVersion.Visible = true;
            pictureASQAAddinStatus.Visible = false;
            labelASQAAddinStatus.Visible = false;
            checkBoxAutomaticallyCheckNewVersion.Checked = Settings.Default.AddInAutomaticallyCheckNewVersion;
            buttonCheckForUpdates.Visible = !checkBoxAutomaticallyCheckNewVersion.Checked;
            buttonDownloadUpdate.Visible = false;
            labelASQAAddinVersion.Text = "Currently installed ASQA Addin version is {0}".FormatWith(SSASQueryAnalyzerClient.ClientVersion.ToString());
        }

        private async void RefreshVersionSyncStatus()
        {
            if (!VersionChecker.IsNewVersionAvailable.HasValue && !VersionChecker.FailedWithException)
                await Task.Delay(TimeSpan.FromSeconds(1));

            if (VersionChecker.IsNewVersionAvailable.HasValue)
            {
                if (VersionChecker.IsNewVersionAvailable.Value)
                {
                    pictureASQAAddinStatus.Image = SystemIcons.Warning.ToBitmap();
                    labelASQAAddinStatus.Text = "New version available!";
                    buttonDownloadUpdate.Visible = true;
                    buttonCheckForUpdates.Visible = false;
                }
                else
                {
                    pictureASQAAddinStatus.Image = Properties.Resources.WindowsOK_32x32;
                    labelASQAAddinStatus.Text = "Current version is up to date!";
                }
            }
            else
            {
                labelASQAAddinVersion.Text = "Unable to retrieve version!";
                pictureASQAAddinStatus.Image = SystemIcons.Error.ToBitmap();
                pictureASQAAddinStatus.Visible = true;
            }

            pictureASQAAddinStatus.Visible = true;
            labelASQAAddinStatus.Visible = true;
        }

        private void RefreshVersionSync()
        {
            RefreshVersionSyncControls();

            if (checkBoxAutomaticallyCheckNewVersion.Checked)
                RefreshVersionSyncStatus();
        }

        private void RefreshAutomaticallyCheckNewVersionValue()
        {
            Settings.Default.AddInAutomaticallyCheckNewVersion = checkBoxAutomaticallyCheckNewVersion.Checked;
        }

        private void RefreshAutomaticallyCheckNewVersionControls()
        {
            checkBoxAutomaticallyCheckNewVersion.Checked = Settings.Default.AddInAutomaticallyCheckNewVersion;
        }

        #endregion

        #region Configuration

        public void SaveConfiguration()
        {
            Settings.Default.Save();
        }

        public void RestoreDefaultConfiguration()
        {
            object resultPresenterConfiguration = new ResultPresenterConfiguration();

            foreach (var field in resultPresenterConfiguration.GetType().GetFields())
            {
                string defaultPropertyName = field.Name.Replace("Default", string.Empty);

                foreach (SettingsProperty property in Settings.Default.Properties)
                {
                    if (property.Name == defaultPropertyName)
                    {
                        Settings.Default[property.Name] = field.GetValue(resultPresenterConfiguration);
                        break;
                    }
                }
            }

            foreach (TreeNode node in treeViewTimelineObjects.Nodes)
                SetTimelineObjectsPropertyValue(GetAssociatedTimelineObjectsProperty(node.Name), node.Checked = false);

            Settings.Default.Save();

            RefreshAutomaticallyCheckNewVersionControls();
            RefreshColorButtons();
            RefreshTimelineObjectCounterThresholdsControls();
            RefreshMaxRowsReturnedControls();
            RefreshDebugControls();
            RefreshExecutionProgressActivitiesControls();
        }

        #endregion

        #region Execution Progress Activities

        private void RefreshExecutionProgressActivitiesValue()
        {
            Settings.Default.ExecutionProgressActivitiesEnabled = checkBoxProgressPanelActivities.Checked;
            RefreshExecutionProgressActivitiesControls();
        }

        private void RefreshExecutionProgressActivitiesControls()
        {
            checkBoxProgressPanelActivities.Checked = Settings.Default.ExecutionProgressActivitiesEnabled;
        }

        #endregion

        #region Debug

        private void RefreshDebugValue()
        {
            Settings.Default.DebugEnabled = checkBoxDebugEnabled.Checked;
        }

        private void RefreshDebugControls()
        {
            checkBoxDebugEnabled.Checked = Settings.Default.DebugEnabled;
        }

        #endregion

        #region Properties Colors

        private string CurrentColorsSelectedProperty
        {
            get
            {
                if (tabControlASQAAddinColors.SelectedTab == tabPageASQAAddinSettingsGlobal)
                    return _globalColorsSelectedProperty;
                else if (tabControlASQAAddinColors.SelectedTab == tabPageASQAAddinSettingsExecutionTimeline)
                    return _timelineColorsSelectedProperty;
                else
                    return "None";
            }
            set
            {
                if (tabControlASQAAddinColors.SelectedTab == tabPageASQAAddinSettingsGlobal)
                    _globalColorsSelectedProperty = value;
                else if (tabControlASQAAddinColors.SelectedTab == tabPageASQAAddinSettingsExecutionTimeline)
                    _timelineColorsSelectedProperty = value;
            }
        }

        private Button CurrentColorButton
        {
            get
            {
                if (tabControlASQAAddinColors.SelectedTab == tabPageASQAAddinSettingsGlobal)
                    return buttonGlobalColor;
                else if (tabControlASQAAddinColors.SelectedTab == tabPageASQAAddinSettingsExecutionTimeline)
                    return buttonTimelineColor;

                throw new ApplicationException("Invalid type for get CurrentSelectedProperty");
            }
        }

        private string GetAssociatedColorsProperty()
        {
            string associatedProperty = "";

            switch (CurrentColorsSelectedProperty)
            {
                #region Global Color Properties
                case "[Cold Cache Execution] - Graph bar color 1":
                    associatedProperty = "ColdCacheGraphBarColor1";
                    break;
                case "[Cold Cache Execution] - Graph bar color 2":
                    associatedProperty = "ColdCacheGraphBarColor2";
                    break;
                case "[Cold Cache Execution] - Title back color":
                    associatedProperty = "ColdCacheColor";
                    break;
                case "[Warm Cache Execution] - Graph bar color 1":
                    associatedProperty = "WarmCacheGraphBarColor1";
                    break;
                case "[Warm Cache Execution] - Graph bar color 2":
                    associatedProperty = "WarmCacheGraphBarColor2";
                    break;
                case "[Warm Cache Execution] - Title back color":
                    associatedProperty = "WarmCacheColor";
                    break;
                case "Highligth color":
                    associatedProperty = "HighlightColor";
                    break;
                #endregion

                #region Timeline Color Properties
                case "[Profiler Events] - Color":
                    associatedProperty = "ProfilerEventsColor";
                    break;
                case "[Performance Counters] - Color":
                    associatedProperty = "PerformanceCountersColor";
                    break;
                case "[Caches] - Color":
                    associatedProperty = "CachesColor";
                    break;
                case "[Aggregations] - Color":
                    associatedProperty = "AggregationsColor";
                    break;
                case "[Partitions] - Color":
                    associatedProperty = "PartitionsColor";
                    break;
                case "[Cached Dimensions] - Color":
                    associatedProperty = "CachedDimensionsColor";
                    break;
                case "[Non Cached Dimensions] - Color":
                    associatedProperty = "NonCachedDimensionsColor";
                    break;
                case "[Regular Measures] - Color":
                    associatedProperty = "RegularMeasuresColor";
                    break;
                case "[Calculated Measures] - Color":
                    associatedProperty = "CalculatedMeasuresColor";
                    break;
                case "[NonEmpty Activities] - Color":
                    associatedProperty = "NonEmptyActivitiesColor";
                    break;               
                case "[Serialization Activities] - Color":
                    associatedProperty = "SerializationActivitiesColor";
                    break;
                #endregion

                default:
                    break;
            }

            return associatedProperty;
        }

        private void RefreshColorButtons()
        {
            foreach (SettingsProperty currentProperty in Common.Properties.Settings.Default.Properties)
            {
                if (currentProperty.Name == GetAssociatedColorsProperty())
                {
                    CurrentColorButton.BackColor = (Color)Settings.Default[currentProperty.Name];
                    break;
                }
            }
        }

        private int GetColorValue(Color color)
        {
            return (color.B << 16) + (color.G << 8) + color.R;
        }

        private void LoadCustomColors()
        {
            _customColorsCount = 0;

            foreach (SettingsProperty currentProperty in Settings.Default.Properties)
            {
                if (currentProperty.PropertyType == typeof(Color))
                {
                    _colorValue = GetColorValue((Color)Settings.Default[currentProperty.Name]);

                    if(!_customColors.Contains(_colorValue))
                        _customColors[_customColorsCount++] = _colorValue;
                }
            }
        }

        #endregion

        #region Timeline Objects Threshold

        private void RefreshTimelineEventsThresholdValue()
        {
            if (radioButtonTimelineObjectsThresholdUnlimited.Checked)
                Settings.Default.TimelineEventsNumberThreshold = 0;
            else if (radioButtonTimelineEventsThresholdLimited.Checked)
                Settings.Default.TimelineEventsNumberThreshold = Convert.ToInt32(numericUpDownTimelineEventsThreshold.Value);

            RefreshTimelineObjectCounterThresholdsControls();
        }

        private void OnTreeViewTimelineObjects_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Level == 0)
                e.Node.HideCheckBox();

            e.DrawDefault = true;
        }

        private bool GetTimelineObjectsPropertyValue(string propertyName)
        {
            bool propertyValue = false;

            foreach (SettingsProperty currentProperty in Settings.Default.Properties)
            {
                if (currentProperty.Name == propertyName)
                {
                    propertyValue = (bool)Settings.Default[currentProperty.Name];
                    break;
                }
            }

            return propertyValue;
        }

        private void SetTimelineObjectsPropertyValue(string propertyName, bool value)
        {
            foreach (SettingsProperty currentProperty in Settings.Default.Properties)
            {
                if (currentProperty.Name == propertyName)
                {
                    Settings.Default[currentProperty.Name] = value;
                    break;
                }
            }
        }

        private string GetAssociatedTimelineObjectsProperty(string selectedProperty)
        {
            string associatedProperty = "";

            switch (selectedProperty)
            {
                case "Caches":
                    associatedProperty = "TimelineCachesVisible";
                    break;
                case "Aggregations":
                    associatedProperty = "TimelineAggregationsVisible";
                    break;
                case "Partitions":
                    associatedProperty = "TimelinePartitionsVisible";
                    break;
                case "Dimensions":
                    associatedProperty = "TimelineDimensionsVisible";
                    break;
                case "Measures":
                    associatedProperty = "TimelineMeasuresVisible";
                    break;
                case "NonEmpty Activities":
                    associatedProperty = "TimelineNonEmptyActivitiesVisible";
                    break;
                case "Serialization Activities":
                    associatedProperty = "TimelineSerializationActivitiesVisible";
                    break;
            }

            return associatedProperty;
        }

        private void InitializeTimelineObjects()
        {
            var timelineObjectsList = new List<string>
            {
                "Caches",
                "Aggregations",
                "Partitions",
                "Dimensions",
                "Measures",
                "NonEmpty Activities",
                "Serialization Activities"
            };

            TreeNode eventNode = null;
            foreach (string timelineObject in timelineObjectsList)
            {
                eventNode = treeViewTimelineObjects.Nodes.Add(timelineObject);
                eventNode.Name = timelineObject;
                eventNode.Checked = GetTimelineObjectsPropertyValue(GetAssociatedTimelineObjectsProperty(eventNode.Name));
            }
        }

        private void RefreshTimelineObjectCounterThresholdsControls()
        {
            radioButtonTimelineObjectsThresholdUnlimited.Checked = Settings.Default.TimelineEventsNumberThreshold == 0;
            radioButtonTimelineEventsThresholdLimited.Checked = !radioButtonTimelineObjectsThresholdUnlimited.Checked;
            numericUpDownTimelineEventsThreshold.Enabled = radioButtonTimelineEventsThresholdLimited.Checked;
            numericUpDownTimelineEventsThreshold.ForeColor = numericUpDownTimelineEventsThreshold.Enabled ? SystemColors.WindowText : SystemColors.GrayText;

            if(radioButtonTimelineEventsThresholdLimited.Checked)
                numericUpDownTimelineEventsThreshold.Value = Settings.Default.TimelineEventsNumberThreshold;
        }

        #endregion

        #region Query Results

        private void RefreshMaxRowsReturnedValue()
        {
            if (radioButtonMaxRowsReturnedNone.Checked)
                Settings.Default.MaxRowsReturned = 0;
            else if (radioButtonMaxRowsReturnedUnlimited.Checked)
                Settings.Default.MaxRowsReturned = int.MaxValue;
            else if (radioButtonMaxRowsReturnedLimited.Checked)
                Settings.Default.MaxRowsReturned = Convert.ToInt32(numericUpDownMaxRowsReturned.Value);

            RefreshMaxRowsReturnedControls();
        }

        private void RefreshMaxRowsReturnedControls()
        {
            radioButtonMaxRowsReturnedNone.Checked = Settings.Default.MaxRowsReturned == 0;
            radioButtonMaxRowsReturnedUnlimited.Checked = !radioButtonMaxRowsReturnedNone.Checked && Settings.Default.MaxRowsReturned == int.MaxValue;
            radioButtonMaxRowsReturnedLimited.Checked = !radioButtonMaxRowsReturnedNone.Checked && !radioButtonMaxRowsReturnedUnlimited.Checked;
            numericUpDownMaxRowsReturned.Enabled = radioButtonMaxRowsReturnedLimited.Checked;
            numericUpDownMaxRowsReturned.ForeColor = numericUpDownMaxRowsReturned.Enabled ? SystemColors.WindowText : SystemColors.GrayText;

            if (radioButtonMaxRowsReturnedLimited.Checked)
                numericUpDownMaxRowsReturned.Value = Settings.Default.MaxRowsReturned;
        }

        #endregion

        #region Events

        #region Tabs

        private void tabControlASQAAddinColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshColorButtons();
        }

        #endregion

        #region Version

        private void OnCheckBoxAutomaticallyCheckNewVersion_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckForUpdates.Visible = !checkBoxAutomaticallyCheckNewVersion.Checked && !buttonDownloadUpdate.Visible;

            RefreshAutomaticallyCheckNewVersionValue();
        }

        private void OnButtonCheckForUpdates_Click(object sender, EventArgs e)
        {
            var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
            helper.WaitStart();
            try
            {
                try
                {
                    VersionChecker.CheckForUpdate();
                }
                catch
                {
                    // suppress errors here
                }

                RefreshVersionSyncControls();
                RefreshVersionSyncStatus();
            }
            finally
            {
                helper.WaitStop();
            }
        }

        private void OnButtonDownloadUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ssasqueryanalyzer.github.io/");
        }
        
        #endregion

        #region Execution Progress Activities

        private void OnCheckBoxExecutionProgressActivities_CheckedChanged(object sender, EventArgs e)
        {
            RefreshExecutionProgressActivitiesValue();
        }

        #endregion

        #region Debug

        private void OnCheckBoxDebugEnabled_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDebugValue();
        }

        #endregion

        #region Properties Colors

        private void OnButtonClientColor_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog())
            {
                dialog.CustomColors = _customColors;

                if (dialog.CustomColors.Contains(GetColorValue(CurrentColorButton.BackColor)))
                {
                    for (int index = 0; index < dialog.CustomColors.Count(); index++)
                    {
                        if (dialog.CustomColors[index] == GetColorValue(CurrentColorButton.BackColor))
                        {
                            dialog.Color = CurrentColorButton.BackColor;
                            break;
                        }
                    }
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (SettingsProperty currentProperty in Common.Properties.Settings.Default.Properties)
                    {
                        if (currentProperty.Name == GetAssociatedColorsProperty())
                        {
                            Settings.Default[currentProperty.Name] = dialog.Color;
                            CurrentColorButton.BackColor = (Color)Settings.Default[currentProperty.Name];
                            break;
                        }
                    }
                }
            }
        }

        private void OnComboBoxProperties_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var senderComboBox = sender as ComboBox;
            CurrentColorsSelectedProperty = senderComboBox.Text;
            RefreshColorButtons();
        }

        #endregion

        #region Timeline others

        private void OnNumericUpDownTimelineEventsThreshold_ValueChanged(object sender, EventArgs e)
        {
            RefreshTimelineEventsThresholdValue();
        }

        private void radioButtonTimelineEventsThreshold_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTimelineEventsThresholdValue();
        }

        private void treeViewTimelineObjects_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetTimelineObjectsPropertyValue(GetAssociatedTimelineObjectsProperty(e.Node.Name), e.Node.Checked);
        }
        
        private void treeViewTimelineObjects_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                SetTimelineObjectsPropertyValue(GetAssociatedTimelineObjectsProperty(treeViewTimelineObjects.SelectedNode.Name), treeViewTimelineObjects.SelectedNode.Checked);
            }
        }

        #endregion

        #region Query Results

        private void OnNumericUpDownMaxRowsReturned_ValueChanged(object sender, EventArgs e)
        {
            RefreshMaxRowsReturnedValue();
        }

        private void radioButtonMaxRowsReturned_CheckedChanged(object sender, EventArgs e)
        {
            RefreshMaxRowsReturnedValue();
        }

        #endregion

        #endregion
    }
}
