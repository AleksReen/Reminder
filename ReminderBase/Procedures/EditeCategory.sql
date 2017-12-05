CREATE PROCEDURE EditCategory
@CategoryId int,
@CategoryName nvarchar(max)
AS
UPDATE Categories
SET CategoryName = @CategoryName
WHERE CategoryId = @CategoryId

