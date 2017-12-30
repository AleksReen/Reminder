USE ReminderBase
GO

CREATE PROCEDURE EditeCategory
@CategoryId int,
@CategoryName nvarchar(max)
AS
UPDATE Categories
SET CategoryName = @CategoryName
WHERE CategoryId = @CategoryId

