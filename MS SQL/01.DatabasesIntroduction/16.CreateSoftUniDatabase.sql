--•	Towns (Id, Name)
CREATE TABLE Towns
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[Name] NVARCHAR(90) NOT NULL
)

--•	Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[AddressText] NVARCHAR(300) NOT NULL
	,[TownId] INT FOREIGN KEY REFERENCES Towns([Id])
)

--•	Departments (Id, Name)
CREATE TABLE Departments
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[Name] NVARCHAR(50) NOT NULL
)

--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[FirstName] NVARCHAR(30) NOT NULL
	,[MiddleName] NVARCHAR(30)
	,[LastName] NVARCHAR(30) NOT NULL
	,[JobTitle] NVARCHAR(30) NOT NULL
	,[DepartmentId] INT FOREIGN KEY REFERENCES Departments([Id])
	,[HireDate] DATE NOT NULL
	,[Salary] INT NOT NULL
	,[AddressId] INT FOREIGN KEY REFERENCES Addresses([Id])
)


