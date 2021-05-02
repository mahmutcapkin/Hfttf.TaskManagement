using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Address
{
    public class AddressUpdate
    {
        [Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public int Id { get; set; }

        [DisplayName("Adres"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
           StringLength(250, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Description { get; set; }

        [DisplayName("Şehir"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
          StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string City { get; set; }

        [DisplayName("Ülke"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
          StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Country { get; set; }

        [DisplayName("Posta Kodu"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
          StringLength(10, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string ZipCode { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
