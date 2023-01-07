using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DomainClients.Domain.Models;
using WebApplication2.DomainClients.Domain.Repositories;
using WebApplication2.Shared.Persistence.Context;
using WebApplication2.Shared.Persistence.Repositories;

namespace WebApplication2.DomainClients.Persistence.Repositories
{
    public class ClientRepository:BaseRepository, IClientRepository
    {
        public ClientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> FindAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> FindByDniAsync(string dni)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Dni == dni);
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public void UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
        }

        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
        }
    }
}