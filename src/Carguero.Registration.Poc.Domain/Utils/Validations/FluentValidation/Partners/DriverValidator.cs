using Carguero.Registration.Poc.Domain.Entities.Partners;
using FluentValidation;

namespace Carguero.Registration.Poc.Domain.Utils.Validations.FluentValidation.Partners
{
    internal class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Campo {PropertyName} não informado");
        }
    }
}
