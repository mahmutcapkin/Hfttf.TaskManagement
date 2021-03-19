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
    public class UserSalaryInsertHandler : BaseUserSalaryHandler, IRequestHandler<UserSalaryInsertCommand, Response>
    {

        public UserSalaryInsertHandler(IUserSalaryRepository userSalaryRepository) : base(userSalaryRepository)
        {
        }
        public async Task<Core.Models.Response> Handle(UserSalaryInsertCommand request, CancellationToken cancellationToken)
        {
            var userSalary = TaskManagementMapper.Mapper.Map<UserSalary>(request);
            userSalary.CreatedDate = DateTime.Now;
            var response = await _userSalaryRepository.AddAsync(userSalary);
            var userSalaryResponse = TaskManagementMapper.Mapper.Map<UserSalaryResponse>(response);
            var result = Response.Success(userSalaryResponse, 200);
            return result;

        }
    }
}
