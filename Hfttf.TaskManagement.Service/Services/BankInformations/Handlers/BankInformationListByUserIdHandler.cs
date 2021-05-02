using Hfttf.TaskManagement.Core.Entities;
using Hfttf.TaskManagement.Core.Models;
using Hfttf.TaskManagement.Core.Repositories;
using Hfttf.TaskManagement.Service.Mappers;
using Hfttf.TaskManagement.Service.Services.BankInformations.Handlers.Base;
using Hfttf.TaskManagement.Service.Services.BankInformations.Queries;
using Hfttf.TaskManagement.Service.Services.BankInformations.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Handlers
{
    public class BankInformationListByUserIdHandler : BaseBankInformationHandler, IRequestHandler<BankInformationListByUserIdQuery, Response>
    {
        public BankInformationListByUserIdHandler(IBankInformationRepository BankInformationRepository) : base(BankInformationRepository)
        {

        }
        public async Task<Response> Handle(BankInformationListByUserIdQuery request, CancellationToken cancellationToken)
        {
            var bankInformation = await _bankInformationRepository.GetListWithUserByUserId(request.UserId);
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<BankInformationResponse>>(bankInformation);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
