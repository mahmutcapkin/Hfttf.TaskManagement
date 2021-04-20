using Hfttf.TaskManagement.Core.Models;
using MediatR;

namespace Hfttf.TaskManagement.Service.Services.EducationInformations.Queries
{
    public class EducationInformationDetailQuery : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
