using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

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
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, FirstName, LastName);

            return new AuthenticationResult(
                userId,
                FirstName,
                LastName,
                Email,
                token
            );
        }
    }
}