using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Features.Clients.Entities;
using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Shared.Interfaces;

namespace Plataforma.Gym.WebApi.Persistence
{
    public class PostgresDbContext : DbContext, IDbContext
    {
        public PostgresDbContext()
        {
            
        }

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
            // var pendingMigrations = Database.GetPendingMigrations();

            // if(pendingMigrations.Count() > 0){
            //     Database.Migrate();
            // }

            Database.Migrate();

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}