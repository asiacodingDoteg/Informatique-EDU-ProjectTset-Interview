CREATE PROCEDURE [dbo].[sp_SharchTask]
@UserID int null,
@Type int null,
@SharchTxt nvarchar(50) null 
AS

if @Type = 1  
SELECT Users.Fullname as 'Fullname' , CONVERT(nvarchar(50),Task.TypeTask) as 'Status' , CONVERT(nvarchar(50), Task.id) as 'ID'
FROM Task  
INNER JOIN Users ON  (Task.FromUser=@UserID and users.Fullname like '%'+@SharchTxt+'%' ) 
else
SELECT Users.Fullname as 'Fullname' , CONVERT(nvarchar(50),Task.TypeTask) as 'Status' , CONVERT(nvarchar(50), Task.id) as 'ID'
FROM Task  
INNER JOIN Users ON  (Task.ToUser=Users.id and users.Fullname like '%'+@SharchTxt+'%' and Users.id = @UserID) 
