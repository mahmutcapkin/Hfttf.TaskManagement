using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Commands;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Validators
{
    public class UserSalaryUpdateValidator : AbstractValidator<UserSalaryUpdateCommand>
    {
        public UserSalaryUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
            RuleFor(x => x.UpdateBy).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.UpdateBy).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
          
            RuleFor(x => x.Salary).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Salary).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Salary).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
            RuleFor(x => x.ApplicationUserId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.ApplicationUserId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

        }
    }
}
