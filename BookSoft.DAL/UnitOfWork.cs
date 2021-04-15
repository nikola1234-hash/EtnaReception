using BookSoft.DAL.Repositories;
using BookSoft.Domain;

namespace BookSoft.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataService _dataService;

        public UnitOfWork(IDataService dataService)
        {
            _dataService = dataService;
            User = new UserRepository(_dataService);
            Company = new CompanyRepository(_dataService);
            Room = new RoomRepository(_dataService);
            StayType = new StayTypesRepository(_dataService);
        }

        public UserRepository User { get; }
        public CompanyRepository Company { get; }
        public RoomRepository Room { get; }
        public StayTypesRepository StayType { get; }
    }
}
