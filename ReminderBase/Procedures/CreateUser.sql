CREATE PROCEDURE CreateUser
	@login nvarchar(max),
	@password nvarchar(max),
	@email nvarchar(max)
AS
BEGIN
	INSERT INTO Users
	([Login], [Password], [Email])
	VALUES 
	(@login, @password, @email)
	
DECLARE @lastId int = @@IDENTITY
DECLARE @role INT;
SET @role = (SELECT RoleId
                FROM Roles 
                WHERE [Role] = 'User');

	INSERT INTO Users_Roles
	(UserId,RoleId)
	VALUES 
	(@lastId, @role)
END