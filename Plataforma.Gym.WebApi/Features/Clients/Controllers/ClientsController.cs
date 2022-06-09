using Microsoft.AspNetCore.Mvc;
using Plataforma.Gym.WebApi.Features.Clients.Interfaces;
using Plataforma.Gym.WebApi.Shared.Controllers;

namespace Plataforma.Gym.WebApi.Features.Clients.Controllers
{
    public class ClientsController : ApiControllerBase
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = clientService.GetClients();
            return Ok(result);
        }
    }
}
