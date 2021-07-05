using System;
using BookSoft.BLL.Services;
using Reception.Dialogs;

namespace Reception.Services.Facade
{
    public class BookingFacade : IBookingFacade
    {
        private readonly IReservationService _reservationService;
        private readonly IGuestService _guestService;

        public BookingFacade(IReservationService reservationService, IGuestService guestService)
        {
            _reservationService = reservationService;
            _guestService = guestService;
        }


        public bool CreateBooking(CreateNewReservationDialogViewModel model)
        {
            bool success = false;
            DateTime startDate;
            DateTime endDate;
            int persons;


            return success;
        }
    }
}
