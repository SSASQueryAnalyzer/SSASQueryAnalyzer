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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices
{
    using System;
    using System.Runtime.InteropServices;

    public enum TraceEventSubclass
    {
        // Summary:
        //     The NotAvailable subclass.
        NotAvailable,
        //
        // Summary:
        //     The InstanceShutdown subclass.
        InstanceShutdown,
        //
        // Summary:
        //     The InstanceStarted subclass.
        InstanceStarted,
        //
        // Summary:
        //     The InstancePaused subclass.
        InstancePaused,
        //
        // Summary:
        //     The InstanceContinued subclass.
        InstanceContinued,
        //
        // Summary:
        //     The Backup subclass.
        Backup,
        //
        // Summary:
        //     The Restore subclass.
        Restore,
        //
        // Summary:
        //     The Synchronize subclass.
        Synchronize,
        //
        // Summary:
        //     The Process subclass.
        Process,
        //
        // Summary:
        //     The Merge subclass.
        Merge,
        //
        // Summary:
        //     The Delete subclass.
        Delete,
        //
        // Summary:
        //     The DeleteOldAggregations subclass.
        DeleteOldAggregations,
        //
        // Summary:
        //     The Rebuild subclass.
        Rebuild,
        //
        // Summary:
        //     The Commit subclass.
        Commit,
        //
        // Summary:
        //     The Rollback subclass.
        Rollback,
        //
        // Summary:
        //     The CreateIndexes subclass.
        CreateIndexes,
        //
        // Summary:
        //     The CreateTable subclass.
        CreateTable,
        //
        // Summary:
        //     The InsertInto subclass.
        InsertInto,
        //
        // Summary:
        //     The Transaction subclass.
        Transaction,
        //
        // Summary:
        //     The Initialize subclass.
        Initialize,
        //
        // Summary:
        //     The Discretize subclass.
        Discretize,
        //
        // Summary:
        //     The Query subclass.
        Query,
        //
        // Summary:
        //     The CreateView subclass.
        CreateView,
        //
        // Summary:
        //     The WriteData subclass.
        WriteData,
        //
        // Summary:
        //     The ReadData subclass.
        ReadData,
        //
        // Summary:
        //     The GroupData subclass.
        GroupData,
        //
        // Summary:
        //     The GroupDataRecord subclass.
        GroupDataRecord,
        //
        // Summary:
        //     The BuildIndex subclass.
        BuildIndex,
        //
        // Summary:
        //     The Aggregate subclass.
        Aggregate,
        //
        // Summary:
        //     The BuildDecode subclass.
        BuildDecode,
        //
        // Summary:
        //     The WriteDecode subclass.
        WriteDecode,
        //
        // Summary:
        //     The BuildDataMiningDecode subclass.
        BuildDataMiningDecode,
        //
        // Summary:
        //     The ExecuteSql subclass.
        ExecuteSql,
        //
        // Summary:
        //     The ExecuteModifiedSql subclass.
        ExecuteModifiedSql,
        //
        // Summary:
        //     The Connecting subclass.
        Connecting,
        //
        // Summary:
        //     The BuildAggregationsAndIndexes subclass.
        BuildAggregationsAndIndexes,
        //
        // Summary:
        //     The MergeAggregationsOnDisk subclass.
        MergeAggregationsOnDisk,
        //
        // Summary:
        //     The BuildIndexForRigidAggregations subclass.
        BuildIndexForRigidAggregations,
        //
        // Summary:
        //     The BuildIndexForFlexibleAggregations subclass.
        BuildIndexForFlexibleAggregations,
        //
        // Summary:
        //     The WriteAggregationsAndIndexes subclass.
        WriteAggregationsAndIndexes,
        //
        // Summary:
        //     The WriteSegment subclass.
        WriteSegment,
        //
        // Summary:
        //     The DataMiningProgress subclass.
        DataMiningProgress,
        //
        // Summary:
        //     The ReadBufferFullReport subclass.
        ReadBufferFullReport,
        //
        // Summary:
        //     The ProactiveCacheConversion subclass.
        ProactiveCacheConversion,
        //
        // Summary:
        //     The BuildProcessingSchedule subclass.
        BuildProcessingSchedule,
        //
        // Summary:
        //     The MdxQuery subclass.
        MdxQuery,
        //
        // Summary:
        //     The DmxQuery subclass.
        DmxQuery,
        //
        // Summary:
        //     The SqlQuery subclass.
        SqlQuery,
        //
        // Summary:
        //     The Create subclass.
        Create,
        //
        // Summary:
        //     The Alter subclass.
        Alter,
        //
        // Summary:
        //     The DesignAggregations subclass.
        DesignAggregations,
        //
        // Summary:
        //     The WBInsert subclass.
        WBInsert,
        //
        // Summary:
        //     The WBUpdate subclass.
        WBUpdate,
        //
        // Summary:
        //     The WBDelete subclass.
        WBDelete,
        //
        // Summary:
        //     The MergePartitions subclass.
        MergePartitions,
        //
        // Summary:
        //     The Subscribe subclass.
        Subscribe,
        //
        // Summary:
        //     The Batch subclass.
        Batch,
        //
        // Summary:
        //     The BeginTransaction subclass.
        BeginTransaction,
        //
        // Summary:
        //     The CommitTransaction subclass.
        CommitTransaction,
        //
        // Summary:
        //     The RollbackTransaction subclass.
        RollbackTransaction,
        //
        // Summary:
        //     The GetTransactionState subclass.
        GetTransactionState,
        //
        // Summary:
        //     The Cancel subclass.
        Cancel,
        //
        // Summary:
        //     The Import80MiningModels subclass.
        Import80MiningModels,
        //
        // Summary:
        //     The Other subclass.
        Other,
        //
        // Summary:
        //     The DiscoverConnections subclass.
        DiscoverConnections,
        //
        // Summary:
        //     The DiscoverSessions subclass.
        DiscoverSessions,
        //
        // Summary:
        //     The DiscoverTransactions subclass.
        DiscoverTransactions,
        //
        // Summary:
        //     The DiscoverDatabaseConnections subclass.
        DiscoverDatabaseConnections,
        //
        // Summary:
        //     The DiscoverJobs subclass.
        DiscoverJobs,
        //
        // Summary:
        //     The DiscoverLocks subclass.
        DiscoverLocks,
        //
        // Summary:
        //     The DiscoverPerformanceCounters subclass.
        DiscoverPerformanceCounters,
        //
        // Summary:
        //     The DiscoverMemoryUsage subclass.
        DiscoverMemoryUsage,
        //
        // Summary:
        //     The DiscoverJobProgress subclass.
        DiscoverJobProgress,
        //
        // Summary:
        //     The DiscoverMemoryGrant subclass.
        DiscoverMemoryGrant,
        //
        // Summary:
        //     The SchemaCatalogs subclass.
        SchemaCatalogs,
        //
        // Summary:
        //     The SchemaTables subclass.
        SchemaTables,
        //
        // Summary:
        //     The SchemaColumns subclass.
        SchemaColumns,
        //
        // Summary:
        //     The SchemaProviderTypes subclass.
        SchemaProviderTypes,
        //
        // Summary:
        //     The SchemaCubes subclass.
        SchemaCubes,
        //
        // Summary:
        //     The SchemaDimensions subclass.
        SchemaDimensions,
        //
        // Summary:
        //     The SchemaHierarchies subclass.
        SchemaHierarchies,
        //
        // Summary:
        //     The SchemaLevels subclass.
        SchemaLevels,
        //
        // Summary:
        //     The SchemaMeasures subclass.
        SchemaMeasures,
        //
        // Summary:
        //     The SchemaProperties subclass.
        SchemaProperties,
        //
        // Summary:
        //     The SchemaMembers subclass.
        SchemaMembers,
        //
        // Summary:
        //     The SchemaFunctions subclass.
        SchemaFunctions,
        //
        // Summary:
        //     The SchemaActions subclass.
        SchemaActions,
        //
        // Summary:
        //     The SchemaSets subclass.
        SchemaSets,
        //
        // Summary:
        //     The DiscoverInstances subclass.
        DiscoverInstances,
        //
        // Summary:
        //     The SchemaKpis subclass.
        SchemaKpis,
        //
        // Summary:
        //     The SchemaMeasureGroups subclass.
        SchemaMeasureGroups,
        //
        // Summary:
        //     The SchemaCommands subclass.
        SchemaCommands,
        //
        // Summary:
        //     The SchemaMiningServices subclass.
        SchemaMiningServices,
        //
        // Summary:
        //     The SchemaMiningServiceParameters subclass.
        SchemaMiningServiceParameters,
        //
        // Summary:
        //     The SchemaMiningFunctions subclass.
        SchemaMiningFunctions,
        //
        // Summary:
        //     The SchemaMiningModelContent subclass.
        SchemaMiningModelContent,
        //
        // Summary:
        //     The SchemaMiningModelXml subclass.
        SchemaMiningModelXml,
        //
        // Summary:
        //     The SchemaMiningModels subclass.
        SchemaMiningModels,
        //
        // Summary:
        //     The SchemaMiningColumns subclass.
        SchemaMiningColumns,
        //
        // Summary:
        //     The DiscoverDataSources subclass.
        DiscoverDataSources,
        //
        // Summary:
        //     The DiscoverProperties subclass.
        DiscoverProperties,
        //
        // Summary:
        //     The DiscoverSchemaRowsets subclass.
        DiscoverSchemaRowsets,
        //
        // Summary:
        //     The DiscoverEnumerators subclass.
        DiscoverEnumerators,
        //
        // Summary:
        //     The DiscoverKeywords subclass.
        DiscoverKeywords,
        //
        // Summary:
        //     The DiscoverLiterals subclass.
        DiscoverLiterals,
        //
        // Summary:
        //     The DiscoverXmlMetadata subclass.
        DiscoverXmlMetadata,
        //
        // Summary:
        //     The DiscoverTraces subclass.
        DiscoverTraces,
        //
        // Summary:
        //     The DiscoverTraceDefinitionProviderInfo subclass.
        DiscoverTraceDefinitionProviderInfo,
        //
        // Summary:
        //     The DiscoverTraceColumns subclass.
        DiscoverTraceColumns,
        //
        // Summary:
        //     The DiscoverTraceEventCategories subclass.
        DiscoverTraceEventCategories,
        //
        // Summary:
        //     The SchemaMiningStructures subclass.
        SchemaMiningStructures,
        //
        // Summary:
        //     The SchemaMiningStructureColumns subclass.
        SchemaMiningStructureColumns,
        //
        // Summary:
        //     The DiscoverMasterKey subclass.
        DiscoverMasterKey,
        //
        // Summary:
        //     The SchemaInputDataSources subclass.
        SchemaInputDataSources,
        //
        // Summary:
        //     The DiscoverLocations subclass.
        DiscoverLocations,
        //
        // Summary:
        //     The DiscoverPartitionDimensionStat subclass.
        DiscoverPartitionDimensionStat,
        //
        // Summary:
        //     The DiscoverPartitionStat subclass.
        DiscoverPartitionStat,
        //
        // Summary:
        //     The DiscoverDimensionStat subclass.
        DiscoverDimensionStat,
        //
        // Summary:
        //     The ProactiveCachingBegin subclass.
        ProactiveCachingBegin,
        //
        // Summary:
        //     The ProactiveCachingEnd subclass.
        ProactiveCachingEnd,
        //
        // Summary:
        //     The FlightRecorderStarted subclass.
        FlightRecorderStarted,
        //
        // Summary:
        //     The FlightRecorderStopped subclass.
        FlightRecorderStopped,
        //
        // Summary:
        //     The ConfigurationPropertiesUpdated subclass.
        ConfigurationPropertiesUpdated,
        //
        // Summary:
        //     The SqlTrace subclass.
        SqlTrace,
        //
        // Summary:
        //     The ObjectCreated subclass.
        ObjectCreated,
        //
        // Summary:
        //     The ObjectDeleted subclass.
        ObjectDeleted,
        //
        // Summary:
        //     The ObjectAltered subclass.
        ObjectAltered,
        //
        // Summary:
        //     The ProactiveCachingPollingBegin subclass.
        ProactiveCachingPollingBegin,
        //
        // Summary:
        //     The ProactiveCachingPollingEnd subclass.
        ProactiveCachingPollingEnd,
        //
        // Summary:
        //     The FlightRecorderSnapshotBegin subclass.
        FlightRecorderSnapshotBegin,
        //
        // Summary:
        //     The FlightRecorderSnapshotEnd subclass.
        FlightRecorderSnapshotEnd,
        //
        // Summary:
        //     The ProactiveCachingNotifiableObjectUpdated subclass.
        ProactiveCachingNotifiableObjectUpdated,
        //
        // Summary:
        //     The LazyProcessingStartProcessing subclass.
        LazyProcessingStartProcessing,
        //
        // Summary:
        //     The LazyProcessingProcessingComplete subclass.
        LazyProcessingProcessingComplete,
        //
        // Summary:
        //     The SessionOpenedEventBegin subclass.
        SessionOpenedEventBegin,
        //
        // Summary:
        //     The SessionOpenedEventEnd subclass.
        SessionOpenedEventEnd,
        //
        // Summary:
        //     The SessionClosingEventBegin subclass.
        SessionClosingEventBegin,
        //
        // Summary:
        //     The SessionClosingEventEnd subclass.
        SessionClosingEventEnd,
        //
        // Summary:
        //     The CubeOpenedEventBegin subclass.
        CubeOpenedEventBegin,
        //
        // Summary:
        //     The CubeOpenedEventEnd subclass.
        CubeOpenedEventEnd,
        //
        // Summary:
        //     The CubeClosingEventBegin subclass.
        CubeClosingEventBegin,
        //
        // Summary:
        //     The CubeClosingEventEnd subclass.
        CubeClosingEventEnd,
        //
        // Summary:
        //     The GetData subclass.
        GetData,
        //
        // Summary:
        //     The ProcessCalculatedMembers subclass.
        ProcessCalculatedMembers,
        //
        // Summary:
        //     The PostOrder subclass.
        PostOrder,
        //
        // Summary:
        //     The SerializeAxes subclass.
        SerializeAxes,
        //
        // Summary:
        //     The SerializeCells subclass.
        SerializeCells,
        //
        // Summary:
        //     The SerializeSqlRowset subclass.
        SerializeSqlRowset,
        //
        // Summary:
        //     The SerializeFlattenedRowset subclass.
        SerializeFlattenedRowset,
        //
        // Summary:
        //     The CacheData subclass.
        CacheData,
        //
        // Summary:
        //     The NonCacheData subclass.
        NonCacheData,
        //
        // Summary:
        //     The InternalData subclass.
        InternalData,
        //
        // Summary:
        //     The SqlData subclass.
        SqlData,
        //
        // Summary:
        //     The MeasureGroupStructuralChange subclass.
        MeasureGroupStructuralChange,
        //
        // Summary:
        //     The MeasureGroupDeletion subclass.
        MeasureGroupDeletion,
        //
        // Summary:
        //     The GetDataFromMeasureGroupCache subclass.
        GetDataFromMeasureGroupCache,
        //
        // Summary:
        //     The GetDataFromFlatCache subclass.
        GetDataFromFlatCache,
        //
        // Summary:
        //     The GetDataFromCalculationCache subclass.
        GetDataFromCalculationCache,
        //
        // Summary:
        //     The GetDataFromPersistedCache subclass.
        GetDataFromPersistedCache,
        //
        // Summary:
        //     The Detach subclass.
        Detach,
        //
        // Summary:
        //     The Attach subclass.
        Attach,
        //
        // Summary:
        //     The AnalyzeEncodeData subclass.
        AnalyzeEncodeData,
        //
        // Summary:
        //     The CompressSegment subclass.
        CompressSegment,
        //
        // Summary:
        //     The WriteTableColumn subclass.
        WriteTableColumn,
        //
        // Summary:
        //     The RelationshipBuildPrepare subclass.
        RelationshipBuildPrepare,
        //
        // Summary:
        //     The BuildRelationshipSegment subclass.
        BuildRelationshipSegment,
        //
        // Summary:
        //     The SchemaMeasureGroupDimensions subclass.
        SchemaMeasureGroupDimensions,
        //
        // Summary:
        //     The Load subclass.
        Load,
        //
        // Summary:
        //     The MetadataLoad subclass.
        MetadataLoad,
        //
        // Summary:
        //     The DataLoad subclass.
        DataLoad,
        //
        // Summary:
        //     The PostLoad subclass.
        PostLoad,
        //
        // Summary:
        //     The MetadataTraversalDuringBackup subclass.
        MetadataTraversalDuringBackup,
        //
        // Summary:
        //     The SetAuthContext subclass.
        SetAuthContext,
        //
        // Summary:
        //     The ImageLoad subclass.
        ImageLoad,
        //
        // Summary:
        //     The ImageSave subclass.
        ImageSave,
        //
        // Summary:
        //     The TransactionAbortRequested subclass.
        TransactionAbortRequested,
        //
        // Summary:
        //     The VertiPaqScan subclass, used by the xVelocity in-memory analytics engine
        //     (VertiPaq).
        VertiPaqScan,
        //
        // Summary:
        //     The TabularQuery subclass.
        TabularQuery,
        //
        // Summary:
        //     The VertiPaq subclass, used by the xVelocity in-memory analytics engine (VertiPaq).
        VertiPaq,
        //
        // Summary:
        //     The HierarchyProcessing subclass.
        HierarchyProcessing,
        //
        // Summary:
        //     The VertiPaqScanInternal subclass, used by the xVelocity in-memory analytics
        //     engine (VertiPaq).
        VertiPaqScanInternal,
        //
        // Summary:
        //     The TabularQueryInternal subclass.
        TabularQueryInternal,
        //
        // Summary:
        //     The SwitchingDictionary subclass.
        SwitchingDictionary,
        //
        // Summary:
        //     The MdxScript subclass.
        MdxScript,
        //
        // Summary:
        //     The MdxScriptCommand subclass.
        MdxScriptCommand,
        //
        // Summary:
        //     The DiscoverXEventTraceDefinition subclass.
        DiscoverXEventTraceDefinition,
        //
        // Summary:
        //     The UserHierarchyProcessingQuery subclass.
        UserHierarchyProcessingQuery,
        //
        // Summary:
        //     The UserHierarchyProcessingQueryInternal subclass.
        UserHierarchyProcessingQueryInternal,
        //
        // Summary:
        //     The DAXQuery subclass.
        DAXQuery,
        //
        // Summary:
        //     The DISCOVER_COMMANDS subclass.
        DISCOVER_COMMANDS,
        //
        // Summary:
        //     The DISCOVER_COMMAND_OBJECTS subclass.
        DISCOVER_COMMAND_OBJECTS,
        //
        // Summary:
        //     The DISCOVER_OBJECT_ACTIVITY subclass.
        DISCOVER_OBJECT_ACTIVITY,
        //
        // Summary:
        //     The DISCOVER_OBJECT_MEMORY_USAGE subclass.
        DISCOVER_OBJECT_MEMORY_USAGE,
        //
        // Summary:
        //     The DISCOVER_XEVENT_TRACE_DEFINITION subclass.
        DISCOVER_XEVENT_TRACE_DEFINITION,
        //
        // Summary:
        //     The DISCOVER_STORAGE_TABLES subclass.
        DISCOVER_STORAGE_TABLES,
        //
        // Summary:
        //     The DISCOVER_STORAGE_TABLE_COLUMNS subclass.
        DISCOVER_STORAGE_TABLE_COLUMNS,
        //
        // Summary:
        //     The DISCOVER_STORAGE_TABLE_COLUMN_SEGMENTS subclass.
        DISCOVER_STORAGE_TABLE_COLUMN_SEGMENTS,
        //
        // Summary:
        //     The DISCOVER_CALC_DEPENDENCY subclass.
        DISCOVER_CALC_DEPENDENCY,
        //
        // Summary:
        //     The DISCOVER_CSDL_METADATA subclass.
        DISCOVER_CSDL_METADATA,
        //
        // Summary:
        //     The VertiPaqCacheExactMatch subclass, used by the xVelocity in-memory analytics
        //     engine (VertiPaq).
        VertiPaqCacheExactMatch,
        //
        // Summary:
        //     The InitEvalNodeStart subclass.
        InitEvalNodeStart,
        //
        // Summary:
        //     The InitEvalNodeEnd subclass.
        InitEvalNodeEnd,
        //
        // Summary:
        //     The BuildEvalNodeStart subclass.
        BuildEvalNodeStart,
        //
        // Summary:
        //     The BuildEvalNodeEnd subclass.
        BuildEvalNodeEnd,
        //
        // Summary:
        //     The PrepareEvalNodeStart subclass.
        PrepareEvalNodeStart,
        //
        // Summary:
        //     The PrepareEvalNodeEnd subclass.
        PrepareEvalNodeEnd,
        //
        // Summary:
        //     The RunEvalNodeStart subclass.
        RunEvalNodeStart,
        //
        // Summary:
        //     The RunEvalNodeEnd subclass.
        RunEvalNodeEnd,
        //
        // Summary:
        //     The BuildEvalNodeEliminatedEmptyCalculations subclass.
        BuildEvalNodeEliminatedEmptyCalculations,
        //
        // Summary:
        //     The BuildEvalNodeSubtractedCalculationSpaces subclass.
        BuildEvalNodeSubtractedCalculationSpaces,
        //
        // Summary:
        //     The BuildEvalNodeAppliedVisualTotals subclass.
        BuildEvalNodeAppliedVisualTotals,
        //
        // Summary:
        //     The BuildEvalNodeDetectedCachedEvaluationNode subclass.
        BuildEvalNodeDetectedCachedEvaluationNode,
        //
        // Summary:
        //     The BuildEvalNodeDetectedCachedEvaluationResults subclass.
        BuildEvalNodeDetectedCachedEvaluationResults,
        //
        // Summary:
        //     The PrepareEvalNodeBeginPrepareEvaluationItem subclass.
        PrepareEvalNodeBeginPrepareEvaluationItem,
        //
        // Summary:
        //     The PrepareEvalNodeFinishedPrepareEvaluationItem subclass.
        PrepareEvalNodeFinishedPrepareEvaluationItem,
        //
        // Summary:
        //     The RunEvalNodeFinishedCalculatingItem subclass.
        RunEvalNodeFinishedCalculatingItem,
        //
        // Summary:
        //     The DAXVertiPaqLogicalPlan subclass.
        DAXVertiPaqLogicalPlan,
        //
        // Summary:
        //     The DAXVertiPaqPhysicalPlan subclass.
        DAXVertiPaqPhysicalPlan,
        //
        // Summary:
        //     The DAXDirectQueryAlgebrizerTree subclass.
        DAXDirectQueryAlgebrizerTree,
        //
        // Summary:
        //     The DAXDirectQueryLogicalPlan subclass.
        DAXDirectQueryLogicalPlan,
        //
        CloneDatabase,
        //
        RGWLGroupExceedHighMemoryLimit,
        //
        RGWLGroupExceedHardMemoryLimit,
        //
        RGWLGroupBelowHighMemoryLimit,
        //
        RGWLGroupBelowHardMemoryLimit,
    }
}
