using Carguero.Registration.Poc.Domain.Contracts.Repositories.Partners;
using Carguero.Registration.Poc.Domain.Entities.Partners;
using Carguero.Registration.Poc.Infrastructure.Data.Contexts;
using Carguero.Registration.Poc.Infrastructure.Data.Repositories.Base;

namespace Carguero.Registration.Poc.Infrastructure.Data.Repositories.Partners
{
    internal sealed class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        public DriverRepository(RegistrationContext registrationContext)
            : base(registrationContext)
        {
        }
    }
}
