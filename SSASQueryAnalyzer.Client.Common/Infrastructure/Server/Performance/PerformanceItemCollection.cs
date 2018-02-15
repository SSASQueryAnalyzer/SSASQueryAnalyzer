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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure.Server.Performance
{
	using System;
	using System.Collections.Generic;
	using System.Data;

	public class PerformanceItemCollection : List<PerformanceItem>
	{
		public string Name { get; private set; }
		public string Category { get; private set; }

		public string FullName
		{
			get
			{
				return "{0} : {1}".FormatWith(Category, Name);
			}
		}

		private PerformanceItemCollection(DataTable table)
		{
            AddRange(table.To<PerformanceItem>());
		}

		public static PerformanceItemCollection CreateFromDataTable(DataTable table, string category = null, string name = null)
		{
            #region Argument exception

            if (table == null)
				throw new ArgumentNullException("table");

            #endregion

            var collection = new PerformanceItemCollection(table);

            collection.Name = name ?? table.TableName;
            collection.Category = category ?? table.Namespace.Substring(table.Namespace.IndexOf(':') + 1);

            return collection;

        }
	}
}
