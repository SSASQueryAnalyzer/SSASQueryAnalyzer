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
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Globalization;

    internal abstract class BulkCopyDataReader: IDataReader
    {
        #region Consts

        private const string IsIdentitySchemaColumn = "IsIdentity";
        private const string DataTypeNameSchemaColumn = "DataTypeName";
        private const string XmlSchemaCollectionDatabaseSchemaColumn = "XmlSchemaCollectionDatabase";
        private const string XmlSchemaCollectionOwningSchemaSchemaColumn = "XmlSchemaCollectionOwningSchema";
        private const string XmlSchemaCollectionNameSchemaColumn = "XmlSchemaCollectionName";

        private static readonly Dictionary<SqlDbType, List<string>> AllowedOptionalColumnCombinations = new Dictionary<SqlDbType, List<string>>
        {
            { SqlDbType.BigInt, new List<string> { } },
            { SqlDbType.Binary, new List<string> { SchemaTableColumn.ColumnSize } },
            { SqlDbType.Bit, new List<string> { } },
            { SqlDbType.Char, new List<string> { SchemaTableColumn.ColumnSize } },
            { SqlDbType.Date, new List<string> { } },
            { SqlDbType.DateTime, new List<string> { } },
            { SqlDbType.DateTime2, new List<string> { SchemaTableColumn.NumericPrecision } },
            { SqlDbType.DateTimeOffset, new List<string> { SchemaTableColumn.NumericPrecision } },
            { SqlDbType.Decimal, new List<string> { SchemaTableColumn.NumericPrecision, SchemaTableColumn.NumericScale } },
            { SqlDbType.Float, new List<string> { SchemaTableColumn.NumericPrecision, SchemaTableColumn.NumericScale } },
            { SqlDbType.Image, new List<string> { } },
            { SqlDbType.Int, new List<string> { } },
            { SqlDbType.Money, new List<string> { } },
            { SqlDbType.NChar, new List<string> { SchemaTableColumn.ColumnSize } },
            { SqlDbType.NText, new List<string> { } },
            { SqlDbType.NVarChar, new List<string> { SchemaTableColumn.ColumnSize } },
            { SqlDbType.Real, new List<string> { } },
            { SqlDbType.SmallDateTime, new List<string> { } },
            { SqlDbType.SmallInt, new List<string> { } },
            { SqlDbType.SmallMoney, new List<string> { } },
            { SqlDbType.Structured, new List<string> { } },
            { SqlDbType.Text, new List<string> { } },
            { SqlDbType.Time, new List<string> { SchemaTableColumn.NumericPrecision } },
            { SqlDbType.Timestamp, new List<string> { } },
            { SqlDbType.TinyInt, new List<string> { } },
            { SqlDbType.Udt, new List<string> { BulkCopyDataReader.DataTypeNameSchemaColumn } },
            { SqlDbType.UniqueIdentifier, new List<string> { } },
            { SqlDbType.VarBinary, new List<string> { SchemaTableColumn.ColumnSize } },
            { SqlDbType.VarChar, new List<string> { SchemaTableColumn.ColumnSize } },
            { SqlDbType.Variant, new List<string> { } },
            { SqlDbType.Xml, new List<string> { BulkCopyDataReader.XmlSchemaCollectionDatabaseSchemaColumn, BulkCopyDataReader.XmlSchemaCollectionOwningSchemaSchemaColumn, BulkCopyDataReader.XmlSchemaCollectionNameSchemaColumn } }
        };

        #endregion

        #region Fields

        private bool _open = true;
        private bool _disposed = false;
        private DataTable _schemaTable = new DataTable();
        private List<SqlBulkCopyColumnMapping> _columnMapping = new List<SqlBulkCopyColumnMapping>();

        #endregion

        public ReadOnlyCollection<SqlBulkCopyColumnMapping> ColumnMappings
        {
            get
            {
                if (_columnMapping.Count == 0)
                {
                    AddSchemaTableRows();

                    if (_columnMapping.Count == 0)
                        throw new InvalidOperationException("AddSchemaTableRows did not add rows.");
                }

                return new ReadOnlyCollection<SqlBulkCopyColumnMapping>(_columnMapping);
            }
        }

        public string DestinationTableName
        {
            get
            {
                using (var builder = new SqlCommandBuilder())
                    return builder.QuoteIdentifier(SchemaName) + "." + builder.QuoteIdentifier(TableName);
            }
        }

        protected abstract string SchemaName { get; }

        protected abstract string TableName { get; }

        protected abstract void AddSchemaTableRows();

        public abstract bool NextResult();

        public abstract bool Read();

        protected void AddSchemaTableRow(string columnName, int? columnSize, short? numericPrecision, short? numericScale, bool isUnique, bool isKey, bool allowDBNull, SqlDbType providerType, string    udtSchema, string    udtType, string    xmlSchemaCollectionDatabase, string    xmlSchemaCollectionOwningSchema, string    xmlSchemaCollectionName)
        {
            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentException("columnName must be a nonempty string.");
            else if (columnSize.HasValue && columnSize.Value <= 0)
                throw new ArgumentOutOfRangeException("columnSize");
            else if (numericPrecision.HasValue && numericPrecision.Value <= 0)
                throw new ArgumentOutOfRangeException("numericPrecision");
            else  if (numericScale.HasValue && numericScale.Value < 0)
                throw new ArgumentOutOfRangeException("columnSize");

            List<string> allowedOptionalColumnList;

            if (BulkCopyDataReader.AllowedOptionalColumnCombinations.TryGetValue(providerType, out allowedOptionalColumnList))
            {
                if ((columnSize.HasValue && !allowedOptionalColumnList.Contains(SchemaTableColumn.ColumnSize)) ||
                    (numericPrecision.HasValue && !allowedOptionalColumnList.Contains(SchemaTableColumn.NumericPrecision)) ||
                    (numericScale.HasValue && !allowedOptionalColumnList.Contains(SchemaTableColumn.NumericScale)) ||
                    (udtSchema != null && !allowedOptionalColumnList.Contains(BulkCopyDataReader.DataTypeNameSchemaColumn)) ||
                    (udtType != null && !allowedOptionalColumnList.Contains(BulkCopyDataReader.DataTypeNameSchemaColumn)) ||
                    (xmlSchemaCollectionDatabase != null && !allowedOptionalColumnList.Contains(BulkCopyDataReader.XmlSchemaCollectionDatabaseSchemaColumn)) ||
                    (xmlSchemaCollectionOwningSchema != null && !allowedOptionalColumnList.Contains(BulkCopyDataReader.XmlSchemaCollectionOwningSchemaSchemaColumn)) ||
                    (xmlSchemaCollectionName != null && !allowedOptionalColumnList.Contains(BulkCopyDataReader.XmlSchemaCollectionNameSchemaColumn)))
                {
                    throw new ArgumentException("Columns are set that are incompatible with the value of providerType.");
                }
            }
            else
            {
                throw new ArgumentException("providerType is unsupported.");
            }

            Type dataType;       // Corresponding CLR type.
            string dataTypeName; // Corresponding SQL Server type.
            bool isLong = false; // Is the column a large value column (e.g. nvarchar(max))?

            switch (providerType)
            {
                case SqlDbType.BigInt:
                    dataType = typeof(long);
                    dataTypeName = "bigint";
                    break;
                case SqlDbType.Binary:
                    dataType = typeof(byte[]);

                    if (!columnSize.HasValue)
                        throw new ArgumentException("columnSize must be specified for \"binary\" type columns.");
                    else if (columnSize > 8000)
                        throw new ArgumentOutOfRangeException("columnSize");

                    dataTypeName = string.Format(CultureInfo.InvariantCulture, "binary({0})", columnSize.Value);
                    break;
                case SqlDbType.Bit:
                    dataType = typeof(bool);
                    dataTypeName = "bit";
                    break;
                case SqlDbType.Char:
                    dataType = typeof(string);

                    if (!columnSize.HasValue)
                        throw new ArgumentException("columnSize must be specified for \"char\" type columns.");
                    else if (columnSize > 8000)
                        throw new ArgumentOutOfRangeException("columnSize");

                    dataTypeName = string.Format(CultureInfo.InvariantCulture, "char({0})", columnSize.Value);
                    break;
                case SqlDbType.Date:
                    dataType = typeof(DateTime);
                    dataTypeName = "date";
                    break;
                case SqlDbType.DateTime:
                    dataType = typeof(DateTime);
                    dataTypeName = "datetime";
                    break;
                case SqlDbType.DateTime2:
                    dataType = typeof(DateTime);

                    if (numericPrecision.HasValue)
                    {
                        if (numericPrecision.Value > 7)
                            throw new ArgumentOutOfRangeException("numericPrecision");

                        dataTypeName = string.Format(CultureInfo.InvariantCulture, "datetime2({0})", numericPrecision.Value);
                    }
                    else
                        dataTypeName = "datetime2";
                    break;
                case SqlDbType.DateTimeOffset:
                    dataType = typeof(DateTimeOffset);

                    if (numericPrecision.HasValue)
                    {
                        if (numericPrecision.Value > 7)
                            throw new ArgumentOutOfRangeException("numericPrecision");

                        dataTypeName = string.Format(CultureInfo.InvariantCulture, "datetimeoffset({0})", numericPrecision.Value);
                    }
                    else
                        dataTypeName = "datetimeoffset";
                    break;
                case SqlDbType.Decimal:
                    dataType = typeof(decimal);

                    if (!numericPrecision.HasValue || !numericScale.HasValue)
                        throw new ArgumentException("numericPrecision and numericScale must be specified for \"decimal\" type columns.");
                    else if (numericPrecision > 38)
                        throw new ArgumentOutOfRangeException("numericPrecision");
                    else if (numericScale.Value > numericPrecision.Value)
                        throw new ArgumentException("numericScale must not be larger than numericPrecision for \"decimal\" type columns.");

                    dataTypeName = string.Format(CultureInfo.InvariantCulture, "decimal({0}, {1})", numericPrecision.Value, numericScale.Value);
                    break;
                case SqlDbType.Float:
                    dataType = typeof(double);

                    if (!numericPrecision.HasValue)
                        throw new ArgumentException("numericPrecision must be specified for \"float\" type columns");
                    else if (numericPrecision > 53)
                        throw new ArgumentOutOfRangeException("numericPrecision");

                    dataTypeName = string.Format(CultureInfo.InvariantCulture, "float({0})", numericPrecision.Value);
                    break;
                case SqlDbType.Image:
                    dataType = typeof(byte[]);
                    dataTypeName = "image";
                    break;
                case SqlDbType.Int:
                    dataType = typeof(int);
                    dataTypeName = "int";
                    break;
                case SqlDbType.Money:
                    dataType = typeof(decimal);
                    dataTypeName = "money";
                    break;
                case SqlDbType.NChar:
                    dataType = typeof(string);

                    if (!columnSize.HasValue)
                        throw new ArgumentException("columnSize must be specified for \"nchar\" type columns");
                    else if (columnSize > 4000)
                        throw new ArgumentOutOfRangeException("columnSize");

                    dataTypeName = string.Format(CultureInfo.InvariantCulture, "nchar({0})", columnSize.Value);
                    break;
                case SqlDbType.NText:
                    dataType = typeof(string);
                    dataTypeName = "ntext";
                    break;
                case SqlDbType.NVarChar:
                    dataType = typeof(string);

                    if (columnSize.HasValue)
                    {
                        if (columnSize > 4000)
                            throw new ArgumentOutOfRangeException("columnSize");

                        dataTypeName = string.Format(CultureInfo.InvariantCulture, "nvarchar({0})", columnSize.Value);
                    }
                    else
                    {
                        isLong = true;
                        dataTypeName = "nvarchar(max)";
                    }
                    break;
                case SqlDbType.Real:
                    dataType = typeof(float);
                    dataTypeName = "real";
                    break;
                case SqlDbType.SmallDateTime:
                    dataType = typeof(DateTime);
                    dataTypeName = "smalldatetime";
                    break;
                case SqlDbType.SmallInt:
                    dataType = typeof(Int16);
                    dataTypeName = "smallint";
                    break;
                case SqlDbType.SmallMoney:
                    dataType = typeof(decimal);
                    dataTypeName = "smallmoney";
                    break;
                // SqlDbType.Structured not supported because it related to nested rowsets.
                case SqlDbType.Text:
                    dataType = typeof(string);
                    dataTypeName = "text";
                    break;

                case SqlDbType.Time:
                    dataType = typeof(TimeSpan);

                    if (numericPrecision.HasValue)
                    {
                        if (numericPrecision > 7)
                            throw new ArgumentOutOfRangeException("numericPrecision");

                        dataTypeName = string.Format(CultureInfo.InvariantCulture, "time({0})",  numericPrecision.Value);
                    }
                    else
                        dataTypeName = "time";
                    break;
                // SqlDbType.Timestamp not supported because rowversions are not settable.
                case SqlDbType.TinyInt:
                    dataType = typeof(byte);
                    dataTypeName = "tinyint";
                    break;
                case SqlDbType.Udt:
                    if (string.IsNullOrEmpty(udtSchema))
                        throw new ArgumentException("udtSchema must be nonnull and nonempty for \"UDT\" columns.");
                    else if (string.IsNullOrEmpty(udtType))
                        throw new ArgumentException("udtType must be nonnull and nonempty for \"UDT\" columns.");

                    dataType = typeof(object);
                    using (var commandBuilder = new SqlCommandBuilder())
                        dataTypeName = commandBuilder.QuoteIdentifier(udtSchema) + "." + commandBuilder.QuoteIdentifier(udtType);
                    break;
                case SqlDbType.UniqueIdentifier:
                    dataType = typeof(Guid);
                    dataTypeName = "uniqueidentifier";
                    break;
                case SqlDbType.VarBinary:
                    dataType = typeof(byte[]);

                    if (columnSize.HasValue)
                    {
                        if (columnSize > 8000)
                            throw new ArgumentOutOfRangeException("columnSize");

                        dataTypeName = string.Format(CultureInfo.InvariantCulture, "varbinary({0})", columnSize.Value);
                    }
                    else
                    {
                        isLong = true;
                        dataTypeName = "varbinary(max)";
                    }
                    break;
                case SqlDbType.VarChar:
                    dataType = typeof(string);

                    if (columnSize.HasValue)
                    {
                        if (columnSize > 8000)
                            throw new ArgumentOutOfRangeException("columnSize");

                        dataTypeName = string.Format(CultureInfo.InvariantCulture, "varchar({0})", columnSize.Value);
                    }
                    else
                    {
                        isLong = true;
                        dataTypeName = "varchar(max)";
                    }
                    break;
                case SqlDbType.Variant:
                    dataType = typeof(object);
                    dataTypeName = "sql_variant";
                    break;
                case SqlDbType.Xml:
                    dataType = typeof(string);

                    if (xmlSchemaCollectionName == null)
                    {
                        if (xmlSchemaCollectionDatabase != null || xmlSchemaCollectionOwningSchema != null)
                            throw new ArgumentException("xmlSchemaCollectionDatabase and xmlSchemaCollectionOwningSchema must be null if xmlSchemaCollectionName is null for \"xml\" columns.");

                        dataTypeName = "xml";
                    }
                    else
                    {
                        if (xmlSchemaCollectionName.Length == 0)
                            throw new ArgumentException("xmlSchemaCollectionName must be nonempty or null for \"xml\" columns.");
                        else if (xmlSchemaCollectionDatabase != null && xmlSchemaCollectionDatabase.Length == 0)
                            throw new ArgumentException("xmlSchemaCollectionDatabase must be null or nonempty for \"xml\" columns.");
                        else if (xmlSchemaCollectionOwningSchema != null && xmlSchemaCollectionOwningSchema.Length == 0)
                            throw new ArgumentException("xmlSchemaCollectionOwningSchema must be null or nonempty for \"xml\" columns.");

                        var schemaCollection = new System.Text.StringBuilder("xml(");

                        if (xmlSchemaCollectionDatabase != null)
                            schemaCollection.Append("[" + xmlSchemaCollectionDatabase + "]");

                        schemaCollection.Append("[" + (xmlSchemaCollectionOwningSchema == null ? SchemaName : xmlSchemaCollectionOwningSchema) + "]");
                        schemaCollection.Append("[" + xmlSchemaCollectionName + "]");

                        dataTypeName = schemaCollection.ToString();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("providerType");
            }

            _schemaTable.Rows.Add(
                columnName,
                _schemaTable.Rows.Count,
                columnSize,
                numericPrecision,
                numericScale,
                isUnique,
                isKey,
                "TraceServer",
                "TraceWarehouse",
                columnName,
                SchemaName,
                TableName,
                dataType,
                allowDBNull,
                providerType,
                false, // isAliased
                false, // isExpression
                false, // isIdentity,
                false, // isAutoIncrement,
                false, // isRowVersion,
                false, // isHidden,
                isLong,
                true, // isReadOnly,
                dataType,
                dataTypeName,
                xmlSchemaCollectionDatabase,
                xmlSchemaCollectionOwningSchema,
                xmlSchemaCollectionName);

            _columnMapping.Add(new SqlBulkCopyColumnMapping(columnName, columnName));
        }
        
        protected BulkCopyDataReader()
        {
            _schemaTable.Locale = System.Globalization.CultureInfo.InvariantCulture;

            var columns = _schemaTable.Columns;

            columns.Add(SchemaTableColumn.ColumnName, typeof(string));
            columns.Add(SchemaTableColumn.ColumnOrdinal, typeof(int));
            columns.Add(SchemaTableColumn.ColumnSize, typeof(int));
            columns.Add(SchemaTableColumn.NumericPrecision, typeof(short));
            columns.Add(SchemaTableColumn.NumericScale, typeof(short));
            columns.Add(SchemaTableColumn.IsUnique, typeof(bool));
            columns.Add(SchemaTableColumn.IsKey, typeof(bool));
            columns.Add(SchemaTableOptionalColumn.BaseServerName, typeof(string));
            columns.Add(SchemaTableOptionalColumn.BaseCatalogName, typeof(string));
            columns.Add(SchemaTableColumn.BaseColumnName, typeof(string));
            columns.Add(SchemaTableColumn.BaseSchemaName, typeof(string));
            columns.Add(SchemaTableColumn.BaseTableName, typeof(string));
            columns.Add(SchemaTableColumn.DataType, typeof(System.Type));
            columns.Add(SchemaTableColumn.AllowDBNull, typeof(bool));
            columns.Add(SchemaTableColumn.ProviderType, typeof(int));
            columns.Add(SchemaTableColumn.IsAliased, typeof(bool));
            columns.Add(SchemaTableColumn.IsExpression, typeof(bool));
            columns.Add(BulkCopyDataReader.IsIdentitySchemaColumn, typeof(bool));
            columns.Add(SchemaTableOptionalColumn.IsAutoIncrement, typeof(bool));
            columns.Add(SchemaTableOptionalColumn.IsRowVersion, typeof(bool));
            columns.Add(SchemaTableOptionalColumn.IsHidden, typeof(bool));
            columns.Add(SchemaTableColumn.IsLong, typeof(bool));
            columns.Add(SchemaTableOptionalColumn.IsReadOnly, typeof(bool));
            columns.Add(SchemaTableOptionalColumn.ProviderSpecificDataType, typeof(System.Type));
            columns.Add(BulkCopyDataReader.DataTypeNameSchemaColumn, typeof(string));
            columns.Add(BulkCopyDataReader.XmlSchemaCollectionDatabaseSchemaColumn, typeof(string));
            columns.Add(BulkCopyDataReader.XmlSchemaCollectionOwningSchemaSchemaColumn, typeof(string));
            columns.Add(BulkCopyDataReader.XmlSchemaCollectionNameSchemaColumn, typeof(string));
        }
                
        #region IDataReader

        public int Depth
        {
            get 
            { 
                return 0; 
            }
        }

        public int FieldCount
        {
            get 
            { 
                return GetSchemaTable().Rows.Count; 
            }
        }

        public bool IsClosed
        {
            get 
            { 
                return !_open; 
            }
        }

        public object this[int i]
        {
            get 
            { 
                return GetValue(i); 
            }
        }

        public object this[string name]
        {
            get 
            { 
                return GetValue(GetOrdinal(name)); 
            }
        }

        public int RecordsAffected
        {
            get 
            { 
                return -1; 
            }
        }

        public void Close()
        {
            _open = false;
        }

        public bool GetBoolean(int i)
        {
            return (bool)GetValue(i);
        }

        public byte GetByte(int i)
        {
            return (byte)GetValue(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            var data = (byte[])GetValue(i);

            if (buffer != null)
                Array.Copy(data, fieldOffset, buffer, bufferOffset, length);

            return data.LongLength;
        }

        public char GetChar(int i)
        {
            char result;

            var data = GetValue(i);
            var dataAsChar = data as char?;
            var dataAsCharArray = data as char[];
            var dataAsString = data as string;

            if (dataAsChar.HasValue)
                result = dataAsChar.Value;
            else if (dataAsCharArray != null && dataAsCharArray.Length == 1)
                result = dataAsCharArray[0];
            else if (dataAsString != null &&  dataAsString.Length == 1)
                result = dataAsString[0];
            else
                throw new InvalidOperationException("GetValue did not return a Char compatible type.");

            return result;
        }

        public long GetChars(int i, long fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            var data = GetValue(i);
            var dataAsString = data as string;
            var dataAsCharArray = data as char[];

            if (dataAsString != null)
                dataAsCharArray = dataAsString.ToCharArray((int)fieldOffset, length);
            else if (dataAsCharArray == null)
                throw new InvalidOperationException("GetValue did not return either a Char array or a String.");

            if (buffer != null)
                Array.Copy(dataAsCharArray, fieldOffset, buffer, bufferOffset, length);

            return dataAsCharArray.LongLength;
        }

        public IDataReader GetData(int i)
        {
            if (i < 0 || i >= FieldCount)
                throw new ArgumentOutOfRangeException("i");

            return null;
        }

        public string GetDataTypeName(int i)
        {
            return GetFieldType(i).Name;
        }

        public DateTime GetDateTime(int i)
        {
            return (DateTime)GetValue(i);
        }

        public DateTimeOffset GetDateTimeOffset(int i)
        {
            return (DateTimeOffset)GetValue(i);
        }

        public decimal GetDecimal(int i)
        {
            return (Decimal)GetValue(i);
        }

        public double GetDouble(int i)
        {
            return (double)GetValue(i);
        }

        public Type GetFieldType(int i)
        {
            return (Type)GetSchemaTable().Rows[i][SchemaTableColumn.DataType];
        }

        public float GetFloat(int i)
        {
            return (float)this[i];
        }

        public Guid GetGuid(int i)
        {
            return (Guid)GetValue(i);
        }

        public short GetInt16(int i)
        {
            return (short)GetValue(i);
        }

        public int GetInt32(int i)
        {
            return (int)GetValue(i);
        }

        public long GetInt64(int i)
        {
            return (long)GetValue(i);
        }

        public string GetName(int i)
        {
            return (string)GetSchemaTable().Rows[i][SchemaTableColumn.ColumnName];
        }

        public int GetOrdinal(string name)
        {
            if (name == null) // Empty strings are handled as a IndexOutOfRangeException.
                throw new ArgumentNullException("name");

            int result = -1;
            int rowCount = FieldCount;
            var schemaRows = GetSchemaTable().Rows;

            // Case sensitive search
            for (int ordinal = 0; ordinal < rowCount; ordinal++)
                if (string.Equals((string)schemaRows[ordinal][SchemaTableColumn.ColumnName], name, StringComparison.Ordinal))
                    result = ordinal;

            if (result == -1)
            {
                // Case insensitive search.
                for (int ordinal = 0; ordinal < rowCount; ordinal++)
                    if (string.Equals((string)schemaRows[ordinal][SchemaTableColumn.ColumnName], name, StringComparison.OrdinalIgnoreCase))
                        result = ordinal;
            }

            if (result == -1)
                throw new IndexOutOfRangeException(name);

            return result;
        }

        public DataTable GetSchemaTable()
        {
            if (IsClosed)
                throw new InvalidOperationException("IDataReader is closed");

            if (_schemaTable.Rows.Count == 0)
            {
                // Need to add the column definitions and mappings
                _schemaTable.TableName = TableName;

                AddSchemaTableRows();
            }

            return _schemaTable;
        }

        public string GetString(int i)
        {
            return (string)GetValue(i);
        }

        public TimeSpan GetTimeSpan(int i)
        {
            return (TimeSpan)GetValue(i);
        }

        public abstract object GetValue(int i);

        public int GetValues(object[] values)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            int fieldCount = Math.Min(FieldCount, values.Length);

            for (int i = 0; i < fieldCount; i++)
                values[i] = GetValue(i);

            return fieldCount;
        }

        public bool IsDBNull(int i)
        {
            object data = GetValue(i);

            return data == null || Convert.IsDBNull(data);
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (disposing)
                {
                    if (_schemaTable != null)
                    {
                        _schemaTable.Dispose();
                        _schemaTable = null;
                    }

                    _columnMapping = null;
                    _open = false;

                    GC.SuppressFinalize(this);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~BulkCopyDataReader()
        {
            Dispose(false);
        }

        #endregion
    }
}

