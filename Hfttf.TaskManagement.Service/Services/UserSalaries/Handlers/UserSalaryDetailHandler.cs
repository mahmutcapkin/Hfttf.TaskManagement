using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Queries;
using Hfttf.TaskManagement.Service.Services.UserSalaries.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Handlers
{
    public class UserSalaryDetailHandler : BaseUserSalaryHandler, IRequestHandler<UserSalaryDetailQuery, Response>
    {
        public UserSalaryDetailHandler(IUserSalaryRepository userSalaryRepository) : base(userSalaryRepository)
        {
        }
        public async Task<Response> Handle(UserSalaryDetailQuery request, CancellationToken cancellationToken)
        {
            var userSalary = await _userSalaryRepository.FindAsync(x => x.Id == request.Id);
            var userSalaryResponse = TaskManagementMapper.Mapper.Map<UserSalaryResponse>(userSalary);
            var response = Response.Success(userSalaryResponse, 200);
            return response;
        }
    }
}
