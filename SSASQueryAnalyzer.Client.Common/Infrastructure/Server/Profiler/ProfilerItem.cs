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

    public class ProfilerItem
    {
        public int ID { get; private set; }
        public string ConnectionID { get; private set; }
        public long? CpuTime { get; private set; }
        public DateTime? CurrentTime { get; private set; }
        public string DatabaseName { get; private set; }
        public long? Duration { get; private set; }
        public DateTime? EndTime { get; private set; }
        public TraceEventClass? EventClass { get; private set; }
        public TraceEventSubclass? EventSubclass { get; private set; }
        public long? IntegerData { get; private set; }
        public string ObjectID { get; private set; }
        public string ObjectName { get; private set; }
        public string ObjectPath { get; private set; }
        public string ObjectReference { get; private set; }
        public Type ObjectType { get; private set; }
        public long? ProgressTotal { get; private set; }
        public DateTime? StartTime { get; private set; }
        public string TextData { get; private set; }
        //public XmlaMessageCollection XmlaMessages { get; private set; }

        //public string this[TraceColumn column] { get; set; }
    }
}
