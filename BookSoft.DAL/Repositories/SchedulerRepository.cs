using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain;
using BookSoft.Domain.Models;

namespace BookSoft.DAL.Repositories
{
    public class SchedulerRepository
    {
        private readonly IDataService _data;
        private string LOAD_ROOM_RESOURCE = "SELECT Id, RoomNumber from dbo.Room";
        public SchedulerRepository(IDataService data)
        {
            _data = data;
        }

        public IEnumerable<RoomScheduler> LoadRooms()
        {
            var rooms = _data.LoadData<RoomScheduler, dynamic>("spReception_LoadRoomScheduler", new { });
            return rooms;
        }

        public int CancelReservation(int id)
        {
            var rows = _data.SaveData("spReceptionScheduler_CancelReservation", new {reservationId = id});
            return rows;
        }

        public IEnumerable<RoomResource> LoadRoomResources()
        {
            var resource = _data.LoadData<RoomResource, dynamic>(LOAD_ROOM_RESOURCE, new { });
            return resource;
        }
    }
}
