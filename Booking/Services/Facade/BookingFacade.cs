using Booking.ViewModels;
using BookSoft.BLL.Services;
using BookSoft.Domain.Models;
using System;

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

        public bool CreateBooking(BookingViewModel viewModel)
        {
            DateTime startDate;
            DateTime endDate;
            decimal totalPrice;
            int numberOfPeople;
            int stayTypeId;
            bool success = false;
            int idGuest = 0;
            int roomId;
            decimal discount = 0M; 


            startDate = viewModel.SearchRooms.StartDate.Date;
            endDate = viewModel.SearchRooms.EndDate.Date;
            numberOfPeople = viewModel.SearchRooms.NumberOfPeople;
            stayTypeId = viewModel.SelectedStayType.Id;
            roomId = viewModel.SelectedRoom.Id;
            totalPrice = viewModel.TotalPrice;
            var guestWrapper = viewModel.Guest;

            if (viewModel.IsGuestSelected && viewModel.SelectedGuestResult.Id > 0)
            {
                  idGuest = viewModel.SelectedGuestResult.Id;
            }
            bool shouldCreateNewGuest = guestWrapper != null && viewModel.IsGuestSelected == false;
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
                idGuest = newGuest.Id;
            }
            int reservationId = _reservationService.CreateReservation(idGuest, startDate, endDate, totalPrice, discount);
            int roomReservationId = _reservationService.CreateRoomReservation(reservationId, roomId, numberOfPeople, stayTypeId);
            success = reservationId > 0 && roomReservationId > 0;

            return success;
        }
    }
}
