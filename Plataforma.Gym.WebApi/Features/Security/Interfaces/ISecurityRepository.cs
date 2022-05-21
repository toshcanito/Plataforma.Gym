using Plataforma.Gym.WebApi.Features.Security.Entities;

namespace Plataforma.Gym.WebApi.Features.Security.Interfaces
{
    public interface ISecurityRepository
    {
        User? FindUserByEmail(string email);
        User RegisterUser(User user);
    }
}