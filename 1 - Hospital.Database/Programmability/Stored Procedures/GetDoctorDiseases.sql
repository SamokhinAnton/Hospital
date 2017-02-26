CREATE PROCEDURE [dbo].[GetDoctorDiseases]
	@doctorId int
AS
	SELECT ds.Id, ds.PatientId, ds.DoctorId, ds.Name, ds.StartAt, ds.EndAt
	from [dbo].[Diseases] ds
	where ds.DoctorId = @doctorId
go
