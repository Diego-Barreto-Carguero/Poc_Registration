using AutoMapper;
using Carguero.Registration.Poc.Domain.Contracts.Repositories.Partners;
using Carguero.Registration.Poc.Domain.Contracts.Services.Partners;
using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Entities.Partners;
using Carguero.Registration.Poc.Domain.Models.Partners;

namespace Carguero.Registration.Poc.Domain.Services.Partners
{
    internal class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        private readonly INotifier _notifier;

        public DriverService(IDriverRepository driverRepository, IMapper mapper, INotifier notifier)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
            _notifier = notifier;
        }

        public async Task RegisterAsync(DriverRequest driverRequest)
        {
            var driver = await _driverRepository.FindByKeyAsync(s => s.Cpf == driverRequest.Cpf);

            if (driver is not null)
            {
                _notifier.NotifyHandle($"Cpf {driver.Cpf} linked to the driver {driver.Name} already has an active registration");
                return;
            }

            driver = _mapper.Map<DriverRequest, Driver>(driverRequest);

            await _driverRepository.AddAsync(driver);
            await _driverRepository.CommitAsync();
        }

        public async Task<DriverResponse> GetDriverActiveByCpf(string cpf)
        {
            var driver = await _driverRepository.FindByKeyAsync(s => s.Cpf == cpf);

            return _mapper.Map<DriverResponse>(driver);
        }

        public async Task<IEnumerable<DriverResponse>> GetDriverActiveByTenant(string cpf, int tenantId)
        {
            var driver = await _driverRepository
                .GetByPredicateAsync(p => p.Cpf == cpf);

            // && p.Tenant.Any(s=> s.Id == tenantId), p => p.Tenant, p => p.Contacts, p => p.Address , p=> p.Vehicles

            return _mapper.Map<IEnumerable<DriverResponse>>(driver);
        }

        public async Task UpdateDriverActiveAsync(string cpf)
        {
            var driver = await _driverRepository.FindByKeyAsync(s => s.Cpf == cpf);

            if (driver is null)
            {
                _notifier.NotifyHandle($"Cpf {cpf} not found");
                return;
            }

            _driverRepository.Update(driver);
            await _driverRepository.CommitAsync();
        }
    }
}
