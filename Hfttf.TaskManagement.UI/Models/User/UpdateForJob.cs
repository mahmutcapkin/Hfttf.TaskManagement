using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.User
{
    public class UpdateForJob
    {
        [DisplayName("Kullanıcı"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string UserId { get; set; }  
        public int? JobId { get; set; }
    }
}
