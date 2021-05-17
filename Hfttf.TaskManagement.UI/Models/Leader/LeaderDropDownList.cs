using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Leader
{
    public class LeaderDropDownList
    {
        [Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string UserId { get; set; }
        public string FullName { get; set; }
    }
}
