// <copyright file="DriverRequest.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

namespace Carguero.Registration.Poc.Domain.Patterns.Models.V1
{
    public record DriverRequest
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
