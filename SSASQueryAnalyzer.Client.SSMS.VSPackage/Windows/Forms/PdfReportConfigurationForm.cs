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
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public partial class PdfReportConfigurationForm : Form
    {
        public PdfReportConfigurationForm()
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

            InitializeForm();
        }

        private void InitializeForm()
        {
            textBoxFilePath.Text = savePdfReportDialog.FileName;
            panelPdfReportSave.Visible = false;
            checkBoxShowReport.Checked = true;
            RefreshButtons();
        }

        private void RefreshButtons()
        {
            buttonOK.Enabled = checkBoxShowReport.Checked || checkBoxSaveReport.Checked;

            if (checkBoxSaveReport.Checked)
                buttonOK.Enabled = (textBoxFilePath.Text != string.Empty) && (Directory.Exists(Path.GetDirectoryName(textBoxFilePath.Text)));
        }

        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox senderCheckBox && senderCheckBox.Checked)
            {
                if (senderCheckBox == checkBoxSaveReport)
                {
                    checkBoxShowReport.Checked = false;
                    panelPdfReportSave.Visible = true;
                }
                else if (senderCheckBox == checkBoxShowReport)
                {
                    checkBoxSaveReport.Checked = false;
                    panelPdfReportSave.Visible = false;
                }
            }

            RefreshButtons();
        }

        private void ButtonSaveDialog_Click(object sender, EventArgs e)
        {
            if (savePdfReportDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = savePdfReportDialog.FileName;
                RefreshButtons();
            }
        }
    }
}
