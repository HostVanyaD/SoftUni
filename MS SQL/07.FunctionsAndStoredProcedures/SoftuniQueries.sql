--01. Employees with Salary Above 35000

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT [FirstName], [LastName] 
	FROM Employees
	WHERE [Salary] > 35000
END
GO


--02. Employees with Salary Above Number

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number DECIMAL(18, 4))
AS
BEGIN
	SELECT [FirstName], [LastName]
	FROM Employees
	WHERE [Salary] >= @number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

GO



--03. Town Names Starting With

CREATE PROC usp_GetTownsStartingWith (@starting VARCHAR(30))
AS
BEGIN
	SELECT [Name] AS [Town]
	FROM Towns
	WHERE SUBSTRING([Name], 1, LEN(@starting)) = @starting
END

EXEC usp_GetTownsStartingWith b
GO



--04. Employees from Town

CREATE PROC usp_GetEmployeesFromTown (@townName VARCHAR(50))
AS
BEGIN
	SELECT e.[FirstName], e.[LastName]
	FROM Employees AS e
	LEFT JOIN Addresses AS a ON e.[AddressID] = a.[AddressID]
	LEFT JOIN Towns AS t ON t.[TownID] = a.TownID
	WHERE t.[Name] = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'
GO



--05. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @level VARCHAR(10)

	IF @salary < 30000
		SET @level = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000
		SET @level = 'Average'
	ELSE	
		SET @level = 'High'

	RETURN @level
END
GO



--06. Employees by Salary Level

CREATE PROC usp_EmployeesBySalaryLevel(@level VARCHAR(10))
AS
BEGIN
	SELECT [FirstName], [LastName]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel([Salary]) = @level
END

EXEC usp_EmployeesBySalaryLevel 'High'
GO



--07. Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
		DECLARE @count INT = 1
		DECLARE @currentLetter VARCHAR(1)

		WHILE(LEN(@word) >= @count)
		BEGIN
			   SET @currentLetter = SUBSTRING(@word, @count, 1)

			   IF @setOfLetters NOT LIKE CONCAT('%', @currentLetter, '%')
					RETURN 0

			   SET @count += 1
		END
		RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS [Result]
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves') AS [Result]

GO



--08. Delete Employees and Departments

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
		DELETE FROM EmployeesProjects
		WHERE [EmployeeID] IN (SELECT [EmployeeID]
							     FROM Employees
							    WHERE [DepartmentID] = @departmentId)

		UPDATE Employees
		   SET [ManagerID] = NULL
		 WHERE [ManagerID] IN (SELECT [EmployeeID]
							     FROM Employees
								WHERE [DepartmentID] = @departmentId)

		ALTER TABLE Depatments
		ALTER COLUMN [ManagerID] INT

		UPDATE Departments
		   SET [ManagerID] = NULL
		 WHERE [DepartmentID] = @departmentId

		DELETE FROM Employees
		      WHERE [DepartmentID] = @departmentId

		DELETE FROM Departments
		      WHERE [DepartmentID] = @departmentId

		SELECT COUNT([EmployeeID])
		  FROM Employees
		 WHERE [DepartmentID] = @departmentId
END

