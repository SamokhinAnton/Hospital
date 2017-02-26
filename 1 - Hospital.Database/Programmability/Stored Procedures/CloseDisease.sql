CREATE PROCEDURE [dbo].[CloseDisease]
	@id int,
	@endAt datetime
AS
	update [dbo].[Diseases] 
	set EndAt = @endAt
	where Id = @id
go
