USE [master]
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE [name] = N'ASQA')
BEGIN
	CREATE DATABASE [ASQA];
	ALTER  DATABASE [ASQA] MODIFY FILE (NAME = N'ASQA', FILEGROWTH = 65536KB);
END
GO

USE [ASQA]
GO

EXEC sys.sp_addextendedproperty @name=N'ASQA_DatabaseVersion', @value=N'0.1.0' 
GO