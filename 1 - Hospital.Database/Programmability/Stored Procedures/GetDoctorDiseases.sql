CREATE PROCEDURE [dbo].[GetDoctorDiseases]
	@doctorId int
AS
	SELECT ds.Id, ds.PatientId, ds.DoctorId, ds.Name, ds.StartAt, ds.EndAt, p.Name as ProfileName
	from [dbo].[Diseases] ds
	left join [dbo].[Patients] p on p.Id = ds.PatientId 
	where ds.DoctorId = @doctorId
go
