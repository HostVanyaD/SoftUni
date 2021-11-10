SELECT TOP(5) 
	 r.Id
	,r.[Name]
	,COUNT(*) AS Commits
FROM Repositories AS r
JOIN Commits AS c ON r.Id = c.RepositoryId
JOIN RepositoriesContributors AS rc ON r.Id= rc.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY Commits DESC, r.Id, r.[Name]