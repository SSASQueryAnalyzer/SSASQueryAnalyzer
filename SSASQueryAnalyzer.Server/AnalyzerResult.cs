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

namespace SSASQueryAnalyzer.Server
{
    using SSASQueryAnalyzer.Server.Infrastructure;
    using SSASQueryAnalyzer.Server.Profiler;
    using System;
    using System.Collections.Concurrent;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    internal class AnalyzerResult: IDisposable
    {
        private ProcedureContext _procedureContext;
        private bool _disposed = false;

        public AnalyzerResult(ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            _procedureContext = procedureContext;
        }
        
        public DataSet CalculateForPrepare()
        {
            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepPrepare);

            var store = Calculate(AnalyzerTaskResult.CreateForPrepare(_procedureContext));
            
            Debug.Assert(store.Tables.Cast<DataTable>()
                .Select(t => t.Rows.Count)
                .Sum() == 0);

            return store;
        }

        public DataSet Calculate(AnalyzerTaskResult analyzerResult)
        {
            #region Argument exceptions

            if (analyzerResult == null)
                throw new ArgumentNullException("analyzerResult");

            #endregion
            
            var store = new DataSet();

            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepCalculateResult);

            store.Tables.Add(_procedureContext.ToExecutionInfoTable());

            switch (_procedureContext.ExecutionMode)
            {
                case ProcedureExecutionMode.Live:
                    var bag = new ConcurrentBag<DataTable>();

                    using (var task = Task.Factory.StartNew(() =>
                    {
                        Task.Factory.StartNew(() => bag.Add(analyzerResult.Profiler.ToEnginePerformanceTable()), TaskCreationOptions.AttachedToParent);
                        Task.Factory.StartNew(() => bag.Add(analyzerResult.Profiler.ToAggregationsReadTable()), TaskCreationOptions.AttachedToParent);
                        Task.Factory.StartNew(() => bag.Add(analyzerResult.Profiler.ToPartitionsReadTable()), TaskCreationOptions.AttachedToParent);
                        Task.Factory.StartNew(() => bag.Add(analyzerResult.Profiler.ToCachesReadTable()), TaskCreationOptions.AttachedToParent);

                        store.Tables.Add(analyzerResult.QueryResult.ToQueryResultTable());
                        foreach (var table in analyzerResult.Performance.ToTables())
                            store.Tables.Add(table);
                        foreach (var table in analyzerResult.Profiler.ToTables())
                            store.Tables.Add(table);
                    }))
                    {
                        task.Wait();
                    }

                    foreach (var table in bag)
                        store.Tables.Add(table);
                    break;
                case ProcedureExecutionMode.Batch:
                    BatchHelper.Calculate(_procedureContext);
                    break;
            }
                                  
            EventsNotifier.Instance.Notify(ProcedureEvents.ProcedureAnalyzeStepSendResult);
            store.Tables.Add(EventsNotifier.Instance.NotifiedEvents.ToProcedureEventTable());

            return store;
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // ..
                }

                _disposed = true;
            }
        }

        #endregion
    }
}
