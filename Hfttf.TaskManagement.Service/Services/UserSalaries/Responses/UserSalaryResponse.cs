using Hfttf.TaskManagement.Core.ResourceViewModel;
using System;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Responses
{
    public class UserSalaryResponse
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public UserViewResponse ApplicationUser { get; set; }
    }
}
