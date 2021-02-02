CREATE TABLE [Web].[ProductCeiling]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[ID_Product] [bigint] NOT NULL,
[MaxPerDayCount] [smallint] NOT NULL CONSTRAINT [DF__ProductCe__MaxPe__56B3DD81] DEFAULT ((10)),
[DayCount] [tinyint] NOT NULL CONSTRAINT [DF__ProductCe__DayCo__57A801BA] DEFAULT ((1)),
[Description] [nvarchar] (300) COLLATE Persian_100_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [Web].[ProductCeiling] ADD CONSTRAINT [PK__ProductC__3214EC2705E392DB] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [Ix_Un_ProductCeiling_ProductID] ON [Web].[ProductCeiling] ([ID_Product]) ON [PRIMARY]
GO
