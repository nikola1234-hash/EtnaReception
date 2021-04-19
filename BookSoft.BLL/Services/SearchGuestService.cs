using BookSoft.DAL;
using BookSoft.Domain.Models;
using System.Collections.Generic;

namespace BookSoft.BLL.Services
{
    public class SearchGuestService : ISearchGuestService
    {
        private readonly IUnitOfWork _unit;

        public SearchGuestService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IEnumerable<Guest> SearchGuest(string firstName, string lastName, string jmbg, string address)
        {
            object searchItem = new
            {
                FirstName = firstName,
                LastName = lastName,
                Jmbg = jmbg,
                Address = address
            };
            var guests = _unit.Guest.SearchGuest(searchItem);
            return guests;
        }
    }
}
