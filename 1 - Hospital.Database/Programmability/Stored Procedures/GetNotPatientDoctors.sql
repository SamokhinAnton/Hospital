CREATE PROCEDURE [dbo].[GetNotPatientDoctors]
	@patientId int
AS
	select d.Id, d.Name, d.Specialization
	from [dbo].[Doctors] d
	left join (select * from [dbo].[PatientsDoctors]  where PatientId = @patientId) pd on pd.DoctorId = d.Id
	where pd.PatientId is null
go
