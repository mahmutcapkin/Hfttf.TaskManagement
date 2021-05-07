using Hfttf.TaskManagement.Core.Entities;
using System;

namespace Hfttf.TaskManagement.Service.Services.Users.Responses
{
    public class UserViewResponse
    {   
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string PictureUrl { get; set; }
        public int? DepartmentId { get; set; }
        public int? JobId { get; set; }
        //public Job Job { get; set; }
        //public Department Department { get; set; }   
    }
}
