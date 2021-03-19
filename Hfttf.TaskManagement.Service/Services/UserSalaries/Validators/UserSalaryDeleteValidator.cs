﻿using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Commands;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Validators
{
    public class UserSalaryDeleteValidator : AbstractValidator<UserSalaryDeleteCommand>
    {
        public UserSalaryDeleteValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
