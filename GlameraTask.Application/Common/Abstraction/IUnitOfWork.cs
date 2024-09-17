

using Microsoft.EntityFrameworkCore.Storage;
using System.Net.Sockets;
using Task = System.Threading.Tasks.Task;

namespace GlameraTask.Application.Common.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> CompleteAsync();
        IBaseRepository<T> Repository<T>() where T : class;

    }
}
