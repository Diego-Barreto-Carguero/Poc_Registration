using Carguero.Registration.Poc.Domain.Models.Partners;

namespace Carguero.Registration.Poc.Domain.Contracts.Services.Partners
{
    public interface IDriverService
    {
        public Task<IEnumerable<DriverResponse>> GetAll();

        public Task RegisterAsync(DriverRequest driverRequest);
    }
}
