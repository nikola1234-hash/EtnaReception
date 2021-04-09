using BookSoft.BLL.Regions;
using Home.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Home
{
    public class HomeModule : IModule
    {

        private readonly IRegionManager _regionManager;

        public HomeModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeView>();
        }
    }
}