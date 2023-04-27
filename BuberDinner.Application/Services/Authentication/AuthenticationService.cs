using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Login(string Email, string Password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "John",
                "Doe",
                Email,
                "token"
            );

        }

        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
        {
            return new AuthenticationResult(
                 Guid.NewGuid(),
                    FirstName,
                    LastName,
                 Email,
                 "token"
             );

        }

    }
}