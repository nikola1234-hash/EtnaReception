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


        private const string LOAD_ROOM_RESOURCE = "SELECT Id, RoomNumber from dbo.Room";
        private const string LOAD_ROOMS = "spReception_LoadRoomScheduler";
        private const string CANCEL_RESERVATION = "spReceptionScheduler_CancelReservation";
        private const string LOAD_RESERVATION_STATUS = "SELECT * FROM dbo.Status_Catalog";
        //make sp
        private const string UPDATE_RESERVATION_STATUS = "spReceptionScheduler_UpdateStatus";


        public SchedulerRepository(IDataService data)
        {
            _data = data;
        }

        public IEnumerable<RoomScheduler> LoadRooms()
        {
            var rooms = _data.LoadData<RoomScheduler, dynamic>(LOAD_ROOMS, new { });
            return rooms;
        }

        public int CancelReservation(int id)
        {
            var rows = _data.SaveData(CANCEL_RESERVATION, new {reservationId = id});
            return rows;
        }

        public IEnumerable<RoomResource> LoadRoomResources()
        {
            var resource = _data.LoadData<RoomResource, dynamic>(LOAD_ROOM_RESOURCE, new { });
            return resource;
        }

        public int ChangeReservationStatus(int id, int statusId)
        {
            int rows = _data.SaveData(UPDATE_RESERVATION_STATUS, new {reservationId = id, statusId = statusId});
                //TODO: Throw exception if rows is 0
            return rows;
        }

        public IEnumerable<StatusModel> LoadStatus()
        {
            var statusList = _data.LoadData<StatusModel, dynamic>(LOAD_RESERVATION_STATUS, new { });
            return statusList;
        }
        public void UpdateReservation(object details)
        {
            var reservation = "";
        }
    }
}
