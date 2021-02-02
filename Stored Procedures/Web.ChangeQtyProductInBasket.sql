SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE PROC [Web].[ChangeQtyProductInBasket]
 @Ssn VARCHAR(10)  = '0072374586'
, @ID_Product BIGINT = 48494849015
, @Qty  SMALLINT

AS
UPDATE	Dt
SET		Dt.Qty = @Qty
FROM	Web.Basket B
			INNER JOIN Web.BasketDetail Dt
				ON Dt.ID_Basket = B.ID 
WHERE	B.Ssn = @Ssn
		AND B.OrderID IS NULL 
		AND Dt.ID_Product = @ID_Product
		AND Dt.Qty <> @Qty

		RETURN @@ROWCOUNT



GO
