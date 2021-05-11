using Booking;
using BookSoft.BLL.Authentications;
using BookSoft.BLL.Regions;
using BookSoft.DAL;
using BookSoft.DAL.DataAccess;
using BookSoft.DAL.Services.Authentication;
using BookSoft.Domain;
using EtnaReception.Desktop.Views;
using Home;
using Menu;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Reception;
using System.IO;
using System.Windows;
using BookSoft.BLL.License;

namespace EtnaReception.Desktop
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
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
            containerRegistry.Register<IUnitOfWork, UnitOfWork>();
            containerRegistry.Register<IDataService, DataService>();
            containerRegistry.Register<IPasswordHasher, PasswordHasher>();
            containerRegistry.Register<IAuthenticator, Authenticator>();


            containerRegistry.RegisterInstance<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build());

        }
        protected override void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionKey.Key);
            Window login = Container.Resolve<LoginWindow>();
            var result = login.ShowDialog();
            if (result.Value)
            {
                base.OnInitialized();
            }
        }
    
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MenuModule>();
            moduleCatalog.AddModule<HomeModule>();
            moduleCatalog.AddModule<BookingModule>();
            moduleCatalog.AddModule<ReceptionModule>();
        }
    }
}
