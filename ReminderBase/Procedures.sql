--PROCEDURE

-- get all categories
CREATE PROCEDURE GetAllCategories
AS
SELECT*FROM Categories

CREATE PROCEDURE GetCategoryNameById
@CategoryId int
AS
SELECT CategoryName FROM Categories
WHERE CategoryId = @CategoryId

CREATE PROCEDURE GetAllReminders
AS
SELECT*FROM Reminders

CREATE PROCEDURE GetReminderById
@ReminderId int
AS
SELECT*FROM Reminders
WHERE ReminderId = @ReminderId

CREATE PROCEDURE GetReminderDescription
@ReminderId int
AS
SELECT [Description] FROM RemindersInfo
WHERE ReminderId = @ReminderId

CREATE PROCEDURE GetReminderActions
@ReminderId int
AS
SELECT [Action] FROM ReminderActions
WHERE ReminderId = @ReminderId