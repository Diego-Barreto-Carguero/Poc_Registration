// <copyright file="DriverConfiguration.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Patterns.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carguero.Registration.Poc.Infrastructure.Data.Configuration.Partners
{
    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Driver");

            builder.HasKey(x => x.Id);

            builder.Property(s => s.Name).HasColumnType("varchar(80)").IsRequired();

            builder.Property(s => s.Rg).HasColumnType("varchar(15)").IsRequired();

            builder.Property(s => s.Cpf).HasColumnType("varchar(15)").IsRequired();

            builder.Property(s => s.BirthDate).IsRequired();

            builder.Property(s => s.Active).HasDefaultValue(true).IsRequired();

            builder.Property(s => s.CreationDate).IsRequired();

            builder.Property(s => s.ModificationDate).IsRequired();
        }
    }
}
