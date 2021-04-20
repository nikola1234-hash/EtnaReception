using BookSoft.BLL.Authentications;
using BookSoft.DAL;
using EtnaReception.Configuration.Navigation;
using EtnaReception.Configuration.ViewRegions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace EtnaReception.Configuration.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Admin Creation";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

     
        public MainWindowViewModel()
        {

        }
    }
}