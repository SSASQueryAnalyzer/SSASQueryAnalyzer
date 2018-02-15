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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure.Server
{
    using System;

    public class EnginePerformance
    {
        public TimeSpan QueryDuration { get; private set; }
        public TimeSpan FormulaEngineDuration { get; private set; }
        public TimeSpan StorageEngineDuration { get; private set; }
        public int QuerySubcubeExecutionsCacheData { get; private set; }
        public int QuerySubcubeExecutionsNonCacheData { get; private set; }
        public int CachesRead { get; private set; }
        public int PartitionsRead { get; private set; }
        public int PartitionsHit { get; private set; }
        public TimeSpan PartitionsDuration { get; private set; }
        public int AggregationsRead { get; private set; }
        public int AggregationsHit { get; private set; }
        public TimeSpan AggregationsDuration { get; private set; }
        public int ResourceUsageReads { get; private set; }
        public long ResourceUsageReadKB { get; private set; }
        public int ResourceUsageWrites { get; private set; }
        public long ResourceUsageWriteKB { get; private set; }
        public long ResourceUsageCpuTimeMS { get; private set; }
        public int ResourceUsageRowsScanned { get; private set; }
        public int ResourceUsageRowsReturned { get; private set; }
    }
}
