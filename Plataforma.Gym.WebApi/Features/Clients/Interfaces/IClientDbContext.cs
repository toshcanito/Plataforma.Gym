using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Shared.Interfaces;
using Plataforma.Gym.WebApi.Features.Clients.Entities;

namespace Plataforma.Gym.WebApi.Features.Clients.Interfaces
{
    public interface IClientDbContext : IDefaultsDbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}
