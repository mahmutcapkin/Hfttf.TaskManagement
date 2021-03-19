using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Commands
{
    public class ExperienceInsertCommand : IRequest<Response>
    {
        public string Job { get; set; }
        public string Company { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
