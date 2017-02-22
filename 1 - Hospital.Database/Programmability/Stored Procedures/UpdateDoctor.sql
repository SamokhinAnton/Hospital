CREATE PROCEDURE [dbo].[UpdateDoctor]
	@id int,
	@name nvarchar(128),
	@specialization nvarchar(128)
AS
	update [dbo].[Doctors] 
	set Name = @name, Specialization = @specialization
	where Id = @id
go
