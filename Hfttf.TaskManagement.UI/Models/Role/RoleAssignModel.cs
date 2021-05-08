using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Role
{
    public class RoleAssignModel
    {
        [DisplayName("Kullanıcılar"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string UserId { get; set; }

        [DisplayName("Roller"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public List<string> RoleId { get; set; }
    }
}
