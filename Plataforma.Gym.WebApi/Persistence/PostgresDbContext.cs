using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Shared.Interfaces;

namespace Plataforma.Gym.WebApi.Persistence
{
    public class PostgresDbContext : DbContext, IDbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}