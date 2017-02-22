CREATE PROCEDURE [dbo].[GetPatientDiseasesHistory]
	@id int
AS
	SELECT ds.Id, ds.Name as Diseas, ds.StartAt, ds.EndAt, d.Name as Doctor
	from [dbo].[Diseases] ds
	left join [dbo].[Doctors] d on d.Id = ds.DoctorId
	where ds.PatientId = @id
go
