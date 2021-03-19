using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Commands
{
    public class UserSalaryInsertCommand : IRequest<Response>
    {

        public decimal Salary { get; set; }
        public sbyte PayType { get; set; }
        public string CreateBy { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }
}
