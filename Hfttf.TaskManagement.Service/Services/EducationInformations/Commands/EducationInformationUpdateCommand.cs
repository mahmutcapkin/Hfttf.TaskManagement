using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Commands
{
    public class EducationInformationUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
