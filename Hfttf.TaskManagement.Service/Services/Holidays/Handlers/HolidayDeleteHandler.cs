using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Holidays.Commands;
using Hfttf.TaskManagement.Service.Services.Holidays.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Holidays.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Handlers
{
    public class HolidayDeleteHandler : BaseHolidayHandler, IRequestHandler<HolidayDeleteCommand, Response>
    {
        public HolidayDeleteHandler(IHolidayRepository holidayRepository) : base(holidayRepository)
        {
        }
        public async Task<Response> Handle(HolidayDeleteCommand request, CancellationToken cancellationToken)
        {
            var holiday = TaskManagementMapper.Mapper.Map<Holiday>(request);
            var response = await _holidayRepository.DeleteAsync(holiday);
            var holidayresponse = TaskManagementMapper.Mapper.Map<HolidayResponse>(response);
            var result = Response.Success(holidayresponse, 200);
            return result;
        }
    }
}
