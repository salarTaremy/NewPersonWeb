CREATE TABLE [Web].[ProductRate]
(
[ID_Product] [bigint] NULL,
[Rate] [tinyint] NULL,
[LastUpdate] [date] NOT NULL CONSTRAINT [DF__ProductRa__LastU__40058253] DEFAULT (CONVERT([date],getdate(),(0)))
) ON [PRIMARY]
GO
