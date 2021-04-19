using BookSoft.Domain;
using BookSoft.Domain.Models;
using System.Collections.Generic;

namespace BookSoft.DAL.Repositories
{
    public class GuestRepository
    {
        private readonly IDataService _dataService;

        public GuestRepository(IDataService dataService)
        {
            _dataService = dataService;
        }
        public IEnumerable<Guest> SearchGuest(object guest)
        {
            var output = _dataService.LoadData<Guest, dynamic>("spGuest_Search", new { guest });
            return output;
        }
    }
}
