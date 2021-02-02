SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE  proc [Web].[RemoveProductFromBasket] 
@Ssn  varchar(10) 
,@ID_Product bigint 
As

if len(@ssn) <> 10  or @Ssn is null
begin
	Raiserror(N'کد ملی نا معتبر',16,1)
	return
End

DELETE dt
FROM	web.Basket B
		INNER JOIN Web.BasketDetail Dt
			ON Dt.ID_Basket = B.ID
WHERE	1=1
		AND		@Ssn= Ssn
		AND		B.OrderID IS NULL
		AND		Dt.ID_Product = @ID_Product








		  


		   




GO
