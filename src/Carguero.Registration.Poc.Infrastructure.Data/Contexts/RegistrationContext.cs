using Carguero.Registration.Poc.Domain.Entities.Partners;
using Microsoft.EntityFrameworkCore;

namespace Carguero.Registration.Poc.Infrastructure.Data.Contexts
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> dbContextOptions)
            : base(dbContextOptions)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            
           // Database.ExecuteSqlRaw("SET TRANSACTION ISOLATION LEVEL SNAPSHOT;");
        }

        public DbSet<Driver> Driver { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegistrationContext).Assembly);
        }
    }
}
