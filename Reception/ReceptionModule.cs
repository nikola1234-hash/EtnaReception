using BookSoft.BLL.Regions;
using BookSoft.BLL.Services;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Reception.Dialogs;
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
            containerRegistry.RegisterDialog<CreateNewReservationDialog, CreateNewReservationDialogViewModel>();
        }
    }
}