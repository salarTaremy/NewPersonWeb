SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[View_Anbar] As 

SELECT CAST(311 AS BIGINT) [Code_Anbar],N'مرکزی' [Name_Anbar],N'News_Mahsol' [Name_News],[Code_kala],[sharh],[sharh_koli],[Tarikh_sodor],CAST([Shomareh] AS BIGINT)[Shomareh],[Vahed],[Meghdar_vahed],[Tedad_vahed],[Meghdar_kol_riali],[Meghdar_kol_tedadi],[Fee],[Noae_bastehbandi],[Code_hesabdari],[code_ghabz_havaleh],[Code_noae],[Tarikhe_tolid],[Tarikh_engheza],[Shomareh_seri_sakht],[Shomareh_mixer],[Name_sherkat_sazandeh],[Shomareh_darkhast],[Shomareh_factor],[Tarikh_vorod_factory],[Shomareh_tank],[Code_vizitor],[Code_moshtary],[Taghir_Factor],[shomareh_sanad],[temp1],[temp2],[temp3],[temp4],[lock],[Flag_edit],[User_Edit],[active],[username],[machine],[date_time],[Rate],[Darsad_Takhfif_Saderat],[Takhfif_Saderat],[Add_Saderat],[Darsad_Add_Saderat],[Code_Elmi],[Lab_NO],[Groh],[Flag_Dasti],[Noae_Moshtari],[Flag_Shamsi_Or_Miladi],[Ghymat_Masraf_konandeh],[Flag_Re_Check],[Code_Dakheli_News],[Code_Daru],[Shomareh_sakht],[Counter],[Arzesh_afzodeh] FROM News_Mahsol






GO
