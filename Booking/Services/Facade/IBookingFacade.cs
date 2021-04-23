using Booking.Wrapper;

namespace Booking.Services.Facade
{
    public interface IBookingFacade
    {
        public bool CreateBooking(SearchWrapper searchWrapper,
                                  int roomId,
                                  decimal totalPrice,
                                  int stayTypeId,
                                  bool isGuestSelected,
                                  int guestId = 0,
                                  decimal discount = 0,
                                  GuestWrapper guestWrapper = null);
    }
}
