using Carguero.Registration.Poc.Domain.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carguero.Registration.Poc.Infrastructure.Data.Mapping.Addresses
{
    internal class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
        }
    }
}
