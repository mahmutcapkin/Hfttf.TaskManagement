using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Leave
{
    public class LeaveAdd
    {
        [DisplayName("Açıklama"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
         StringLength(200, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Title { get; set; }

        [DisplayName("Başlangıç Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public DateTime StartDate { get; set; }

        [DisplayName("Bitiş Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public DateTime EndDate { get; set; }
        public string CreateBy { get; set; }

        [DisplayName("Kullanıcı"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string ApplicationUserId { get; set; }
    }
}
