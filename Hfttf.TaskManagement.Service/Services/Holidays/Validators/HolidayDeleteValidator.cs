using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Holidays.Commands;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Validators
{
    public class HolidayDeleteValidator : AbstractValidator<HolidayDeleteCommand>
    {
        public HolidayDeleteValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
