--12. Countries Holding 'A'

SELECT [CountryName] AS [Country Name]
	  ,[ISOCode] AS [ISO Code]
FROM Countries
WHERE [CountryName] LIKE '%A%A%A%'
ORDER BY [ISOCode];



--13. Mix of Peak and River Names

SELECT p.[PeakName]
      ,r.[RiverName]
	  ,LOWER(CONCAT(LEFT(p.[PeakName], LEN(p.[PeakName]) - 1), r.[RiverName])) AS [Mix]
FROM Peaks AS p
    ,Rivers AS r
WHERE LOWER(RIGHT(p.[PeakName], 1)) = LOWER(LEFT(r.[RiverName], 1))
ORDER BY [Mix];