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

namespace SSASQueryAnalyzer.Client.SSMS.VSPackage
{
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Shell;
    using Shell.Command;
    using Shell.ToolWindow;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Properties;
    using SSASQueryAnalyzer.Client.SSMS.VSPackage.Infrastructure;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [ProvideAutoLoad(ShellGuids.ObjectExplorerToolWindowIDString)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideToolWindow(typeof(AsqaToolWindowPaneHelper), Style = VsDockStyle.Tabbed, Window = ShellGuids.ObjectExplorerToolWindowIDString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(AsqaPackageGuidString)]
    public sealed class SSASQueryAnalyzerSSMSPackage : Package
    {
        public const string AsqaPackageGuidString = "28672cc0-c8a7-4203-b4ce-d9c3e6216812";
        public Guid AsqaPackageGuid = new Guid(AsqaPackageGuidString);
        
        private IVsOutputWindowPane _outputWindowPane;

        public SSASQueryAnalyzerSSMSPackage()
        {
        }

        #region Package Members

        protected override void Initialize()
        {
            base.Initialize();                        
            try
            {
                OutputMessage("::Initialize");
                InitializeMenuCommands();
                CheckForUpdate();
            }
            catch (Exception ex)
            {
                ActivityLogEntry(__ACTIVITYLOG_ENTRYTYPE.ALE_ERROR, ex.ToString());
            }
        }

        protected override int QueryClose(out bool canClose)
        {
            OutputMessage("::QueryClose");

            using (var registryKey = UserRegistryRoot.CreateSubKey(@"Packages\{" + AsqaPackageGuidString + "}"))
                registryKey.SetValue("SkipLoading", 1);

            return base.QueryClose(out canClose);
        }

        #endregion

        public void OutputMessage(string message, params object[] args)
        {
            if (_outputWindowPane == null)
            {
                var outputWindow = (IVsOutputWindow)GetService(typeof(SVsOutputWindow));
                ErrorHandler.ThrowOnFailure(outputWindow.CreatePane(AsqaPackageGuid, pszPaneName: nameof(SSASQueryAnalyzerSSMSPackage), fInitVisible: 1, fClearWithSolution: 0));
                ErrorHandler.ThrowOnFailure(outputWindow.GetPane(ref AsqaPackageGuid, out _outputWindowPane));
            }

            //if (_outputWindowPane != null)
            //{
                _outputWindowPane.OutputString($"{ DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) } - { string.Format(message, args) }\r\n");
                _outputWindowPane.Activate();
            //}
        }

        private void ActivityLogEntry(__ACTIVITYLOG_ENTRYTYPE entryType, string message)
        {
            OutputMessage(message);

            // Logs to %AppData%\Microsoft\VisualStudio\14.0\ActivityLog.XML.
            // Obtain the activity log just before writing to it, do not cache or save the activity log for future use.
            var log = GetService(typeof(SVsActivityLog)) as IVsActivityLog;
            if (log == null)
                return;
            
            ErrorHandler.ThrowOnFailure(log.LogEntryGuid((uint)entryType, ToString(), message, AsqaPackageGuid));
        }

        private void InitializeMenuCommands()
        {
            OutputMessage("::InitializeMenuCommands");

            if (Zombied)
                return;

            AsqaCommandNewQuery.Initialize(this);
            AsqaCommandExecuteLiveAnalysis.Initialize(this);
            AsqaCommandExecuteBatchAnalysis.Initialize(this);
            AsqaCommandCreatePowershellScript.Initialize(this);
            AsqaCommandFormatMDX.Initialize(this);
            //AsqaCommandCreatePdfReport.Initialize(this);
            AsqaCommandShowHelper.Initialize(this);            
        }

        private void CheckForUpdate()
        {
            OutputMessage("::CheckForUpdate");

            if (Settings.Default.AddInAutomaticallyCheckNewVersion)
            {
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    try
                    {
                        VersionChecker.CheckForUpdate();
                        OutputMessage("::CheckForUpdate -> [{0}]", VersionChecker.CurrentVersion);
                    }
                    catch (Exception ex)
                    {
                        OutputMessage("::CheckForUpdate::Exception -> [{0}]".FormatWith(ex));
                    }
                },
                TaskCreationOptions.AttachedToParent);
            }
        }
    }
}
