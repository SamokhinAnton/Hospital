CREATE PROCEDURE [dbo].[GetPatientDiseasesHistory]
	@id int
AS
	SELECT ds.Id, ds.PatientId, ds.DoctorId, ds.Name, ds.StartAt, ds.EndAt, d.Name as ProfileName
	from [dbo].[Diseases] ds
	left join [dbo].[Doctors] d on d.Id = ds.DoctorId
	where ds.PatientId = @id
go
