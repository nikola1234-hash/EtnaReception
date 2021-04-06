using BookSoft.Domain.Models;

namespace BookSoft.DAL.Services.Authentication
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        UsernameAlreadyExists
    }
    public interface IAuthenticationService
    {
        User Login(string username, string password);
        RegistrationResult Register(string firstName, string lastName, string email, string username, string password, string confirmPassword, int companyId);
    }
}
