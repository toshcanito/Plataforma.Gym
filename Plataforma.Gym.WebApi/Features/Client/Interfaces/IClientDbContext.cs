using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Shared.Interfaces;

namespace Plataforma.Gym.WebApi.Features.Client.Interfaces
{
    public interface IClientDbContext : IDefaultsDbContext
    {
        public DbSet<Features.Client.Entities.Client> Clients { get; set; }
    }
}
