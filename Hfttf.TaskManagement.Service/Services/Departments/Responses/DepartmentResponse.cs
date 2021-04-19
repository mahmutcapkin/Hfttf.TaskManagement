using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.ResourceViewModel;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Departments.Responses
{
    public class DepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public IList<UserViewResponse> ApplicationUsers { get; set; }
    }
}
