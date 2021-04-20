using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Queries
{
    public class JobDetailWithUsersQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
