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
    using System.Diagnostics;
    using System.Threading;

    internal class ProcedureMutex: IDisposable
	{
		private static readonly Guid MutexGuid = new Guid("22F4C358-7B14-4341-960C-35B99C9B445D");
		private static readonly string MutexName = "Global\\{{{0}}}".FormatWith(MutexGuid);

		private Mutex _mutex;
        private bool _acquired;
        private bool _disposed;

		private ProcedureMutex()
		{
			_mutex = new Mutex(initiallyOwned: false, name: MutexName);

			try
			{
				_acquired = _mutex.WaitOne(TimeSpan.Zero);

				if (!_acquired)
					throw new ApplicationException("Another instance of the procedure is already running");
			}
			catch (AbandonedMutexException)
			{
				_acquired = true;
			}
        }

		public static ProcedureMutex TryAcquire()
		{
			return new ProcedureMutex();
        }

        #region IDisposable

		protected virtual void Dispose(bool disposing)
		{
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_mutex != null)
                    {
                        if (_acquired)
                            _mutex.ReleaseMutex();
                        
                        _mutex.Dispose();
                        _mutex = null;
                    }

                    // HACK
                    EventsNotifier.Instance.Clear();

                    _disposed = true;
                }
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
