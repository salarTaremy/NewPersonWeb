SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE  proc  [Web].[GetProductListPerSsnCode] 
--   [Web].[GetProductListPerSsnCode]  '0072374586'

--create type IntArray  as table (Value int) 

@ssn  varchar(10) =''
,@sortOrder int = 0
,@countInPage int = 15
,@curentPgae int= 1
,@keyword  nvarchar(max) = null
,@GroupID  int = 0
,@Brands IntArray readonly
	
As 
DECLARE @MaxPerDayCount SMALLINT	= (SELECT Value FROM Web.Settings WHERE ID = 1)
DECLARE @DayCount		TINYINT		= (SELECT Value FROM Web.Settings WHERE ID = 2)
Declare @Today  nvarchar(10)=  (SELECT Pr_DateDisplay FROM dbo.Clander WHERE gr_date = CAST(GetDate() AS date))
Declare @CodeNoae nvarchar(5) = (SELECT TOP(1) noae from moshtari WITH (NOLOCK) WHERE active = 1 AND groh = '32' AND Code_meli = @ssn)
Declare @OFFSET int= (@CountInPage * @CurentPgae) - @CountInPage
Declare @cnt  int 

set @keyword = REPLACE(@keyword, NCHAR(1610), NCHAR(1740))
set @keyword = REPLACE(@keyword, NCHAR(1603), NCHAR(1705))

set @keyword = REPLACE(@keyword,'ي','ی')
set @keyword = REPLACE(@keyword,'ك','ک')


--WAITFOR DELAY '00:00:01';
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

--UPDATE	#fo 
--SET		Ghymat_Masraf_konandeh = ghemat  
--WHERE	Ghymat_Masraf_konandeh < ghemat

Delete	#fo   
WHERE	Ghymat_Masraf_konandeh  < ghemat + (ghemat * IIF( HaveTax = 1,9,0) / 100)



DROP TABLE  IF EXISTS #Base 
select 	km.ID
		,SortOrder_0 = ROW_NUMBER()  Over(order by km.code) 
		,SortOrder_1 = ROW_NUMBER()  Over(order by gr.name+ km.name + br.name) 
		,SortOrder_2 = ROW_NUMBER()  Over(order by fo.ghemat)   
		,SortOrder_3 = ROW_NUMBER()  Over(order by fo.ghemat desc)
		,SortOrder_4 = ROW_NUMBER()  Over(order by fo.Ghymat_Masraf_konandeh -fo.ghemat desc)
		,SortOrder_5 = ROW_NUMBER()  Over(order by  100-(fo.ghemat * 100 / fo.Ghymat_Masraf_konandeh) desc )
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
		--, count(*) over (  partition by 1) TotalCount
Into	#base
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
		and (Gr.id = @GroupID or @GroupID = 0)
	INNER JOIN tedad td WITH(NOlock) 
		on td.active = 1
		and td.code  collate Persian_100_CI_AS = km.Code_tedad  
	INNER JOIN #fo fo 
		ON fo.code_kala = km.Code
	INNER JOIN @brands br2
		On br2.Value = Br.ID
	Left Join #Basket b 
		on b.ID_Product = km.id
	left join Web.FavoriteProduct Fv
		on fv.id_product = km.id
	LEFT JOIN Web.ProductCeiling  PC
		ON PC.ID_Product = km.ID
where km.active = 1
and ((km.Code + ' '+ gr.name+' '+ km.name +' '+ br.name) like N'%'+ @keyword+'%' or @keyword is null)
--and (br.ID in (select value from @brands)  or  (select COUNT(*) from @brands ) = 0)
--==================================================================
--							Product
--==================================================================
	select	* 
	from	#base
	ORDER BY case @SortOrder 
		when 0 then SortOrder_0
		when 1 then SortOrder_1
		when 2 then SortOrder_2
		when 3 then SortOrder_3
		when 4 then SortOrder_4
		when 5 then SortOrder_5
		end
	OFFSET @OFFSET ROWS
	FETCH NEXT @CountInPage ROWS ONLY
--==================================================================
--							Pageing
--==================================================================
	Declare @TotalPageCount_dec  decimal(30,2) = (select Count(*) From #base) /  cast(@countInPage as decimal(30,2))
	Drop table if Exists #PageInfo
	Select	 Ssn			= @Ssn		
			,SortOrder 		= @SortOrder 	
			,CountInPage	= @CountInPage
			,CurentPgae		= @CurentPgae	
			,TotalCount		= (select Count(*) From #base)	
			,TotalPageCount	= CEILING(@TotalPageCount_dec)
	into #PageInfo

	--Update #PageInfo 
	--set TotalPageCount = TotalPageCount + 1
	--where TotalCount >TotalPageCount

	
	Update #PageInfo 
	set TotalPageCount = 1
	where TotalPageCount = 0

	select * 
	from #PageInfo
--==================================================================
--							Brand
--==================================================================
		SELECT	Tg.ID 
			,Tg.name  
			, COUNT  ( DISTINCT Base.Code) Qty 
			, Cast (1 as bit) Chk
	from #base Base WITH(NOlock)
		inner join dbo.Tejari_Grop  Tg WITH(NOLOCK)  
			ON Tg.active = 1 
			AND tg.code_moshakhas_konnande = '1'
			AND Tg.code = left(Base.Code ,2)
	where 1 = 1
	GROUP BY Tg.ID ,  Tg.name 
	order by Tg.name		
--==================================================================
--							Groups
--==================================================================
	DROP TABLE  IF EXISTS #baseGrp
	SELECT	Tg.ID 
			,Tg.name  
			, COUNT  ( DISTINCT Base.Code) Qty 
			, Cast (0 as bit) Chk
			,R = ROW_NUMBER() over (order by Tg.name)
	into #baseGrp
	from #base Base WITH(NOlock)
		inner join dbo.Tejari_Grop  Tg WITH(NOLOCK)  
			ON Tg.active = 1 
			AND tg.code_moshakhas_konnande = '2'
			AND Tg.code = SUBSTRING(Base.Code ,3,2)
	where 1=1
	GROUP BY Tg.ID ,  Tg.name 

	insert #baseGrp (ID, name , Qty , Chk,R)
	select 0  , N'همه' ,(select sum(Qty) From #baseGrp) , 1,0
	
	select * from #baseGrp
	order by  R

GO
