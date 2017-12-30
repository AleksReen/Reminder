USE ReminderBase
GO

CREATE TABLE Roles
(
	RoleId int NOT NULL PRIMARY KEY IDENTITY,
	[Role] nvarchar(max) NOT NULL
)