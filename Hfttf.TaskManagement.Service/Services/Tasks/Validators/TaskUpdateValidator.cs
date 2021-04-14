using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Tasks.Commands;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Validators
{
    public class TaskUpdateValidator : AbstractValidator<TaskUpdateCommand>
    {
        public TaskUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);

            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Title).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.DueDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.DueDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.ProjectId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ProjectId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.ProjectId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);

            RuleFor(x => x.TaskStatusId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.TaskStatusId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.TaskStatusId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
