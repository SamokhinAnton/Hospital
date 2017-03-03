CREATE TABLE [dbo].[Doctors]
(
	[Id] INT NOT NULL identity(1, 1),
	[Name] nvarchar(128) not null, 
	[Specialization] nvarchar(128) not null
	CONSTRAINT [PK_dbo.Doctors] PRIMARY KEY CLUSTERED ([Id] ASC)
)
