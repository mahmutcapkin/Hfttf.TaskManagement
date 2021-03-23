using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.Leaders.Commands;
using Hfttf.TaskManagement.Service.Services.Leaders.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.Leaders.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.Leaders.Handlers
{
    public class LeaderDeleteHandler : BaseLeaderHandler, IRequestHandler<LeaderDeleteCommand, Response>
    {
        public LeaderDeleteHandler(ILeaderRepository LeaderRepository) : base(LeaderRepository)
        {
        }
        public async Task<Response> Handle(LeaderDeleteCommand request, CancellationToken cancellationToken)
        {
            var leader = TaskManagementMapper.Mapper.Map<Leader>(request);
            var response = await _leaderRepository.DeleteAsync(leader);
            var leaderresponse = TaskManagementMapper.Mapper.Map<LeaderResponse>(response);
            var result = Response.Success(leaderresponse, 200);
            return result;
        }
    }
}
