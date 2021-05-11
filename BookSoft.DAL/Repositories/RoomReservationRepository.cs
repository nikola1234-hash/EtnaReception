using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain;
using BookSoft.Domain.Models;

namespace BookSoft.DAL.Repositories
{
    public class RoomReservationRepository
    {
        private readonly IDataService _data;

        public RoomReservationRepository(IDataService data)
        {
            _data = data;
        }

        public IEnumerable<RoomScheduler> LoadRooms()
        {
            var rooms = _data.LoadData<RoomScheduler, dynamic>("spReception_LoadRoomScheduler", new { });
            return rooms;
        }
    }
}
