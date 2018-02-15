USE [ASQA]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_CommonAggregationsRead]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_CommonAggregationsRead];
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_CommonCachesRead]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_CommonCachesRead];
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_CommonEnginePerformance]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_CommonEnginePerformance];
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_CommonPartitionsRead]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_CommonPartitionsRead];
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_Performance]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_Performance];
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_Trace]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_Trace];
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_ExecutionInfo]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_ExecutionInfo];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_PerformanceTypes]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_PerformanceTypes];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_read_TraceTypes]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_read_TraceTypes];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_find_BatchID]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_find_BatchID];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_find_ConnectionUserName]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_find_ConnectionUserName];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_find_CubeName]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_find_CubeName];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_find_DatabaseName]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_find_DatabaseName];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_find_Execution]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_find_Execution];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_find_ExecutionName]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_find_ExecutionName];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_find_ExecutionStartTime]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_find_ExecutionStartTime];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[sp_find_ServerName]') AND type IN (N'P', N'PC'))
   DROP PROCEDURE [asqa].[sp_find_ServerName];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[asqa].[vw_Execution]') AND type IN (N'V'))
	DROP VIEW [asqa].[vw_Execution];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[Execution]') AND type IN (N'U'))
   DROP TABLE [asqa].[Execution];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[Performance]') AND type IN (N'U'))
   DROP TABLE [asqa].[Performance];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[Trace]') AND type IN (N'U'))
   DROP TABLE [asqa].[Trace];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[CommonEnginePerformance]') AND type IN (N'U'))
   DROP TABLE [asqa].[CommonEnginePerformance];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[CommonCachesRead]') AND type IN (N'U'))
   DROP TABLE [asqa].[CommonCachesRead];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[CommonPartitionsRead]') AND type IN (N'U'))
   DROP TABLE [asqa].[CommonPartitionsRead];
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[asqa].[CommonAggregationsRead]') AND type IN (N'U'))
   DROP TABLE [asqa].[CommonAggregationsRead];
GO

IF EXISTS (SELECT * FROM sys.extended_properties WHERE [class] = 0 AND [name] = N'ASQA_DatabaseVersion')
	EXEC sys.sp_dropextendedproperty @name=N'ASQA_DatabaseVersion' 
GO

IF EXISTS (SELECT * FROM sys.schemas WHERE name = N'asqa')
   DROP SCHEMA [asqa];
GO