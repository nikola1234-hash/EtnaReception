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

        public bool CreateReservation(int guestId, DateTime startDate, DateTime endDate, decimal totalPrice, decimal discount = 0)
        {
            bool output = false;
            object reservation = new
            {
                GuestId = guestId,
                StartDate = startDate,
                EndDate = endDate,
                TotalPrice = totalPrice,
                Discount = discount
            };
            var rows = _unit.Reservation.CreateReservation(reservation);
            output = rows > 0;
            return output;
        }
    }
}
