CREATE TABLE [dbo].[Patients]
(
	[Id] INT NOT NULL identity(1, 1),
	[Name] nvarchar(128) not null,
	[Birthdate] datetime not null
	CONSTRAINT [PK_dbo.Patients] PRIMARY KEY CLUSTERED ([Id] ASC)
)
