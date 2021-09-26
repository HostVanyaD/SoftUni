CREATE DATABASE CarRental;

--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories
(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL
	,[CategoryName] NVARCHAR(30) NOT NULL
	,[DailyRate] DECIMAL(9, 2) 
	,[WeeklyRate] DECIMAL(9, 2)
	,[MonthlyRate] DECIMAL(9, 2)
	,[WeekendRate] DECIMAL(9, 2)
)

--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars
(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL
	,[PlateNumber] NVARCHAR(20) NOT NULL
	,[Manufacturer] NVARCHAR(30) NOT NULL
	,[Model] NVARCHAR(30) NOT NULL
	,[CarYear] INT NOT NULL
	,[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id])
	,[Doors] TINYINT NOT NULL
	,[Picture] VARBINARY(MAX)
	,[Condition] NVARCHAR(MAX)
	,[Available] BIT NOT NULL
)

--•	Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL
	,[FirstName] NVARCHAR(30) NOT NULL
	,[LastName] NVARCHAR(30) NOT NULL
	,[Title] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX)
)

--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers
(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL
	,[DriverLicenceNumber] INT NOT NULL
	,[FullName] NVARCHAR(90) NOT NULL
	,[Address] NVARCHAR(100) NOT NULL
	,[City] NVARCHAR(90) NOT NULL
	,[ZIPCode] INT NOT NULL
	,[Notes] NVARCHAR(MAX)
)

--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
CREATE TABLE RentalOrders
(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL
	,[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id])
	,[CustomerId] INT FOREIGN KEY REFERENCES Customers([Id])
	,[CarId] INT FOREIGN KEY REFERENCES Cars([Id])
	,[TankLevel] TINYINT NOT NULL
	,[KilometrageStart] INT NOT NULL
	,[KilometrageEnd] INT NOT NULL
	,[TotalKilometrage] AS ([KilometrageEnd] - [KilometrageStart])
	,[StartDate] DATE NOT NULL
	,[EndDate] DATE NOT NULL
	,[TotalDays] AS DATEDIFF(DAY, [StartDate], [EndDate])
	,[RateApplied] DECIMAL(9, 2)
	,[TaxRate] DECIMAL(9, 2)
	,[OrderStatus] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX)
)

INSERT INTO Categories ([CategoryName], [DailyRate], [WeekLyRate], [MonthlyRate], [WeekendRate]) 
     VALUES ('Car', 20, 120, 500, 42.50),
            ('Bus', 250, 1600, 6000, 489.99),
            ('Truck', 500, 3000, 11900, 949.90)

INSERT INTO Cars ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available]) 
     VALUES ('123456ABCD', 'Cadillac', 'Escalade', 2014, 1, 5, 123456, 'Perfect', 1),
            ('asdafof145', 'Mercedes', 'Vito', 2017, 2, 5, 99999, 'Perfect', 1),
            ('asdp230456', 'MAN', 'TGX', 2016, 3, 2, 123456, 'Perfect', 1)

INSERT INTO Employees ([FirstName], [LastName], [Title]) 
     VALUES ('Borislav', 'Ivanov', 'Seller'),
            ('Georgi', 'Georgiev', 'Seller'),
            ('Miroslav', 'Dimitrov', 'Manager')

INSERT INTO Customers ([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
     VALUES (123456789, 'Vlado Penev', '5 Koruna str.', 'Prague', 1233, 'Excellent driver'),
            (347645231, 'Silvy D.', '1 May str.', 'Varna', 5678, 'Bad driver'),
            (123574322, 'Benny Benassy', '5 Avenue', 'NY', 5689, 'Good driver')

INSERT INTO RentalOrders ([EmployeeId],[CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [OrderStatus]) 
     VALUES (1, 1, 1, 54, 2189, 2456, '2021-09-05', '2021-09-08', '3 days rent'),
            (2, 2, 2, 22, 13565, 14258, '2021-09-06', '2021-09-11', '5 days rent'),
            (3, 3, 3, 180, 1202, 1964, '2021-09-09', '2021-10-09', '1 month rent')