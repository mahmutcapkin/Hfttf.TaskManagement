using FluentValidation;
using Hfttf.TaskManagement.UI.BaseValidatorMessages;

namespace Hfttf.TaskManagement.UI.Models.Address.Validators
{
    public class AddressAddValidator : AbstractValidator<AddressAdd>
    {
        public AddressAddValidator()
        {
            RuleFor(x => x.Country).NotNull().WithName("Ülke").WithMessage(ValidatorMessage.NotNullMessage);
            RuleFor(x => x.Country).MaximumLength(30).WithMessage(ValidatorMessage.LengthWarningMessage);

            RuleFor(x => x.City).NotNull().WithName("Şehir").WithMessage(ValidatorMessage.NotNullMessage);
            RuleFor(x => x.City).MaximumLength(30).WithMessage(ValidatorMessage.LengthWarningMessage);

            RuleFor(x => x.ZipCode).NotNull().WithName("Posta Kodu").WithMessage(ValidatorMessage.NotNullMessage);
            RuleFor(x => x.ZipCode).MaximumLength(10).WithMessage(ValidatorMessage.LengthWarningMessage);

            RuleFor(x => x.Description).NotNull().WithName("Adres").WithMessage(ValidatorMessage.NotNullMessage);
            RuleFor(x => x.Description).MaximumLength(250).WithMessage(ValidatorMessage.LengthWarningMessage);
        }
    }
}
