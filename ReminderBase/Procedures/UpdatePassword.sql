USE ReminderBase
GO

CREATE PROCEDURE UpdatePassword
	@id int,
	@newPassword nvarchar(max)
AS
	UPDATE Users
	SET Password = @newPassword
	WHERE UserId = @id

RETURN 0