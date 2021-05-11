using System.Collections.Generic;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public interface IReceptionService
    {
        IEnumerable<RoomScheduler> LoadRoomScheduler();
    }
}