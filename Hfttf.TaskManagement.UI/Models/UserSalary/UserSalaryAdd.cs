using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.UserSalary
{
    public class UserSalaryAdd
    {
        [DisplayName("Maaş"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public decimal Salary { get; set; }
        public string CreateBy { get; set; }

        [DisplayName("Kullanıcı"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string ApplicationUserId { get; set; }


    }
}
