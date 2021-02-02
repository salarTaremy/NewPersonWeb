SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE  proc  [Web].[GetRelatedProduct] 

@ssn  varchar(10)  = null
,@ProductID  bigint = null
,@MaxCount  int = 10

--declare @ssn  varchar(10) ='0072374586'
--declare @ProductID  bigint = 48514852034

As
	

Declare @Today  nvarchar(10)=  (SELECT Pr_DateDisplay FROM dbo.Clander WHERE gr_date = CAST(GetDate() AS date))
Declare @CodeNoae nvarchar(5) = (SELECT TOP(1) noae from moshtari WITH (NOLOCK) WHERE active = 1 AND groh = '32' AND Code_meli = @ssn)
DECLARE @MaxPerDayCount SMALLINT	= (SELECT Value FROM Web.Settings WHERE ID = 1)
DECLARE @DayCount		TINYINT		= (SELECT Value FROM Web.Settings WHERE ID = 2)
--═════════════════════════════════════════════════════════════════════
--							Update Product Rate
--═════════════════════════════════════════════════════════════════════
if Exists (	Select	Top(1) * 
			From	Web.ProductRate
			Where	LastUpdate <> cast(GETDATE() as date )		
			)
Begin
	Begin tran 
	Begin Try
		Delete	Web.ProductRate
		Where	1=1
		insert Web.ProductRate(ID_Product,Rate)
		SELECT	km.ID 
				, NTILE(5) OVER (ORDER BY SUM( it.Meghdar_Kol_Tedad )) AS Rate
		FROM	dbo.Factor F WITH(NOLOCK)
				INNER JOIN dbo.Item_factor it  WITH(NOLOCK)
					ON it.active = 1
					AND it.shomareh_serial_darkhast = F.shomareh_serial
					AND it.noae_kala IN (1,7,8)
				INNER JOIN dbo.Kala_Mahsol km  
					ON km.active = 1
					AND km.Code COLLATE Persian_100_CI_AS = it.code_kala
		WHERE	F.active = 1 
				AND F.noae_factor = '1'
				AND F.tarikh >= '1399/03/01'
		GROUP BY km.id
		commit
	End try
	begin catch
		rollback
	End Catch
End


--═════════════════════════════════════════════════════════════════════
--							Get Product Group ID
--═════════════════════════════════════════════════════════════════════
Declare @GroupID smallint = 0
select @GroupID = gr.id 
from Kala_Mahsol km
	INNER JOIN Tejari_Grop br WITH(NOlock) 
		on br.active = 1 
		and br.code = LEFT(km.code , 2) 
		and br.code_moshakhas_konnande = '1'
	INNER JOIN Tejari_Grop Gr WITH(NOlock) 
		on gr.active = 1 
		and gr.code =  substring(km.code,3 , 2) 
		and gr.code_moshakhas_konnande = '2'
		and gr.name <> '-'
where km.active = 1
and km.ID = @ProductID
--═════════════════════════════════════════════════════════════════════
--							Basket
--═════════════════════════════════════════════════════════════════════
DROP TABLE  IF EXISTS #Basket
select Dt.ID_Product  , Dt.Qty 
into  #Basket
from Web.Basket B
inner join Web.BasketDetail Dt on B.ID = Dt.ID_Basket
where B.OrderID is null
and B.Ssn = @ssn

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


DROP TABLE  IF EXISTS #Base 
select 	Top (@MaxCount) km.ID
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
		,HaveTax
		,ExistInBasket = cast(ISNULL(B.Qty , 0)   as bit)
		,BuyHistoryCount = 0
		,FavoriteCount = 0
		,Rate = isnull(R.Rate,1)
from Kala_Mahsol km
	INNER JOIN Tejari_Grop br WITH(NOlock) 
		on br.active = 1 
		and br.code = LEFT(km.code , 2) 
		and br.code_moshakhas_konnande = '1'
	INNER JOIN Tejari_Grop Gr WITH(NOlock) 
		on gr.active = 1 
		and gr.code =  substring(km.code,3 , 2) 
		and gr.code_moshakhas_konnande = '2'
		and gr.name <> '-'
	INNER JOIN tedad td WITH(NOlock) 
		on td.active = 1
		and td.code  collate Persian_100_CI_AS = km.Code_tedad  
	INNER JOIN #fo fo 
		ON fo.code_kala = km.Code
	Left Join #Basket b 
		on b.ID_Product = km.id
	left join Web.FavoriteProduct Fv
		on fv.id_product = km.id
	left join Web.ProductRate R
		on R.id_product = km.id
	LEFT JOIN Web.ProductCeiling  PC
		ON PC.ID_Product = km.ID
where km.active = 1
and km.ID <> @ProductID
and gr.ID = @GroupID


GO
