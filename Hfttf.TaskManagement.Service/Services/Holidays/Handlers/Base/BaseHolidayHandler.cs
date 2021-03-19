using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Handlers.Base
{
    public class BaseHolidayHandler
    {
        protected readonly IHolidayRepository _holidayRepository;

        public BaseHolidayHandler(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }
    }
}
