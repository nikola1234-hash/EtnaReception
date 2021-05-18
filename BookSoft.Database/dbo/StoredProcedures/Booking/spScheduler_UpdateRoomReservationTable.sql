CREATE PROCEDURE [dbo].[spScheduler_UpdateRoomReservationTable]
	@reservationId int,
	@roomId int,
	@persons int,
	@stayTypeId int
	AS
	BEGIN
		UPDATE dbo.RoomReservation SET RoomId = @roomId,
		Persons = @persons, StayTypeId = @stayTypeId WHERE ReservationId = @reservationId;

	END