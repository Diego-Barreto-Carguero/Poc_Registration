using Carguero.Registration.Poc.Domain.Models.Partners;

namespace Carguero.Registration.Poc.Domain.Contracts.Services.Partners
{
    public interface IDriverService
    {
        public Task<IEnumerable<DriverResponse>> GetDriverActiveByTenant(string cpf, int tenantId);

        public Task<DriverResponse> GetDriverActiveByCpf(string cpf);

        public Task RegisterAsync(DriverRequest driverRequest);

        public Task UpdateDriverActiveAsync(string cpf);

    }
}
