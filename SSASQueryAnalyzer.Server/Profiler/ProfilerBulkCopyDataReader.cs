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

namespace SSASQueryAnalyzer.Server.Profiler
{
    using Microsoft.AnalysisServices;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;

    internal class ProfilerBulkCopyDataReader: BulkCopyDataReader
    {
        private BlockingCollection<List<TraceEventArgs>> _bag = new BlockingCollection<List<TraceEventArgs>>();
        private ProcedureContext _procedureContext;
        private List<TraceEventArgs> _events;
        private int _currentEventId = 0;
        private int _resultCounter = 0;
        private int _currentRead = -1;

        public ProfilerBulkCopyDataReader(ProcedureContext procedureContext)
        {
            _procedureContext = procedureContext;
        }

        protected override string SchemaName
        {
            get
            {
                return "asqa";
            }
        }

        protected override string TableName
        {
            get 
            {
                return "#Trace_{0:N}_{1:N}".FormatWith(_procedureContext.BatchID, _procedureContext.ExecutionID);
            }
        }

        protected override void AddSchemaTableRows()
        {
            AddSchemaTableRow("ID", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: false, providerType: SqlDbType.Int, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("EventClass", columnSize: 128, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.NVarChar, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("EventSubclass", columnSize: 128, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.NVarChar, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("IntegerData", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.BigInt, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("StartTime", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.DateTime, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("CurrentTime", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.DateTime, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("Duration", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.BigInt, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("ObjectName", columnSize: 128, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.NVarChar, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("CpuTime", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.BigInt, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("EndTime", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.DateTime, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("ObjectID", columnSize: 1024, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.NVarChar, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("ObjectPath", columnSize: 1024, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.NVarChar, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("ObjectType", columnSize: 1024, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.NVarChar, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("ObjectReference", columnSize: 1024, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.NVarChar, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("ProgressTotal", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.BigInt, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
            AddSchemaTableRow("TextData", columnSize: null, numericPrecision: null, numericScale: null, isUnique: false, isKey: false, allowDBNull: true, providerType: SqlDbType.NVarChar, udtSchema: null, udtType: null, xmlSchemaCollectionDatabase: null, xmlSchemaCollectionOwningSchema: null, xmlSchemaCollectionName: null);
        }

        public override object GetValue(int i)
        {
            switch (i)
	        {
                case 0:
                    return ++_currentEventId;
                case 1:
                    return Convert.ToString(_events[_currentRead].EventClass);
                case 2:
                    return Convert.ToString(_events[_currentRead].EventSubclass);
                case 3:
                    if (_events[_currentRead][TraceColumn.IntegerData] != null)
                        return _events[_currentRead].IntegerData;
                    return null;
                case 4:
                    if (_events[_currentRead][TraceColumn.StartTime] != null)
                        return _events[_currentRead].StartTime;
                    return null;
                case 5:
                    if (_events[_currentRead][TraceColumn.CurrentTime] != null)
                        return _events[_currentRead].CurrentTime;
                    return null;
                case 6:
                    if (_events[_currentRead][TraceColumn.Duration] != null)
                        return _events[_currentRead].Duration;
                    return null;
                case 7:
                    return _events[_currentRead].ObjectName;
                case 8:
                    if (_events[_currentRead][TraceColumn.CpuTime] != null)
                        return _events[_currentRead].CpuTime;
                    return null;
                case 9:
                    if (_events[_currentRead][TraceColumn.EndTime] != null)
                        return _events[_currentRead].EndTime;
                    return null;
                case 10:
                    return _events[_currentRead].ObjectID;
                case 11:
                    return _events[_currentRead].ObjectPath;
                case 12:
                    if (_events[_currentRead][TraceColumn.ObjectType] == null)
                        return null;
                    if (_events[_currentRead].ObjectType == null)
                    {
                        // HACK
                        if (_events[_currentRead][TraceColumn.ObjectType] == ProfilerCollector.TraceEventObjectTypeAggregationUnmapped)
                            return typeof(Aggregation).AssemblyQualifiedName;
                        return null;
                    }
                    return _events[_currentRead].ObjectType.AssemblyQualifiedName;
                case 13:
                    return _events[_currentRead].ObjectReference;
                case 14:
                    if (_events[_currentRead][TraceColumn.ProgressTotal] != null)
                        return _events[_currentRead].ProgressTotal;
                    return null;
                case 15:
                    return _events[_currentRead].TextData;
		        default:
                    return null;
	        }
        }

        public override bool Read()
        {
            return ++_currentRead < _events.Count;
        }

        public override bool NextResult()
        {
            _currentRead = -1;
            _resultCounter++;
            _events = null;

            if (_procedureContext.IsCancellationRequested)
                return false;

            if (_bag.IsCompleted)
                return false;

            if (_resultCounter % 10 == 0)
                GC.Collect();

            try
            {                
                _events = _bag.Take(_procedureContext.CancellationToken);

                //using (var task = System.Threading.Tasks.Task.Factory.StartNew(() => System.IO.File.AppendAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProcedureContext.SQLiteFolderPath, "queue.log"), "{0:dd/MM/yyyy hh:mm:ss.fff} - {1} - {2}\r\n".FormatWith(DateTime.Now, _procedureContext.ExecutionID, _bag.Count))))
                //    task.Wait();
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (OperationCanceledException)
            {
                return false;
            }

            return true;
        }

        public void Add(List<TraceEventArgs> traces, bool completed)
        {
            _bag.Add(traces);

            if (completed)
                _bag.CompleteAdding();
        }

        public void WriteToServer()
        {
            NextResult();
            
            var createTemporaryTable = @"
CREATE TABLE {0}
(
	[ID] [int] NOT NULL,
	[EventClass] [nvarchar](128) NULL,
	[EventSubclass] [nvarchar](128) NULL,
	[IntegerData] [bigint] NULL,
	[StartTime] [datetime] NULL,
	[CurrentTime] [datetime] NULL,
	[Duration] [bigint] NULL,
	[ObjectName] [nvarchar](128) NULL,
	[CpuTime] [bigint] NULL,
	[EndTime] [datetime] NULL,
	[ObjectID] [nvarchar](1024) NULL,
	[ObjectPath] [nvarchar](1024) NULL,
	[ObjectType] [nvarchar](1024) NULL,
	[ObjectReference] [nvarchar](1024) NULL,
	[ProgressTotal] [bigint] NULL,
	[TextData] [nvarchar](max) NULL
);";

            var selectIntoTable = @"
INSERT INTO [asqa].[Trace]
(
	[ExecutionID],
	[ID],
	[EventClass],
	[EventSubclass],
	[IntegerData],
	[StartTime],
	[CurrentTime],
	[Duration],
	[ObjectName],
	[CpuTime],
	[EndTime],
	[ObjectID],
	[ObjectPath],
	[ObjectType],
	[ObjectReference],
	[ProgressTotal],
	[TextData]
)
SELECT
	CONVERT(UNIQUEIDENTIFIER, '{0:D}'),
	[ID],
	[EventClass],
	[EventSubclass],
	[IntegerData],
	[StartTime],
	[CurrentTime],
	[Duration],
	[ObjectName],
	[CpuTime],
	[EndTime],
	[ObjectID],
	[ObjectPath],
	[ObjectType],
	[ObjectReference],
	[ProgressTotal],
	[TextData]
FROM
	{1};";

            BatchHelper.WriteToSqlite(_procedureContext, this, afterCompleted: (r) =>
                {
                    BatchHelper.WriteToServer(_procedureContext, r, DestinationTableName, 
                        beforeActionCommandText: createTemporaryTable.FormatWith(DestinationTableName),
                        afterActionCommandText: selectIntoTable.FormatWith(_procedureContext.ExecutionID, DestinationTableName)
                        );
                });
        }
    }
}
