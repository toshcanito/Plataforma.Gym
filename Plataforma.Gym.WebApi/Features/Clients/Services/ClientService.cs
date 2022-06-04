using Plataforma.Gym.WebApi.Features.Clients.Entities;
using Plataforma.Gym.WebApi.Features.Clients.Interfaces;
using Plataforma.Gym.WebApi.Shared.Exceptions;

namespace Plataforma.Gym.WebApi.Features.Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository) 
        {
            this.clientRepository = clientRepository;
        }

        public void DeleteClient(Guid clientId)
        {
            if (!clientRepository.DoClientExist(clientId))
                throw new NotFoundException($"The client was not found. Provided Id {clientId}. ");

            clientRepository.DeleteClient(clientId);
        }

        public Client? GetById(Guid id)
        {
            return clientRepository.FindClientById(id);
        }

        public IEnumerable<Client> GetClients()
        {
            return clientRepository.GetAllClients();
        }

        public Client RegisterClient(Client client)
        {
            return clientRepository.RegisterClient(client);
        }

        public Client UpdateClient(Guid clientId, Client client)
        {
            if (!clientRepository.DoClientExist(clientId))
                throw new NotFoundException($"The client was not found. Provided Id {clientId}. ");

            return clientRepository.UpdateClient(clientId, client);
        }
    }
}
