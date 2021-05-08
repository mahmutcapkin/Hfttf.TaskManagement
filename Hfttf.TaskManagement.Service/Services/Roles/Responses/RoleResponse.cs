using Hfttf.TaskManagement.Service.Services.Users.Responses;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Roles.Responses
{
    public class RoleResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<UserResponse> ApplicationUsers { get; set; }
    }
}
