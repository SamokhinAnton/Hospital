CREATE PROCEDURE [dbo].[GetPatient]
	@id int
AS
	select p.Id, p.Name, p.Birthdate
	from [dbo].[Patients] p
	where p.Id = @id
go
