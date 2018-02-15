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

namespace SSASQueryAnalyzer.Server.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO.MemoryMappedFiles;
    using System.Linq;

    internal class EventsNotifier: IDisposable
    {
        private static readonly EventsNotifier _instance = new EventsNotifier();
        
        private readonly long _size = sizeof(ProcedureEvents);
        private readonly string _name = "248B3109-54AB-49CA-BA32-2FA9989769AB";
        private IDictionary<ProcedureEvents, DateTime> _notified;
        private MemoryMappedFile _memoryMappedFile;
        private bool _disposed;

        public static EventsNotifier Instance
        {
            get
            {
                return _instance;
            }
        }

        private EventsNotifier()
        {
            _memoryMappedFile = MemoryMappedFile.CreateOrOpen(_name, _size);
            _notified = new Dictionary<ProcedureEvents, DateTime>();
        }

        public void Notify(ProcedureEvents @event)
        {
            _notified.Add(@event, DateTime.UtcNow);

            using (var accessor = _memoryMappedFile.CreateViewAccessor(0, _size, MemoryMappedFileAccess.Write))
                accessor.Write<ProcedureEvents>(0, ref @event);
        }

        public void Clear()
        {
            _notified.Clear();
        }

        public ProcedureEvents LastNotifiedEvent
        {
            get
            {
                ProcedureEvents @event;

                using (var accessor = _memoryMappedFile.CreateViewAccessor(0, _size, MemoryMappedFileAccess.Read))
                    accessor.Read<ProcedureEvents>(0, out @event);

                return @event;
            }
        }

        public IDictionary<ProcedureEvents, DateTime> NotifiedEvents
        {
            get
            {
                return _notified.ToDictionary((s) => s.Key, (s) => s.Value);
            }
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_memoryMappedFile != null)
                    {
                        _memoryMappedFile.Dispose();
                        _memoryMappedFile = null;
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
