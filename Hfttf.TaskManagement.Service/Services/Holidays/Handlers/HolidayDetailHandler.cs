using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Holidays.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Holidays.Queries;
using Hfttf.TaskManagement.Service.Services.Holidays.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Handlers
{
    public class HolidayDetailHandler : BaseHolidayHandler, IRequestHandler<HolidayDetailQuery, Response>
    {
        public HolidayDetailHandler(IHolidayRepository holidayRepository) : base(holidayRepository)
        {
        }
        public async Task<Response> Handle(HolidayDetailQuery request, CancellationToken cancellationToken)
        {
            var holiday = await _holidayRepository.FindAsync(x => x.Id == request.Id);
            var holidayResponse = TaskManagementMapper.Mapper.Map<HolidayResponse>(holiday);
            var response = Response.Success(holidayResponse, 200);
            return response;
        }
    }
}
