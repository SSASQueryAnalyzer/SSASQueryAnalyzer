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
    using System.Collections.Generic;
    using System.Diagnostics;

    internal sealed class PerformanceItemCollection : List<PerformanceItem>
    {
        private float _init;
        private float? _last;

        public float? LastValue
        {
            get
            {
                return _last;
            }
        }

        public static PerformanceItemCollection CreateAndInitialize(float init)
        {
            return new PerformanceItemCollection(init, last: null);
        }

        public static PerformanceItemCollection CloneAndInitialize(float init, float? last)
        {
            return new PerformanceItemCollection(init, last);
        }

        private PerformanceItemCollection(float init, float? last = null)
        {
            _init = init;
            _last = last;
        }

        public void Add(DateTime traceEventTime, float value)
        {
            if (!_last.HasValue || _last.Value != value)
            {
                _last = value;

                base.Add(item: new PerformanceItem(traceEventTime, value - _init));
            }
        }

        new public void Add(PerformanceItem item)
        {
            throw new NotImplementedException();
        }

        new public void AddRange(IEnumerable<PerformanceItem> collection)
        {
            throw new NotImplementedException();
        }
    }
}
