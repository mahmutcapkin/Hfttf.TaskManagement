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
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Name).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.StatusNameId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.StatusNameId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.StatusNameId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
