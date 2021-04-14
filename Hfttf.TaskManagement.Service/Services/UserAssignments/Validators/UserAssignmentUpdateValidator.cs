using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Commands;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Validators
{
    public class UserAssignmentUpdateValidator : AbstractValidator<UserAssignmentUpdateCommand>
    {
        public UserAssignmentUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
            RuleFor(x => x.ApplicationUserId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ApplicationUserId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.TaskId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.TaskId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.TaskId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
            RuleFor(x => x.UpdateBy).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.UpdateBy).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
        }
    }
}
