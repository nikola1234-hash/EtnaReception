using BookSoft.BLL.Authentications;
using BookSoft.DAL.Exceptions;
using EtnaReception.Desktop.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Controls;

namespace EtnaReception.Desktop.ViewModels
{
    public class LoginWindowViewModel : BindableBase
    {
        public DelegateCommand<object> LoginCommand { get; }
        public IRegionManager _regionManager;
        private readonly IAuthenticator _authenticator;
        private readonly IEventAggregator _eventAggregator;
        public EventHandler SuccessfulLogin;

        public LoginWindowViewModel(IAuthenticator authenticator,
                                    IEventAggregator eventAggregator)
        {
            LoginCommand = new DelegateCommand<object>(OnLogin);
            _authenticator = authenticator;
            ErrorMessageViewModel = new MessageViewModel();
            _eventAggregator = eventAggregator;
        }

        private void OnLogin(object passwordBox)
        {
            
            var password = passwordBox as PasswordBox;
            try
            {
                _authenticator.Login(Username, password.Password);
                _eventAggregator.GetEvent<LoginEvent>().Publish(true);
            }
            catch (UserNotFoundException)
            {
                ErrorMessage = "Korisnicko ime ne postoji!";
            }
            catch (InvalidPasswordException)
            {
                ErrorMessage = "Lozinka nije ispravna!";
            }
            finally
            {
               // ErrorMessage = "Greska!";
            }
        }
        public MessageViewModel ErrorMessageViewModel { get; set; }
        public string ErrorMessage 
        {
            set => ErrorMessageViewModel.Message = value;
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        
    }
}