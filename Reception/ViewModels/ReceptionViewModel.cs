using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using BookSoft.BLL.Services;
using Prism.Mvvm;
using Prism.Regions;
using Reception.Services;
using Syncfusion.UI.Xaml.Scheduler;

namespace Reception.ViewModels
{
    public class ReceptionViewModel : BindableBase, INavigationAware
    {
        private readonly IReceptionService _reception;

        public ReceptionViewModel(IReceptionService reception)
        {
            _reception = reception;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
           
            
        }
        
    }

}

