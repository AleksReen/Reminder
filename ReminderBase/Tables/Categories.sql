USE ReminderBase
GO

CREATE TABLE Categories 
(
	CategoryId int NOT NULL PRIMARY KEY IDENTITY,
	CategoryName nvarchar(50) NOT NULL
)
