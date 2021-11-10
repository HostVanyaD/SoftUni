SELECT 
	 t.Id
	,CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName + ' ', ''), a.LastName) AS [Full Name]
	,ca.[Name] AS [From]
	,ch.[Name] AS [To]
	,CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE
			CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' days')		
		END
FROM AccountsTrips AS acct 
JOIN Accounts AS a ON acct.AccountId = a.Id
JOIN Cities AS ca ON a.CityId = ca.Id
JOIN Trips AS t ON acct.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS ch ON h.CityId = ch.Id
ORDER BY [Full Name], t.Id