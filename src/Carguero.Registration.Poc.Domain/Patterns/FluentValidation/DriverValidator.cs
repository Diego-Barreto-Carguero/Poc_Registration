// <copyright file="DriverValidator.cs" company="Carguero">
// Copyright (c) Carguero. All rights reserved.
// </copyright>

using Carguero.Registration.Poc.Domain.Patterns.Models.V1;
using FluentValidation;

namespace Carguero.Registration.Poc.Domain.Patterns.FluentValidation
{
    public class DriverValidator : AbstractValidator<DriverRequest>
    {
        public DriverValidator()
        {
            const string messageProcessingHandler = "Property [{PropertyName}] is Required";
            const string rangeName = "Property [{PropertyName}] has to be between {MinLength} and {MaxLength} characters";

            RuleFor(s => s.Name).Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(messageProcessingHandler)
                .NotNull()
                .WithMessage(messageProcessingHandler)
                .Length(10, 80)
                .WithMessage(rangeName);

            RuleFor(s => s.Cpf).Matches(@"^\d{5}(-?\d{4})?$");
        }
    }
}
