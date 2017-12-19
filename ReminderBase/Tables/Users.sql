USE ReminderBase
GO

CREATE TABLE Users
(
	UserId int NOT NULL PRIMARY KEY IDENTITY,
	[Login] nvarchar(max) NOT NULL,
	[Password]  nvarchar(max) NOT NULL,
	Email nvarchar(max) NOT NULL
)