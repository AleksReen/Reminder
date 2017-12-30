USE ReminderBase
GO

CREATE PROCEDURE DeleteUser
	@id int
AS
	DELETE Users
	WHERE UserId = @id

	DELETE Users_Roles
	WHERE UserId = @id

RETURN 0