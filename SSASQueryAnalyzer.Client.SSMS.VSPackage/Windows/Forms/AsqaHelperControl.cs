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
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using Infrastructure;

    /// <summary>
    /// 
    /// </summary>
    public partial class AsqaHelperControl : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public AsqaHelperControl()
        {
            InitializeComponent();

            #region FlatButtons
            buttonSaveConfiguration.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonSaveConfiguration.FlatAppearance.MouseOverBackColor = Color.White;
            buttonSaveConfiguration.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonSaveConfiguration.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonSaveConfiguration.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonSaveConfiguration.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonRestoreDefaultConfiguration.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonRestoreDefaultConfiguration.FlatAppearance.MouseOverBackColor = Color.White;
            buttonRestoreDefaultConfiguration.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonRestoreDefaultConfiguration.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonRestoreDefaultConfiguration.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonRestoreDefaultConfiguration.MouseLeave += Extension.OnFlatButton_MouseLeave;
            #endregion

            tabControlMain.SelectedTab = tabPageAddin;
        }

        private void UpdatePanelBottomVisibility()
        {
            panelBottom.Visible = tabControlMain.SelectedTab != tabPageAbout && tabControlMain.SelectedTab != tabPageBatchMode;
        }

        private void OnTabControlMain_Selected(object sender, TabControlEventArgs e)
        {
            UpdatePanelBottomVisibility();
        }

        public void WaitStart()
        {
            UseWaitCursor = true;
            tabControlMain.Enabled = false;
            panelBottom.Visible = false;
            panelWaiting.Visible = true;
        }

        public void WaitStop()
        {
            panelWaiting.Visible = false;
            UpdatePanelBottomVisibility();
            tabControlMain.Enabled = true;
            UseWaitCursor = false;
        }

        private async void OnButtonSaveConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                await asqaHelperLiveModeControl1.SaveConfigurationAsync();
                asqaHelperAddinControl1.SaveConfiguration();
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }

        private async void OnButtonRestoreDefaultConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                asqaHelperAddinControl1.RestoreDefaultConfiguration();
                await asqaHelperLiveModeControl1.RestoreDefaultConfigurationAsync();
            }
            catch (Exception ex)
            {
                ex.HandleException(display: true);
            }
        }
    }
}
