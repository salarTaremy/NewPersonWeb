SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
--DECLARE @Ssn VARCHAR(10) = '0072374586'
CREATE PROC [Web].[GetBasket]
@Ssn  VARCHAR(10) = '0072374586'
As
SELECT	B.ID,
        B.CreateDate,
        B.Ssn,
        B.Description,
        B.OrderID 
FROM	web.Basket B
WHERE	1=1
		AND B.Ssn = @Ssn
		AND B.OrderID IS NULL
GO
