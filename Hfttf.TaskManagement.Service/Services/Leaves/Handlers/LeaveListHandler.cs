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
    public class LeaveListHandler : BaseLeaveHandler, IRequestHandler<LeaveListQuery, Response>
    {
        public LeaveListHandler(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
        }

        public async Task<Response> Handle(LeaveListQuery request, CancellationToken cancellationToken)
        {
            var leave = await _leaveRepository.GetAllAsync();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<LeaveResponse>>(leave);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
