using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Users.Commands
{
    public class UserInsertCommand : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; }

    }
}
