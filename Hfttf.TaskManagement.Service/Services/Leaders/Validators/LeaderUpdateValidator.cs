using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Leaders.Commands;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Validators
{
    public class LeaderUpdateValidator : AbstractValidator<LeaderUpdateCommand>
    {
        public LeaderUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);

            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.UserId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.ProjectId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ProjectId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.ProjectId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);

        }
    }
}
