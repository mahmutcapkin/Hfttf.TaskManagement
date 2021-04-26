using Hfttf.TaskManagement.UI.Models.User;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.UI.Models.Department
{
    public class DepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserResponse> ApplicationUsers { get; set; }
    }
}
