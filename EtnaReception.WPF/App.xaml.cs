using BookSoft.DAL;
using BookSoft.DAL.DataAccess;
using BookSoft.DAL.Services.Authentication;
using BookSoft.Domain;
using EtnaReception.WPF.Views;
using Login;
using Login.Views;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Modularity;
using System.IO;
using System.Windows;

namespace EtnaReception.WPF
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
        public IConfiguration Configuration { get; private set; }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();


            containerRegistry.Register<IDataService, DataService>();
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
            containerRegistry.Register<IUnitOfWork, UnitOfWork>();

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LoginModule>();   
        }
    }
}
