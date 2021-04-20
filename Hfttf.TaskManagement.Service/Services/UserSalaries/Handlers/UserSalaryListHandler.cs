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
    public class UserSalaryListHandler : BaseUserSalaryHandler, IRequestHandler<UserSalaryListQuery, Response>
    {
        public UserSalaryListHandler(IUserSalaryRepository userSalaryRepository) : base(userSalaryRepository)
        {
        }
        public async Task<Response> Handle(UserSalaryListQuery request, CancellationToken cancellationToken)
        {
            var userSalaries = await _userSalaryRepository.GetListWithUser();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<UserSalaryResponse>>(userSalaries);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
