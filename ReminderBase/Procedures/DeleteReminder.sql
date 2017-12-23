USE ReminderBase
GO

CREATE PROCEDURE DeleteReminder
	@ReminderID int,
	@imageUrl nvarchar(max) output
AS
BEGIN
	SELECT @imageUrl = [Image] FROM Reminders
	WHERE ReminderId = @ReminderID

	DELETE Reminders
	WHERE ReminderId = @ReminderID
END