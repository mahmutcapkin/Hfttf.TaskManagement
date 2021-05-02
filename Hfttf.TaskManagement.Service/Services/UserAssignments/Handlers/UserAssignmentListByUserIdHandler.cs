using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Queries;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers
{
    public class UserAssignmentListByUserIdHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentListByUserIdQuery, Response>
    {

        public UserAssignmentListByUserIdHandler(IUserAssignmentRepository UserAssignmentRepository) : base(UserAssignmentRepository)
        {
        }

        public async Task<Response> Handle(UserAssignmentListByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userAssignment = await _UserAssignmentRepository.GetListWithUserandTaskByUserId(request.UserId);
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<UserAssignmentResponse>>(userAssignment);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
