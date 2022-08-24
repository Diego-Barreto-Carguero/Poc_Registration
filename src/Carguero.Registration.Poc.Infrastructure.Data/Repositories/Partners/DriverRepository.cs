// <copyright file="DriverRepository.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Patterns.Contracts.Repositories;
using Carguero.Registration.Poc.Domain.Patterns.Entities;
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
