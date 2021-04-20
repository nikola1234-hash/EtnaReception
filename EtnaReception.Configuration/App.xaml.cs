using BookSoft.BLL.Authentications;
using BookSoft.DAL;
using BookSoft.DAL.DataAccess;
using BookSoft.DAL.Services.Authentication;
using BookSoft.Domain;
using EtnaReception.Configuration.ViewRegions;
using EtnaReception.Configuration.Views;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Regions;
using System.IO;
using System.Windows;

namespace EtnaReception.Configuration
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionsNames.MainRegion, typeof(MainView));
            regionManager.RegisterViewWithRegion(RegionsNames.MenuRegion, typeof(MenuView));

            containerRegistry.Register<IUnitOfWork, UnitOfWork>();
            containerRegistry.Register<IAuthenticator, Authenticator>();
            containerRegistry.Register<IDataService, DataService>();
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
            containerRegistry.Register<IPasswordHasher, PasswordHasher>();
            containerRegistry.RegisterInstance<IConfiguration>(new ConfigurationBuilder()
                                                               .SetBasePath(Directory.GetCurrentDirectory())
                                                               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                               .Build());

            containerRegistry.RegisterForNavigation<UserManagementView>();
            
        }
    }
}
