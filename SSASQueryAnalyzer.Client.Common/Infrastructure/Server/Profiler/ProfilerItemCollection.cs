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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure.Server.Profiler
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ProfilerItemCollection : List<ProfilerItem>
    {
        public TraceEventClass EventClass { get; private set; }
        public string EventClassName { get; private set; }

        private ProfilerItemCollection(DataTable table)
        {
            Func<DataColumn, Type> mappingCustomTypes = (column) =>
			{
                switch (column.ColumnName)
				{
					case "EventClass" :
						return typeof(SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices.TraceEventClass);
					case "EventSubclass" :
                        return typeof(SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices.TraceEventSubclass);
                    case "ObjectType":
                        return typeof(Type);
					default:
                        return column.DataType;
				}
			};

            AddRange(table.To<ProfilerItem>(mappingCustomTypes));
        }

        public static ProfilerItemCollection CreateFromDataTable(DataTable table, string eventClassName = null)
        {
            #region Argument exception

            if (table == null)
                throw new ArgumentNullException("table");

            #endregion
            
            var collection = new ProfilerItemCollection(table);

            collection.EventClassName = eventClassName ?? table.TableName;
            collection.EventClass = collection.EventClassName.ToEventClass();

            return collection;
        }
    }
}
