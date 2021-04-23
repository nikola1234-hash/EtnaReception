using Booking.Services.Facade;
using Booking.Views;
using BookSoft.BLL;
using BookSoft.BLL.Regions;
using BookSoft.BLL.Services;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Booking
{
    public class BookingModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public BookingModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(BookingView));
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BookingView>();
            containerRegistry.Register<IBookingCalculate, BookinCalculationService>();
            containerRegistry.Register<ISearchGuestService, SearchGuestService>();
            containerRegistry.Register<IReservationService, ReservationService>();
            containerRegistry.Register<IBookingFacade, BookingFacade>();
            containerRegistry.Register<IGuestService, GuestService>();
        }
    }
}