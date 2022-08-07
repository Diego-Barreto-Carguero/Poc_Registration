using Carguero.Registration.Poc.Domain.Contracts.Repositories.Addresses;
using Carguero.Registration.Poc.Domain.Entities.Addresses;
using Carguero.Registration.Poc.Infrastructure.Data.Contexts;
using Carguero.Registration.Poc.Infrastructure.Data.Repositories.Base;

namespace Carguero.Registration.Poc.Infrastructure.Data.Repositories.Addresses
{
    internal class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(RegistrationContext registrationContext)
            : base(registrationContext)
        {
        }
    }
}
