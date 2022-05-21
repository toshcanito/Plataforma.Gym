using Microsoft.AspNetCore.Mvc;
using Plataforma.Gym.WebApi.Features.Security.Dtos.Requests;

namespace Plataforma.Gym.WebApi.Features.Security.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            return Ok("LOGIN !!");
        }
    }
}