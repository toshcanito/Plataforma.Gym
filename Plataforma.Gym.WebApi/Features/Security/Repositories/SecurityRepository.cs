using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Features.Security.Interfaces;
using Plataforma.Gym.WebApi.Shared.Interfaces;

namespace Plataforma.Gym.WebApi.Features.Security.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly IDbContext context;

        public SecurityRepository(IDbContext context)
        {
            this.context = context;
        }

        public User? FindUserByEmail(string email)
        {
            return context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User RegisterUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}