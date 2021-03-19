using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Queries;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Validators
{
    public class UserAssignmentDetailValidator : AbstractValidator<UserAssignmentDetailQuery>
    {
        public UserAssignmentDetailValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
