--22.Display all mountain peaks in alphabetical order.
SELECT [PeakName]
FROM [Peaks]
ORDER BY [PeakName] ASC;

--23.Find the 30 biggest countries by population located in Europe. Display the "CountryName" and "Population". Sort the results by population (from biggest to smallest), then by country alphabetically.
SELECT TOP(30)
		[CountryName]
		,[Population]
FROM Countries
WHERE [ContinentCode] IN ('EU')
ORDER BY [Population] DESC
		,[CountryName] ASC;

--24.Find all countries along with information about their currency. Display the "CountryName", "CountryCode", and information about its "Currency": either "Euro" or "Not Euro". Sort the results by country name alphabetically.
SELECT [CountryName]
		,[CountryCode]
		,CASE
		WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
		END AS [Currency]
FROM Countries
ORDER BY [CountryName] ASC;
