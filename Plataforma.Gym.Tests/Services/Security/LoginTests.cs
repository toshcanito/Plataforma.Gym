using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Features.Security.Interfaces;
using Plataforma.Gym.WebApi.Features.Security.Services;
using Plataforma.Gym.WebApi.Shared.Configurations;
using System;

namespace Plataforma.Gym.Tests.Services.Security
{
    public class LoginTests
    {
        private readonly ISecurityService securityService;
        private readonly Mock<ISecurityRepository> securityRepository;

        public LoginTests()
        {
            JwtConfiguration conf = new();
            var mockIOptions = new Mock<IOptions<JwtConfiguration>>();
            mockIOptions.Setup(x => x.Value).Returns(conf);

            securityRepository = new Mock<ISecurityRepository>();

            securityService = new SecurityService(securityRepository.Object, mockIOptions.Object);
        }

        [SetUp]
        public void Setup()
        {

            User user = new(
                id: new Guid("31207332-673b-455b-8849-63148ce49c53"),
                firstName: "John",
                lastName: "Doe",
                email: "john.doe@email.com"
            );

            user.SetPassword(
                passwordHashed: "ocHTMDC6bitcId/4ni6RN/Iw56nSPIOFaeaUdrYAtuY=",
                salt: "KZ/wAqVPhe9E3aCqJrOxag=="
            );

            securityRepository.Setup(x => x.FindUserByEmail(It.IsAny<string>()))
                .Returns(user);
        }

        [Test]
        public void LoginUser__User_Right_Credentials()
        {
            string username = "john.doe@email.com";
            string password = "Pa$$word!";

            var result = securityService.Login(username, password);

            Assert.IsNotNull(result);
            result?.Email.Should().Be(username);
            result?.Password.Should().BeEmpty();
            result?.PasswordSalt.Should().BeEmpty();
        }

        [Test]
        public void LoginUser__Wrong_Credentials()
        {
            string username = "john.doe@email.com";
            string password = "pa$$word!123";

            Assert.Throws<Exception>(() => securityService.Login(username, password));
        }
    }
}