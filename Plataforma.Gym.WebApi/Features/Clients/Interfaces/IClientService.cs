using Plataforma.Gym.WebApi.Features.Clients.Entities;

namespace Plataforma.Gym.WebApi.Features.Clients.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        Client? GetById(Guid id);
        Client RegisterClient(Client client);
        void DeleteClient(Guid clientId);
        Client UpdateClient(Guid clientId, Client client);
    }
}
