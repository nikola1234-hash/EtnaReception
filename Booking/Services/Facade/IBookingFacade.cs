using Booking.ViewModels;

namespace Booking.Services.Facade
{
    public interface IBookingFacade
    {
        public bool CreateBooking(BookingViewModel viemModel);
    }
}
