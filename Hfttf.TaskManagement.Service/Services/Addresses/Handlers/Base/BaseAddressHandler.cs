using Hfttf.TaskManagement.Core.Repositories;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Handlers.Base
{
    public class BaseAddressHandler
    {
        protected readonly IAddressRepository _addressRepository;

        public BaseAddressHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
    }
}
