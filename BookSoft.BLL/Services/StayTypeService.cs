using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.DAL;
using BookSoft.DAL.Exceptions;
using BookSoft.Domain;
using BookSoft.Domain.Models;

namespace BookSoft.BLL.Services
{
    public class StayTypeService : IStayTypeService
    {
        private readonly IUnitOfWork _unit;

        public StayTypeService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IEnumerable<StayType> GetAllTypes()
        {
            var types = _unit.StayType.GetAll();
            if (types is null)
            {
                throw new StayTypesNotFoundException();
            }

            return types;
        }

        public StayType GetById(int id)
        {
            var type = _unit.StayType.GetById(id);
            return type;
        }
    }
}
