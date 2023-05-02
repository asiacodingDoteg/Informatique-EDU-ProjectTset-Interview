create PROCEDURE [dbo].[sp_GetFullname]
@UserID int null
AS

select top 1 Fullname from Users where id = @UserID and IsEnabled =1