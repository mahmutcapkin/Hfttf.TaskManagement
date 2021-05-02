using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.EmergencyContactInfo
{
    public class EmergencyContactInfoAdd
    {
        [DisplayName("Ad Soyad"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Name { get; set; }


        [DisplayName("Yakınlık Durumu"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string RelationShip { get; set; }


        [DisplayName("Telefon Numarası"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
        StringLength(11, ErrorMessage = "{0} max. {1} karakter olmalı")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^(0(\d{3})(\d{3})(\d{2})(\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
        public string ApplicationUserId { get; set; }
    }
}
