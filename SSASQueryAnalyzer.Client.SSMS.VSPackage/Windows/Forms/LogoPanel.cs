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

namespace SSASQueryAnalyzer.Client.SSMS.VSPackage.Infrastructure
{
    using Common.Infrastructure;
    using Common.Infrastructure.Configuration;
    using Microsoft.SqlServer.Management.UI.VSIntegration.Editors;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    internal class LogoPanel: Panel
    {
        private const string LogoPanelControlName = "asqaLogoPanel";

        public enum PanelMode
        {
            Undefined,
            Live,
            Batch,
            LoadFomDB
        }

        private static Control FindParent(ScriptAndResultsEditorControl scriptEditorControl)
        {
            var analysisServerMetaDataHost = scriptEditorControl.Controls.Cast<Control>().FirstOrDefault((c) => c.Name == "AnalysisServerMetaDataHost");
            if (analysisServerMetaDataHost == null)
                return null;

            var metadataHolder = analysisServerMetaDataHost.Controls.Cast<Control>().FirstOrDefault((c) => c is Panel && c.Name == "metadataHolder");
            if (metadataHolder != null)
                return metadataHolder;

            return null;
        }

        private static LogoPanel Find(Control parent)
        {
            var logoPanel = parent.Controls.Cast<Control>().FirstOrDefault((c) => c is Panel && c.Name == LogoPanelControlName);
            if (logoPanel != null)
                return (LogoPanel)logoPanel;

            return null;
        }

        public static void Create(ScriptAndResultsEditorControl scriptEditorControl)
        {
            var metadataHolder = FindParent(scriptEditorControl);
            if (metadataHolder == null)
                return;
            
            metadataHolder.Controls.Add(new LogoPanel() { Name = LogoPanelControlName });
            metadataHolder.Parent.Width = 155;
        }

        public static void SetMode(ScriptAndResultsEditorControl scriptEditorControl, PanelMode panelMode)
        {
            var metadataHolder = FindParent(scriptEditorControl);
            if (metadataHolder == null)
                return;

            var logoPanel = Find(metadataHolder);
            if (logoPanel != null)
                logoPanel.UpdateMode(panelMode); 
        }

        public static void SetValues(ScriptAndResultsEditorControl scriptEditorControl, int columns, int rows)
        {
            var metadataHolder = FindParent(scriptEditorControl);
            if (metadataHolder == null)
                return;

            var logoPanel = Find(metadataHolder);
            if (logoPanel != null)
                logoPanel.UpdateValues(columns, rows);
        }

        private Panel _lineMiddlePanel;
        private PictureBox _pictureBox;
        private TableLayoutPanel _tableLayoutPanel;
        private Label _executionModeLabel;
        private Label _columnCounterLabel;
        private Label _rowCounterLabel;

        private LogoPanel()
        {
            Height = 75;
            Dock = DockStyle.Bottom;
            BackColor = ResultPresenterConfiguration.DefaultWindowBackColor;
            BorderStyle = BorderStyle.Fixed3D;
            Visible = true;

            #region _tableLayoutPanel

            _tableLayoutPanel = new TableLayoutPanel();
            _tableLayoutPanel.ColumnCount = 4;
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tableLayoutPanel.Dock = DockStyle.Fill;
            _tableLayoutPanel.Name = "tableLayoutPanel";
            _tableLayoutPanel.RowCount = 3;
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 4F));
            _tableLayoutPanel.Visible = true;

            #endregion

            #region _lineMiddlePanel

            _lineMiddlePanel = new Panel();
            _lineMiddlePanel.BackColor = SystemColors.WindowText;
            _lineMiddlePanel.Dock = DockStyle.Fill;
            _lineMiddlePanel.Name = "lineMiddlePanel";

            #endregion

            #region _pictureBox

