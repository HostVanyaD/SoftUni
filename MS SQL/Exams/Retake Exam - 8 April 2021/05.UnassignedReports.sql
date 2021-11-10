SELECT 
	[Description]
   ,FORMAT(OpenDate, 'dd-MM-yyyy') AS [Open Date]
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]
