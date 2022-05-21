using Plataforma.Gym.WebApi.Features.Security.Interfaces;
using Plataforma.Gym.WebApi.Features.Security.Repositories;
using Plataforma.Gym.WebApi.Features.Security.Services;

namespace Plataforma.Gym.WebApi.Features.Security.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurityModule(this IServiceCollection services)
        {

            services.AddTransient<ISecurityRepository, SecurityRepository>();

            services.AddTransient<ISecurityService, SecurityService>();

            return services;
        }
    }
}