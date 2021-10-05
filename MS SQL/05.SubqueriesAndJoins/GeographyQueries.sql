--12.Highest Peaks in Bulgaria

--•	CountryCode
--•	MountainRange
--•	PeakName
--•	Elevation

SELECT 
	 mc.[CountryCode]
	,m.[MountainRange]
	,p.[PeakName]
	,p.[Elevation]
FROM Peaks AS p
JOIN Mountains AS m ON p.[MountainId] = m.[Id]
JOIN MountainsCountries AS mc ON m.[Id] = mc.[MountainId]
WHERE p.[Elevation] > 2835 
	  AND mc.[CountryCode] = 'BG'
ORDER BY p.[Elevation] DESC



--13. Count Mountain Ranges

SELECT 
	 mc.[CountryCode]
	,COUNT(m.[MountainRange]) AS [MountainRanges]
FROM Mountains AS m
JOIN MountainsCountries AS mc ON m.[Id] = mc.[MountainId]
WHERE mc.[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY mc.[CountryCode]



--14. Countries With or Without Rivers

SELECT TOP(5)
		c.[CountryName]
	   ,r.[RiverName]
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN Rivers AS r ON cr.[RiverId] = r.[Id]
WHERE c.[ContinentCode] = 'AF'
ORDER BY c.[CountryName]



--15. Continents and Currencies

SELECT RankingSubQuery.[ContinentCode]
	  ,RankingSubQuery.[CurrencyCode]
	  ,RankingSubQuery.[CurrencyUsage]
FROM
(SELECT 
	 c.[ContinentCode]
    ,c.[CurrencyCode]
	,COUNT(c.[CurrencyCode]) AS [CurrencyUsage]
	,DENSE_RANK() OVER (PARTITION BY c.[ContinentCode] ORDER BY COUNT(c.[CurrencyCode]) DESC) AS [Ranking]
FROM Countries AS c
GROUP BY c.[ContinentCode], c.[CurrencyCode]) AS RankingSubQuery
WHERE RankingSubQuery.[Ranking] = 1 AND RankingSubQuery.[CurrencyUsage] > 1



--16. Countries Without any Mountains

SELECT COUNT(*) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.[CountryCode] = mc.[CountryCode]
WHERE mc.[MountainId] IS NULL



--17. Highest Peak and Longest River by Country
--CountryName	HighestPeakElevation	LongestRiverLength

SELECT TOP(5)
	  c.[CountryName]
	 ,MAX(p.[Elevation]) AS [HighestPeakElevation]
	 ,MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON C.[CountryCode] = mc.[CountryCode]
LEFT JOIN Mountains AS m ON mc.[MountainId] = m.[Id]
LEFT JOIN Peaks AS p ON m.[Id] = p.[MountainId]
LEFT JOIN CountriesRivers AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN Rivers AS r ON cr.[RiverId] = r.[Id]
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.[CountryName]



--18. Highest Peak Name and Elevation by Country
--Country	Highest Peak Name	Highest Peak Elevation	Mountain

SELECT TOP(5)
	 pr.[CountryName] AS [Country]
	,ISNULL(pr.[PeakName], '(no highest peak)') AS [Highest Peak Name]
	,ISNULL(pr.[HighestPeakName], 0) AS [Highest Peak Elevation]
	,ISNULL(pr.[MountainRange], '(no mountain)') AS [Mountain]
FROM( 
SELECT 
	 c.[CountryName]
	,p.[PeakName]
	,MAX(p.[Elevation]) AS [HighestPeakName]
	,m.[MountainRange]
	,DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY MAX(p.[Elevation]) DESC) AS [PeakRank] 
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN Mountains AS m ON mc.[MountainId] = m.[Id]
LEFT JOIN Peaks AS p ON m.[Id] = p.[MountainId]
GROUP BY c.CountryName, m.MountainRange, p.PeakName) AS pr
WHERE PeakRank = 1
ORDER BY [Country], [Highest Peak Name]
