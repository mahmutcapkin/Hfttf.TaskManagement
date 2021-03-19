using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Queries
{
    public class UserSalaryDetailQuery : IRequest<Response>
    {
        public int  Id { get; set; }
    }
}
