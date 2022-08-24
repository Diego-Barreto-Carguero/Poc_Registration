// <copyright file="IDriverRepository.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Core.Contracts.Repositories;
using Carguero.Registration.Poc.Domain.Patterns.Entities;

namespace Carguero.Registration.Poc.Domain.Patterns.Contracts.Repositories
{
    public interface IDriverRepository : IBaseRepository<Driver>
    {
    }
}
