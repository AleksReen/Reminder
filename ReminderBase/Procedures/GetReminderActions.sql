CREATE PROCEDURE GetReminderActions
@ReminderId int
AS
SELECT [Action] FROM Actions
WHERE ReminderId = @ReminderId