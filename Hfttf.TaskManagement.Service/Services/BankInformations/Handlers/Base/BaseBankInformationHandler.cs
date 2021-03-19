using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.BankInformations.Handlers.Base
{
    public class BaseBankInformationHandler
    {
        protected readonly IBankInformationRepository _bankInformationRepository;

        public BaseBankInformationHandler(IBankInformationRepository bankInformationRepository)
        {
            _bankInformationRepository = bankInformationRepository;
        }
    }
}
