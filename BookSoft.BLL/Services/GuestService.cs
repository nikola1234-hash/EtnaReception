using BookSoft.DAL;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public class GuestService : IGuestService
    {
        private readonly IUnitOfWork _unit;

        public GuestService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public Guest CreateGuest(object guest)
        {
            Guest guestFromDb = _unit.Guest.CreateGuest(guest);
            return guestFromDb;
        }
    }
}
