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
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    internal static class AssemblyResolverHelper
    {
        public static Assembly Resolve(object sender, ResolveEventArgs args)
        {
            if (args.Name == "System.Data.SQLite, Version=1.0.105.2, Culture=neutral, PublicKeyToken=db937bc2d44ff139")                
                return ResolveSQLite();

            return null;
        }

        private static Assembly ResolveSQLite()
        {           
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SSASQueryAnalyzer.Server.Resources.System.Data.SQLite.dll"))
            {
                var length = (int)stream.Length;
                var buffer = new byte[length];
                stream.Read(buffer, 0, length);

                return Assembly.Load(buffer);
            }
        }
    }
}
