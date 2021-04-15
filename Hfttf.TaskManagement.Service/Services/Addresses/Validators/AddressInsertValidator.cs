using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Addresses.Commands;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Validators
{
    public class AddressInsertValidator : AbstractValidator<AddressInsertCommand>
    {
        public AddressInsertValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.City).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Country).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Country).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.ApplicationUserId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ApplicationUserId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.ZipCode).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ZipCode).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
        }
    }
}
