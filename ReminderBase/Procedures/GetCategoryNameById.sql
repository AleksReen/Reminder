CREATE PROCEDURE GetCategoryNameById
@CategoryId int
AS
SELECT CategoryName FROM Categories
WHERE CategoryId = @CategoryId