using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Leaders.Commands;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Validators
{
    public class LeaderInsertValidator : AbstractValidator<LeaderInsertCommand>
    {
        public LeaderInsertValidator()
        {
            RuleFor(x => x.ApplicationUserId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ApplicationUserId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.ProjectId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ProjectId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.ProjectId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
