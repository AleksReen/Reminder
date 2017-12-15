CREATE PROCEDURE UpdateReminder
	@reminderId int,
	@title nvarchar(max),
	@date date,
	@dateReminder smalldatetime,
	@image nvarchar(MAX),
	@categoryId int,
	@actions xml = null,
	@description nvarchar(max) = null
AS

UPDATE Reminders
	SET Title = @title, 
		[Date] = @date, 
		ReminderTime = @dateReminder,
		[Image] = @image,
		CategoryId = @categoryId
	WHERE ReminderId = @reminderId

IF @description IS NULL
	DELETE Descriptions
	WHERE ReminderId = @reminderId
ELSE
	UPDATE Descriptions
	SET [Description] = @description
	WHERE ReminderId = @reminderId

IF @actions IS NULL
	DELETE Actions
	WHERE ReminderId = @reminderId;
ELSE
	DELETE Actions
	WHERE ReminderId = @reminderId;

	INSERT INTO Actions
	(ReminderId, ActionLine, [Action])
	SELECT a.ReminderId, a.ActionLine, a.Actions 
	FROM dbo.f_GenerateActionsTable(@reminderId, @actions) as a

RETURN 0