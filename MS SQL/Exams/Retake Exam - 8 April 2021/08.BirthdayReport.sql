SELECT 
	 u.Username
	,c.[Name] AS CategoryName
FROM Reports AS r
JOIN Users AS u ON r.UserId = u.Id
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DAY(u.Birthdate) = DAY(r.OpenDate)
ORDER BY u.Username, c.[Name]
