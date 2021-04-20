using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Queries
{
    public class ExperienceDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
