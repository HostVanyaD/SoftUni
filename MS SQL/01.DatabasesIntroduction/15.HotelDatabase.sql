CREATE DATABASE Hotel;
USE Hotel;

--•	Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[FirstName] NVARCHAR(30) NOT NULL
	,[LastName] NVARCHAR(30) NOT NULL
	,[Title] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Maria','Ivanova','Receptionist',NULL),
('Dimitar','Dimitrov','Manager',NULL),
('Ivo','Minkov','Mechanic',NULL)

--•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers
(
	[AccountNumber] INT PRIMARY KEY NOT NULL
	,[FirstName] NVARCHAR(30) NOT NULL
	,[LastName] NVARCHAR(30) NOT NULL
	,[PhoneNumber] VARCHAR(15) NOT NULL
	,[EmergencyName] NVARCHAR(100) NOT NULL
	,[EmergencyNumber] VARCHAR(15) NOT NULL
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO Customers VALUES
(895215,'Lalo','B.','0895163547','Maria','0896874563',NULL),
(894268,'Nino','H.','0896874563','Luca','0897459871',NULL),
(632548,'Nico','P.','0897459871','Sara','0895163547',NULL)


--•	RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[RoomStatus] NVARCHAR(30) NOT NULL
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
('Cleaning',NULL),
('Vacant',NULL),
('Occupied',NULL)

--•	RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[RoomType] NVARCHAR(30) NOT NULL
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
('Two bedrooms',NULL),
('Single bedroom',NULL),
('Apartment',NULL)

--•	BedTypes (BedType, Notes)
CREATE TABLE BedTypes
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[BedType] NVARCHAR(30) NOT NULL
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('Single bed',NULL),
('King bed',NULL),
('Queen bed',NULL)

--•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms
(
	[RoomNumber] INT PRIMARY KEY IDENTITY NOT NULL
	,[RoomType] INT FOREIGN KEY REFERENCES RoomTypes([Id])
	,[BedType] INT FOREIGN KEY REFERENCES BedTypes([Id])
	,[Rate] DECIMAL(9, 2) NOT NULL
	,[RoomStatus] INT FOREIGN KEY REFERENCES RoomStatus([Id])
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO Rooms VALUES
(1, 1, 30, 2 ,NULL),
(2, 2, 60, 1,NULL),
(3, 3, 100, 3,NULL)

--•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id])
	,[PaymentDate] DATE NOT NULL
	,[AccountNumber] INT FOREIGN KEY REFERENCES Customers([AccountNumber])
	,[FirstDateOccupied] DATE NOT NULL
	,[LastDateOccupied] DATE NOT NULL
	,[TotalDays] AS DATEDIFF(DAY, [FirstDateOccupied], [LastDateOccupied])
	,[AmountCharged] DECIMAL(9, 2) NOT NULL
	,[TaxRate] DECIMAL(9, 2) NOT NULL
	,[TaxAmount] DECIMAL(9, 2) NOT NULL
	,[PaymentTotal] DECIMAL(18, 2) NOT NULL
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO Payments VALUES
(1, GETDATE(), 895215, GETDATE(), GETDATE(), 200.00, 20.00, 40.00, 240.00, NULL),
(2, GETDATE(), 894268, GETDATE(), GETDATE(), 200.00, 20.00, 40.00, 240.00, NULL),
(3, GETDATE(), 632548, GETDATE(), GETDATE(), 200.00, 20.00, 40.00, 240.00, NULL)

--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE Occupancies
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id])
	,[DateOccupied] DATE NOT NULL
	,[AccountNumber] INT FOREIGN KEY REFERENCES Customers([AccountNumber])
	,[RoomNumber] INT FOREIGN KEY REFERENCES Rooms([RoomNumber])
	,[RateApplied] DECIMAL(9, 2) NOT NULL
	,[PhoneCharge] DECIMAL(9, 2)
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1, GETDATE(), 895215, 1, 20.00, NULL, NULL),
(2, GETDATE(), 632548, 2, 20.00, 2.56, NULL),
(3, GETDATE(), 894268, 3, 20.00, 0.65, 'Thank you!')