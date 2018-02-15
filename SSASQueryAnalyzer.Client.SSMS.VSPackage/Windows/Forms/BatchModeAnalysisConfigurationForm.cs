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
    using Microsoft.SqlServer.Management.Common;
    using System;
    using System.Windows.Forms;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;

    public partial class BatchModeAnalysisConfigurationForm : Form
    {
        public BatchModeAnalysisConfigurationForm()
        {
            InitializeComponent();

            #region FlatButtons

            buttonOK.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonOK.FlatAppearance.MouseOverBackColor = Color.White;
            buttonOK.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonOK.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonOK.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonOK.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonCancel.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonCancel.FlatAppearance.MouseOverBackColor = Color.White;
            buttonCancel.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonCancel.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonCancel.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonCancel.MouseLeave += Extension.OnFlatButton_MouseLeave;

            #endregion
        }

        public SqlConnectionInfo SelectedConnection
        {
            get
            {
                return (SqlConnectionInfo)comboBoxConnections.SelectedItem;
            }
        }

        public string SelectedBatchName
        {
            get
            {
                return textBoxBatchName.Text;
            }
            set
            {
                textBoxBatchName.Text = value;
            }
        }

        private void ComboBoxConnections_DropDown(object sender, System.EventArgs e)
        {
            try
            {
                comboBoxConnections.Items.Clear();
                comboBoxConnections.DisplayMember = "ServerName";
                comboBoxConnections.Items.AddRange(ObjectExplorerManager.GetSqlServerConnections());
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }

        private void ComboBoxConnections_DropDownClosed(object sender, EventArgs e)
        {
            buttonOK.Enabled = (comboBoxConnections.Items.Count > 0) && (SelectedConnection != null);
        }
    }
}
