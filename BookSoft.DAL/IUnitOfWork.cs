using BookSoft.DAL.Repositories;

namespace BookSoft.DAL
{
    public interface IUnitOfWork
    {
        UserRepository User { get; }
        CompanyRepository Company { get; }
        RoomRepository Room { get; }
        StayTypesRepository StayType { get; }
    }
}