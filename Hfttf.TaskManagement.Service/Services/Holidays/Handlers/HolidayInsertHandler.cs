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
    public class HolidayInsertHandler : BaseHolidayHandler, IRequestHandler<HolidayInsertCommand, Response>
    {
        public HolidayInsertHandler(IHolidayRepository holidayRepository) : base(holidayRepository)
        {
        }
        public async Task<Response> Handle(HolidayInsertCommand request, CancellationToken cancellationToken)
        {
            var holiday = TaskManagementMapper.Mapper.Map<Holiday>(request);
            holiday.CreatedDate = DateTime.Now;
            TimeSpan dayDifference = (holiday.EndDate - holiday.StartDate);
            holiday.NumberOfDay = dayDifference.TotalDays.ToString();
            var response = await _holidayRepository.AddAsync(holiday);
            var holidayResponse = TaskManagementMapper.Mapper.Map<HolidayResponse>(response);
            var result = Response.Success(holidayResponse, 200);
            return result;
        }
    }
}
