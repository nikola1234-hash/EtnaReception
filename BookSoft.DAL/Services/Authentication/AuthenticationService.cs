using BookSoft.DAL.Exceptions;
using BookSoft.Domain.Models;
using Microsoft.AspNet.Identity;
using System;

namespace BookSoft.DAL.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unit;

        public AuthenticationService(IPasswordHasher passwordHasher, IUnitOfWork unit)
        {
            _passwordHasher = passwordHasher;
            _unit = unit;
        }

        public User Login(string username, string password)
        {
            User userAccount = _unit.User.GetByUsername(username);
            if(userAccount is null)
            {
                throw new UserNotFoundException(username);
            }
            PasswordVerificationResult match = _passwordHasher.VerifyHashedPassword(userAccount.Password, password);
            if(match != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }
            return userAccount;
        }

        public RegistrationResult Register(string firstName,
                                           string lastName,
                                           string email,
                                           string username,
                                           string password,
                                           string confirmPassword, 
                                           int companyId)
        {
            RegistrationResult output = RegistrationResult.Success;
            if(password != confirmPassword)
            {
                output = RegistrationResult.PasswordsDoNotMatch;
            }
            User userAccount = _unit.User.GetByUsername(username);
            if(userAccount != null)
            {
                output = RegistrationResult.UsernameAlreadyExists;
            }
            if(output == RegistrationResult.Success)
            {
                var passwordHashed = _passwordHasher.HashPassword(password);
                var company = _unit.Company.GetCompanyById(companyId);
                var user = new
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Username = username,
                    Password = passwordHashed,
                    Created = DateTime.Now.Date,
                    Updated = DateTime.Now.Date,
                    CompanyId = company.Id
                };
                _unit.User.RegisterUser(user);
                
            }
            return output;
        }
    }
}
