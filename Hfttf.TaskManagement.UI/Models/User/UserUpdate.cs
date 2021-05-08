using Hfttf.TaskManagement.UI.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.User
{
    public class UserUpdate
    {
        public string Id { get; set; }

        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
     StringLength(20, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string UserName { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
     StringLength(30, ErrorMessage = "{0} max. {1} karakter olmalı")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Ad"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
     StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string FirstName { get; set; }

        [DisplayName("Soyad"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
     StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string LastName { get; set; }

        [DisplayName("Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }

        [EnumDataType(typeof(GenderType))]
        [DisplayName("Cinsiyet")]
        public GenderType Gender { get; set; }

        [DisplayName("Profil Resmi")]
        public string PictureUrl { get; set; }

        [Display(Name = "Profil Fotoğrafı")]
        public IFormFile ProfilePicture { get; set; }

        [DisplayName("Departman")]
        public int? DepartmentId { get; set; }

        [DisplayName("Telefon Numarası"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
       StringLength(11, ErrorMessage = "{0} max. {1} karakter olmalı")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Meslek")]
        public int? JobId { get; set; }
    }
}
