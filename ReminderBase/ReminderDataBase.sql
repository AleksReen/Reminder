
--creation of a database

CREATE DATABASE ReminderBase
COLLATE Cyrillic_General_CI_AS
GO

--selection of the created database

USE ReminderBase
GO

--creating tables

CREATE TABLE Reminders
(
	ReminderId int NOT NULL PRIMARY KEY IDENTITY,
	Title nvarchar(max) NOT NULL,
	[Date] date NOT NULL,
	ReminderTime smalldatetime,
	[Image] nvarchar(max),
	CategoryId int NOT NULL 
)

CREATE TABLE Categories 
(
	CategoryId int NOT NULL PRIMARY KEY IDENTITY,
	CategoryName nvarchar(50) NOT NULL
)

CREATE TABLE RemindersInfo
(
	ReminderId int NOT NULL PRIMARY KEY,
	[Description] nvarchar(max)
)

CREATE TABLE ReminderActions
(
	ActionId int NOT NULL PRIMARY KEY IDENTITY,
	[Action] nvarchar(max) NOT NULL,
	ReminderId int NULL
)

--setting up keys and restrictions

ALTER TABLE ReminderActions ADD CONSTRAINT
	FK_ReminderActions_Reminders FOREIGN KEY(ReminderId) 
	REFERENCES Reminders(ReminderId) 
	ON DELETE CASCADE
GO

ALTER TABLE Reminders ADD CONSTRAINT
	FK_Reminders_Categories FOREIGN KEY (CategoryId)
	REFERENCES Categories(CategoryId)
GO

ALTER TABLE RemindersInfo ADD 
	CONSTRAINT UQ_RemindersInfo UNIQUE(ReminderId)
GO

ALTER TABLE RemindersInfo ADD 
	CONSTRAINT FK_RemindersInfo_Reminders FOREIGN KEY (ReminderId) 
	REFERENCES Reminders(ReminderId) 
	ON DELETE CASCADE
GO