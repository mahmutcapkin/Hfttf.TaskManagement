using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.UserAssignment
{
    public class UserAssignmentModel
    {
        [DisplayName("Kullanıcılar"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string ApplicationUserId { get; set; }
        public int TaskId { get; set; }
    }
}
