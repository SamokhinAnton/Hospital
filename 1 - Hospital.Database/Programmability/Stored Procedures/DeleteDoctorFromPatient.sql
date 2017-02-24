CREATE PROCEDURE [dbo].[DeleteDoctorFromPatient]
	@patientId int,
	@doctorId int
AS
	delete from [dbo].[PatientsDoctors]
	where PatientId = @patientId and
	      DoctorId = @doctorId
go
