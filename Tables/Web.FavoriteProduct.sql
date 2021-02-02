CREATE TABLE [Web].[FavoriteProduct]
(
[ID] [int] NOT NULL IDENTITY(1000, 1),
[ssn] [varchar] (10) COLLATE Persian_100_CI_AS_SC_UTF8 NOT NULL,
[ID_Product] [bigint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [Web].[FavoriteProduct] ADD CONSTRAINT [PK_FavoriteProduct] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [un_fav_ssn_pr] ON [Web].[FavoriteProduct] ([ssn], [ID_Product]) ON [PRIMARY]
GO
