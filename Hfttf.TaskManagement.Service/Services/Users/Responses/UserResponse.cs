using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Addresses.Responses;
using Hfttf.TaskManagement.Service.Services.BankInformations.Responses;
using Hfttf.TaskManagement.Service.Services.Departments.Responses;
using Hfttf.TaskManagement.Service.Services.EducationInformations.Responses;
using Hfttf.TaskManagement.Service.Services.EmergencyContactInfos.Responses;
using Hfttf.TaskManagement.Service.Services.Experiences.Responses;
using Hfttf.TaskManagement.Service.Services.Jobs.Responses;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using Hfttf.TaskManagement.Service.Services.Leaves.Responses;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Responses;
using System;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Service.Services.Users.Responses
{
    public class UserResponse
    {
        //public string Id { get; set; }
        //public string UserName { get; set; }
        //public string Email { get; set; }
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        // public DateTime BirthDate { get; set; }
        // public Gender Gender { get; set; }
        // public int? DepartmentId { get; set; }
        //// public string PhoneNumber { get; set; }
        // public int? JobId { get; set; }
        //public JobForUserResponse Job { get; set; }
        //public DepartmentForUserResponse Department { get; set; }
        ////public IList<string> Roles { get; set; }
        //public IList<EmergencyContactUserInfoResponse> EmergencyContactInfos { get; set; }
        //public IList<BankInformationForUserInfoResponse> BankInformations { get; set; }
        //public IList<EducationInformationForUserInfoResponse> EducationInformations { get; set; }
        //public IList<ExperienceForUserInfoResponse> Experiences { get; set; }
        //public IList<AddressForUserInfoResponse> Addresses { get; set; }
        //public IList<LeaderForUserResponse> Leaders { get; set; }
        //public IList<LeaveForUserResponse> Leaves { get; set; }
        //public IList<UserAssignmentForUserResponse> UserAssignments { get; set; }
        //public IList<UserSalaryForUserInfoResponse> UserSalaries { get; set; }
        //public IList<AddressForUserInfoResponse> Projects { get; set; }

        //--------------------------------------------------------------
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int? DepartmentId { get; set; }
        public int? JobId { get; set; }
        public JobForUserResponse Job { get; set; }
        public DepartmentForUserResponse Department { get; set; }
        public IList<EmergencyContactUserInfoResponse> EmergencyContactInfos { get; set; }
        public IList<BankInformationForUserInfoResponse> BankInformations { get; set; }
        public IList<EducationInformationForUserInfoResponse> EducationInformations { get; set; }
        public IList<ExperienceForUserInfoResponse> Experiences { get; set; }
        public IList<AddressForUserInfoResponse> Addresses { get; set; }
        public IList<LeaderForUserResponse> Leaders { get; set; }
        public IList<LeaveForUserResponse> Leaves { get; set; }
        public IList<UserAssignmentForUserResponse> UserAssignments { get; set; }
        public IList<UserSalaryForUserInfoResponse> UserSalaries { get; set; }
        public IList<AddressForUserInfoResponse> Projects { get; set; }
    }
}
