--01. Find Names of All Employees by First Name

--SELECT [FirstName], [LastName] FROM [Employees]
--WHERE LEFT([FirstName], 2) = 'Sa'

--SELECT [FirstName], [LastName] FROM [Employees]
--WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'

SELECT [FirstName], [LastName]
FROM Employees
WHERE [FirstName] LIKE 'SA%';



--02. Find Names of All Employees by Last Name

--SELECT [FirstName], [LastName], CHARINDEX('ei', [LastName]) FROM [Employees]
--I VARIANT

SELECT [FirstName], [LastName]
FROM Employees
WHERE [LastName] LIKE '%EI%';



--03. Find First Names of All Employess

SELECT [FirstName]
FROM Employees
WHERE [DepartmentID] IN (3, 10) AND
YEAR([HireDate]) BETWEEN 1995 AND 2005;



--04. Find All Employees Except Engineers

SELECT [FirstName], [LastName]
FROM Employees
WHERE [JobTitle] NOT LIKE '%engineer%';



--05. Find Towns with Name Length

SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name];



--06. Find Towns Starting With

SELECT [TownID], [Name]
FROM Towns
WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name];



--07. Find Towns Not Starting With

SELECT [TownID], [Name]
FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name];



--08. Create View Employees Hired After
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName]
FROM Employees
WHERE YEAR([HireDate]) > 2000;



--09. Length of Last Name

SELECT [FirstName], [LastName]
FROM Employees
WHERE LEN([LastName]) = 5;



--10. Rank Employees by Salary

SELECT [EmployeeID], [FirstName], [LastName], [Salary]
		,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC;



--11. Find All Employees with Rank 2 

SELECT *
FROM (SELECT [EmployeeID], [FirstName], [LastName], [Salary]
		,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY EmployeeID) AS [Rank]
	  FROM Employees
	  WHERE [Salary] BETWEEN 10000 AND 50000) AS RankTable
WHERE [Rank] = 2
ORDER BY [Salary] DESC;