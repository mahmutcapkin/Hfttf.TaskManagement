using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Validators
{
    public class TaskStatusUpdateValidator : AbstractValidator<TaskStatusUpdateCommand>
    {
        public TaskStatusUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);

            RuleFor(x => x.Status).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Status).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Status).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
