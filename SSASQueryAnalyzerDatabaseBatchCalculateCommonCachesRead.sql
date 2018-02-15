BEGIN
	SET NOCOUNT ON; 
	
	/*--*/
	 
	IF EXISTS (SELECT * FROM [asqa].[CommonCachesRead] WHERE [ExecutionID] = @executionID)
		DELETE  [asqa].[CommonCachesRead] WHERE [ExecutionID] = @executionID;

	/*--*/

	INSERT INTO [asqa].[CommonCachesRead]
	(
		 [ExecutionID]
		,[CacheType]
		,[CacheSubType]
	)
	SELECT
		ExecutionID = @executionID,
		CacheType = CONVERT(NVARCHAR(256), 'Measure Group Cache'),
		CacheSubType = CONVERT(NVARCHAR(MAX), [TextData])
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'GetDataFromCache' AND 
		[EventSubclass] = N'GetDataFromMeasureGroupCache';

	/*--*/

	INSERT INTO [asqa].[CommonCachesRead]
	(
		 [ExecutionID]
		,[CacheType]
		,[CacheSubType]
	)
	SELECT
		ExecutionID = @executionID,
		CacheType = CONVERT(NVARCHAR(256), 'Persisted Cache'),
		CacheSubType = CONVERT(NVARCHAR(256), [TextData])
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'GetDataFromCache' AND 
		[EventSubclass] = N'GetDataFromPersistedCache';

	/*--*/

	INSERT INTO [asqa].[CommonCachesRead]
	(
		 [ExecutionID]
		,[CacheType]
		,[CacheSubType]
	)
	SELECT
		ExecutionID = @executionID,
		CacheType = CONVERT(NVARCHAR(256), 'Flat Cache'),
		CacheSubType = CONVERT(NVARCHAR(256), [TextData])
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'GetDataFromCache' AND 
		[EventSubclass] = N'GetDataFromFlatCache';

	/*--*/

	INSERT INTO [asqa].[CommonCachesRead]
	(
		 [ExecutionID]
		,[CacheType]
		,[CacheSubType]
	)
	SELECT
		ExecutionID = @executionID,
		CacheType = CONVERT(NVARCHAR(256), 'Calculation Cache - Global Scope'),
		CacheSubType = CONVERT(NVARCHAR(256), [TextData])
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'GetDataFromCache' AND 
		[EventSubclass] = N'GetDataFromCalculationCache' AND 
		CONVERT(NVARCHAR(MAX), [TextData]) = N'Global Scope';

	/*--*/

	INSERT INTO [asqa].[CommonCachesRead]
	(
		 [ExecutionID]
		,[CacheType]
		,[CacheSubType]
	)
	SELECT
		ExecutionID = @executionID,
		CacheType = CONVERT(NVARCHAR(256), 'Calculation Cache - Session Scope'),
		CacheSubType = CONVERT(NVARCHAR(256), [TextData])
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'GetDataFromCache' AND
		[EventSubclass] = N'GetDataFromCalculationCache' AND 
		CONVERT(NVARCHAR(MAX), [TextData]) = N'Session Scope';

	/*--*/

	INSERT INTO [asqa].[CommonCachesRead]
	(
		 [ExecutionID]
		,[CacheType]
		,[CacheSubType]
	)
	SELECT
		ExecutionID = @executionID,
		CacheType = CONVERT(NVARCHAR(256), 'Calculation Cache - Query Scope'),
		CacheSubType = CONVERT(NVARCHAR(256), [TextData])
	FROM 
		[asqa].[Trace]
	WHERE 
		[ExecutionID] = @executionID AND 
		[EventClass] = N'GetDataFromCache' AND 
		[EventSubclass] = N'GetDataFromCalculationCache' AND 
		CONVERT(NVARCHAR(MAX), [TextData]) = N'Query Scope';
	
	/*--*/
END