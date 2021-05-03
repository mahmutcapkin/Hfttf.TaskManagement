using Hfttf.TaskManagement.UI.Enums;
using System;

namespace Hfttf.TaskManagement.UI.Models.User
{
    public class UserAdd
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public int? DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public int? JobId { get; set; }
    }
}
