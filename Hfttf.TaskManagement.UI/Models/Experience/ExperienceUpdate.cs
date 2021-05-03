using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Experience
{
    public class ExperienceUpdate
    {
        public int Id { get; set; }

        [DisplayName("Meslek"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
       StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Job { get; set; }

        [DisplayName("Firma Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
       StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Company { get; set; }

        [DisplayName("Başlangıç Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
       StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string StartDate { get; set; }

        [DisplayName("Bitiş Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
       StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
