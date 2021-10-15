SELECT 
	 u.Username
	,AVG(f.Size) AS AverageSize
FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY AverageSize DESC, u.Username
