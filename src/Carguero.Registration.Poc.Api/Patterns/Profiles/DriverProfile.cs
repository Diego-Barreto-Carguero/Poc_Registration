// <copyright file="DriverProfile.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using AutoMapper;
using Carguero.Registration.Poc.Api.Patterns.Models.V1;
using Carguero.Registration.Poc.Domain.Patterns.Entities;

namespace Carguero.Registration.Poc.Api.Patterns.Profiles
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
