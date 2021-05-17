using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;
using System;

namespace Hfttf.TaskManagement.Service.Services.Projects.Validatior
{
    public class ProjectInsertValidator : AbstractValidator<ProjectInsertCommand>
    {
        public ProjectInsertValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Title).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Description).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Description).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.CreateBy).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.CreateBy).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.StartDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage).GreaterThan(m => m.StartDate).WithMessage(ValidatorMessages.DateTimeNotEarlierStart);
            RuleFor(x => x.EndDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage).GreaterThan(m => m.StartDate).WithMessage(ValidatorMessages.DateTimeNotEarlierStart);

        }
    }
}
