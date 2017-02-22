CREATE PROCEDURE [dbo].[GetAllDoctors]

AS
	SELECT d.Id, d.Name, d.Specialization
	from [dbo].[Doctors] d

go
