using Hfttf.TaskManagement.Core.Entities;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.ResourceViewModel
{
    public class UserWithRolesResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

    }
}
