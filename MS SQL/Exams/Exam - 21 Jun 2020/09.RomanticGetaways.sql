SELECT 
	 accT.[AccountId]
	,a.Email
	,c.[Name] AS City
	,COUNT(accT.AccountId) AS Trips
FROM AccountsTrips AS accT 
JOIN Accounts AS a ON a.Id = accT.AccountId
JOIN Trips AS t ON accT.TripId = t.Id
JOIN Rooms r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON a.CityId = c.Id
WHERE a.CityId = h.CityId
GROUP BY accT.[AccountId], a.Email, c.[Name]
ORDER BY Trips DESC, accT.[AccountId]

SELECT 
	at.[AccountId], 
	a.[Email], 
	c.[Name], 
	COUNT(at.[AccountId]) AS [Trips]
	FROM [AccountsTrips] at
	JOIN Accounts a ON a.[Id] = at.[AccountId]
	JOIN Trips t ON t.[Id] = at.[TripId]
	JOIN Rooms r ON r.[Id] = t.[RoomId]
	JOIN [Hotels] h ON h.[Id] = r.[HotelId]
	JOIN [Cities] c ON c.[Id] = h.[CityId] AND c.[Id] = a.[CityId]
	GROUP BY at.[AccountId], a.[Email], c.[Name]
	ORDER BY COUNT(at.[AccountId]) DESC, at.[AccountId]