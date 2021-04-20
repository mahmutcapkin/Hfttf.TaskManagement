using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Queries
{
    public class UserSalaryListByUserIdQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
