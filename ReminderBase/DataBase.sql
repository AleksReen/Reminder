
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
	ReminderTime smalldatetime NULL,
	[Image] nvarchar(max) NULL,
	CategoryId int NOT NULL,
	UserId int NOT NULL 
)

CREATE TABLE Categories 
(
	CategoryId int NOT NULL PRIMARY KEY IDENTITY,
	CategoryName nvarchar(50) NOT NULL
)

CREATE TABLE Descriptions
(
	ReminderId int NOT NULL PRIMARY KEY,
	[Description] nvarchar(max) NULL
)

CREATE TABLE Actions
(
	ReminderId int NOT NULL,
	ActionLine int NOT NULL,
	[Action] nvarchar(max) NULL,	
)

CREATE TABLE Users
(
	UserId int NOT NULL PRIMARY KEY IDENTITY,
	[Login] nvarchar(max) NOT NULL,
	[Password]  nvarchar(max) NOT NULL,
	Email nvarchar(max) NOT NULL
)

CREATE TABLE Roles
(
	RoleId int NOT NULL PRIMARY KEY IDENTITY,
	[Role] nvarchar(max) NOT NULL
)

CREATE TABLE Users_Roles
(
	UserId int NOT NULL,
	RoleId int NOT NULL
)

--setting up keys and restrictions
ALTER TABLE Reminders ADD CONSTRAINT
	FK_Reminders_Users FOREIGN KEY (UserID)
	REFERENCES Users(UserId)
	ON DELETE CASCADE
GO

ALTER TABLE Users_Roles ADD CONSTRAINT
	PK_Users_Roles PRIMARY KEY (UserId,RoleId)
GO

ALTER TABLE Users_Roles ADD CONSTRAINT
	FK_Users_Roles_Users FOREIGN KEY (UserId)
	REFERENCES Users(UserId)
	ON DELETE CASCADE
GO

ALTER TABLE Users_Roles ADD CONSTRAINT
	FK_Users_Roles_Roles FOREIGN KEY (RoleId)
	REFERENCES Roles(RoleId)
GO

ALTER TABLE Actions ADD CONSTRAINT
	PK_Actions PRIMARY KEY (ReminderId,ActionLine) 
GO

ALTER TABLE Actions ADD CONSTRAINT
	FK_Actions_Reminders FOREIGN KEY(ReminderId) 
	REFERENCES Reminders(ReminderId) 
	ON DELETE CASCADE
GO

ALTER TABLE Reminders ADD CONSTRAINT
	FK_Reminders_Categories FOREIGN KEY (CategoryId)
	REFERENCES Categories(CategoryId)
	ON DELETE CASCADE
GO

ALTER TABLE Descriptions ADD 
	CONSTRAINT UQ_Descriptions UNIQUE(ReminderId)
GO

ALTER TABLE Descriptions ADD 
	CONSTRAINT FK_Descriptions_Reminders FOREIGN KEY (ReminderId) 
	REFERENCES Reminders(ReminderId) 
	ON DELETE CASCADE
GO