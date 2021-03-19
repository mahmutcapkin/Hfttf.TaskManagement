using FluentValidation;
using Hfttf.TaskManagement.Service.BaseValidators;
using Hfttf.TaskManagement.Service.Services.Projects.Commands;

namespace Hfttf.TaskManagement.Service.Services.Projects.Validatior
{
    public class ProjectDeleteValidator : AbstractValidator<ProjectDeleteCommand>
    {
        public ProjectDeleteValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);
        }
    }
}
