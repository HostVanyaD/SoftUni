SELECT
	 rankingQuery.CountryName
	,rankingQuery.DisributorName
FROM
(SELECT
	 c.[Name] AS CountryName
	,d.[Name] AS DisributorName
	,COUNT(i.Id) AS [Count]
	,DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS [Rank]
FROM Distributors AS d
LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
JOIN Countries AS c ON c.Id = d.CountryId
GROUP BY c.[Name], d.[Name]) AS rankingQuery
WHERE rankingQuery.[Rank] = 1
ORDER BY rankingQuery.CountryName, rankingQuery.DisributorName

