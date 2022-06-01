namespace Plataforma.Gym.WebApi.Features.Client.Extensions
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
