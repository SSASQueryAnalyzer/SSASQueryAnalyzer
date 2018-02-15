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

namespace SSASQueryAnalyzer.Client.SSMS.VSPackage.Shell.Command
{
    using Microsoft.VisualStudio.Shell;
    using SSASQueryAnalyzer.Client.SSMS.VSPackage.Infrastructure;
    using System;
    using System.ComponentModel.Design;

    internal sealed class AsqaCommandCreatePowershellScript
    {
        private readonly Package _package;

        private AsqaCommandCreatePowershellScript(Package package)
        {
            _package = package ?? throw new ArgumentNullException(nameof(package));

            if (ServiceProvider.GetService(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                var command = new OleMenuCommand(OnInvoke, id: new CommandID(PackageGuids.guidAsqaPackageCmdSet, PackageIds.cmdidAsqaToolbarCommandCreatePowershellScript));
                command.BeforeQueryStatus += OnBeforeQueryStatus;
                commandService.AddCommand(command);

                command = new OleMenuCommand(OnInvoke, id: new CommandID(PackageGuids.guidAsqaPackageCmdSet, PackageIds.cmdidAsqaContextMenuCommandCreatePowershellScript));
                command.BeforeQueryStatus += OnBeforeQueryStatus;
                commandService.AddCommand(command);
            }
        }

        public static AsqaCommandCreatePowershellScript Instance
        {
            get;
            private set;
        }

        private IServiceProvider ServiceProvider
        {
            get
            {
                return _package;
            }
        }
        
        public static void Initialize(Package package)
        {
            Instance = new AsqaCommandCreatePowershellScript(package);
        }

        private void OnInvoke(object sender, EventArgs e)
        {
            DTEManager.CreatePowershellScript();
        }

        private void OnBeforeQueryStatus(object sender, EventArgs e)
        {
            if (sender is OleMenuCommand command)
            {
                command.Enabled = false;

                var window = DTEManager.GetCurrentAnalysisWindowEditorControl();
                if (window != null)
                {
                    if (window.Connection != null)
                        command.Enabled = true;
                }
            }
        }
    }
}
