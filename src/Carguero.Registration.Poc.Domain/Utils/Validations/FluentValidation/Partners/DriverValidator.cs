using Carguero.Registration.Poc.Domain.Models.Partners;
using FluentValidation;

namespace Carguero.Registration.Poc.Domain.Utils.Validations.FluentValidation.Partners
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
        }
    }
}
