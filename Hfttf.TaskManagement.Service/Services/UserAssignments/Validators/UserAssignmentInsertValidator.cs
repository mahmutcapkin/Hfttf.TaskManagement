using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Commands;


namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Validators
{
    public class UserAssignmentInsertValidator : AbstractValidator<UserAssignmentInsertCommand>
    {
        public UserAssignmentInsertValidator()
        {
            RuleFor(x => x.ApplicationUserId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ApplicationUserId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.TaskId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.TaskId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.TaskId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
            RuleFor(x => x.CreateBy).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.CreateBy).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
        }
    }
}
