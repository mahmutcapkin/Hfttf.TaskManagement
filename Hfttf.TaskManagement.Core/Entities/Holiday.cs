using Hfttf.TaskManagement.Core.Entities.Base;
using System;

namespace Hfttf.TaskManagement.Core.Entities
{
    public class Holiday : Entity
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NumberOfDay { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
