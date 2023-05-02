create PROCEDURE [dbo].[sp_GetUser]
@UserID int null
AS

select top 1 * from Users where id = @UserID and IsEnabled =1
