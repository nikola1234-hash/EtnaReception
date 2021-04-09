using Booking.Views;
using BookSoft.BLL.Regions;
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
        }
    }
}