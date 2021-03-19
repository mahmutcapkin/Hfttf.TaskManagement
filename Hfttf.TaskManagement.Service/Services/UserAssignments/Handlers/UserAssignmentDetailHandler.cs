using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Queries;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers
{
    public class UserAssignmentDetailHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentDetailQuery, Response>
    {
        public UserAssignmentDetailHandler(IUserAssignmentRepository UserAssignmentRepository) : base(UserAssignmentRepository)
        {
        }
        public async Task<Response> Handle(UserAssignmentDetailQuery request, CancellationToken cancellationToken)
        {
            var UserAssignment = await _UserAssignmentRepository.FindAsync(x => x.Id == request.Id);
            var response = TaskManagementMapper.Mapper.Map<UserAssignmentResponse>(UserAssignment);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
