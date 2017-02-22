CREATE PROCEDURE [dbo].[CreateDoctorPatient]
	@patientId int,
	@doctorId int
AS
	insert into [dbo].[PatientsDoctors](DoctorId, PatientId)
	values (@doctorId, @patientId)
go
