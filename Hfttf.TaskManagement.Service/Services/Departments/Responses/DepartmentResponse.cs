using System;

namespace Hfttf.TaskManagement.Service.Services.Departments.Responses
{
    public class DepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public bool IsActive { get; set; }
    }
}
