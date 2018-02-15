CREATE SCHEMA [asqa] AUTHORIZATION [dbo]
GO

CREATE TABLE [asqa].[Execution]
(
	[BatchID] [uniqueidentifier] NOT NULL,
	[ExecutionID] [uniqueidentifier] NOT NULL,
	[BatchName] [nvarchar](256) NULL,
	[ExecutionStartTime] [datetime] NOT NULL,
	[ExecutionEndTime] [datetime] NULL,
	[ExecutionError] [nvarchar](max) NULL,
	[ConnectionUserName] [nvarchar](256) NOT NULL,
	[ImpersonationUserName] [nvarchar](256) NOT NULL,
	[SSASInstanceName] [nvarchar](256) NOT NULL,
	[SSASInstanceVersion] [nvarchar](256) NOT NULL,
	[SSASInstanceEdition] [nvarchar](256) NOT NULL,
	[SSASInstanceConfig] [nvarchar](max) NOT NULL,
	[SQLInstanceName] [nvarchar](256) NOT NULL,
	[SQLInstanceVersion] [nvarchar](256) NOT NULL,
	[SQLInstanceEdition] [nvarchar](256) NOT NULL,
	[DatabaseName] [nvarchar](256) NOT NULL,
	[CubeName] [nvarchar](256) NOT NULL,
	[CubeMetadata] [nvarchar](max) NOT NULL,
	[ClearCacheMode] [nvarchar](256) NOT NULL,
	[Statement] [nvarchar](max) NOT NULL,
	[ASQAServerVersion] [nvarchar](256) NOT NULL,
	[ASQAServerConfig] [nvarchar](max) NOT NULL,
	[ClientVersion] [nvarchar](256) NOT NULL,
	[ClientType] [nvarchar](256) NULL,
	[SystemOperativeSystemName] [nvarchar](256) NULL,
	[SystemPhysicalMemory] [bigint] NULL,
	[SystemLogicalCpuCore] [int] NULL
)
GO

CREATE TABLE [asqa].[Performance]
(
    [ExecutionID] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](256) NOT NULL,
	[CounterName] [nvarchar](256) NOT NULL,
	[TraceEventTime] [datetime] NOT NULL,
    [Value] [bigint] NOT NULL
)
GO

CREATE TABLE [asqa].[Trace]
(
	[ExecutionID] [uniqueidentifier] NOT NULL,
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
	[TextData] [nvarchar](MAX) NULL
)
GO

CREATE TABLE [asqa].[CommonEnginePerformance]
( 
	[ExecutionID] [uniqueidentifier] NOT NULL,
	[QueryDuration] [time] NULL,
	[FormulaEngineDuration] [time] NULL,
	[StorageEngineDuration] [time] NULL,
	[QuerySubcubeExecutionsCacheData] [int] NULL,
	[QuerySubcubeExecutionsNonCacheData] [int] NULL,
	[CachesRead] [int] NULL,
	[PartitionsRead] [int] NULL,
	[PartitionsHit] [int] NULL,
	[PartitionsDuration] [time] NULL,
	[AggregationsRead] [int] NULL,
	[AggregationsHit] [int] NULL,
	[AggregationsDuration] [time] NULL,
	[ResourceUsageReads] [int] NULL,
	[ResourceUsageReadKB] [bigint] NULL,
	[ResourceUsageWrites] [int] NULL,
	[ResourceUsageWriteKB] [bigint] NULL,
	[ResourceUsageCpuTimeMS] [bigint] NULL,
	[ResourceUsageRowsScanned] [int] NULL,
	[ResourceUsageRowsReturned] [int] NULL,
)
GO

CREATE TABLE [asqa].[CommonCachesRead]
(
	[ExecutionID] [uniqueidentifier] NOT NULL,	
	[CacheType] [nvarchar](256) NULL,	
	[CacheSubType] [nvarchar](MAX) NULL	
)
GO

CREATE TABLE [asqa].[CommonPartitionsRead]
(
	[ExecutionID] [uniqueidentifier] NOT NULL,	
	[CubeID] [nvarchar](256) NULL,	
	[MeasureGroupID] [nvarchar](256) NULL,	
	[PartitionID] [nvarchar](256) NULL,	
	[PartitionName] [nvarchar](256) NULL,	
	[PartitionHit] [int] NULL,	
	[PartitionDuration] [time] NULL,	
	[PartitionDurationRatio] [float] NULL		
)
GO

