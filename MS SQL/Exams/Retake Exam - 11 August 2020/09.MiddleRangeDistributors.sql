SELECT 
	 d.[Name] AS DistributorName
	,i.[Name] AS IngredientName
	,p.[Name] AS ProductName
	,AVG(f.Rate) AS AverageRate
FROM ProductsIngredients AS ping 
JOIN Ingredients AS i ON ping.IngredientId = i.Id
JOIN Products AS p ON ping.ProductId = p.Id
JOIN Distributors AS d ON i.DistributorId = d.Id
JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.[Name], i.[Name], p.[Name]
