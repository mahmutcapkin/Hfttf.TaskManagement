using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Commands
{
    public class UserSalaryInsertCommand : IRequest<Response>
    {
        public decimal Salary { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
