using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Features.Security.Interfaces;
using Plataforma.Gym.WebApi.Shared.Configurations;
using Plataforma.Gym.WebApi.Shared.Exceptions;
using Plataforma.Gym.WebApi.Shared.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Plataforma.Gym.WebApi.Features.Security.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository securityRepository;
        private readonly JwtConfiguration jwtConfiguration;

        public SecurityService(ISecurityRepository securityRepository, IOptions<JwtConfiguration> jwtConfiguration)
        {
            this.securityRepository = securityRepository;
            this.jwtConfiguration = jwtConfiguration.Value;
        }

        public string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfiguration.Secret));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Issuer = jwtConfiguration.Issuer,
                Audience = jwtConfiguration.Audience,
                Expires = DateTime.UtcNow.AddMinutes(jwtConfiguration.TokenExpirationInMinutes),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwt =  tokenHandler.WriteToken(token);

            return jwt;
        }

        public User? Login(string username, string password)
        {
            var user = securityRepository.FindUserByEmail(username);

            if (user == null)
            {
                // TODO Create Custom Exception
                throw new NotFoundException("The User doesn't exist");
            }

            // TODO check passwords 
            var isValidPassword = PasswordHasher.Compare(password, user.Password, user.PasswordSalt);

            if(isValidPassword == false)
            {
                throw new Exception("The username or password are not correct");
            }


            user.ProtectSensitiveInformation();

            return user;
        }

        public User Register(User user)
        {
            //TODO Validate user data
            
            //Verify if email is registerd
            var userExits = securityRepository.FindUserByEmail(user.Email);

            if (userExits != null)
            {
                throw new ArgumentException("The email is already registerd");
            }

            // Hash Password
            string hashedPassword = PasswordHasher.Hash(user.Password, out string salt);
            user.SetPassword(hashedPassword, salt);

            securityRepository.RegisterUser(user);
            return user;
        }
    }
}