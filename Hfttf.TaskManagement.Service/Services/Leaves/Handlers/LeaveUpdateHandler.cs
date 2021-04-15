using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaves.Commands;
using Hfttf.TaskManagement.Service.Services.Leaves.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaves.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaves.Handlers
{
    public class LeaveUpdateHandler : BaseLeaveHandler, IRequestHandler<LeaveUpdateCommand, Response>
    {
        public LeaveUpdateHandler(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
        }

        public async Task<Response> Handle(LeaveUpdateCommand request, CancellationToken cancellationToken)
        {
            var leave = TaskManagementMapper.Mapper.Map<Leave>(request);
            leave.UpdatedDate = DateTime.Now;
            var LeaveGetById = await _leaveRepository.GetByIdAsync(request.Id);
            leave.CreatedDate = LeaveGetById.CreatedDate;
            TimeSpan dayDifference = (leave.EndDate - leave.StartDate);
            leave.NumberOfDay = dayDifference.TotalDays.ToString();
            var response = await _leaveRepository.UpdateAsync(leave);
            var leaveResponse = TaskManagementMapper.Mapper.Map<LeaveResponse>(response);
            var result = Response.Success(leaveResponse, 200);
            return result;
        }
    }
}
