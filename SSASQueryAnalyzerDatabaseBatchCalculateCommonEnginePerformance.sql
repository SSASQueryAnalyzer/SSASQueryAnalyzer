BEGIN
	SET NOCOUNT ON;

	DECLARE @queryDuration BIGINT;
	DECLARE @storageEngineDuration BIGINT;
	DECLARE @formulaEngineDuration BIGINT;
	DECLARE @querySubcubeExecutionsCacheData INT;
	DECLARE @querySubcubeExecutionsNonCacheData INT;

	SELECT
		@queryDuration = [Duration] 
	FROM 
		[asqa].[Trace] 
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'QueryEnd';

	IF (@queryDuration IS NULL)
	BEGIN
        RAISERROR('@queryDuration is null', 16, 1)
        RETURN
    END
	
	SELECT 
		@storageEngineDuration = ISNULL(SUM([Duration]), 0),
		@querySubcubeExecutionsCacheData = COUNT(IIF([EventSubclass] = N'CacheData', 1, NULL)),
		@querySubcubeExecutionsNonCacheData = COUNT(IIF([EventSubclass] = N'NonCacheData', 1, NULL))
	FROM 
		[asqa].[Trace] AS t
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'QuerySubcube';
		
	IF (@storageEngineDuration > @queryDuration)
		SET @storageEngineDuration = @queryDuration;
	SET @formulaEngineDuration = @queryDuration - @storageEngineDuration;
	
	/*--*/

	DECLARE @partitionsRead INT;
	DECLARE @partitionsHit INT;
	DECLARE @partitionsDuration BIGINT;

	SELECT
		@partitionsRead = COUNT(DISTINCT [ObjectID]),
		@partitionsDuration = ISNULL(SUM([Duration]), 0),
		@partitionsHit = COUNT(*)
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'ProgressReportEnd' AND 
		[EventSubclass] = N'Query' AND 
		[ObjectReference] LIKE '%<PartitionID>%' /* [ObjectType] = N'Partition' */ -- TOFIX

	/*--*/

	DECLARE @aggregationsRead INT;
	DECLARE @aggregationsHit INT;
	DECLARE @aggregationsDuration BIGINT;
	
	WITH [cte_aggregations] AS
	( 
		SELECT
			[ObjectPath],
			[AggregationID] = LEFT(CONVERT(NVARCHAR(MAX), [TextData]), CHARINDEX(CHAR(10), CONVERT(NVARCHAR(MAX), [TextData])) - 1),
			[AggregationObjectPath] = [ObjectPath] + '.' + LEFT(CONVERT(NVARCHAR(MAX), [TextData]), CHARINDEX(CHAR(10), CONVERT(NVARCHAR(MAX), [TextData])) - 1)
		FROM 
			[asqa].[Trace]
		WHERE 
			[ExecutionID] = @executionID AND 
			[EventClass] = N'GetDataFromAggregation'
	)
	SELECT
		@aggregationsRead = COUNT(DISTINCT [ObjectID]),
		@aggregationsDuration = ISNULL(SUM([Duration]), 0),
		@aggregationsHit = COUNT(*)
	FROM 
		[asqa].[Trace] AS t
	INNER JOIN
		[cte_aggregations] AS a
	ON
		t.[ObjectID] = a.[AggregationID] AND
		t.[ObjectPath] = a.[AggregationObjectPath]
	WHERE 
		t.[ExecutionID] = @executionID AND 
		t.[EventClass] = N'ProgressReportEnd' AND 
		t.[EventSubclass] = N'Query';
	
	/*--*/

	DECLARE @cachesRead INT;

	SELECT 
		@cachesRead = COUNT(*)
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'GetDataFromCache';

	/*--*/

	DECLARE @resourceUsageReads INT;
	DECLARE @resourceUsageReadKB BIGINT;
	DECLARE @resourceUsageWrites INT;
	DECLARE @resourceUsageWriteKB BIGINT;
	DECLARE @resourceUsageCpuTimeMS BIGINT;
	DECLARE @resourceUsageRowsScanned INT;
	DECLARE @resourceUsageRowsReturned INT;
	
	SELECT
		@resourceUsageReads = CONVERT(INT, SUBSTRING([TextData], CHARINDEX('READS,', [TextData]) + DATALENGTH('READS,'), CHARINDEX('READ_KB,', [TextData]) - (CHARINDEX('READS,', [TextData]) + DATALENGTH('READS,') + 1))),
		@resourceUsageReadKB = CONVERT(BIGINT, SUBSTRING([TextData], CHARINDEX('READ_KB,', [TextData]) + DATALENGTH('READ_KB,'), CHARINDEX('WRITES,', [TextData]) - (CHARINDEX('READ_KB,', [TextData]) + DATALENGTH('READ_KB,') + 1))),
		@resourceUsageWrites = CONVERT(INT, SUBSTRING([TextData], CHARINDEX('WRITES,', [TextData]) + DATALENGTH('WRITES,'), CHARINDEX('WRITE_KB,', [TextData]) - (CHARINDEX('WRITES,', [TextData]) + DATALENGTH('WRITES,') + 1))),
		@resourceUsageWriteKB = CONVERT(BIGINT, SUBSTRING([TextData], CHARINDEX('WRITE_KB,', [TextData]) + DATALENGTH('WRITE_KB,'), CHARINDEX('CPU_TIME_MS,', [TextData]) - (CHARINDEX('WRITE_KB,', [TextData]) + DATALENGTH('WRITE_KB,') + 1))),
		@resourceUsageCpuTimeMS = CONVERT(BIGINT, SUBSTRING([TextData], CHARINDEX('CPU_TIME_MS,', [TextData]) + DATALENGTH('CPU_TIME_MS,'), CHARINDEX('ROWS_SCANNED,', [TextData]) - (CHARINDEX('CPU_TIME_MS,', [TextData]) + DATALENGTH('CPU_TIME_MS,') + 1))),
		@resourceUsageRowsScanned = CONVERT(INT, SUBSTRING([TextData], CHARINDEX('ROWS_SCANNED,', [TextData]) + DATALENGTH('ROWS_SCANNED,'), CHARINDEX('ROWS_RETURNED,', [TextData]) - (CHARINDEX('ROWS_SCANNED,', [TextData]) + DATALENGTH('ROWS_SCANNED,') + 1))),
		@resourceUsageRowsReturned = CONVERT(INT, SUBSTRING([TextData], CHARINDEX('ROWS_RETURNED,', [TextData]) + DATALENGTH('ROWS_RETURNED,'), CHARINDEX(CHAR(10), [TextData], CHARINDEX('ROWS_RETURNED,', [TextData])) - (CHARINDEX('ROWS_RETURNED,', [TextData]) + DATALENGTH('ROWS_RETURNED,'))))
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'ResourceUsage';

	/*--*/
	 
	IF EXISTS (SELECT * FROM [asqa].[CommonEnginePerformance] WHERE [ExecutionID] = @executionID)
		DELETE [asqa].[CommonEnginePerformance] WHERE [ExecutionID] = @executionID;
  
	INSERT INTO [asqa].[CommonEnginePerformance]
	(
		 [ExecutionID]
		,[QueryDuration]
		,[FormulaEngineDuration]
		,[StorageEngineDuration]
		,[QuerySubcubeExecutionsCacheData]
		,[QuerySubcubeExecutionsNonCacheData]
		,[CachesRead]
		,[PartitionsRead]
		,[PartitionsHit]
		,[PartitionsDuration]
		,[AggregationsRead]
		,[AggregationsHit]
		,[AggregationsDuration]
		,[ResourceUsageReads]
		,[ResourceUsageReadKB]
		,[ResourceUsageWrites]
		,[ResourceUsageWriteKB]
		,[ResourceUsageCpuTimeMS]
		,[ResourceUsageRowsScanned]
		,[ResourceUsageRowsReturned]
	)
	VALUES
	(
		 @executionID
		,CONVERT(TIME, DATEADD(MS, @queryDuration, 0))
		,CONVERT(TIME, DATEADD(MS, @formulaEngineDuration, 0))
		,CONVERT(TIME, DATEADD(MS, @storageEngineDuration, 0))
		,@querySubcubeExecutionsCacheData
		,@querySubcubeExecutionsNonCacheData
		,@cachesRead
		,@partitionsRead
		,@partitionsHit
		,CONVERT(TIME, DATEADD(MS, @partitionsDuration, 0))
		,@aggregationsRead
		,@aggregationsHit
		,CONVERT(TIME, DATEADD(MS, @aggregationsDuration, 0))
		,@resourceUsageReads
		,@resourceUsageReadKB
		,@resourceUsageWrites
		,@resourceUsageWriteKB
		,@resourceUsageCpuTimeMS
		,@resourceUsageRowsScanned
		,@resourceUsageRowsReturned
	);
END