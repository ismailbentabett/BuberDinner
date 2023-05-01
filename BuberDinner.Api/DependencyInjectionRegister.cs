using BuberDinner.Api.Common.Errors.Mapping;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Api;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {
        services.AddMappings(
                
        );
        return services;
    }
}