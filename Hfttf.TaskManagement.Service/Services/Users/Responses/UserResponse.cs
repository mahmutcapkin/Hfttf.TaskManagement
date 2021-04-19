using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Addresses.Responses;
using Hfttf.TaskManagement.Service.Services.BankInformations.Responses;
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
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; }
        public JobResponse Job { get; set; }
        public List<EmergencyContactUserInfoResponse> EmergencyContactInfos { get; set; }
        public List<BankInformationForUserInfoResponse> BankInformations { get; set; }
        public List<EducationInformationForUserInfoResponse> EducationInformations { get; set; }
        public List<ExperienceForUserInfoResponse> Experiences { get; set; }
        public List<AddressForUserInfoResponse> Addresses { get; set; }
        public List<LeaderForUserResponse> Leaders { get; set; }
        public List<LeaveForUserResponse> Leaves { get; set; }
        public List<UserAssignmentForUserResponse> UserAssignments { get; set; }
        public List<UserSalaryForUserInfoResponse> UserSalaries { get; set; }
        public List<AddressForUserInfoResponse> Projects { get; set; }

    }
}
