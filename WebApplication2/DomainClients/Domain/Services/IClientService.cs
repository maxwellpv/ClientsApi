using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.DomainClients.Domain.Models;
using WebApplication2.DomainClients.Domain.Services.Communications;

namespace WebApplication2.DomainClients.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ListAsync();
        Task<Client> FindAsync(int id);
        Task<ClientResponse> SaveAsync(Client client);
        Task<ClientResponse> UpdateAsync(int id, Client client);
        Task<ClientResponse> DeleteAsync(int id);

    }
}