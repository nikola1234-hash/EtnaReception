CREATE PROCEDURE [dbo].[spRoomReservation_LoadByReservationId]
	@reservationId int
	AS
	BEGIN
		SELECT [Id], [ReservationId], [RoomId], [Persons], [StayTypeId] from dbo.RoomReservation where ReservationId = @reservationId;
	END