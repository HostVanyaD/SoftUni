--14. Create Table Logs

CREATE TABLE Logs
(
	 LogId INT PRIMARY KEY IDENTITY
	,AccountId INT
	,OldSum MONEY
	,NewSum MONEY
)
GO

CREATE TRIGGER tr_ChangingSumLog
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs([AccountId], [OldSum], [NewSum])
	SELECT i.[Id], d.[Balance], i.[Balance]
	FROM inserted AS i
	JOIN deleted AS d ON d.[Id] = i.[Id]
	WHERE i.Balance != d.Balance
END

GO


--15. Create Table Emails

CREATE TABLE NotificationEmails
(
	 [Id] INT PRIMARY KEY IDENTITY
	,[Recipient] INT
	,[Subject] VARCHAR(100)
	,[Body] VARCHAR(MAX)
)
GO

CREATE TRIGGER tr_SendingEmailWhenBalanceIsChanged
ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails([Recipient], [Subject], [Body])
	SELECT 
		 i.[AccountId]
		,CONCAT('Balance change for account: ', CAST(i.[AccountId] AS VARCHAR(12)))
		,CONCAT('On '
		        ,CAST(GETDATE() AS VARCHAR(12))
				,' your balance was changed from '
				, CAST(i.[OldSum] AS VARCHAR(20))
				,' to '
				, CAST(i.[NewSum] AS VARCHAR(20))
				, '.')
	FROM inserted AS i
END
GO

--16. Deposit Money

CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(20, 4))
AS
BEGIN TRANSACTION
		IF(@moneyAmount < 0 OR @moneyAmount IS NULL)
			ROLLBACK

		IF(NOT EXISTS(SELECT a.[Id] 
					 FROM Accounts AS a
					 WHERE a.[Id] = @accountId) 
		   OR @accountId IS NULL)
			ROLLBACK

		UPDATE Accounts
	       SET [Balance] += @moneyAmount
		 WHERE @accountId = [Id]
COMMIT
GO


--17. Withdraw Money Procedure

CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(20, 4))
AS
BEGIN TRANSACTION
	IF(@moneyAmount < 0 OR @moneyAmount IS NULL)
	   ROLLBACK

	IF(NOT EXISTS(SELECT a.[Id] 
				    FROM Accounts AS a
				   WHERE a.[Id] = @accountId) 
	   OR @accountId IS NULL)
	   ROLLBACK

	UPDATE Accounts
	   SET [Balance] -= @moneyAmount
	 WHERE [Id] = @accountId
COMMIT
GO



--18. Money Transfer

CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(20, 4))
AS
BEGIN TRANSACTION
	EXEC usp_WithdrawMoney @senderId, @amount
	EXEC usp_DepositMoney @receiverId, @amount
COMMIT

GO



--20. *Massive Shopping

