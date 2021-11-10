--05. Online Store Database
CREATE DATABASE OnlineStore;

CREATE TABLE Cities
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[Birthday] DATE NOT NULL
	,[CityId] INT FOREIGN KEY REFERENCES Cities([Id])
)

CREATE TABLE Orders
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[CustomerId] INT FOREIGN KEY REFERENCES Customers([Id])
)

CREATE TABLE ItemTypes
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[ItemTypeId] INT FOREIGN KEY REFERENCES ItemTypes([Id])
)

CREATE TABLE OrderItems
(
	[OrderId] INT FOREIGN KEY REFERENCES Orders([Id])
	,[ItemId] INT FOREIGN KEY REFERENCES Items([Id])
	,PRIMARY KEY ([OrderId], [ItemId])
)



--06. University Database
CREATE DATABASE University;

CREATE TABLE Majors
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE Students
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Number] VARCHAR(50) NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[MajorID] INT FOREIGN KEY REFERENCES Majors([Id])
)

CREATE TABLE Payments
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Date] DATE NOT NULL
	,[Amount] DECIMAL(10, 2) NOT NULL
	,[StudentID] INT FOREIGN KEY REFERENCES Students([Id])
)

CREATE TABLE Subjects
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda
(
	[StudentID] INT FOREIGN KEY REFERENCES Students([Id])
	,[SubjectID] INT FOREIGN KEY REFERENCES Subjects([Id])
	,PRIMARY KEY([StudentID], [SubjectID])
)



--09. *Peaks in Rila
SELECT [MountainRange], [PeakName], [Elevation] 
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
WHERE [MountainRange] = 'Rila'
ORDER BY [Elevation] DESC;