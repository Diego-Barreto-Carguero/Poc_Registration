using Carguero.Registration.Poc.Domain.Core.DomainObjects;
using Carguero.Registration.Poc.Domain.Entities.Partners;

namespace Carguero.Registration.Poc.Domain.Utils.Validations.AssertionConcerns.Partners
{
    internal static class DriverAssertionConcerns
    {
        public static void ValidateDriverExists(this Driver? driver)
        {
            if (driver is not null)
            {
                throw new DomainException("Driver already registered.");
            }
        }
    }
}
