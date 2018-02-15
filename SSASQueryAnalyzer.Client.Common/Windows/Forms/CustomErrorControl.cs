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
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Properties;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System.Threading.Tasks;
    using System.IO;
    using Microsoft.AnalysisServices.AdomdClient;
    using System.Linq;

    public partial class CustomErrorControl : UserControl
    {
        public CustomErrorControl()
        {
            InitializeComponent();

            #region FlatButtons

            buttonCopyAll.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonCopyAll.FlatAppearance.MouseOverBackColor = Color.White;
            buttonCopyAll.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonCopyAll.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonCopyAll.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonCopyAll.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonShowDetails.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonShowDetails.FlatAppearance.MouseOverBackColor = Color.White;
            buttonShowDetails.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonShowDetails.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonShowDetails.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonShowDetails.MouseLeave += Extension.OnFlatButton_MouseLeave;

            #endregion

            InitializeContextMenuStrips();
        }

        public static CustomErrorControl CreateFromException(Exception ex, bool dialogMode = false, string errorFile = null)
        {
            var control = new CustomErrorControl();
            control.richTextBoxErrorDetails.Text = ex.ToString();
            control.splitContainer1.Panel2Collapsed = true;
            control.pictureBox1.Image = SystemIcons.Error.ToBitmap();
            control.panelErrorBand.BackColor = Settings.Default.WarmCacheColor;
            control.Dock = DockStyle.Fill;
            control.tableLayoutPanelInternal.RowStyles[2].Height = 0;

            if (control.labelErrorFile.Visible = errorFile != null)
            {
                control.tableLayoutPanelInternal.RowStyles[2].Height = 20;
                control.labelErrorFile.Text = "See log for details [{0}]".FormatWith(errorFile);
            }

            if (ex is AggregateException)
            {
                ex = (ex as AggregateException).Flatten();

                if (ex.InnerException != null)
                    ex = ex.InnerException;
            }

            var friendlyMessage = TranslateToFriendlyMessage(ex);
            if (friendlyMessage.Item1 != null && friendlyMessage.Item2 != null)
            {
                control.pictureBox1.Image = SystemIcons.Information.ToBitmap();
                control.panelErrorBand.BackColor = Settings.Default.ColdCacheColor;
            }

            control.labelErrorType.Text = friendlyMessage.Item1 ?? ex.GetType().ToString();
            control.labelErrorMessage.Text = friendlyMessage.Item2 ?? ex.Message;

            using (var graphics = control.labelErrorType.CreateGraphics())
            {
                var errorTypeFont = new Font(control.labelErrorType.Font.Name, control.labelErrorType.Font.SizeInPoints, control.labelErrorType.Font.Style);
                var errorMessageFont = new Font(control.labelErrorMessage.Font.Name, control.labelErrorMessage.Font.SizeInPoints, control.labelErrorMessage.Font.Style);
                var sizeErrorType = graphics.MeasureString(control.labelErrorType.Text, errorTypeFont);
                var sizeErrorMessage = graphics.MeasureString(control.labelErrorMessage.Text, errorMessageFont);

                control.tableLayoutPanelInternal.ColumnStyles[5].Width = Math.Max(sizeErrorType.Width, sizeErrorMessage.Width) * 1.1f; // 1.1f is needed to avoid that the string is truncated 

                float panelMessageWidth = 0;
                for (int i = 0; i < control.tableLayoutPanelInternal.ColumnCount; i++)
                    panelMessageWidth += control.tableLayoutPanelInternal.ColumnStyles[i].Width;

                control.tableLayoutPanelMaster.ColumnStyles[2].Width = panelMessageWidth;
            }

            return control;
        }

        private void InitializeContextMenuStrips()
        {
            Debug.Assert(richTextBoxErrorDetails.ContextMenuStrip == null);

            var menuItem = new ToolStripMenuItem("Copy");
            menuItem.Click += (s, e) => OnRichTextMenu_Copy();
            menuItem.Enabled = true;
            menuItem.Visible = true;

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(menuItem);

            richTextBoxErrorDetails.ContextMenuStrip = contextMenu;
        }

        private void OnRichTextMenu_Copy()
        {
            if (richTextBoxErrorDetails.SelectionLength > 0)
                richTextBoxErrorDetails.Copy();
        }

        private void OnButtonShowDetails_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;

            if (splitContainer1.Panel2Collapsed)
            {
                panelMaster.BorderStyle = BorderStyle.FixedSingle;
                panelError.BorderStyle = BorderStyle.None;
                panelBottom.BorderStyle = BorderStyle.None;
                buttonShowDetails.Text = "Show details";
                buttonCopyAll.Visible = false;
            }
            else
            {
                panelMaster.BorderStyle = BorderStyle.None;
                panelError.BorderStyle = BorderStyle.FixedSingle;
                panelBottom.BorderStyle = BorderStyle.FixedSingle;
                buttonShowDetails.Text = "Hide details";
                buttonCopyAll.Visible = true;
            }
        }

        private void OnButtonCopyAll_Click(object sender, EventArgs e)
        {
            richTextBoxErrorDetails.Focus();
            richTextBoxErrorDetails.SelectAll();
            richTextBoxErrorDetails.Copy();
        }

        private static Tuple<string, string> TranslateToFriendlyMessage(Exception ex)
        {
            const int ERROR_ADOMD_GENERIC_1 = -1056309164;
            const int ERROR_ADOMD_FUNCTION_DOES_NOT_EXIST = -1056309167;
            const int ERROR_ADOMD_OPERATION_CANCELLED_BY_USER = -1055129590;
            const int ERROR_ADOMD_TABULAR_ASSEMBLY_NOT_SUPPORTED = -1056308855;

            string errorType = null;
            string errorMessage = null;
            
            var responseException = ex as AdomdErrorResponseException;
            var taskCanceledException = ex as TaskCanceledException;
            var applicationException = ex as ApplicationException;
            var fileNotFoundException = ex as FileNotFoundException;

            #region Exceptions
            
            if (responseException != null)
            {
                var responseExceptionErrors = responseException.Errors.Cast<AdomdError>();

                //Clipboard.SetText(Convert.ToString(responseException.ErrorCode));
                //MessageBox.Show("ErrorCode copied to clipboard");
                
                if (responseExceptionErrors.Any((e) => e.ErrorCode == ERROR_ADOMD_GENERIC_1 && (responseException.Message.Contains("Cube not found") || responseException.Message.Contains("cube either does not exist or has not been processed"))))
                //if (responseException.Message.Contains(commonMessage + "Cube not found") || responseException.Message.Contains("cube either does not exist or has not been processed"))
                {                    
                    errorType = "MDX cube not found!";
                    errorMessage = "Please, check if you are connected to the right database, if it contains the cube used by the MDX query and if it has been processed.";
                }
                else if (responseException.Message.Contains("ASQA database version is invalid ["))
                {
                    errorType = "Invalid ASQA database version!";
                    errorMessage = "The ASQA database founded on the SQL Server instance you are connected has a version that is not compatible with the current version of ASQA Addin.";
                }
                else if (responseException.Message.Contains("XML for Analysis parser: The XML for Analysis request timed out before it was completed"))
                {
                    errorType = "MDX query timeout!";
                    errorMessage = "Please, check the value of the [ServerTimeout] parameter on the Analysis Services instance you are connected.";
                }
                else if (responseException.ErrorCode == ERROR_ADOMD_TABULAR_ASSEMBLY_NOT_SUPPORTED || responseException.Message.Contains("Common Language Runtime assemblies are not supported when using Analysis Services in Tabular mode"))
                {
                    errorType = "Analysis Services in Tabular mode is not supported!";
                    errorMessage = "The ASQA SSAS Assembly does not support Analysis Services in Tabular mode since it does not support Common Language Runtime assemblies.";
                }
                else if (responseExceptionErrors.Any((e) => e.ErrorCode == ERROR_ADOMD_FUNCTION_DOES_NOT_EXIST))
                //else if (responseException.Message.Contains("The '[ASQA].[Analyze]' function does not exist") || responseException.Message.Contains("The '[ASQA].[GetConfiguration]' function does not exist"))
                {
                    errorType = "ASQA SSAS Assembly not found!";
                    errorMessage = "The ASQA SSAS Assembly is not installed on the Analysis Services instance you are connected." + Environment.NewLine;
                    errorMessage += "Verify to be connected to an SSAS Multidimensional instance." + Environment.NewLine;
                    errorMessage += "You could use ASQA Helper to install it or change connection.";
                }
                else if (responseExceptionErrors.Any((e) => e.ErrorCode == ERROR_ADOMD_OPERATION_CANCELLED_BY_USER))
                //else if (responseException.Message.Contains("Server: The operation was cancelled by the user"))
                {
                    errorType = "Analysis stopped!";
                    errorMessage = "The analysis was canceled by the user.";
                }
                else if (responseException.Message.Contains("Another instance of the procedure is already running"))
                {
                    errorType = "Another ASQA analysis is already running!";
                    errorMessage = "Only one ASQA analysis at a time can be executed by the ASQA engine. Please, verify if another process and/or another account is running an ASQA analysis on the same SSAS instance.";
                }
                else if (responseException.Message.Contains("Query (") && responseException.Message.Contains(") Parser"))
                {
                    errorType = "MDX is invalid!";
                    errorMessage = "Please, verify the syntax of the MDX query.";
                }
                else if (responseException.Message.Contains("The maximum number of trace events [") && responseException.Message.Contains("Please raise the value of the 'Events number threshold' parameter"))
                {
                    string errorText = "The maximum number of trace events";
                    int errorIndex = responseException.Message.IndexOf(errorText);
                    errorMessage = responseException.Message.Substring(errorIndex);
                    errorText = "Please raise the value of the 'Events number threshold' parameter or execute ASQA Batch Mode analysis.";
                    int errorIndex2 = responseException.Message.IndexOf(errorText);
                    errorType = responseException.Message.Substring(errorIndex, (errorIndex2 - errorIndex) -2) + "!";
                }
                else if (responseException.Message.Contains("NtSetSystemInformation(SYSTEMCACHEINFORMATION) error"))
                {
                    errorType = "Administrative right required!";
                    errorMessage = "Clearing the filesystem cache requires administrative rights for your account on the SSAS server." + Environment.NewLine;
                    errorMessage += "Consider running SSMS using elevated permissions or disabling this setting for the filesystem cache using the ASQA helper -> Live Mode -> Engine";
                }
            }
            else if (taskCanceledException != null)
            {
                if (taskCanceledException.Message.Contains("A task was canceled"))
                {
                    errorType = "Analysis stopped!";
                    errorMessage = "The analysis was canceled by the user";
                }
            }
            else if (applicationException != null)
            {
                if (applicationException.Message.StartsWith("Complex object validation error:"))
                {
                    errorType = "Complex object validation error!";
                    errorMessage = ex.Message.Replace("Complex object validation error:", string.Empty);
                }
            }
            else if (fileNotFoundException != null)
            {
                var message = fileNotFoundException.Message;
                if (message.Contains("SSASQueryAnalyzer.Server2012.dll") || message.Contains("SSASQueryAnalyzer.Server2014.dll") || message.Contains("SSASQueryAnalyzer.Server2016.dll"))
                {
                    errorType = "ASQA SSAS Assembly file not found!";
                    errorMessage = fileNotFoundException.Message;
                }
            }

            #endregion

            return System.Tuple.Create(errorType, errorMessage);
        }
    }
}
