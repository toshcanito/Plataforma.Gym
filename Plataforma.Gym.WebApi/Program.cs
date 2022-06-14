using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Features.Security.Extensions;
using Plataforma.Gym.WebApi.Persistence;
using Plataforma.Gym.WebApi.Persistence.Extensions;
using Plataforma.Gym.WebApi.Shared.Configurations;
using Plataforma.Gym.WebApi.Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllersConfiguration();

services.AddEndpointsApiExplorer();

services.AddAuthenticationConfiguration(configuration);

services.AddSwaggerConfiguration();

services.AddMailConfiguration(configuration);

services.AddPersistenceConfiguration(configuration);

services.AddSecurityModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PostgresDbContext>();
    context.Database.Migrate();
}

app.Run();
