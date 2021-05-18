CREATE PROCEDURE [dbo].[spReception_LoadRoomScheduler]
AS
BEGIn

SELECT        Room.Id, RoomNumber, RoomReservation.Persons, Reservation.StartDate, 
              Reservation.EndDate, StayType.Title, StayTypeId ,Reservation.TotalPrice, Reservation.DiscountPercent,
			  Guest.FirstName, Guest.LastName, Guest.Phone, Guest.Email, Guest.[Address], Reservation.Id as ReservationId
FROM            Room  LEFT JOIN
                         RoomReservation ON RoomReservation.RoomId = Room.Id 
						 LEFT JOIN
                         Reservation ON RoomReservation.ReservationId = Reservation.Id 
						 LEFT JOIN
                         StayType ON RoomReservation.StayTypeId = StayType.Id
						 LEFT JOIN Guest ON Reservation.GuestId = Guest.Id
						 LEFT JOIN Reservation_Status_Event as Rse On Reservation.Id = Rse.ReservationId
						 WHERE Reservation.Id not in
						 (select rse.ReservationId from dbo.Reservation_Status_Event as rse where rse.StatusId = 4)
						 ORDER BY RoomNumber ASC;
END