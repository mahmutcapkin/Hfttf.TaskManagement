using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Holidays.Commands;
using Hfttf.TaskManagement.Service.Services.Holidays.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Holidays.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Handlers
{
    public class HolidayUpdateHandler : BaseHolidayHandler, IRequestHandler<HolidayUpdateCommand, Response>
    {
        public HolidayUpdateHandler(IHolidayRepository holidayRepository) : base(holidayRepository)
        {
        }

        public async Task<Response> Handle(HolidayUpdateCommand request, CancellationToken cancellationToken)
        {
            var holiday = TaskManagementMapper.Mapper.Map<Holiday>(request);
            holiday.UpdatedDate = DateTime.Now;
            var holidayGetById = await _holidayRepository.GetByIdAsync(request.Id);
            holiday.CreatedDate = holidayGetById.CreatedDate;
            TimeSpan dayDifference = (holiday.EndDate - holiday.StartDate);
            holiday.Day = dayDifference.TotalDays.ToString();
            var response = await _holidayRepository.UpdateAsync(holiday);
            var holidayResponse = TaskManagementMapper.Mapper.Map<HolidayResponse>(response);
            var result = Response.Success(holidayResponse, 200);
            return result;
        }
    }
}
