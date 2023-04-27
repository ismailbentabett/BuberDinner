using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
     AuthenticationResult Login(
        string Email,
        string Password
        );
    AuthenticationResult Register(
        string FirstName,
        string LastName,
        string Email,
        string Password
        );
    }
}