SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE  proc [Web].[AddProductToBasket] 
@Ssn  varchar(10) 
,@ID_Product bigint 
,@Qty smallint 
As

if len(@ssn) <> 10  or @Ssn is null
begin
	Raiserror(N'کد ملی نا معتبر',16,1)
	return
End

Declare @ID_Basket int 
select @ID_Basket = ID 
from web.basket 
where  Ssn = @Ssn 
	and OrderID is null



INSERT INTO [Web].[Basket] ([Ssn])
SELECT @Ssn
WHERE @ID_Basket is null

set @ID_Basket = ISNULL(@ID_Basket , SCOPE_IDENTITY())


INSERT INTO [Web].[BasketDetail]
           ([ID_Basket]
           ,[ID_Product]
           ,[Qty])
Select		@ID_Basket
           ,@ID_Product
           ,@Qty



		  


		   



GO
