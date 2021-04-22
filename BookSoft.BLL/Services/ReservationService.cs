using BookSoft.DAL;
using System;

namespace BookSoft.BLL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unit;

        public ReservationService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public int CreateReservation(int guestId, DateTime startDate, DateTime endDate, decimal totalPrice, decimal discount = 0)
        {
            object reservation = new
            {
                GuestId = guestId,
                StartDate = startDate,
                EndDate = endDate,
                TotalPrice = totalPrice,
                DiscountPercent = discount
            };
            int output = _unit.Reservation.CreateReservation(reservation);
            return output;
        }

        public int CreateRoomReservation(int reservationId, int roomId, int persons, int stayTypeId)
        {
            object roomReservation = new
            {
                ReservationId = reservationId,
                RoomId = roomId,
                Persons = persons,
                StayTypeId = stayTypeId
            };
            var id = _unit.Reservation.CreateRoomReservation(roomReservation);
            return id;
        }
    }
}
