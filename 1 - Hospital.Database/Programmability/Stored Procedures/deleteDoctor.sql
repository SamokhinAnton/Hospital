CREATE PROCEDURE [dbo].[DeleteDoctor]
	@id int
AS
	delete from [dbo].[PatientsDoctors] where DoctorId = @id
	delete from [dbo].[Diseases] where DoctorId = @id
	delete from [dbo].[Doctors] where Id = @id
go
