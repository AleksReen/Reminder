USE ReminderBase
GO

CREATE TABLE Actions
(
	ReminderId int NOT NULL,
	ActionLine int NOT NULL,
	[Action] nvarchar(max) NULL,	
)