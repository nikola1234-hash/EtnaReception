using BookSoft.Domain.Models;
using System.Collections.Generic;

namespace BookSoft.BLL.Services
{
    public interface ISearchGuestService
    {
        public IEnumerable<Guest> SearchGuest(string firstName, string lastName, string jmbg, string address);
    }
}
