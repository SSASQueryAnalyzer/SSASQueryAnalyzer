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
    using Microsoft.AnalysisServices;
    using System;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    internal static class XmlaHelper
    {
        private const string XmlaBatchClearDatabaseCacheTemplate = 
            "<Batch xmlns=\"http://schemas.microsoft.com/analysisservices/2003/engine\">" +
                "<ClearCache>" +
                    "<Object>" +
                        "<DatabaseID>{0}</DatabaseID>" +
                    "</Object>" +
                "</ClearCache>" +
            "</Batch>";

        private const string XmlaBatchClearCubeCacheTemplate =
          "<Batch xmlns=\"http://schemas.microsoft.com/analysisservices/2003/engine\">" +
              "<ClearCache>" +
                  "<Object>" +
                      "<DatabaseID>{0}</DatabaseID>" +
                      "<CubeID>{1}</CubeID>" +
                  "</Object>" +
              "</ClearCache>" +
          "</Batch>";

        private const string MdxMeasuresMetadata = @"
            WITH
            // MEMBER {1}.[DATAID] AS DATAID(AXIS(1).ITEM(0).ITEM(0).HIERARCHY.CURRENTMEMBER), CAPTION = 'DATAID_OF_CURRENTMEMBER'
               MEMBER {1}.[ID] AS AXIS(1).ITEM(0).ITEM(0).HIERARCHY.CURRENTMEMBER.PROPERTIES(""ID""), CAPTION = 'ID_OF_CURRENTMEMBER'
               MEMBER {1}.[MEMBER_KEY] AS AXIS(1).ITEM(0).ITEM(0).HIERARCHY.CURRENTMEMBER.MEMBER_KEY, CAPTION = 'MEMBERKEY_OF_CURRENTMEMBER'
            // MEMBER {1}.[UNIQUENAME] AS AXIS(1).ITEM(0).ITEM(0).HIERARCHY.CURRENTMEMBER.UNIQUENAME, CAPTION = 'UNIQUENAME_OF_CURRENTMEMBER'
            // MEMBER {1}.[DEFAULTMEMBER] AS AXIS(1).ITEM(0).ITEM(0).HIERARCHY.DEFAULTMEMBER.UNIQUENAME, CAPTION = 'UNIQUENAME_OF_DEFAULTMEMBER'
            // MEMBER {1}.[HIERARCHY_NAME] AS AXIS(1).ITEM(0).ITEM(0).HIERARCHY.NAME, CAPTION = 'HIERARCHY_NAME_OF_CURRENTMEMBER'
            // MEMBER {1}.[LEVEL_NAME] AS AXIS(1).ITEM(0).ITEM(0).HIERARCHY.CURRENTMEMBER.LEVEL.NAME, CAPTION = 'LEVELNAME_OF_CURRENTMEMBER'
            // MEMBER {1}.[CATALOG_NAME] AS AXIS(1).ITEM(0).ITEM(0).HIERARCHY.CURRENTMEMBER.CATALOG_NAME, CAPTION = 'CATALOGNAME_OF_CURRENTMEMBER'
            SELECT 
            {{
            //	{1}.[DATAID],
	            {1}.[ID],
	            {1}.[MEMBER_KEY]--,
            //	{1}.[UNIQUENAME],
            //	{1}.[DEFAULTMEMBER],
            //	{1}.[HIERARCHY_NAME],
            //	{1}.[LEVEL_NAME],
            //	{1}.[CATALOG_NAME]
            }} 
            ON 0,
            {{
	            [Measures].ALLMEMBERS
            }}
            ON 1
            FROM [{0}] PROPERTIES VALUE
            ";

        /// <summary>
        /// Code from ASStoredProcedures [ASStoredProcs.XmlaDiscover.ClearCache(string cubeName)]
        /// </summary>
        /// <see cref="http://www.codeplex.com/Wiki/View.aspx?ProjectName=ASStoredProcedures"/>
        public static void ClearCache(ProcedureContext procedureContext)
        {
            #region Argument exception

            if (procedureContext == null)
                throw new ArgumentNullException(nameof(procedureContext));

            #endregion

            using (var server = new Server())
            {
                server.Connect(procedureContext.ConnectionString);

                switch (procedureContext.ClearCacheMode)
                {
                    case ClearCacheMode.CurrentCube:
                    case ClearCacheMode.CurrentCubeAndFileSystem:
                        {
                            var database = server.Databases.FindByName(procedureContext.DatabaseName);
                            if (database == null)
                                throw new ApplicationException("Database not found [{0}]".FormatWith(procedureContext.DatabaseName));

                            var cube = database.Cubes.FindByName(procedureContext.CubeName);
                            if (cube == null)
                                throw new ApplicationException("Cube not found [{0}]".FormatWith(procedureContext.DatabaseName));

                            server.Execute(XmlaBatchClearCubeCacheTemplate.FormatWith(database.ID, cube.ID));
                        }
                        break;
                    case ClearCacheMode.CurrentDatabase:
                    case ClearCacheMode.CurrentDatabaseAndFileSystem:
                        {
                            var database = server.Databases.FindByName(procedureContext.DatabaseName);
                            if (database == null)
                                throw new ApplicationException("Database not found [{0}]".FormatWith(procedureContext.DatabaseName));

                            server.Execute(XmlaBatchClearDatabaseCacheTemplate.FormatWith(database.ID));
                        }
                        break;
                    case ClearCacheMode.AllDatabases:
                    case ClearCacheMode.AllDatabasesAndFileSystem:
                        {
                            foreach (Database database in server.Databases)
                                server.Execute(XmlaBatchClearDatabaseCacheTemplate.FormatWith(database.ID));
                        }
                        break;
                    default:
                        throw new ApplicationException("Invalid ClearCacheMode [{0}]".FormatWith(procedureContext.ClearCacheMode));
                }
            }
        }

        public static string RetrieveCubeMetadata(ProcedureContext procedureContext)
        {
            #region Argument exception

            if (procedureContext == null)
                throw new ArgumentNullException("procedureContext");

            #endregion

            var path = default(string);
            var document = new XDocument(new XDeclaration("1.0", "utf-8", standalone: null), new XElement("CubeMetadata"));

            using (var server = new Server())
            {
                server.Connect(procedureContext.ConnectionString);

                #region Find database/cube/dimension

                var database = server.Databases.FindByName(procedureContext.DatabaseName);
                if (database == null)
                    throw new ApplicationException("Database not found [{0}]".FormatWith(procedureContext.DatabaseName));

                var cube = database.Cubes.FindByName(procedureContext.CubeName);
                if (cube == null)
                    throw new ApplicationException("Cube not found [{0}]".FormatWith(procedureContext.CubeName));

                var dimension = cube.Dimensions.Cast<CubeDimension>().FirstOrDefault((d) => d.Visible);
                if (dimension == null)
                    throw new ApplicationException("CubeDimension for metadata not found");

                #endregion

                path = "[{0}]".FormatWith(dimension.Name);

                var attribute = dimension.Attributes.Cast<CubeAttribute>().FirstOrDefault((a) => a.AttributeHierarchyVisible && a.AttributeHierarchyEnabled);
                if (attribute != null)
                {
                    path += ".[{0}]".FormatWith(attribute.Attribute.Name);
                }
                else
                {
                    var hierarchy = dimension.Hierarchies.Cast<CubeHierarchy>().FirstOrDefault((h) => h.Visible && h.Enabled);
                    if (hierarchy == null)
                        throw new ApplicationException("CubeAttribute/CubeHierarchy for metadata not found");

                    path += ".[{0}]".FormatWith(hierarchy.Hierarchy.Name);
                }
                
                var mdxScript = cube.MdxScripts.Cast<MdxScript>().First();

                document.Root.Add(new XElement("Cube",
                    new XAttribute("ID", cube.ID ?? string.Empty),
                    new XAttribute("Name", cube.Name ?? string.Empty),
                    new XAttribute("LastSchemaUpdate", cube.LastSchemaUpdate.ToUniversalTime().ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture)),
                    new XAttribute("EstimatedRows", cube.EstimatedRows),
                    new XAttribute("StorageMode", cube.StorageMode),
                    new XAttribute("DefaultMeasure", cube.DefaultMeasure ?? string.Empty),                    
                    new XElement("MdxScript",
                        new XAttribute("ID", mdxScript.ID ?? string.Empty),
                        new XAttribute("Name", mdxScript.Name ?? string.Empty),
                        new XAttribute("DefaultScript", mdxScript.DefaultScript),
                            new XElement("Commands", mdxScript.Commands.Cast<Command>()
                                .Select((c) => { var e = new XElement("Command"); e.Value = c.Text; return e; }))),
                    new XElement("CubeDimensions", cube.Dimensions.Cast<CubeDimension>()
                        .Select((d) => new XElement("CubeDimension",
                            new XAttribute("ID", d.ID ?? string.Empty),
                            new XAttribute("Name", d.Name ?? string.Empty),
                            new XAttribute("Visible", d.Visible),
                            new XAttribute("AttributesCount", d.Attributes.Count),
                            new XAttribute("HierarchiesCount", d.Hierarchies.Count),
                            new XAttribute("DimensionID", d.DimensionID ?? string.Empty)))),
                    new XElement("MeasureGroups", cube.MeasureGroups.Cast<MeasureGroup>()
                        .Select((m) => new XElement("MeasureGroup",
                            new XAttribute("ID", m.ID ?? string.Empty),
                            new XAttribute("Name", m.Name),
                            new XAttribute("Type", m.Type),
                            new XAttribute("StorageMode", m.StorageMode),
                            new XAttribute("EstimatedRows", m.EstimatedRows),
                            new XAttribute("EstimatedSize", m.EstimatedSize),
                            new XAttribute("DataAggregation", m.DataAggregation),
                            new XAttribute("ProcessingMode", m.ProcessingMode),
                            new XElement("AggregationDesigns", m.AggregationDesigns.Cast<AggregationDesign>()
                                .Select((a) => new XElement("AggregationDesign",
                                    new XAttribute("ID", a.ID ?? string.Empty),
                                    new XAttribute("Name", a.Name),
                                    new XAttribute("EstimatedRows", a.EstimatedRows),
                                    new XAttribute("EstimatedPerformanceGain", a.EstimatedPerformanceGain)))),
                            new XElement("Partitions", m.Partitions.Cast<Partition>()
                                .Select((p) => new XElement("Partition",
                                    new XAttribute("ID", p.ID ?? string.Empty),
                                    new XAttribute("Name", p.Name),
                                    new XAttribute("EstimatedRows", p.EstimatedRows),
                                    new XAttribute("EstimatedSize", p.EstimatedSize),
                                    new XAttribute("ProcessingMode", p.ProcessingMode),
                                    new XAttribute("Slice", p.Slice ?? string.Empty),
                                    new XAttribute("StorageMode", p.StorageMode),
                                    new XAttribute("Type", p.Type),
                                    new XAttribute("AggregationDesignID", p.AggregationDesignID ?? string.Empty)))),
                            new XElement("Measures", m.Measures.Cast<Measure>()
                                .Select((s) => new XElement("Measure",
                                    new XAttribute("ID", s.ID ?? string.Empty),
                                    new XAttribute("Name", s.Name),
                                    new XAttribute("Visible", s.Visible),
                                    new XAttribute("DataType", s.DataType),
                                    new XAttribute("FormatString", s.FormatString ?? string.Empty),
                                    new XAttribute("MeasureExpression", s.MeasureExpression ?? string.Empty),
                                    new XAttribute("SourceNullProcessing", s.Source.NullProcessing),
                                    new XAttribute("SourceNullDataType", s.Source.DataType)))))))));
            }

            using (var table = AdomdClientHelper.ExecuteDataTable(procedureContext.ConnectionString, commandText: MdxMeasuresMetadata.FormatWith(procedureContext.CubeName, path)))
            {
                if (table.Columns.Count != 3)
                    throw new ApplicationException("Invalid columns for MdxMeasuresMetadata");

                table.Columns[0].ColumnName = "Name";
                table.Columns[1].ColumnName = "IDOfCurrentMember";
                table.Columns[2].ColumnName = "ID";

                document.Root.Add(new XElement("MeasuresExtended",
                    table.AsEnumerable().Skip(1)
                        .Select((r) => new XElement("Measure", table.Columns.Cast<DataColumn>().Select((c) => new XAttribute(c.ColumnName, r[c])))))
                    );
            }

            return document.ToString(SaveOptions.DisableFormatting);
        }
    }
}
