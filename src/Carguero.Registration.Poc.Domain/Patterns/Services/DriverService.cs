// <copyright file="DriverService.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using AutoMapper;
using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Patterns.AssertionConcern;
using Carguero.Registration.Poc.Domain.Patterns.Contracts.Repositories;
using Carguero.Registration.Poc.Domain.Patterns.Contracts.Services;
using Carguero.Registration.Poc.Domain.Patterns.Entities;
using Carguero.Registration.Poc.Domain.Patterns.Models.V1;

namespace Carguero.Registration.Poc.Domain.Services
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

            if (driver.ValidateDriverExists(_notifier)) return;

            driver = _mapper.Map<Driver>(driverRequest);

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
