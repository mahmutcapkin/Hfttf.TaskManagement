using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Queries;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Handlers
{
    public class UserSalaryListByUserIdHandler : BaseUserSalaryHandler, IRequestHandler<UserSalaryListByUserIdQuery, Response>
    {
        public UserSalaryListByUserIdHandler(IUserSalaryRepository userSalaryRepository) : base(userSalaryRepository)
        {
        }
        public async Task<Response> Handle(UserSalaryListByUserIdQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<UserSalary> userSalaries;
            if (request.UserId == null)
            {
                userSalaries = await _userSalaryRepository.GetListWithUser();
            }
            else
            {
                userSalaries = await _userSalaryRepository.GetListWithUserByUserId(request.UserId);
            }
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<UserSalaryResponse>>(userSalaries);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
