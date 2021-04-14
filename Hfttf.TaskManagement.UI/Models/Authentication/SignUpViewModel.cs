using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Authentication
{
    public class SignUpViewModel
    {

        //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
        //public string PhoneNumber { get; set; }

        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
            StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Username { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
            StringLength(35, ErrorMessage = "{0} max. {1} karakter olmalı"),
            EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-posta adresi giriniz")]
        public string Email { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
            DataType(DataType.Password),
            StringLength(16, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Password { get; set; }

        [DisplayName("Şifre(Tekrar)"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
            DataType(DataType.Password),
            StringLength(16, ErrorMessage = "{0} max. {1} karakter olmalı"),
            Compare("Password", ErrorMessage = "{0} ile {1} uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}
