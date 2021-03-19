using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Departments.Commands;

namespace Hfttf.TaskManagement.Service.Services.Departments.Validatiors
{
    public class DepartmentDeleteValidator : AbstractValidator<DepartmentDeleteCommand>
    {
        public DepartmentDeleteValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
