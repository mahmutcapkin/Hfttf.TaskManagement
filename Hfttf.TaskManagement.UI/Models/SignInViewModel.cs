using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models
{
    public class SignInViewModel
    {

        [DisplayName("Email"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
            StringLength(35, ErrorMessage = "{0} max. {1} karakter olmalı"),
            EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-posta adresi giriniz")]
        public string Email { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
            DataType(DataType.Password),
            StringLength(16, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Password { get; set; }
    }
}
