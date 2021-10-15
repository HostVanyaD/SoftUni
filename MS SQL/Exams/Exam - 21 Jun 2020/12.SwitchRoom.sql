CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @targetHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @currentRoomId INT = (SELECT RoomId FROM Trips WHERE Id = @TripId)
	DECLARE @currentHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @currentRoomId)

	IF(@targetHotelId <> @currentHotelId)
	BEGIN
		RAISERROR('Target room is in another hotel!',16,1)
		RETURN
	END

	DECLARE @tripAccounts INT = (SELECT COUNT(TripId) FROM AccountsTrips WHERE TripId = @TripId)
	DECLARE @bedsInTargetRoom INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId) 

	IF(@tripAccounts > @bedsInTargetRoom)
	BEGIN
		RAISERROR('Not enough beds in target room!',16,1)
		RETURN
	END

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId
END