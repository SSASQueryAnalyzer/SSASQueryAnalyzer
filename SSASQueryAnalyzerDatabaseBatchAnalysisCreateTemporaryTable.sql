CREATE TABLE [asqa].[#Trace_{0}_{1}]
(
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
	[TextData] [nvarchar](max) NULL
)
GO