BEGIN
	SET NOCOUNT ON;
	
	DECLARE @durationTotal BIGINT;

	SELECT
		@durationTotal = SUM([Duration])
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'ProgressReportEnd' AND 
		[EventSubclass] = N'Query' AND 
		[ObjectReference] LIKE '%<PartitionID>%'-- [ObjectType] = N'Partition' -- TOFIX

	INSERT INTO [asqa].[CommonPartitionsRead]
	(
		 [ExecutionID]
        ,[CubeID]
        ,[MeasureGroupID]
        ,[PartitionID]
        ,[PartitionName]
        ,[PartitionHit]
        ,[PartitionDuration]
        ,[PartitionDurationRatio]
	)	
	SELECT
		[ExecutionID] = @executionID,
		[CubeID] = CONVERT(XML, [ObjectReference]).value(N'(/Object/CubeID)[1]', N'NVARCHAR(256)'),
		[MeasureGroupID] = CONVERT(XML, [ObjectReference]).value(N'(/Object/MeasureGroupID)[1]', N'NVARCHAR(256)'),
		[PartitionID] = CONVERT(XML, [ObjectReference]).value(N'(/Object/PartitionID)[1]', N'NVARCHAR(256)'),
		[PartitionName] = [ObjectName],
		[PartitionHit] = COUNT(*),
		[PartitionDuration] = CONVERT(TIME, DATEADD(MS, SUM([Duration]), 0)),
		[PartitionDurationRatio] = ROUND(IIF(@durationTotal = 0, CONVERT(FLOAT, 0), SUM([Duration]) * 100 / CONVERT(FLOAT, @durationTotal)), 2)
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'ProgressReportEnd' AND 
		[EventSubclass] = N'Query' AND 
		[ObjectReference] LIKE '%<PartitionID>%'-- [ObjectType] = N'Partition' -- TOFIX
	GROUP BY
		[ObjectID],
		[ObjectName],
		[ObjectReference]
END