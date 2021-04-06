using Login.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows.Controls;

namespace Login
{
    public class LoginModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public LoginModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;

        }



        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(LoginView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}