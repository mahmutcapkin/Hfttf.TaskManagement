using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Projects.Queries
{
    public class ProjectListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
