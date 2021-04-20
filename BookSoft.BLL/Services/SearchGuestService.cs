using BookSoft.DAL;
using BookSoft.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookSoft.BLL.Services
{
    public class SearchGuestService : ISearchGuestService
    {
        private readonly IUnitOfWork _unit;

        public SearchGuestService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IEnumerable<Guest> SearchGuest(string firstName = null, string lastName = null, string phone = null)
        {
            object searchItem = new
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone
            };
            var guests = _unit.Guest.SearchGuest(searchItem);
            return guests;
        }
    }
}
