using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Queries
{
    public class HolidayDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
