using Microsoft.AspNetCore.Mvc;
using Plataforma.Gym.WebApi.Features.Security.Dtos.Requests;
using Plataforma.Gym.WebApi.Features.Security.Dtos.Requests.RegisterUser;
using Plataforma.Gym.WebApi.Features.Security.Entities;
using Plataforma.Gym.WebApi.Features.Security.Interfaces;
using Plataforma.Gym.WebApi.Shared.Controllers;
using Plataforma.Gym.WebApi.Shared.Interfaces;
using Plataforma.Gym.WebApi.Shared.Models;

namespace Plataforma.Gym.WebApi.Features.Security.Controllers
{
    public class SecurityController : ApiControllerBase
    {
        private readonly ISecurityService securityService;
        private readonly IMailService mailService;

        public SecurityController(ISecurityService securityService, IMailService mailService)
        {
            this.securityService = securityService;
            this.mailService = mailService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = securityService.Login(request.Username, request.Password);
            var jwt = securityService.GenerateJwtToken(user);
            return Ok(new { AccessToken = jwt });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            User user = new(request.FirstName, request.LastName, request.Email, request.Password);

            var result = securityService.Register(user);

            mailService.SendEmail(new MailRequest {
                ToEmail = request.Email,
                Subject = "Welcome to Plataforma",
                Body = "Welcome to Plataforma, your account has been created, you can login with your email and password."
            });
            return Ok(result);
        }
    }
}