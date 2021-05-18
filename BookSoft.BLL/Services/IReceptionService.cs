using System.Collections.Generic;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public interface IReceptionService
    {
        IEnumerable<RoomScheduler> LoadRoomScheduler();
        int CancelReservation(int id);
        IEnumerable<RoomResource> LoadRoomResource();
        IEnumerable<StatusModel> LoadStatus(int id = 0);
        StatusModel LoadStatusByReservationId(int id);
    }
}