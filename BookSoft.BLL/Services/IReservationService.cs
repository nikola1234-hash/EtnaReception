using System;

namespace BookSoft.BLL.Services
{
    public interface IReservationService
    {
        public int CreateReservation(int guestId, DateTime startDate, DateTime endDate, decimal totalPrice, decimal discount = 0);
        public int CreateRoomReservation(int reservationId, int roomId, int persons, int stayTypeId);
    }
}
