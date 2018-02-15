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
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CustomTabControlControl : TabControl
    {
        public CustomTabControlControl()
        {
            InitializeComponent();

            if (TabCount > 0)
                SelectedIndex = 0;

            DrawMode = TabDrawMode.Normal;

            //DrawMode = TabDrawMode.OwnerDrawFixed;
            //DrawItem += OnDrawItem;
        }

        //private void OnDrawItem(object sender, DrawItemEventArgs e)
        //{
        //    var page = TabPages[e.Index];

        //    var rect = GetTabRect(e.Index);
            
        //    using (var brush = new SolidBrush(page.BackColor))
        //    {
        //        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        //            brush.Color = Color.White;

        //        e.Graphics.FillRectangle(brush, rect);
        //        e.DrawFocusRectangle();
        //    }

        //    using (var format = new StringFormat())
        //    {
        //        format.Alignment = StringAlignment.Center;
        //        format.LineAlignment = StringAlignment.Center;

        //        using (var brush = new SolidBrush(page.ForeColor))
        //        {
        //            // TODO : sistemare

        //            if (page.Text.IndexOf("warm", StringComparison.OrdinalIgnoreCase) >= 0)
        //                brush.Color = Color.Red;
        //            if (page.Text.IndexOf("cold", StringComparison.OrdinalIgnoreCase) >= 0)
        //                brush.Color = Color.Blue;

        //            e.Graphics.DrawString(page.Text, page.Font, brush, rect, format);
        //        }
        //    }
        //}
    }
}
