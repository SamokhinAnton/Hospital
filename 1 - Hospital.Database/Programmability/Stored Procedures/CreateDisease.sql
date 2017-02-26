CREATE PROCEDURE [dbo].[CreateDisease]
	@patientId int,
	@doctorId int,
	@name nvarchar(128),
	@startAt datetime
AS
	insert into [dbo].[Diseases](PatientId, DoctorId, Name, StartAt)
	values (@patientId, @doctorId, @name, @startAt)
go
