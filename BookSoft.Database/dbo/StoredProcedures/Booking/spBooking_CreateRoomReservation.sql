CREATE PROCEDURE [dbo].[spBooking_CreateRoomReservation]
	@ReservationId int,
	@RoomId int,
	@Persons int,
	@StayTypeId int
	AS
	BEGIN
		INSERT INTO dbo.RoomReservation(ReservationId, RoomId, Persons, StayTypeId)
		VALUES 
		(@ReservationId, @RoomId, @Persons, @StayTypeId);
		RETURN @@IDENTITY;
	END
