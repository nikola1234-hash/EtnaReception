CREATE PROCEDURE [dbo].[spReceptionScheduler_UpdateReservation]
	@id int,
	@startDate date,
	@endDate date
	AS
	BEGIN
		UPDATE
		dbo.Reservation 
		SET
		StartDate = @startDate, 
		EndDate = @endDate, 
		Updated = GETDATE() 
		WHERE
		Id = @id;
		BEGIN 
			SELECT * 
			FROM dbo.Reservation
			WHERE Id = @id
		END
	END