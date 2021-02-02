CREATE TABLE [dbo].[item_kala_factor]
(
[shomareh_darkhast] [nvarchar] (11) COLLATE Persian_100_CI_AS NULL,
[shomareh_serial_darkhast] [nvarchar] (11) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[code_kala] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[tedad_dar_karton] [int] NOT NULL,
[tedad_dar_shiling] [int] NOT NULL,
[botr_sefaresh] [int] NOT NULL,
[karton_sefaresh] [int] NOT NULL,
[jayezeh] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[darsad_takhfif_jenci] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[darsad_takhfif_naghdi] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[darsad_takhfif_noe] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[ghemat] [bigint] NULL,
[noae_kala] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[seri_sakht] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[sharh] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[shomareh_taghir] [int] NULL,
[vazit_tahvil] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[code_noae] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[noae] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL CONSTRAINT [DF_item_kala_factor ] DEFAULT ('01'),
[active] [bit] NULL,
[username] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[machine] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[date_time] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Tarikhe_tolid] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Tarikh_engheza] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Name_sherkat_sazandeh] [nvarchar] (70) COLLATE Persian_100_CI_AS NULL,
[Flag_Shamsi_Or_Miladi] [bit] NULL,
[Shomareh_seri_sakht] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Ghymat_Masraf_konandeh] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Code_Dakheli_News] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Code_Daru] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Counter] [bigint] NOT NULL IDENTITY(1, 1),
[IsManualOffer] [bit] NULL,
[StartTime] [datetime2] NOT NULL CONSTRAINT [DF__item_kala__Start__5CA1C101] DEFAULT (sysutcdatetime()),
[EndTime] [datetime2] NOT NULL CONSTRAINT [DF__item_kala__EndTi__5D95E53A] DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999',(0))),
[AppName] [nvarchar] (1000) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[meghdar_kol_tedad] [bigint] NULL,
[Mab_Kol] [bigint] NULL,
[Meghdar_Kol_Tedadi] [bigint] NULL,
[Meghdar_Kol_Riali] [bigint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[item_kala_factor] ADD CONSTRAINT [CK_LenShomareItem] CHECK ((len([shomareh_serial_darkhast])>(7)))
GO
ALTER TABLE [dbo].[item_kala_factor] ADD CONSTRAINT [PK_item_kala_factor] PRIMARY KEY NONCLUSTERED  ([Counter]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
