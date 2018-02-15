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
    using SSASQueryAnalyzer.Server.Performance;
    using SSASQueryAnalyzer.Server.Profiler;
    using System;
    using System.Data;
    using AdomdClient = Microsoft.AnalysisServices.AdomdClient;

    internal class AnalyzerTaskResult: IDisposable
    {
        private bool _disposed;

        public DataTable QueryResult { get; private set; }
        public ProfilerResult Profiler { get; private set; }
        public PerformanceResult Performance { get; private set; }

        public static AnalyzerTaskResult Create(DataTable queryResult, ProfilerResult profilerResult, PerformanceResult performanceResult)
        {
            #region Argument exceptions

            if (queryResult == null)
                throw new ArgumentNullException("queryResult");
            if (profilerResult == null)
                throw new ArgumentNullException("profilerResult");
            if (performanceResult == null)
                throw new ArgumentNullException("performanceResult");

            #endregion

            return new AnalyzerTaskResult()
            {
                Performance = performanceResult,
                Profiler = profilerResult,
                QueryResult = queryResult
            };
        }

        public static AnalyzerTaskResult CreateForPrepare(ProcedureContext procedureContext)
        {
            #region Argument exceptions

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            return new AnalyzerTaskResult()
            {
                Performance = PerformanceResult.CreateForPrepare(procedureContext),
                Profiler = ProfilerResult.CreateForPrepare(procedureContext),
                QueryResult = default(DataTable)
            };
        }

        private AnalyzerTaskResult()
        {
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
                    if (QueryResult != null)
                        QueryResult.Dispose();

                    QueryResult = null;
                }

                _disposed = true;
            }
        }

        #endregion
    }
}
