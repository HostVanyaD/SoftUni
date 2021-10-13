CREATE PROC usp_PlaceOrder(@jobId INT, @partSerialNumber VARCHAR(50), @quantity INT)
AS
BEGIN
	DECLARE @status VARCHAR(11) = (SELECT [Status] FROM Jobs WHERE JobId = @jobId)

	IF(@status = 'Finished') THROW 50011,'This job is not active!',1
	ELSE IF(@quantity <= 0) THROW 50012,'Part quantity must be more than zero!',1
	ELSE IF(NOT EXISTS(SELECT JobId FROM Jobs WHERE JobId = @jobId)) THROW 50013,'Job not found!',1
	ELSE IF(NOT EXISTS(SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)) THROW 50014,'Part not found!',1

	IF((SELECT COUNT(*) FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL) <> 1)
	BEGIN
		INSERT INTO Orders(JobId, IssueDate)
		VALUES (@jobId, NULL)
	END

	DECLARE @orderId INT = (SELECT OrderId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL)
	DECLARE @partId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)

	IF((SELECT COUNT(*) FROM OrderParts WHERE OrderId = @orderId AND PartId = @partId) <> 1)
	BEGIN
		INSERT INTO OrderParts
		VALUES (@orderId, @partId, @quantity)
	END
	ELSE
	BEGIN
		UPDATE OrderParts
			SET Quantity += @quantity
			WHERE OrderId = @orderId AND PartId = @partId
	END
END