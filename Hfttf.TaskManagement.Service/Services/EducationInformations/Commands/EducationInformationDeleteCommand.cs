using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Commands
{
    public class EducationInformationDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
