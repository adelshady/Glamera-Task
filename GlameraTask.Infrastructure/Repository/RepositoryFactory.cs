
namespace GlameraTask.Infrastructure.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly GlameraTaskDbContext _context;

        public RepositoryFactory(GlameraTaskDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<T> GetRepository<T>() where T : class
        {
            return new BaseRepository<T>(_context);
        }
    }
}
