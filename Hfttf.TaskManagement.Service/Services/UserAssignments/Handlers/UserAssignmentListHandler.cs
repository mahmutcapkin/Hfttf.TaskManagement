using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Queries;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers.Base;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers
{
    public class UserAssignmentListHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentListQuery, Response>
    {

        public UserAssignmentListHandler(IUserAssignmentRepository UserAssignmentRepository) : base(UserAssignmentRepository)
        {
        }

        public async Task<Response> Handle(UserAssignmentListQuery request, CancellationToken cancellationToken)
        {
            var UserAssignment = await _UserAssignmentRepository.GetListWithUserandTask();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<UserAssignmentResponse>>(UserAssignment);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
