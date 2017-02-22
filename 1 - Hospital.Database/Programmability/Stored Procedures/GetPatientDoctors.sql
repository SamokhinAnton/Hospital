CREATE PROCEDURE [dbo].[GetPatientDoctors]
	@id int
AS
	select d.Id, d.Name, d.Specialization
	from [dbo].[PatientsDoctors] pd
	left join [dbo].[Doctors] d on d.Id = pd.DoctorId
	where pd.PatientId = @id
go
