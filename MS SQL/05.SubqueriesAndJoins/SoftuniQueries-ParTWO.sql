--09. Employee Manager

SELECT 
	 e.[EmployeeID]
	,e.[FirstName]
	,e.[ManagerID]
	,m.[FirstName] AS [ManagerName]
FROM Employees AS e
JOIN Employees AS m ON e.[ManagerID] = m.[EmployeeID]
WHERE e.[ManagerID] IN (3, 7)
ORDER BY e.[EmployeeID]



--10. Employees Summary

SELECT TOP(50)
    e.[EmployeeID]
   ,CONCAT(e.[FirstName], ' ', e.[LastName]) AS [EmployeeName]
   ,CONCAT(m.[FirstName], ' ', m.[LastName]) AS [ManagerName]
   ,d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS m ON e.[ManagerID] = m.[EmployeeID]
JOIN Departments AS d ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID]



--11. Min Average Salary

SELECT MIN(a.[AvgSalary]) AS [MinAverageSalary]
FROM
   (SELECT AVG([Salary]) AS AvgSalary
    FROM Employees
    GROUP BY [DepartmentID]) AS a
