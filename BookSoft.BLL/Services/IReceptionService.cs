using System.Collections.Generic;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public interface IReceptionService
    {
        IEnumerable<RoomScheduler> LoadRoomScheduler();
        int CancelReservation(int id);
        IEnumerable<RoomResource> LoadRoomResource();
        IEnumerable<StatusModel> LoadStatus();
        StatusModel LoadStatusByReservationId(int id);
    }
}