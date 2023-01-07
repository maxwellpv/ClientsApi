using System.Threading.Tasks;

namespace WebApplication2.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}