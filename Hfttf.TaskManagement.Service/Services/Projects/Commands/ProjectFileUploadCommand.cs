using Hfttf.TaskManagement.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Hfttf.TaskManagement.Service.Services.Projects.Commands
{
    public class ProjectFileUploadCommand : IRequest<Response>
    {
        public int ProjectId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
