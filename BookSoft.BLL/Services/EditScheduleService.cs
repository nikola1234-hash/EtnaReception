using System;
using BookSoft.DAL;
using BookSoft.DAL.Exceptions;

namespace BookSoft.BLL.Services
{
    public class EditScheduleService : IEditScheduleService
    {
        
        private readonly IUnitOfWork _unit;
        public EditScheduleService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public void UpdateReservationDates(DateTime startDate, DateTime endDate, int reservationId)
        {
            var details = new
            {
                startDate,
                endDate,
                reservationId
            };
            var rows = _unit.RoomReservation.UpdateReservation(details);
            if (rows == 0)
            {
                throw new ErrorUpdatingReservationException();
            }
        }

        public void UpdateRoomReservationDetails(int reservationId, int roomId, int stayTypeId, int persons)
        {
            var details = new
            {
                reservationId,
                roomId,
                stayTypeId,
                persons
            };

            var rows = _unit.RoomReservation.UpdateRoomReservationTable(details);
            if (rows == 0)
            {
                throw new ErrorUpdatingRoomReservationException();
            }
        }

        public void UpdateReservationStatus(int reservationId, int statusId)
        {
            var rows =_unit.RoomReservation.ChangeReservationStatus(reservationId, statusId);
            if (rows == 0)
            {
                throw new ErrorUpdatingReservationStatusException();
            }
        }
    }
}
