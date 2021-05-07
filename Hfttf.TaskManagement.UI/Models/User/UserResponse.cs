using Hfttf.TaskManagement.UI.Enums;
using Hfttf.TaskManagement.UI.Models.Address;
using Hfttf.TaskManagement.UI.Models.BankInformation;
using Hfttf.TaskManagement.UI.Models.Department;
using Hfttf.TaskManagement.UI.Models.EducationInformation;
using Hfttf.TaskManagement.UI.Models.EmergencyContactInfo;
using Hfttf.TaskManagement.UI.Models.Experience;
using Hfttf.TaskManagement.UI.Models.Job;
using Hfttf.TaskManagement.UI.Models.Leader;
using Hfttf.TaskManagement.UI.Models.Leave;
using Hfttf.TaskManagement.UI.Models.Project;
using Hfttf.TaskManagement.UI.Models.UserAssignment;
using Hfttf.TaskManagement.UI.Models.UserSalary;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.User
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public GenderType Gender { get; set; }
        public string PictureUrl { get; set; }

        [Display(Name = "Profil Fotoğrafı"), 
        Required(ErrorMessage = "{0} alanı boş geçilemez...")] 
        public IFormFile ProfilePicture { get; set; }
        public int? DepartmentId { get; set; }
        public int? JobId { get; set; }
        public JobForUserResponse Job { get; set; }
        public DepartmentForUserResponse Department { get; set; }
        public List<EmergencyContactUserInfoResponse> EmergencyContactInfos { get; set; }
        public List<BankInformationForUserInfoResponse> BankInformations { get; set; }
        public List<EducationInformationForUserInfoResponse> EducationInformations { get; set; }
        public List<ExperienceForUserInfoResponse> Experiences { get; set; }
        public List<AddressForUserInfoResponse> Addresses { get; set; }
        public List<LeaderForUserResponse> Leaders { get; set; }
        public List<LeaveForUserResponse> Leaves { get; set; }
        public List<UserAssignmentForUserResponse> UserAssignments { get; set; }
        public List<UserSalaryForUserInfoResponse> UserSalaries { get; set; }
        public List<ProjectForUserResponse> Projects { get; set; }
    }
}
