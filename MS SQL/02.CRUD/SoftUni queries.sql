--02.Create an SQL query that finds all available information about the Departments.
SELECT * FROM Departments;

--03.Create an SQL query that finds all Department names.
SELECT [Name] FROM Departments;

--04.Create an SQL query that finds the first name, last name, and salary for each employee.
SELECT [FirstName], [LastName], [Salary]
FROM Employees;

--05.Create an SQL query that finds the first, middle, and last name for each employee. 
SELECT [FirstName], [MiddleName], [LastName]
FROM Employees;

--06.Create an SQL query that finds the email address for each employee, by his first and last name. Consider that the email domain is softuni.bg. Emails should look like "John.Doe@softuni.bg". The produced column should be named "Full Email Address". 
SELECT CONCAT([FirstName], '.', [LastName], '@softuni.bg')
AS [Full Email Address]
FROM Employees;

--07.Create an SQL query that finds all different employee’s salaries. Display the salaries only in a column named "Salary".
SELECT DISTINCT [Salary]
FROM Employees;

--08.Create an SQL query that finds all information about the employees whose job title is "Sales Representative”. 
SELECT * FROM Employees
WHERE [JobTitle] = 'Sales Representative';

--09.Create an SQL query to find the first name, last name, and job title for all employees whose salary is in a range between 20000 and 30000.
SELECT [FirstName], [LastName], [JobTitle]
FROM Employees
WHERE [Salary] >= 20000 AND [Salary] <= 30000;

--10.Create an SQL query that finds the full name of all employees whose salary is exactly 25000, 14000, 12500, or 23600. The result should be displayed in a column named "Full Name", which is a combination of first, middle, and last names separated by a single space.
SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name] 
	FROM [Employees]
	WHERE [Salary] IN (25000, 14000, 12500, 23600);	

--11.Create an SQL query that finds the first and last names of those employees that do not have a manager. 
SELECT [FirstName], [LastName]
FROM Employees
WHERE [ManagerID] IS NULL;

--12.Create an SQL query that finds the first name, last name, and salary for employees with a salary higher than 50000. Order the result in decreasing order by salary. 
SELECT [FirstName], [LastName], [Salary]
FROM Employees
WHERE [Salary] > 50000
ORDER BY [Salary] DESC;

--13.Create an SQL query that finds the first and last names of the 5 best-paid Employees, ordered in descending by their salary.
SELECT TOP(5) [FirstName], [LastName]
FROM Employees
ORDER BY [Salary] DESC;

--14.Create an SQL query that finds the first and last names of all employees whose department ID is not 4.
SELECT [FirstName], [LastName]
FROM Employees
WHERE [DepartmentID] NOT IN (4);

--15.Create an Write a SQL query that sorts all records in the Employees table by the following criteria: 
--•	By salary in decreasing order
--•	Then by the first name alphabetically
--•	Then by the last name descending
--•	Then by middle name alphabetically
SELECT *
FROM Employees
ORDER BY [Salary] DESC
		,[FirstName]
		,[LastName] DESC
		,[MiddleName];

--16.Create an SQL query that creates a view "V_EmployeesSalaries" with first name, last name, and salary for each employee.
CREATE VIEW V_EmployeesSalaries
AS
SELECT [FirstName], [LastName], [Salary]
FROM Employees;

--17.Create an SQL query to create view "V_EmployeeNameJobTitle" with full employee name and job title. When the middle name is NULL replace it with an empty string ('').
CREATE VIEW V_EmployeeNameJobTitle
AS (SELECT 
		CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name],
		[JobTitle] AS [Job Title]
FROM Employees);

--18.Create an SQL query that finds all distinct job titles.
SELECT DISTINCT [JobTitle]
FROM Employees;

--19.Create an SQL query that finds the first 10 projects which were started, select all information about them, and sort the result by starting date, then by name.
SELECT TOP(10) *
FROM Projects
ORDER BY [StartDate] ASC,
		[Name] ASC;

--20.Create an SQL query that finds the last 7 hired employees, select their first, last name, and hire date.
SELECT TOP(7)
		[FirstName]
		,[LastName]
		,[HireDate]
FROM Employees
ORDER BY [HireDate] DESC;

--21.Create an SQL query that increases salaries by 12% of all employees that work in the ether Engineering, Tool Design, Marketing, or Information Services departments. As a result, select and display only the "Salaries" column from the Employees table. After that exercise, you should restore the database to the original data.
UPDATE [Employees]
SET [Salary]=[Salary]*1.12
WHERE [DepartmentID] IN (1, 2, 4, 11 )
SELECT [Salary] 
FROM [Employees]