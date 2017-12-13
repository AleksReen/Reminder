CREATE PROCEDURE UpdateProfile
	@id int,
	@login nvarchar(max),
	@email nvarchar(max)
AS
	Update Users
	SET Login = @login, Email = @email
	WHERE UserId = @id

RETURN 0