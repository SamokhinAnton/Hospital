CREATE PROCEDURE [dbo].[CreateDoctor]
	@name nvarchar(128),
	@specialization nvarchar(128)
AS
	insert into [dbo].[Doctors](Name, Specialization)
	values (@name, @specialization) 
go
