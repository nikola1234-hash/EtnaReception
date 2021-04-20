CREATE PROCEDURE [dbo].[spRooms_GetAvailableRoomsByDates]
	@startDate date,
	@endDate date,
	@numberOfPeople int
	AS
	BEGIN
	set nocount on;
		select r.RoomNumber , roc.Capacity, rt.[Type] 
		from dbo.Room as r
		inner join dbo.RoomCapacity as roc ON r.CapacityId = roc.Id
		inner join dbo.RoomType as rt on r.RoomTypeId = rt.Id
		where roc.Capacity >= @numberOfPeople AND r.Id NOT IN
		(Select rr.RoomId from dbo.RoomReservation as rr
		inner join dbo.Reservation as re ON rr.ReservationId = re.Id
		WHERE (@startDate < re.StartDate AND @endDate < re.EndDate)
		OR(re.StartDate <= @endDate AND @endDate < re.EndDate)
		OR(re.StartDate <= @startDate AND @startDate < re.EndDate));
	END
