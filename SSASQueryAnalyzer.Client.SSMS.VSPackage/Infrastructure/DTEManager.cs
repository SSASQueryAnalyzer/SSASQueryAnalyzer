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
    using Common;
    using Common.Windows.Forms;
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.AnalysisServices.Controls.QueryExecution;
    using Microsoft.SqlServer.Management.UI.VSIntegration;
    using Microsoft.SqlServer.Management.UI.VSIntegration.Editors;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Properties;
    using SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using MDXParser;
    using SSASQueryAnalyzer.Client.Common.Reporting.Infrastructure.Pdf;

    internal static class DTEManager
    {
        #region Const

        private const string CommandNewAnalysisDefaultStatement =
@"SELECT
NON EMPTY
       { 
            
       } ON COLUMNS,
NON EMPTY
       { 
            
       } ON ROWS
FROM      
    
CELL PROPERTIES VALUE;";

        private const string SSASQueryAnalyzerAnalyzeBatch = "SSASQueryAnalyzer.Client.SSMS.VSPackage.Resources.sql.SSASQueryAnalyzerAnalyzeBatch.ps1";

        #endregion

        private static DTE2 _dte;
        private static string selectedPdfFileName;
        private static bool executeAnalysis;
        private static bool showReport;
        private static bool saveReport;

        public static Dictionary<Window, ScriptAndResultsEditorControl> AnalysisWindows
        {
            get;
            private set;
        }
                
        private static string FormattedMDXHeader()
        {
            return
@"/***************************************************************************************************************
     MDX script formatted with Analysis Services Query Analyzer version " + SSASQueryAnalyzerClient.ClientVersion.ToString() + @" https://ssasqueryanalyzer.github.io 
 ***************************************************************************************************************/

";
        }

        private static string DefaultHeader()
        {
            return
@"/***************************************************************************************************************
     MDX script edited with Analysis Services Query Analyzer version " + SSASQueryAnalyzerClient.ClientVersion.ToString() + @" https://ssasqueryanalyzer.github.io
 ***************************************************************************************************************/

";
        }

        private static string SelectedPdfFileName
        {
            get
            {
                return selectedPdfFileName;
            }
            set
            {
                selectedPdfFileName = value;
            }
        }

        private static bool ShowReport
        {
            get
            {
                return showReport;
            }
            set
            {
                showReport = value;
            }
        }

        private static bool SaveReport
        {
            get
            {
                return saveReport;
            }
            set
            {
                saveReport = value;
            }
        }


        private static bool ExecuteAnalysis
        {
            get
            {
                return executeAnalysis;
            }
            set
            {
                executeAnalysis = value;
            }
        }
        static DTEManager()
        {            
            _dte = (DTE2)Package.GetGlobalService(typeof(SDTE));

            AnalysisWindows = new Dictionary<Window, ScriptAndResultsEditorControl>();
        }

        private static bool ShowDialogForCreatePdfReport()
        {
            var mdxExtension = ".mdx";
            var pdfExtension = ".pdf";
            var pdfFileName = "ASQA report.pdf";

            using (var form = new PdfReportConfigurationForm())
            {
                var caption = _dte.ActiveDocument.ActiveWindow.Caption;
                if (caption.ToLower().Contains(mdxExtension))
                {
                    var mdxIndex = caption.ToLower().IndexOf(mdxExtension);
                    pdfFileName = caption.Substring(0, mdxIndex);
                    pdfFileName = pdfFileName + pdfExtension;
                }

                form.savePdfReportDialog.InitialDirectory = Application.StartupPath;
                form.savePdfReportDialog.FileName = pdfFileName;

                if (ExecuteAnalysis)
                {
                    form.checkBoxExecuteAnalysis.Checked = true;
                    form.checkBoxExecuteAnalysis.Enabled = false;
                }

                if (form.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
                else
                {
                    ExecuteAnalysis = form.checkBoxExecuteAnalysis.Checked;
                    ShowReport = form.checkBoxShowReport.Checked;
                    SaveReport = form.checkBoxSaveReport.Checked;
                    if (SaveReport == true)
                    {
                        if (Directory.Exists(Path.GetDirectoryName(form.savePdfReportDialog.FileName)))
                        {
                            SelectedPdfFileName = form.savePdfReportDialog.FileName;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        SelectedPdfFileName = "";
                        return true;
                    }
                }
            }
        }

        private static Tuple<string, string> ShowDialogForSelectConnection()
        {
            var mdxExtension = ".mdx";
            
            using (var form = new BatchModeAnalysisConfigurationForm())
            {
                var caption = _dte.ActiveDocument.ActiveWindow.Caption;
                if (caption.ToLower().Contains(mdxExtension))
                {
                    var mdxIndex = caption.ToLower().IndexOf(mdxExtension) + mdxExtension.Length;
                    form.SelectedBatchName = caption.Substring(0, mdxIndex);
                }

                if (form.ShowDialog() != DialogResult.OK)
                    return null;

                if (form.SelectedConnection == null)
                    return null;

                return Tuple.Create(
                    form.SelectedConnection.ConnectionString.ToAsqaSqlConnectionString(),
                    form.SelectedBatchName
                    );
            }
        }

        public static ScriptAndResultsEditorControl GetCurrentAnalysisWindowEditorControl()
        {
            if (_dte.ActiveDocument != null)
            {
                if (AnalysisWindows.TryGetValue(_dte.ActiveDocument.ActiveWindow, out ScriptAndResultsEditorControl scriptEditorControl))
                    return scriptEditorControl;
            }

            return null;
        }

        private static Control RestoreAnalysisServerResultsControl(ScriptAndResultsEditorControl scriptEditorControl, bool showOriginalControls)
        {
            Control displayResultsControl = null;

            foreach (Control control1 in scriptEditorControl.Controls)
            {
                if (control1 is Splitter)
                    control1.Show();

                foreach (Control control2 in control1.Controls)
                {
                    if (control2 is Splitter)
                        control2.Show();

                    if (control2.GetType().FullName == "Microsoft.SqlServer.Management.UI.VSIntegration.Editors.DisplayAnalysisServerResultsControl")
                    {
                        displayResultsControl = control2;

                        // These are the objects that a default MDX Query window shows: "Messages" and "Results" tab
                        foreach (var control3 in displayResultsControl.Controls.Cast<Control>().Where((c) => c is AnalysisServicesExecutionControl))
                            control3.Visible = showOriginalControls;

                        for (var i = displayResultsControl.Controls.Count - 1; i >= 0; i--)
                        {
                            var control = displayResultsControl.Controls[i];
                            if (control is ResultPresenterControl || control is CustomErrorControl)
                            {
                                displayResultsControl.Controls.RemoveAt(i);
                                control.Dispose();
                            }
                        }

                        break;
                    }

                    if (displayResultsControl != null)
                        displayResultsControl.Show();
                }
            }

            return displayResultsControl;
        }

        private static StringBuilder BuildMessage(string complexObjectName, StringBuilder message)
        {
            switch (complexObjectName)
            {
                case "Dimensions":
                    message.AppendLine(string.Format("- Complex object 'Dimensions': ('{0}' [ID: {1}])",
                                                        "Query Dimension",
                                                        "81"));
                    break;
                case "Measures":
                    message.AppendLine(string.Format("- Complex object 'Measures': ('{0}' [ID: {1}] - '{2}' [ID: {3}])",
                                    "Calculation Evaluation",
                                    "110",
                                    "Calculation Evaluation Detailed Information",
                                    "111"));
                    break;
                case "NonEmpty Activities":
                    message.AppendLine(string.Format("- Complex object 'NonEmpty Activities': ('{0}' [ID: {1}] - '{2}' [ID: {3}])",
                                    "Calculate Non Empty Begin",
                                    "72",
                                    "Calculate Non Empty Current",
                                    "73"));
                    break;
                case "Serialization Activities":
                    message.AppendLine(string.Format("- Complex object 'Serialization Activities': ('{0}' [ID: {1}] - '{2}' [ID: {3}] - '{4}' [ID: {5}])",
                                    "Serialize Results Begin",
                                    "75",
                                    "Serialize Results Current",
                                    "76",
                                    "Serialize Results End",
                                    "77"));
                    break;
                default:
                    break;
            }

            return message;
        }

        private static void ValidateFromBatchAnalysisSettings(string config)
        {
            #region Complex object validation error

            var xdoc = XDocument.Parse(config);
            var trace = xdoc.Root.Element("trace");

            var messages = new StringBuilder();

            // TOFIX: usare settings dell'esecuzione batch
            if (Settings.Default.TimelineDimensionsVisible)
            {
                if (trace == null ||
                    trace.Elements().SingleOrDefault((e) => e.Attribute("id").Value == "81") == null) // Query Processing/Query Dimension
                    BuildMessage("Dimensions", messages);
            }

            if (Settings.Default.TimelineMeasuresVisible)
            {
                if (trace == null ||
                    trace.Elements().SingleOrDefault((e) => e.Attribute("id").Value == "110") == null || // Query Processing/Calculation Evaluation
                    trace.Elements().SingleOrDefault((e) => e.Attribute("id").Value == "111") == null)   // Query Processing/Calculation Evaluation Detailed Information
                    BuildMessage("Measures", messages);
            }

            if (Settings.Default.TimelineNonEmptyActivitiesVisible)
            {
                if (trace == null ||
                    trace.Elements().SingleOrDefault((e) => e.Attribute("id").Value == "72") == null || // Query Processing/Calculate Non Empty Begin
                    trace.Elements().SingleOrDefault((e) => e.Attribute("id").Value == "73") == null)   // Query Processing/Calculate Non Empty Current
                    BuildMessage("NonEmpty Activities", messages);
            }

            if (Settings.Default.TimelineSerializationActivitiesVisible)
            {
                if (trace == null ||
                    trace.Elements().SingleOrDefault((e) => e.Attribute("id").Value == "75") == null || // Query Processing/Serialize Results Begin
                    trace.Elements().SingleOrDefault((e) => e.Attribute("id").Value == "76") == null || // Query Processing/Serialize Results Current
                    trace.Elements().SingleOrDefault((e) => e.Attribute("id").Value == "77") == null)   // Query Processing/Serialize Results End
                    BuildMessage("Serialization Activities", messages);
            }

            if (messages.Length > 0)
            {
                messages.Insert(0, "Please uncheck the following Complex Objects in the Addin tab of the ASQA Helper, since their related Profiler Events where not collected during the analysis:\r\n");
                throw new ApplicationException("Complex object validation error:" + messages);
            }

            #endregion
        }

        private static void ValidateLiveAnalysisSettings(DataTable traceConfig)
        {
            #region Complex object validation error

            var config = traceConfig.AsEnumerable();
            var messages = new StringBuilder();

            // TODO: gestire setting immutabili
            if (Settings.Default.TimelineDimensionsVisible)
            {
                var event81 = config.Single((r) => r.Field<int>("EventID") == 81); // Query Processing/Query Dimension
                if (Convert.ToBoolean(event81.Field<string>("IsActive")) == false)
                    BuildMessage("Dimensions", messages);
            }

            if (Settings.Default.TimelineMeasuresVisible)
            {
                var event110 = config.Single((r) => r.Field<int>("EventID") == 110); // Query Processing/Calculation Evaluation
                var event111 = config.Single((r) => r.Field<int>("EventID") == 111); // Query Processing/Calculation Evaluation Detailed Information
                if (Convert.ToBoolean(event110.Field<string>("IsActive")) == false || Convert.ToBoolean(event111.Field<string>("IsActive")) == false)
                    BuildMessage("Measures", messages);
            }

            if (Settings.Default.TimelineNonEmptyActivitiesVisible)
            {
                var event72 = config.Single((r) => r.Field<int>("EventID") == 72); // Query Processing/Calculate Non Empty Begin
                var event73 = config.Single((r) => r.Field<int>("EventID") == 73); // Query Processing/Calculate Non Empty Current
                if (Convert.ToBoolean(event72.Field<string>("IsActive")) == false || Convert.ToBoolean(event73.Field<string>("IsActive")) == false )
                    BuildMessage("NonEmpty Activities", messages);
            }

            if (Settings.Default.TimelineSerializationActivitiesVisible)
            {
                var event75 = config.Single((r) => r.Field<int>("EventID") == 75); // Query Processing/Serialize Results Begin
                var event76 = config.Single((r) => r.Field<int>("EventID") == 76); // Query Processing/Serialize Results Current
                var event77 = config.Single((r) => r.Field<int>("EventID") == 77); // Query Processing/Serialize Results End
                if (Convert.ToBoolean(event75.Field<string>("IsActive")) == false || Convert.ToBoolean(event76.Field<string>("IsActive")) == false || Convert.ToBoolean(event77.Field<string>("IsActive")) == false )
                    BuildMessage("Serialization Activities", messages);
            }

            if (messages.Length > 0)
            {
                messages.Insert(0, "Please verify the activation of the related Profiler Events in the Live mode tab of the ASQA Helper, for the following Complex Objects:\r\n");
                throw new ApplicationException("Complex object validation error:" + messages);
            }

            #endregion
        }

        public static void NewBlankWindow(ScriptType scriptType, string scriptText)
        {
            var scriptFactory = ServiceCache.ScriptFactory;
            if (scriptFactory == null)
                return;

            var scriptEditorControl = (ScriptAndResultsEditorControl)scriptFactory.CreateNewBlankScript(scriptType);            
            (_dte.ActiveDocument.Object("TextDocument") as TextDocument)
                .EndPoint.CreateEditPoint()
                .Insert(scriptText);
        }

        public static void NewAnalysisWindow(bool debug = false)
        {
            var scriptFactory = ServiceCache.ScriptFactory;
            if (scriptFactory == null)
                return;

            var scriptEditorControl = (ScriptAndResultsEditorControl)scriptFactory.CreateNewBlankScript(ScriptType.Mdx); 
                
            LogoPanel.Create(scriptEditorControl);
               
            AnalysisWindows.Add(_dte.ActiveDocument.ActiveWindow, scriptEditorControl);
#if DEBUG
            var debugDocument = (TextDocument)_dte.ActiveDocument.Object("TextDocument");
            
            var debugPoint = debugDocument.EndPoint.CreateEditPoint();
            debugPoint.Insert(DefaultHeader());
            debugPoint = debugDocument.EndPoint.CreateEditPoint();
            debugPoint.Insert(CommandNewAnalysisDefaultStatement);
#endif  
        }

        public static async void ExecuteAnalysisAsync(Action onExecuted = null)
        {
            if (_dte.ActiveDocument.ActiveWindow == null)
                return;

            var scriptEditorControl = GetCurrentAnalysisWindowEditorControl();
            if (scriptEditorControl == null)
                return;

            var analysisServerResultsControl = RestoreAnalysisServerResultsControl(scriptEditorControl, showOriginalControls: false);
            try
            {
                var document = (TextDocument)_dte.ActiveDocument.Object("TextDocument");
                var statement = (document.Selection.Text.Length > 0 ? document.Selection.Text : document.StartPoint.CreateEditPoint().GetText(document.EndPoint)).Trim();
                if (statement.Length == 0)
                    return;

                var server = scriptEditorControl.Connection.ServerName;
                var database = scriptEditorControl.Connection.AdvancedOptions.Get("DATABASE");
            
                LogoPanel.SetMode(scriptEditorControl, LogoPanel.PanelMode.Live);

                using (var client = new SSASQueryAnalyzerClient(server, database))
                {
                    using (var config = await client.GetConfigurationForTraceEventsAsync())
                        ValidateLiveAnalysisSettings(config);

                    client.DebugToXml = Settings.Default.DebugEnabled;
                    client.ExecutionProgressControlEnabled = true;
                    client.ExecutionProgressControl.ActivitiesEnabled = Settings.Default.ExecutionProgressActivitiesEnabled;
                    client.ExecutionProgressControl.TitleMessage = "Live";

                    analysisServerResultsControl.ResizeFor(client.ExecutionProgressControl);
                    analysisServerResultsControl.Controls.Add(client.ExecutionProgressControl);

                    var analyzerStatistics = await client.AnalyzeAsync(statement, queryResultRowLimit: Settings.Default.MaxRowsReturned);
                    {
                        LogoPanel.SetValues(scriptEditorControl,
                            columns: analyzerStatistics.ColdCacheExecutionResult.QueryResults.Columns.Count,
                            rows: analyzerStatistics.ColdCacheExecutionResult.QueryResults.Rows.Count
                            );

                        var control = client.BuildResultControl(analyzerStatistics);

                        analysisServerResultsControl.ResizeFor(control);
                        analysisServerResultsControl.Controls.Add(control);
                    }
                }

                onExecuted?.Invoke();
            }
            catch (Exception ex)
            {
                analysisServerResultsControl.Controls.Add(CustomErrorControl.CreateFromException(ex));
            }
        }

        public static async void ExecuteBatchAnalysisAsync()
        {
            if (_dte.ActiveDocument.ActiveWindow == null)
                return;

            var scriptEditorControl = GetCurrentAnalysisWindowEditorControl();
            if (scriptEditorControl == null)
                return;

            var dialogSelected = ShowDialogForSelectConnection();
            if (dialogSelected == null)
                return;

            var analysisServerResultsControl = RestoreAnalysisServerResultsControl(scriptEditorControl, showOriginalControls: false);
            try
            {
                var document = (TextDocument)_dte.ActiveDocument.Object("TextDocument");
                var statement = (document.Selection.Text.Length > 0 ? document.Selection.Text : document.StartPoint.CreateEditPoint().GetText(document.EndPoint)).Trim();
                if (statement.Length == 0)
                    return;

                LogoPanel.SetMode(scriptEditorControl, LogoPanel.PanelMode.Batch);

                var server = scriptEditorControl.Connection.ServerName;
                var database = scriptEditorControl.Connection.AdvancedOptions.Get("DATABASE");

                using (var client = new SSASQueryAnalyzerClient(server, database))
                {
                    client.ExecutionProgressControlEnabled = true;
                    client.ExecutionProgressControl.TitleMessage = "Batch";

                    analysisServerResultsControl.ResizeFor(client.ExecutionProgressControl);
                    analysisServerResultsControl.Controls.Add(client.ExecutionProgressControl);

                    var analyzerStatistics = await client.AnalyzeBatchAsync(dialogSelected.Item1, statement, batchName: dialogSelected.Item2);

                    var control = client.BuildBatchResultControl(analyzerStatistics);
                    analysisServerResultsControl.ResizeFor(control);
                    analysisServerResultsControl.Controls.Add(control);
                }
            }
            catch (Exception ex)
            {
                analysisServerResultsControl.Controls.Add(CustomErrorControl.CreateFromException(ex));
            }
        }

        public static async void ExecuteLoadFromBatchAnalysisAsync(string connectionStringBatch, string batchID, string statement, Action onExecuted = null)
        {
            NewAnalysisWindow();

            var scriptEditorControl = GetCurrentAnalysisWindowEditorControl();
            if (scriptEditorControl == null || scriptEditorControl.Connection == null)
                return;

            var analysisServerResultsControl = RestoreAnalysisServerResultsControl(scriptEditorControl, showOriginalControls: false);
            try
            {
                var document = (TextDocument)_dte.ActiveDocument.Object("TextDocument");

                var selection = document.Selection;
                selection.StartOfDocument(false);
                selection.EndOfDocument(true);
                selection.Delete();

                var point = document.EndPoint.CreateEditPoint();
                point.Insert(statement);

                LogoPanel.SetMode(scriptEditorControl, LogoPanel.PanelMode.LoadFomDB);

                var server = scriptEditorControl.Connection.ServerName;
                var database = scriptEditorControl.Connection.AdvancedOptions.Get("DATABASE");

                using (var client = new SSASQueryAnalyzerClient(server, database))
                {
                    client.ExecutionProgressControlEnabled = true;
                    client.ExecutionProgressControl.TitleMessage = "FromBatch";
                    
                    analysisServerResultsControl.ResizeFor(client.ExecutionProgressControl);
                    analysisServerResultsControl.Controls.Add(client.ExecutionProgressControl);

                    var analyzerStatistics = await client.AnalyzeFromBatchAsync(connectionStringBatch, batchID);

                    ValidateFromBatchAnalysisSettings(analyzerStatistics.ColdCacheExecutionResult.ASQAServerConfig);

                    var control = client.BuildLoadBatchResultControl(analyzerStatistics);
                    analysisServerResultsControl.ResizeFor(control);
                    analysisServerResultsControl.Controls.Add(control);
                }

                onExecuted?.Invoke();
            }
            catch (Exception ex)
            {
                analysisServerResultsControl.Controls.Add(CustomErrorControl.CreateFromException(ex));
            }
        }

        public static void FormatMDX()
        {
            if (_dte.ActiveDocument.ActiveWindow == null)
                return;

            var scriptEditorControl = GetCurrentAnalysisWindowEditorControl();
            if (scriptEditorControl == null)
                return;

            var document = (TextDocument)_dte.ActiveDocument.Object("TextDocument");
            var statement = (document.Selection.Text.Length > 0 ? document.Selection.Text : document.StartPoint.CreateEditPoint().GetText(document.EndPoint)).Trim();
            if (statement.Length == 0)
                return;

            // Remove headers if they exist
            statement = statement.Replace(DefaultHeader(), "");
            statement = statement.Replace(FormattedMDXHeader(), "");

            var parser = new MDXParser(statement, new Source(), new CubeInfo());
            if (parser != null)
            {
                parser.Parse();

                var options = new FormatOptions
                {
                    Output = OutputFormat.Text,
                    Indent = 2,
                    CommaBeforeNewLine = true,
                    ColorFunctionNames = true,
                    LineWidth = 200
                };

                statement = FormattedMDXHeader();
                statement += parser.FormatMDX(options);

                var startPoint = document.StartPoint.CreateEditPoint();
                var endPoint = document.EndPoint.CreateEditPoint();

                startPoint.StartOfDocument();
                endPoint.EndOfDocument();
                startPoint.ReplaceText(endPoint, statement, (int)vsEPReplaceTextOptions.vsEPReplaceTextAutoformat);
            }
        }

        public static void CreatePowershellScript()
        {
            if (_dte.ActiveDocument.ActiveWindow == null)
                return;

            var scriptEditorControl = GetCurrentAnalysisWindowEditorControl();
            if (scriptEditorControl == null)
                return;

            var ssasInstance = scriptEditorControl.Connection.ServerName;
            var ssasDatabase = scriptEditorControl.Connection.AdvancedOptions.Get("DATABASE");

            var document = (TextDocument)_dte.ActiveDocument.Object("TextDocument");
            var mdxStatement = (document.Selection.Text.Length > 0 ? document.Selection.Text : document.StartPoint.CreateEditPoint().GetText(document.EndPoint)).Trim();
            if (mdxStatement.Length == 0)
                return;

            var dialogSelection = ShowDialogForSelectConnection();
            if (dialogSelection == null)
                return;

            var builder = new SqlConnectionStringBuilder(dialogSelection.Item1)
            {
                ApplicationName = "Powershell"
            };
            var connectionString = builder.ToString();
            var batchName = dialogSelection.Item2;

            string script;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SSASQueryAnalyzerAnalyzeBatch))
            using (var reader = new StreamReader(stream))
                script = reader.ReadToEnd();

            script = script.Replace("#ASQAClientVersion#", SSASQueryAnalyzerClient.ClientVersion.ToString());
            script = script.Replace("#SSASInstance#", ssasInstance.EscapePowershellString());
            script = script.Replace("#SSASDatabase#", ssasDatabase.EscapePowershellString());
            script = script.Replace("#MDXStatement#", mdxStatement.EscapePowershellString());
            script = script.Replace("#SQLConnectionString#", connectionString.EscapePowershellString());
            script = script.Replace("#BatchName#", batchName.EscapePowershellString());

            try
            {
                var path = Path.ChangeExtension(Path.GetTempFileName(), "ps1");
                File.WriteAllText(path, script);
                System.Diagnostics.Process.Start("powershell_ise.exe", path);
            }
            catch
            {
                NewBlankWindow(ScriptType.Sql, script);
            }
        }

        public static void CreatePdfReport()
        {
        }

        public static void CreatePdfReportFromBatch(string connectionStringBatch, string batchID, string statement)
        {
        }

        public static ResultPresenterControl GetCurrentResultPresenterControl()
        {
            var scriptEditorControl = GetCurrentAnalysisWindowEditorControl();
            if (scriptEditorControl == null)
                return null;
            
            foreach (Control control1 in scriptEditorControl.Controls)
            {
                foreach (Control control2 in control1.Controls)
                {
                    if (control2.GetType().FullName == "Microsoft.SqlServer.Management.UI.VSIntegration.Editors.DisplayAnalysisServerResultsControl")
                    {
                        for (var i = control2.Controls.Count - 1; i >= 0; i--)
                        {
                            if (control2.Controls[i] is ResultPresenterControl)
                                return (ResultPresenterControl)control2.Controls[i];
                        }
                    }
                }
            }

            return null;
        }
    }
}
