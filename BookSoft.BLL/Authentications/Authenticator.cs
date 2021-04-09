using BookSoft.DAL.Services.Authentication;
using BookSoft.Domain.Models;
using System;

namespace BookSoft.BLL.Authentications
{
    public class Authenticator : IAuthenticator
    {
        private User _currentUser;
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                StateChanged?.Invoke();
            }
        }


        public bool IsLoggedIn => CurrentUser != null;

        public event Action StateChanged;

        public void Login(string username, string password)
        {
            _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public RegistrationResult Register(string firstName, string lastName, string email, string username, string password, string confirmPassword, int companyId)
        {
            return _authenticationService.Register(firstName, lastName, email, username, password, confirmPassword, companyId);
        }
    }
}
