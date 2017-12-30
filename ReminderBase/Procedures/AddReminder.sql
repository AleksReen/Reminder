USE ReminderBase
GO

CREATE PROCEDURE AddReminder
	@title nvarchar(max),
	@date date,
	@dateReminder smalldatetime,
	@image nvarchar(MAX),
	@categoryId int,
	@userId int,
	@actions xml = null,
	@description nvarchar(max) = null

AS
DECLARE @ReminderId int;
	
INSERT INTO Reminders
	(Title, [Date], ReminderTime, [Image], CategoryId, UserId)
VALUES 
	(@title, @date, @dateReminder, @image, @categoryId, @userId)	

SET @ReminderId = @@IDENTITY;

IF @description IS NOT NULL
BEGIN
	INSERT INTO Descriptions
	(ReminderId, [Description])
	VALUES
	(@ReminderId, @description)
END

IF @actions IS NOT NULL
BEGIN
	INSERT INTO Actions
	(ReminderId, ActionLine, [Action])
	SELECT a.ReminderId, a.ActionLine, a.Actions 
	FROM dbo.f_GenerateActionsTable(@ReminderId, @actions) as a
END 
RETURN 0