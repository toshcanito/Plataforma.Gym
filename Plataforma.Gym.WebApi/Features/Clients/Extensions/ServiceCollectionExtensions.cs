using Plataforma.Gym.WebApi.Features.Clients.Interfaces;
using Plataforma.Gym.WebApi.Features.Clients.Repositories;
using Plataforma.Gym.WebApi.Features.Clients.Services;

namespace Plataforma.Gym.WebApi.Features.Clients.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClientModule(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientService, ClientService>();

            return services;
        }
    }
}
