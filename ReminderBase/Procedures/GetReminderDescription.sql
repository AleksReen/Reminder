CREATE PROCEDURE GetReminderDescription
@ReminderId int
AS
SELECT ReminderId, [Description] FROM Descriptions
WHERE ReminderId = @ReminderId