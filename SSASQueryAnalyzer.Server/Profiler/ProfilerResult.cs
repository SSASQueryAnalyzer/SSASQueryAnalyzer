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

namespace SSASQueryAnalyzer.Server.Profiler
{
    using Microsoft.AnalysisServices;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ProfilerResult
    {
        public const string Namespace = "Profiler";

        public static readonly Type ItemsType = typeof(TraceEventArgs);
        private static readonly object _sync = new object();

        private List<TraceEventArgs> _traces = new List<TraceEventArgs>();
        private ProfilerBulkCopyDataReader _bulkCopy;
        private CollectorsSynchronizer _synchronizer;
        private ProcedureContext _procedureContext;
        private Task _bulkCopyTask;
        private int _collectCount = 0;
        private int _eventId = 0;

        public List<TraceEventArgs> Values
        {
            get
            {
                return (List<TraceEventArgs>)_traces;
            }
        }

        public bool ExecuteForPrepare { get; private set; }

        public readonly ManualResetEvent CollectCompleted = new ManualResetEvent(false);

        public static ProfilerResult Create(ProcedureContext procedureContext, CollectorsSynchronizer synchronizer)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            if (synchronizer == null)
                throw new ArgumentNullException("synchronizer");

            #endregion

            return new ProfilerResult(procedureContext, synchronizer);
        }

        public static ProfilerResult CreateForPrepare(ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            return new ProfilerResult(procedureContext, synchronizer: null) 
                { 
                    ExecuteForPrepare = true 
                };
        }

        private ProfilerResult(ProcedureContext procedureContext, CollectorsSynchronizer synchronizer)
        {
            _procedureContext = procedureContext;
            _synchronizer = synchronizer;

            _bulkCopy = new ProfilerBulkCopyDataReader(_procedureContext);
        }

        public void Add(TraceEventArgs e)
        {
            if (_procedureContext.ExecutionMode == ProcedureExecutionMode.Live)
                if (_procedureContext.TraceEventsThreshold > 0 && _traces.Count >= _procedureContext.TraceEventsThreshold)
                    throw new ApplicationException("The maximum number of trace events [{0}] has been reached.{1}Please raise the value of the 'Events number threshold' parameter or execute ASQA Batch Mode analysis.".FormatWith(_procedureContext.TraceEventsThreshold, Environment.NewLine));

            lock (_traces)
            {
                _traces.Add(e);
            }

            _synchronizer.Add(e.CurrentTime);

            if (++_collectCount >= BatchHelper.BulkCopyBatchSize)
            {
                _collectCount = 0;

                if (_procedureContext.ExecutionMode == ProcedureExecutionMode.Batch)
                    FlushBatch();
            }

            if (e.EventClass == TraceEventClass.ResourceUsage)
                CollectCompleted.Set();
        }

        public void FlushBatch(bool completion = false)
        {
            Debug.Assert(_procedureContext.ExecutionMode == ProcedureExecutionMode.Batch);

            lock (_traces)
            {
                _bulkCopy.Add(_traces, completion);
                _traces = new List<TraceEventArgs>();
            }

            _bulkCopyTask = _bulkCopyTask ?? Task.Factory.StartNew(() => _bulkCopy.WriteToServer(), _procedureContext.CancellationToken, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);

            if (completion)
                _bulkCopyTask.Wait();
        }

        public IEnumerable<DataTable> ToTables()
        {
            return _traces.ToDataTables(_procedureContext.CurrentTraceEvents, _procedureContext.ExecuteForPrepare, ref _eventId);
        }
    }
}
