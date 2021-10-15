CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @roomId INT =
			(SELECT TOP(1) r.Id
			FROM Rooms AS r
			JOIN Trips AS t ON r.Id= t.RoomId
			WHERE r.HotelId = @HotelId
			  AND r.Beds > @People
			  AND ((@Date >= t.ArrivalDate AND @Date <= t.ReturnDate AND t.CancelDate IS NOT NULL) 
				  OR (@Date < t.ArrivalDate OR @Date > t.ReturnDate))
			ORDER BY r.Price DESC)

	IF((SELECT COUNT(Id) FROM Rooms WHERE Id = @roomId) < 1)
		RETURN 'No rooms available'

	DECLARE @HotelBaseRate DECIMAL(18,2) = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
	DECLARE @RoomPrice DECIMAL(18,2) = (SELECT Price FROM Rooms WHERE Id = @RoomId)
	DECLARE @RoomType NVARCHAR(20) = (SELECT [Type] FROM Rooms WHERE Id = @RoomId)
	DECLARE @RoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @RoomId)
	DECLARE @TotalPrice DECIMAL(18,2) = (@HotelBaseRate + @RoomPrice) * @People

	RETURN CONCAT('Room ',@RoomId,': ',@RoomType,' (',@RoomBeds,' beds) - $',@TotalPrice)
END