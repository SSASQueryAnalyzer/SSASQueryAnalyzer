/* T-SQL Script for SQL Azure Database */

/*
** Manually connect to [Master] db and the run this command 
*/

USE [master]
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE [name] = N'ASQA')
BEGIN
	CREATE DATABASE [ASQA];
END
GO

/*
** Manually connect to [ASQA] db and the run all the following commands 
*/

USE [ASQA]
GO

EXEC sys.sp_addextendedproperty @name=N'ASQA_DatabaseVersion', @value=N'0.1.0' 
GO