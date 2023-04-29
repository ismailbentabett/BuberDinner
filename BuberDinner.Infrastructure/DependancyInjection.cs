using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistance;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            Microsoft.Extensions.Configuration.IConfiguration configuration

        )
        {
            services.Configure
            <JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository , UserRepository>();

            return services;
        }
    }
}