using BookSoft.Domain;
using BookSoft.Domain.Models;
using System.Linq;

namespace BookSoft.DAL.Repositories
{
    public class ReservationRepository
    {
        private readonly IDataService _data;

        public ReservationRepository(IDataService data)
        {
            _data = data;
        }
        public int CreateReservation(object reservation)
        {
            var id = _data.LoadData<int, dynamic>("spBooking_CreateReservation", reservation);
            return id.FirstOrDefault();
        }
        public int CreateRoomReservation(object roomReservation)
        {
            var id = _data.SaveData("spBooking_CreateRoomReservation", roomReservation);
            return id;
        }
    }
}
