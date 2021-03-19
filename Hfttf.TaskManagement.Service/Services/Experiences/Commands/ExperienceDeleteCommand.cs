﻿using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.Experiences.Commands
{
    public class ExperienceDeleteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
