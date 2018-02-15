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

namespace SSASQueryAnalyzer.Client.SSMS.VSPackage.Infrastructure
{
    using System;
    using System.IO;
    using System.Net;
    using System.Xml;

    internal static class VersionChecker
    {
        private static string CurrentVersionURL = "https://goo.gl/YXFkM3";

        public static bool? IsNewVersionAvailable;
        public static bool FailedWithException;

        public static Version CurrentVersion;

        public static void CheckForUpdate()
        {
            FailedWithException = false;
            IsNewVersionAvailable = null;
            CurrentVersion = null;
            try
            {
                using (var client = new WebClient())
                {
                    client.Proxy = WebRequest.GetSystemWebProxy();
                    client.Proxy.Credentials = CredentialCache.DefaultCredentials;

                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                    using (var stream = new MemoryStream(client.DownloadData(new Uri(CurrentVersionURL))))
                    {
                        using (var reader = XmlReader.Create(stream))
                        {
                            var document = new XmlDocument();
                            document.Load(reader);

                            var versionText = document.DocumentElement
                                .SelectSingleNode("version")
                                .InnerText;

                            CurrentVersion = Version.Parse(versionText);
                        }
                    }
                }

                IsNewVersionAvailable = AssemblyInfo.AssemblyFileVersion < CurrentVersion;
            }
            catch
            {
                FailedWithException = true;
                throw;
            }
        }
    }
}
