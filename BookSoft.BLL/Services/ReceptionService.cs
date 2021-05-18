using System.Collections.Generic;
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

        public int CancelReservation(int id)
        {
            int rows =_unit.RoomReservation.CancelReservation(id);
            return rows;
        }

        public IEnumerable<RoomResource> LoadRoomResource()
        {
            var resources = _unit.RoomReservation.LoadRoomResources();
            return resources;
        }

        public IEnumerable<StatusModel> LoadStatus()
        {
            var statuses = _unit.RoomReservation.LoadStatus();
            return statuses;
        }

        public StatusModel LoadStatusByReservationId(int id)
        {
            var output = _unit.RoomReservation.LaodStatusByReservation(id);
            return output;
        }
    }
}
