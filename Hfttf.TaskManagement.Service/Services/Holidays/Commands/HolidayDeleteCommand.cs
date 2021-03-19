using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Commands
{
    public class HolidayDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
