// <copyright file="DriverRequestValidator.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Api.Patterns.Models.V1;
using FluentValidation;

namespace Carguero.Registration.Poc.Api.Patterns.Validations.V1
{
    public class DriverRequestValidator : AbstractValidator<DriverRequest>
    {
        public DriverRequestValidator()
        {
            RuleFor(s => s.Name).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .Length(10, 80);
        }
    }
}
