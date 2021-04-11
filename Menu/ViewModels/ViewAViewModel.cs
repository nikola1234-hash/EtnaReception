using Booking.Events;
using BookSoft.BLL.Regions;
using Menu.Navigation;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace Menu.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand<object> NavigateCommand { get; }
        public ViewAViewModel(IRegionManager regionManager,
                              IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<object>(ExecuteNavigate, CanNavigateExecute);
            _eventAggregator = eventAggregator;
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
                if(view == NavigationType.BookingView)
                {
                    _eventAggregator.GetEvent<LoadEvent>().Publish();
                }
                _regionManager.RequestNavigate(RegionNames.MainRegion, view.ToString());
            }
            
        }
    }
}
