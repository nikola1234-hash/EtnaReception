using BookSoft.DAL.Repositories;

namespace BookSoft.DAL
{
    public interface IUnitOfWork
    {
        UserRepository User { get; }
        CompanyRepository Company { get; }
        RoomRepository Room { get; }
        StayTypesRepository StayType { get; }
        GuestRepository Guest { get; }
        ReservationRepository Reservation { get; }
        SchedulerRepository RoomReservation { get; }
        RoomReservationRepository RoomReservationRepository { get; }
    }
}