using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Projects.Queries
{
    public class ProjectDetailWithTaskandUserQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
