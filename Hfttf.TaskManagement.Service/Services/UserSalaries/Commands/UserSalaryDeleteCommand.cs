using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Commands
{
   public class UserSalaryDeleteCommand : IRequest<Response>
    {
        public int  Id { get; set; }
    }
}
