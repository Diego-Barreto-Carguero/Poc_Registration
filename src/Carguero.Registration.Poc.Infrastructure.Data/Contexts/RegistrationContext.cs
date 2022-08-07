using Carguero.Registration.Poc.Domain.Entities.Partners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Carguero.Registration.Poc.Infrastructure.Data.Contexts
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> dbContextOptions)
            : base(dbContextOptions)
        {
            //ChangeTracker.LazyLoadingEnabled = false;

            // Database.ExecuteSqlRaw("SET TRANSACTION ISOLATION LEVEL SNAPSHOT;");

            var Entry = ChangeTracker.Context;
        }

        protected IEnumerable<EntityEntry> EntityEntry { get; set; }

        public DbSet<Driver> Driver => Set<Driver>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegistrationContext).Assembly);
        }
    }
}
