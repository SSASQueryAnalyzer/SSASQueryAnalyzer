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
    using System.Linq;

    public class ProfilerItemCollectionList : List<ProfilerItemCollection>
    {
        private static readonly string Namespace = "Profiler";
        
        public IEnumerable<TraceEventClass> EventClasses
        {
            get
            {
                return this.SelectMany((p) => p)
                    .Where((i) => i.EventClass.HasValue)
                    .Select((i) => i.EventClass.Value)
                    .Distinct();
            }
        }

        public IEnumerable<TraceEventSubclass> EventSubclasses
        {
            get
            {
                return this.SelectMany((p) => p)
                    .Where((i) => i.EventSubclass.HasValue)
                    .Select((i) => i.EventSubclass.Value)
                    .Distinct();
            }
        }

        public static ProfilerItemCollectionList CreateFromDataSet(DataSet dataset)
        {
            #region Argument exception

            if (dataset == null)
                throw new ArgumentNullException("dataset");

            #endregion

            var profilerList = new ProfilerItemCollectionList();

            profilerList.AddRange(dataset.Tables.Cast<DataTable>().AsParallel()
                .Where((t) => t.Namespace.StartsWith(Namespace))
                .Select((t) => ProfilerItemCollection.CreateFromDataTable(t))
                .ToArray());

            return profilerList;
        }
    }
}
