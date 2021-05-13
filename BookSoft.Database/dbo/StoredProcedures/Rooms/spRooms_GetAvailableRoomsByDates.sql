CREATE PROCEDURE [dbo].[spRooms_GetAvailableRoomsByDates]
	@startDate date,
	@endDate date,
	@numberOfPeople int
	AS
	BEGIN
	set nocount on;
		select r.Id, r.RoomNumber , roc.Capacity, rt.[Type] 
		from dbo.Room as r
		inner join dbo.RoomCapacity as roc ON r.CapacityId = roc.Id
		inner join dbo.RoomType as rt on r.RoomTypeId = rt.Id
		
		where roc.Capacity >= @numberOfPeople AND r.Id NOT IN
		(Select rr.RoomId from dbo.RoomReservation as rr
		inner join dbo.Reservation as re ON rr.ReservationId = re.Id
		inner join dbo.Reservation_Status_Event as rse ON rr.ReservationId = rse.ReservationId
		WHERE re.Id not in (select rsee.ReservationId 
		from dbo.Reservation_Status_Event as rsee where rsee.StatusId = 4 )
		AND
		(@startDate < re.StartDate AND @endDate < re.EndDate)
		OR(re.StartDate <= @endDate AND @endDate < re.EndDate)
		OR(re.StartDate <= @startDate AND @startDate < re.EndDate));
	END
