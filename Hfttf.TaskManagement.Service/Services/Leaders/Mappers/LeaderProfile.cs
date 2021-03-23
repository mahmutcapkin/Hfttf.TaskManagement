using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Leaders.Commands;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Mappers
{
    public class LeaderProfile : Profile
    {
        public LeaderProfile()
        {
            CreateMap<LeaderInsertCommand, Leader>().ReverseMap();
            CreateMap<LeaderUpdateCommand, Leader>().ReverseMap();
            CreateMap<LeaderDeleteCommand, Leader>().ReverseMap();
            CreateMap<Leader, LeaderResponse>().ReverseMap();
        }
    }
}
