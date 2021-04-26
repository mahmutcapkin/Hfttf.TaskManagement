using Hfttf.TaskManagement.UI.Models.User;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.UI.Models.Job
{
    public class JobResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserResponse> ApplicationUsers { get; set; }
    }
}
