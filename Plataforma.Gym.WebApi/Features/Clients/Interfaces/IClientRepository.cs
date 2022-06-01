using Plataforma.Gym.WebApi.Features.Clients.Entities;

namespace Plataforma.Gym.WebApi.Features.Clients.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client? FindClientById(Guid id);
        Client RegisterClient(Client client);
        void DeleteClient(Guid clientId);
        Client UpdateClient(Client client);
    }
}
