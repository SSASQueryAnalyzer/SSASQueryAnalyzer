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
    using Microsoft.SqlServer.Management.UI.VSIntegration.Editors;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using Infrastructure;

    public partial class AsqaHelperBatchModeControl : UserControl
    {
        private const string BatchDatabaseName = "ASQA";
        private const string BatchDatabaseExtendedPropertyVersionName = "ASQA_DatabaseVersion";
#if SSMS_VSPACKAGE
        private const string DatabaseInstallBodyResourceName = "SSASQueryAnalyzer.Client.SSMS.VSPackage.Resources.sql.SSASQueryAnalyzerDatabaseInstallBody.sql";
        private const string DatabaseInstallHeaderDatabaseEngineTypeStandaloneResourceName = "SSASQueryAnalyzer.Client.SSMS.VSPackage.Resources.sql.SSASQueryAnalyzerDatabaseInstallHeaderDatabaseEngineTypeStandalone.sql";
        private const string DatabaseInstallHeaderDatabaseEngineTypeSqlAzureDatabaseResourceName = "SSASQueryAnalyzer.Client.SSMS.VSPackage.Resources.sql.SSASQueryAnalyzerDatabaseInstallHeaderDatabaseEngineTypeSqlAzureDatabase.sql";
        private const string DatabaseUninstallBodyResourceName = "SSASQueryAnalyzer.Client.SSMS.VSPackage.Resources.sql.SSASQueryAnalyzerDatabaseUninstallBody.sql";
        private const string DatabaseUninstallHeaderDatabaseEngineTypeStandaloneResourceName = "SSASQueryAnalyzer.Client.SSMS.VSPackage.Resources.sql.SSASQueryAnalyzerDatabaseUninstallHeaderDatabaseEngineTypeStandalone.sql";
        private const string DatabaseUninstallHeaderDatabaseEngineTypeSqlAzureDatabaseResourceName = "SSASQueryAnalyzer.Client.SSMS.VSPackage.Resources.sql.SSASQueryAnalyzerDatabaseUninstallHeaderDatabaseEngineTypeSqlAzureDatabase.sql";
#else
        private const string DatabaseInstallBodyResourceName = "SSASQueryAnalyzer.Client.SSMSAddIn.Resources.SSASQueryAnalyzerDatabaseInstallBody.sql";
        private const string DatabaseInstallHeaderDatabaseEngineTypeStandaloneResourceName = "SSASQueryAnalyzer.Client.SSMSAddIn.Resources.SSASQueryAnalyzerDatabaseInstallHeaderDatabaseEngineTypeStandalone.sql";
        private const string DatabaseInstallHeaderDatabaseEngineTypeSqlAzureDatabaseResourceName = "SSASQueryAnalyzer.Client.SSMSAddIn.Resources.SSASQueryAnalyzerDatabaseInstallHeaderDatabaseEngineTypeSqlAzureDatabase.sql";
        private const string DatabaseUninstallBodyResourceName = "SSASQueryAnalyzer.Client.SSMSAddIn.Resources.SSASQueryAnalyzerDatabaseUninstallBody.sql";
        private const string DatabaseUninstallHeaderDatabaseEngineTypeStandaloneResourceName = "SSASQueryAnalyzer.Client.SSMSAddIn.Resources.SSASQueryAnalyzerDatabaseUninstallHeaderDatabaseEngineTypeStandalone.sql";
        private const string DatabaseUninstallHeaderDatabaseEngineTypeSqlAzureDatabaseResourceName = "SSASQueryAnalyzer.Client.SSMSAddIn.Resources.SSASQueryAnalyzerDatabaseUninstallHeaderDatabaseEngineTypeSqlAzureDatabase.sql";
#endif
        private const string CommandTextCheckDatabaseExist = "SELECT [name] FROM sys.databases WHERE [name] = N'{0}'";
        private const string CommandTextCheckExtendedPropertyValue = "SELECT [value] FROM sys.extended_properties WHERE [class] = 0 AND [name] = N'{0}'";

        private const string ParameterDefaultValue = "<ALL>";
        private const string ParameterDateQuery = @"EXECUTE [asqa].[sp_find_ExecutionStartTime] @batchID, @date, @user, @server, @database, @cube, @name";
        private const string ParameterUserQuery = @"EXECUTE [asqa].[sp_find_ConnectionUserName] @batchID, @date, @user, @server, @database, @cube, @name";
        private const string ParameterInstanceQuery = @"EXECUTE [asqa].[sp_find_ServerName] @batchID, @date, @user, @server, @database, @cube, @name";
        private const string ParameterDatabaseQuery = @"EXECUTE [asqa].[sp_find_DatabaseName] @batchID, @date, @user, @server, @database, @cube, @name";
        private const string ParameterCubeQuery = @"EXECUTE [asqa].[sp_find_CubeName] @batchID, @date, @user, @server, @database, @cube, @name";
        private const string ParameterBatchIDQuery = @"EXECUTE [asqa].[sp_find_BatchID] @batchID, @date, @user, @server, @database, @cube, @name";
        private const string ParameterBatchNameQuery = @"EXECUTE [asqa].[sp_find_ExecutionName] @batchID, @date, @user, @server, @database, @cube, @name";

        private bool SqlInstanceConnected;
        private bool DatabaseInstalled;
        private string DatabaseVersion;

        public AsqaHelperBatchModeControl()
        {
            InitializeComponent();

            #region FlatButtons

            // buttons will be in the same location but only one at a time will be visible!
            buttonASQADBInstall.Left = buttonASQADBUninstall.Left;

            buttonASQADBInstall.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonASQADBInstall.FlatAppearance.MouseOverBackColor = Color.White;
            buttonASQADBInstall.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonASQADBInstall.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonASQADBInstall.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonASQADBInstall.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonASQADBUninstall.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonASQADBUninstall.FlatAppearance.MouseOverBackColor = Color.White;
            buttonASQADBUninstall.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonASQADBUninstall.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonASQADBUninstall.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonASQADBUninstall.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonAnalysisSearchRefresh.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonAnalysisSearchRefresh.FlatAppearance.MouseOverBackColor = Color.White;
            buttonAnalysisSearchRefresh.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonAnalysisSearchRefresh.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonAnalysisSearchRefresh.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonAnalysisSearchRefresh.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonBackFromQuery.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonBackFromQuery.FlatAppearance.MouseOverBackColor = Color.White;
            buttonBackFromQuery.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonBackFromQuery.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonBackFromQuery.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonBackFromQuery.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonShowQuery.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonShowQuery.FlatAppearance.MouseOverBackColor = Color.White;
            buttonShowQuery.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonShowQuery.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonShowQuery.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonShowQuery.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonLoadAnalysisData.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonLoadAnalysisData.FlatAppearance.MouseOverBackColor = Color.White;
            buttonLoadAnalysisData.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonLoadAnalysisData.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonLoadAnalysisData.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonLoadAnalysisData.MouseLeave += Extension.OnFlatButton_MouseLeave;

            gridViewAnalysisData.DefaultCellStyle.SelectionBackColor = CustomColor.ASQAOrange;

            #endregion

            SetSQLInstanceControlsDisabled();
        }

        private void SetSQLInstanceControlsDisabled()
        {
            SqlInstanceConnected = false;
            DatabaseInstalled = false;

            labelASQADBVersion.Visible = false;
            labelASQADBVersion.Text = string.Empty;

            panelLoadFromDb.Visible = false;
            panelQueryText.Visible = false;

            checkBoxFilterControls.Checked = false;
            panelAnalysisSearchTitle.Visible = false;
            panelAnalysisSearchParameters.Visible = false;

            checkBoxResults.Checked = true;
            panelAnalysisSearchResult.Visible = false;
            gridViewAnalysisData.DataSource = null;

            buttonASQADBInstall.Enabled = false;
            buttonASQADBInstall.Visible = false;
            buttonASQADBUninstall.Enabled = false;
            buttonASQADBUninstall.Visible = false;
        }

        private void RefreshCurrentSQLInstance()
        {
            try
            {
                DatabaseVersion = null;
                SetSQLInstanceControlsDisabled();

                var connectionString = GetCurrentSQLInstanceConnectionString();
                if (connectionString == null)
                    return;
             
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlInstanceConnected = true;

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = CommandTextCheckDatabaseExist.FormatWith(BatchDatabaseName);
                        command.CommandType = CommandType.Text;

                        DatabaseInstalled = command.ExecuteScalar() != null;
                    }

                    if (DatabaseInstalled)
                    {
                        connection.Close();
                        connection.ConnectionString = connectionString.ToAsqaSqlConnectionString();
                        connection.Open();

                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = CommandTextCheckExtendedPropertyValue.FormatWith(BatchDatabaseExtendedPropertyVersionName);
                            command.CommandType = CommandType.Text;

                            DatabaseVersion = (string)command.ExecuteScalar();
                        }
                    }
                }
                
                DatabaseInstalled = DatabaseVersion != null;

                EnableASQADBControls();
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }

        private string GetCurrentSQLInstanceConnectionString()
        {
            var connectionInfo = comboBoxSQLInstances.SelectedItem as Tuple<string, SqlConnectionInfo, ServerConnection>;
            if (connectionInfo == null)
                return null; 

            return connectionInfo.Item2.ConnectionString;
        }

        private DatabaseEngineType GetCurrentSQLInstanceDatabaseEngineType()
        {
            var connectionInfo = comboBoxSQLInstances.SelectedItem as Tuple<string, SqlConnectionInfo, ServerConnection>;
            if (connectionInfo == null)
                return DatabaseEngineType.Unknown;

            return connectionInfo.Item3.DatabaseEngineType;
        }

        private void EnableASQADBControls()
        {
            if (SqlInstanceConnected) 
            {
                labelASQADBVersion.Visible = true;
                
                labelASQADBVersion.Text = "Not installed";
                if (DatabaseInstalled)
                    labelASQADBVersion.Text = "Currently installed ASQA database version is {0}".FormatWith(DatabaseVersion);
            }

#region SQLInstance panel

            buttonASQADBInstall.Enabled = SqlInstanceConnected && !DatabaseInstalled;
            buttonASQADBInstall.Visible = SqlInstanceConnected && !DatabaseInstalled;
            buttonASQADBUninstall.Enabled = SqlInstanceConnected && DatabaseInstalled;
            buttonASQADBUninstall.Visible = SqlInstanceConnected && DatabaseInstalled;

#endregion

#region AnalysisSearchParameters panel

            var enabled = SqlInstanceConnected && DatabaseInstalled;

            buttonAnalysisSearchRefresh.Enabled = enabled;
            buttonAnalysisSearchRefresh.Visible = enabled;
            panelLoadFromDb.Visible = enabled;
            panelAnalysisSearchParameters.Visible = enabled && !checkBoxFilterControls.Checked;
            panelAnalysisSearchTitle.Visible = panelAnalysisSearchParameters.Visible;
            panelAnalysisSearchResult.Visible = enabled && !checkBoxResults.Checked;

            foreach (var combo in new[] { comboBoxDate, comboBoxUserName, comboBoxInstance, comboBoxDatabase, comboBoxCube, comboBoxBatchID, comboBoxAnalysisName })
            {
                combo.Items.Clear();

                if (enabled)
                {
                    combo.Items.Add(ParameterDefaultValue);
                    combo.SelectedIndex = 0;
                }

                combo.Enabled = enabled;
            }

#endregion
        }

        private void RefreshParameter(ComboBox combo, string statement)
        {
            var executions = new DataTable();

            try
            {
                combo.Items.Clear();

                using (var connection = new SqlConnection(GetCurrentSQLInstanceConnectionString().ToAsqaSqlConnectionString()))
                {
                    connection.Open();

                    using (var command = new SqlCommand(statement, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar)).Value = string.IsNullOrEmpty(comboBoxDate.GetItemText(comboBoxDate.SelectedItem)) ? ParameterDefaultValue : comboBoxDate.GetItemText(comboBoxDate.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar)).Value = string.IsNullOrEmpty(comboBoxUserName.GetItemText(comboBoxUserName.SelectedItem)) ? ParameterDefaultValue : comboBoxUserName.GetItemText(comboBoxUserName.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@server", SqlDbType.VarChar)).Value = string.IsNullOrEmpty(comboBoxInstance.GetItemText(comboBoxInstance.SelectedItem)) ? ParameterDefaultValue : comboBoxInstance.GetItemText(comboBoxInstance.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@database", SqlDbType.VarChar)).Value = string.IsNullOrEmpty(comboBoxDatabase.GetItemText(comboBoxDatabase.SelectedItem)) ? ParameterDefaultValue : comboBoxDatabase.GetItemText(comboBoxDatabase.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@cube", SqlDbType.VarChar)).Value = string.IsNullOrEmpty(comboBoxCube.GetItemText(comboBoxCube.SelectedItem)) ? ParameterDefaultValue : comboBoxCube.GetItemText(comboBoxCube.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar)).Value = string.IsNullOrEmpty(comboBoxAnalysisName.GetItemText(comboBoxAnalysisName.SelectedItem)) ? ParameterDefaultValue : comboBoxAnalysisName.GetItemText(comboBoxAnalysisName.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@batchID", SqlDbType.VarChar)).Value = string.IsNullOrEmpty(comboBoxBatchID.GetItemText(comboBoxBatchID.SelectedItem)) ? ParameterDefaultValue : comboBoxBatchID.GetItemText(comboBoxBatchID.SelectedItem);

                        using (var adapter = new SqlDataAdapter(command))
                            adapter.Fill(executions);
                    }
                }

                foreach (DataRow row in executions.Rows)
                    combo.Items.Add(row[0]);

                combo.Items.Insert(0, ParameterDefaultValue);
                combo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }
        
        private void RefreshExecutions()
        {                
            var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
            helper.WaitStart();
            try
            {
                using (var connection = new SqlConnection(GetCurrentSQLInstanceConnectionString().ToAsqaSqlConnectionString()))
                {
                    connection.Open();

                    using (var command = new SqlCommand(@"EXECUTE [asqa].[sp_find_Execution] @batchID, @date, @user, @server, @database, @cube, @name", connection))
                    {
                        command.Parameters.Add(new SqlParameter("@batchID", SqlDbType.VarChar)).Value = comboBoxBatchID.GetItemText(comboBoxBatchID.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar)).Value = comboBoxDate.GetItemText(comboBoxDate.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar)).Value = comboBoxUserName.GetItemText(comboBoxUserName.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@server", SqlDbType.VarChar)).Value = comboBoxInstance.GetItemText(comboBoxInstance.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@database", SqlDbType.VarChar)).Value = comboBoxDatabase.GetItemText(comboBoxDatabase.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@cube", SqlDbType.VarChar)).Value = comboBoxCube.GetItemText(comboBoxCube.SelectedItem);
                        command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar)).Value = comboBoxAnalysisName.GetItemText(comboBoxAnalysisName.SelectedItem);

                        var table = new DataTable();

                        using (var adapter = new SqlDataAdapter(command))
                            adapter.Fill(table);

                        gridViewAnalysisData.DataSource = table;
                    }
                }

                labelAnalysisSearchRowsCount.Text = "Rows: {0} ".FormatWith(gridViewAnalysisData.Rows.Count);
                gridViewAnalysisData.Columns["Statement"].Visible = false;
                gridViewAnalysisData.Columns["BatchID"].Visible = false;

                panelAnalysisSearchResult.Visible = !checkBoxResults.Checked;
                panelQueryText.Visible = false;
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
            finally
            {
                helper.WaitStop();
            }
        }

        private void RefreshDataButtons()
        {
            bool enabled = gridViewAnalysisData.Rows.Count > 0 && gridViewAnalysisData.SelectedRows.Count == 1;

            buttonLoadAnalysisData.Enabled = enabled;
            buttonShowQuery.Enabled = enabled;
            buttonLoadAnalysisData.Visible = enabled;
            buttonShowQuery.Visible = enabled;
        }

        private void OnComboBoxSQLInstances_DropDown(object sender, EventArgs e)
        {
            try
            { 
                comboBoxSQLInstances.Items.Clear();
                comboBoxSQLInstances.DisplayMember = "Item1";
                comboBoxSQLInstances.Items.AddRange(ObjectExplorerManager.GetSqlServerConnectionsExtended());
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }

        private void OnComboBoxSQLInstances_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxSQLInstances.SelectedItem == null)
                SetSQLInstanceControlsDisabled();
        }

        private void OnComboBoxSQLInstances_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshCurrentSQLInstance();
        }
        
        private void DisableControls()
        {
            labelASQADBVersion.Visible = false;
            buttonASQADBInstall.Visible = false;
            panelLoadFromDb.Visible = false;
            panelAnalysisSearchParameters.Visible = false;
            panelAnalysisSearchTitle.Visible = false;
            panelAnalysisSearchResult.Visible = false;
            panelQueryText.Visible = false;
            checkBoxFilterControls.Checked = true;
            checkBoxResults.Checked = true;
        }

        private void OnButtonASQADBUninstall_Click(object sender, EventArgs e)
        {
            var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
            helper.WaitStart();
            try
            {
                buttonASQADBUninstall.Enabled = false;

                Func<string, string> getResource = (name) =>
                {
                    using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                    using (var reader = new StreamReader(stream))
                        return reader.ReadToEnd();
                };

                var scriptText = getResource(DatabaseUninstallHeaderDatabaseEngineTypeStandaloneResourceName);
                if (GetCurrentSQLInstanceDatabaseEngineType() == DatabaseEngineType.SqlAzureDatabase)
                    scriptText = getResource(DatabaseUninstallHeaderDatabaseEngineTypeSqlAzureDatabaseResourceName);

                scriptText += Environment.NewLine;
                scriptText += getResource(DatabaseUninstallBodyResourceName);

                DTEManager.NewBlankWindow(ScriptType.Sql, scriptText);

                comboBoxSQLInstances.SelectedItem = null;
                OnComboBoxSQLInstances_SelectionChangeCommitted(comboBoxSQLInstances, null);

                DisableControls();
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
            finally
            {
                helper.WaitStop();
            }
        }

        private void OnButtonASQADBInstall_Click(object sender, EventArgs e)
        {
            var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
            helper.WaitStart();
            try
            {
                buttonASQADBInstall.Enabled = false;

                Func<string, string> getResource = (name) =>
                {
                    using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                    using (var reader = new StreamReader(stream))
                        return reader.ReadToEnd();
                };

                var scriptText = getResource(DatabaseInstallHeaderDatabaseEngineTypeStandaloneResourceName);
                if (GetCurrentSQLInstanceDatabaseEngineType() == DatabaseEngineType.SqlAzureDatabase)
                    scriptText = getResource(DatabaseInstallHeaderDatabaseEngineTypeSqlAzureDatabaseResourceName);

                scriptText += Environment.NewLine;
                scriptText += getResource(DatabaseInstallBodyResourceName);

                DTEManager.NewBlankWindow(ScriptType.Sql, scriptText);

                comboBoxSQLInstances.SelectedItem = null;
                OnComboBoxSQLInstances_SelectionChangeCommitted(comboBoxSQLInstances, null);

                DisableControls();
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
            finally
            {
                helper.WaitStop();
            }
        }

        private void OnButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshExecutions();
        }

        private void OnComboBoxDate_DropDown(object sender, EventArgs e)
        {
            RefreshParameter((ComboBox)sender, ParameterDateQuery);
        }

        private void OnComboBoxUser_DropDown(object sender, EventArgs e)
        {
            RefreshParameter((ComboBox)sender, ParameterUserQuery);
        }

        private void OnComboBoxInstance_DropDown(object sender, EventArgs e)
        {
            RefreshParameter((ComboBox)sender, ParameterInstanceQuery);
        }

        private void OnComboBoxDatabase_DropDown(object sender, EventArgs e)
        {
            RefreshParameter((ComboBox)sender, ParameterDatabaseQuery);
        }

        private void OnComboBoxCube_DropDown(object sender, EventArgs e)
        {
            RefreshParameter((ComboBox)sender, ParameterCubeQuery);
        }

        private void OnComboBoxBatchID_DropDown(object sender, EventArgs e)
        {
            RefreshParameter((ComboBox)sender, ParameterBatchIDQuery);
        }

        private void OnComboBoxName_DropDown(object sender, EventArgs e)
        {
            RefreshParameter((ComboBox)sender, ParameterBatchNameQuery);
        }
        
        private void OnButtonShowQuery_Click(object sender, EventArgs e)
        {
            richTextBoxQuery.Clear();
            richTextBoxQuery.AppendText("************************************************************");
            richTextBoxQuery.AppendText(Environment.NewLine); 
            richTextBoxQuery.AppendText("Batch ID: " + Convert.ToString(gridViewAnalysisData.SelectedRows[0].Cells["BatchID"].Value));
            richTextBoxQuery.AppendText(Environment.NewLine);
            richTextBoxQuery.AppendText("************************************************************");
            richTextBoxQuery.AppendText(Environment.NewLine);
            richTextBoxQuery.AppendText(Environment.NewLine);
            richTextBoxQuery.AppendText(Convert.ToString(gridViewAnalysisData.SelectedRows[0].Cells["Statement"].Value));

            panelAnalysisSearchResult.Visible = false;
            panelQueryText.Visible = true;
        }

        private void OnButtonLoadAnalysisData_Click(object sender, EventArgs e)
        {
            var helper = (AsqaHelperControl)this.Parent.Parent.Parent.Parent;
            helper.WaitStart();
            try
            {
                var selectedRow = gridViewAnalysisData.SelectedRows[0];

                DTEManager.ExecuteLoadFromBatchAnalysisAsync(
                    connectionStringBatch: GetCurrentSQLInstanceConnectionString().ToAsqaSqlConnectionString(),
                    batchID: Convert.ToString(selectedRow.Cells["BatchID"].Value),
                    statement: Convert.ToString(selectedRow.Cells["Statement"].Value)
                    );
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
            finally
            {
                helper.WaitStop();
            }
        }
        
        private void OnButtonBackFromQuery_Click(object sender, EventArgs e)
        {
            panelQueryText.Visible = false;
            panelAnalysisSearchResult.Visible = true;
        }

        private void OnCheckBoxFilterControls_CheckedChanged(object sender, EventArgs e)
        {
            panelAnalysisSearchParameters.Visible = !checkBoxFilterControls.Checked;
            panelAnalysisSearchTitle.Visible = panelAnalysisSearchParameters.Visible;
        }

        private void OnCheckBoxResults_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataButtons();
            panelAnalysisSearchResult.Visible = !checkBoxResults.Checked;
        }

        private void OnGridViewAnalysisData_Click(object sender, EventArgs e)
        {
            RefreshDataButtons();
        }

        private void OnGridViewAnalysisData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gridViewAnalysisData.ClearSelection();
            RefreshDataButtons();
        }

        private void OnGridViewAnalysisData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RefreshDataButtons();
        }
    }
}
