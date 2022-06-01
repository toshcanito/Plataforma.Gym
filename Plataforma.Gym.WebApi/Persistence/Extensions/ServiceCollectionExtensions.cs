using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Shared.Interfaces;

namespace Plataforma.Gym.WebApi.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddEntityFrameworkNpgsql()
            .AddDbContext<PostgresDbContext>(option => 
                option.UseNpgsql(configuration.GetConnectionString("postgresql"))
            );


            return services;
        }
    }
}