using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.User
{
    public class UserDropdownList
    {
        [Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string UserId { get; set; }
        public string FullName { get; set; }
    }
}
