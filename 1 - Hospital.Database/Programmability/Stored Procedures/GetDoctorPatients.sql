CREATE PROCEDURE [dbo].[GetDoctorPatients]
	@doctorId int
AS
	SELECT p.Id, p.Name, p.Birthdate
	from [dbo].[PatientsDoctors] pd
	left join [dbo].[Patients] p on p.Id = pd.PatientId
	where pd.DoctorId = @doctorId 
go
