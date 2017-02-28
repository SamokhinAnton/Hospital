CREATE PROCEDURE [dbo].[SearchDoctors]
	@pattern nvarchar(128)
AS
	select Id, Name, Specialization
	from [dbo].[Doctors]
	where Name like '%'+@pattern+'%'
	OR Specialization like '%'+@pattern+'%'
go
