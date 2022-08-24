// <copyright file="DriverProfile.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using AutoMapper;
using Carguero.Registration.Poc.Domain.Patterns.Entities;
using Carguero.Registration.Poc.Domain.Patterns.Models.V1;

namespace Carguero.Registration.Poc.Domain.Patterns.AutoMapper
{
    internal class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverResponse>();
            CreateMap<DriverRequest, Driver>()
                .ConstructUsing(s => new Driver(s.Name, s.Cpf, s.Rg, s.BirthDate));
        }
    }
}
