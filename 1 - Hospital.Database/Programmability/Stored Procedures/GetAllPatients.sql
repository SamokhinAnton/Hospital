CREATE PROCEDURE [dbo].[GetAllPatients]
	
AS
	select p.Id, p.Name, p.Birthdate
	from [dbo].[Patients] p
go
