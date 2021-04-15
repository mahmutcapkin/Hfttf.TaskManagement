using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Leaves.Commands;
using System;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Validators
{
    public class LeaveUpdateValidator : AbstractValidator<LeaveUpdateCommand>
    {
        public LeaveUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Title).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.StartDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage).GreaterThan(m => m.StartDate).WithMessage(ValidatorMessages.DateTimeNotEarlierStart);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage).GreaterThan(m => m.StartDate).WithMessage(ValidatorMessages.DateTimeNotEarlierStart);
        }
    }
}
