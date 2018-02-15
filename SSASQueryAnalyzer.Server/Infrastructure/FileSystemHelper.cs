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
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Security.Principal;

    /// <summary>
    /// Code from ASStoredProcedures - FileSystemCache.cs
    /// </summary>
    /// <see cref="http://www.codeplex.com/Wiki/View.aspx?ProjectName=ASStoredProcedures"/>
    /// <seealso cref="https://asstoredprocedures.codeplex.com/wikipage?title=FileSystemCache"/>
    internal static class FileSystemHelper
    {
        #region ClearFileSystemCache

        public static void ClearFileSystemCache()
        {
            ClearFileSystemCache(clearStandbyCache: true); //clear the standby cache by default since this must be done to really test cold cache performance
        }

        /// <summary>
        /// Clear the active file system cache
        /// </summary>
        public static void ClearFileSystemCache(bool clearStandbyCache)
        {
            SetIncreasePrivilege(SE_INCREASE_QUOTA_NAME);

            int result;

            if (!Is64BitMode())
            {
                var info = new SYSTEM_CACHE_INFORMATION
                {
                    MinimumWorkingSet = uint.MaxValue, //means to clear the active file system cache
                    MaximumWorkingSet = uint.MaxValue //means to clear the active file system cache
                };
                int iSize = Marshal.SizeOf(info);

                var gch = GCHandle.Alloc(info, GCHandleType.Pinned);
                try
                {
                    result = NtSetSystemInformation(SYSTEMCACHEINFORMATION, gch.AddrOfPinnedObject(), iSize);
                }
                finally
                {
                    gch.Free();
                }
            }
            else
            {
                var info = new SYSTEM_CACHE_INFORMATION_64_BIT
                {
                    MinimumWorkingSet = -1, //means to clear the active file system cache
                    MaximumWorkingSet = -1 //means to clear the active file system cache
                };
                int iSize = Marshal.SizeOf(info);

                var gch = GCHandle.Alloc(info, GCHandleType.Pinned);
                try
                {
                    result = NtSetSystemInformation(SYSTEMCACHEINFORMATION, gch.AddrOfPinnedObject(), iSize);
                }
                finally
                {
                    gch.Free();
                }
            }

            if (result != 0)
                throw new ApplicationException("NtSetSystemInformation(SYSTEMCACHEINFORMATION) error", new Win32Exception(Marshal.GetLastWin32Error()));

            if (clearStandbyCache)
            {
                try
                {
                    SetIncreasePrivilege(SE_PROFILE_SINGLE_PROCESS_NAME);

                    int iSize = Marshal.SizeOf(ClearStandbyPageList);
                    var gch = GCHandle.Alloc(ClearStandbyPageList, GCHandleType.Pinned);
                    try
                    {
                        result = NtSetSystemInformation(SYSTEMMEMORYLISTINFORMATION, gch.AddrOfPinnedObject(), iSize);
                    }
                    finally
                    {
                        gch.Free();
                    }

                    if (result != 0)
                        throw new ApplicationException("NtSetSystemInformation(SYSTEMMEMORYLISTINFORMATION) error", new Win32Exception(Marshal.GetLastWin32Error()));
                }
                catch
                {
                    //this is a fallback if the API call doesn't work on an older OS
                    ClearStandbyFileSystemCacheByConsumingAvailableMemory();
                }
            }
        }

        #endregion

        #region ClearStandbyFileSystemCacheByConsumingAvailableMemory

        /// <summary>
        /// Consume all available memory then free it, which will wipe out the standby cache.
        /// </summary>
        private static void ClearStandbyFileSystemCacheByConsumingAvailableMemory()
        {
            //get the page size. will need to write at least one byte per page to make sure that page is committed to 
            //this process working set: http://blogs.msdn.com/b/ntdebugging/archive/2007/11/27/too-much-cache.aspx?CommentPosted=true&PageIndex=2#comments
            var sysinfo = new SYSTEM_INFO();
            GetSystemInfo(ref sysinfo);

            PerformanceCounter pcAvailableBytes = null;
            long lngAvailableBytes = 0;

            pcAvailableBytes = new PerformanceCounter("Memory", "Available Bytes", readOnly: true);
            lngAvailableBytes = (long)pcAvailableBytes.NextValue();

            long lngRemainingBytes = lngAvailableBytes - (1024 * 1024); //take up all available memory minus 1MB
            var listPtrMem = new List<IntPtr>();
            try
            {
                while (lngRemainingBytes > 0)
                {
                    //figure out the next allocation size
                    int iAllocLen = (int)Math.Min((long)(sysinfo.dwPageSize * 1024), lngRemainingBytes);
                    lngRemainingBytes -= iAllocLen;

                    //allocate this memory
                    listPtrMem.Add(Marshal.AllocHGlobal(iAllocLen));

                    //write one byte per page which is the minimum necessary to make sure this page gets committed to this process' working set
                    for (int j = 0; j < iAllocLen; j += (int)sysinfo.dwPageSize)
                        Marshal.WriteByte(listPtrMem[listPtrMem.Count - 1], j, (byte)1);
                }

                lngAvailableBytes = (long)pcAvailableBytes.NextValue();
            }
            catch (OutOfMemoryException ex)
            {
                throw new ApplicationException("ClearStandbyFileSystemCacheByConsumingAvailableMemory() raise OutOfMemoryException", ex);
            }
            finally
            {
                // dont forget to free up the memory. 
                foreach (IntPtr ptrMem in listPtrMem)
                {
                    if (ptrMem != IntPtr.Zero)
                        Marshal.FreeHGlobal(ptrMem);
                }
            }

            lngAvailableBytes = (long)pcAvailableBytes.NextValue();
        }

        #endregion

        #region Windows APIs

        private static bool Is64BitMode()
        {
            return Marshal.SizeOf(typeof(IntPtr)) == 8;
        }

        [DllImport("NTDLL.dll", SetLastError = true)]
        internal static extern int NtSetSystemInformation(int SystemInformationClass, IntPtr SystemInfo, int SystemInfoLength);

        //SystemInformationClass values
        private static int SYSTEMCACHEINFORMATION = 0x15;
        private static int SYSTEMMEMORYLISTINFORMATION = 80;

        //SystemInfo values
        private static int ClearStandbyPageList = 4;

#pragma warning disable 649 //disable the "is never assigned to" warning
        private struct SYSTEM_CACHE_INFORMATION
        {
            public uint CurrentSize;
            public uint PeakSize;
            public uint PageFaultCount;
            public uint MinimumWorkingSet;
            public uint MaximumWorkingSet;
            public uint Unused1;
            public uint Unused2;
            public uint Unused3;
            public uint Unused4;
        }

        private struct SYSTEM_CACHE_INFORMATION_64_BIT
        {
            public long CurrentSize;
            public long PeakSize;
            public long PageFaultCount;
            public long MinimumWorkingSet;
            public long MaximumWorkingSet;
            public long Unused1;
            public long Unused2;
            public long Unused3;
            public long Unused4;
        }
#pragma warning restore 649 //reenable the warning

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr hObject);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        private const int SE_PRIVILEGE_ENABLED = 0x00000002;
        private const int TOKEN_QUERY = 0x00000008;
        private const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        private const string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";
        private const string SE_PROFILE_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";

        private static bool SetIncreasePrivilege(string privilegeName)
        {
            try
            {
                using (var currentIdentity = WindowsIdentity.GetCurrent(TokenAccessLevels.AdjustPrivileges | TokenAccessLevels.Query))
                {
                    TokPriv1Luid tp;
                    tp.Count = 1;
                    tp.Luid = 0;
                    tp.Attr = SE_PRIVILEGE_ENABLED;

                    var success = LookupPrivilegeValue(null, privilegeName, ref tp.Luid);
                    if (!success)
                        throw new ApplicationException("Error in LookupPrivilegeValue: ", new Win32Exception(Marshal.GetLastWin32Error()));

                    success = AdjustTokenPrivileges(currentIdentity.Token, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
                    if (!success)
                        throw new ApplicationException("Error in AdjustTokenPrivileges: ", new Win32Exception(Marshal.GetLastWin32Error()));

                    return success;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in SetIncreasePrivilege(" + privilegeName + "):", ex);
            }
        }

        [DllImport("kernel32.dll")]
        private static extern void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO lpSystemInfo);

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEM_INFO
        {
            internal _PROCESSOR_INFO_UNION uProcessorInfo;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort dwProcessorLevel;
            public ushort dwProcessorRevision;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct _PROCESSOR_INFO_UNION
        {
            [FieldOffset(0)]
            internal uint dwOemId;
            [FieldOffset(0)]
            internal ushort wProcessorArchitecture;
            [FieldOffset(2)]
            internal ushort wReserved;
        }

        #endregion
    }
}
