

namespace GlameraTask.Domain.Data
{
    public class GlameraTaskDbContext : DbContext
    {
      
        public IConfiguration configuration { get; }


        public GlameraTaskDbContext(DbContextOptions<GlameraTaskDbContext> options, IConfiguration configuration)
            : base(options)
        {
           
            this.configuration = configuration;

        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Branch> Branches { get; set; }

    }
}
