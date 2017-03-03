CREATE TABLE [dbo].[Diseases]
(
	[Id] INT NOT NULL identity(1, 1),
	[PatientId] int not null,
	[DoctorId] int not null, 
	[Name] nvarchar(128) not null,
	[StartAt] datetime not null,
	[EndAt] datetime null,
	CONSTRAINT [PK_dbo.Diseases] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Diseases_dbo.Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Diseases_dbo.Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patients] ([Id]) ON DELETE CASCADE
);
GO

CREATE NONCLUSTERED INDEX [IX_DoctorId]
    ON [dbo].[Diseases]([DoctorId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_PatientId]
    ON [dbo].[Diseases]([PatientId] ASC);
GO
