using System;

namespace BookSoft.BLL.Services
{
    public interface IReservationService
    {
        public bool CreateReservation(int guestId, DateTime startDate, DateTime endDate, decimal totalPrice, decimal discount = 0);
    }
}
