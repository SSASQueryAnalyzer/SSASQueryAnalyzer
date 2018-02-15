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
    using Microsoft.SqlServer.Management.Common;
    using SSASQueryAnalyzer.Client.Common;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.SSMS.VSPackage.Infrastructure;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;

    public partial class AsqaHelperLiveModeControl : UserControl
    {
        private const string DatabaseInstallResourceName = "SSASQueryAnalyzer.Client.SSMSAddIn.Resources.SSASQueryAnalyzerDatabaseInstall.sql";
        private const string DatabaseUninstallResourceName = "SSASQueryAnalyzer.Client.SSMSAddIn.Resources.SSASQueryAnalyzerDatabaseUninstall.sql";
        private const string BatchDatabaseExtendedPropertyVersion = "ASQA_DatabaseVersion";
        private const string BatchDatabaseName = "ASQA";

        private bool _ssasInstanceConnected;
        private bool _assemblyInstalled;
        private Version _assemblyVersion;
        
        public AsqaHelperLiveModeControl()
        {
            InitializeComponent();

            #region FlatButtons

            // buttons will be in the same location but only one at a time will be visible!
            buttonASQAAssemblyInstall.Left = buttonASQAAssemblyUninstall.Left; 
            
            buttonASQAAssemblyUninstall.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonASQAAssemblyUninstall.FlatAppearance.MouseOverBackColor = Color.White;
            buttonASQAAssemblyUninstall.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonASQAAssemblyUninstall.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonASQAAssemblyUninstall.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonASQAAssemblyUninstall.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonASQAAssemblyInstall.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonASQAAssemblyInstall.FlatAppearance.MouseOverBackColor = Color.White;
            buttonASQAAssemblyInstall.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonASQAAssemblyInstall.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonASQAAssemblyInstall.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonASQAAssemblyInstall.MouseLeave += Extension.OnFlatButton_MouseLeave;

            #endregion

            SetASQAAssemblyControlsDisabled();
        }

        private void SetASQAAssemblyControlsDisabled()
        {
            _ssasInstanceConnected = false;
            _assemblyInstalled = false;
            _assemblyVersion = null;

            buttonASQAAssemblyInstall.Enabled = false;
            buttonASQAAssemblyInstall.Visible = false;
            buttonASQAAssemblyUninstall.Enabled = false;
            buttonASQAAssemblyUninstall.Visible = false;
            labelASQAAssemblyVersion.Visible = false;
            labelASQAAssemblyVersion.Text = string.Empty;
            panelASQAAssemblySettings.Visible = false;
        }
        
        private string GetCurrentSSASInstanceConnectionString()
        {
            if (comboBoxSSASInstances.SelectedItem == null)
                return null;

            var connectionInfo = comboBoxSSASInstances.SelectedItem as OlapConnectionInfo;
            if (connectionInfo == null)
                return null;

            return connectionInfo.ConnectionString;
        }

        private void EnableASQAAssemblyControls()
        {
            if (_ssasInstanceConnected)
            {
                labelASQAAssemblyVersion.Visible = true;

                labelASQAAssemblyVersion.Text = "Not installed";
                if (_assemblyInstalled)
                    labelASQAAssemblyVersion.Text = "Currently installed ASQA SSAS Assembly version is {0}".FormatWith(_assemblyVersion);
            }

            #region SSASInstance panel

            buttonASQAAssemblyInstall.Enabled = _ssasInstanceConnected && !_assemblyInstalled;
            buttonASQAAssemblyInstall.Visible = _ssasInstanceConnected && !_assemblyInstalled;
            buttonASQAAssemblyUninstall.Enabled = _ssasInstanceConnected && _assemblyInstalled;
            buttonASQAAssemblyUninstall.Visible = _ssasInstanceConnected && _assemblyInstalled;

            #endregion

            #region ASQAAssemblyConfig panel
            
            panelASQAAssemblySettings.Visible = _ssasInstanceConnected && _assemblyInstalled;

            foreach (Control control in tabPageEngine.Controls)
                control.Enabled = panelASQAAssemblySettings.Visible;

            if (!panelASQAAssemblySettings.Visible)
            {
                treeViewProfilerEvents.Nodes.Clear();
                treeViewPerformanceCounters.Nodes.Clear();
            }

            #endregion
        }

        public async Task SaveConfigurationAsync()
        {
            if (_ssasInstanceConnected && _assemblyInstalled)
            {
                var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
                helper.WaitStart();
                try
                {
                    var optionalEvents = treeViewProfilerEvents.Nodes.Cast<TreeNode>()
                         .SelectMany((n) => n.Nodes.Cast<TreeNode>())
                         .Where((n) => n.Checked)
                         .Select((n) => new
                         {
                             Id = Convert.ToInt32(n.Tag)
                         });

                    var optionalCounters = treeViewPerformanceCounters.Nodes.Cast<TreeNode>()
                        .SelectMany((n) => n.Nodes.Cast<TreeNode>())
                        .Where((n) => n.Checked)
                        .Select((n) => new
                        {
                            Category = Convert.ToString(n.Tag),
                            Name = n.Name
                        });

                    string xconfig = new XDocument(
                        new XElement(ProcedureConfiguration.XConfigRoot,
                            new XElement(ProcedureConfiguration.XConfigEngineItem,
                                new XAttribute(ProcedureConfiguration.XConfigEngineAttributeTraceEventsThreshold, radioButtonEventsThresholdLimited.Checked ? numericUpDownEventsThreshold.Value : ProcedureConfiguration.XConfigEngineAttributeTraceEventsThresholdUnlimited),
                                new XAttribute(ProcedureConfiguration.XConfigEngineAttributeClearCacheMode,
                                                radioButtonClearCacheMode_CurrentCube.Checked ? ClearCacheMode.CurrentCube :
                                                radioButtonClearCacheMode_CurrentDatabase.Checked ? ClearCacheMode.CurrentDatabase :
                                                radioButtonClearCacheMode_AllDatabases.Checked ? ClearCacheMode.AllDatabases :
                                                radioButtonClearCacheModeFileSystemOnly.Checked ? ClearCacheMode.FileSystemOnly :
                                                radioButtonClearCacheMode_CurrentCubeAndFileSystem.Checked ? ClearCacheMode.CurrentCubeAndFileSystem :
                                                radioButtonClearCacheMode_CurrentDatabaseAndFileSystem.Checked ? ClearCacheMode.CurrentDatabaseAndFileSystem :
                                                radioButtonClearCacheMode_AllDatabasesAndFileSystem.Checked ? ClearCacheMode.AllDatabasesAndFileSystem : 
                                                ProcedureConfiguration.XConfigEngineAttributeClearCacheModeDefault)
                            ),
                            new XElement(ProcedureConfiguration.XConfigTraceCollection,
                                optionalEvents.Select((x) =>
                                    new XElement(ProcedureConfiguration.XConfigTraceItem,
                                        new XAttribute(ProcedureConfiguration.XConfigTraceAttributeId, x.Id)))
                            ),
                            new XElement(ProcedureConfiguration.XConfigPerformanceCollection,
                                optionalCounters.Select((x) =>
                                    new XElement(ProcedureConfiguration.XConfigPerformanceItem,
                                        new XAttribute(ProcedureConfiguration.XConfigPerformanceAttributeCategory, x.Category),
                                        new XAttribute(ProcedureConfiguration.XConfigPerformanceAttributeName, x.Name)
                                    ))
                                )
                            )
                        ).ToString(SaveOptions.DisableFormatting);

                    using (var client = new SSASQueryAnalyzerClient(GetCurrentSSASInstanceConnectionString()))
                        await client.ReconfigureAsync(xconfig);
                }
                finally
                {
                    helper.WaitStop();
                }
            }
        }

        public async Task RestoreDefaultConfigurationAsync()
        {
            if (_ssasInstanceConnected && _assemblyInstalled)
            {
                var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
                helper.WaitStart();
                try
                {
                    var xconfig = new XDocument(new XElement(ProcedureConfiguration.XConfigRoot))
                        .ToString(SaveOptions.DisableFormatting);

                    using (var client = new SSASQueryAnalyzerClient(GetCurrentSSASInstanceConnectionString()))
                    {
                        await client.ReconfigureAsync(xconfig);

                        LoadEngineConfiguration(await client.GetConfigurationForEngineAsync());
                        LoadTraceEventsConfiguration(await client.GetConfigurationForTraceEventsAsync());
                        LoadPerformanceCountersConfiguration(await client.GetConfigurationForPerformanceCountersAsync());
                    }
                }
                finally
                {
                    helper.WaitStop();
                }
            }
        }

        #region Events
        
        private void OnComboBoxSSASInstances_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboBoxSSASInstances.Items.Clear();
                comboBoxSSASInstances.DisplayMember = "ServerName";
                comboBoxSSASInstances.Items.AddRange(ObjectExplorerManager.GetOlapServerConnections());
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }

        private void OnComboBoxSSASInstances_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxSSASInstances.SelectedItem == null)
                SetASQAAssemblyControlsDisabled();
        }

        private async void OnComboBoxSSASInstances_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
                helper.WaitStart();
                try
                {
                    SetASQAAssemblyControlsDisabled();

                    using (var client = new SSASQueryAnalyzerClient(GetCurrentSSASInstanceConnectionString()))
                    {
                        _assemblyVersion = await client.GetVersionAsync();

                        _ssasInstanceConnected = true;
                        _assemblyInstalled = _assemblyVersion != null;

                        if (_assemblyInstalled)
                        {
                            LoadEngineConfiguration(await client.GetConfigurationForEngineAsync());
                            LoadTraceEventsConfiguration(await client.GetConfigurationForTraceEventsAsync());
                            LoadPerformanceCountersConfiguration(await client.GetConfigurationForPerformanceCountersAsync());
                        }
                    }

                    EnableASQAAssemblyControls();
                }
                finally
                {
                    helper.WaitStop();
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }

        private async void OnButtonAssemblyUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
                helper.WaitStart();
                try
                {
                    SetASQAAssemblyControlsDisabled();

                    using (var client = new SSASQueryAnalyzerClient(GetCurrentSSASInstanceConnectionString()))
                        await client.UninstallAsync();

                    _ssasInstanceConnected = true;
                    _assemblyInstalled = false;

                    EnableASQAAssemblyControls();
                }
                finally
                {
                    helper.WaitStop();
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }

        private async void OnButtonAssemblyInstall_Click(object sender, EventArgs e)
        {
            try
            {
                var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
                helper.WaitStart();
                try
                {
                    SetASQAAssemblyControlsDisabled();

                    using (var client = new SSASQueryAnalyzerClient(GetCurrentSSASInstanceConnectionString()))
                    {
                        await client.InstallAsync();

                        _assemblyVersion = await client.GetVersionAsync();
                        _ssasInstanceConnected = true;
                        _assemblyInstalled = _assemblyVersion != null;

                        LoadEngineConfiguration(await client.GetConfigurationForEngineAsync());
                        LoadTraceEventsConfiguration(await client.GetConfigurationForTraceEventsAsync());
                        LoadPerformanceCountersConfiguration(await client.GetConfigurationForPerformanceCountersAsync());
                    }

                    EnableASQAAssemblyControls();
                }
                finally
                {
                    helper.WaitStop();
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }
                
        private void OnRadioButtonEventsThreshold_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonEventsThresholdLimited.Checked = !radioButtonEventsThresholdUnlimited.Checked;

            numericUpDownEventsThreshold.Enabled = radioButtonEventsThresholdLimited.Checked;
            numericUpDownEventsThreshold.ForeColor = numericUpDownEventsThreshold.Enabled ? SystemColors.WindowText : SystemColors.GrayText;
        }

        private void OnRadioButtonClearCacheMode_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton senderButton && senderButton.Checked)
            {
                if (senderButton == radioButtonClearCacheModeFileSystemOnly)
                {
                    radioButtonClearCacheMode_AllDatabasesAndFileSystem.Checked = false;
                    radioButtonClearCacheMode_CurrentDatabaseAndFileSystem.Checked = false;
                    radioButtonClearCacheMode_CurrentCubeAndFileSystem.Checked = false;
                    radioButtonClearCacheMode_AllDatabases.Checked = false;
                    radioButtonClearCacheMode_CurrentDatabase.Checked = false;
                    radioButtonClearCacheMode_CurrentCube.Checked = false;
                }
                else if (senderButton == radioButtonClearCacheMode_AllDatabasesAndFileSystem || senderButton == radioButtonClearCacheMode_CurrentDatabaseAndFileSystem || senderButton == radioButtonClearCacheMode_CurrentCubeAndFileSystem)
                {
                    radioButtonClearCacheModeFileSystemOnly.Checked = false;
                    radioButtonClearCacheMode_AllDatabases.Checked = false;
                    radioButtonClearCacheMode_CurrentDatabase.Checked = false;
                    radioButtonClearCacheMode_CurrentCube.Checked = false;
                }
                else if (senderButton == radioButtonClearCacheMode_AllDatabases || senderButton == radioButtonClearCacheMode_CurrentDatabase || senderButton == radioButtonClearCacheMode_CurrentCube)
                {
                    radioButtonClearCacheModeFileSystemOnly.Checked = false;
                    radioButtonClearCacheMode_AllDatabasesAndFileSystem.Checked = false;
                    radioButtonClearCacheMode_CurrentDatabaseAndFileSystem.Checked = false;
                    radioButtonClearCacheMode_CurrentCubeAndFileSystem.Checked = false;
                }
            }
        }
                
        private void OnTreeViewProfilerEvents_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Level == 0)
                e.Node.HideCheckBox();

            e.DrawDefault = true;
        }
        
        private void OnTreeViewPerformanceCounters_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Level == 0)
                e.Node.HideCheckBox();

            e.DrawDefault = true;
        }

        private void OnTreeView_MandatoryKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                var treeView = (TreeView)sender;
                if (treeView.SelectedNode != null && treeView.SelectedNode.ForeColor == SystemColors.GrayText)
                    e.SuppressKeyPress = true;
            }
        }

        #endregion

        private void LoadEngineConfiguration(DataTable configuration)
        {
            foreach (DataRow row in configuration.Rows)
            {
                string propertyName = Convert.ToString(row["PropertyName"]);
                string propertyValue = Convert.ToString(row["PopertyValue"]);

                if (propertyName == ProcedureConfiguration.XConfigEngineAttributeTraceEventsThreshold)
                {
                    var threshold = Convert.ToDecimal(propertyValue);
                    if (threshold > ProcedureConfiguration.XConfigEngineAttributeTraceEventsThresholdUnlimited)
                        numericUpDownEventsThreshold.Value = threshold;

                    radioButtonEventsThresholdUnlimited.Checked = !(radioButtonEventsThresholdLimited.Checked = (threshold > ProcedureConfiguration.XConfigEngineAttributeTraceEventsThresholdUnlimited));
                }
                else if (propertyName == ProcedureConfiguration.XConfigEngineAttributeClearCacheMode)
                {
                    var clearCacheMode = (ClearCacheMode)Enum.Parse(typeof(ClearCacheMode), propertyValue);
                    switch (clearCacheMode)
                    {
                        case ClearCacheMode.CurrentCube:
                            radioButtonClearCacheMode_CurrentCube.Checked = true;
                            break;
                        case ClearCacheMode.CurrentDatabase:
                            radioButtonClearCacheMode_CurrentDatabase.Checked = true;
                            break;
                        case ClearCacheMode.AllDatabases:
                            radioButtonClearCacheMode_AllDatabases.Checked = true;
                            break;
                        case ClearCacheMode.FileSystemOnly:
                            radioButtonClearCacheModeFileSystemOnly.Checked = true;
                            break;
                        case ClearCacheMode.CurrentCubeAndFileSystem:
                            radioButtonClearCacheMode_CurrentCubeAndFileSystem.Checked = true;
                            break;
                        case ClearCacheMode.CurrentDatabaseAndFileSystem:
                            radioButtonClearCacheMode_CurrentDatabaseAndFileSystem.Checked = true;
                            break;
                        case ClearCacheMode.AllDatabasesAndFileSystem:
                            radioButtonClearCacheMode_AllDatabasesAndFileSystem.Checked = true;
                            break;
                        default:
                            throw new ApplicationException("Unknown ClearCacheMode [{0}]".FormatWith(clearCacheMode));
                    }
                }
            }
        }

        private void LoadPerformanceCountersConfiguration(DataTable configuration)
        {
            configuration.DefaultView.Sort = "CategoryName";
            treeViewPerformanceCounters.Nodes.Clear();

            var node = treeViewPerformanceCounters.Nodes.Add("temp");
            node.HideCheckBox();
            treeViewPerformanceCounters.Nodes.Remove(node);

            foreach (DataRow row in configuration.Rows)
            {
                string categoryName = Convert.ToString(row["CategoryName"]);
                string counterName = Convert.ToString(row["CounterName"]);
                string counterType = Convert.ToString(row["CounterType"]);
                bool isDefault = Convert.ToBoolean(row["IsDefault"]);
                bool isActive = Convert.ToBoolean(row["IsActive"]);

                TreeNode categoryNode = null;

                // Set category node
                if (treeViewPerformanceCounters.Nodes.Count > 0)
                {
                    var foundNodes = treeViewPerformanceCounters.Nodes.Find(categoryName, searchAllChildren: false);
                    switch (foundNodes.Count())
                    {
                        case 0:
                            categoryNode = treeViewPerformanceCounters.Nodes.Add(categoryName);
                            categoryNode.Name = categoryName;
                            categoryNode.ToolTipText = categoryName;
                            break;
                        case 1:
                            categoryNode = foundNodes[0];
                            break;
                    }
                }
                else
                {
                    categoryNode = treeViewPerformanceCounters.Nodes.Add(categoryName);
                    categoryNode.Name = categoryName;
                    categoryNode.ToolTipText = categoryName;
                }

                if (categoryNode == null)
                    return;

                // Set counter node
                if (!categoryNode.Nodes.ContainsKey(counterName))
                {
                    var counterNode = categoryNode.Nodes.Add(counterName);
                    counterNode.Name = counterName;
                    counterNode.Tag = categoryNode.Name;
                    counterNode.ToolTipText = counterType;
                    counterNode.Checked = isActive;

                    if (isDefault)
                    {
                        counterNode.ForeColor = SystemColors.GrayText;
                        counterNode.Checked = false;
                        counterNode.HideCheckBox();
                    }
                }
            }
        }

        private void LoadTraceEventsConfiguration(DataTable configuration)
        {
            configuration.DefaultView.Sort = "CategoryName";
            treeViewProfilerEvents.Nodes.Clear();

            var node = treeViewProfilerEvents.Nodes.Add("temp");
            node.HideCheckBox();
            treeViewProfilerEvents.Nodes.Remove(node);

            foreach (DataRow row in configuration.Rows)
            {
                string categoryName = Convert.ToString(row["CategoryName"]);
                string categoryDescription = Convert.ToString(row["CategoryDescription"]);
                string eventName = Convert.ToString(row["EventName"]);
                string eventDescription = Convert.ToString(row["EventDescription"]);
                string eventID = Convert.ToString(row["EventID"]);
                bool isDefault = Convert.ToBoolean(row["IsDefault"]);
                bool isActive = Convert.ToBoolean(row["IsActive"]);

                TreeNode categoryNode = null;

                // Set category node
                if (treeViewProfilerEvents.Nodes.Count > 0)
                {
                    var foundNodes = treeViewProfilerEvents.Nodes.Find(categoryName, searchAllChildren: false);
                    switch (foundNodes.Count())
                    {
                        case 0:
                            categoryNode = treeViewProfilerEvents.Nodes.Add(categoryName);
                            categoryNode.Name = categoryName;
                            categoryNode.ToolTipText = categoryDescription;
                            break;
                        case 1:
                            categoryNode = foundNodes[0];
                            break;
                    }
                }
                else
                {
                    categoryNode = treeViewProfilerEvents.Nodes.Add(categoryName);
                    categoryNode.Name = categoryName;
                    categoryNode.ToolTipText = categoryDescription;
                }

                if (categoryNode == null)
                    return;

                // Set event node
                if (!categoryNode.Nodes.ContainsKey(eventName))
                {
                    var eventNode = categoryNode.Nodes.Add(eventName);
                    eventNode.Name = eventName;
                    eventNode.Tag = eventID;
                    eventNode.Checked = isActive;
                    eventNode.ToolTipText = "[Event ID: {0}] - {1}".FormatWith(eventID,eventDescription);

                    if (isDefault)
                    {
                        eventNode.ForeColor = SystemColors.GrayText;
                        eventNode.Checked = false;
                        eventNode.HideCheckBox();
                    }
                }
            }
        }
    }
}
