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
    using System;
    using System.Diagnostics;

    internal class PerformanceAggregate
    {
        public PerformanceCounter Counter { get; private set; }
        public PerformanceItemCollection Values { get; set; }

        public static PerformanceAggregate Create(PerformanceCounter counter)
        {
            return new PerformanceAggregate(counter, values: PerformanceItemCollection.CreateAndInitialize(counter.NextValue()));
        }

        public static PerformanceAggregate CloneForSwitch(PerformanceAggregate aggregate)
        {
            var result = new PerformanceAggregate(aggregate.Counter, aggregate.Values);
            {
                aggregate.Values = PerformanceItemCollection.CloneAndInitialize(aggregate.Counter.NextValue(), aggregate.Values.LastValue);
            }

            return result;
        }

        private PerformanceAggregate(PerformanceCounter counter, PerformanceItemCollection values)
        {
            Counter = counter;
            Values = values;
        }
    }
}
