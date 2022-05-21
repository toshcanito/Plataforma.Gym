using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Features.Security.Entities;

namespace Plataforma.Gym.WebApi.Shared.Interfaces
{
    public interface IDbContext : IDefaultsDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}