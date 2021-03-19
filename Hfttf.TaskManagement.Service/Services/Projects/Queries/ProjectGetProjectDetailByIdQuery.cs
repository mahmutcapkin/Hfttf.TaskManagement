using Hfttf.TaskManagement.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Projects.Queries
{
   public class ProjectGetProjectDetailByIdQuery:IRequest<Response>
    {
        public int Id { get; set; }
    }
}
