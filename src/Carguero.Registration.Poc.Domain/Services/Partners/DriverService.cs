using AutoMapper;
using Carguero.Registration.Poc.Domain.Contracts.Repositories.Partners;
using Carguero.Registration.Poc.Domain.Contracts.Services.Partners;
using Carguero.Registration.Poc.Domain.Entities.Partners;
using Carguero.Registration.Poc.Domain.Models.Partners;
using Carguero.Registration.Poc.Domain.Utils.Validations.AssertionConcerns.Partners;

namespace Carguero.Registration.Poc.Domain.Services.Partners
{
    internal class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task RegisterAsync(DriverRequest driverRequest)
        {
            var driver = await _driverRepository.FindByKeyAsync(driverRequest.Cpf);

            driver.ValidateDriverExists();

            driver = _mapper.Map<DriverRequest, Driver>(driverRequest);

            await _driverRepository.SaveAsync();
        }

        public async Task<IEnumerable<DriverResponse>> GetAll()
        {
            var driver = await _driverRepository.GetByPredicateAsync(s => s.Id == 82);

            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverResponse>>(driver);
        }
    }
}
