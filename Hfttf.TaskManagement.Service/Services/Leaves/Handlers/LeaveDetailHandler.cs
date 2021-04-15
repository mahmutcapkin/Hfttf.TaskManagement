using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaves.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaves.Queries;
using Hfttf.TaskManagement.Service.Services.Leaves.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Handlers
{
    public class LeaveDetailHandler : BaseLeaveHandler, IRequestHandler<LeaveDetailQuery, Response>
    {
        public LeaveDetailHandler(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
        }
        public async Task<Response> Handle(LeaveDetailQuery request, CancellationToken cancellationToken)
        {
            var leave = await _leaveRepository.FindAsync(x => x.Id == request.Id);
            var leaveResponse = TaskManagementMapper.Mapper.Map<LeaveResponse>(leave);
            var response = Response.Success(leaveResponse, 200);
            return response;
        }
    }
}
