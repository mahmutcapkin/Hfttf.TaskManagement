using Hfttf.TaskManagement.UI.Models.Department;
using Hfttf.TaskManagement.UI.Models.Job;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.UI.Models.User
{
    public class UserUpdateViewModel
    {
        public UserUpdate User { get; set; }
        public List<DepartmentResponse> Departments { get; set; }
        public List<JobResponse> Jobs { get; set; }
    }
}
