using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.TaskComments.Queries;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Validators
{
    public class TaskCommentDetailValidator : AbstractValidator<TaskCommentDetailQuery>
    {
        public TaskCommentDetailValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
