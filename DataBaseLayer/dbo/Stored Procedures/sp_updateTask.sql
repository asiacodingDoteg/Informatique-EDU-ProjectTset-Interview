create PROCEDURE [dbo].[sp_updateTask]
	@useriD	int ,
	@TaskID int,
	@SubjectTxt nvarchar(500),
	@TypeTask int,
	@TitleTask nvarchar(50)
AS

DECLARE @userRoles bit = 0; 

select @userRoles =UserType from Users where id=@useriD 

if @userRoles = 1
	update Task set SubjectTask = @SubjectTxt ,TypeTask = @TypeTask , @TitleTask=@TitleTask where Task.FromUser = @useriD and id = @TaskID
else
	update Task set TypeTask = @TypeTask  where Task.ToUser = @useriD and id = @TaskID
