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
    using System.Linq;
    using System.Management;

    internal class PInvokeHelper
    {
        /// <summary>
        /// Retrieves the amount of RAM in Kb that is physically installed on the computer
        /// </summary>
        public static long GetPhysicalSystemMemory()
        {
            //[DllImport("kernel32.dll", SetLastError = true)]
            //[return: MarshalAs(UnmanagedType.Bool)]
            //static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

            //if (!GetPhysicallyInstalledSystemMemory(out long totalMemoryInKilobytes))
            //    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());

            var info = new Microsoft.VisualBasic.Devices.ComputerInfo();

            return (long)(info.TotalPhysicalMemory / 1024);
        }

        public static string GetOperatingSystemName()
        {
            using(var wmi = new ManagementObjectSearcher("SELECT Caption, Version FROM Win32_OperatingSystem"))
            {
                var managementObject = wmi.Get().Cast<ManagementObject>().FirstOrDefault();
                if (managementObject == null)
                    return null;

                return "{0} ({1})".FormatWith(managementObject.GetPropertyValue("Caption"), managementObject.GetPropertyValue("Version"));                    
            }
        }
    }
}
