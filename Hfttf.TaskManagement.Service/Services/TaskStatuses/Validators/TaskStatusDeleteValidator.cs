using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Validators
{
    public class TaskStatusDeleteValidator : AbstractValidator<TaskStatusDeleteCommand>
    {
        public TaskStatusDeleteValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
