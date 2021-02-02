SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create Proc [Web].[RemoveProductFromFavorite]
@ssn nvarchar(10)
,@ID_Product bigint
As 

begin try

	WAITFOR DELAY '00:00:00:500';
	Delete From [Web].[FavoriteProduct]
	where ID_Product = @ID_Product
	and ssn = @ssn
end try
begin catch
	return
end Catch

GO
