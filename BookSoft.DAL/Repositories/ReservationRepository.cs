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
            var rows = _data.SaveData("spReservation_CreateReservation", reservation);
            return rows;
        }
    }
}