CREATE TABLE [asqa].[CommonAggregationsRead]
(
	[ExecutionID] [uniqueidentifier] NOT NULL,	
	[CubeID] [nvarchar](256) NULL,	
	[MeasureGroupID] [nvarchar](256) NULL,	
	[PartitionID] [nvarchar](256) NULL,	
	[AggregationID] [nvarchar](256) NULL,
	[AggregationName] [nvarchar](256) NULL,
	[AggregationHit] [int] NULL,
	[AggregationDuration] [time] NULL,
	[AggregationDurationRatio] [float] NULL,
)
GO

CREATE VIEW [asqa].[vw_Execution]
AS
WITH cte AS
(
	SELECT
		  e.[BatchID]
		, e.[ExecutionID]
		, e.[BatchName]
		, e.[ExecutionStartTime]
		, e.[ExecutionEndTime]
		, e.[ExecutionError]
		, e.[ConnectionUserName]
		, e.[ImpersonationUserName]
		, e.[SSASInstanceName]
		, e.[SSASInstanceVersion]
		, e.[SSASInstanceEdition]
		, e.[SSASInstanceConfig]
		, e.[SQLInstanceName]
		, e.[SQLInstanceVersion]
		, e.[SQLInstanceEdition]
		, e.[DatabaseName]
		, e.[CubeName]
		, e.[CubeMetadata]
		, e.[ClearCacheMode]
		, e.[Statement]
		, e.[ASQAServerVersion]
		, e.[ASQAServerConfig]
		, e.[ClientVersion]
		, e.[ClientType]
		, e.[SystemOperativeSystemName]
		, e.[SystemPhysicalMemory]
		, e.[SystemLogicalCpuCore]
		, [$error_count] = COUNT(e.[ExecutionError]) OVER(PARTITION BY e.[BatchID])
		, [$execution_count] = COUNT(e.[ExecutionID]) OVER(PARTITION BY e.[BatchID])
		, [$cache_mode_nothing_count] = COUNT(IIF(e.[ClearCacheMode] = 'NOTHING', 1, NULL)) OVER(PARTITION BY e.[BatchID])
	FROM
		[asqa].[Execution] AS e
)
SELECT
      c.[BatchID]
	, c.[ExecutionID]
	, c.[BatchName]
	, c.[ExecutionStartTime]
	, c.[ExecutionEndTime]
	, c.[ExecutionError]
	, c.[ConnectionUserName]
	, c.[ImpersonationUserName]
	, c.[SSASInstanceName]
	, c.[SSASInstanceVersion]
	, c.[SSASInstanceEdition]
	, c.[SSASInstanceConfig]
	, c.[SQLInstanceName]
	, c.[SQLInstanceVersion]
	, c.[SQLInstanceEdition]
	, c.[DatabaseName]
	, c.[CubeName]
	, c.[CubeMetadata]
	, c.[ClearCacheMode]
	, c.[Statement]
	, c.[ASQAServerVersion]
	, c.[ASQAServerConfig]
	, c.[ClientVersion]
	, c.[ClientType]
	, c.[SystemOperativeSystemName]
	, c.[SystemPhysicalMemory]
	, c.[SystemLogicalCpuCore]
FROM
	[cte] AS c
WHERE
	c.[$error_count] = 0 AND
	c.[$execution_count] = 2 AND
	c.[$cache_mode_nothing_count] = 1 AND
	c.[ClearCacheMode] != 'NOTHING'
GO

