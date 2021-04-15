using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Commands
{
    public class UserSalaryInsertCommand : IRequest<Response>
    {
        public decimal Salary { get; set; }
        public string CreateBy { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
