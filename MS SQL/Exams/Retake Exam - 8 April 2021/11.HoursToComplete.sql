CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF((@StartDate IS NULL) OR (@EndDate IS NULL)) RETURN 0

	DECLARE @hours INT = DATEDIFF(HOUR, @startDate, @endDate)
	RETURN @hours
END
