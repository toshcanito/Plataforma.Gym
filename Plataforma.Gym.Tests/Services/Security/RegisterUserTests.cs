using Moq;
using NUnit.Framework;
using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Features.Security.Interfaces;
using Plataforma.Gym.WebApi.Features.Security.Services;
using Plataforma.Gym.WebApi.Shared.Helpers;

namespace Plataforma.Gym.Tests.Services.Security
{
    public class RegisterUserTests
    {
        private readonly Mock<ISecurityRepository> mockSecurityRepository;
        private ISecurityService securityService;
        public RegisterUserTests()
        {
            mockSecurityRepository = new Mock<ISecurityRepository>();


            securityService = new SecurityService(mockSecurityRepository.Object);
        }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Register_User_With_Required_Fields()
        {
            string firstName = "Jhon";
            string lastName = "Doe";
            string email = "john.doe@mail.com";
            string password = "Pa$$word!";


            User newUser = new(firstName, lastName, email, password);

            mockSecurityRepository.Setup(x => x.RegisterUser(It.IsAny<User>())).Returns(newUser);

            var result = securityService.Register(newUser);

            var isSamePassword = PasswordHasher.Compare(password, result.Password, result.PasswordSalt);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, firstName);
            Assert.AreEqual(result.LastName, lastName);
            Assert.AreEqual(result.Email, email);
            Assert.AreNotEqual(result.Password, password);
            Assert.NotNull(result.PasswordSalt);
            Assert.True(isSamePassword);
        }
    }
}