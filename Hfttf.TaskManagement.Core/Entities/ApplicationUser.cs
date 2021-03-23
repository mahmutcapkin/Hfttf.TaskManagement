using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public IList<Leader> Leaders { get; set; }
        public IList<Address> Addresses { get; set; }
        public IList<Experience> Experiences { get; set; }
        public IList<EducationInformation> EducationInformations { get; set; }
        public IList<EmergencyContactInfo> EmergencyContactInfos { get; set; }
        public IList<BankInformation> BankInformations { get; set; }
        public IList<UserAssignment> UserAssignments { get; set; }
        public IList<UserSalary> UserSalaries { get; set; }
    }

    public enum Gender
    {
        Male=1,
        Female
    }
}
