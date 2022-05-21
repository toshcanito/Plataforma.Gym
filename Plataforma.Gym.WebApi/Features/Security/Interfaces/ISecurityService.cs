
using Plataforma.Gym.WebApi.Features.Security.Entities;

namespace Plataforma.Gym.WebApi.Features.Security.Interfaces
{
    public interface ISecurityService
    {
         User? Login(string username, string password);
         User Register(User user);
         string GenerateJwtToken(User user);
    }
}