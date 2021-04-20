using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Queries
{
    public class LeaderDetailWithProjectAndUserQuery : IRequest<Response>
    {
        public int Id { get; set; } 
    }
}
