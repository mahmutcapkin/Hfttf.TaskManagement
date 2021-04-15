using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Departments.Commands;

namespace Hfttf.TaskManagement.Service.Services.Departments.Validatiors
{
    public class DepartmentInsertValidator : AbstractValidator<DepartmentInsertCommand>
    {
        public DepartmentInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Name).NotNull().WithMessage(ValidatorMessages.NotNullMessage);      
        }
    }
}
