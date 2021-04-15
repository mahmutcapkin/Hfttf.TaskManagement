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
    public class LeaveInsertHandler : BaseLeaveHandler, IRequestHandler<LeaveInsertCommand, Response>
    {
        public LeaveInsertHandler(ILeaveRepository leaveRepository) : base(leaveRepository)
        {
        }
        public async Task<Response> Handle(LeaveInsertCommand request, CancellationToken cancellationToken)
        {
            var leave = TaskManagementMapper.Mapper.Map<Leave>(request);
            leave.CreatedDate = DateTime.Now;
            TimeSpan dayDifference = (leave.EndDate - leave.StartDate);
            leave.NumberOfDay = dayDifference.TotalDays.ToString();
            var response = await _leaveRepository.AddAsync(leave);
            var leaveResponse = TaskManagementMapper.Mapper.Map<LeaveResponse>(response);
            var result = Response.Success(leaveResponse, 200);
            return result;
        }
    }
}
