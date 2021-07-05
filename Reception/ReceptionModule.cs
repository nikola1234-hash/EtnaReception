using BookSoft.BLL.Regions;
using BookSoft.BLL.Services;
using BookSoft.Domain.Models;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Reception.Dialogs;
using Reception.Services;
using Reception.Services.Facade;
using Reception.Views;

namespace Reception
{
    public class ReceptionModule : IModule
    {
        private readonly IRegionManager _region;

        public ReceptionModule(IRegionManager region)
        {
            _region = region;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _region.RegisterViewWithRegion(RegionNames.MainRegion, typeof(ReceptionView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ReceptionView>();
            containerRegistry.Register<IReceptionService, ReceptionService>();
            containerRegistry.Register<IRoomService, RoomService>();
            containerRegistry.Register<IStayTypeService, StayTypeService>();
            containerRegistry.Register<IEditScheduleService, EditScheduleService>();
            containerRegistry.Register<IStatusColor, StatusColor>();
            containerRegistry.RegisterDialog<CreateNewReservationDialog, CreateNewReservationDialogViewModel>();
            containerRegistry.RegisterDialog<EditReservationDialogView, EditReservationDialogViewModel>();
            containerRegistry.Register<IBookingFacade, BookingFacade>();
            containerRegistry.Register<IReservationService, ReservationService>();
            containerRegistry.Register<IGuestService, GuestService>();

            containerRegistry.Register<IUpdateReservationFacade, UpdateReservationFacade>();
        }
    }
}