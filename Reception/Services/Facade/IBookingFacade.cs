using Reception.Dialogs;

namespace Reception.Services.Facade
{
    public interface IBookingFacade
    {
        public bool CreateBooking(CreateNewReservationDialogViewModel model);
    }
}