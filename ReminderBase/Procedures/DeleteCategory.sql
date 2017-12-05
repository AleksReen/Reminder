CREATE PROCEDURE DeleteCategory
@CategoryId int
AS

DELETE Categories
WHERE CategoryId = @CategoryId

