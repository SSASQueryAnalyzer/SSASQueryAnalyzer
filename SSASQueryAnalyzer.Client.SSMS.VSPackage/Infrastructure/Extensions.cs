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
    using SSASQueryAnalyzer.Client.Common.Windows.Forms;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    internal static class Extensions
    {
        public static string ToAsqaSqlConnectionString(this string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            builder.InitialCatalog = "ASQA";
            return builder.ToString();
        }

        public static void HandleException(this Exception exception, bool display)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SSASQueryAnalyzer");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, "SSASQueryAnalyzer.SSMS.log");
            File.AppendAllText(path, "{0}\r\n{1}\r\n{0}\r\n{2}\r\n".FormatWith("********************", DateTime.UtcNow, exception));

            if (exception is AggregateException)
            {
                exception = (exception as AggregateException).Flatten();

                if (exception.InnerException != null)
                    exception = exception.InnerException;
            }

            using (var form = new Form())
            {
                form.Text = "SSASQueryAnalyzer - Exception";
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Controls.Add(CustomErrorControl.CreateFromException(exception, dialogMode: true, errorFile: path));
                form.Width = Screen.FromControl(form).Bounds.Width / 2;

                form.ShowDialog();
            }
        }

        public static void ResizeFor(this Control parent, Control child)
        {
            int frameHeight = parent.Height - parent.ClientSize.Height;
            int frameWidth = parent.Width - parent.ClientSize.Width;

            if (parent.ClientSize.Height <= child.Height)
                parent.Size = new Size(parent.Width, child.Height + frameHeight);

            if (parent.ClientSize.Width <= child.Width)
                parent.Size = new Size(child.Width + frameWidth, parent.Height);
        }
    }

    internal static class TreeViewExtensions
    {
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TVITEM lParam);

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        public static void HideCheckBox(this TreeNode node)
        {
            var tvi = new TVITEM
            {
                hItem = node.Handle,
                mask = TVIF_STATE,
                stateMask = TVIS_STATEIMAGEMASK,
                state = 0
            };
            SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }
    }
}
