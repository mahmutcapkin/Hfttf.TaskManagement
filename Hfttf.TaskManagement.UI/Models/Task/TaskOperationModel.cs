using Hfttf.TaskManagement.UI.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Task
{
    public class TaskOperationModel
    {
        public int Id { get; set; }

        [DisplayName("Başlık"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
    StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Title { get; set; }

        [DisplayName("Açıklama"), Required(ErrorMessage = "{0} alanı boş geçilemez..."),
    StringLength(300, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string Description { get; set; }

        [EnumDataType(typeof(PriorityLevel))]
        [DisplayName("Öncelik")]
        public PriorityLevel Priority { get; set; }

        [DisplayName("Bitiş Tarihi"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public DateTime DueDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public int ProjectId { get; set; }

        [DisplayName("Görev Durumu"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public int TaskStatusId { get; set; }
    }
}
