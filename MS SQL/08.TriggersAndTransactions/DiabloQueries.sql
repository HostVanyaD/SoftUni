--19.Trigger

CREATE TRIGGER tr_UserGameItemsWithMinLevel
ON UserGameItems 
INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO UserGameItems
	SELECT i.[Id], ug.[Id]
	FROM inserted	
	JOIN UsersGames AS ug ON UserGameId = ug.[Id]
	JOIN Items AS i ON ItemId = i.[Id]
	WHERE ug.[Level] >= i.[MinLevel]
END
GO

UPDATE UsersGames
SET [Cash] += 50000
FROM UsersGames AS ug
JOIN Users AS u ON ug.[UserId] = u.[Id]
JOIN Games AS g ON ug.[GameId] = g.[Id]
WHERE g.[Name] = 'Bali' AND u.[Username] IN('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
GO

CREATE PROC usp_BuyItems(@username VARCHAR(100))
AS
BEGIN
	DECLARE @userId INT = (SELECT [Id] FROM Users WHERE [Username] = @username)
	DECLARE @gameId INT = (SELECT [Id] FROM Games WHERE [Name] = 'Bali')
	DECLARE @userGameId INT = (SELECT [Id] FROM UsersGames WHERE [UserId] = @userId AND [GameId] = @gameId)
	DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE [Id] = @userGameId)

	DECLARE @counter INT = 251

	WHILE(@counter <= 539)
	BEGIN
		DECLARE @itemId INT = @counter
		DECLARE @itemPrice MONEY = (SELECT [Price] FROM Items WHERE [Id] = @itemId)
		DECLARE @itemLevel INT = (SELECT [MinLevel] FROM Items WHERE [Id] = @itemId)
		DECLARE @userGameCash MONEY = (SELECT [Cash] FROM UsersGames WHERE [Id] = @userGameId)

		IF(@userGameCash >= @itemPrice AND @userGameLevel >= @itemLevel)
		BEGIN
			UPDATE UsersGames
			SET [Cash] -= @itemPrice
			WHERE [Id] = @userGameId

			INSERT INTO UserGameItems
			VALUES (@itemId, @userGameId)
	    END

		SET @counter += 1
		
		IF(@counter = 300)
			SET @counter = 501
	END
END
GO

EXEC usp_BuyItems 'baleremuda'
EXEC usp_BuyItems 'loosenoise'
EXEC usp_BuyItems 'inguinalself'
EXEC usp_BuyItems 'buildingdeltoid'
EXEC usp_BuyItems 'monoxidecos'
GO

SELECT 
	u.[Username]
   ,g.[Name] AS [Name]
   ,ug.[Cash]
   ,i.[Name] AS [Item Name]
FROM Users AS u
JOIN UsersGames AS ug ON u.[Id] = ug.[UserId]
JOIN Games AS g ON ug.[GameId] = g.[Id]
JOIN UserGameItems AS ugi ON ug.[Id] = ugi.[UserGameId]
JOIN Items AS i ON ugi.[ItemId] = i.[Id]
WHERE g.Name = 'Bali'
ORDER BY u.[Username], i.[Name]
GO




--20. *Massive Shopping

DECLARE @userId INT = (SELECT [Id] FROM Users WHERE [Username] = 'Stamat')
DECLARE @gameId INT = (SELECT [Id] FROM Games WHERE [Name] = 'Safflower')
DECLARE @userGameId INT = (SELECT [Id] FROM UsersGames WHERE [UserId] = @userId AND [GameId] = @gameId)
DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE [Id] = @userGameId)
DECLARE @itemStartLevel INT = 11
DECLARE @itemEndLevel INT = 12
DECLARE @totalPrice MONEY = (SELECT SUM([Price]) FROM Items WHERE ([MinLevel] BETWEEN @itemStartLevel AND @itemEndLevel))
DECLARE @usersCash MONEY = (SELECT [Cash] FROM UsersGames WHERE [Id] = @userGameId)

IF(@usersCash >= @totalPrice)
BEGIN
	BEGIN TRANSACTION
			   UPDATE UsersGames
			      SET [Cash] -= @totalPrice
			    WHERE [Id] = @userGameId

			   INSERT INTO UserGameItems
			        SELECT i.[Id], @userGameId
			          FROM Items AS i
			         WHERE (i.[MinLevel] BETWEEN @itemStartLevel AND @itemEndLevel)
	COMMIT
END

SELECT 
	 i.[Name] AS [Item Name]
FROM Users AS u
JOIN UsersGames AS ug ON u.[Id] = ug.[UserId]
JOIN Games AS g ON ug.[GameId] = g.[Id]
JOIN UserGameItems AS ugi ON ug.[Id] = ugi.[UserGameId]
JOIN Items AS i ON ugi.[ItemId] = i.[Id]
WHERE u.[Username] = 'Stamat' AND g.[Name] = 'Safflower'
ORDER BY i.[Name]
