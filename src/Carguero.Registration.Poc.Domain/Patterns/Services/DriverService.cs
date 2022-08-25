// <copyright file="DriverService.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Patterns.AssertionConcern;
using Carguero.Registration.Poc.Domain.Patterns.Contracts.Repositories;
using Carguero.Registration.Poc.Domain.Patterns.Contracts.Services;
using Carguero.Registration.Poc.Domain.Patterns.Entities;

namespace Carguero.Registration.Poc.Domain.Services
{
    internal sealed class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly INotifier _notifier;

        public DriverService(IDriverRepository driverRepository, INotifier notifier)
        {
            _driverRepository = driverRepository;
            _notifier = notifier;
        }

        public async Task RegisterAsync(Driver driver)
        {
            driver = await _driverRepository.FindByKeyAsync(s => s.Cpf == driver.Cpf);

            if (driver.AssertDriverIsNotNull(_notifier)) return;

            await _driverRepository.AddAsync(driver);
            await _driverRepository.CommitAsync();
        }

        public async Task<Driver> GetDriverActiveByCpf(string cpf)
        {
            var driver = await _driverRepository.FindByKeyAsync(s => s.Cpf == cpf);

            return driver;
        }

        public async Task<IEnumerable<Driver>> GetDriverActiveByTenant(string cpf, int tenantId)
        {
            var drivers = await _driverRepository.GetByPredicateAsync(p => p.Cpf == cpf);

            return drivers;
        }

        public async Task UpdateDriverActiveAsync(string cpf)
        {
            var driver = await _driverRepository.FindByKeyAsync(s => s.Cpf == cpf);

            driver.AssertDriverNull(_notifier);

            _driverRepository.Update(driver);
            await _driverRepository.CommitAsync();
        }
    }
}
