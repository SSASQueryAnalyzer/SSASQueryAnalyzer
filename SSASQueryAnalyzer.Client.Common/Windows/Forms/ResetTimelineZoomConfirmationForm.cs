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
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;

    public partial class ResetTimelineZoomConfirmationForm : Form
    {
        public ResetTimelineZoomConfirmationForm()
        {
            InitializeComponent();

            #region FlatButtons

            buttonYes.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonYes.FlatAppearance.MouseOverBackColor = Color.White;
            buttonYes.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonYes.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonYes.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonYes.MouseLeave += Extension.OnFlatButton_MouseLeave;

            buttonNo.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonNo.FlatAppearance.MouseOverBackColor = Color.White;
            buttonNo.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonNo.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonNo.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonNo.MouseLeave += Extension.OnFlatButton_MouseLeave;

            #endregion

            var iconBitmap = SystemIcons.Warning.ToBitmap();
            pictureInfo.Image = iconBitmap;
        }

    }
}
