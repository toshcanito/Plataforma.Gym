using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Plataforma.Gym.WebApi.Shared.Configurations
{
    public static class ControllersConfiguration
    {
        public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    return new BadRequestObjectResult(context.ModelState);
                };
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Program>();
            });

            return services;
        }
    }
}
