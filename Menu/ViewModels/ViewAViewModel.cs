
using BookSoft.BLL.Regions;
using Menu.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace Menu.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<object> NavigateCommand { get; }
        public ViewAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<object>(ExecuteNavigate, CanNavigateExecute);
        }

        private bool CanNavigateExecute(object navigation)
        {
            return true;
        }

        private void ExecuteNavigate(object navigation)
        {
            if(navigation is NavigationType)
            {
                var view = (NavigationType)navigation;
                _regionManager.RequestNavigate(RegionNames.MainRegion, view.ToString());
            }
            
        }
    }
}
