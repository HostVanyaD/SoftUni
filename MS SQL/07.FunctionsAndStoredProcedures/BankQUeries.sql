--09. Find Full Name

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT([FirstName], ' ', [LastName]) AS [Full Name]
	FROM AccountHolders
END
GO



--10. People with Balance Higher Than

CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(18, 4))
AS
BEGIN
	SELECT ah.[FirstName], ah.[LastName]
	FROM AccountHolders AS ah
	JOIN Accounts AS acc ON ah.[Id] = acc.[AccountHolderId]
	GROUP BY ah.[FirstName], ah.[LastName]
	HAVING SUM(acc.[Balance]) > @number
	ORDER BY ah.[FirstName], ah.[LastName]
END

EXEC usp_GetHoldersWithBalanceHigherThan 50000
GO




--11. Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(18, 4), @yearlyRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
BEGIN
	RETURN (@initialSum * (POWER((1 + @yearlyRate), @years)))
END

GO


--12. Calculating Interest

CREATE PROC usp_CalculateFutureValueForAccount(@accountID INT, @interestRate FLOAT)
AS
BEGIN
	DECLARE @years INT = 5

	SELECT acc.[Id] AS [Account Id]
		  ,ah.[FirstName] AS [First Name]
		  ,ah.[LastName] AS [Last Name]
		  ,acc.[Balance] AS [Current Balance]
		  ,dbo.ufn_CalculateFutureValue(acc.[Balance], @interestRate, @years) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS acc ON ah.[Id] = acc.[AccountHolderId]
	WHERE acc.[Id] = @accountID
END

GO