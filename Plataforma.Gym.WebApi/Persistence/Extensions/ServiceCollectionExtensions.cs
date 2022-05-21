using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Shared.Interfaces;

namespace Plataforma.Gym.WebApi.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PostgresDbContext>(option => option.UseNpgsql(configuration.GetConnectionString("postgresql")));

            services.AddScoped<IDbContext,PostgresDbContext>();

            return services;
        }
    }
}