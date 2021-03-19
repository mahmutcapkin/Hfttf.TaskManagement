using Hfttf.TaskManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Service.Services.UserSalaries.Responses
{
   public class UserSalaryResponse
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public sbyte PayType { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        //public string UserId { get; set; }
        //public User User { get; set; }
    }
}
