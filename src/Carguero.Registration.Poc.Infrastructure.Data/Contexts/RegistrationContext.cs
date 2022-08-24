// <copyright file="RegistrationContext.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Patterns.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        protected DbSet<Driver> Driver => Set<Driver>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegistrationContext).Assembly);
        }
    }
}
