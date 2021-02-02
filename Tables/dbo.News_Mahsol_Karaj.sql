CREATE TABLE [dbo].[News_Mahsol_Karaj]
(
[Code_kala] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[sharh] [nvarchar] (200) COLLATE Persian_100_CI_AS NULL,
[sharh_koli] [nvarchar] (200) COLLATE Persian_100_CI_AS NULL,
[Tarikh_sodor] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Shomareh] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Vahed] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Meghdar_vahed] [decimal] (18, 5) NULL,
[Tedad_vahed] [decimal] (18, 5) NULL,
[Meghdar_kol_riali] [decimal] (18, 2) NULL,
[Meghdar_kol_tedadi] [decimal] (18, 5) NULL,
[Fee] [decimal] (12, 2) NULL,
[Noae_bastehbandi] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Code_hesabdari] [nvarchar] (20) COLLATE Persian_100_CI_AS NULL,
[code_ghabz_havaleh] [nvarchar] (3) COLLATE Persian_100_CI_AS NULL,
[Code_noae] [nvarchar] (3) COLLATE Persian_100_CI_AS NULL,
[Tarikhe_tolid] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Tarikh_engheza] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Shomareh_seri_sakht] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Shomareh_mixer] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Name_sherkat_sazandeh] [nvarchar] (70) COLLATE Persian_100_CI_AS NULL,
[Shomareh_darkhast] [nvarchar] (11) COLLATE Persian_100_CI_AS NULL,
[Shomareh_factor] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Tarikh_vorod_factory] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Shomareh_tank] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Code_vizitor] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[Code_moshtary] [nvarchar] (20) COLLATE Persian_100_CI_AS NULL,
[Taghir_Factor] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[shomareh_sanad] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[temp1] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[temp2] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[temp3] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[temp4] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[Flag_edit] [int] NULL,
[User_Edit] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[lock] [bit] NULL,
[active] [bit] NULL,
[username] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[machine] [nvarchar] (40) COLLATE Persian_100_CI_AS NULL,
[date_time] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[Code_Elmi] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[Lab_NO] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Groh] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[Flag_Dasti] [bit] NULL,
[Noae_Moshtari] [nvarchar] (4) COLLATE Persian_100_CI_AS NULL,
[Darsad_Takhfif_Saderat] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Takhfif_Saderat] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Add_Saderat] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Darsad_Add_Saderat] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Flag_Shamsi_Or_Miladi] [bit] NULL,
[Ghymat_Masraf_konandeh] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Counter] [bigint] NOT NULL IDENTITY(1, 1),
[Flag_Re_Check] [bit] NULL,
[Shomareh_sakht] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Code_Dakheli_News] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Code_Daru] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Rate] [nvarchar] (10) COLLATE Persian_100_CI_AS NULL,
[Arzesh_afzodeh] [decimal] (18, 0) NULL,
[QC] [bit] NULL,
[QC_UserSubmit] [nvarchar] (30) COLLATE Persian_100_CI_AS NULL,
[QC_DateSubmit] [nvarchar] (50) COLLATE Persian_100_CI_AS NULL,
[AppName] [nvarchar] (max) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[Endtime] [nvarchar] (max) COLLATE Persian_100_CI_AS_SC_UTF8 NULL,
[starttime] [nvarchar] (max) COLLATE Persian_100_CI_AS_SC_UTF8 NULL
) ON [PRIMARY]
GO
