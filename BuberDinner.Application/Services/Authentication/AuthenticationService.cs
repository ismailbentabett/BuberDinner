using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator
            , IUserRepository userRepository
        )
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string Email, string Password)
        {
            //if user does exist 
            if(_userRepository.GetUserByEmail(Email) is not User user)
            {
                throw new Exception("User does not exist");
            }

            //if password is correct
            if(user.Password != Password)
            {
                throw new Exception("Password is incorrect");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );
        }

        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
        {
            if(
                _userRepository.GetUserByEmail(Email) != null
            )
            {
                throw new Exception("User already exists");
            }
            
            var user = new User{
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };

            _userRepository.Add(user);
            

            var token = _jwtTokenGenerator.GenerateToken(
                user
                );

            return new AuthenticationResult(
               user,
                token
            );
        }
    }
}