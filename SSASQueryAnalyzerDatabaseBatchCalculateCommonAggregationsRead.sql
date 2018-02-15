BEGIN
	SET NOCOUNT ON;

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
	),
	[cte_events] AS
	(
		SELECT
			t.[ObjectName],
			t.[ObjectPath],
			t.[Duration]
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
			t.[EventSubclass] = N'Query'
	),
	[cte_duration_total] AS
	(
		SELECT
			[DurationTotal] = SUM(t.[Duration])
		FROM
			[cte_events] AS t		
	)
	INSERT INTO [asqa].[CommonAggregationsRead]
	(
		 [ExecutionID]
		,[CubeID]
		,[MeasureGroupID]
		,[PartitionID]
		,[AggregationID]
		,[AggregationName]
		,[AggregationHit]
		,[AggregationDuration]
		,[AggregationDurationRatio]
	)
	SELECT
		[ExecutionID] = @executionID,
		[CubeID] = PARSENAME(SUBSTRING(SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath])), CHARINDEX('.', SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath]))) + 1, LEN(SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath])))), 4),
		[MeasureGroupID] = PARSENAME(SUBSTRING(SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath])), CHARINDEX('.', SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath]))) + 1, LEN(SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath])))), 3),
		[PartitionID] = PARSENAME(SUBSTRING(SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath])), CHARINDEX('.', SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath]))) + 1, LEN(SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath])))), 2),
		[AggregationID] = PARSENAME(SUBSTRING(SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath])), CHARINDEX('.', SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath]))) + 1, LEN(SUBSTRING([ObjectPath], CHARINDEX('.', [ObjectPath]) + 1, LEN([ObjectPath])))), 1),
		[AggregationName] = [ObjectName],
		[AggregationHit] = COUNT(*),
		[AggregationDuration] = CONVERT(TIME, DATEADD(MS, SUM([Duration]), 0)),
		[AggregationDurationRatio] = ROUND(IIF([DurationTotal] = 0, CONVERT(FLOAT, 0), SUM([Duration]) * 100 / CONVERT(FLOAT, [DurationTotal])), 2)
	FROM 
		[cte_events]
	CROSS JOIN
		[cte_duration_total]  -- TODO: sistemare
	GROUP BY
		[ObjectName],
		[ObjectPath],
		[DurationTotal]
END