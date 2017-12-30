USE ReminderBase
GO

CREATE PROCEDURE GetReminderInfo
	@id int
	AS
	SELECT rem.ReminderId, Title, [Date], ReminderTime, [Image], [Description], [Action], rem.CategoryId, CategoryName
	FROM Reminders as rem
	INNER JOIN Categories as cat
	ON cat.CategoryId = rem.CategoryId
	LEFT JOIN Descriptions as d
	ON d.ReminderId = rem.ReminderId
	LEFT JOIN Actions as act
	ON act.ReminderId = rem.ReminderId
	WHERE rem.ReminderId = @id
GO


