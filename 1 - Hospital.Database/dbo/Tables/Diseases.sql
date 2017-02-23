CREATE TABLE [dbo].[Diseases]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[PatientId] int not null,
	[DoctorId] int not null, 
	[Name] nvarchar(128) not null,
	[StartAt] datetime not null,
	[EndAt] datetime null,
	Constraint [FK_Disiases_Patients] foreign key (PatientId) References Patients(Id),
	Constraint [FK_Disiases_Doctors] foreign key (DoctorId) References Doctors(Id)
)
