namespace GlameraTask.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GlameraTaskDbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;
        private IDbContextTransaction _transaction;

       
        public UnitOfWork(GlameraTaskDbContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        }
        public IBaseRepository<T> Repository<T>() where T : class
        {
            return _repositoryFactory.GetRepository<T>();
        }
        public IDbContextTransaction BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
            return _transaction;
        }
        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }
        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
       
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}


