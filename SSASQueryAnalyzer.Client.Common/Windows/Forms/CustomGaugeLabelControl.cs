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
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;


    public enum CustomGaugeLabelShape
    {
        Circle,
        Square
    }

    public enum CustomGaugeLabelState
    {
        Signaled,
        Unsignaled,
        Mixed,
        Off
    }

    public partial class CustomGaugeLabelControl : Label
    {
        private Color _fillColor;
        private Color _borderColor;
        public Color cacheFillColor;
        public Color cacheBorderColor;
        private int _borderWidthOffset = 2;
        private int _borderHeightOffset = 2;
        private CustomGaugeLabelState _state;
        private CustomGaugeLabelShape _shape;

        public CustomGaugeLabelControl()
        {
            InitializeComponent();

            State = CustomGaugeLabelState.Off;
            Shape = CustomGaugeLabelShape.Circle;
        }

        [Category("Custom Properties")]
        public CustomGaugeLabelState State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                {
                    _state = value;

                    // TODO: sistemare enum e custom color
                    switch(_state)
                    {
                        //case CustomGaugeLabelState.Unsignaled:
                        //    _fillColor = CustomColor.CustomGaugeLabelStateUnsignaledColor;
                        //    _borderColor = CustomColor.CustomGaugeLabelStateUnsignaledBorderColor;
                        //    break;
                        //case CustomGaugeLabelState.Signaled:
                        //    _fillColor = CustomColor.CustomGaugeLabelStateSignaledColor;
                        //    _borderColor = CustomColor.CustomGaugeLabelStateSignaledBorderColor;
                        //    break;
                        //case CustomGaugeLabelState.Mixed:
                        //    _fillColor = CustomColor.CustomGaugeLabelStateMixedColor;
                        //    _borderColor = CustomColor.CustomGaugeLabelStateMixedBorderColor;
                        //    break;
                        //case CustomGaugeLabelState.Off:
                        //    _fillColor = CustomColor.CustomGaugeLabelStateUnknownColor;
                        //    _borderColor = CustomColor.CustomGaugeLabelStateUnknownBorderColor;
                        //    break;
                        case CustomGaugeLabelState.Off:
                            _fillColor = ResultPresenterConfiguration.DefaultWindowBackColor;
                            _borderColor = Color.DarkGray;
                            ForeColor = Color.DarkGray;
                            break;
                        default:
                            _fillColor = cacheFillColor;
                            _borderColor = cacheBorderColor;
                            ForeColor = ResultPresenterConfiguration.DefaultLabelsColor;
                            break;
                    }

                    Invalidate();
                }
            }
        }

        [Category("Custom Properties")]
        public CustomGaugeLabelShape Shape
        {
            get
            {
                return _shape;
            }
            set
            {
                if (_shape != value)
                {
                    _shape = value;
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
            var textSize = TextRenderer.MeasureText(Text, Font);
            int width = textSize.Height;
            int height = textSize.Height;
            int x = 0;
            int y = 0;

            switch (RightToLeft)
            {
                case RightToLeft.No:
                case RightToLeft.Inherit:
                    x = e.ClipRectangle.X + BorderWidthOffset;
                    y = e.ClipRectangle.Y + BorderHeightOffset;
                    break;
                case RightToLeft.Yes:
                    x = Width - width - BorderWidthOffset;
                    y = e.ClipRectangle.Y + BorderHeightOffset;
                    break;
            }

            var externalRectangle = new Rectangle(x, y, width, height);
            var internalRectangle = new Rectangle(++x, ++y, width -= 2, height -= 2);

            //
            // draw gauge
            //
            using (var pen = new Pen(_borderColor))
            using (var brush = new SolidBrush(_fillColor))
            {
                switch (Shape)
                {
                    case CustomGaugeLabelShape.Circle:
                        e.Graphics.DrawEllipse(pen, externalRectangle);
                        e.Graphics.FillEllipse(brush, internalRectangle);
                        break;
                    case CustomGaugeLabelShape.Square:
                        e.Graphics.DrawRectangle(pen, externalRectangle);
                        e.Graphics.FillRectangle(brush, internalRectangle);
                        break;
                }
            }

            //
            // draw text
            //
            switch (RightToLeft)
            {
                case RightToLeft.No:
                case RightToLeft.Inherit:
                    x = x + width + BorderWidthOffset;
                    break;
                case RightToLeft.Yes:
                    x = e.ClipRectangle.Width - width - textSize.Width - BorderWidthOffset;
                    break;
            }

            var rectangle = new Rectangle(x, y, textSize.Width, textSize.Height);
            {
                TextRenderer.DrawText(e.Graphics, Text, Font, rectangle, ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
