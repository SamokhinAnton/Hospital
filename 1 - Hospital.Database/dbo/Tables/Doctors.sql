CREATE TABLE [dbo].[Doctors]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[Name] nvarchar(128) not null, 
	[Specialization] nvarchar(128) not null
)
