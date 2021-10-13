CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(18, 2)
AS
BEGIN
	DECLARE @cost DECIMAL(18, 2) = 
			(SELECT SUM(p.Price * op.Quantity)
			   FROM Jobs AS j
			   LEFT JOIN Orders AS o ON j.JobId = o.JobId
			   LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
			   LEFT JOIN Parts AS p ON op.PartId = p.PartId
			   WHERE j.JobId = @jobId)

	IF(@cost IS NULL)
		SET @cost = 0

	RETURN @cost
END
GO 

SELECT dbo.udf_GetCost(1)