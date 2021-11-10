CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
BEGIN
	SELECT 
		Id
	   ,[Name]
	   ,CONCAT(Size, 'KB') AS Size
	FROM Files
	WHERE [Name] LIKE '%.' + @fileExtension
	ORDER BY Id, [Name], Size DESC
END