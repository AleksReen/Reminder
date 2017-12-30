USE ReminderBase
GO

CREATE FUNCTION [dbo].[f_GenerateActionsTable]
(
	@reminderId int,	
	@actions xml
)
RETURNS @ActionsTable TABLE 
(
	ActionLine int identity(1,1),
	ReminderId int,
	Actions nvarchar(max)
)
AS
BEGIN

 INSERT INTO @ActionsTable (Actions) 
 SELECT ParamValues.Actions.value('.', 'nvarchar(max)')
 FROM @actions.nodes('/*/string') as ParamValues(Actions)

 UPDATE @ActionsTable
 SET ReminderId = @reminderId
 
 RETURN
END