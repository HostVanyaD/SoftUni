--13. *Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
RETURNS @table TABLE([SumCash] DECIMAL(18, 4))
AS
BEGIN
	DECLARE 
	@sumCash DECIMAL(18, 2) = (SELECT SUM(result.[Cash])
							   FROM 
								  (SELECT [Cash]
										,ROW_NUMBER() OVER (ORDER BY [Cash] DESC) AS [Rows]
								    FROM UsersGames
								   WHERE [GameId] IN 
											(SELECT [Id] 
										       FROM Games
										      WHERE [Name] = @gameName)) AS result
							  WHERE result.[Rows] % 2 != 0)
	INSERT INTO @table 
	VALUES (@sumCash)
	RETURN
END