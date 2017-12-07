CREATE PROCEDURE GetUsers
AS
SELECT u.UserId, [Login], Email, [Role] = STUFF((SELECT ',' + r.[Role] 
													FROM dbo.Roles r
													JOIN Users_Roles as u_r
													ON u_r.RoleId = r.RoleId
													WHERE u.UserId = u_r.UserId
										FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
FROM Users as u
GROUP BY u.UserId, u.Login, u.Email
RETURN 0