--13. Departments Total Salaries

SELECT 
	[DepartmentID]
	,SUM([Salary]) AS [TotalSalary]
FROM Employees
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]



--14. Employees Minimum Salaries

SELECT 
	 [DepartmentID]
	,MIN([Salary]) AS [MinimumSalary]
FROM Employees
WHERE [HireDate] > '01-01-2000' 
  AND [DepartmentID] IN (2, 5, 7)
  GROUP BY [DepartmentID]



--15. Employees Average Salaries

SELECT *
INTO [EmployeesWithMoreSalary]
FROM Employees
WHERE [Salary] > 30000

DELETE 
	FROM [EmployeesWithMoreSalary]
	WHERE [ManagerID] IN (42)

UPDATE [EmployeesWithMoreSalary]
	SET [Salary] += 5000
	WHERE [DepartmentID] IN (1)

SELECT 
	 [DepartmentID]
	,AVG([Salary]) AS [AverageSalary]
FROM [EmployeesWithMoreSalary]
GROUP BY [DepartmentID]



--16. Employees Maximum Salaries

SELECT 
	 [DepartmentID]
	,MAX([Salary]) AS [MaxSalary]
FROM Employees
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000



--17. Employees Count Salaries

SELECT 
	COUNT([EmployeeID]) AS [Count]
FROM Employees
WHERE [ManagerID] IS NULL




--18. 3rd Highest Salary

SELECT DISTINCT
	 [DepartmentID]
	,[Salary] AS [ThirdHighestSalary]
FROM (
		SELECT 
			 e.[DepartmentID]
			,e.[Salary]
			,DENSE_RANK() OVER(PARTITION BY e.[DepartmentID] ORDER BY e.[Salary] DESC) AS [SalaryRank]
		FROM Employees AS e
     ) AS [RankingSalarySubQuery]
WHERE [SalaryRank] = 3




--19. Salary Challenge

SELECT TOP(10)
	 e.[FirstName]
	,e.[LastName]
	,e.[DepartmentID]
FROM Employees AS e
WHERE [Salary] > (
					SELECT 
						 AVG(em.[Salary]) AS [DepAverageSalary]
					FROM Employees AS em
					WHERE e.[DepartmentID]  = em.[DepartmentID]
					GROUP BY em.[DepartmentID]
				  )
ORDER BY e.[DepartmentID]
