using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Queries;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers
{
    public class UserAssignmentListByProjectIdHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentListByProjectIdQuery, Response>
    {

        public UserAssignmentListByProjectIdHandler(IUserAssignmentRepository UserAssignmentRepository) : base(UserAssignmentRepository)
        {
        }

        public async Task<Response> Handle(UserAssignmentListByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var userAssignment = await _UserAssignmentRepository.GetListWithUserandTaskByProjectId(request.ProjectId);
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<UserAssignmentResponse>>(userAssignment);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
