CREATE TABLE [dbo].[PatientsDoctors]
(
	[DoctorId] int not null,
	[PatientId] int not null,
	CONSTRAINT [PK_dbo.PatientsDoctors] PRIMARY KEY CLUSTERED ([DoctorId] ASC, [PatientId] ASC),
    CONSTRAINT [FK_dbo.PatientsDoctors_dbo.Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.PatientsDoctors_dbo.Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patients] ([Id]) ON DELETE CASCADE
);
GO

CREATE NONCLUSTERED INDEX [IX_DoctorId]
    ON [dbo].[PatientsDoctors]([DoctorId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_PatientId]
    ON [dbo].[PatientsDoctors]([PatientId] ASC);
GO
