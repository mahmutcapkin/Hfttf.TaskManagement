using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Queries
{
    public class ExperienceListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
