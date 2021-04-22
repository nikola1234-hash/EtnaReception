using BookSoft.Domain;

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
            var id = _data.SaveData("spBooking_CreateReservation", reservation);
            return id;
        }
        public int CreateRoomReservation(object roomReservation)
        {
            var id = _data.SaveData("spBooking_CreateRoomReservation", roomReservation);
            return id;
        }
    }
}
