SELECT TOP(5) 
	 c.[Name] AS CategoryName
	,COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]
