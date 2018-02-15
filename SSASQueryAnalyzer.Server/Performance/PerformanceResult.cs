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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://www.andygup.net/a-better-way-to-measure-cpu-using-windows-performancecounter-and-c/"/>
    internal class PerformanceResult
    {
        public const string Namespace = "Performance";
        private static readonly object _sync = new object();

        private ConcurrentBag<PerformanceAggregate> _performancesBag = new ConcurrentBag<PerformanceAggregate>();
        private List<PerformanceAggregate> _performances = new List<PerformanceAggregate>();
        private ProcedureContext _procedureContext;
        private int _collectCount = 0;

        public static PerformanceResult Create(ProcedureContext procedureContext)
        {
            return new PerformanceResult(procedureContext, counters: PerformanceCollector.ActivePerformanceCounters(procedureContext));
        }

        public static PerformanceResult CreateForPrepare(ProcedureContext procedureContext)
        {
            return new PerformanceResult(procedureContext, counters: Enumerable.Empty<PerformanceCounter>());
        }

        private PerformanceResult(ProcedureContext procedureContext, IEnumerable<PerformanceCounter> counters)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            if (counters == null)
                throw new ArgumentNullException("counters");

            #endregion

            _procedureContext = procedureContext;

            foreach (var item in counters)
                _performances.Add(PerformanceAggregate.Create(item));
        }

#if !DEBUG
        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        public void Collect(DateTime eventTime)
        {
            lock (_performances)
            {
                Parallel.ForEach(_performances, (p) => p.Values.Add(eventTime, p.Counter.NextValue()));
            }

            if (++_collectCount >= BatchHelper.BulkCopyBatchSize)
            {
                _collectCount = 0;

                if (_procedureContext.ExecutionMode == ProcedureExecutionMode.Batch)
                    FlushBatch(TimeSpan.Zero);
            }
        }

        public Task FlushBatch(TimeSpan timeout)
        {
            Debug.Assert(_procedureContext.ExecuteForPrepare == false);
            Debug.Assert(_procedureContext.ExecutionMode == ProcedureExecutionMode.Batch);

            lock (_performances)
            {
                foreach (var item in _performances)
                    _performancesBag.Add(PerformanceAggregate.CloneForSwitch(item));
            }

            return Task.Factory.StartNew(() =>
            {
                if (Monitor.TryEnter(_sync, timeout))
                {
                    try
                    {
                        var aggregateCollection = new List<PerformanceAggregate>();

                        PerformanceAggregate aggregate;
                        while (_performancesBag.TryTake(out aggregate))
                            aggregateCollection.Add(aggregate);

                        aggregateCollection.WriteToServer(_procedureContext);
                    }
                    finally
                    {
                        Monitor.Exit(_sync);
                    }
                }
            },
            _procedureContext.CancellationToken, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
        }

        public IEnumerable<DataTable> ToTables()
        {
            return _performances.ToDataTables(_procedureContext.ExecuteForPrepare);
        }
    }
}
