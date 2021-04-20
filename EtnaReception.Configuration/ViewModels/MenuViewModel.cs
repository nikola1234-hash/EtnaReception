using EtnaReception.Configuration.Navigation;
using EtnaReception.Configuration.ViewRegions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace EtnaReception.Configuration.ViewModels
{
    public class MenuViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;

        public MenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<object>(ExecuteNavigateCommand, CanNavigateCommandExecute);
        }

        private bool CanNavigateCommandExecute(object arg)
        {
            return true;
        }

        private void ExecuteNavigateCommand(object parameters)
        {
            if (parameters is NavigationType)
            {
                var navigation = (NavigationType)parameters;
                _regionManager.RequestNavigate(RegionsNames.MainRegion, navigation.ToString());
            }
        }

        public DelegateCommand<object> NavigateCommand { get; }

    }
}
