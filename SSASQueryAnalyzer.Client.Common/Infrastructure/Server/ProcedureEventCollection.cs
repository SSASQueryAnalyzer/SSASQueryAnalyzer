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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure.Server
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using SSASQueryAnalyzer.Server.Infrastructure;

    public class ProcedureEventCollection : List<ProcedureEvent>
    {
        public static readonly string TableName = "ProcedureEvent";

        private ProcedureEventCollection(DataTable table)
        {
            if (table == null)
                return;

            Func<DataColumn, Type> mappingCustomTypes = (column) =>
            {
                switch (column.ColumnName)
                {
                    case "Event":
                        return typeof(SSASQueryAnalyzer.Server.Infrastructure.ProcedureEvents);
                    default:
                        return column.DataType;
                }
            };
            
            AddRange(table.To<ProcedureEvent>(mappingCustomTypes));
        }

        public ProcedureEvent this[ProcedureEvents @event] 
        { 
            get
            {
                return this.Where((e) => e.Event == @event).FirstOrDefault();
            }
        }

        public static ProcedureEventCollection CreateFromDataSet(DataSet dataset)
        {
            #region Argument exception

            if (dataset == null)
                throw new ArgumentNullException("dataset");

            #endregion

            return new ProcedureEventCollection(dataset.Tables[TableName, "Common"]);
        }
    }
}
