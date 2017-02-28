CREATE PROCEDURE [dbo].[SearchPatients]
	@pattern nvarchar(128)
AS
	select Id, Name, Birthdate
	from [dbo].[Patients]
	where Name like '%'+@pattern+'%'
go
