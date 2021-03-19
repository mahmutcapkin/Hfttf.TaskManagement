using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Holidays.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Holidays.Queries;
using Hfttf.TaskManagement.Service.Services.Holidays.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Handlers
{
    public class HolidayListHandler : BaseHolidayHandler, IRequestHandler<HolidayListQuery, Response>
    {
        public HolidayListHandler(IHolidayRepository holidayRepository) : base(holidayRepository)
        {
        }

        public async Task<Response> Handle(HolidayListQuery request, CancellationToken cancellationToken)
        {
            var holiday = await _holidayRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<HolidayResponse>>(holiday);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
