using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Department
{
    public class DepartmentUpdate
    {
        public int Id { get; set; }
        [DisplayName("Departman"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Name { get; set; }
    }
}
