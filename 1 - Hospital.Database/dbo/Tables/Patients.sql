CREATE TABLE [dbo].[Patients]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[Name] nvarchar(128) not null,
	[Birthdate] date not null
)
