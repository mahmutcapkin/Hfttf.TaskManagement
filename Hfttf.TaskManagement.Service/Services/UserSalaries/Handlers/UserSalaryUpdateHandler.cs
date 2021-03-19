using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Commands;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Handlers
{
    public class UserSalaryUpdateHandler : BaseUserSalaryHandler, IRequestHandler<UserSalaryUpdateCommand, Response>
    {
        public UserSalaryUpdateHandler(IUserSalaryRepository userSalaryRepository) : base(userSalaryRepository)
        {
        }
        public async Task<Response> Handle(UserSalaryUpdateCommand request, CancellationToken cancellationToken)
        {
            var userSalary = TaskManagementMapper.Mapper.Map<UserSalary>(request);
            userSalary.UpdatedDate = DateTime.Now;
            var userSalaryGetById = await _userSalaryRepository.GetByIdAsync(request.Id);
            userSalary.CreatedDate = userSalaryGetById.CreatedDate;
            userSalary.CreateBy = userSalaryGetById.CreateBy;
            var response = await _userSalaryRepository.UpdateAsync(userSalary);
            var userSalaryResponse = TaskManagementMapper.Mapper.Map<UserSalaryResponse>(response);
            var result = Response.Success(userSalaryResponse, 200);
            return result;
        }
    }
}