CREATE PROCEDURE [asqa].[sp_find_BatchID] 
(
	@batchID VARCHAR(36),
	@date VARCHAR(10),
	@user VARCHAR(128), 
	@server VARCHAR(128), 
	@database VARCHAR(128),
	@cube VARCHAR(128),
	@name VARCHAR(128)
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT DISTINCT
		e.[BatchID]
	FROM 
		[asqa].[vw_Execution] AS e
	WHERE		
		(NULLIF(@batchID,  '<ALL>') IS NULL OR CONVERT(VARCHAR(36), e.[BatchID]) = @batchID) AND
		(NULLIF(@date,     '<ALL>') IS NULL OR CONVERT(DATE, e.[ExecutionStartTime]) = CONVERT(VARCHAR(10), NULLIF(@date, '<ALL>'))) AND
		(NULLIF(@user,     '<ALL>') IS NULL OR e.[ConnectionUserName] = @user) AND
		(NULLIF(@server,   '<ALL>') IS NULL OR e.[SSASInstanceName] = @server) AND
		(NULLIF(@database, '<ALL>') IS NULL OR e.[DatabaseName] = @database) AND
		(NULLIF(@cube,     '<ALL>') IS NULL OR e.[CubeName] = @cube) AND
		(NULLIF(@name,     '<ALL>') IS NULL OR e.[BatchName] = @name)
END
GO

CREATE PROCEDURE [asqa].[sp_find_ConnectionUserName] 
(
	@batchID VARCHAR(36),
	@date VARCHAR(10),
	@user VARCHAR(128), 
	@server VARCHAR(128), 
	@database VARCHAR(128),
	@cube VARCHAR(128),
	@name VARCHAR(128)
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT DISTINCT
		e.[ConnectionUserName]
	FROM 
		[asqa].[vw_Execution] AS e
	WHERE
		(NULLIF(@batchID,  '<ALL>') IS NULL OR CONVERT(VARCHAR(36), e.[BatchID]) = @batchID) AND
		(NULLIF(@date,     '<ALL>') IS NULL OR CONVERT(DATE, e.[ExecutionStartTime]) = CONVERT(VARCHAR(10), NULLIF(@date, '<ALL>'))) AND
		(NULLIF(@user,     '<ALL>') IS NULL OR e.[ConnectionUserName] = @user) AND
		(NULLIF(@server,   '<ALL>') IS NULL OR e.[SSASInstanceName] = @server) AND
		(NULLIF(@database, '<ALL>') IS NULL OR e.[DatabaseName] = @database) AND
		(NULLIF(@cube,     '<ALL>') IS NULL OR e.[CubeName] = @cube) AND
		(NULLIF(@name,     '<ALL>') IS NULL OR e.[BatchName] = @name)
END
GO

CREATE PROCEDURE [asqa].[sp_find_CubeName] 
(
	@batchID VARCHAR(36),
	@date VARCHAR(10),
	@user VARCHAR(128), 
	@server VARCHAR(128), 
	@database VARCHAR(128),
	@cube VARCHAR(128),
	@name VARCHAR(128)
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT DISTINCT
		e.[CubeName]
	FROM 
		[asqa].[vw_Execution] AS e
	WHERE
		(NULLIF(@batchID,  '<ALL>') IS NULL OR CONVERT(VARCHAR(36), e.[BatchID]) = @batchID) AND
		(NULLIF(@date,     '<ALL>') IS NULL OR CONVERT(DATE, e.[ExecutionStartTime]) = CONVERT(VARCHAR(10), NULLIF(@date, '<ALL>'))) AND
		(NULLIF(@user,     '<ALL>') IS NULL OR e.[ConnectionUserName] = @user) AND
		(NULLIF(@server,   '<ALL>') IS NULL OR e.[SSASInstanceName] = @server) AND
		(NULLIF(@database, '<ALL>') IS NULL OR e.[DatabaseName] = @database) AND
		(NULLIF(@cube,     '<ALL>') IS NULL OR e.[CubeName] = @cube) AND
		(NULLIF(@name,     '<ALL>') IS NULL OR e.[BatchName] = @name)
END
GO

CREATE PROCEDURE [asqa].[sp_find_DatabaseName] 
(
	@batchID VARCHAR(36),
	@date VARCHAR(10),
	@user VARCHAR(128), 
	@server VARCHAR(128), 
	@database VARCHAR(128),
	@cube VARCHAR(128),
	@name VARCHAR(128)
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT DISTINCT
		e.[DatabaseName]
	FROM 
		[asqa].[vw_Execution] AS e
	WHERE		
		(NULLIF(@batchID,  '<ALL>') IS NULL OR CONVERT(VARCHAR(36), e.[BatchID]) = @batchID) AND
		(NULLIF(@date,     '<ALL>') IS NULL OR CONVERT(DATE, e.[ExecutionStartTime]) = CONVERT(VARCHAR(10), NULLIF(@date, '<ALL>'))) AND
		(NULLIF(@user,     '<ALL>') IS NULL OR e.[ConnectionUserName] = @user) AND
		(NULLIF(@server,   '<ALL>') IS NULL OR e.[SSASInstanceName] = @server) AND
		(NULLIF(@database, '<ALL>') IS NULL OR e.[DatabaseName] = @database) AND
		(NULLIF(@cube,     '<ALL>') IS NULL OR e.[CubeName] = @cube) AND
		(NULLIF(@name,     '<ALL>') IS NULL OR e.[BatchName] = @name)
END
GO

CREATE PROCEDURE [asqa].[sp_find_Execution] 
(
	@batchID VARCHAR(36),
	@date VARCHAR(10),
	@user VARCHAR(128), 
	@server VARCHAR(128), 
	@database VARCHAR(128),
	@cube VARCHAR(128),
	@name VARCHAR(128)
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT
		[#] = ROW_NUMBER() OVER(ORDER BY MIN(e.[ExecutionStartTime]) ASC),
		e.[BatchID],
		--e.[ExecutionID],
		e.[ExecutionStartTime],
		--e.[ExecutionError],
		[UserName] = e.[ConnectionUserName],
		e.[SSASInstanceName],
		e.[DatabaseName],
		e.[CubeName],
		--e.[ClearCacheMode],
		e.[Statement]
	FROM 
		[asqa].[vw_Execution] AS e
	WHERE
		(NULLIF(@batchID,  '<ALL>') IS NULL OR CONVERT(VARCHAR(36), e.[BatchID]) = @batchID) AND
		(NULLIF(@date,     '<ALL>') IS NULL OR CONVERT(DATE, e.[ExecutionStartTime]) = CONVERT(VARCHAR(10), NULLIF(@date, '<ALL>'))) AND
		(NULLIF(@user,     '<ALL>') IS NULL OR e.[ConnectionUserName] = @user) AND
		(NULLIF(@server,   '<ALL>') IS NULL OR e.[SSASInstanceName] = @server) AND
		(NULLIF(@database, '<ALL>') IS NULL OR e.[DatabaseName] = @database) AND
		(NULLIF(@cube,     '<ALL>') IS NULL OR e.[CubeName] = @cube) AND
		(NULLIF(@name,     '<ALL>') IS NULL OR e.[BatchName] = @name)
	GROUP BY
		e.[BatchID],
		e.[ExecutionStartTime],
		e.[ConnectionUserName],
		e.[SSASInstanceName],
		e.[DatabaseName],
		e.[CubeName],
		e.[Statement]
END
GO

CREATE PROCEDURE [asqa].[sp_find_ExecutionName] 
(
	@batchID VARCHAR(36),
	@date VARCHAR(10),
	@user VARCHAR(128), 
	@server VARCHAR(128), 
	@database VARCHAR(128),
	@cube VARCHAR(128),
	@name VARCHAR(128)
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT DISTINCT
		e.[BatchName] AS [ExecutionName]
	FROM 
		[asqa].[vw_Execution] AS e
	WHERE		
		(NULLIF(@batchID,  '<ALL>') IS NULL OR CONVERT(VARCHAR(36), e.[BatchID]) = @batchID) AND
		(NULLIF(@date,     '<ALL>') IS NULL OR CONVERT(DATE, e.[ExecutionStartTime]) = CONVERT(VARCHAR(10), NULLIF(@date, '<ALL>'))) AND
		(NULLIF(@user,     '<ALL>') IS NULL OR e.[ConnectionUserName] = @user) AND
		(NULLIF(@server,   '<ALL>') IS NULL OR e.[SSASInstanceName] = @server) AND
		(NULLIF(@database, '<ALL>') IS NULL OR e.[DatabaseName] = @database) AND
		(NULLIF(@cube,     '<ALL>') IS NULL OR e.[CubeName] = @cube) AND
		(NULLIF(@name,     '<ALL>') IS NULL OR e.[BatchName] = @name)
END
GO

CREATE PROCEDURE [asqa].[sp_find_ExecutionStartTime] 
(
	@batchID VARCHAR(36),
	@date VARCHAR(10),
	@user VARCHAR(128), 
	@server VARCHAR(128), 
	@database VARCHAR(128),
	@cube VARCHAR(128),
	@name VARCHAR(128)
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT DISTINCT
		CONVERT(VARCHAR(10), CONVERT(DATE, e.[ExecutionStartTime])) AS [ExecutionStartTime]
	FROM 
		[asqa].[vw_Execution] AS e
	WHERE		
		(NULLIF(@batchID,  '<ALL>') IS NULL OR CONVERT(VARCHAR(36), e.[BatchID]) = @batchID) AND
		(NULLIF(@date,     '<ALL>') IS NULL OR CONVERT(DATE, e.[ExecutionStartTime]) = CONVERT(VARCHAR(10), NULLIF(@date, '<ALL>'))) AND
		(NULLIF(@user,     '<ALL>') IS NULL OR e.[ConnectionUserName] = @user) AND
		(NULLIF(@server,   '<ALL>') IS NULL OR e.[SSASInstanceName] = @server) AND
		(NULLIF(@database, '<ALL>') IS NULL OR e.[DatabaseName] = @database) AND
		(NULLIF(@cube,     '<ALL>') IS NULL OR e.[CubeName] = @cube) AND
		(NULLIF(@name,     '<ALL>') IS NULL OR e.[BatchName] = @name)
END
GO

CREATE PROCEDURE [asqa].[sp_find_ServerName] 
(
	@batchID VARCHAR(36),
	@date VARCHAR(10),
	@user VARCHAR(128), 
	@server VARCHAR(128), 
	@database VARCHAR(128),
	@cube VARCHAR(128),
	@name VARCHAR(128)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT DISTINCT
		[ServerName] = e.[SSASInstanceName]
	FROM 
		[asqa].[vw_Execution] AS e
	WHERE		
		(NULLIF(@batchID,  '<ALL>') IS NULL OR CONVERT(VARCHAR(36), e.[BatchID]) = @batchID) AND
		(NULLIF(@date,     '<ALL>') IS NULL OR CONVERT(DATE, e.[ExecutionStartTime]) = CONVERT(VARCHAR(10), NULLIF(@date, '<ALL>'))) AND
		(NULLIF(@user,     '<ALL>') IS NULL OR e.[ConnectionUserName] = @user) AND
		(NULLIF(@server,   '<ALL>') IS NULL OR e.[SSASInstanceName] = @server) AND
		(NULLIF(@database, '<ALL>') IS NULL OR e.[DatabaseName] = @database) AND
		(NULLIF(@cube,     '<ALL>') IS NULL OR e.[CubeName] = @cube) AND
		(NULLIF(@name,     '<ALL>') IS NULL OR e.[BatchName] = @name)
END
GO

CREATE PROCEDURE [asqa].[sp_read_Trace]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255),
	@eventClass NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);
	
	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT 
		--[ExecutionID]
		 [ID]
		,[EventClass]
		,[EventSubclass]
		,[TextData]
		,[IntegerData]
		,[StartTime]
		,[CurrentTime]
		,[Duration]
		,[ObjectName]
		,[CpuTime]
		,[EndTime]
		,[ObjectID]
		,[ObjectPath]
		,[ObjectType]
		,[ObjectReference]
		,[ProgressTotal]
	FROM 
		[asqa].[Trace]
	WHERE
		[ExecutionID] = @executionID AND
		[EventClass] = @eventClass;
END
GO

CREATE PROCEDURE [asqa].[sp_read_CommonPartitionsRead]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);

	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT 
		--[ExecutionID]
		 [CubeID]
		,[MeasureGroupID]
		,[PartitionID]
		,[PartitionName]
		,[PartitionHit]
		,[PartitionDuration]
		,[PartitionDurationRatio]
	FROM 
		[asqa].[CommonPartitionsRead]
	WHERE
		[ExecutionID] = @executionID;
END
GO

CREATE PROCEDURE [asqa].[sp_read_CommonEnginePerformance]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);
	
	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT
		--[ExecutionID]
		 [QueryDuration]
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
	FROM
		[asqa].[CommonEnginePerformance]
	WHERE
		[ExecutionID] = @executionID;
END
GO

CREATE PROCEDURE [asqa].[sp_read_CommonCachesRead]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);

	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT 
		--[ExecutionID]
		 [CacheType]
		,[CacheSubType]
	FROM 
		[asqa].[CommonCachesRead]
	WHERE
		[ExecutionID] = @executionID;
END
GO

CREATE PROCEDURE [asqa].[sp_read_CommonAggregationsRead]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);
	
	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT 
		--[ExecutionID]
		 [CubeID]
		,[MeasureGroupID]
		,[PartitionID]
		,[AggregationID]
		,[AggregationName]
		,[AggregationHit]
		,[AggregationDuration]
		,[AggregationDurationRatio]
	FROM 
		[asqa].[CommonAggregationsRead]
	WHERE
		[ExecutionID] = @executionID;
END
GO

CREATE PROCEDURE [asqa].[sp_read_Performance]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255),
	@categoryName NVARCHAR(255),
	@counterName NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);
	
	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT
		 [TraceEventTime]
		,[Value]
	FROM 
		[asqa].[Performance]
	WHERE
		[ExecutionID] = @executionID AND
		[CategoryName] = @categoryName AND
		[CounterName] = @counterName;
END
GO

CREATE PROCEDURE [asqa].[sp_read_ExecutionInfo]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);
	
	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT [key] = CONVERT(NVARCHAR(256), 'connection_user_name'),         [value] = CONVERT(NVARCHAR(256), e.[ConnectionUserName])        FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'execution_start_time'),         [value] = CONVERT(NVARCHAR(256), e.[ExecutionStartTime], 121)   FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'execution_end_time'),           [value] = CONVERT(NVARCHAR(256), e.[ExecutionEndTime], 121)     FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'asqa_server_version'),          [value] = CONVERT(NVARCHAR(256), e.[ASQAServerVersion])         FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'asqa_server_config'),           [value] = CONVERT(NVARCHAR(MAX), e.[ASQAServerConfig])          FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'client_version'),               [value] = CONVERT(NVARCHAR(256), e.[ClientVersion])             FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'client_type'),                  [value] = CONVERT(NVARCHAR(256), e.[ClientType])                FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'batch_id'),                     [value] = CONVERT(NVARCHAR(256), e.[BatchID])                   FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'batch_name'),                   [value] = CONVERT(NVARCHAR(256), e.[BatchName])                 FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'ssas_instance_name'),           [value] = CONVERT(NVARCHAR(256), e.[SSASInstanceName])          FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'ssas_instance_version'),        [value] = CONVERT(NVARCHAR(256), e.[SSASInstanceVersion])       FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'ssas_instance_edition'),        [value] = CONVERT(NVARCHAR(256), e.[SSASInstanceEdition])       FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'ssas_instance_config'),         [value] = CONVERT(NVARCHAR(MAX), e.[SSASInstanceConfig])        FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'sql_instance_name'),            [value] = CONVERT(NVARCHAR(256), e.[SQLInstanceName])           FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'sql_instance_version'),         [value] = CONVERT(NVARCHAR(256), e.[SQLInstanceVersion])        FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'sql_instance_edition'),         [value] = CONVERT(NVARCHAR(256), e.[SQLInstanceEdition])        FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'statement'),                    [value] = CONVERT(NVARCHAR(MAX), e.[Statement])                 FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'database_name'),                [value] = CONVERT(NVARCHAR(256), e.[DatabaseName])              FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'cube_name'),                    [value] = CONVERT(NVARCHAR(256), e.[CubeName])	               FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'cube_metadata'),                [value] = CONVERT(NVARCHAR(MAX), e.[CubeMetadata])              FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'system_operative_system_name'), [value] = CONVERT(NVARCHAR(256), e.[SystemOperativeSystemName]) FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'system_physical_memory'),       [value] = CONVERT(NVARCHAR(256), e.[SystemPhysicalMemory])      FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID UNION
	SELECT [key] = CONVERT(NVARCHAR(256), 'system_logical_cpu_core'),      [value] = CONVERT(NVARCHAR(256), e.[SystemLogicalCpuCore])      FROM [asqa].[Execution] AS e WHERE e.[ExecutionID] = @executionID;
