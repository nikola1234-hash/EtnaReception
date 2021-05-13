CREATE PROCEDURE [dbo].[spReceptionScheduler_CancelReservation]
	@reservationId int
	AS
	BEGIN
		UPDATE dbo.Reservation_Status_Event SET StatusId = 4 WHERE ReservationId = @reservationId;
		Return @@ROWCOUNT
	END
