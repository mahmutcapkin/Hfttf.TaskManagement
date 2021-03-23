﻿using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Tasks.Commands;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Validators
{
    public class TaskInsertValidator : AbstractValidator<TaskInsertCommand>
    {
        public TaskInsertValidator()
        {
            RuleFor(x => x.CreateBy).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.CreateBy).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.ApprovedBy).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ApprovedBy).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Title).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.DueDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.DueDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.DueDate).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.DueDate).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.ProjectId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ProjectId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.ProjectId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);

            RuleFor(x => x.Status).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Status).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.TaskStatusId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.TaskStatusId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.TaskStatusId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}