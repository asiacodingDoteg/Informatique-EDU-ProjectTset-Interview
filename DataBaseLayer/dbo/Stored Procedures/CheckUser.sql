
CREATE PROCEDURE [dbo].[CheckUser]
	@Username	nvarchar(50) 
AS


DECLARE @_CountRow int = 0; 
DECLARE @_LastID int = 0;


if (select COUNT(*) from InformatiqueEDU_Task.dbo.Users) = 0
begin
	set @_LastID =  1
end
else
begin
	select @_LastID =  Max(id)+1  from InformatiqueEDU_Task.dbo.Users  
end


select @_CountRow = Count(*) from InformatiqueEDU_Task.dbo.Users where Username = @Username

-- If the user is found, it returns -1
if @_CountRow >= 1
begin
	select -1 as 'LastID', ('Found This User '+@Username) as 'cases'
	return ;
end

--But if it does not find any registered user, it will return the last ID of the last person in the databases
select @_LastID as 'LastID', 'Successful registration' as 'cases';
