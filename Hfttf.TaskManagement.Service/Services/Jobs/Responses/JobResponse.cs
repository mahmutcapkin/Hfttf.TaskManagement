using Hfttf.TaskManagement.Core.ResourceViewModel;
using Hfttf.TaskManagement.Service.Services.Users.Responses;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Responses
{
    public class JobResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<UserViewResponse> ApplicationUsers { get; set; }
    }
}
