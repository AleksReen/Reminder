USE ReminderBase
GO

CREATE PROCEDURE EditeUser
	@id int
AS
	SELECT u.UserId, Login, Email, r.RoleId, r.Role
	FROM Users as u
	JOIN Users_Roles as u_r
	ON u_r.UserId = u.UserId
	JOIN Roles as r
	ON r.RoleId = u_r.RoleId

	WHERE u.UserId = @id

RETURN 0