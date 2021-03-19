using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Commands;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Validators
{
    public class TaskStatusInsertValidator : AbstractValidator<TaskStatusInsertCommand>
    {
        public TaskStatusInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Name).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.StatusNameId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.StatusNameId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.StatusNameId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
