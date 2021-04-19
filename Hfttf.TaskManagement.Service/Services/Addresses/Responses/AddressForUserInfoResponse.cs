namespace Hfttf.TaskManagement.Service.Services.Addresses.Responses
{
    public class AddressForUserInfoResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
