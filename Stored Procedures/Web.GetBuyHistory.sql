SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROC [Web].[GetBuyHistory]

@ID_Product BIGINT = 48575056005
,@Ssn VARCHAR(10)  = '0072374586'
 As

DECLARE @Code			VARCHAR(10) 
DECLARE @MaxPerDayCount SMALLINT
DECLARE @DayCount		TINYINT 
Declare @Today			VARCHAR(10)=  (SELECT Pr_DateDisplay FROM dbo.Clander WHERE gr_date = CAST(GetDate() AS date))

SELECT	@Code  = Code
FROM	dbo.Kala_Mahsol 
WHERE	active = 1 
		AND ID = @ID_Product

SELECT	@MaxPerDayCount = MaxPerDayCount
		,@DayCount =  DayCount
FROM	Web.ProductCeiling
WHERE	ID_Product =@ID_Product

SELECT	@MaxPerDayCount = ISNULL(@MaxPerDayCount,Value) 
FROM	web.Settings  
WHERE	ID = 1

SELECT	@DayCount = ISNULL(@DayCount,Value) 
FROM	web.Settings  
WHERE	ID = 2


SET @DayCount = 200
Declare @TodayAgo			VARCHAR(10)=  ( SELECT Pr_DateDisplay FROM dbo.Clander WHERE DayCounter = (SELECT DayCounter -@DayCount  FROM dbo.Clander WHERE gr_date = CAST(GetDate() AS date)) )



SELECT	ISNULL(SUM(it.Meghdar_Kol_Tedadi),0)  BuyQty
		,DayCount = @DayCount
		,MaxPerDayCount = @MaxPerDayCount
		,RemainingQty = @MaxPerDayCount -ISNULL(SUM(it.Meghdar_Kol_Tedadi),0)
FROM	dbo.darkhast D
		INNER JOIN dbo.moshtari M
			ON m.active = 1
				AND m.code = D.code_foroshghah
				AND m.noae = D.code_noae
				AND m.Code_meli = @ssn
				AND m.groh = '32'
		INNER JOIN dbo.item_kala_factor it
			ON it.active = 1
			AND it.shomareh_serial_darkhast COLLATE Persian_100_CI_AS = D.shomareh_serial
			AND it.noae_kala IN ('1','7','8')
		INNER JOIN dbo.Kala_Mahsol Km
			ON km.active = 1 
			AND km.Code = it.code_kala
WHERE	1=1
		AND D.active = 1
		AND Km.ID = @ID_Product
		AND d.tarikh >= @TodayAgo
		
	

GO
