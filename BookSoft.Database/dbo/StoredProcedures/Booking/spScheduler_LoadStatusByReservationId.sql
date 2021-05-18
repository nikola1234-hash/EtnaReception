CREATE PROCEDURE [dbo].[spScheduler_LoadStatusByReservationId]
	@reservationId int
AS
BEGIN
	SELECT StatusId AS Id from dbo.Reservation_Status_Event where ReservationId = @reservationId;
END
