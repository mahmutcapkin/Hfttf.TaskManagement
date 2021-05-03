using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Job
{
    public class JobUpdate
    {
        public int Id { get; set; }
        [DisplayName("Meslek"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
       StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Name { get; set; }
    }
}
