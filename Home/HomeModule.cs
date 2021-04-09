using BookSoft.BLL.Regions;
using Home.Services;
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
        public async void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(HomeView));
            WeatherService weather = new WeatherService();
            await weather.GetWeatherForecast();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeView>();
        }
    }
}