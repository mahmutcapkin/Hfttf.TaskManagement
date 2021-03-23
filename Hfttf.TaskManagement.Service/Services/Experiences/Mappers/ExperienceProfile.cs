﻿using AutoMapper;
using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Service.Services.Experiences.Commands;
using Hfttf.TaskManagement.Service.Services.Experiences.Responses;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Mappers
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<ExperienceDeleteCommand, Experience>().ReverseMap();
            CreateMap<ExperienceInsertCommand, Experience>().ReverseMap();
            CreateMap<ExperienceUpdateCommand, Experience>().ReverseMap();
            CreateMap<Experience, ExperienceResponse>().ReverseMap();
        }
    }
}