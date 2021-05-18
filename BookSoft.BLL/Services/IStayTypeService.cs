using System.Collections.Generic;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public interface IStayTypeService
    {
        IEnumerable<StayType> GetAllTypes();
        StayType GetById(int id);
    }
}