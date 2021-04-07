using BookSoft.DAL.Exceptions;
using BookSoft.DAL.Services.Authentication;
using EtnaReception.Desktop.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace EtnaReception.Desktop.ViewModels
{
    public class LoginWindowViewModel : BindableBase
    {
        public DelegateCommand<object> LoginCommand { get; }
        public IRegionManager _regionManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEventAggregator _eventAggregator;
        public EventHandler SuccessfulLogin;

        public LoginWindowViewModel(IAuthenticationService authenticationService,
                                    IEventAggregator eventAggregator)
        {
            LoginCommand = new DelegateCommand<object>(OnLogin);
            _authenticationService = authenticationService;
            ErrorMessageViewModel = new MessageViewModel();
            _eventAggregator = eventAggregator;
        }

        private void OnLogin(object passwordBox)
        {
            
            var password = passwordBox as PasswordBox;
            try
            {
                _authenticationService.Login(Username, password.Password);
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