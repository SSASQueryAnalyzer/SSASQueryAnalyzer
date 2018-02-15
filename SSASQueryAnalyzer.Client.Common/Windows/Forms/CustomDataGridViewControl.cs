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

    public partial class CustomDataGridViewControl : DataGridView
    {
        public static CustomDataGridViewControl Create(object datasource)
        {
            var view = new CustomDataGridViewControl();

            view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            view.Dock = DockStyle.Fill;
            view.DataSource = datasource;

            return view;
        }

        public CustomDataGridViewControl()
        {
            InitializeComponent();

            CellFormatting += OnCellFormatting;
        }

        private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
            {
                e.CellStyle.BackColor = Color.LightYellow;
                return;
            }

            var valueType = ((DataGridView)sender).Columns[e.ColumnIndex].ValueType;
            if (valueType == null)
                return;

            var nullableValueType = Nullable.GetUnderlyingType(valueType);
            if (nullableValueType != null)
                valueType = nullableValueType;

            if (valueType.Equals(typeof(DateTime)))
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy hh:mm:ss.fff");
                e.FormattingApplied = true;
            }
            else if (valueType.Equals(typeof(TimeSpan)))
            {
                e.Value = ((TimeSpan)e.Value).ToString("hh':'mm':'ss'.'fff");
                e.FormattingApplied = true;
            }
        }
    }
}