            _pictureBox = new PictureBox();
            _pictureBox.BackColor = ResultPresenterConfiguration.DefaultWindowBackColor;
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom; 
            _pictureBox.Name = "pictureBox";
            _pictureBox.Dock = DockStyle.Fill;
            _pictureBox.TabStop = false;

            #endregion

            #region _executionModeLabel

            _executionModeLabel = new Label();
            _executionModeLabel.Dock = DockStyle.Fill;
            _executionModeLabel.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            _executionModeLabel.Name = "executionModeLabel";
            _executionModeLabel.Padding = new Padding(0, 3, 0, 0);
            _executionModeLabel.TextAlign = ContentAlignment.MiddleCenter;
            _executionModeLabel.UseCompatibleTextRendering = true;

            #endregion

            #region _columnCounterLabel

            _columnCounterLabel = new Label();
            _columnCounterLabel.Dock = DockStyle.Fill;
            _columnCounterLabel.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            _columnCounterLabel.Name = "columnCounterLabel";
            _columnCounterLabel.Padding = new Padding(0, 3, 0, 0);
            _columnCounterLabel.TextAlign = ContentAlignment.MiddleLeft;
            _columnCounterLabel.UseCompatibleTextRendering = true;

            #endregion

            #region _masterLabelRowsCounter

            _rowCounterLabel = new Label();
            _rowCounterLabel.Dock = DockStyle.Fill;
            _rowCounterLabel.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            _rowCounterLabel.Name = "masterLabelRowsCounter";
            _rowCounterLabel.Padding = new Padding(0, 3, 0, 0);
            _rowCounterLabel.TextAlign = ContentAlignment.MiddleRight;
            _rowCounterLabel.UseCompatibleTextRendering = true;

            #endregion

