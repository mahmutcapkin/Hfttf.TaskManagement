using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Commands
{
    public class HolidayUpdateCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Day { get; set; }
        public bool IsActive { get; set; }
    }
}
