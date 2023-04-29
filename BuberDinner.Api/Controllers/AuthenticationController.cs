using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );

            var response = new AuthenticationResponse
            (
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
            );
            return Ok(response);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password
            );
            var response = new AuthenticationResponse
            (
                authResult.User.Id,
              authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
            );
            return Ok(response);
        }
    }
}