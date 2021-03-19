using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Commands;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers
{
    public class UserAssignmentDeleteHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentDeleteCommand, Response>
    {
        public UserAssignmentDeleteHandler(IUserAssignmentRepository UserAssignmentRepository) : base(UserAssignmentRepository)
        {
        }
        public async Task<Response> Handle(UserAssignmentDeleteCommand request, CancellationToken cancellationToken)
        {
            var UserAssignment = TaskManagementMapper.Mapper.Map<UserAssignment>(request);
            var response = await _UserAssignmentRepository.DeleteAsync(UserAssignment);
            var UserAssignmentResponse = TaskManagementMapper.Mapper.Map<UserAssignmentResponse>(response);
            var result = Response.Success(UserAssignmentResponse, 200);
            return result;
        }
    }
}
