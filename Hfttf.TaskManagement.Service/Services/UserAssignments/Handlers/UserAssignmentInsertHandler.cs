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
    public class UserAssignmentInsertHandler : BaseUserAssignmentHandler, IRequestHandler<UserAssignmentInsertCommand, Response>
    {
        public UserAssignmentInsertHandler(IUserAssignmentRepository UserAssignmentRepository) : base(UserAssignmentRepository)
        {
        }
        public async Task<Core.Models.Response> Handle(UserAssignmentInsertCommand request, CancellationToken cancellationToken)
        {
            var UserAssignment = TaskManagementMapper.Mapper.Map<UserAssignment>(request);
            UserAssignment.CreatedDate = DateTime.Now;
            var response = await _UserAssignmentRepository.AddAsync(UserAssignment);
            var UserAssignmentResponse = TaskManagementMapper.Mapper.Map<UserAssignmentResponse>(response);
            var result = Response.Success(UserAssignmentResponse, 200);
            return result;
        }
    }
}
