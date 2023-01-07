using System.Threading.Tasks;
using WebApplication2.Shared.Domain.Repositories;
using WebApplication2.Shared.Persistence.Context;

namespace WebApplication2.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}