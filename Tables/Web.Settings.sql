CREATE TABLE [Web].[Settings]
(
[ID] [int] NOT NULL,
[Name] [nvarchar] (100) COLLATE Persian_100_CI_AS NULL,
[Value] [bigint] NULL,
[StringValue] [nvarchar] (300) COLLATE Persian_100_CI_AS NULL,
[Description] [nvarchar] (300) COLLATE Persian_100_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [Web].[Settings] ADD CONSTRAINT [PK__Settings__3214EC270AD8A7E2] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
