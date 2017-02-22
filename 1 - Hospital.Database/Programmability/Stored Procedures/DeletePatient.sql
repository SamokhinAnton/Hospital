CREATE PROCEDURE [dbo].[DeletePatient]
	@id int
AS
	delete from [dbo].[PatientsDoctors] where PatientId = @id
	delete from [dbo].[Diseases] where PatientId = @id
	delete from [dbo].[Patients] where Id = @id
go
