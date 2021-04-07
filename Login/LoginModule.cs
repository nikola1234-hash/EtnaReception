using BookSoft.DAL;
using BookSoft.DAL.DataAccess;
using BookSoft.DAL.Services.Authentication;
using BookSoft.Domain;
using Login.ViewModels;
using Login.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Login
{
    public class LoginModule : IModule
    {

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
            var _regionManager = containerProvider.Resolve<IRegionManager>();
            containerProvider.Resolve<LoginViewModel>();
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(LoginView));
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {      
            
        }
    }
}