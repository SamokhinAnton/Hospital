CREATE PROCEDURE [dbo].[UpdatePatient]
	@id int,
	@name nvarchar(128),
	@birthdate date
AS
	update [dbo].[Patients] 
	set Name = @name, 
		Birthdate = @birthdate
	where Id = @id
go
