using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.DomainClients.Domain.Models;

namespace WebApplication2.DomainClients.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
        Task<Client> FindAsync(int id);
        Task<Client> FindByDniAsync(string id);
        Task AddAsync(Client client);
        void UpdateAsync(Client client);
        void Delete(Client client);
    }
}