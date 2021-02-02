SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROC [Web].[GetProductGroup]
@ssn nvarchar(10)
AS 


	Declare @Today  nvarchar(10)=  (SELECT Pr_DateDisplay FROM dbo.Clander WHERE gr_date = CAST(GetDate() AS date))
	Declare @CodeNoae nvarchar(5) = (SELECT TOP(1) noae from moshtari WITH (NOLOCK) WHERE active = 1 AND groh = '32' AND Code_meli = @ssn)

	DROP TABLE  IF EXISTS #baseGrp
	SELECT	Tg.ID 
			,Tg.name  
			, COUNT  ( DISTINCT fo.code_kala) Qty 
			, Cast (0 as bit) Chk
			,SortOrder = ROW_NUMBER() over (order by Tg.name)
	into #baseGrp
	from Fee_omomi fo WITH(NOlock)
		inner join dbo.Tejari_Grop  Tg WITH(NOLOCK)  
			ON Tg.active = 1 
			AND tg.code_moshakhas_konnande = '2'
			AND Tg.code = SUBSTRING(fo.code_kala ,3,2)
	where fo.active = 1
		and fo.lock = 0
		and  @Today between start_date and end_date
		and groh_moshtary = '32'
		and code_noae collate Persian_100_CI_AS = @CodeNoae
	GROUP BY Tg.ID ,  Tg.name 

	insert #baseGrp (ID, name , Qty , Chk,SortOrder)
	select 0  , N'همه' ,(select sum(Qty) From #baseGrp) , 1,0
	
	select * from #baseGrp
	order by  SortOrder




	
GO
