using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.EducationInformation
{
    public class EducationInformationUpdate
    {
        [Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public int Id { get; set; }

        [DisplayName("Okul Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string SchoolName { get; set; }

        [DisplayName("Bölüm"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(75, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Section { get; set; }

        [DisplayName("Başlangıç Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string StartDate { get; set; }

        [DisplayName("Bitiş Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(100, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
