SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
--DECLARE @Ssn VARCHAR(10) = '0072374586'
CREATE PROC [Web].[GetBasketDetailIfExistsProduct]
@Ssn  VARCHAR(10) = '0072374586'
,@ID_Product BIGINT = NULL
As
SELECT	Dt.ID,
        Dt.ID_Basket,
        Dt.ID_Product,
        Dt.CreateDate,
        Dt.Qty
FROM	web.Basket B
		INNER JOIN Web.BasketDetail Dt
			ON Dt.ID_Basket = B.ID
WHERE	1=1
		AND B.Ssn = @Ssn
		AND B.OrderID IS NULL
		AND (@ID_Product IS NULL OR @ID_Product = Dt.ID_Product)

GO
