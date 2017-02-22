CREATE PROCEDURE [dbo].[GetDoctor]
	@id int
AS
	select d.Id, d.Name, d.Specialization
	from [dbo].[Doctors] d
	where d.Id = @id
go
