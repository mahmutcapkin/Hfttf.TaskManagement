﻿using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;

namespace Hfttf.TaskManagement.Service.Services.Tasks.Commands
{
    public class TaskInsertCommand : IRequest<Response>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? ProjectId { get; set; }
        public int TaskStatusId { get; set; }
    }
}
