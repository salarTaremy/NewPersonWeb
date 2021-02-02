SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE Proc [Web].[AddProductToFavorite]
@ssn nvarchar(10)
,@ID_Product bigint
As 

begin try

	WAITFOR DELAY '00:00:00:500';

	INSERT INTO [Web].[FavoriteProduct]
           ([ssn]
           ,[ID_Product])
	select @ssn,@ID_Product
	where not exists(	select id 
						from [Web].[FavoriteProduct]
						where ID_Product = @ID_Product 
						and ssn = @ssn)
end try
begin catch
	return
end Catch

GO
