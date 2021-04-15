using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaves.Commands;
using Hfttf.TaskManagement.Service.Services.Leaves.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaves.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Handlers
{
    public class LeaveDeleteHandler : BaseLeaveHandler, IRequestHandler<LeaveDeleteCommand, Response>
    {
        public LeaveDeleteHandler(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
        }
        public async Task<Response> Handle(LeaveDeleteCommand request, CancellationToken cancellationToken)
        {
            var leave = TaskManagementMapper.Mapper.Map<Leave>(request);
            var response = await _leaveRepository.DeleteAsync(leave);
            var leaveresponse = TaskManagementMapper.Mapper.Map<LeaveResponse>(response);
            var result = Response.Success(leaveresponse, 200);
            return result;
        }
    }
}
