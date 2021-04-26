using System;

namespace Hfttf.TaskManagement.UI.Models.UserSalary
{
    public class UserSalaryForUserInfoResponse
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
