using Hfttf.TaskManagement.UI.Enums;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.UI.Models.Authentication
{
    public class AppUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
