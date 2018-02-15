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

namespace SSASQueryAnalyzer.Server.Performance
{
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Diagnostics;

    internal static class Extension
    {
        public static string ToNamespace(this PerformanceCounter counter)
        {
            #region Argument exception

            if (counter == null)
                throw new ArgumentNullException("counter");

            #endregion

            return "{0}.{1}".FormatWith(PerformanceResult.Namespace, counter.CategoryName);
        }

        public static DataTable ToDataTable(this PerformanceCounter counter)
        {
            #region Argument exception

            if (counter == null)
                throw new ArgumentNullException("counter");

            #endregion

            var table = new DataTable(counter.CounterName, counter.ToNamespace());
            {
                table.Columns.Add("TraceEventTime", typeof(DateTime));
                table.Columns.Add("Value", typeof(long));
            }

            return table;
        }

        public static IEnumerable<DataTable> ToDataTables(this IList<PerformanceAggregate> aggregates, bool executeForPrepare)
        {
            var performanceTables = aggregates
#if !DEBUG
                .AsParallel().WithDegreeOfParallelism(aggregates.Count)
#endif
                .Select((p) =>
                {
                    var counterTable = p.Counter.ToDataTable();

                    if (executeForPrepare)
                        return counterTable;

                    foreach (var item in p.Values)
                        counterTable.Rows.Add(item.TraceEventTime, item.Value);

                    return counterTable;
                });

            return performanceTables;
        }
	}
}
