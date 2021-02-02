CREATE TABLE [dbo].[Item_factor]
(
[shomareh_factor] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[shomareh_darkhast] [nvarchar] (11) COLLATE Persian_100_CI_AS NULL,
[shomareh_serial_darkhast] [nvarchar] (11) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[code_kala] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[tedad_dar_karton] [nvarchar] (4) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[tedad_dar_shiling] [nvarchar] (4) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[botr_sefaresh] [nvarchar] (5) COLLATE Persian_100_CI_AS NULL,
[karton_sefaresh] [nvarchar] (5) COLLATE Persian_100_CI_AS NULL,
[jayezeh] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[darsad_takhfif_jenci] [nvarchar] (6) COLLATE Persian_100_CI_AS NULL,
[darsad_takhfif_naghdi] [nvarchar] (6) COLLATE Persian_100_CI_AS NULL,
[darsad_takhfif_noe] [nvarchar] (6) COLLATE Persian_100_CI_AS NULL,
[ghemat] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[noae_kala] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[seri_sakht] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[sharh] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[shomareh_taghir] [int] NULL,
[vazit_tahvil] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[code_noae] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[noae] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[active] [bit] NULL,
[username] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[machine] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[date_time] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Tarikhe_tolid] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Tarikh_engheza] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Shomareh_seri_sakhtTarikhe_tolid] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Shomareh_seri_sakht] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Sherkat_sazandeh] [nvarchar] (100) COLLATE Persian_100_CI_AS NULL,
[Flag_Shamsi_Or_Miladi] [bit] NULL,
[Ghymat_Masraf_konandeh] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Code_Noae_Moshtari] [nvarchar] (5) COLLATE Persian_100_CI_AS NULL,
[Code_Groh_Moshtari] [nvarchar] (5) COLLATE Persian_100_CI_AS NULL,
[Code_Moshtari_Hesab] [nvarchar] (11) COLLATE Persian_100_CI_AS NULL,
[Code_Moshtari_Forosh] [nvarchar] (7) COLLATE Persian_100_CI_AS NULL,
[tarikh_Item] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[code_Vizitor_item] [nvarchar] (5) COLLATE Persian_100_CI_AS NULL,
[Code_Dakheli_News] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Code_Daru] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Modat_Vosol] [int] NULL,
[Counter] [bigint] NOT NULL,
[arzesh_afzode] [int] NULL CONSTRAINT [DF_Item_factor_arzesh_afzode] DEFAULT ((9)),
[AppName] [nvarchar] (128) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[Mab_Kol] [decimal] (38, 0) NULL,
[Darsad_Takhfif] [decimal] (8, 2) NULL,
[Meghdar_Kol_Tedad] [bigint] NULL,
[Mablagh_Takhfif] [decimal] (38, 0) NULL,
[Mablagh_Kol_PasAz_Takhfif] [decimal] (38, 0) NULL,
[Jame_Maliat_Avarez] [bigint] NULL,
[Mablagh_khales] [decimal] (38, 0) NULL,
[HistoryAppName] [nvarchar] (128) COLLATE Persian_100_CI_AS NULL,
[HistoryDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Item_factor] ADD CONSTRAINT [ChkSerial8] CHECK (([shomareh_serial_darkhast] IS NOT NULL))
GO
ALTER TABLE [dbo].[Item_factor] ADD CONSTRAINT [PK_Item_factor] PRIMARY KEY CLUSTERED  ([Counter]) ON [PRIMARY]
GO
