using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Role
{
    public class RoleUpdate
    {
        public string Id { get; set; }

        [DisplayName("Rol"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(20, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Name { get; set; }
    }
}
