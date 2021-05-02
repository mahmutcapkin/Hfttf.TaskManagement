using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.BankInformation
{
    public class BankInformationAdd
    {
        [DisplayName("Banka Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
          StringLength(250, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string BankName { get; set; }

        [DisplayName("Hesap Numarası"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
          StringLength(250, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string AccountNo { get; set; }

        [DisplayName("IBAN No"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
          StringLength(250, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string IBANNo { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
