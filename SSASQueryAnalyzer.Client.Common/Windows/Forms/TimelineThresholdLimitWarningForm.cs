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
    using SSASQueryAnalyzer.Client.Common.Infrastructure;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class TimelineThresholdLimitWarningForm : Form
    {
        public TimelineThresholdLimitWarningForm()
        {
            InitializeComponent();

            #region FlatButtons

            buttonOK.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonOK.FlatAppearance.MouseOverBackColor = Color.White;
            buttonOK.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonOK.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonOK.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonOK.MouseLeave += Extension.OnFlatButton_MouseLeave;

            #endregion

            var iconBitmap = SystemIcons.Warning.ToBitmap();
            pictureInfo.Image = iconBitmap;
        }
    }
}
