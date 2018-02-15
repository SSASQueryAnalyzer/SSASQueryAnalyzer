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
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.UI.VSIntegration;
    using Microsoft.SqlServer.Management.UI.VSIntegration.ObjectExplorer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class ObjectExplorerManager
    {
        private static IObjectExplorerService _objectExplorer;
             
        static ObjectExplorerManager()
        {
            _objectExplorer = (IObjectExplorerService)ServiceCache.ServiceProvider.GetService(typeof(IObjectExplorerService));
        }

        private static IEnumerable<IExplorerHierarchy> GetExplorerHierarchies()
        {
            var getTreeMethod = _objectExplorer.GetType().GetProperty("Tree", BindingFlags.Instance | BindingFlags.NonPublic);
            var treeMethodValue = getTreeMethod.GetValue(_objectExplorer, null);

            var getHierarchiesMethod = treeMethodValue.GetType().GetProperty("Hierarchies", BindingFlags.Instance | BindingFlags.NonPublic);
            var hierarchiesMethodValue = getHierarchiesMethod.GetValue(treeMethodValue, null);

            foreach (var explorerHerarchy in (Dictionary<string, IExplorerHierarchy>)hierarchiesMethodValue)
                yield return explorerHerarchy.Value;
        }

        //public static UIConnectionInfo CurrentlyActiveConnection()
        //{
        //    return ServiceCache.ScriptFactory.CurrentlyActiveWndConnectionInfo.UIConnectionInfo;
        //}

        public static IEnumerable<SqlOlapConnectionInfoBase> GetServerConnections()
        {
            foreach (var explorerrHerarchy in GetExplorerHierarchies())
            {
                if (explorerrHerarchy.Root is IServiceProvider provider)
                    yield return (provider.GetService(typeof(INodeInformation)) as INodeInformation).Connection;
            }
        }

        public static OlapConnectionInfo[] GetOlapServerConnections()
        {
            return GetServerConnections().OfType<OlapConnectionInfo>().ToArray();
        }

        public static SqlConnectionInfo[] GetSqlServerConnections()
        {
            return GetServerConnections().OfType<SqlConnectionInfo>().ToArray();
        }

        public static Tuple<string, SqlConnectionInfo, ServerConnection>[] GetSqlServerConnectionsExtended()
        {
            return GetSqlServerConnections().Select((c) => Tuple.Create(c.ServerName, c, new ServerConnection(c))).ToArray();
        }
    }
}
