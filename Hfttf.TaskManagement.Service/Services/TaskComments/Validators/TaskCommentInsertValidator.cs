using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.TaskComments.Commands;

namespace Hfttf.TaskManagement.Service.Services.TaskComments.Validators
{
    public class TaskCommentInsertValidator : AbstractValidator<TaskCommentInsertCommand>
    {
        public TaskCommentInsertValidator()
        {
            RuleFor(x => x.CreateBy).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.CreateBy).NotNull().WithMessage(ValidatorMessages.NotNullMessage);          
            RuleFor(x => x.TaskId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.TaskId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.TaskId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
       
        }
    }
}
