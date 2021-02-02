SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
--DECLARE @Ssn VARCHAR(10) = '0072374586'
CREATE PROC [Web].[GetBasketDetail]
@ID_Basket  int
As
SELECT	Dt.ID,
        Dt.ID_Basket,
        Dt.ID_Product,
        Dt.CreateDate  crd,
        Dt.Qty
FROM	web.BasketDetail Dt
WHERE	1=1
		AND Dt.ID_Basket = @ID_Basket
GO
