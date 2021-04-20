using BookSoft.DAL.Services.Authentication;
using BookSoft.Domain.Models;
using System;

namespace BookSoft.BLL.Authentications
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }
        RegistrationResult Register(string firstName,
                                    string lastName,
                                    string email,
                                    string username,
                                    string password,
                                    string confirmPassword,
                                    int companyId);
        void Login(string username, string password);
        event Action StateChanged;
        void Logout();
    }
}
