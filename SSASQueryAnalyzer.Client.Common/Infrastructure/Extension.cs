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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices;
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Client.Common.Windows.Forms;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public static class Extension
	{
        internal static Be.Timvw.Framework.ComponentModel.SortableBindingList<T> ToSortableBindingList<T>(this IEnumerable<T> list)
        {
            return new Be.Timvw.Framework.ComponentModel.SortableBindingList<T>(list);
        }

        internal static void HideEmptyColumns(this DataGridView view)
        {
            var rows = view.Rows.Cast<DataGridViewRow>();

            var query = view.Columns.Cast<DataGridViewColumn>()
                .Where((c) => rows.All((r) => r.Cells[c.Index].Value == null));

            foreach (var column in query)
                column.Visible = false;
        }

        internal static AnalyzerExecutionResult ToAnalyzerExecutionResult(this DataSet dataset, bool dispose = false)
		{
			var result = AnalyzerExecutionResult.CreateFromDataSet(dataset);

			if (dispose)
			{
				dataset.Clear();
				dataset.Dispose();
				dataset = null;

				GC.Collect(); // TODO: verificare se serve
			}

			return result;
		}

        internal static IEnumerable<T> To<T>(this DataTable table, Func<DataColumn, Type> mappingCustomTypes = null) where T : new()
		{
            if (mappingCustomTypes == null)
                mappingCustomTypes = (column) => column.DataType;

			var tableFields = from DataColumn column in table.Columns
                              select new { Name = column.ColumnName, Type = mappingCustomTypes(column) };

			
            var classFields = from property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
							  where property.CanWrite
							  select new { Name = property.Name, Type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType };

			var sharedFields = classFields.Intersect(tableFields)
				.Select((f) => 
				{
					var property = typeof(T).GetProperty(f.Name);

					return new
					{
						Name = f.Name,
						Property = property,
						Column = table.Columns[f.Name],
						Type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType
					};
				});

			foreach (DataRow row in table.Rows)
			{
				var o = new T();

				Parallel.ForEach(sharedFields, (f) => 
				{
					var v = row[f.Column];

					if (Convert.IsDBNull(v))
						v = null;

                    if (v != null)
                    {
                        if (f.Type.IsEnum)
                        {
                            if (f.Type == typeof(TraceEventClass) || f.Type == typeof(TraceEventSubclass) || f.Type == typeof(ProcedureEvents)) // HACK :-/
                                v = Enum.Parse(f.Type, (string)v);
                            else
                                v = Enum.ToObject(f.Type, v);
                        }
                        else if (f.Type == typeof(DateTime))
                        {
                            v = new DateTime((((DateTime)v).Ticks / 10000) * 10000, ((DateTime)v).Kind);
                        }
                        else if (f.Type == typeof(Type))
                        {
                            v = Type.GetType((string)v, throwOnError: true);
                        }                      
                    }

					f.Property.SetValue(o, v, index: null); // if v == null sets property using the default value for that type
				});

				yield return o;                
			}
		}

        public static Version ToVersion(this DataTable table)
        {
            if (table == null)
                return null;

            if (table.Rows.Count != 1 || table.Columns.Count != 1)
                return null;

            var value = table.Rows[0][0];
            if (value == DBNull.Value)
                return null;

            //Version version;
            //if (Version.TryParse("", out version))
            //    return version

            return Version.Parse(Convert.ToString(value));
        }

		public static string FormatWith(this string format, params object[] args)
		{
            #region Argument exceptions

            if (args == null)
				throw new ArgumentNullException("args");
			if (format == null)
				throw new ArgumentNullException("format");

            #endregion

            return string.Format(format, args);
		}

        public static string EscapeMdxString(this string value)
        {
            if (value == null)
                return null;

            return value.Replace("\"", "\"\"");
        }

        public static string EscapePowershellString(this string value)
        {
            if (value == null)
                return null;

            return value.Replace("\"", "\"\"");
        }

        internal static string ToFormattedTime(this TimeSpan timeSpan)
		{
			if (timeSpan.Days > 0)
				return "{0:%d} d {0:%h} hrs {0:%m} min {0:%s} sec {0:fff} ms".FormatWith(timeSpan);

			if (timeSpan.Hours > 0)
				return "{0:%h} hrs {0:%m} min {0:%s} sec {0:fff} ms".FormatWith(timeSpan);

			if (timeSpan.Minutes > 0)
				return "{0:%m} min {0:%s} sec {0:fff} ms".FormatWith(timeSpan);

			if (timeSpan.Seconds > 0)
				return "{0:%s} sec {0:fff} ms".FormatWith(timeSpan);

			if (timeSpan.Milliseconds > 0)
				return "{0:fff} ms".FormatWith(timeSpan);

			if (timeSpan.TotalMilliseconds > 0D)
				return "{0} µs".FormatWith(timeSpan.TotalMilliseconds * 1000.0);
			
			return "{0}".FormatWith(0);
		}

        internal static TraceEventClass ToEventClass(this string name)
        {
            #region Argument exceptions

            if (name == null)
                throw new ArgumentNullException("name");

            #endregion

            return (TraceEventClass)Enum.Parse(typeof(TraceEventClass), name);
        }

        internal static TraceEventSubclass ToEventSubclass(this string name)
        {
            #region Argument exceptions

            if (name == null)
                throw new ArgumentNullException("name");

            #endregion

            return (TraceEventSubclass)Enum.Parse(typeof(TraceEventSubclass), name);
        }

        internal static string ToName(this TraceEventClass @class)
        {
            return Enum.GetName(typeof(TraceEventClass), @class);
        }

        internal static string ToName(this TraceEventSubclass subclass)
        {
            return Enum.GetName(typeof(TraceEventSubclass), subclass);
        }

        internal static ResultPresenterControl GetResultPresenterControl(this Control control)
        {            
            while (control.Parent != null)
                control = control.Parent;

            var result = control.Controls.Find("ResultPresenterControl", searchAllChildren: true)
                .Cast<Control>().SingleOrDefault() as ResultPresenterControl;

            if (result == null)
                throw new ApplicationException("ResultPresenterControl not found");
            
            return result;
        }

        internal enum ButtonState
        {
            Normal,
            Focused,
            Downed
        }

        #region Flat buttons behavior

        internal static void SetFlatButtonColors(Button button, ButtonState buttonState)
        {
            if (button != null)
            {
                switch (buttonState)
                {
                    case ButtonState.Normal:
                        button.ForeColor = Color.Black;
                        button.BackColor = Color.White;
                        break;
                    case ButtonState.Focused:
                        button.BackColor = Color.White;
                        button.ForeColor = CustomColor.ASQAOrange;
                        break;
                    case ButtonState.Downed:
                        button.BackColor = CustomColor.ASQAOrange;
                        button.ForeColor = Color.White;
                        break;
                }
            }
        }

        public static void OnFlatButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetFlatButtonColors(button, ButtonState.Normal);
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.FlatAppearance.BorderSize = 1;
            }
        }

        public static void OnFlatButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetFlatButtonColors(button, ButtonState.Focused);
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.FlatAppearance.BorderSize = 2;
            }
        }

        public static void OnFlatButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                SetFlatButtonColors(button, ButtonState.Downed);
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
            }
        }

        public static void OnFlatButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                SetFlatButtonColors(button, ButtonState.Normal);
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
            }
        }

        #endregion

        #region Timeline zoom buttons behavior

        internal static void SetFlatTimelineZoomButtonColors(Button button, ButtonState buttonState)
        {
            if (button != null && button.Tag != null)
            {
                switch (buttonState)
                {
                    case ButtonState.Normal:
                        button.ForeColor = Color.Black;
                        button.BackColor = (Color)button.Tag;
                        break;
                    case ButtonState.Focused:
                        button.BackColor = Color.White;
                        button.ForeColor = CustomColor.ASQAOrange;
                        break;
                    case ButtonState.Downed:
                        button.BackColor = CustomColor.ASQAOrange;
                        button.ForeColor = CustomColor.ASQAOrange;
                        break;
                }
            }
        }
        
        public static void OnFlatTimelineZoomButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetFlatTimelineZoomButtonColors(button, ButtonState.Normal);
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.FlatAppearance.BorderSize = 1;
            }
        }

        public static void OnFlatTimelineZoomButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetFlatTimelineZoomButtonColors(button, ButtonState.Focused);
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.FlatAppearance.BorderSize = 2;
            }
        }

        public static void OnFlatTimelineZoomButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                SetFlatTimelineZoomButtonColors(button, ButtonState.Downed);
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
            }
        }

        public static void OnFlatTimelineZoomButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                SetFlatTimelineZoomButtonColors(button, ButtonState.Normal);
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
            }
        }

        #endregion
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
            var tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }
    }
}
