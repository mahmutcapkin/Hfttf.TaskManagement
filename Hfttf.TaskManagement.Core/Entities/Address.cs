using Hfttf.TaskManagement.Core.Entities.Base;
using System;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Address : Entity
    {
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
