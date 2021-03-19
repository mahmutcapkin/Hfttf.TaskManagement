using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Commands
{
    public class HolidayInsertCommand : IRequest<Response>
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
