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
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using System;
    using System.ComponentModel.Design;
    using System.Runtime.InteropServices;
    using ToolWindow;

    internal sealed class AsqaCommandShowHelper
    {
        private readonly Package _package;

        private AsqaCommandShowHelper(Package package)
        {
            _package = package ?? throw new ArgumentNullException(nameof(package));

            if (ServiceProvider.GetService(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                commandService.AddCommand(command: new OleMenuCommand(OnInvoke, id: new CommandID(PackageGuids.guidAsqaPackageCmdSet, PackageIds.cmdidAsqaToolbarCommandShowHelper))
                {
                    Supported = true,
                    Enabled = true
                });                

                commandService.AddCommand(command: new OleMenuCommand(OnInvoke, id: new CommandID(PackageGuids.guidAsqaPackageCmdSet, PackageIds.cmdidAsqaContextMenuCommandShowHelper))
                {
                    Supported = true,
                    Enabled = true
                });
            }
        }

        public static AsqaCommandShowHelper Instance
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
            Instance = new AsqaCommandShowHelper(package);
        }

        private void OnInvoke(object sender, EventArgs e)
        {
            var pane = _package.FindToolWindow(typeof(AsqaToolWindowPaneHelper), id: 0, create: true);
            if (pane == null)
                throw new COMException($"{ nameof(pane) } is null");

            var frame = pane.Frame as IVsWindowFrame;
            if (frame == null)
                throw new COMException($"{ nameof(frame) } is null");

            ErrorHandler.ThrowOnFailure(frame.Show());
        }
    }
}