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
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CustomLabelControl : Label
    {
        private bool _drawBorder;
        private int _borderWidthOffset;
        private int _borderHeightOffset;
        private ButtonBorderStyle _borderStyle;
        private Color _borderColor;

        public CustomLabelControl()
        {
            InitializeComponent();

            BorderStyle = ButtonBorderStyle.Solid;
            BorderColor = Color.Black;
        }

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
        new public ButtonBorderStyle BorderStyle
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

        [Category("Custom Properties")]
        public int BorderWidthOffset
        {
            get
            {
                return _borderWidthOffset;
            }
            set
            {
                if (value < 2)
                    value = 2;

                if (_borderWidthOffset != value)
                {
                    _borderWidthOffset = value;
                    Invalidate();
                }
            }
        }

        [Category("Custom Properties")]
        public int BorderHeightOffset
        {
            get
            {
                return _borderHeightOffset;
            }
            set
            {
                if (value < 2)
                    value = 2;

                if (_borderHeightOffset != value)
                {
                    _borderHeightOffset = value;
                    Invalidate();
                }
            }
        } 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DrawBorder)
            {
                /* This code draw the border of the label */
                var x = e.ClipRectangle.X + (int)(BorderWidthOffset / 2);
                var y = e.ClipRectangle.Y + (int)(BorderHeightOffset / 2);
                var width = e.ClipRectangle.Width - BorderWidthOffset;
                var height = e.ClipRectangle.Height - BorderHeightOffset;

                var rectangle = new Rectangle(x, y, width, height);
                ControlPaint.DrawBorder(e.Graphics, rectangle, BorderColor, BorderStyle);                
            }
        }
    }
}