END
GO

CREATE PROCEDURE [asqa].[sp_read_PerformanceTypes]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);
	
	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT
		[CategoryName],
		[CounterName]
	FROM 
		[asqa].[Performance]
	WHERE
		[ExecutionID] = @executionID
	GROUP BY
		[CategoryName],
		[CounterName];
END
GO

CREATE PROCEDURE [asqa].[sp_read_TraceTypes]
	@batchID UNIQUEIDENTIFIER,
	@clearCacheMode NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF (@clearCacheMode = 'DEFAULT')
	BEGIN
        SELECT 
			@clearCacheMode = [ClearCacheMode] 
		FROM
			[asqa].[vw_Execution]
		WHERE 
			[BatchID] = @batchID
    END

	DECLARE @executionID UNIQUEIDENTIFIER = 
	(
		SELECT 
			[ExecutionID]
		FROM 
			[asqa].[Execution]
		WHERE 
			[BatchID] = @batchID AND [ClearCacheMode] = @clearCacheMode
	);
	
	IF (@executionID IS NULL)
	BEGIN
        RAISERROR('@executionID is null', 16, 1)
        RETURN
    END

	SELECT 
		[EventClass]
	FROM 
		[asqa].[Trace]
	WHERE
		[ExecutionID] = @executionID
	GROUP BY
		[EventClass];
END
GO