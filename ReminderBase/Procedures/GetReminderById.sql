CREATE PROCEDURE GetReminderById
@ReminderId int
AS
SELECT*FROM Reminders
WHERE ReminderId = @ReminderId