using BookSoft.Domain;
using BookSoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookSoft.DAL.Repositories
{
    public class RoomRepository
    {
        private readonly IDataService _dataService;

        public RoomRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<AvailableRoomRequest> GetAvailableRoomsForDates(DateTime startDate, DateTime endDate, int numberOfPeople)
        {
            var rooms = _dataService.LoadData<AvailableRoomRequest, dynamic>("spRooms_GetAvailableRoomsByDates",
                                                                             new { startDate, endDate, numberOfPeople });
            return rooms.ToList();
        }
    }
}
