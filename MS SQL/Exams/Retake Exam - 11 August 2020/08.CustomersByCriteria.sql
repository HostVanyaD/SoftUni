SELECT 
	 c.FirstName
	,c.Age
	,c.PhoneNumber
FROM Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id
WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') OR ((c.PhoneNumber LIKE '%38') AND co.[Name] NOT IN ('Greece'))
ORDER BY c.FirstName, c.Age DESC