USE ReminderBase
GO

CREATE TABLE Descriptions
(
	ReminderId int NOT NULL PRIMARY KEY,
	[Description] nvarchar(max) NULL
)