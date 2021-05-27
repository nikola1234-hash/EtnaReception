using System;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public enum UpdateStatus
    {
        Done,
        Error
    }

    public interface IEditScheduleService
    {
        void UpdateReservationDates(DateTime startDate, DateTime endDate, int reservationId);
        void UpdateRoomReservationDetails(int reservationId, int roomId, int stayTypeId, int persons);
        void UpdateReservationStatus(int reservationId, int statusId);
        RoomReservation LoadRoomReservationDetails(int reservationId);
    }
}