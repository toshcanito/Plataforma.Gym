using Microsoft.AspNetCore.Mvc;
using Plataforma.Gym.WebApi.Features.Security.Dtos.Requests;
using Plataforma.Gym.WebApi.Shared.Controllers;

namespace Plataforma.Gym.WebApi.Features.Security.Controllers
{
    public class SecurityController : ApiControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            return Ok("LOGIN !!");
        }
    }
}