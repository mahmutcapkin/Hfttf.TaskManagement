using Hfttf.TaskManagement.UI.Models.User;

namespace Hfttf.TaskManagement.UI.Models.Address
{
    public class AddressResponse
    {
        //public int Id { get; set; }
        //public string Description { get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        //public string ZipCode { get; set; }
        //public string ApplicationUserId { get; set; }
        //public AppUser ApplicationUser { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string ApplicationUserId { get; set; }
        public UserResponse ApplicationUser { get; set; }
    }
}
