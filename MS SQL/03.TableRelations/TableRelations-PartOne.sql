CREATE DATABASE TableRelations;
USE TableRelations;

--01.Create two tables and use appropriate data types.

CREATE TABLE Persons
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[FirstName] VARCHAR(30) NOT NULL
	,[Salary] DECIMAL(10, 2) NOT NULL
	,[PassportID] INT NOT NULL
)

CREATE TABLE Passports
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[PassportNumber] VARCHAR(8) NOT NULL
)

ALTER TABLE Persons
ADD CONSTRAINT FK_PersonsPassports FOREIGN KEY ([PassportID]) REFERENCES Passports([Id])



--02.One-To-Many Relationship

CREATE TABLE Manufacturers
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[EstablishedOn] DATE NOT NULL
)

CREATE TABLE Models
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers([Id])
)


--03. Many-To-Many Relationship

CREATE TABLE Students
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	[StudentID] INT FOREIGN KEY REFERENCES Students([Id])
	,[ExamID] INT FOREIGN KEY REFERENCES Exams([Id])
	CONSTRAINT PK_StudentsExams PRIMARY KEY CLUSTERED([StudentID], [ExamID])
)


--04. Self-Referencing

CREATE TABLE Teachers	
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL
	,[ManagerID] INT FOREIGN KEY REFERENCES Teachers([Id])
)


