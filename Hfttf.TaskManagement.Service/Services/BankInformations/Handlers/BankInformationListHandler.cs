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
    public class BankInformationListHandler : BaseBankInformationHandler, IRequestHandler<BankInformationListQuery, Response>
    {
        public BankInformationListHandler(IBankInformationRepository BankInformationRepository) : base(BankInformationRepository)
        {

        }
        public async Task<Response> Handle(BankInformationListQuery request, CancellationToken cancellationToken)
        {
            var bankInformation = await _bankInformationRepository.GetListWithUser();
            var response = TaskManagementMapper.Mapper.Map<IEnumerable<BankInformationResponse>>(bankInformation);
            var result = Response.Success(response, 200);
            return result;
        }
    }
}
