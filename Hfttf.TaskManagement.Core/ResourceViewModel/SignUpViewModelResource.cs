using System;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.Core.ResourceViewModel
{
    public class SignUpViewModelResource
    {
        [Required(ErrorMessage = "Kullanıcı ismi gerekldir.")]
        public string UserName { get; set; }

        //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
        //public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz gereklidir.")]
        public string Password { get; set; }
    }
}
