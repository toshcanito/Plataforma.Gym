using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plataforma.Gym.WebApi.Shared.Controllers;

namespace Plataforma.Gym.WebApi.Features.Security.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok("GetUser Endpoint");
        }
    }
}
