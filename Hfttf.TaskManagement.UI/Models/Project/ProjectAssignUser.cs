using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Project
{
    public class ProjectAssignUser
    {
        [DisplayName("Projeler"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public int Id { get; set; }

        [DisplayName("Kullanıcılar"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public List<string> UserIds { get; set; }
    }
}
