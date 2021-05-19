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
    public class UserAssignmentDetailWithTaskandUserHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentDetailWithTaskandUserQuery, Response>
    {
        public UserAssignmentDetailWithTaskandUserHandler(IUserAssignmentRepository UserAssignmentRepository) : base(UserAssignmentRepository)
        {
        }
        public async Task<Response> Handle(UserAssignmentDetailWithTaskandUserQuery request, CancellationToken cancellationToken)
        {
            var UserAssignment = await _UserAssignmentRepository.GetDetailWithUserandTask(request.Id);
            var response = TaskManagementMapper.Mapper.Map<UserAssignmentResponse>(UserAssignment);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
