using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Entities.Partners;

namespace Carguero.Registration.Poc.Domain.Utils.Validations.AssertionConcerns.Partners
{
    internal static class DriverAssertionConcerns
    {
        public static bool ValidateDriverExists(this Driver? driver, ref INotifier _notifier)
        {
            if (driver is not null)
            {
                _notifier.NotifyHandle("Driver Exists");
                return true;
            }

            return false;
        }
    }
}
