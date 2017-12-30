USE ReminderBase
GO

CREATE TABLE Reminders
(
	ReminderId int NOT NULL PRIMARY KEY IDENTITY,
	Title nvarchar(max) NOT NULL,
	[Date] date NOT NULL,
	ReminderTime smalldatetime NULL,
	[Image] nvarchar(max) NULL,
	CategoryId int NOT NULL,
	UserId int NOT NULL 
)