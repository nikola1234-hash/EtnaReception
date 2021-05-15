using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.DAL;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public interface IRoomService
    {
        IEnumerable<AvailableRoomRequest> LoadAvailableRooms(DateTime startDate, DateTime endDate, int people);
    }

    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unit;

        public RoomService(IUnitOfWork unit)
        {
            _unit = unit;
        }


        public IEnumerable<AvailableRoomRequest> LoadAvailableRooms(DateTime startDate, DateTime endDate, int people)
        {
            var rooms = _unit.Room.GetAvailableRoomsForDates(startDate, endDate, people);
            return rooms;
        }
    }
}
