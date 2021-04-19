using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Departments.Commands;

namespace Hfttf.TaskManagement.Service.Services.Departments.Validatiors
{
    public class DepartmentUpdateValidator : AbstractValidator<DepartmentUpdateCommand>
    {
        public DepartmentUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Name).NotNull().WithMessage(ValidatorMessages.NotNullMessage);         
        }
    }
}
