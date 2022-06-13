using Plataforma.Gym.WebApi.Shared.Interfaces;
using Plataforma.Gym.WebApi.Shared.Services;

namespace Plataforma.Gym.WebApi.Shared.Configurations
{
    public static class MailServiceConfigurationExtension
    {
        public static IServiceCollection AddMailConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.AddTransient<IMailService, MailService>();

            return services;
        }
    }
}