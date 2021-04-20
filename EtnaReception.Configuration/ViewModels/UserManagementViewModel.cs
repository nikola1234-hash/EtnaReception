using BookSoft.BLL.Authentications;
using BookSoft.DAL;
using BookSoft.DAL.Services.Authentication;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;

namespace EtnaReception.Configuration.ViewModels
{
    public class UserManagementViewModel : BindableBase
    {

        private readonly IUnitOfWork _unit;
        private readonly IAuthenticator _authenticator;


        public DelegateCommand CreateUserCommand { get; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        private string _password;

        public UserManagementViewModel(IUnitOfWork unit, IAuthenticator authenticator)
        {
            _unit = unit;
            _authenticator = authenticator;
            CreateUserCommand = new DelegateCommand(ExecuteCreateUserCommand, CanCreateUserExecute);
        }

        private bool CanCreateUserExecute()
        {
            return true;
        }

        private void ExecuteCreateUserCommand()
        {
            var company = _unit.Company.GetActiveCompany();
            RegistrationResult admin = _authenticator.Register("admin", "admin", "none", Username, Password, Password, company.Id);
            if(admin == RegistrationResult.Success)
            {
                MessageBox.Show($"Uspesno kreiran Korisnik: {Username}.");
            }
            if(admin == RegistrationResult.UsernameAlreadyExists)
            {
                MessageBox.Show($"{Username} vec postoji u bazi.");
            }

        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


    }
}
