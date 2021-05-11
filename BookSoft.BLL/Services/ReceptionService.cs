using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.DAL;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public class ReceptionService : IReceptionService
    {
        private readonly IUnitOfWork _unit;

        public ReceptionService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IEnumerable<RoomScheduler> LoadRoomScheduler()
        {
            var rooms = _unit.RoomReservation.LoadRooms();
            return rooms;
        }
    }
}
