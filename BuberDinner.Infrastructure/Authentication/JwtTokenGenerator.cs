using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {

        private readonly IDateTimeProvider _dateTimeProvide;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,
      IOptions<JwtSettings> jwtSettings
        )
        {
            _dateTimeProvide = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;

        }
        public string GenerateToken(Guid userId, string FirstName, string LastName)
        {
            var signinCredentials
            = new SigningCredentials(
            new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _jwtSettings.Secret
                    )),
                    SecurityAlgorithms.HmacSha256
                );

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    _dateTimeProvide.UtcNow.ToString())
            };
            var securityToken
                = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience : _jwtSettings.Audience, 
                    claims: claims,
                    expires:
                        _dateTimeProvide.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes

                        ),
                    signingCredentials: signinCredentials
                );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(securityToken);

            return token;

        }
    }

}