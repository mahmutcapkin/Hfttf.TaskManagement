using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaves.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaves.Queries;
using Hfttf.TaskManagement.Service.Services.Leaves.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Handlers
{
    public class LeaveListByUserIdHandler : BaseLeaveHandler, IRequestHandler<LeaveListByUserIdQuery, Response>
    {
        public LeaveListByUserIdHandler(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
        }

        public async Task<Response> Handle(LeaveListByUserIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Leave> leave;
            if (request.UserId == null)
            {
                leave = await _leaveRepository.GetListWithUser();
            }
            else
            {
                leave = await _leaveRepository.GetListWithUserByUserId(request.UserId);
            }
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<LeaveResponse>>(leave);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
