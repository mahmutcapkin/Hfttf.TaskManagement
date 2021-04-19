using Hfttf.TaskManagement.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Models.User
{
    public class UserProfileInfo
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int? DepartmentId { get; set; }
        //public Department Department { get; set; }
        public int? JobId { get; set; }
        //public Job Job { get; set; }
        //public IList<Address> Addresses { get; set; }
        //public IList<Experience> Experiences { get; set; }
        //public IList<EducationInformation> EducationInformations { get; set; }
        //public IList<EmergencyContactInfo> EmergencyContactInfos { get; set; }
        //public IList<BankInformation> BankInformations { get; set; }


    }
}
