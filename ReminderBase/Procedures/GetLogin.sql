USE ReminderBase
GO

CREATE PROCEDURE GetLogin 
(
	@login nvarchar(50),
	@password nvarchar(50)
)
AS
SELECT u.UserId, Login, Role 
FROM Users_Roles as u_r
	JOIN Users as u on u.UserId = u_r.UserId 
    JOIN Roles as r on r.RoleId= u_r.RoleId
WHERE u.Login = @login AND u.Password = @password