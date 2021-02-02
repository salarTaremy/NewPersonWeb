CREATE TABLE [dbo].[name_noae_groh_moshtary]
(
[code] [nvarchar] (3) COLLATE Persian_100_CI_AS_SC_UTF8 NOT NULL,
[name_groh] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[code_moshakhas_konnande] [nvarchar] (2) COLLATE Persian_100_CI_AS_SC_UTF8 NOT NULL,
[username] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[machine] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[date_time] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[active] [bit] NULL,
[Counter] [bigint] NOT NULL IDENTITY(1, 1),
[Code_Tafsil] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[GLN] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[PostalCode] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[BranchTypeName] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[ShebaNumber] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[ID] AS (CONVERT([smallint],[code_moshakhas_konnande]+right(concat('00',[code]),(3)),(0))) PERSISTED NOT NULL,
[IDTafsil] [bigint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[name_noae_groh_moshtary] ADD CONSTRAINT [PK__name_noa__3214EC270DCEC3C2] PRIMARY KEY CLUSTERED  ([ID]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
