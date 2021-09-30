--18. Orders Table

--ProductName	OrderDate	Pay Due   	Deliver Due

SELECT [ProductName]
	  ,[OrderDate]
	  ,DATEADD(DAY, 3, [OrderDate]) AS [Pay Due]
	  ,DATEADD(MONTH, 1,  [OrderDate]) AS [Deliver Due]
FROM Orders;




--19.People Table

CREATE TABLE People
(
[Id] INT IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[BirthDate] DATETIME NOT NULL
);

INSERT INTO People([Name], [Birthdate])
VALUES
	  ('Ivo', '1979-07-06 00:00:00.000'),
	  ('Vanya', '1989-03-24 00:00:00.000'),
	  ('Lachezar', '2016-01-04 18:05:00.000'),
	  ('Boril', '2017-09-21 12:05:00.000');

SELECT [Name] --Age in Years	Age in Months	Age in Days	Age in Minutes
	  ,DATEDIFF(YEAR, [BirthDate], GETDATE()) AS [Age in Years]
	  ,DATEDIFF(MONTH, [BirthDate], GETDATE()) AS [Age in Months]
	  ,DATEDIFF(DAY, [BirthDate], GETDATE()) AS [Age in Days]
	  ,DATEDIFF(MINUTE, [BirthDate], GETDATE()) AS [Age in Minutes]
FROM People;