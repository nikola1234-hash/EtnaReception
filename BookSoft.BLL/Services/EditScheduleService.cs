using System;
using System.Data;
using BookSoft.DAL;
using BookSoft.DAL.Exceptions;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public class EditScheduleService : IEditScheduleService
    {
        
        private readonly IUnitOfWork _unit;
        public EditScheduleService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public UpdateStatus UpdateReservationDates(DateTime startDate, DateTime endDate, int reservationId)
        {
            var details = new
            {
                startDate,
                endDate,
                id = reservationId
            };
            var rows = _unit.RoomReservation.UpdateReservation(details);
            if (rows == 1)
            {
                return UpdateStatus.Done;
            }
            return UpdateStatus.Error;
        }

        public UpdateStatus UpdateRoomReservationDetails(int reservationId, int roomId, int stayTypeId, int persons)
        {
            var details = new
            {
                reservationId,
                roomId,
                stayTypeId,
                persons
            };

            var rows = _unit.RoomReservation.UpdateRoomReservationTable(details);
            if (rows == 1)
            {
                return UpdateStatus.Done;
            }

            return UpdateStatus.Error;
        }

        public UpdateStatus UpdateReservationStatus(int reservationId, int statusId)
        {
            var rows =_unit.RoomReservation.ChangeReservationStatus(reservationId, statusId);

            if (rows == 1)
            {
                return UpdateStatus.Done;
            }

            return UpdateStatus.Error;
        }

        public RoomReservation LoadRoomReservationDetails(int reservationId)
        {
            var output = _unit.RoomReservationRepository.LoadRoomReservationByResId(reservationId);
            return output;
        }
    }
}
