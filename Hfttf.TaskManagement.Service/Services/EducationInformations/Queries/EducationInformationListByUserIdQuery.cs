using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Queries
{
    public class EducationInformationListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
