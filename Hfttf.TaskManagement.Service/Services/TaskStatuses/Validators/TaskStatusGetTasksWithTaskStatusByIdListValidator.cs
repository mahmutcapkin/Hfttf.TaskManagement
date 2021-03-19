using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.TaskStatuses.Queries;

namespace Hfttf.TaskManagement.Service.Services.TaskStatuses.Validators
{
    public class TaskStatusGetTasksWithTaskStatusByIdListValidator : AbstractValidator<TaskStatusGetTasksWithTaskStatusByIdListQuery>
    {
        public TaskStatusGetTasksWithTaskStatusByIdListValidator()
        {
            RuleFor(x => x.StatusNameId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.StatusNameId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

        }
    }
}
