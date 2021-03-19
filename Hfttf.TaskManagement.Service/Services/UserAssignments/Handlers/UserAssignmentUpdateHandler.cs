using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Commands;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.UserAssignments.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.UserAssignments.Handlers
{
    public class UserAssignmentUpdateHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentUpdateCommand, Response>
    {
        public UserAssignmentUpdateHandler(IUserAssignmentRepository UserAssignmentRepository) : base(UserAssignmentRepository)
        {
        }
        public async Task<Response> Handle(UserAssignmentUpdateCommand request, CancellationToken cancellationToken)
        {
            var UserAssignment = TaskManagementMapper.Mapper.Map<UserAssignment>(request);
            UserAssignment.UpdatedDate = DateTime.Now;
            var UserAssignmentGetById = await _UserAssignmentRepository.GetByIdAsync(request.Id);
            UserAssignment.CreatedDate = UserAssignmentGetById.CreatedDate;
            UserAssignment.CreateBy = UserAssignmentGetById.CreateBy;
            var response = await _UserAssignmentRepository.UpdateAsync(UserAssignment);
            var UserAssignmentResponse = TaskManagementMapper.Mapper.Map<UserAssignmentResponse>(response);
            var result = Response.Success(UserAssignmentResponse, 200);
            return result;
        }
    }
}
