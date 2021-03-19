using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Holidays.Commands;
using System;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Validators
{
    public class HolidayInsertValidator : AbstractValidator<HolidayInsertCommand>
    {
        public HolidayInsertValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Title).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.StartDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.StartDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.EndDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage).GreaterThan(m => m.StartDate).WithMessage(ValidatorMessages.DateTimeNotEarlierStart);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage).GreaterThan(m => m.StartDate).WithMessage(ValidatorMessages.DateTimeNotEarlierStart);

        }
    }
}
