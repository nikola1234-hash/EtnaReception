using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookSoft.Domain;
using BookSoft.Domain.Models;

namespace BookSoft.DAL.Repositories
{
    public class RoomReservationRepository
    {
        private const string LoadRoomReservationById = "spRoomReservation_LoadByReservationId";

        private readonly IDataService _dataService;

        public RoomReservationRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public RoomReservation LoadRoomReservationByResId(int reservationId)
        {
            var output = _dataService.LoadData<RoomReservation, dynamic>(LoadRoomReservationById, new {reservationId});
            return output.FirstOrDefault();
        }
    }
}
