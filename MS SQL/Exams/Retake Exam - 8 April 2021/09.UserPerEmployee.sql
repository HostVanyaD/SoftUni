SELECT 
	 CONCAT(e.FirstName, ' ', e.LastName) AS FullName
	,ISNULL(COUNT(u.Id), 0) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
LEFT JOIN Users AS u ON r.UserId = u.Id
GROUP BY e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName
