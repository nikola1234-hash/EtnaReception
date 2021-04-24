using Booking.Wrapper;
using BookSoft.BLL.Services;
using BookSoft.Domain.Models;

namespace Booking.Services.Facade
{
    public class BookingFacade : IBookingFacade
    {
        private readonly IReservationService _reservationService;
        private readonly IGuestService _guestService;

        public BookingFacade(IReservationService reservationService,
                             IGuestService guestService)
        {
            _reservationService = reservationService;
            _guestService = guestService;
        }

        public bool CreateBooking(SearchWrapper searchWrapper,
                                  int roomId,
                                  decimal totalPrice,
                                  int stayTypeId,
                                  bool isGuestSelected,
                                  int? guestId = 0,
                                  decimal discount = 0,
                                  GuestWrapper guestWrapper = null)
        {
            bool success = false;
            int idGuest;
            if (isGuestSelected)
            {

                if (guestId.HasValue && guestId.Value > 0)
                {
                    idGuest = guestId.Value;
                
                    int reservationId = _reservationService.CreateReservation(idGuest, searchWrapper.StartDate, searchWrapper.EndDate, totalPrice);
                    int done = _reservationService.CreateRoomReservation(reservationId, roomId, searchWrapper.NumberOfPeople ,stayTypeId);
                    success = reservationId > 0 && done > 0;
                }
            }
            bool shouldCreateNewGuest = guestWrapper != null && isGuestSelected == false;
            if (shouldCreateNewGuest)
            {
                var guestForCreation = new
                {
                    FirstName = guestWrapper.FirstName,
                    LastName = guestWrapper.LastName,
                    Phone = guestWrapper.Phone,
                    Address = guestWrapper.Address,
                    Email = guestWrapper.Email,
                    Details = guestWrapper.Details,
                    Jmbg = guestWrapper.Jmbg
                };
                Guest newGuest = _guestService.CreateGuest(guestForCreation);
                int reservationId = _reservationService.CreateReservation(newGuest.Id, searchWrapper.StartDate, searchWrapper.EndDate, totalPrice, discount);
                int id = _reservationService.CreateRoomReservation(reservationId, roomId, searchWrapper.NumberOfPeople, stayTypeId);
                success = reservationId > 0 && id > 0;
            }
            return success;
        }
    }
}
