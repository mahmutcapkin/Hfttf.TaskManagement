using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hfttf.TaskManagement.UI.Models.Leader
{
    public class LeaderUpdate
    {
        public int Id { get; set; }

        [DisplayName("Kullanıcılar"), Required(ErrorMessage = "{0} alanı boş geçilemez...")]
        public string ApplicationUserId { get; set; }

        public int? ProjectId { get; set; }
    }
}
