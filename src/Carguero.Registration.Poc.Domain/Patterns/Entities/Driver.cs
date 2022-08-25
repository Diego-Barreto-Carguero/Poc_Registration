// <copyright file="Driver.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Core.Entities;

namespace Carguero.Registration.Poc.Domain.Patterns.Entities
{
    public class Driver : BaseEntity, IAggregationRoot
    {
        public Driver(string name, string cpf, string rg, DateTime birthDate)
        {
            Name = name;
            Cpf = cpf;
            Rg = rg;
            BirthDate = birthDate;
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public string Cpf { get; private set; }

        public string Rg { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
