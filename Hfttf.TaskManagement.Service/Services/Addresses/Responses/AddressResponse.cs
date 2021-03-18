using Hfttf.TaskManagement.Core.Entities;
using System;

namespace Hfttf.TaskManagement.Service.Services.Addresses.Responses
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
