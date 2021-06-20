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
        UpdateStatus UpdateReservationDates(DateTime startDate, DateTime endDate, int reservationId);
        UpdateStatus UpdateRoomReservationDetails(int reservationId, int roomId, int stayTypeId, int persons);
        UpdateStatus UpdateReservationStatus(int reservationId, int statusId);
        RoomReservation LoadRoomReservationDetails(int reservationId);
    }
}