            UpdateMode(PanelMode.Undefined);
        }

        public void UpdateMode(PanelMode panelMode)
        {
            #region Remove all controls from the _tableLayoutPanel

            _tableLayoutPanel.Controls.Remove(_columnCounterLabel);
            _tableLayoutPanel.Controls.Remove(_rowCounterLabel);
            _tableLayoutPanel.Controls.Remove(_lineMiddlePanel);
            _tableLayoutPanel.Controls.Remove(_executionModeLabel);
            _tableLayoutPanel.Controls.Remove(_pictureBox);

            #endregion

            #region Set all controls inside the TableLayoutPanel

            switch (panelMode)
            {
                case PanelMode.Undefined:
                    _columnCounterLabel.Text = "";
                    _columnCounterLabel.Visible = false;
                    _rowCounterLabel.Text = "";
                    _rowCounterLabel.Visible = false;
                    _lineMiddlePanel.Visible = false;
                    _executionModeLabel.Text = "";
                    _executionModeLabel.Visible = false;
                    _pictureBox.Image = Properties.Resources.ASQA_Logo_64x64;
                    _tableLayoutPanel.Controls.Add(_pictureBox, 1, 0);
                    _tableLayoutPanel.SetColumnSpan(_pictureBox, 2);
                    _tableLayoutPanel.SetRowSpan(_pictureBox, 5);
                    _pictureBox.Visible = true;
                    break;
                case PanelMode.Live:
                    _tableLayoutPanel.Controls.Add(_columnCounterLabel, 1, 0);
                    _columnCounterLabel.Text = "";
                    _columnCounterLabel.Visible = false;
                    _tableLayoutPanel.Controls.Add(_rowCounterLabel, 2, 0);
                    _rowCounterLabel.Text = "";
                    _rowCounterLabel.Visible = false;
                    _tableLayoutPanel.Controls.Add(_lineMiddlePanel, 1, 1);
                    _tableLayoutPanel.SetColumnSpan(_lineMiddlePanel, 2);
                    _lineMiddlePanel.Visible = false;
                    _executionModeLabel.Text = "Live mode";
                    _tableLayoutPanel.Controls.Add(_executionModeLabel, 1, 2);
                    _tableLayoutPanel.SetColumnSpan(_executionModeLabel, 2);
                    _executionModeLabel.Visible = true;
                    _pictureBox.Image = Properties.Resources.LiveMode_32x32;
                    _tableLayoutPanel.Controls.Add(_pictureBox, 1, 3);
                    _tableLayoutPanel.SetColumnSpan(_pictureBox, 2);
                    _tableLayoutPanel.SetRowSpan(_pictureBox, 1);
                    _pictureBox.Visible = true;
                    break;
                case PanelMode.Batch:
                    _tableLayoutPanel.Controls.Add(_columnCounterLabel, 1, 0);
                    _columnCounterLabel.Text = "";
                    _columnCounterLabel.Visible = false;
                    _tableLayoutPanel.Controls.Add(_rowCounterLabel, 2, 0);
                    _rowCounterLabel.Text = "";
                    _rowCounterLabel.Visible = false;
                    _tableLayoutPanel.Controls.Add(_lineMiddlePanel, 1, 1);
                    _tableLayoutPanel.SetColumnSpan(_lineMiddlePanel, 2);
                    _lineMiddlePanel.Visible = false;
                    _executionModeLabel.Text = "Batch mode";
                    _tableLayoutPanel.Controls.Add(_executionModeLabel, 1, 2);
                    _tableLayoutPanel.SetColumnSpan(_executionModeLabel, 2);
                    _executionModeLabel.Visible = true;
                    _pictureBox.Image = Properties.Resources.BatchMode_32x32;
                    _tableLayoutPanel.Controls.Add(_pictureBox, 1, 3);
                    _tableLayoutPanel.SetColumnSpan(_pictureBox, 2);
                    _tableLayoutPanel.SetRowSpan(_pictureBox, 1);
                    _pictureBox.Visible = true;
                    break;
                case PanelMode.LoadFomDB:
                    _columnCounterLabel.Text = "";
                    _columnCounterLabel.Visible = false;
                    _rowCounterLabel.Text = "";
                    _rowCounterLabel.Visible = false;
                    _lineMiddlePanel.Visible = false;
                    _executionModeLabel.Text = "Loaded from DB";
                    _tableLayoutPanel.Controls.Add(_executionModeLabel, 1, 0);
                    _tableLayoutPanel.SetColumnSpan(_executionModeLabel, 2);
                    _executionModeLabel.Visible = true;
                    _pictureBox.Image = Properties.Resources.LoadFromDB_32x32;
                    _tableLayoutPanel.Controls.Add(_pictureBox, 1, 3);
                    _tableLayoutPanel.SetColumnSpan(_pictureBox, 2);
                    _tableLayoutPanel.SetRowSpan(_pictureBox, 1);
                    _pictureBox.Visible = true;
                    break;
                default:
                    _columnCounterLabel.Visible = false;
                    _rowCounterLabel.Visible = false;
                    _lineMiddlePanel.Visible = false;
                    _executionModeLabel.Text = "";
                    _executionModeLabel.Visible = false;
                    _pictureBox.Image = Properties.Resources.ASQA_Logo_32x32;
                    _tableLayoutPanel.Controls.Add(_pictureBox, 1, 0);
                    _tableLayoutPanel.SetColumnSpan(_pictureBox, 2);
                    _tableLayoutPanel.SetRowSpan(_pictureBox, 5);
                    _pictureBox.Visible = true;
                    break;
            }

            #endregion

            Controls.Add(_tableLayoutPanel);
        }

        public void UpdateValues(int columns, int rows)
        {
            var hide = columns == 0 && rows == 0;

            _columnCounterLabel.Text = "Columns: {0}".FormatWith(columns);
            _columnCounterLabel.Visible = !hide;
            _rowCounterLabel.Text = "Rows: {0}".FormatWith(rows);
            _rowCounterLabel.Visible = !hide;
            _lineMiddlePanel.Visible = !hide;
        }
    }
}
