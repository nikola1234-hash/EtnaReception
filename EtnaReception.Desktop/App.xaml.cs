using BookSoft.DAL;
using BookSoft.DAL.DataAccess;
using BookSoft.DAL.Services.Authentication;
using BookSoft.Domain;
using EtnaReception.Desktop.Views;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using System.IO;
using System.Windows;

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
            containerRegistry.RegisterInstance<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build());

        }
        protected override void OnInitialized()
        {
            Window login = Container.Resolve<LoginWindow>();
            var result = login.ShowDialog();
            if (result.Value)
            {
                base.OnInitialized();
            }
           
        }
    }
}
