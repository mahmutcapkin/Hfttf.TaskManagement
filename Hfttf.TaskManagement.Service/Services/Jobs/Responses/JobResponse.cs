using System;

namespace Hfttf.TaskManagement.Service.Services.Jobs.Responses
{
    public class JobResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        //  public List<ApplicationUser> Users { get; set; } 
    }
}
