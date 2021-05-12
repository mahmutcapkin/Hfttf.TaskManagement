using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.UserSalary
{
    public class UserSalaryUpdate
    {
        public int Id { get; set; }

        [DisplayName("Maaş"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public decimal Salary { get; set; }
        public string UpdateBy { get; set; }

        [DisplayName("Kullanıcı"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string ApplicationUserId { get; set; }
    }
}
