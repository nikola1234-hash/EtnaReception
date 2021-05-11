CREATE PROCEDURE [dbo].[spReception_LoadRoomScheduler]
AS
BEGIn

SELECT        Room.Id, RoomNumber, RoomReservation.Persons, Reservation.StartDate, 
              Reservation.EndDate, StayType.Title, Reservation.TotalPrice, Reservation.DiscountPercent,
			  Guest.FirstName, Guest.LastName, Guest.Phone, Guest.Email, Guest.[Address]
FROM            Room  LEFT JOIN
                         RoomReservation ON RoomReservation.RoomId = Room.Id 
						 LEFT JOIN
                         Reservation ON RoomReservation.ReservationId = Reservation.Id 
						 LEFT JOIN
                         StayType ON RoomReservation.StayTypeId = StayType.Id
						 LEFT JOIN Guest ON Reservation.GuestId = Guest.Id
						 ORDER BY RoomNumber ASC
END