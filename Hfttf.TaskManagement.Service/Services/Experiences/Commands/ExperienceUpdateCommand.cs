using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Commands
{
    public class ExperienceUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
