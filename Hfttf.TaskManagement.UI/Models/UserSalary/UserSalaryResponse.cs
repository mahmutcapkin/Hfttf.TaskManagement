using Hfttf.TaskManagement.UI.Models.User;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.UserSalary
{
    public class UserSalaryResponse
    {
        public int Id { get; set; }

        [DisplayName("Maaş"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public decimal Salary { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ApplicationUserId { get; set; }

        [DisplayName("Kullanıcı"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public UserResponse ApplicationUser { get; set; }
    }
}
