using Plataforma.Gym.WebApi.Features.Clients.Entities;
using Plataforma.Gym.WebApi.Features.Clients.Interfaces;
using Plataforma.Gym.WebApi.Persistence;

namespace Plataforma.Gym.WebApi.Features.Clients.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly PostgresDbContext context;

        public ClientRepository(PostgresDbContext context)
        {
            this.context = context;
        }

        public void DeleteClient(Guid clientId)
        {
            Client client = FindClientById(clientId);
            //Add custom client exception on client not found

            client.IsActive = false;
            this.context.Update(client);
            this.context.SaveChanges();
        }

        public Client FindClientById(Guid id)
        {
            return this.context.Clients
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return this.context.Clients;
        }

        public Client RegisterClient(Client client)
        {
            this.context.Add(client);
            this.context.SaveChanges();
            return client;
        }

        public Client UpdateClient(Guid clientId, Client client)
        {
            Client clientToUpdate = FindClientById(clientId);

            //map new values

            this.context.Update(client);
            this.context.SaveChanges();
            return client;
        }

        public bool DoClientExist(Guid clientId) 
        {
            Client client = FindClientById(clientId);
            return client != default;
        }
    }
}
