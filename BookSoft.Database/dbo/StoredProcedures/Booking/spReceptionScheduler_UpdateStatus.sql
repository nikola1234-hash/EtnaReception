CREATE PROCEDURE [dbo].[spReceptionScheduler_UpdateStatus]
	@reservationId int,
	@statusId int
	AS

	BEGIN
		UPDATE dbo.Reservation_Status_Event SET StatusId = @statusId where ReservationId = @reservationId;
		RETURN @@ROWCOUNT;
	END