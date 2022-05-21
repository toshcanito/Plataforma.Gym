using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Features.Security.Interfaces;

namespace Plataforma.Gym.WebApi.Features.Security.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository securityRepository;

        public SecurityService(ISecurityRepository securityRepository)
        {
            this.securityRepository = securityRepository;
        }

        public string GenerateJwtToken(User user)
        {
            throw new NotImplementedException();
        }

        public User? Login(string username, string password)
        {
            var user = securityRepository.FindUserByEmail(username);

            if (user == null)
            {
                // TODO Create Custom Exception
                throw new Exception("User not exists");
            }

            // TODO check passwords 

            // TODO if passwords are ok return user else throw a custom excepcion
            throw new NotImplementedException();
        }

        public User Register(User user)
        {
            //TODO Validate user data
            securityRepository.RegisterUser(user);
            return user;
        }
    }
}