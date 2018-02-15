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
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CustomComboBoxControl : ComboBox
    {
        private static int WM_PAINT = 0x000F;

        private bool _drawBorder;
        private Color _borderColor;
        private ButtonBorderStyle _borderStyle;

        [Category("Custom Properties")]
        public Color BorderColor
        {
            get
            { 
                return _borderColor; 
            }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Custom Properties")]
        public ButtonBorderStyle BorderStyle
        {
            get 
            { 
                return _borderStyle; 
            }
            set
            {
                if (_borderStyle != value)
                {
                    _borderStyle = value;
                    Invalidate();
                }
            }
        }

        [Category("Custom Properties")]
        public bool DrawBorder
        {
            get
            {
                return _drawBorder;
            }
            set
            {
                if (_drawBorder != value)
                {
                    _drawBorder = value;
                    Invalidate();
                }
            }
        }

        public CustomComboBoxControl()
        {
            InitializeComponent();

            BorderColor = Color.Black;
            BorderStyle = ButtonBorderStyle.Solid;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (DrawBorder && m.Msg == WM_PAINT)
            {
                using(var graphics = Graphics.FromHwnd(Handle))
                {
                    var bounds = new Rectangle(0, 0, Width, Height);
                    ControlPaint.DrawBorder(graphics, bounds, BorderColor, BorderStyle);
                }
            }
        }
    }
}
