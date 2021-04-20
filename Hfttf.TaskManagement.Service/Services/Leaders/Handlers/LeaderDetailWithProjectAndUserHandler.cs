using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaders.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaders.Queries;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Handlers
{
    public class LeaderDetailWithProjectAndUserHandler : BaseLeaderHandler, IRequestHandler<LeaderDetailWithProjectAndUserQuery, Response>
    {
        public LeaderDetailWithProjectAndUserHandler(ILeaderRepository LeaderRepository) : base(LeaderRepository)
        {
        }
        public async Task<Response> Handle(LeaderDetailWithProjectAndUserQuery request, CancellationToken cancellationToken)
        {
            var leader = await _leaderRepository.GetLeaderWithUserandProject(request.Id);
            var leaderResponse = TaskManagementMapper.Mapper.Map<LeaderResponse>(leader);
            var response = Response.Success(leaderResponse, 200);
            return response;
        }
    }
}
