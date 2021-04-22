CREATE PROCEDURE [dbo].[spBooking_CreateReservation]
	@GuestId int,
	@StartDate date,
	@EndDate date,
	@DiscountPercent decimal,
	@TotalPrice decimal
	AS
	BEGIN
		insert into dbo.Reservation(GuestId, StartDate, EndDate, DiscountPercent, TotalPrice, Created, Updated)
		values
		(@GuestId, @StartDate, @EndDate, @DiscountPercent, @TotalPrice, GETDATE(), GETDATE())
		RETURN @@IDENTITY;
	END