SELECT 
	 p.Id
	,p.[Name]
	,CONCAT(p.Size, 'KB') AS Size
FROM Files AS p
LEFT JOIN Files AS c ON p.Id = c.ParentId
WHERE c.Id IS NULL
ORDER BY c.Id, c.[Name], c.Size DESC