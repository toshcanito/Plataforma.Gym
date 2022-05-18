using Microsoft.AspNetCore.Mvc;
using Plataforma.Gym.WebApi.Models.Requests;

namespace Plataforma.Gym.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request){
            return Ok("LOGIN !!");
        }
    }
}