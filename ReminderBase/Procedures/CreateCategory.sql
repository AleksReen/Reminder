USE ReminderBase
GO

CREATE PROCEDURE CreateCategory
	@categoryName nvarchar (max)
AS
INSERT INTO Categories
(CategoryName)
VALUES
(@categoryName)

