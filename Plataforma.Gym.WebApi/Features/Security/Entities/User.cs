using System.Text;
using Plataforma.Gym.WebApi.Shared.Entities;

namespace Plataforma.Gym.WebApi.Features.Security.Entities
{
    public class User : BaseEntity
    {
        public User()
        {

        }

        public User(Guid id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public User(string firstName, string lastName, string email, string password, Guid? id = null)
        {
            Id = id is null ? Guid.NewGuid() : id.Value;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }


        public void SetPassword(string passwordHashed, string salt)
        {
            Password = passwordHashed;
            PasswordSalt = salt;
        }

        public void ProtectSensitiveInformation()
        {
            Password = string.Empty;
            PasswordSalt = string.Empty;
        }
    }
}