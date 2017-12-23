USE ReminderBase
GO

CREATE PROCEDURE UpdateUser
	@id int,
	@login nvarchar(max),
	@email nvarchar(max),
	@roleId int

AS
	Update Users
	SET Login = @login, Email = @email
	WHERE UserId = @id

	Update Users_Roles
	SET RoleId = @roleId
	WHERE UserId = @id 

RETURN 0