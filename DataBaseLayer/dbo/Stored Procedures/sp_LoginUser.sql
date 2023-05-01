CREATE PROCEDURE [dbo].[sp_LoginUser]
	@Username	nvarchar(50) ,
	@Password	nvarchar(50) 
AS

--DECLARE @_CountRow int = 0; 


--select @_CountRow =  COUNT( *) from Users where LOWER(Username) = LOWER(@Username) and Password = @Password
--
--if @_CountRow >= 1
--begin

select top 1 * from Users where LOWER(Username) = LOWER(@Username) and Password = @Password;

GO