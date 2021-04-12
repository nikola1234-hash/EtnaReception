using BookSoft.Domain;
using BookSoft.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookSoft.DAL.Repositories
{
    public class StayTypesRepository 
    {
        private readonly IDataService _dataService;

        public StayTypesRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<StayType> GetAll()
        {
            var types = _dataService.LoadData<StayType, dynamic>("spStayType_GetAll", new { });
            return types;
        }
        public StayType GetById(int id)
        {
            var type = _dataService.LoadData<StayType, dynamic>("spStayType_GetByID", new { id });
            return type.FirstOrDefault();
        }
    }
}
