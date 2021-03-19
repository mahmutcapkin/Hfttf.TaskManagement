using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Holidays.Queries;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Validators
{
    public class HolidayDetailValidator : AbstractValidator<HolidayDetailQuery>
    {
        public HolidayDetailValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
