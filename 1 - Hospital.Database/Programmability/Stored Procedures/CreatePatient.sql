CREATE PROCEDURE [dbo].[CreatePatient]
	@name nvarchar(128),
	@birthdate date
as
	insert into [dbo].[Patients](Name, Birthdate)
	values (@name, @birthdate)
go
