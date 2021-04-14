using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Models.EducationInformation
{
    public class EducationInformationList
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Section { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
