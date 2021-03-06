using BookSoft.DAL.Exceptions;
using BookSoft.DAL.Services.Authentication;
using Login.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace Login.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public DelegateCommand<object> LoginCommand { get; }
        public IRegionManager _regionManager;

        public LoginViewModel(IRegionManager regionManager)
        {
            LoginCommand = new DelegateCommand<object>(OnLogin);
            _regionManager = regionManager;
        }

        private void OnLogin(object passwordBox)
        {
            var authenticationService = _regionManager.Reson
            var password = passwordBox as PasswordBox;
            try
            {
                _authenticationService.Login(Username, password.Password);
                MessageBox.Show("Radi");
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
                ErrorMessage = "Greska!";
            }
        }
        public MessageViewModel ErrorMessageViewModel { get; set; }
        public string ErrorMessage 
        { 
            set
            {
                ErrorMessageViewModel.Message = value;
            } 
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
    }
}