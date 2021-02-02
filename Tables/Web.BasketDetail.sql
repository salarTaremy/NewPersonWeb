CREATE TABLE [Web].[BasketDetail]
(
[ID] [int] NOT NULL IDENTITY(1000, 1),
[ID_Basket] [int] NOT NULL,
[ID_Product] [bigint] NOT NULL,
[CreateDate] [datetime] NULL CONSTRAINT [DF__BasketDet__Creat__5BE2A6F2] DEFAULT (getdate()),
[Qty] [smallint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [Web].[BasketDetail] ADD CONSTRAINT [PK__BasketDe__3214EC273F70844B] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [ID_Basket_ID_Product] ON [Web].[BasketDetail] ([ID_Basket], [ID_Product]) ON [PRIMARY]
GO
ALTER TABLE [Web].[BasketDetail] ADD CONSTRAINT [FK__BasketDet__ID_Ba__5AEE82B9] FOREIGN KEY ([ID_Basket]) REFERENCES [Web].[Basket] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
