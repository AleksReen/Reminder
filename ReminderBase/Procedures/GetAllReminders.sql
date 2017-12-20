CREATE PROCEDURE GetAllReminders
(@userId int)
AS
SELECT ReminderId, Title, Date, ReminderTime, rem.Image, rem.CategoryId, CategoryName FROM Reminders as rem
INNER JOIN Categories as cat
ON cat.CategoryId = rem.CategoryId 
WHERE UserId = @userId