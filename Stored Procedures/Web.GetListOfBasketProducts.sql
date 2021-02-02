SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROC [Web].[GetListOfBasketProducts]
		@Ssn NVARCHAR(10) = '0072374586'
		As


		WAITFOR DELAY '00:00:01:00'


Declare @Today  nvarchar(10)=  (SELECT Pr_DateDisplay FROM dbo.Clander WHERE gr_date = CAST(GetDate() AS date))
Declare @CodeNoae nvarchar(5) = (SELECT TOP(1) noae from moshtari WITH (NOLOCK) WHERE active = 1 AND groh = '32' AND Code_meli = @ssn)
DECLARE @MaxPerDayCount SMALLINT	= (SELECT Value FROM Web.Settings WHERE ID = 1)
DECLARE @DayCount		TINYINT		= (SELECT Value FROM Web.Settings WHERE ID = 2)

DROP TABLE  IF EXISTS #fo 
SELECT TOP(1)  WITH TIES
	fo.code_kala
	, CAST(REPLACE(fo.ghemat ,',','') AS BIGINT) ghemat 
	, CAST(REPLACE(Ghymat_Masraf_konandeh ,',','') AS BIGINT) Ghymat_Masraf_konandeh 
	,  case fo.code_groh_kala when '1' then cast(1 as bit) else cast(0 as bit) End   HaveTax
INTO #fo
from Fee_omomi fo WITH(NOlock)
where fo.active = 1
	and fo.lock = 0
	and  @Today between start_date and end_date
	and groh_moshtary = '32'
	and code_noae collate Persian_100_CI_AS = @CodeNoae
ORDER BY ROW_NUMBER() OVER (PARTITION BY fo.code_kala, fo.ghemat , fo.Ghymat_Masraf_konandeh ORDER BY fo.code_groh_kala  DESC)

UPDATE #fo SET Ghymat_Masraf_konandeh = ghemat  WHERE  Ghymat_Masraf_konandeh < ghemat


-------------------------------------------------------------------------------
--DELETE Product From Basket IF Is Locked OR NOT Avalable
DELETE Dt
FROM	Web.Basket B
		INNER JOIN Web.BasketDetail Dt
			ON Dt.ID_Basket = B.ID
		INNER JOIN dbo.Kala_Mahsol Km
			ON km.active = 1 
			AND Km.ID = Dt.ID_Product
		LEFT JOIN #fo fo 
			ON fo.code_kala = km.Code
WHERE 1=1
AND fo.code_kala IS NULL

--------------------------------------------------------------------------------
DECLARE @Tax int = (SELECT Value FROM Web.Settings WHERE ID = 3)

SELECT	Dt.ID_Basket
		,km.ID
		,Code = km.code
		,name = km.Name
		,BrandName = br.name
		,GroupName = gr.name 
		,BrandID = br.ID
		,GroupID = gr.ID 
		,Weight = km.Vazn
		,price = fo.ghemat 
		,ConsumerPrices = fo.Ghymat_Masraf_konandeh
		,MaxPerDayCount  = ISNULL(pc.MaxPerDayCount,@MaxPerDayCount)
		,DayCount = ISNULL(pc.DayCount,@DayCount)
		,CountInBox = td.Meghdar_Kol_Tedad
		,IsFavorite = cast(ISNULL(fv.id , 0)   as bit)
		,CountInBasket = 0
		,Rate = isnull(R.Rate,1)
		,HaveTax
		,TaxPercentage = IIF(fo.HaveTax= 1,@Tax,0)
		,Qty = Dt.Qty
FROM	Web.Basket B
		INNER JOIN Web.BasketDetail Dt
			ON Dt.ID_Basket = B.ID
		INNER JOIN dbo.Kala_Mahsol Km
			ON km.active = 1 
			AND Km.ID = Dt.ID_Product
		INNER JOIN Tejari_Grop br WITH(NOLOCK) 
			on br.active = 1 
			and br.code = LEFT(km.code , 2) 
			and br.code_moshakhas_konnande = '1'
		INNER JOIN Tejari_Grop Gr WITH(NOLOCK) 
			on gr.active = 1 
			and gr.code =  substring(km.code,3 , 2) 
			and gr.code_moshakhas_konnande = '2'
		INNER JOIN tedad td WITH(NOlock) 
			on td.active = 1
			and td.code  collate Persian_100_CI_AS = km.Code_tedad  
		INNER JOIN #fo fo 
			ON fo.code_kala = km.Code
		LEFT join Web.ProductRate R
			ON R.id_product = km.id
		LEFT join Web.FavoriteProduct Fv
			ON fv.id_product = km.id
		LEFT JOIN Web.ProductCeiling  PC
			ON PC.ID_Product = km.ID
WHERE	1=1
		AND		OrderID IS NULL 
		AND		B.Ssn  = @Ssn
ORDER BY Dt.ID_Product












GO
