using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Plataforma.Gym.WebApi.Shared.Configurations
{
    public static class AuthenticationConfigurationExtension
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtConfiguration:Issuer"],
                    ValidAudience = configuration["JwtConfiguration:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfiguration:Secret"]))
                };
            });

            return services;
        }
    }
}
