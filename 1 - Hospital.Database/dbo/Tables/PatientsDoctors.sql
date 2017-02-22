CREATE TABLE [dbo].[PatientsDoctors]
(
	[PatientId] int not null,
	[DoctorId] int not null,
	Constraint [PK_PatientsDoctors] primary key([PatientId], [DoctorId]),
	Constraint [FK_PatientsDoctors_Patients] foreign key (PatientId) References Patients(Id),
	Constraint [FK_PatientsDoctors_Doctors] foreign key (DoctorId) References Doctors(Id)
)
