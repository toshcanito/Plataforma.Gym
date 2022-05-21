using Microsoft.EntityFrameworkCore;
using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Shared.Interfaces;

namespace Plataforma.Gym.WebApi.Features.Security.Interfaces
{
    public interface ISecurityDbContext: IDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}