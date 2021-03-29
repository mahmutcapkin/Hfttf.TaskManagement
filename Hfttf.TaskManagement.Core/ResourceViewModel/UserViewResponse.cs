using Hfttf.TaskManagement.Core.Entities;
using System;

namespace Hfttf.TaskManagement.Core.ResourceViewModel
{
    public class UserViewResponse
    {
        //[Required(ErrorMessage = "Kullanıcı ismi gerekldir.")]
        public string UserName { get; set; }

        //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "Email adresi gereklidir.")]
        //[EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int? DepartmentId { get; set; }
        //public Department Department { get; set; }
        //public IList<Leader> Leaders { get; set; }
        //public IList<Address> Addresses { get; set; }
        //public IList<Experience> Experiences { get; set; }
        //public IList<EducationInformation> EducationInformations { get; set; }
        //public IList<EmergencyContactInfo> EmergencyContactInfos { get; set; }
        //public IList<BankInformation> BankInformations { get; set; }
        //public IList<UserAssignment> UserAssignments { get; set; }
        //public IList<UserSalary> UserSalaries { get; set; }
    }
}
