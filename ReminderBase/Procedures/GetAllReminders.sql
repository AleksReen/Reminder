CREATE PROCEDURE GetAllReminders
(@userId int)
AS
SELECT*FROM Reminders
WHERE UserId = @userId