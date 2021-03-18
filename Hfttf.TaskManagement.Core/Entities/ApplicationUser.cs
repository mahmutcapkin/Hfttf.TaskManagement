using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Address> Addresses { get; set; }
    }
}
