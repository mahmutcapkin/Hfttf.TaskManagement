using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Holidays.Commands;
using Hfttf.TaskManagement.Service.Services.Holidays.Responses;

namespace Hfttf.TaskManagement.Service.Services.Holidays.Mappers
{
    public class HolidayProfile : Profile
    {
        public HolidayProfile()
        {
            CreateMap<HolidayInsertCommand, Holiday>().ReverseMap();
            CreateMap<HolidayUpdateCommand, Holiday>().ReverseMap();
            CreateMap<HolidayDeleteCommand, Holiday>().ReverseMap();
            CreateMap<Holiday, HolidayResponse>().ReverseMap();
        }
    }
}
