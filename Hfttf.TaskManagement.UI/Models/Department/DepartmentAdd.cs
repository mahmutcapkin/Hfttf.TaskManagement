using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Department
{
    public class DepartmentAdd
    {
        [DisplayName("Departman"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
          StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Name { get; set; }
    }
}
