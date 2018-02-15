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
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Windows.Forms;
    using System.Xml;
    using System.Linq;
    using System.Diagnostics;
    using System.Drawing;

    public partial class ResultPresenterExecutionInfoControl : UserControl
    {
        private AnalyzerStatistics _analyzerStatistics;
        public AnalyzerStatistics AnalyzerStatistics
        {
            get
            {
                return _analyzerStatistics;
            }
        }

        private const string DateTimeFormatString = "dd/MM/yyyy HH:mm:ss.fff";

        private DateTime _analysisEnd;
        private DateTime _analysisBegin;
        private DateTime _renderingBegin;
        private TimeSpan _analysisDuration;
        private TreeNode _mdxScriptNode;
        private bool _liveMode;
        private bool _batchMode;
        private bool _loadBatchMode;

        public ResultPresenterExecutionInfoControl()
        {
            InitializeComponent();
        }

        #region Common

        private void AddChildNodes(TreeNodeCollection parentCollection, XmlNode xnode)
        {
            foreach (XmlNode childNode in xnode.ChildNodes)
            {
                TreeNode newNode;
                if (childNode is XmlText)
                    newNode = parentCollection.Add(childNode.Value);
                else
                {
#if !DEBUG
                    if (childNode.Name == "MeasuresExtended")
                        continue;
#endif
                    if (childNode.Name == "Command" && childNode.ParentNode.Name == "Commands")
                    {
                        LoadMdxScript(childNode);
                        continue;
                    };

                    var text = childNode.Name;
                    var attrib = childNode.Attributes["Name"] ?? childNode.Attributes["ID"];
                    if (attrib != null)
                        text += " [{0}]".FormatWith(attrib.Value);

                    newNode = parentCollection.Add(text);
                    if (newNode.Text == "MdxScript [MdxScript]")
                        _mdxScriptNode = newNode;

                    foreach (XmlAttribute attribute in childNode.Attributes)
                        newNode.Nodes.Add("{0} = {1}".FormatWith(attribute.Name, attribute.Value));
                }

                AddChildNodes(newNode.Nodes, childNode);

                if (newNode.Nodes.Count == 0)
                    newNode.EnsureVisible();
            }
        }

        private void AddProfilerEventsChildNodes(TreeNodeCollection parentCollection, XmlNode xnode)
        {
            foreach (XmlNode childNode in xnode.ChildNodes)
            {
                TreeNode categoryNode = null;

                var category = childNode.Attributes["Category"];
                if (category != null)
                {
                    foreach (TreeNode treeNode in parentCollection)
                    {
                        if (treeNode.Text == category.Value)
                        {
                            categoryNode = treeNode;
                            break;
                        }
                    }
                }

                if (categoryNode == null)
                    categoryNode = parentCollection.Add(category.Value);

                if (categoryNode != null)
                {
                    var eventName = childNode.Attributes["Name"];
                    var eventID = childNode.Attributes["id"];
                    if (eventName != null)
                    {
                        if (!categoryNode.Nodes.ContainsKey(eventName.Value))
                        {
                            var eventNode = categoryNode.Nodes.Add(eventName.Value);
                            eventNode.Name = eventName.Value;
                            eventNode.Tag = eventID;
                            eventNode.ToolTipText = "[Event ID: {0}]".FormatWith(eventID.Value);
                            eventNode.EnsureVisible();
                        }
                    }
                }
            }
        }

        private void AddPerformanceCountersChildNodes(TreeNodeCollection parentCollection, XmlNode xnode)
        {
            foreach (XmlNode childNode in xnode.ChildNodes)
            {
                TreeNode categoryNode = null;

                var category = childNode.Attributes["category"];
                if (category != null)
                {
                    foreach (TreeNode treeNode in parentCollection)
                    {
                        if (treeNode.Text == category.Value)
                        {
                            categoryNode = treeNode;
                            break;
                        }
                    }
                }

                if (categoryNode == null)
                    categoryNode = parentCollection.Add(category.Value);

                if (categoryNode != null)
                {
                    var counterName = childNode.Attributes["name"];
                    if (counterName != null)
                    {
                        if (!categoryNode.Nodes.ContainsKey(counterName.Value))
                        {
                            var counterNode = categoryNode.Nodes.Add(counterName.Value);
                            counterNode.Name = counterName.Value;
                            counterNode.EnsureVisible();
                        }
                    }
                }
            }
        }

        private void InitializeContextMenuStrips()
        {
            Debug.Assert(richTextBoxMDXScript.ContextMenuStrip == null);

            var richTextBoxMDXScriptContextMenu = new ContextMenuStrip();
            richTextBoxMDXScriptContextMenu.Items.Add(new ToolStripMenuItem("Copy", null, (s, e) => RichTextBoxMdxScriptCopy()));
            richTextBoxMDXScript.ContextMenuStrip = richTextBoxMDXScriptContextMenu;
        }

        public void UpdateStatistics(AnalyzerStatistics analyzerStatistics, bool liveMode, bool batchMode, bool loadBatchMode, DateTime renderingBegin)
        {
            InitializeContextMenuStrips();
            pictureBoxMessage.Image = SystemIcons.Information.ToBitmap();

            _analyzerStatistics = analyzerStatistics;

            _liveMode = liveMode;
            _batchMode = batchMode;
            _loadBatchMode = loadBatchMode;
            _renderingBegin = renderingBegin;

            if (_loadBatchMode)
            {
                tableLayoutExecution.RowStyles[2].Height = 0;

                _analysisEnd = _analyzerStatistics.WarmCacheExecutionResult.ExecutionEndTime;
                _analysisBegin = _analyzerStatistics.ColdCacheExecutionResult.ExecutionStartTime;
                _analysisDuration = _analysisEnd.Subtract(_analysisBegin);

                labelExecutionTypeValue.Text = "Batch Mode - Loaded from ASQA database";
                labelExecutionIDValue.Text = "[{0}]".FormatWith(_analyzerStatistics.ColdCacheExecutionResult.BatchID);
                pictureExecutionMode.Image = Properties.Resources.LoadFromDB_16x16;
                // Load ASQA SSAS Assembly details when in loadBatchMode
                LoadASQAAssemblyConfiguration();
                UpdateLabelMessage();
            }
            else
            {
                if (_analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents == null || _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents.Count == 0 ||
                    _analyzerStatistics.WarmCacheExecutionResult.ProcedureEvents == null || _analyzerStatistics.WarmCacheExecutionResult.ProcedureEvents.Count == 0)
                    return;

                _analysisEnd = DateTime.UtcNow;
                _analysisBegin = _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeBegin].Time;
                _analysisDuration = _analysisEnd.Subtract(_analysisBegin);

                if (_liveMode)
                {
                    labelExecutionTypeValue.Text = "Live Mode";
                    labelExecutionIDValue.Text = "[{0}]".FormatWith(_analyzerStatistics.ColdCacheExecutionResult.BatchID);
                    pictureExecutionMode.Image = Properties.Resources.LiveMode_16x16;
                    tabControlEnvironmentDetails.TabPages.Remove(tabPageSQLServer);
                    tabControlEnvironmentDetails.TabPages.Remove(tabPageASQASSASAssembly);
                }
                else if (_batchMode)
                {
                    labelExecutionTypeValue.Text = "Batch Mode";
                    labelExecutionIDValue.Text = "[{0}]".FormatWith(_analyzerStatistics.ColdCacheExecutionResult.BatchID);
                    pictureExecutionMode.Image = Properties.Resources.BatchMode_16x16;
                    tabControlEnvironmentDetails.TabPages.Remove(tabPageASQASSASAssembly);
                }

                // Load Activities details when not in loadBatchMode
                LoadActivity();
            }

            LoadIniFile();
            LoadCubeMetadata();
            LoadExecutionInfo();
        }

        public void LoadExecutionInfo()
        {
            #region Execution

            labelExecutionNameValue.Text = _analyzerStatistics.ColdCacheExecutionResult.BatchName ?? "N/A";
            labelExecutionBeginValue.Text = _analysisBegin.ToString(DateTimeFormatString);
            labelExecutionEndValue.Text = _analysisEnd.ToString(DateTimeFormatString);
            labelAnalysisDurationValue.Text = _analysisDuration.ToFormattedTime();

            #endregion

            #region Client

            labelClientTypeValue.Text = _analyzerStatistics.ColdCacheExecutionResult.ClientType ?? "N/A";
            labelClientVersionValue.Text = _analyzerStatistics.ColdCacheExecutionResult.ClientVersion ?? "N/A";
            labelUserNameValue.Text = _analyzerStatistics.ColdCacheExecutionResult.ConnectionUserName ?? "N/A";

            #endregion

            #region ASQA SSAS Assembly

            labelASQAAssemblyVersion_ASQATab_Value.Text = _analyzerStatistics.ColdCacheExecutionResult.ASQAServerVersion ?? "N/A";
            
            #endregion

            #region SSAS instance

            labelSSASInstanceNameValue.Text = _analyzerStatistics.ColdCacheExecutionResult.SSASInstanceName ?? "N/A";
            labelASQAAssemblyVersionValue.Text = _analyzerStatistics.ColdCacheExecutionResult.ASQAServerVersion ?? "N/A";
            labelSSASVersionValue.Text = _analyzerStatistics.ColdCacheExecutionResult.SSASInstanceVersion ?? "N/A";
            labelSSASEditionValue.Text = _analyzerStatistics.ColdCacheExecutionResult.SSASInstanceEdition ?? "N/A";
            labelSSASDatabaseValue.Text = _analyzerStatistics.ColdCacheExecutionResult.DatabaseName ?? "N/A";
            labelSSASCubeValue.Text = _analyzerStatistics.ColdCacheExecutionResult.CubeName ?? "N/A";
            labelOperatingSystemValue.Text = _analyzerStatistics.ColdCacheExecutionResult.SystemOperativeSystemName ?? "N/A";
            labelNumberOfCoresValue.Text = _analyzerStatistics.ColdCacheExecutionResult.SystemLogicalCpuCore.ToString();
            labelRAMValue.Text = string.Format("{0:n0}", _analyzerStatistics.ColdCacheExecutionResult.SystemPhysicalMemory);

            #endregion

            #region SQL Server

            labelSQLInstanceNameValue.Text = _analyzerStatistics.ColdCacheExecutionResult.SQLInstanceName ?? "N/A";
            labelSQLVersionValue.Text = _analyzerStatistics.ColdCacheExecutionResult.SQLInstanceVersion ?? "N/A";
            labelSQLEditionValue.Text = _analyzerStatistics.ColdCacheExecutionResult.SQLInstanceEdition ?? "N/A";       
            
            #endregion

            foreach (Control control in tableLayoutPanelExecutionInfo.Controls)
                control.Visible = true;

            tableLayoutPanelExecutionInfo.Visible = true;
            //panelInfo.Visible = true;
        }

        private void UpdateLabelMessage()
        {
            int parentNodeCounter = 0;
            int nodeCounter = 0;
            int allNodecounter = 0;
            string objectsType = "";

            panelMessageExternal.SuspendLayout();

            if (!radioButtonEngine.Checked)
            {
                if (radioButtonProfilerEvents.Checked)
                {
                    parentNodeCounter = treeViewProfilerEvents.Nodes.Count;
                    allNodecounter = treeViewProfilerEvents.GetNodeCount(true);
                    nodeCounter = allNodecounter - parentNodeCounter;
                    objectsType = "Profiler Events";
                }
                else if (radioButtonPerformanceCounters.Checked)
                {
                    parentNodeCounter = treeViewPerformanceCounters.Nodes.Count;
                    allNodecounter = treeViewPerformanceCounters.GetNodeCount(true);
                    nodeCounter = allNodecounter - parentNodeCounter;
                    objectsType = "Performance Counters";
                }
            }

            switch(nodeCounter)
            {
                case 0:
                    customLabelMessage.Text = "No Optional {0}!".FormatWith(objectsType);
                    break;
                default:
                    customLabelMessage.Text = "Optional {0}: {1}.".FormatWith(objectsType, nodeCounter.ToString());
                    break;
            }

            panelMessageExternal.Visible = !radioButtonEngine.Checked;
            panelMessageExternal.ResumeLayout();
        }

        #endregion

        #region Execution

        public void LoadActivity()
        {
            var dt_Pre_VerifyMDX = _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepValidateStatement].Time;
            var dt_Pre_ClearCache = _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepClearCache].Time;
            var dt_Pre_LoadCubeMDXScript = _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepLoadCubeScript].Time;
            var dt_Cold_RunTraces = _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepStartAnalyzerTask].Time;
            var dt_Cold_ExecuteMDX = _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepExecuteStatement].Time;
            var dt_Cold_CalculateMetrics = _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepCalculateResult].Time;
            var dt_PostCold_RetrieveData = _analyzerStatistics.ColdCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepSendResult].Time;
            var dt_Warm_RunTraces = _analyzerStatistics.WarmCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepStartAnalyzerTask].Time;
            var dt_Warm_ExecuteMDX = _analyzerStatistics.WarmCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepExecuteStatement].Time;
            var dt_Warm_CalculateMetrics = _analyzerStatistics.WarmCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepCalculateResult].Time;
            var dt_PostWarm_RetrieveData = _analyzerStatistics.WarmCacheExecutionResult.ProcedureEvents[ProcedureEvents.ProcedureAnalyzeStepSendResult].Time;

            var ts_Pre_EnvironmentSetup = dt_Pre_VerifyMDX.Subtract(_analysisBegin);
            var ts_Pre_VerifyMDX = dt_Pre_ClearCache.Subtract(dt_Pre_VerifyMDX);
            var ts_Pre_ClearCache = dt_Pre_LoadCubeMDXScript.Subtract(dt_Pre_ClearCache);
            var ts_Pre_LoadCubeMDXScript = dt_Cold_RunTraces.Subtract(dt_Pre_LoadCubeMDXScript);
            var ts_Cold_RunTraces = dt_Cold_ExecuteMDX.Subtract(dt_Cold_RunTraces);
            var ts_Cold_ExecuteMDX = dt_Cold_CalculateMetrics.Subtract(dt_Cold_ExecuteMDX);
            var ts_Cold_CalculateMetrics = dt_PostCold_RetrieveData.Subtract(dt_Cold_CalculateMetrics);
            var ts_PostCold_RetrieveData = dt_Warm_RunTraces.Subtract(dt_PostCold_RetrieveData);
            var ts_Warm_RunTraces = dt_Warm_ExecuteMDX.Subtract(dt_Warm_RunTraces);
            var ts_Warm_ExecuteMDX = dt_Warm_CalculateMetrics.Subtract(dt_Warm_ExecuteMDX);
            var ts_Warm_CalculateMetrics = dt_PostWarm_RetrieveData.Subtract(dt_Warm_CalculateMetrics);
            var ts_PostWarm_RetrieveData = _renderingBegin.Subtract(dt_PostWarm_RetrieveData);
            var ts_PostWarm_RenderingData = _analysisEnd.Subtract(_renderingBegin);

            // Cold activities labels
            labelResult_Pre_EnvironmentSetup.Text = ts_Pre_EnvironmentSetup.ToFormattedTime();
            labelResult_Pre_QuerySyntaxValidation.Text = ts_Pre_VerifyMDX.ToFormattedTime();
            labelResult_Pre_CacheClearing.Text = ts_Pre_ClearCache.ToFormattedTime();
            labelResult_Pre_CubeScriptLoading.Text = ts_Pre_LoadCubeMDXScript.ToFormattedTime();
            labelResult_Cold_TracesStartup.Text = ts_Cold_RunTraces.ToFormattedTime();
            labelResult_Cold_QueryExecution.Text = ts_Cold_ExecuteMDX.ToFormattedTime();
            labelResult_Cold_MetricsCalculation.Text = ts_Cold_CalculateMetrics.ToFormattedTime();
            labelResult_PostCold_DataRetrieval.Text = ts_PostCold_RetrieveData.ToFormattedTime();

            // Warm activities labels
            labelResult_Warm_TracesStartup.Text = ts_Warm_RunTraces.ToFormattedTime();
            labelResult_Warm_QueryExecution.Text = ts_Warm_ExecuteMDX.ToFormattedTime();
            labelResult_Warm_MetricsCalculation.Text = ts_Warm_CalculateMetrics.ToFormattedTime();
            labelResult_PostWarm_DataRetrieval.Text = ts_PostWarm_RetrieveData.ToFormattedTime();
            labelResult_PostWarm_DataRendering.Text = ts_PostWarm_RenderingData.ToFormattedTime();

            foreach (Control control in tableLayoutPanelActivities.Controls)
                control.Visible = true;

            tableLayoutPanelActivities.Visible = true;
        }

        #endregion

        #region SSAS instance

        public void LoadCubeMetadata()
        {
            var xdoc = new XmlDocument();
            xdoc.LoadXml(_analyzerStatistics.ColdCacheExecutionResult.CubeMetadata);

            treeViewCubeMetadata.Nodes.Clear();
            AddChildNodes(treeViewCubeMetadata.Nodes, xdoc.DocumentElement);

            if (_mdxScriptNode != null)
                treeViewCubeMetadata.Nodes.Remove(_mdxScriptNode);

            treeViewCubeMetadata.CollapseAll();
        }

        public void LoadIniFile()
        {
            var xdoc = new XmlDocument();
            xdoc.LoadXml(_analyzerStatistics.ColdCacheExecutionResult.SSASInstanceConfig);

            treeViewIniFile.Nodes.Clear();
            AddChildNodes(treeViewIniFile.Nodes, xdoc.DocumentElement);
            treeViewIniFile.CollapseAll();
        }

        private void LoadMdxScript(XmlNode mdxScriptNode)
        {
            richTextBoxMDXScript.Clear();
            foreach (XmlNode childNode in mdxScriptNode.ChildNodes)
            {
                richTextBoxMDXScript.Text += childNode.Value;
                richTextBoxMDXScript.Text += System.Environment.NewLine;
            }
        }

        private void OnRadioButtonsSSAS_Click(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;

            switch (radioButton.Name)
            {
                case "radioButtonShowIniFile":
                    panelCubeMetadata.Visible = false;
                    panelMDXScript.Visible = false;
                    radioButtonShowCubeMetadata.Checked = false;
                    radioButtonShowMDXScript.Checked = false;
                    radioButtonShowIniFile.Checked = true;
                    panelIniFile.Visible = true;
                    break;
                case "radioButtonShowCubeMetadata":
                    panelIniFile.Visible = false;
                    panelMDXScript.Visible = false;
                    radioButtonShowIniFile.Checked = false;
                    radioButtonShowMDXScript.Checked = false;
                    radioButtonShowCubeMetadata.Checked = true;
                    panelCubeMetadata.Visible = true;
                    break;
                case "radioButtonShowMDXScript":
                    panelCubeMetadata.Visible = false;
                    panelIniFile.Visible = false;
                    radioButtonShowIniFile.Checked = false;
                    radioButtonShowCubeMetadata.Checked = false;
                    radioButtonShowMDXScript.Checked = true;
                    panelMDXScript.Visible = true;
                    break;
            }
        }

        #region MDX Script RichTextBox

        private void RichTextBoxMdxScriptCopy()
        {
            if (richTextBoxMDXScript.SelectionLength > 0)
                richTextBoxMDXScript.Copy();
        }

        private void RichTextBoxMdxScriptMouseUp(object sender, MouseEventArgs e)
        {
            var richTextBox = (RichTextBox)sender;

            richTextBox.ContextMenuStrip.Visible = e.Button == MouseButtons.Right && richTextBox.SelectionLength > 0;
        }

        #endregion

        #endregion

        #region ASQA SSAS Assembly

        private void UpdateCacheModeConfig(string clearCacheMode)
        {
            switch ((ClearCacheMode)Enum.Parse(typeof(ClearCacheMode), clearCacheMode))
            {
                case ClearCacheMode.CurrentCube:
                    radioButtonClearCacheModeCurrentCube.Checked = true;
                    break;
                case ClearCacheMode.CurrentDatabase:
                    radioButtonClearCacheModeCurrentDatabase.Checked = true;
                    break;
                case ClearCacheMode.AllDatabases:
                    radioButtonClearCacheModeAllDatabases.Checked = true;
                    break;
                case ClearCacheMode.FileSystemOnly:
                    radioButtonClearCacheModeFileSystemOnly.Checked = true;
                    break;
                case ClearCacheMode.CurrentCubeAndFileSystem:
                    radioButtonClearCacheModeCurrentCubeAndFileSystem.Checked = true;
                    break;
                case ClearCacheMode.CurrentDatabaseAndFileSystem:
                    radioButtonClearCacheModeCurrentDatabaseAndFileSystem.Checked = true;
                    break;
                case ClearCacheMode.AllDatabasesAndFileSystem:
                    radioButtonClearCacheModeAllDatabasesAndFileSystem.Checked = true;
                    break;
                default:
                    throw new ApplicationException("Unknown ClearCacheMode [{0}]".FormatWith(clearCacheMode));
            }
        }

        private void UpdateTraceEventsThresholdConfig(string traceEventsThreshold)
        {
            var threshold = Convert.ToDecimal(traceEventsThreshold);
            if (threshold > ProcedureConfiguration.XConfigEngineAttributeTraceEventsThresholdUnlimited)
                numericUpDownEventsThreshold.Value = threshold;

            radioButtonEventsThresholdUnlimited.Checked = !(radioButtonEventsThresholdLimited.Checked = (threshold > ProcedureConfiguration.XConfigEngineAttributeTraceEventsThresholdUnlimited));
        }

        private void OnTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.Node.HideCheckBox();
            e.DrawDefault = true;
        }

        private void LoadASQAAssemblyConfiguration()
        {
            var xdoc = new XmlDocument();
            xdoc.LoadXml(_analyzerStatistics.ColdCacheExecutionResult.ASQAServerConfig);

            foreach (XmlNode childNode in xdoc.DocumentElement)
            {
                switch(childNode.Name)
                {
                    case "engine":
                        foreach (XmlAttribute attribute in childNode.Attributes)
                        {
                            switch (attribute.Name)
                            {
                                case "clearCacheMode":
                                    UpdateCacheModeConfig(attribute.Value);
                                    break;
                                case "traceEventsThreshold":
                                    UpdateTraceEventsThresholdConfig(attribute.Value);
                                    break;
                            }
                        }
                        break;
                    case "trace":
                        treeViewProfilerEvents.Nodes.Clear();
                        AddProfilerEventsChildNodes(treeViewProfilerEvents.Nodes, childNode);
                        treeViewProfilerEvents.CollapseAll();
                        break;
                    case "performance":
                        treeViewPerformanceCounters.Nodes.Clear();
                        AddPerformanceCountersChildNodes(treeViewPerformanceCounters.Nodes, childNode);
                        treeViewPerformanceCounters.CollapseAll();
                        break;
                }          
            }
        }

        private void OnRadioButtonsASQAAssembly_Click(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;

            switch (radioButton.Name)
            {
                case "radioButtonEngine":
                    panelOptionalProfilerEvents.Visible = false;
                    panelOptionalPerformanceCounters.Visible = false;
                    radioButtonProfilerEvents.Checked = false;
                    radioButtonPerformanceCounters.Checked = false;

                    radioButtonEngine.Checked = true;
                    panelEngineSettings.Visible = true;
                    break;
                case "radioButtonProfilerEvents":
                    panelEngineSettings.Visible = false;
                    panelOptionalPerformanceCounters.Visible = false;
                    radioButtonEngine.Checked = false;
                    radioButtonPerformanceCounters.Checked = false;

                    radioButtonProfilerEvents.Checked = true;
                    panelOptionalProfilerEvents.Visible = true;
                    break;
                case "radioButtonPerformanceCounters":
                    panelEngineSettings.Visible = false;
                    panelOptionalProfilerEvents.Visible = false;
                    radioButtonEngine.Checked = false;
                    radioButtonProfilerEvents.Checked = false;

                    radioButtonPerformanceCounters.Checked = true;
                    panelOptionalPerformanceCounters.Visible = true;
                    break;
            }

            UpdateLabelMessage();
        }

        #endregion
    }
}
